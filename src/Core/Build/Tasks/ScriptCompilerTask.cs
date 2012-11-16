// ScriptCompilerTask.cs
// Script#/Core/Build
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Microsoft.Build;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using ScriptCruncher = Microsoft.Ajax.Utilities.Minifier;
using ScriptCruncherSettings = Microsoft.Ajax.Utilities.CodeSettings;
using ScriptSourceMap = Microsoft.Ajax.Utilities.ScriptSharpSourceMap;

namespace ScriptSharp.Tasks {

    /// <summary>
    /// The Script# MSBuild task.
    /// </summary>
    public sealed class ScriptCompilerTask : Task, IErrorHandler {

        private string _projectPath;
        private ITaskItem[] _references;
        private ITaskItem[] _sources;
        private ITaskItem[] _resources;
        private ITaskItem _csharpAssembly;
        private string _defines;

        private bool _minimize;
        private bool _crunch;
        private bool _copyReferences;
        private bool _localeSubfolders;
        private string _referencesPath;
        private string _outputPath;
        private string _deploymentPath;
        private List<ITaskItem> _scripts;

        private bool _hasErrors;

        public ScriptCompilerTask() {
            _copyReferences = true;
            _crunch = true;
        }

        public bool CopyReferences {
            get {
                return _copyReferences;
            }
            set {
                _copyReferences = value;
            }
        }

        public string CopyReferencesPath {
            get {
                if (_referencesPath == null) {
                    return String.Empty;
                }
                return _referencesPath;
            }
            set {
                _referencesPath = value;
            }
        }

        public bool Crunch {
            get {
                return _crunch;
            }
            set {
                _crunch = value;
            }
        }

        [Required]
        public ITaskItem CSharpAssembly {
            get {
                return _csharpAssembly;
            }
            set {
                _csharpAssembly = value;
            }
        }

        public string Defines {
            get {
                if (_defines == null) {
                    return String.Empty;
                }
                return _defines;
            }
            set {
                _defines = value;
            }
        }

        public string DeploymentPath {
            get {
                if (_deploymentPath == null) {
                    return String.Empty;
                }
                return _deploymentPath;
            }
            set {
                _deploymentPath = value;
            }
        }

        public bool LocaleSubfolders {
            get {
                return _localeSubfolders;
            }
            set {
                _localeSubfolders = value;
            }
        }

        public bool Minimize {
            get {
                return _minimize;
            }
            set {
                _minimize = value;
            }
        }

        [Required]
        public string OutputPath {
            get {
                if (_outputPath == null) {
                    return String.Empty;
                }
                return _outputPath;
            }
            set {
                _outputPath = value;
            }
        }

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

