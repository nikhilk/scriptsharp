using System;
using System.Collections.Generic;
using System.IO;
using DSharp.Compiler;
using DSharp.Compiler.Errors;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace DSharp.Build.Tasks
{
    public sealed class MetadataCompilerTask : Task, IErrorHandler, IStreamSourceResolver
    {
        private string outputPath;
        private List<ITaskItem> scripts;

        private bool hasErrors;

        public MetadataCompilerTask()
        {
            CopyReferences = true;
        }

        [Required]
        public ITaskItem Assembly { get; set; }

        public bool CopyReferences { get; set; }

        public bool DebugMode { get; set; }

        public string IntermediarySourceFolder { get; set; }

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

        [Required]
        public string ProjectPath { get; set; }

        [Required]
        public ITaskItem[] References { get; set; }

        public string ScriptName { get; set; }

        [Output]
        public ITaskItem[] Scripts
        {
            get
            {
                if (scripts == null)
                {
                    return new ITaskItem[0];
                }
                return scripts.ToArray();
            }
        }

        private bool Compile()
        {
            IMetadataCompilerOptions options = CreateOptions(out ITaskItem scriptTaskItem);
            scripts.Add(scriptTaskItem);

            MetadataCompiler compiler = new MetadataCompiler(this);

            return compiler.Compile(options) && !hasErrors;
        }

        private IMetadataCompilerOptions CreateOptions(out ITaskItem outputScriptItem)
        {
            IMetadataCompilerOptions options = new CompilerOptions();
            options.References = GetReferences();
            options.AssemblyName = AssemblyName;
            options.DebugMode = DebugMode;
            options.Assembly = Assembly.ItemSpec;

            var metadataPath = GetMetadataFilePath();
            outputScriptItem = new TaskItem(metadataPath);

            options.MetadataFile = new TaskItemOutputStreamSource(new TaskItem(metadataPath));

            return options;
        }

        public override bool Execute()
        {
            scripts = new List<ITaskItem>();

            bool success;
            try
            {
                success = Compile();
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                throw;
            }

            return success;
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

        private string GetMetadataFilePath()
        {
            string scriptName = ScriptName;
            if (string.IsNullOrEmpty(scriptName))
            {
                scriptName = Path.GetFileName(Assembly.ItemSpec);
            }

            if (Directory.Exists(OutputPath) == false)
            {
                Directory.CreateDirectory(OutputPath);
            }

            return Path.GetFullPath(Path.Combine(OutputPath, Path.ChangeExtension(scriptName, "meta.js")));
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

        void IErrorHandler.ReportWarning(CompilerError error)
        {
            Log.LogWarning(
                subcategory: string.Empty,
                warningCode: error.FormattedErrorCode,
                helpKeyword: string.Empty,
                file: error.File,
                lineNumber: error.LineNumber.GetValueOrDefault(),
                endLineNumber: error.LineNumber.GetValueOrDefault(),
                columnNumber: error.ColumnNumber.GetValueOrDefault(),
                endColumnNumber: error.ColumnNumber.GetValueOrDefault(),
                message: error.Description);
        }

        IStreamSource IStreamSourceResolver.Resolve(string name)
        {
            string path = Path.Combine(Path.GetDirectoryName(ProjectPath), name);
            if (File.Exists(path))
            {
                return new FileInputStreamSource(path, name);
            }

            return null;
        }

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
