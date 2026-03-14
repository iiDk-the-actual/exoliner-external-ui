using ExolinerExternalUI.Classes;
using ExolinerExternalUI.Forms;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExolinerExternalUI
{
    public partial class ExecutorForm : Form
    {

        private string currentlyOpen = null;
        private FastColoredTextBox codeEditor;
        private SettingsForm SettingsForm = new SettingsForm();
        private AboutBox AboutBox = new AboutBox();
        private int unsavedFiles = 0;

        private FastColoredTextBox makeEditor(string code = "")
        {
            FastColoredTextBox editor = new FastColoredTextBox();
            editor.AutoCompleteBracketsList = new char[] {
                '(', ')', '{', '}', '[', ']', '\"', '\"', '\'', '\''
            };
            editor.Name = "editor";
            editor.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>.+)\r\n";
            editor.AutoScrollMinSize = new System.Drawing.Size(323, 14);
            editor.BackBrush = null;
            editor.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            editor.CharHeight = 14;
            editor.CharWidth = 8;
            editor.CommentPrefix = "--";
            editor.Cursor = System.Windows.Forms.Cursors.IBeam;
            // ── colours ──────────────────────────────────────────────────────
            editor.BackColor = Color.FromArgb(0x0A, 0x0A, 0x0F); // editor bg
            editor.ForeColor = Color.FromArgb(0xD4, 0xD4, 0xD4); // default text
            editor.IndentBackColor = Color.FromArgb(0x0D, 0x14, 0x25); // line-number gutter bg
            editor.LineNumberColor = Color.FromArgb(0x4E, 0x62, 0x85); // line-number text
            editor.ServiceLinesColor = Color.FromArgb(0x0D, 0x14, 0x25); // fold/service line strip
            editor.CaretColor = Color.FromArgb(0xD4, 0xD4, 0xD4);
            // ─────────────────────────────────────────────────────────────────
            editor.DisabledColor = System.Drawing.Color.FromArgb(20, 34, 61, 180);
            editor.Dock = System.Windows.Forms.DockStyle.Fill;
            editor.Font = new System.Drawing.Font("Courier New", 9.75F);
            editor.IsReplaceMode = false;
            editor.Language = FastColoredTextBoxNS.Language.Lua;
            editor.LeftBracket = '(';
            editor.LeftBracket2 = '{';
            editor.Location = new System.Drawing.Point(3, 3);
            editor.Paddings = new System.Windows.Forms.Padding(0);
            editor.RightBracket = ')';
            editor.RightBracket2 = '}';
            editor.SelectionColor = System.Drawing.Color.FromArgb(60, 0, 0, 255);
            editor.Size = new System.Drawing.Size(595, 367);
            editor.TabIndex = 3;
            editor.Text = code;
            editor.Zoom = 100;
            editor.TextChanged += this.Editor_TextChanged;
            return editor;
        }

        private void playSound(Stream sound)
        {
            if (!FileManager.CurrentSettings.SoundEffects) return;
            new SoundPlayer(sound).Play();
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            FastColoredTextBox self = (FastColoredTextBox)sender;
            TabPage page = (TabPage)self.Parent;
            if (page.Text.EndsWith("*")) return;
            page.Text = $"{page.Text}*";
            unsavedFiles++;
        }

        public ExecutorForm()
        {
            InitializeComponent();
            this.scriptPages.HandleCreated += scriptPages_HandleCreated;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WinExternals.AnimateWindow(this.Handle, 500, WinExternals.AnimateWindowFlags.AW_BLEND);
            this.dragBar.MouseDown += mouseDown_Event;
            this.dragBar.MouseMove += mouseMove_event;
            this.dragBar.MouseUp += mouseUp_event;
            this.Text = $"Exoliner - Logged in as {ExolinerApiWrapper.currentUser.data.username}";
            this.rankLabel.Text = $"Your rank is {ExolinerApiWrapper.currentUser.data.rank}";
            this.scriptsList.Items.Clear();
            foreach (string script in FileManager.GetScripts())
            {
                this.scriptsList.Items.Add(Path.GetFileName(script));
            }
            // Open placeholder tab so the control doesn't break on first render
            int index = this.scriptPages.TabCount - 1;
            this.scriptPages.TabPages.Insert(index, "Tab 1");
            TabPage targetPage = this.scriptPages.TabPages[index];
            targetPage.Controls.Add(makeEditor("-- Welcome to Exoliner external!"));
            this.scriptPages.SelectedIndex = 0;
            playSound(Properties.Resources.BellRing);
            this.saveFileDialog.InitialDirectory = FileManager.BasePath;
            this.openFileDialog.InitialDirectory = FileManager.BasePath;
        }

        private Point dragOffset;
        private bool mouseDown;

        private void mouseDown_Event(object sender, MouseEventArgs args)
        {
            dragOffset = args.Location;
            mouseDown = true;
        }

        private void mouseMove_event(object sender, MouseEventArgs args)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(args.Location);
                Location = new Point(currentScreenPos.X - dragOffset.X, currentScreenPos.Y - dragOffset.Y);
            }
        }

        private void mouseUp_event(object sender, MouseEventArgs args) =>
            mouseDown = false;

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (this.codeEditor == null) return;
            this.codeEditor.Clear();
            playSound(Properties.Resources.Click);
        }

        private ExolinerApiWrapper.BaseExolinerData executionResult = null;
        private void executeButton_Click(object sender, EventArgs e)
        {
            if (executionWorker.IsBusy) return;
            this.executionStatus.Text = "Execution status: Running code";
            executionResult = null;
            executionWorker.RunWorkerAsync();
            playSound(Properties.Resources.Click);
        }

        private void executionWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (this.codeEditor == null) return;
            ExolinerApiWrapper.Execute(this.codeEditor.Text, this.convertCheck.Checked).Wait();
        }

        private void executionWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (executionResult != null && !executionResult.success)
            {
                MessageBox.Show(executionResult.message);
            }
            this.executionStatus.Text = "Execution status: Idle";
        }

        private void openFile(string targetPath)
        {
            if (!File.Exists(targetPath)) return;
            currentlyOpen = targetPath;
            TabPage targetPage = null;
            FastColoredTextBox editor = null;
            int index = 0;
            for (int i = 0; i < this.scriptPages.TabPages.Count; i++)
            {
                TabPage page = this.scriptPages.TabPages[i];
                if (page.Text.TrimEnd('*') == Path.GetFileName(targetPath))
                {
                    index = i;
                    targetPage = page;
                    editor = targetPage.Controls[0] as FastColoredTextBox;
                    break;
                }
            }
            string source = File.ReadAllText(targetPath);
            if (targetPage == null)
            {
                index = this.scriptPages.TabCount - 1;
                this.scriptPages.TabPages.Insert(index, Path.GetFileName(targetPath));
                targetPage = this.scriptPages.TabPages[index];
                editor = makeEditor(source);
                targetPage.Controls.Add(editor);
                targetPage.Name = targetPath;
                this.scriptPages.SelectedIndex = index;
                return;
            }
            this.scriptPages.SelectedIndex = index;
            if (targetPage.Text.EndsWith("*")) unsavedFiles--;
            targetPage.Text = targetPage.Text.TrimEnd('*');
            if (editor.Text == source) return;
            editor.Text = source;
        }

        private void scriptsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.scriptsList.SelectedItem == null) return;
            string targetPath = Path.Combine(FileManager.ScriptsPath, this.scriptsList.SelectedItem.ToString());
            openFile(targetPath);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            openFile(this.openFileDialog.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentlyOpen == null)
            {
                this.saveFileDialog.ShowDialog();
                return;
            }
            string targetPath = Path.Combine(FileManager.ScriptsPath, currentlyOpen);
            File.WriteAllText(targetPath, this.codeEditor.Text);
            TabPage page = (TabPage)this.codeEditor.Parent;
            if (page.Text.EndsWith("*")) unsavedFiles--;
            page.Text = page.Text.TrimEnd('*');
        }

        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.codeEditor == null) return;
            string fileName = this.saveFileDialog.FileName;
            File.WriteAllText(fileName, this.codeEditor.Text);
            if (currentlyOpen == null)
            {
                currentlyOpen = this.saveFileDialog.FileName;
                TabPage page = (TabPage)this.codeEditor.Parent;
                foreach (TabPage tabPage in this.scriptPages.TabPages)
                {
                    if (tabPage.Name == fileName && page != tabPage)
                    {
                        tabPage.Dispose();
                    }
                }
                if (page.Text.EndsWith("*")) unsavedFiles--;
                page.Text = Path.GetFileName(fileName).TrimEnd('*');
                page.Name = fileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog();
        }

        // https://stackoverflow.com/questions/36895089/tabcontrol-with-close-and-add-button/36900582#36900582
        private void scriptPages_MouseDown(object sender, MouseEventArgs e)
        {
            int lastIndex = this.scriptPages.TabCount - 1;
            if (this.scriptPages.GetTabRect(lastIndex).Contains(e.Location))
            {
                this.scriptPages.TabPages.Insert(lastIndex, $"Tab {lastIndex + 1}");
                FastColoredTextBox editor = makeEditor();
                TabPage page = this.scriptPages.TabPages[lastIndex];
                page.Controls.Add(editor);
                this.codeEditor = editor;
                this.scriptPages.SelectedIndex = lastIndex;
                return;
            }
            for (int i = 0; i < this.scriptPages.TabPages.Count; i++)
            {
                Rectangle tabRect = this.scriptPages.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                TabPage page = this.scriptPages.TabPages[i];

                Image closeImage = Properties.Resources.CloseButton;
                Rectangle imageRect = new Rectangle(
                    tabRect.Right - closeImage.Width,
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);

                if (imageRect.Contains(e.Location))
                {
                    bool hasUnsaved = page.Text.EndsWith("*");
                    if (!hasUnsaved ||
                        MessageBox.Show("Are you sure you want to close this tab?\nYou will lose all unsaved changes.",
                                        "Are you sure you want to exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (hasUnsaved) unsavedFiles--;
                        this.scriptPages.TabPages.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void scriptPages_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= this.scriptPages.TabCount) return;
            // Only handle calls that originated from PaintFlatChrome — skip
            // anything the native control fires on its own (stale state).
            if (this.scriptPages.PaintingIndex != e.Index) return;

            var tabPage = this.scriptPages.TabPages[e.Index];
            var tabRect = e.Bounds;

            bool isSelected = this.scriptPages.PaintingSelected;
            Color textColor = isSelected
                ? Color.FromArgb(197, 218, 252)
                : Color.FromArgb(52, 74, 113);

            using (Font myanmarFont = new Font("Myanmar Text", tabPage.Font.Size))
            {
                if (e.Index == this.scriptPages.TabCount - 1)
                {
                    var addImage = Properties.Resources.AddButton;
                    e.Graphics.DrawImage(addImage,
                        tabRect.Left + (tabRect.Width - addImage.Width) / 2,
                        tabRect.Top + (tabRect.Height - addImage.Height) / 2);
                }
                else
                {
                    var closeImage = Properties.Resources.CloseButton;
                    e.Graphics.DrawImage(closeImage,
                        tabRect.Right - closeImage.Width,
                        tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                    TextRenderer.DrawText(e.Graphics, tabPage.Text, myanmarFont,
                        tabRect, textColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }
            }
        }

        private void scriptPages_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == this.scriptPages.TabCount - 1)
            {
                e.Cancel = true;
                return;
            }
            Control control = e.TabPage.Controls[0];
            codeEditor = control.Name == "editor" ? control as FastColoredTextBox : null;
            currentlyOpen = File.Exists(e.TabPage.Name) ? e.TabPage.Name : null;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int TCM_SETMINTABWIDTH = 0x1300 + 49;
        private void scriptPages_HandleCreated(object sender, EventArgs e)
        {
            SendMessage(this.scriptPages.Handle, TCM_SETMINTABWIDTH, IntPtr.Zero, (IntPtr)16);
        }

        private async void r6Button_Click(object sender, EventArgs e)
        {
            playSound(Properties.Resources.Click);
            await ExolinerApiWrapper.Execute("require(8694264081).load(owner.Name)", false);
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            playSound(Properties.Resources.Click);
            await ExolinerApiWrapper.Execute("owner:LoadCharacter()", false);
        }

        private void scriptsListTimer_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Interval = Math.Min(Math.Max(FileManager.CurrentSettings.FolderRescanTime, 5000), 1000);
            string[] scripts = FileManager.GetScripts();
            var itemsToRemove = new List<object>();
            foreach (string existing in scriptsList.Items)
            {
                string path = Path.Combine(FileManager.ScriptsPath, existing);
                if (!scripts.Contains(path)) itemsToRemove.Add(existing);
            }
            foreach (var item in itemsToRemove) scriptsList.Items.Remove(item);
            foreach (string script in scripts)
            {
                string name = Path.GetFileName(script);
                if (!scriptsList.Items.Contains(name)) scriptsList.Items.Add(name);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SettingsForm.IsDisposed) SettingsForm = new SettingsForm();
            Point localLocation = this.Location;
            Size localSize = this.Size;
            Size settingsSize = SettingsForm.Size;
            SettingsForm.Location = new Point(
                localLocation.X + (localSize.Width - settingsSize.Width) / 2,
                localLocation.Y + (localSize.Height - settingsSize.Height) / 2);
            SettingsForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AboutBox.IsDisposed) AboutBox = new AboutBox();
            AboutBox.Show();
        }

        private List<Process> oldRobloxProcesses = new List<Process>();
        private void processScanTimer_Tick(object sender, EventArgs e)
        {
            if (!FileManager.CurrentSettings.AutoExec) return;
            Process[] robloxProcesses = Process.GetProcessesByName("RobloxPlayerBeta");
            HashSet<int> currentIds = new HashSet<int>(robloxProcesses.Select(p => p.Id));
            HashSet<int> oldIds = new HashSet<int>(oldRobloxProcesses.Select(p => p.Id));
            List<Process> newProcs = robloxProcesses.Where(p => !oldIds.Contains(p.Id)).ToList();
            foreach (var process in newProcs)
            {
                Task.Run(processAutoExec);
                oldRobloxProcesses.Add(process);
            }
            oldRobloxProcesses.RemoveAll(p => !currentIds.Contains(p.Id));
        }

        private void processAutoExec()
        {
            Console.WriteLine("Roblox process detected. Starting handler...");
            Task.Delay(1000);
            string payload = "game:GetService('Players'):WaitForChild(owner.Name, 1e3);";
            foreach (string scriptPath in FileManager.GetAutoExec())
            {
                string scriptData = File.ReadAllText(scriptPath);
                string fixedScript = String.Concat(payload, scriptData);
                Task.Run(() => ExolinerApiWrapper.Execute(fixedScript, true));
            }
            Console.WriteLine("Started autoexec folder.");
        }

        private void ExecutorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedFiles <= 0) return;
            if (MessageBox.Show("You have unsaved files open, are you sure you want to exit?",
                                "Are you sure you want to exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                unsavedFiles = 0;
                return;
            }
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void executionStatus_Click(object sender, EventArgs e)
        {

        }

        private void convertCheck_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}