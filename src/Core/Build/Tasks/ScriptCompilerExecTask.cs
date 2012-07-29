// ScriptCompilerExecTask.cs
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
    /// The Script# MSBuild task corresponding exactly to functionality exposed
    /// by the command-line tool.
    /// </summary>
    public sealed class ScriptCompilerExecTask : Task, IErrorHandler {

        private string _projectPath;
        private ITaskItem[] _references;
        private ITaskItem[] _sources;
        private ITaskItem[] _resources;
        private ITaskItem _template;
        private ITaskItem _docCommentFile;

        private bool _debug;
        private bool _minimize;
        private bool _tests;
        private string _defines;
        private string _locale;

        private string _outputPath;
        private ITaskItem _script;

        private bool _hasErrors;

        public bool DebugFlavor {
            get {
                return _debug;
            }
            set {
                _debug = value;
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

        public ITaskItem DocumentationFile {
            get {
                return _docCommentFile;
            }
            set {
                _docCommentFile = value;
            }
        }

        public bool IncludeTests {
            get {
                return _tests;
            }
            set {
                _tests = value;
            }
        }

        public string Locale {
            get {
                if (_locale == null) {
                    return String.Empty;
                }
                return _locale;
            }
            set {
                _locale = value;
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
        public ITaskItem Script {
            get {
                return _script;
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

        public ITaskItem Template {
            get {
                return _template;
            }
            set {
                _template = value;
            }
        }

        private bool Compile() {
            CompilerOptions options = new CompilerOptions();
            options.DebugFlavor = DebugFlavor;
            if (DebugFlavor) {
                options.IncludeTests = IncludeTests;
            }
            else {
                options.Minimize = Minimize;
            }
            options.Defines = GetDefines();
            options.References = GetReferences();
            options.Sources = GetSources(_sources);
            options.Resources = GetResources(_resources);
            if (_template != null) {
                options.TemplateFile = new TaskItemInputStreamSource(_template, "Template");
            }
            if (_docCommentFile != null) {
                options.DocCommentFile = new TaskItemInputStreamSource(_docCommentFile, "DocComment");
            }

            ITaskItem scriptTaskItem = new TaskItem(OutputPath);
            options.ScriptFile = new TaskItemOutputStreamSource(scriptTaskItem);

            string errorMessage = String.Empty;
            if (options.Validate(out errorMessage) == false) {
                Log.LogError(errorMessage);
                return false;
            }

            ScriptCompiler compiler = new ScriptCompiler(this);
            compiler.Compile(options);
            if (_hasErrors == false) {
                _script = scriptTaskItem;

                string projectName = (_projectPath != null) ? Path.GetFileNameWithoutExtension(_projectPath) : String.Empty;
                string scriptFileName = Path.GetFileName(scriptTaskItem.ItemSpec);
                string scriptPath = Path.GetFullPath(scriptTaskItem.ItemSpec);

                Log.LogMessage(MessageImportance.High, "{0} -> {1} ({2})", projectName, scriptFileName, scriptPath);
            }
            else {
                return false;
            }

            return true;
        }

        public override bool Execute() {
            bool success = false;

            try {
                success = Compile();
            }
            catch {
            }

            return success;
        }

        private ICollection<string> GetDefines() {
            if (Defines.Length == 0) {
                return new string[0];
            }

            return Defines.Split(';');
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

        private ICollection<IStreamSource> GetResources(IEnumerable<ITaskItem> allResources) {
            if (allResources == null) {
                return new TaskItemInputStreamSource[0];
            }

            string locale = Locale;
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
