namespace ScriptSharp.VisualStudio.Wizards {
    partial class DeploymentWizardForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this._deployLabel = new System.Windows.Forms.Label();
            this._deployTextBox = new System.Windows.Forms.TextBox();
            this._browseButton = new System.Windows.Forms.Button();
            this._instructionLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // _deployLabel
            // 
            this._deployLabel.Location = new System.Drawing.Point(12, 13);
            this._deployLabel.Name = "_deployLabel";
            this._deployLabel.Size = new System.Drawing.Size(373, 16);
            this._deployLabel.TabIndex = 0;
            this._deployLabel.Text = "Script Deployment Folder (optional):";
            // 
            // _deployTextBox
            // 
            this._deployTextBox.Location = new System.Drawing.Point(12, 32);
            this._deployTextBox.Name = "_deployTextBox";
            this._deployTextBox.Size = new System.Drawing.Size(292, 21);
            this._deployTextBox.TabIndex = 1;
            // 
            // _browseButton
            // 
            this._browseButton.Location = new System.Drawing.Point(310, 30);
            this._browseButton.Name = "_browseButton";
            this._browseButton.Size = new System.Drawing.Size(75, 23);
            this._browseButton.TabIndex = 2;
            this._browseButton.Text = "Browse...";
            this._browseButton.UseVisualStyleBackColor = true;
            this._browseButton.Click += new System.EventHandler(this.OnBrowseButtonClick);
            // 
            // _instructionLabel
            // 
            this._instructionLabel.Location = new System.Drawing.Point(12, 66);
            this._instructionLabel.Name = "_instructionLabel";
            this._instructionLabel.Size = new System.Drawing.Size(373, 89);
            this._instructionLabel.TabIndex = 3;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(310, 159);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 4;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.OnOKButtonClick);
            // 
            // _folderBrowser
            // 
            this._folderBrowser.Description = "Script Deployment Folder";
            this._folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // WizardForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 194);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._instructionLabel);
            this.Controls.Add(this._browseButton);
            this.Controls.Add(this._deployTextBox);
            this.Controls.Add(this._deployLabel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script# Project Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _deployLabel;
        private System.Windows.Forms.TextBox _deployTextBox;
        private System.Windows.Forms.Button _browseButton;
        private System.Windows.Forms.Label _instructionLabel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowser;
    }
}