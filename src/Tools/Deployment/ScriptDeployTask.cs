// ScriptDeployTask.cs
// Script#/Core/Build
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace ScriptSharp.Tasks {

    public sealed class ScriptDeployTask : Task {

        private string _projectPath;
        private string _scriptsPath;
        private ITaskItem[] _references;

        private HashSet<string> _scriptSet;
        private List<ITaskItem> _scripts;

        [Required]
        public string ProjectPath {
            get {
                return _projectPath;
            }
            set {
                _projectPath = value;
            }
        }

        [Required]
        public ITaskItem[] References {
            get {
                return _references;
            }
            set {
                _references = value;
            }
        }

        [Output]
        public ITaskItem[] Scripts {
            get {
                if (_scripts == null) {
                    return new ITaskItem[0];
                }
                return _scripts.ToArray();
            }
        }

        public string ScriptsPath {
            get {
                if (String.IsNullOrEmpty(_scriptsPath)) {
                    return "Scripts";
                }
                return _scriptsPath;
            }
            set {
                _scriptsPath = value;
            }
        }

        private void CopyFile(string sourceFilePath, string targetFilePath) {
            if (File.Exists(targetFilePath)) {
                // If the file already exists, make sure it is not read-only, so
                // it can be overrwritten.
                File.SetAttributes(targetFilePath, FileAttributes.Normal);
            }

            File.Copy(sourceFilePath, targetFilePath, /* overwrite */ true);

            // Copy the file, and then make sure it is not read-only (for example, if the
            // source file for a referenced script is read-only).
            File.SetAttributes(targetFilePath, FileAttributes.Normal);
        }

        private void DeployScripts(string projectName, string scriptsFile, string projectPath, string scriptsTargetPath) {
            string sourceDirectory = Path.GetDirectoryName(scriptsFile);
            string[] scripts = File.ReadAllLines(scriptsFile);

            scripts = scripts.Select(s => Path.Combine(sourceDirectory, s)).ToArray();

            Log.LogMessage("Deploying scripts from {0} project:", projectName);
            foreach (string scriptPath in scripts) {
                string scriptFile = Path.GetFileName(scriptPath);
                if (scriptFile.Equals("ss.js", StringComparison.OrdinalIgnoreCase) ||
                    scriptFile.Equals("ss.min.js", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }

                string targetScriptPath = Path.Combine(scriptsTargetPath, scriptFile);
                if (_scriptSet.Add(targetScriptPath)) {
                    CopyFile(scriptPath, targetScriptPath);

                    Uri baseUri = new Uri(projectPath, UriKind.Absolute);
                    Uri targetUri = new Uri(targetScriptPath, UriKind.Absolute);
                    string relativePath = Uri.UnescapeDataString(baseUri.MakeRelativeUri(targetUri).ToString()).Replace("/", "\\");

                    Log.LogMessage("-> " + relativePath);
                    _scripts.Add(new TaskItem(relativePath));
                }
            }
        }

        public override bool Execute() {
            _scriptSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _scripts = new List<ITaskItem>();

            string projectDirectory = Path.GetDirectoryName(_projectPath);
            string scriptsDirectory = Path.Combine(projectDirectory, ScriptsPath);
            if (Directory.Exists(scriptsDirectory) == false) {
                Directory.CreateDirectory(scriptsDirectory);
            }

            foreach (ITaskItem reference in _references) {
                string referencePath = Path.GetFullPath(reference.ItemSpec);
                string referenceName = Path.GetFileNameWithoutExtension(referencePath);

                Project project = GetReferencedProject(referencePath);
                if (project == null) {
                    Log.LogError("Unable to load project {0}.", referenceName);
                    return false;
                }

                if (IsScriptSharpProject(project) == false) {
                    continue;
                }

                string scriptsFile = GetScriptsFile(project, referencePath);
                if (String.IsNullOrEmpty(scriptsFile)) {
                    Log.LogError("Unable to find scripts list for project {0}.", referenceName);
                    return false;
                }

                try {
                    DeployScripts(referenceName, scriptsFile, _projectPath, scriptsDirectory);
                }
                catch (Exception e) {
                    Log.LogError("Error deploying scripts from project {0}.\r\n{1}", referenceName, e.ToString());
                    return false;
                }
            }

            return true;
        }

        private string GetScriptsFile(Project project, string projectPath) {
            string outputPath = project.GetProperty("OutputPath").EvaluatedValue;
            string assemblyName = project.GetProperty("AssemblyName").EvaluatedValue;

            string scriptsFilePath = Path.Combine(Path.GetDirectoryName(projectPath), outputPath, assemblyName + ".scripts");
            if (File.Exists(scriptsFilePath) == false) {
                return null;
            }

            return scriptsFilePath;
        }

        private Project GetReferencedProject(string projectPath) {
            ProjectCollection projects = ProjectCollection.GlobalProjectCollection;
            ICollection<Project> loadedProjects = projects.GetLoadedProjects(projectPath);

            Project project = loadedProjects.FirstOrDefault();
            if (project == null) {
                project = new Project(projectPath);
            }

            return project;
        }

        private bool IsScriptSharpProject(Project project) {
            ProjectProperty scriptSharpProperty = project.GetProperty("ScriptSharp");
            if ((scriptSharpProperty != null) &&
                scriptSharpProperty.EvaluatedValue.Equals("true", StringComparison.OrdinalIgnoreCase)) {
                return true;
            }

            return false;
        }
    }
}
