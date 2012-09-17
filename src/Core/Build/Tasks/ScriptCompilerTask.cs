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

namespace ScriptSharp.Tasks {

    /// <summary>
    /// The Script# MSBuild task.
    /// </summary>
    public sealed class ScriptCompilerTask : Task, IErrorHandler {

        private string _projectPath;
        private ITaskItem[] _references;
        private ITaskItem[] _sources;
        private ITaskItem[] _resources;
        private ITaskItem _docCommentFile;
        private ITaskItem _csharpAssembly;

        private string _defines;
        private bool _copyReferences;
        private bool _suppressDocumentation;

        private string _outputPath;
        private string _deploymentPath;
        private List<ITaskItem> _scripts;

        private bool _hasErrors;

        public ScriptCompilerTask() {
            _copyReferences = true;
        }

        public bool CopyReferences {
            get {
                return _copyReferences;
            }
            set {
                _copyReferences = value;
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

        public ITaskItem DocumentationFile {
            get {
                return _docCommentFile;
            }
            set {
                _docCommentFile = value;
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

        public bool SuppressDocumentation {
            get {
                return _suppressDocumentation;
            }
            set {
                _suppressDocumentation = value;
            }
        }

        private bool Compile(IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems, string locale) {
            ITaskItem scriptTaskItem;

            CompilerOptions debugOptions =
                CreateOptions(sourceItems, resourceItems, locale,
                              /* debug */ true, /* includeTests */ false, /* minimize */ false,
                              out scriptTaskItem);

            string errorMessage = String.Empty;
            if (debugOptions.Validate(out errorMessage) == false) {
                Log.LogError(errorMessage);
                return false;
            }

            ScriptCompiler debugCompiler = new ScriptCompiler(this);
            debugCompiler.Compile(debugOptions);
            if (_hasErrors == false) {
                // Only copy references once (when building language neutral scripts)
                bool copyReferences = String.IsNullOrEmpty(locale) && CopyReferences;

                OnScriptFileGenerated(scriptTaskItem, debugOptions, copyReferences);
                if (_hasErrors) {
                    return false;
                }
            }
            else {
                return false;
            }

            if (debugOptions.HasTestTypes) {
                CompilerOptions testOptions =
                    CreateOptions(sourceItems, resourceItems, locale,
                                  /* debug */ true, /* includeTests */ true, /* minimize */ false,
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

            CompilerOptions releaseOptions =
                CreateOptions(sourceItems, resourceItems, locale,
                              /* debug */ false, /* includeTests */ false, /* minimize */ true,
                              out scriptTaskItem);
            ScriptCompiler releaseCompiler = new ScriptCompiler(this);
            releaseCompiler.Compile(releaseOptions);
            if (_hasErrors == false) {
                OnScriptFileGenerated(scriptTaskItem, releaseOptions, /* copyReferences */ false);
            }
            else {
                return false;
            }

            return true;
        }

        private CompilerOptions CreateOptions(IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems,
                                              string locale,
                                              bool debug, bool includeTests, bool minimize,
                                              out ITaskItem outputScriptItem) {
            CompilerOptions options = new CompilerOptions();
            options.DebugFlavor = debug;
            options.IncludeTests = includeTests;
            options.Minimize = minimize;
            options.Defines = GetDefines();
            options.References = GetReferences();
            options.Sources = GetSources(sourceItems);
            options.Resources = GetResources(resourceItems, locale);
            if ((_docCommentFile != null) && (_suppressDocumentation == false)) {
                options.DocCommentFile = new TaskItemInputStreamSource(_docCommentFile, "DocComment");
            }

            string scriptFilePath = GetScriptFilePath(locale, debug, includeTests);
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

        private string GetScriptFilePath(string locale, bool debug, bool includeTests) {
            if ((_csharpAssembly != null) && (OutputPath.Length != 0)) {
                string assemblyPath = _csharpAssembly.ItemSpec;
                string assemblyFile = Path.GetFileName(assemblyPath);
                string outputPath = OutputPath;

                if ((assemblyFile.Length > 7) && assemblyFile.StartsWith("Script.", StringComparison.OrdinalIgnoreCase)) {
                    // Resulting script files don't need a "Script." prefix, since that
                    // is mostly a naming convention used to separate out script# managed binaries.

                    assemblyFile = assemblyFile.Substring(7);
                }

                string extension = includeTests ? "test.js" : (debug ? "debug.js" : "js");
                if (String.IsNullOrEmpty(locale) == false) {
                    extension = locale + "." + extension;
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

            Func<string, bool, string> getScriptFile = delegate(string reference, bool debug) {
                string scriptFile = Path.ChangeExtension(reference, debug ? ".debug.js" : ".js");
                if (File.Exists(scriptFile)) {
                    return scriptFile;
                }

                string fileName = Path.GetFileName(scriptFile);
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
                    string releaseScriptFile = getScriptFile(reference, /* debug */ false);
                    if (releaseScriptFile != null) {
                        string path = Path.Combine(scriptFolder, Path.GetFileName(releaseScriptFile));
                        safeCopyFile(releaseScriptFile, path);
                    }

                    string debugScriptFile = getScriptFile(reference, /* debug */ true);
                    if (debugScriptFile != null) {
                        string path = Path.Combine(scriptFolder, Path.GetFileName(debugScriptFile));
                        safeCopyFile(debugScriptFile, path);
                    }
                }
            }

            string deploymentPath = DeploymentPath;
            if (DeploymentPath.Length != 0) {
                string deployedScriptPath = Path.Combine(deploymentPath, scriptFileName);
                safeCopyFile(scriptPath, deployedScriptPath);

                if (copyReferences) {
                    foreach (string reference in options.References) {
                        string releaseScriptFile = getScriptFile(reference, /* debug */ false);
                        if (releaseScriptFile != null) {
                            string path = Path.Combine(deploymentPath, Path.GetFileName(releaseScriptFile));
                            safeCopyFile(releaseScriptFile, path);
                        }

                        string debugScriptFile = getScriptFile(reference, /* debug */ true);
                        if (debugScriptFile != null) {
                            string path = Path.Combine(deploymentPath, Path.GetFileName(debugScriptFile));
                            safeCopyFile(debugScriptFile, path);
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
