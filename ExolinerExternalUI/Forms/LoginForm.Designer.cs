using System.Drawing;
using System.Windows.Forms;

namespace ExolinerExternalUI {
    partial class LoginForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.randomPhraseLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rememberCheck = new System.Windows.Forms.CheckBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.processLogin = new System.ComponentModel.BackgroundWorker();
            this.dragBar = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.placeholderLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.dragBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // randomPhraseLabel
            // 
            this.randomPhraseLabel.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomPhraseLabel.ForeColor = System.Drawing.Color.White;
            this.randomPhraseLabel.Location = new System.Drawing.Point(5, 69);
            this.randomPhraseLabel.Name = "randomPhraseLabel";
            this.randomPhraseLabel.Size = new System.Drawing.Size(274, 17);
            this.randomPhraseLabel.TabIndex = 1;
            this.randomPhraseLabel.Text = "external v1.0.4.1";
            this.randomPhraseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rememberCheck);
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Location = new System.Drawing.Point(5, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 48);
            this.panel1.TabIndex = 3;
            // 
            // rememberCheck
            // 
            this.rememberCheck.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.rememberCheck.FlatAppearance.BorderSize = 0;
            this.rememberCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rememberCheck.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberCheck.ForeColor = System.Drawing.Color.White;
            this.rememberCheck.Location = new System.Drawing.Point(0, 0);
            this.rememberCheck.Margin = new System.Windows.Forms.Padding(0);
            this.rememberCheck.Name = "rememberCheck";
            this.rememberCheck.Size = new System.Drawing.Size(121, 18);
            this.rememberCheck.TabIndex = 9;
            this.rememberCheck.Text = "Remember me";
            this.rememberCheck.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.rememberCheck.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            this.errorLabel.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(148, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(126, 18);
            this.errorLabel.TabIndex = 8;
            this.errorLabel.Text = "403 Forbidden";
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.ForeColor = System.Drawing.Color.White;
            this.passwordBox.Location = new System.Drawing.Point(5, 99);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(274, 22);
            this.passwordBox.TabIndex = 5;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(79)))), ((int)(((byte)(215)))));
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(0, 21);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(274, 32);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "Login";
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // processLogin
            // 
            this.processLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.processLogin_DoWork);
            this.processLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.processLogin_RunWorkerCompleted);
            // 
            // dragBar
            // 
            this.dragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(36)))), ((int)(((byte)(65)))));
            this.dragBar.Controls.Add(this.button1);
            this.dragBar.Controls.Add(this.panel3);
            this.dragBar.Controls.Add(this.label1);
            this.dragBar.Location = new System.Drawing.Point(0, 0);
            this.dragBar.Margin = new System.Windows.Forms.Padding(0);
            this.dragBar.Name = "dragBar";
            this.dragBar.Size = new System.Drawing.Size(284, 30);
            this.dragBar.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::ExolinerExternalUI.Properties.Resources.favicon;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 30);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // placeholderLabel
            // 
            this.placeholderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(20)))), ((int)(((byte)(32)))));
            this.placeholderLabel.Font = this.passwordBox.Font;
            this.placeholderLabel.ForeColor = System.Drawing.Color.White;
            this.placeholderLabel.Location = new System.Drawing.Point(6, 99);
            this.placeholderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.placeholderLabel.Name = "placeholderLabel";
            this.placeholderLabel.Size = new System.Drawing.Size(165, 23);
            this.placeholderLabel.TabIndex = 0;
            this.placeholderLabel.Text = "JSON Web Token";
            this.placeholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(79)))), ((int)(((byte)(215)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Myanmar Text", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(258, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.close);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.placeholderLabel);
            this.Controls.Add(this.dragBar);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.randomPhraseLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exoliner - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.dragBar.ResumeLayout(false);
            this.dragBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label randomPhraseLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label placeholderLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label errorLabel;
        private System.ComponentModel.BackgroundWorker processLogin;
        private System.Windows.Forms.CheckBox rememberCheck;
        private System.Windows.Forms.Panel dragBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private Button button1;
    }
}