// ProjectWizard.cs
// Script#/Tools/VisualStudio
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace ScriptSharp.VisualStudio.Wizards {

    public sealed class ProjectWizard : IWizard {

        #region IWizard Members
        void IWizard.BeforeOpeningFile(ProjectItem projectItem) {
        }

        void IWizard.ProjectFinishedGenerating(Project project) {
        }

        void IWizard.ProjectItemFinishedGenerating(ProjectItem projectItem) {
        }

        void IWizard.RunFinished() {
        }

        void IWizard.RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams) {
            DTE dte = (DTE)automationObject;

            string deploymentFolder = String.Empty;

            string destinationDirectory = replacementsDictionary["$destinationdirectory$"];
            if (destinationDirectory.EndsWith("\\", StringComparison.Ordinal) == false) {
                destinationDirectory = destinationDirectory + "\\";
            }

            string parentFolder = Path.GetDirectoryName(destinationDirectory);

            DeploymentWizardForm wizardForm = new DeploymentWizardForm(parentFolder);
            if (wizardForm.ShowDialog(new WindowOwner((IntPtr)dte.MainWindow.HWnd)) == DialogResult.OK) {
                Uri destinationUri = new Uri(destinationDirectory);
                Uri deploymentUri = new Uri(wizardForm.DeploymentFolder);

                Uri relativeUri = destinationUri.MakeRelativeUri(deploymentUri);

                deploymentFolder = relativeUri.ToString().Replace("/", "\\");
            }

            replacementsDictionary["$deploymentpath$"] = deploymentFolder;
        }

        bool IWizard.ShouldAddProjectItem(string filePath) {
            return true;
        }
        #endregion


        private sealed class WindowOwner : IWin32Window {

            private IntPtr _handle;

            public WindowOwner(IntPtr handle) {
                _handle = handle;
            }

            public IntPtr Handle {
                get {
                    return _handle;
                }
            }
        }
    }
}
