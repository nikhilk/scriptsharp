using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using DSharp.Compiler;
using DSharp.Compiler.Errors;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace DSharp.Build.Tasks
{
    public sealed class ScriptCompilerExecTask : Task, IErrorHandler, IStreamSourceResolver
    {
        private readonly bool tests;
        private string defines;
        private string locale;

        private string outputPath;
        private bool hasErrors;

        public string Defines
        {
            get
            {
                if (defines == null)
                {
                    return string.Empty;
                }
                return defines;
            }
            set
            {
                defines = value;
            }
        }

        public string Locale
        {
            get
            {
                if (locale == null)
                {
                    return string.Empty;
                }
                return locale;
            }
            set
            {
                locale = value;
            }
        }

        public bool Minimize { get; set; }

        public string AssemblyName { get; set; }

        [Required]
        public string OutputPath
        {
            get
            {
                if (outputPath == null)
                {
                    return string.Empty;
                }
                return outputPath;
            }
            set
            {
                outputPath = value;
            }
        }

        public string ProjectPath { get; set; }

        [Required]
        public ITaskItem[] References { get; set; }

        public ITaskItem[] Resources { get; set; }

        [Output]
        public ITaskItem Script { get; private set; }

        [Required]
        public ITaskItem[] Sources { get; set; }

        private bool Compile()
        {
            CompilerOptions options = new CompilerOptions();
            options.Minimize = Minimize;
            options.Defines = GetDefines();
            options.References = GetReferences();
            options.Sources = GetSources(Sources);
            options.Resources = GetResources(Resources);
            options.IncludeResolver = this;
            options.AssemblyName = AssemblyName;

            ITaskItem scriptTaskItem = new TaskItem(OutputPath);
            options.ScriptFile = new TaskItemOutputStreamSource(scriptTaskItem);

            string errorMessage = string.Empty;
            if (options.Validate(out errorMessage) == false)
            {
                Log.LogError(errorMessage);
                return false;
            }

            ScriptCompiler compiler = new ScriptCompiler(this);
            compiler.Compile(options);
            if (hasErrors == false)
            {
                Script = scriptTaskItem;

                string projectName = (ProjectPath != null) ? Path.GetFileNameWithoutExtension(ProjectPath) : string.Empty;
                string scriptFileName = Path.GetFileName(scriptTaskItem.ItemSpec);
                string scriptPath = Path.GetFullPath(scriptTaskItem.ItemSpec);

                Log.LogMessage(MessageImportance.High, "{0} -> {1} ({2})", projectName, scriptFileName, scriptPath);
            }
            else
            {
                return false;
            }

            return true;
        }

        public override bool Execute()
        {
            bool success = false;

            try
            {
                success = Compile();
            }
            catch
            {
            }

            return success;
        }

        private ICollection<string> GetDefines()
        {
            if (Defines.Length == 0)
            {
                return new string[0];
            }

            return Defines.Split(';');
        }

        private ICollection<string> GetReferences()
        {
            if (References == null)
            {
                return new string[0];
            }

            List<string> references = new List<string>(References.Length);
            foreach (ITaskItem reference in References)
            {
                // TODO: This is a hack... something in the .net 4 build system causes
                //       System.Core.dll to get included [sometimes].
                //       That shouldn't happen... so filter it out here.
                if (reference.ItemSpec.EndsWith("System.Core.dll", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                references.Add(reference.ItemSpec);
            }

            return references;
        }

        private ICollection<IStreamSource> GetResources(IEnumerable<ITaskItem> allResources)
        {
            if (allResources == null)
            {
                return new TaskItemInputStreamSource[0];
            }

            string locale = Locale;
            List<IStreamSource> resources = new List<IStreamSource>();
            foreach (ITaskItem resource in allResources)
            {
                string itemLocale = ResourceFile.GetLocale(resource.ItemSpec);

                if (string.IsNullOrEmpty(locale) && string.IsNullOrEmpty(itemLocale))
                {
                    resources.Add(new TaskItemInputStreamSource(resource));
                }
                else if ((string.Compare(locale, itemLocale, StringComparison.OrdinalIgnoreCase) == 0) ||
                         locale.StartsWith(itemLocale, StringComparison.OrdinalIgnoreCase))
                {
                    // Either the item locale matches, or the item locale is a prefix
                    // of the locale (eg. we want to include "fr" if the locale specified
                    // is fr-FR)
                    resources.Add(new TaskItemInputStreamSource(resource));
                }
            }

            return resources;
        }

        private ICollection<IStreamSource> GetSources(IEnumerable<ITaskItem> sourceItems)
        {
            if (sourceItems == null)
            {
                return new TaskItemInputStreamSource[0];
            }

            List<IStreamSource> sources = new List<IStreamSource>();
            foreach (ITaskItem sourceItem in sourceItems)
            {
                // TODO: This is a hack... something in the .net 4 build system causes
                //       generation of an AssemblyAttributes.cs file with fully-qualified
                //       type names, that we can't handle (this comes from multitargeting),
                //       and there doesn't seem like a way to turn it off.
                if (sourceItem.ItemSpec.EndsWith(".AssemblyAttributes.cs", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                sources.Add(new TaskItemInputStreamSource(sourceItem));
            }

            return sources;
        }

        void IErrorHandler.ReportError(CompilerError error)
        {
            Log.LogError(
                subcategory: string.Empty,
                errorCode: error.FormattedErrorCode,
                helpKeyword: string.Empty,
                file: error.File, 
                lineNumber: error.LineNumber.GetValueOrDefault(), 
                endLineNumber: error.LineNumber.GetValueOrDefault(),
                columnNumber: error.ColumnNumber.GetValueOrDefault(),
                endColumnNumber: error.ColumnNumber.GetValueOrDefault(),
                message: error.Description);
            hasErrors = true;
        }

        #region Implementation of IStreamSourceResolver

        IStreamSource IStreamSourceResolver.Resolve(string name)
        {
            if (ProjectPath != null)
            {
                string path = Path.Combine(Path.GetDirectoryName(ProjectPath), name);
                if (File.Exists(path))
                {
                    return new FileInputStreamSource(path, name);
                }
            }

            return null;
        }

        #endregion Implementation of IStreamSourceResolver

        private sealed class TaskItemInputStreamSource : FileInputStreamSource
        {
            public TaskItemInputStreamSource(ITaskItem taskItem)
                : base(taskItem.ItemSpec)
            {
            }

            public TaskItemInputStreamSource(ITaskItem taskItem, string name)
                : base(taskItem.ItemSpec, name)
            {
            }
        }

        private sealed class TaskItemOutputStreamSource : FileOutputStreamSource
        {
            public TaskItemOutputStreamSource(ITaskItem taskItem)
                : base(taskItem.ItemSpec)
            {
            }

            public TaskItemOutputStreamSource(ITaskItem taskItem, string name)
                : base(taskItem.ItemSpec, name)
            {
            }
        }
    }
}
