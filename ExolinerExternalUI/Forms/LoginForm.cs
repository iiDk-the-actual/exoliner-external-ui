using ExolinerExternalUI.Classes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExolinerExternalUI {
    public partial class LoginForm : Form {
        private string defaultLoginButtonText = "";
        private string errorMessage = "";
        public LoginForm() {
            InitializeComponent();
            this.rememberCheck.Checked = FileManager.CurrentSettings.AutoLogin;
            this.passwordBox.Text = FileManager.CurrentSettings.JWT;
            defaultLoginButtonText = this.loginButton.Text;
        }

        private void processLogin_DoWork(object sender, DoWorkEventArgs e) {
            if (this.rememberCheck.Checked) {
                FileManager.CurrentSettings.JWT = this.passwordBox.Text;
            }
            FileManager.CurrentSettings.AutoLogin = this.rememberCheck.Checked;

            ExolinerApiWrapper.JSONWebToken = this.passwordBox.Text;
            Task<ExolinerApiWrapper.ExolinerUser> request = ExolinerApiWrapper.GetInfo();
            request.Wait();
            ExolinerApiWrapper.ExolinerUser result = request.Result;
            Thread.Sleep(500);
            errorMessage = result.success ? "" : result.message;
        }
        private void processLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.errorLabel.Text = errorMessage;
            this.loginButton.Text = defaultLoginButtonText;
            this.loginButton.Enabled = true;
            if (errorMessage == "") {
                // No error, we can continue
                Task.Run(() => {
                    this.Invoke((MethodInvoker)delegate { this.Hide(); });
                });
                Form editorForm = new ExecutorForm();
                editorForm.Owner = this;
                editorForm.ShowDialog();
                this.Close();
            }
        }

        private void loginButton_Click(object sender, System.EventArgs e) {
            if (processLogin.IsBusy) return; // Already trying to login
            processLogin.RunWorkerAsync();
            errorMessage = "";
            this.errorLabel.Text = "";
            this.loginButton.Enabled = false;
            this.loginButton.Text = "...";
        }


        private void LoginForm_Load(object sender, System.EventArgs e) {
            this.errorLabel.Text = "";

            this.passwordBox.TextChanged += (s, ex) => {
                placeholderLabel.Visible = string.IsNullOrEmpty(passwordBox.Text);
            };

            this.passwordBox.GotFocus += (s, ex) => {
                placeholderLabel.Visible = string.IsNullOrEmpty(passwordBox.Text);
            };

            this.passwordBox.LostFocus += (s, ex) => {
                placeholderLabel.Visible = string.IsNullOrEmpty(passwordBox.Text);
            };

            this.dragBar.MouseDown += mouseDown_Event;
            this.dragBar.MouseMove += mouseMove_event;
            this.dragBar.MouseUp += mouseUp_event;

            passwordBox.Paint += (s, ex) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(255, 33, 81, 160), 1))
                {
                    Rectangle rect = new Rectangle(0, 0, label1.Width - 1, label1.Height - 1);
                    ex.Graphics.DrawRectangle(pen, rect);
                }
            };

            WinExternals.AnimateWindow(this.Handle, 500, WinExternals.AnimateWindowFlags.AW_BLEND);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            string part1 = "EXO";
            string part2 = "LINER";

            Font font = new Font("Myanmar Text", 24F, FontStyle.Bold);

            SizeF size1 = e.Graphics.MeasureString(part1, font);
            SizeF size2 = e.Graphics.MeasureString(part2, font);

            float totalWidth = size1.Width + size2.Width;

            float startX = (this.ClientSize.Width - totalWidth) / 2;
            float y = 30;

            using (Brush blue = new SolidBrush(Color.FromArgb(42, 117, 237)))
            using (Brush black = new SolidBrush(Color.White))
            {
                e.Graphics.DrawString(part1, font, blue, startX + 7, y);
                e.Graphics.DrawString(part2, font, black, startX + size1.Width - 7, y);
            }
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

        private void close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
