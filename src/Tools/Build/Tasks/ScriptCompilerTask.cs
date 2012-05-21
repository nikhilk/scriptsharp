// ScriptCompilerTask.cs
// Script#/Tools/Build
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
        private ITaskItem _template;
        private ITaskItem _docCommentFile;
        private ITaskItem _csharpAssembly;

        private string _defines;
        private bool _copyReferences;
        private bool _suppressDocumentation;

        private string _outputPath;
        private string _deploymentPath;
        private bool _localeSubFolders;
        private bool _configSubFolders;
        private bool _webAppPartitioning;
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

        public bool LocaleSubFolders {
            get {
                return _localeSubFolders;
            }
            set {
                _localeSubFolders = value;
            }
        }

        public bool ConfigSubFolders {
            get {
                return _configSubFolders;
            }
            set {
                _configSubFolders = value;
            }
        }

        public ITaskItem Template {
            get {
                return _template;
            }
            set {
                _template = value;
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

        public bool WebAppPartitioning {
            get {
                return _webAppPartitioning;
            }
            set {
                _webAppPartitioning = value;
            }
        }

        private bool Compile(string name, IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems, string locale) {
            ITaskItem scriptTaskItem;

            CompilerOptions debugOptions =
                CreateOptions(name, sourceItems, resourceItems, locale,
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
                    CreateOptions(name, sourceItems, resourceItems, locale,
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
                CreateOptions(name, sourceItems, resourceItems, locale,
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

        private CompilerOptions CreateOptions(string name, IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems,
                                              string locale,
                                              bool debug, bool includeTests, bool minimize,
                                              out ITaskItem outputScriptItem) {
            CompilerOptions options = new CompilerOptions();
            options.DebugFlavor = debug;
            options.IncludeTests = includeTests;
            options.Minimize = minimize;
            options.ScriptNameSuffix = name;
            options.Defines = GetDefines(name, !debug);
            options.References = GetReferences();
            options.Sources = GetSources(sourceItems);
            options.Resources = GetResources(resourceItems, locale);
            if (_template != null) {
                options.TemplateFile = new TaskItemInputStreamSource(_template, "Template");
            }
            if ((_docCommentFile != null) && (_suppressDocumentation == false)) {
                options.DocCommentFile = new TaskItemInputStreamSource(_docCommentFile, "DocComment");
            }

            string scriptFilePath = GetScriptFilePath(name, locale, debug, includeTests);
            outputScriptItem = new TaskItem(scriptFilePath);
            options.ScriptFile = new TaskItemOutputStreamSource(outputScriptItem);

            return options;
        }

        public override bool Execute() {
            _scripts = new List<ITaskItem>();

            if (_webAppPartitioning == false) {
                return ExecuteCore(String.Empty, _sources, _resources);
            }
            else {
                CompilationGroup sharedGroup = new CompilationGroup();
                Dictionary<string, CompilationGroup> compilationGroups =
                    new Dictionary<string, CompilationGroup>(StringComparer.OrdinalIgnoreCase);

                if (_sources != null) {
                    foreach (ITaskItem sourceItem in _sources) {
                        string groupName = CompilationGroup.GetGroupName(sourceItem);

                        CompilationGroup group;
                        if (groupName == CompilationGroup.SharedGroupName) {
                            group = sharedGroup;
                        }
                        else if (compilationGroups.TryGetValue(groupName, out group) == false) {
                            group = new CompilationGroup();
                            compilationGroups[groupName] = group;
                        }

                        group.Sources.Add(sourceItem);
                    }
                }

                if (_resources != null) {
                    foreach (ITaskItem resourceItem in _resources) {
                        string groupName = CompilationGroup.GetGroupName(resourceItem);

                        CompilationGroup group;
                        if (groupName == CompilationGroup.SharedGroupName) {
                            group = sharedGroup;
                        }
                        else if (compilationGroups.TryGetValue(groupName, out group) == false) {
                            group = new CompilationGroup();
                            compilationGroups[groupName] = group;
                        }

                        group.Resources.Add(resourceItem);
                    }
                }

                foreach (KeyValuePair<string, CompilationGroup> group in compilationGroups) {
                    group.Value.Sources.AddRange(sharedGroup.Sources);
                    group.Value.Resources.AddRange(sharedGroup.Resources);

                    bool success = ExecuteCore(group.Key, group.Value.Sources, group.Value.Resources);
                    if (success == false) {
                        return false;
                    }
                }

                return true;
            }
        }

        private bool ExecuteCore(string name, IEnumerable<ITaskItem> sources, IEnumerable<ITaskItem> resources) {
            bool success = false;

            try {
                // Create the neutral culture scripts first
                success = Compile(name, sources, resources, /* locale */ String.Empty);

                if (success) {
                    ICollection<string> locales = GetLocales(resources);
                    foreach (string locale in locales) {
                        success = Compile(name, sources, resources, locale);
                        if (success == false) {
                            break;
                        }
                    }
                }
            }
            catch {
                success = false;
            }

            return success;
        }

        private ICollection<string> GetDefines(string name, bool removeDebug) {
            if ((Defines.Length == 0) && String.IsNullOrEmpty(name)) {
                return new string[0];
            }
            string[] defines = Defines.Split(';');
            if (String.IsNullOrEmpty(name) && (removeDebug == false)) {
                return defines;
            }

            List<string> definesList = new List<string>(defines);
            definesList.Add(name);

            if (removeDebug) {
                definesList.Remove("DEBUG");
            }

            return definesList;
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

        private string GetScriptFilePath(string name, string locale, bool debug, bool includeTests) {
            if ((_csharpAssembly != null) && (OutputPath.Length != 0)) {
                string assemblyPath = _csharpAssembly.ItemSpec;
                string assemblyFile = Path.GetFileName(assemblyPath);
                string outputPath = OutputPath;
                string extension = "js";

                if ((assemblyFile.Length > 7) && assemblyFile.StartsWith("Script.", StringComparison.OrdinalIgnoreCase)) {
                    // Resulting script files don't need a "Script." prefix, since that
                    // is mostly a naming convention used to separate out script# managed binaries.

                    assemblyFile = assemblyFile.Substring(7);
                }

                if (_configSubFolders == false) {
                    extension = includeTests ? "test.js" : (debug ? "debug.js" : "js");
                }
                else {
                    outputPath = Path.Combine(outputPath, includeTests ? "test" : (debug ? "debug" : "release"));
                }

                if (String.IsNullOrEmpty(locale) == false) {
                    if (_localeSubFolders == false) {
                        extension = locale + "." + extension;
                    }
                    else {
                        outputPath = Path.Combine(outputPath, locale);
                    }
                }

                if (String.IsNullOrEmpty(name) == false) {
                    extension = name + "." + extension;
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


        private sealed class CompilationGroup {

            public static readonly string SharedGroupName = "Shared";

            public List<ITaskItem> Sources;
            public List<ITaskItem> Resources;

            public CompilationGroup() {
                Sources = new List<ITaskItem>();
                Resources = new List<ITaskItem>();
            }

            public static string GetGroupName(ITaskItem taskItem) {
                string groupName = null;

                string itemPath = taskItem.GetMetadata("Link");
                if (String.IsNullOrEmpty(itemPath)) {
                    itemPath = taskItem.ItemSpec;
                }

                if (Path.IsPathRooted(itemPath) ||
                    (itemPath.IndexOf(Path.DirectorySeparatorChar) < 0)) {
                    groupName = SharedGroupName;
                }
                else {
                    string path = itemPath;
                    while (String.IsNullOrEmpty(path) == false) {
                        groupName = path;
                        path = Path.GetDirectoryName(path);
                    }
                }

                if (groupName.Equals("Properties", StringComparison.Ordinal)) {
                    groupName = CompilationGroup.SharedGroupName;
                }

                return groupName;
            }
        }

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
