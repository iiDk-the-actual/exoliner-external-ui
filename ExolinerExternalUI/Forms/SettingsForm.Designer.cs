namespace ExolinerExternalUI.Forms {
    partial class SettingsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scriptRefreshNum = new System.Windows.Forms.NumericUpDown();
            this.applyButton = new System.Windows.Forms.Button();
            this.autoexecCheck = new System.Windows.Forms.CheckBox();
            this.soundEffectsCheck = new System.Windows.Forms.CheckBox();
            this.customPayload = new System.Windows.Forms.CheckBox();
            this.customPayloadNote = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptRefreshNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scripts list refresh rate (ms)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.scriptRefreshNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(259, 20);
            this.panel1.TabIndex = 0;
            // 
            // scriptRefreshNum
            // 
            this.scriptRefreshNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptRefreshNum.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scriptRefreshNum.Location = new System.Drawing.Point(143, 0);
            this.scriptRefreshNum.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.scriptRefreshNum.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scriptRefreshNum.Name = "scriptRefreshNum";
            this.scriptRefreshNum.Size = new System.Drawing.Size(116, 20);
            this.scriptRefreshNum.TabIndex = 2;
            this.scriptRefreshNum.ThousandsSeparator = true;
            this.scriptRefreshNum.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // applyButton
            // 
            this.applyButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.applyButton.Location = new System.Drawing.Point(5, 271);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(259, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // autoexecCheck
            // 
            this.autoexecCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoexecCheck.Location = new System.Drawing.Point(5, 25);
            this.autoexecCheck.Name = "autoexecCheck";
            this.autoexecCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.autoexecCheck.Size = new System.Drawing.Size(259, 24);
            this.autoexecCheck.TabIndex = 2;
            this.autoexecCheck.Text = "Use autoexec folder";
            this.autoexecCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.autoexecCheck.UseVisualStyleBackColor = true;
            // 
            // soundEffectsCheck
            // 
            this.soundEffectsCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.soundEffectsCheck.Location = new System.Drawing.Point(5, 49);
            this.soundEffectsCheck.Name = "soundEffectsCheck";
            this.soundEffectsCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.soundEffectsCheck.Size = new System.Drawing.Size(259, 24);
            this.soundEffectsCheck.TabIndex = 4;
            this.soundEffectsCheck.Text = "Play sound on actions";
            this.soundEffectsCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.soundEffectsCheck.UseVisualStyleBackColor = true;
            // 
            // customPayload
            // 
            this.customPayload.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPayload.Location = new System.Drawing.Point(5, 73);
            this.customPayload.Name = "customPayload";
            this.customPayload.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.customPayload.Size = new System.Drawing.Size(259, 24);
            this.customPayload.TabIndex = 5;
            this.customPayload.Text = "Add custom payload before scripts";
            this.customPayload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.customPayload.UseVisualStyleBackColor = true;
            this.customPayload.CheckedChanged += new System.EventHandler(this.customPayload_CheckedChanged);
            // 
            // customPayloadNote
            // 
            this.customPayloadNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.customPayloadNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customPayloadNote.Location = new System.Drawing.Point(5, 97);
            this.customPayloadNote.Name = "customPayloadNote";
            this.customPayloadNote.Size = new System.Drawing.Size(259, 28);
            this.customPayloadNote.TabIndex = 6;
            this.customPayloadNote.Text = "[EXPERIMENTAL] for it to work modify payload.lua file";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 299);
            this.Controls.Add(this.customPayloadNote);
            this.Controls.Add(this.customPayload);
            this.Controls.Add(this.soundEffectsCheck);
            this.Controls.Add(this.autoexecCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.applyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scriptRefreshNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown scriptRefreshNum;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.CheckBox autoexecCheck;
        private System.Windows.Forms.CheckBox soundEffectsCheck;
        private System.Windows.Forms.CheckBox customPayload;
        private System.Windows.Forms.Label customPayloadNote;
    }
}