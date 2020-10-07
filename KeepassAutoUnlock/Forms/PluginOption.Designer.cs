namespace KeepassAutoUnlock.Forms
{
    partial class PluginOption
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label databaseLocationText;
            System.Windows.Forms.Label passwordText;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginOption));
            this.isEnabledText = new System.Windows.Forms.Label();
            this.databaseLocationValue = new System.Windows.Forms.TextBox();
            this.passwordValue = new KeePass.UI.SecureTextBoxEx();
            this.validateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.passwordHide = new System.Windows.Forms.CheckBox();
            this.databaseLocationButton = new System.Windows.Forms.Button();
            this.enableValue = new System.Windows.Forms.CheckBox();
            databaseLocationText = new System.Windows.Forms.Label();
            passwordText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // databaseLocationText
            // 
            databaseLocationText.AutoSize = true;
            databaseLocationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            databaseLocationText.Location = new System.Drawing.Point(12, 35);
            databaseLocationText.Name = "databaseLocationText";
            databaseLocationText.Size = new System.Drawing.Size(154, 17);
            databaseLocationText.TabIndex = 0;
            databaseLocationText.Text = "Database Location :";
            // 
            // passwordText
            // 
            passwordText.AutoSize = true;
            passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordText.Location = new System.Drawing.Point(12, 62);
            passwordText.Name = "passwordText";
            passwordText.Size = new System.Drawing.Size(141, 17);
            passwordText.TabIndex = 0;
            passwordText.Text = "Master Password :";
            // 
            // isEnabledText
            // 
            this.isEnabledText.AutoSize = true;
            this.isEnabledText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isEnabledText.Location = new System.Drawing.Point(12, 9);
            this.isEnabledText.Name = "isEnabledText";
            this.isEnabledText.Size = new System.Drawing.Size(126, 17);
            this.isEnabledText.TabIndex = 0;
            this.isEnabledText.Text = "Activate Plugin :";
            this.isEnabledText.Click += new System.EventHandler(this.OnEnableTextClick);
            // 
            // databaseLocationValue
            // 
            this.databaseLocationValue.Location = new System.Drawing.Point(174, 35);
            this.databaseLocationValue.Name = "databaseLocationValue";
            this.databaseLocationValue.Size = new System.Drawing.Size(254, 20);
            this.databaseLocationValue.TabIndex = 3;
            // 
            // passwordValue
            // 
            this.passwordValue.Location = new System.Drawing.Point(174, 62);
            this.passwordValue.Name = "passwordValue";
            this.passwordValue.Size = new System.Drawing.Size(254, 20);
            this.passwordValue.TabIndex = 5;
            this.passwordValue.UseSystemPasswordChar = true;
            // 
            // validateButton
            // 
            this.validateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.validateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validateButton.Location = new System.Drawing.Point(310, 116);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(75, 23);
            this.validateButton.TabIndex = 7;
            this.validateButton.Text = "OK";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.OnOK);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(391, 116);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // passwordHide
            // 
            this.passwordHide.Appearance = System.Windows.Forms.Appearance.Button;
            this.passwordHide.Image = ((System.Drawing.Image)(resources.GetObject("passwordHide.Image")));
            this.passwordHide.Location = new System.Drawing.Point(434, 60);
            this.passwordHide.Name = "passwordHide";
            this.passwordHide.Size = new System.Drawing.Size(32, 23);
            this.passwordHide.TabIndex = 6;
            this.passwordHide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.passwordHide.UseVisualStyleBackColor = true;
            this.passwordHide.CheckedChanged += new System.EventHandler(this.OnHidePassword);
            // 
            // databaseLocationButton
            // 
            this.databaseLocationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.databaseLocationButton.Image = global::KeepassAutoUnlock.Properties.Resources.B16x16_Folder_Blue_Open;
            this.databaseLocationButton.Location = new System.Drawing.Point(434, 33);
            this.databaseLocationButton.Name = "databaseLocationButton";
            this.databaseLocationButton.Size = new System.Drawing.Size(32, 23);
            this.databaseLocationButton.TabIndex = 4;
            this.databaseLocationButton.UseVisualStyleBackColor = true;
            this.databaseLocationButton.Click += new System.EventHandler(this.OnDatabaseBrowse);
            // 
            // enableValue
            // 
            this.enableValue.AutoSize = true;
            this.enableValue.Location = new System.Drawing.Point(174, 12);
            this.enableValue.Name = "enableValue";
            this.enableValue.Size = new System.Drawing.Size(15, 14);
            this.enableValue.TabIndex = 1;
            this.enableValue.UseVisualStyleBackColor = true;
            // 
            // PluginOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 150);
            this.Controls.Add(this.enableValue);
            this.Controls.Add(this.passwordHide);
            this.Controls.Add(this.isEnabledText);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.passwordValue);
            this.Controls.Add(passwordText);
            this.Controls.Add(this.databaseLocationButton);
            this.Controls.Add(this.databaseLocationValue);
            this.Controls.Add(databaseLocationText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginOption";
            this.Text = "Auto unlock options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox databaseLocationValue;
        private System.Windows.Forms.Button databaseLocationButton;
        private KeePass.UI.SecureTextBoxEx passwordValue;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox passwordHide;
        private System.Windows.Forms.CheckBox enableValue;
        private System.Windows.Forms.Label isEnabledText;
    }
}