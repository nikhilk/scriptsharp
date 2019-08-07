using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DSharp.Compiler;
using DSharp.Compiler.Errors;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using NUglify;
using NUglify.JavaScript;

namespace DSharp.Build.Tasks
{
    public sealed class ScriptCompilerTask : Task, IErrorHandler, IStreamSourceResolver
    {
        private string defines;
        private string copyReferencesPath;
        private string outputPath;
        private List<ITaskItem> scripts;

        private bool hasErrors;

        public ScriptCompilerTask()
        {
            CopyReferences = true;
        }

        [Required]
        public ITaskItem Assembly { get; set; }

        public bool CopyReferences { get; set; }

        public string AssemblyName { get; set; }

        public string CopyReferencesPath
        {
            get
            {
                if (copyReferencesPath == null)
                {
                    return string.Empty;
                }
                return copyReferencesPath;
            }
            set
            {
                copyReferencesPath = value;
            }
        }

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

        public bool Minimize { get; set; }

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

        public ITaskItem[] Resources { get; set; }

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

        [Required]
        public ITaskItem[] Sources { get; set; }

        public string TemplatePath { get; set; }

        private bool Compile(IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems, string locale)
        {
            CompilerOptions options = CreateOptions(sourceItems, resourceItems, locale, false, out ITaskItem scriptTaskItem);

            if (options.Validate(out string errorMessage) == false)
            {
                Log.LogError(errorMessage);
                return false;
            }

            ScriptCompiler compiler = new ScriptCompiler(this);
            compiler.Compile(options);
            if (hasErrors == false)
            {
                // Only copy references once (when building language neutral scripts)
                bool copyReferences = string.IsNullOrEmpty(locale) && CopyReferences;

                OnScriptFileGenerated(scriptTaskItem, options, copyReferences);
                if (hasErrors)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (Minimize)
            {
                CompilerOptions minimizeOptions = CreateOptions(sourceItems, resourceItems, locale, true, out scriptTaskItem);
                ScriptCompiler minimizingCompiler = new ScriptCompiler(this);
                minimizingCompiler.Compile(minimizeOptions);
                if (hasErrors == false)
                {
                    ExecuteCruncher(scriptTaskItem);
                    OnScriptFileGenerated(scriptTaskItem, minimizeOptions, /* copyReferences */ false);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private CompilerOptions CreateOptions(IEnumerable<ITaskItem> sourceItems, IEnumerable<ITaskItem> resourceItems,
                                              string locale, bool minimize,
                                              out ITaskItem outputScriptItem)
        {
            CompilerOptions options = new CompilerOptions();
            options.Minimize = minimize;
            options.Defines = GetDefines();
            options.References = GetReferences();
            options.Sources = GetSources(sourceItems);
            options.Resources = GetResources(resourceItems, locale);
            options.IncludeResolver = this;
            options.AssemblyName = AssemblyName;

            if(!string.IsNullOrEmpty(TemplatePath))
            {
                options.ScriptInfo.Template = GetTemplate();
            }

            string scriptFilePath = GetScriptFilePath(locale, minimize);
            outputScriptItem = new TaskItem(scriptFilePath);
            options.ScriptFile = new TaskItemOutputStreamSource(outputScriptItem);

            return options;
        }

        public override bool Execute()
        {
            scripts = new List<ITaskItem>();

            bool success;
            try
            {
                success = ExecuteCore(Sources, Resources);
            }
            catch (Exception ex)
            {
                Log.LogErrorFromException(ex);
                success = false;

                throw;
            }

            return success;
        }

        private bool ExecuteCore(IEnumerable<ITaskItem> sources, IEnumerable<ITaskItem> resources)
        {
            // Create the neutral culture scripts first, and if that 
            // succeeds, compile any localized variants that are supposed
            // to be generated.

            if (Compile(sources, resources, /* locale */ string.Empty))
            {
                ICollection<string> locales = GetLocales(resources);

                foreach (string locale in locales)
                {
                    if (Compile(sources, resources, locale) == false)
                    {
                        return false;
                    }
                }

                GenerateDeploymentFile();
                return true;
            }

            return false;
        }

        private void ExecuteCruncher(ITaskItem scriptItem)
        {
            string script = File.ReadAllText(scriptItem.ItemSpec);

            CodeSettings codeSettings = new CodeSettings
            {
                StripDebugStatements = false,
                OutputMode = OutputMode.SingleLine,
                IgnorePreprocessorDefines = true,
                IgnoreConditionalCompilation = true,
                TermSemicolons = true,
                NoAutoRenameList = "$"
            };

            UglifyResult result = Uglify.Js(script, codeSettings);

            if(result.HasErrors)
            {
                foreach (UglifyError error in result.Errors)
                {
                    Log.LogError(error.Subcategory, error.ErrorCode, error.HelpKeyword, error.File, error.StartLine, error.StartColumn, error.EndLine, error.EndColumn, error.Message);
                }

                return;
            }

            File.WriteAllText(scriptItem.ItemSpec, result.Code);
        }

        private void GenerateDeploymentFile()
        {
            try
            {
                string assemblyFile = Path.GetFileName(Assembly.ItemSpec);
                string scriptsFilePath = Path.Combine(OutputPath, Path.ChangeExtension(assemblyFile, "scripts"));

                Uri scriptsUri = new Uri(Path.GetFullPath(scriptsFilePath), UriKind.Absolute);
                IEnumerable<string> selectedScripts =
                    scripts.Select(s =>
                    {
                        Uri fileUri = new Uri(s.ItemSpec, UriKind.Absolute);
                        return Uri.UnescapeDataString(scriptsUri.MakeRelativeUri(fileUri).ToString());
                    });
                File.WriteAllLines(scriptsFilePath, selectedScripts);
            }
            catch (Exception e)
            {
                Log.LogError(e.ToString());
            }
        }

        private ICollection<string> GetDefines()
        {
            if (Defines.Length == 0)
            {
                return new string[0];
            }

            return Defines.Split(';');
        }

        private ICollection<string> GetLocales(IEnumerable<ITaskItem> resourceItems)
        {
            List<string> locales = new List<string>();

            // Inspect the list of resources to create the list of unique locales
            if (resourceItems != null)
            {
                foreach (ITaskItem resourceItem in resourceItems)
                {
                    string locale = ResourceFile.GetLocale(resourceItem.ItemSpec);

                    if (locales.Contains(locale) == false)
                    {
                        locales.Add(locale);
                    }
                }
            }

            return locales;
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

        private ICollection<IStreamSource> GetResources(IEnumerable<ITaskItem> allResources, string locale)
        {
            if (allResources == null)
            {
                return new TaskItemInputStreamSource[0];
            }

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

        private string GetScriptFilePath(string locale, bool minimize)
        {
            string scriptName = ScriptName;
            if (string.IsNullOrEmpty(scriptName))
            {
                scriptName = Path.GetFileName(Assembly.ItemSpec);
            }

            string extension = minimize ? "min.js" : "js";
            if (string.IsNullOrEmpty(locale) == false)
            {
                extension = locale + "." + extension;
            }

            if (Directory.Exists(OutputPath) == false)
            {
                Directory.CreateDirectory(OutputPath);
            }

            return Path.GetFullPath(Path.Combine(OutputPath, Path.ChangeExtension(scriptName, extension)));
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

        private string GetTemplate()
        {
            if(!File.Exists(TemplatePath))
            {
                Log.LogWarning($"Unable to read from template file: {TemplatePath}. Default template will be used.");
                return null;
            }

            return File.ReadAllText(TemplatePath);
        }

        private void OnScriptFileGenerated(ITaskItem scriptItem, CompilerOptions options, bool copyReferences)
        {
            Func<string, bool, string> getScriptFile = delegate (string reference, bool minimized)
            {
                string scriptFile = Path.ChangeExtension(reference, minimized ? ".min.js" : ".js");

                string fileName = Path.GetFileNameWithoutExtension(scriptFile);
                if (fileName.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase))
                {
                    fileName = (minimized ? DSharpStringResources.DSHARP_SCRIPT_NAME + ".min" : DSharpStringResources.DSHARP_SCRIPT_NAME) + Path.GetExtension(scriptFile);
                    scriptFile = Path.Combine(Path.GetDirectoryName(scriptFile), fileName);
                }

                if (File.Exists(scriptFile))
                {
                    return scriptFile;
                }

                fileName = Path.GetFileName(scriptFile);
                if ((fileName.Length > 7) && fileName.StartsWith("Script.", StringComparison.OrdinalIgnoreCase))
                {
                    fileName = fileName.Substring(7);
                    scriptFile = Path.Combine(Path.GetDirectoryName(scriptFile), fileName);

                    if (File.Exists(scriptFile))
                    {
                        return scriptFile;
                    }
                }

                return null;
            };

            Action<string, string> safeCopyFile = delegate (string sourceFilePath, string targetFilePath)
            {
                try
                {
                    string directory = Path.GetDirectoryName(targetFilePath);
                    if (Directory.Exists(directory) == false)
                    {
                        Directory.CreateDirectory(directory);
                    }

                    if (File.Exists(targetFilePath))
                    {
                        // If the file already exists, make sure it is not read-only, so
                        // it can be overrwritten.
                        File.SetAttributes(targetFilePath, FileAttributes.Normal);
                    }

                    File.Copy(sourceFilePath, targetFilePath, /* overwrite */ true);

                    // Copy the file, and then make sure it is not read-only (for example, if the
                    // source file for a referenced script is read-only).
                    File.SetAttributes(targetFilePath, FileAttributes.Normal);

                    scripts.Add(new TaskItem(targetFilePath));
                }
                catch (Exception e)
                {
                    Log.LogError("Unable to copy referenced script '" + sourceFilePath + "' as '" + targetFilePath + "' (" + e.Message + ")");
                    hasErrors = true;
                }
            };

            string projectName = Path.GetFileNameWithoutExtension(ProjectPath);
            string scriptFileName = Path.GetFileName(scriptItem.ItemSpec);
            string scriptPath = Path.GetFullPath(scriptItem.ItemSpec);
            string scriptFolder = Path.GetDirectoryName(scriptItem.ItemSpec);

            Log.LogMessage(MessageImportance.High, "{0} -> {1} ({2})", projectName, scriptFileName, scriptPath);

            if (copyReferences)
            {
                foreach (string reference in options.References)
                {
                    string scriptFile = getScriptFile(reference, /* minimized */ false);
                    if (scriptFile != null)
                    {
                        string path = Path.Combine(scriptFolder, CopyReferencesPath, Path.GetFileName(scriptFile));
                        safeCopyFile(scriptFile, path);
                    }

                    string minScriptFile = getScriptFile(reference, /* minimized */ true);
                    if (minScriptFile != null)
                    {
                        string path = Path.Combine(scriptFolder, CopyReferencesPath, Path.GetFileName(minScriptFile));
                        safeCopyFile(minScriptFile, path);
                    }
                }
            }

            scripts.Add(scriptItem);
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
            string path = Path.Combine(Path.GetDirectoryName(ProjectPath), name);
            if (File.Exists(path))
            {
                return new FileInputStreamSource(path, name);
            }

            return null;
        }

        #endregion


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
