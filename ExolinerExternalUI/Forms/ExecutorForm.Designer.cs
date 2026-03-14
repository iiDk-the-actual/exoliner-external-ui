using System.Drawing;
using System.Windows.Forms;

namespace ExolinerExternalUI
{
    partial class ExecutorForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecutorForm));
            this.scriptsList = new System.Windows.Forms.ListBox();
            this.bottomButtons = new System.Windows.Forms.Panel();
            this.r6Button = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.executionStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rankLabel = new System.Windows.Forms.Label();
            this.convertCheck = new System.Windows.Forms.CheckBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.executeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dragBar = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptPages = new ExolinerExternalUI.FlatTabControl();
            this.tabPlus = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.executionWorker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.scriptsListTimer = new System.Windows.Forms.Timer(this.components);
            this.processScanTimer = new System.Windows.Forms.Timer(this.components);
            this.bottomButtons.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.dragBar.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.scriptPages.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scriptsList
            // 
            this.scriptsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(26)))));
            this.scriptsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scriptsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptsList.ForeColor = System.Drawing.Color.White;
            this.scriptsList.FormattingEnabled = true;
            this.scriptsList.Location = new System.Drawing.Point(0, 0);
            this.scriptsList.Name = "scriptsList";
            this.scriptsList.Size = new System.Drawing.Size(200, 394);
            this.scriptsList.TabIndex = 1;
            this.scriptsList.SelectedIndexChanged += new System.EventHandler(this.scriptsList_SelectedIndexChanged);
            // 
            // bottomButtons
            // 
            this.bottomButtons.Controls.Add(this.rankLabel);
            this.bottomButtons.Controls.Add(this.r6Button);
            this.bottomButtons.Controls.Add(this.refreshButton);
            this.bottomButtons.Controls.Add(this.executionStatus);
            this.bottomButtons.Controls.Add(this.panel3);
            this.bottomButtons.Controls.Add(this.clearButton);
            this.bottomButtons.Controls.Add(this.executeButton);
            this.bottomButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomButtons.Location = new System.Drawing.Point(5, 430);
            this.bottomButtons.Name = "bottomButtons";
            this.bottomButtons.Padding = new System.Windows.Forms.Padding(5);
            this.bottomButtons.Size = new System.Drawing.Size(809, 40);
            this.bottomButtons.TabIndex = 2;
            // 
            // r6Button
            // 
            this.r6Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(79)))), ((int)(((byte)(215)))));
            this.r6Button.FlatAppearance.BorderSize = 0;
            this.r6Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r6Button.Font = new System.Drawing.Font("Myanmar Text", 12F);
            this.r6Button.ForeColor = System.Drawing.Color.White;
            this.r6Button.Location = new System.Drawing.Point(609, 5);
            this.r6Button.Name = "r6Button";
            this.r6Button.Size = new System.Drawing.Size(45, 30);
            this.r6Button.TabIndex = 0;
            this.r6Button.Text = "R6";
            this.r6Button.UseVisualStyleBackColor = false;
            this.r6Button.Click += new System.EventHandler(this.r6Button_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(79)))), ((int)(((byte)(215)))));
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Location = new System.Drawing.Point(660, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(45, 30);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "RE";
            this.refreshButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // executionStatus
            // 
            this.executionStatus.BackColor = System.Drawing.Color.Transparent;
            this.executionStatus.Font = new System.Drawing.Font("Myanmar Text", 8.25F);
            this.executionStatus.ForeColor = System.Drawing.Color.White;
            this.executionStatus.Location = new System.Drawing.Point(305, 17);
            this.executionStatus.Name = "executionStatus";
            this.executionStatus.Size = new System.Drawing.Size(150, 20);
            this.executionStatus.TabIndex = 5;
            this.executionStatus.Text = "Execution status: Idle";
            this.executionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.executionStatus.Click += new System.EventHandler(this.executionStatus_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.convertCheck);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(644, 5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(160, 30);
            this.panel3.TabIndex = 2;
            // 
            // rankLabel
            // 
            this.rankLabel.BackColor = System.Drawing.Color.Transparent;
            this.rankLabel.Font = new System.Drawing.Font("Myanmar Text", 8.25F);
            this.rankLabel.ForeColor = System.Drawing.Color.White;
            this.rankLabel.Location = new System.Drawing.Point(305, 4);
            this.rankLabel.Name = "rankLabel";
            this.rankLabel.Size = new System.Drawing.Size(150, 13);
            this.rankLabel.TabIndex = 4;
            // 
            // convertCheck
            // 
            this.convertCheck.AutoSize = true;
            this.convertCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.convertCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.convertCheck.Font = new System.Drawing.Font("Myanmar Text", 8.25F);
            this.convertCheck.ForeColor = System.Drawing.Color.White;
            this.convertCheck.Location = new System.Drawing.Point(67, 6);
            this.convertCheck.Name = "convertCheck";
            this.convertCheck.Size = new System.Drawing.Size(93, 24);
            this.convertCheck.TabIndex = 3;
            this.convertCheck.Text = "Auto Convert";
            this.convertCheck.UseVisualStyleBackColor = false;
            this.convertCheck.CheckedChanged += new System.EventHandler(this.convertCheck_CheckedChanged);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(79)))), ((int)(((byte)(215)))));
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Myanmar Text", 12F);
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(155, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(144, 30);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // executeButton
            // 
            this.executeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(79)))), ((int)(((byte)(215)))));
            this.executeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.executeButton.FlatAppearance.BorderSize = 0;
            this.executeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.executeButton.Font = new System.Drawing.Font("Myanmar Text", 12F);
            this.executeButton.ForeColor = System.Drawing.Color.White;
            this.executeButton.Location = new System.Drawing.Point(5, 5);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(144, 30);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel1.Controls.Add(this.dragBar);
            this.panel1.Controls.Add(this.scriptPages);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.bottomButtons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 29, 5, 5);
            this.panel1.Size = new System.Drawing.Size(819, 475);
            this.panel1.TabIndex = 3;
            // 
            // dragBar
            // 
            this.dragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(36)))), ((int)(((byte)(65)))));
            this.dragBar.Controls.Add(this.button1);
            this.dragBar.Controls.Add(this.menuStrip);
            this.dragBar.Controls.Add(this.panel4);
            this.dragBar.Controls.Add(this.label1);
            this.dragBar.Location = new System.Drawing.Point(0, 0);
            this.dragBar.Margin = new System.Windows.Forms.Padding(0);
            this.dragBar.Name = "dragBar";
            this.dragBar.Size = new System.Drawing.Size(819, 30);
            this.dragBar.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(74)))), ((int)(((byte)(132)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(793, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(154, 3);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(159, 29);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Myanmar Text", 9F);
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(113, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Myanmar Text", 9F);
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::ExolinerExternalUI.Properties.Resources.favicon;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(30, 30);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exoliner External";
            // 
            // scriptPages
            // 
            this.scriptPages.AllowDrop = true;
            this.scriptPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.scriptPages.Controls.Add(this.tabPlus);
            this.scriptPages.Cursor = System.Windows.Forms.Cursors.Default;
            this.scriptPages.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.scriptPages.ItemSize = new System.Drawing.Size(53, 20);
            this.scriptPages.Location = new System.Drawing.Point(8, 36);
            this.scriptPages.Name = "scriptPages";
            this.scriptPages.Padding = new System.Drawing.Point(12, 4);
            this.scriptPages.SelectedIndex = 0;
            this.scriptPages.Size = new System.Drawing.Size(600, 394);
            this.scriptPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.scriptPages.TabIndex = 4;
            this.scriptPages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.scriptPages_DrawItem);
            this.scriptPages.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.scriptPages_Selecting);
            this.scriptPages.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scriptPages_MouseDown);
            // 
            // tabPlus
            // 
            this.tabPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.tabPlus.ForeColor = System.Drawing.Color.White;
            this.tabPlus.Location = new System.Drawing.Point(4, 24);
            this.tabPlus.Name = "tabPlus";
            this.tabPlus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlus.Size = new System.Drawing.Size(592, 366);
            this.tabPlus.TabIndex = 1;
            this.tabPlus.Text = "+";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(26)))));
            this.panel2.Controls.Add(this.scriptsList);
            this.panel2.Location = new System.Drawing.Point(614, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 394);
            this.panel2.TabIndex = 3;
            // 
            // executionWorker
            // 
            this.executionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.executionWorker_DoWork);
            this.executionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.executionWorker_RunWorkerCompleted);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Lua files|*.lua|Luau files|*.luau|Text files|*.txt|All files|*.*";
            this.openFileDialog.InitialDirectory = ".";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "luau";
            this.saveFileDialog.Filter = "Lua files|*.lua|Luau files|*.luau|Text files|*.txt|All files|*.*";
            this.saveFileDialog.InitialDirectory = ".";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // scriptsListTimer
            // 
            this.scriptsListTimer.Enabled = true;
            this.scriptsListTimer.Interval = 3000;
            this.scriptsListTimer.Tick += new System.EventHandler(this.scriptsListTimer_Tick);
            // 
            // processScanTimer
            // 
            this.processScanTimer.Enabled = true;
            this.processScanTimer.Interval = 1000;
            this.processScanTimer.Tick += new System.EventHandler(this.processScanTimer_Tick);
            // 
            // ExecutorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 475);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ExecutorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exoliner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExecutorForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.bottomButtons.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.dragBar.ResumeLayout(false);
            this.dragBar.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.scriptPages.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox scriptsList;
        private System.Windows.Forms.Panel bottomButtons;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox convertCheck;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label rankLabel;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label executionStatus;
        private System.ComponentModel.BackgroundWorker executionWorker;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabPlus;
        private System.Windows.Forms.Button r6Button;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Timer scriptsListTimer;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Timer processScanTimer;
        // *** Changed from TabControl to FlatTabControl ***
        private FlatTabControl scriptPages;
        private Panel dragBar;
        private Button button1;
        private Panel panel4;
        private Label label1;
    }
}