        public ITaskItem[] Resources {
            get {
                return _resources;
            }
            set {
                _resources = value;
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

        [Required]
        public ITaskItem[] Sources {
            get {
                return _sources;
            }
            set {
                _sources = value;
            }
        }

        private bool Compile(IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems, string locale) {
            ITaskItem scriptTaskItem;

            CompilerOptions options =
                CreateOptions(sourceItems, resourceItems, locale,
                              /* includeTests */ false, /* minimize */ false,
                              out scriptTaskItem);

            string errorMessage = String.Empty;
            if (options.Validate(out errorMessage) == false) {
                Log.LogError(errorMessage);
                return false;
            }

            ScriptCompiler compiler = new ScriptCompiler(this);
            compiler.Compile(options);
            if (_hasErrors == false) {
                // Only copy references once (when building language neutral scripts)
                bool copyReferences = String.IsNullOrEmpty(locale) && CopyReferences;

                OnScriptFileGenerated(scriptTaskItem, options, copyReferences);
                if (_hasErrors) {
                    return false;
                }
            }
            else {
                return false;
            }

            if (options.HasTestTypes) {
                CompilerOptions testOptions =
                    CreateOptions(sourceItems, resourceItems, locale,
                                  /* includeTests */ true, /* minimize */ false,
                                  out scriptTaskItem);
                ScriptCompiler testCompiler = new ScriptCompiler(this);
                testCompiler.Compile(testOptions);
                if (_hasErrors == false) {
                    OnScriptFileGenerated(scriptTaskItem, testOptions, /* copyReferences */ false);
                }
                else {
                    return false;
                }
            }

            if (_minimize) {
                CompilerOptions minimizeOptions =
                    CreateOptions(sourceItems, resourceItems, locale,
                                  /* includeTests */ false, /* minimize */ true,
                                  out scriptTaskItem);
                ScriptCompiler minimizingCompiler = new ScriptCompiler(this);
                minimizingCompiler.Compile(minimizeOptions);
                if (_hasErrors == false) {
                    if (Crunch) {
                        ExecuteCruncher(scriptTaskItem);
                    }

                    OnScriptFileGenerated(scriptTaskItem, minimizeOptions, /* copyReferences */ false);
                }
                else {
                    return false;
                }
            }

            return true;
        }

        private CompilerOptions CreateOptions(IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems,
                                              string locale, bool includeTests, bool minimize,
                                              out ITaskItem outputScriptItem) {
            CompilerOptions options = new CompilerOptions();
            options.IncludeTests = includeTests;
            options.Minimize = minimize;
            options.Defines = GetDefines();
            options.References = GetReferences();
            options.Sources = GetSources(sourceItems);
            options.Resources = GetResources(resourceItems, locale);

            string scriptFilePath = GetScriptFilePath(locale, minimize, includeTests);
            outputScriptItem = new TaskItem(scriptFilePath);
            options.ScriptFile = new TaskItemOutputStreamSource(outputScriptItem);

            return options;
        }

        public override bool Execute() {
            _scripts = new List<ITaskItem>();

            bool success;
            try {
                success = ExecuteCore(_sources, _resources);
            }
            catch (Exception) {
                success = false;
            }

            return success;
        }

        private bool ExecuteCore(IEnumerable<ITaskItem> sources, IEnumerable<ITaskItem> resources) {
            // Create the neutral culture scripts first, and if that 
            // succeeds, compile any localized variants that are supposed
            // to be generated.

            if (Compile(sources, resources, /* locale */ String.Empty)) {
                ICollection<string> locales = GetLocales(resources);

                foreach (string locale in locales) {
                    if (Compile(sources, resources, locale) == false) {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private void ExecuteCruncher(ITaskItem scriptItem) {
            string script = File.ReadAllText(scriptItem.ItemSpec);

            ScriptCruncher cruncher = new ScriptCruncher();
            ScriptCruncherSettings cruncherSettings = new ScriptCruncherSettings() {
                StripDebugStatements = false,
                OutputMode = Microsoft.Ajax.Utilities.OutputMode.SingleLine,
                IgnorePreprocessorDefines = true,
                IgnoreConditionalCompilation = true
            };
            cruncherSettings.AddNoAutoRename("$");
            cruncherSettings.SetDebugNamespaces(null);

            string crunchedScript = cruncher.MinifyJavaScript(script, cruncherSettings);

            File.WriteAllText(scriptItem.ItemSpec, crunchedScript);
        }

        private ICollection<string> GetDefines() {
            if (Defines.Length == 0) {
                return new string[0];
            }

            return Defines.Split(';');
        }

        private ICollection<string> GetLocales(IEnumerable<ITaskItem> resourceItems) {
            List<string> locales = new List<string>();

            // Inspect the list of resources to create the list of unique locales
            if (resourceItems != null) {
                foreach (ITaskItem resourceItem in resourceItems) {
                    string locale = ResourceFile.GetLocale(resourceItem.ItemSpec);

                    if (locales.Contains(locale) == false) {
                        locales.Add(locale);
                    }
                }
            }

            return locales;
        }

        private ICollection<string> GetReferences() {
            if (_references == null) {
                return new string[0];
            }

            List<string> references = new List<string>(_references.Length);
            foreach (ITaskItem reference in _references) {
                // TODO: This is a hack... something in the .net 4 build system causes
                //       System.Core.dll to get included [sometimes].
                //       That shouldn't happen... so filter it out here.
                if (reference.ItemSpec.EndsWith("System.Core.dll", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }
                references.Add(reference.ItemSpec);
            }

            return references;
        }

        private ICollection<IStreamSource> GetResources(IEnumerable<ITaskItem> allResources, string locale) {
            if (allResources == null) {
                return new TaskItemInputStreamSource[0];
            }

            List<IStreamSource> resources = new List<IStreamSource>();
            foreach (ITaskItem resource in allResources) {
                string itemLocale = ResourceFile.GetLocale(resource.ItemSpec);

                if (String.IsNullOrEmpty(locale) && String.IsNullOrEmpty(itemLocale)) {
                    resources.Add(new TaskItemInputStreamSource(resource));
                }
                else if ((String.Compare(locale, itemLocale, StringComparison.OrdinalIgnoreCase) == 0) ||
                         locale.StartsWith(itemLocale, StringComparison.OrdinalIgnoreCase)) {
                    // Either the item locale matches, or the item locale is a prefix
                    // of the locale (eg. we want to include "fr" if the locale specified
                    // is fr-FR)
                    resources.Add(new TaskItemInputStreamSource(resource));
                }
            }

            return resources;
        }

        private string GetScriptFilePath(string locale, bool minimize, bool includeTests) {
            if ((_csharpAssembly != null) && (OutputPath.Length != 0)) {
                string assemblyPath = _csharpAssembly.ItemSpec;
                string assemblyFile = Path.GetFileName(assemblyPath);
                string outputPath = OutputPath;

                if ((assemblyFile.Length > 7) && assemblyFile.StartsWith("Script.", StringComparison.OrdinalIgnoreCase)) {
                    // Resulting script files don't need a "Script." prefix, since that
                    // is mostly a naming convention used to separate out script# managed binaries.

                    assemblyFile = assemblyFile.Substring(7);
                }

                string extension = includeTests ? "test.js" : (minimize ? "min.js" : "js");
                if (String.IsNullOrEmpty(locale) == false) {
                    if (LocaleSubfolders) {
                        outputPath = Path.Combine(outputPath, locale);
                    }
                    else {
                        extension = locale + "." + extension;
                    }
                }

                if (Directory.Exists(outputPath) == false) {
                    Directory.CreateDirectory(outputPath);
                }

                return Path.Combine(outputPath, Path.ChangeExtension(assemblyFile, extension));
            }

            return null;
        }

        private ICollection<IStreamSource> GetSources(IEnumerable<ITaskItem> sourceItems) {
            if (sourceItems == null) {
                return new TaskItemInputStreamSource[0];
            }

            List<IStreamSource> sources = new List<IStreamSource>();
            foreach (ITaskItem sourceItem in sourceItems) {
                // TODO: This is a hack... something in the .net 4 build system causes
                //       generation of an AssemblyAttributes.cs file with fully-qualified
                //       type names, that we can't handle (this comes from multitargeting),
                //       and there doesn't seem like a way to turn it off.
                if (sourceItem.ItemSpec.EndsWith(".AssemblyAttributes.cs", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }

                sources.Add(new TaskItemInputStreamSource(sourceItem));
            }

            return sources;
        }

        private void OnScriptFileGenerated(ITaskItem scriptItem, CompilerOptions options, bool copyReferences) {
            _scripts.Add(scriptItem);

            Func<string, bool, string> getScriptFile = delegate(string reference, bool minimized) {
                string scriptFile = Path.ChangeExtension(reference, minimized ? ".min.js" : ".js");

                string fileName = Path.GetFileNameWithoutExtension(scriptFile);
                if (fileName.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase)) {
                    fileName = (minimized ? "ss.min" : "ss") + Path.GetExtension(scriptFile);
                    scriptFile = Path.Combine(Path.GetDirectoryName(scriptFile), fileName);
                }

                if (File.Exists(scriptFile)) {
                    return scriptFile;
                }

                fileName = Path.GetFileName(scriptFile);
                if ((fileName.Length > 7) && fileName.StartsWith("Script.", StringComparison.OrdinalIgnoreCase)) {
                    fileName = fileName.Substring(7);
                    scriptFile = Path.Combine(Path.GetDirectoryName(scriptFile), fileName);

                    if (File.Exists(scriptFile)) {
                        return scriptFile;
                    }
                }

                return null;
            };

            Action<string, string> safeCopyFile = delegate(string sourceFilePath, string targetFilePath) {
                try {
                    string directory = Path.GetDirectoryName(targetFilePath);
                    if (Directory.Exists(directory) == false) {
                        Directory.CreateDirectory(directory);
                    }

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
                catch (Exception e) {
                    Log.LogError("Unable to copy referenced script '" + sourceFilePath + "' as '" + targetFilePath + "' (" + e.Message + ")");
                    _hasErrors = true;
                }
            };

            string projectName = (_projectPath != null) ? Path.GetFileNameWithoutExtension(_projectPath) : String.Empty;
            string scriptFileName = Path.GetFileName(scriptItem.ItemSpec);
            string scriptPath = Path.GetFullPath(scriptItem.ItemSpec);
            string scriptFolder = Path.GetDirectoryName(scriptItem.ItemSpec);

            Log.LogMessage(MessageImportance.High, "{0} -> {1} ({2})", projectName, scriptFileName, scriptPath);

            if (copyReferences) {
                foreach (string reference in options.References) {
                    string scriptFile = getScriptFile(reference, /* minimized */ false);
                    if (scriptFile != null) {
                        string path = Path.Combine(scriptFolder, CopyReferencesPath, Path.GetFileName(scriptFile));
                        safeCopyFile(scriptFile, path);
                    }

                    if (_minimize) {
                        string minScriptFile = getScriptFile(reference, /* minimized */ true);
                        if (minScriptFile != null) {
                            string path = Path.Combine(scriptFolder, CopyReferencesPath, Path.GetFileName(minScriptFile));
                            safeCopyFile(minScriptFile, path);
                        }
                    }
                }
            }

            string deploymentPath = DeploymentPath;
            if (DeploymentPath.Length != 0) {
                string deployedScriptPath = Path.Combine(deploymentPath, scriptFileName);
                safeCopyFile(scriptPath, deployedScriptPath);

                if (copyReferences) {
                    foreach (string reference in options.References) {
                        string scriptFile = getScriptFile(reference, /* minimized */ false);
                        if (scriptFile != null) {
                            string path = Path.Combine(deploymentPath, CopyReferencesPath, Path.GetFileName(scriptFile));
                            safeCopyFile(scriptFile, path);
                        }

                        if (_minimize) {
                            string minScriptFile = getScriptFile(reference, /* minimized */ true);
                            if (minScriptFile != null) {
                                string path = Path.Combine(deploymentPath, CopyReferencesPath, Path.GetFileName(minScriptFile));
                                safeCopyFile(minScriptFile, path);
                            }
                        }
                    }
                }
            }
        }

        #region Implementation of IErrorHandler
        void IErrorHandler.ReportError(string errorMessage, string location) {
            _hasErrors = true;

            int line = 0;
            int column = 0;

            if (String.IsNullOrEmpty(location) == false) {
                if (location.EndsWith(")", StringComparison.Ordinal)) {
                    int index = location.LastIndexOf("(", StringComparison.Ordinal);
                    Debug.Assert(index > 0);

                    string position = location.Substring(index + 1, location.Length - index - 2);
                    string[] positionParts = position.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Debug.Assert(positionParts.Length == 2);

                    Int32.TryParse(positionParts[0], out line);
                    Int32.TryParse(positionParts[1], out column);

                    location = location.Substring(0, index);
                }
            }

            Log.LogError(String.Empty, String.Empty, String.Empty, location, line, column, 0, 0, errorMessage);
        }
        #endregion


        private sealed class TaskItemInputStreamSource : FileInputStreamSource {

            public TaskItemInputStreamSource(ITaskItem taskItem)
                : base(taskItem.ItemSpec) {
            }

            public TaskItemInputStreamSource(ITaskItem taskItem, string name)
                : base(taskItem.ItemSpec, name) {
            }
        }

        private sealed class TaskItemOutputStreamSource : FileOutputStreamSource {

            public TaskItemOutputStreamSource(ITaskItem taskItem)
                : base(taskItem.ItemSpec) {
            }

            public TaskItemOutputStreamSource(ITaskItem taskItem, string name)
                : base(taskItem.ItemSpec, name) {
            }
        }
    }
}
