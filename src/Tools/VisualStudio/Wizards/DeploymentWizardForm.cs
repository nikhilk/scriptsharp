// DeploymentWizardForm.cs
// Script#/Tools/VisualStudio
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace ScriptSharp.VisualStudio.Wizards {

    internal partial class DeploymentWizardForm : Form {

        private string _deploymentFolder;

        public DeploymentWizardForm(string baseFolder) {
            InitializeComponent();

            _instructionLabel.Text =
@"This sets the DeploymentPath property in the .csproj. You can manually set it later if needed.

Scripts are generated into the bin directory of the project. You can use the deployment feature to place a copy of the generated scripts into a Web application.";

            if (String.IsNullOrEmpty(baseFolder) == false) {
                _folderBrowser.SelectedPath = baseFolder;
            }
        }

        public string DeploymentFolder {
            get {
                return _deploymentFolder;
            }
        }

        private void OnBrowseButtonClick(object sender, EventArgs e) {
            if (_folderBrowser.ShowDialog(this) == DialogResult.OK) {
                _deployTextBox.Text = _folderBrowser.SelectedPath;
            }
        }

        private void OnOKButtonClick(object sender, EventArgs e) {
            string folder = _deployTextBox.Text;
            if (String.IsNullOrWhiteSpace(folder) == false) {
                if (Directory.Exists(folder) == false) {
                    MessageBox.Show("The specified deployment folder is not a valid folder.", Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _deploymentFolder = folder;
                DialogResult = DialogResult.OK;
            }
            else {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }
    }
}
