using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using DSharp.Compiler.Errors;
using DSharp.Compiler.Generator;
using DSharp.Compiler.Importer;
using DSharp.Compiler.References;
using DSharp.Compiler.ScriptModel.Symbols;

namespace DSharp.Compiler
{
    public sealed class MetadataCompiler : IErrorHandler
    {
        private readonly IErrorHandler errorHandler;
        private bool hasErrors;
        private IMetadataCompilerOptions options;
        private SymbolSet symbols;

        public MetadataCompiler()
            : this(null)
        {
        }

        public MetadataCompiler(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public bool Compile(IMetadataCompilerOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            if (options.DebugMode)
            {
                Debugger.Launch();
            }

            hasErrors = false;
            symbols = new SymbolSet();
            symbols.ScriptName = options.AssemblyName;
            ScriptReferenceProvider.Instance.Reset();

            ImportMetadata();
            GenerateMetadata();

            if (hasErrors)
            {
                return false;
            }

            return true;
        }

        private void GenerateMetadata()
        {
            Stream outputStream = null;
            TextWriter outputWriter = null;

            try
            {
                outputStream = options.MetadataFile?.GetStream();

                if (outputStream == null)
                {
                    return;
                }

                outputWriter = new StreamWriter(outputStream, new UTF8Encoding(false));
                ScriptMetadataGenerator scriptGenerator = new ScriptMetadataGenerator(outputWriter, options, symbols);
                scriptGenerator.GenerateScriptMetadata(symbols);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                outputWriter?.Flush();

                if (outputStream != null)
                {
                    options.MetadataFile.CloseStream(outputStream);
                }
            }
        }

        private void ImportMetadata()
        {
            MetadataImporter mdImporter = new MetadataImporter(this);
            mdImporter.ImportMetadata(options.References, symbols, options.Assembly);
        }

        void IErrorHandler.ReportError(CompilerError error)
        {
            hasErrors = true;
            if (errorHandler != null)
            {
                errorHandler.ReportError(error);
                return;
            }

            //TODO: Look at adding a logger interface
            WriteError(error);
        }

        void IErrorHandler.ReportWarning(CompilerError error)
        {
            if (errorHandler != null)
            {
                errorHandler.ReportWarning(error);
                return;
            }

            //TODO: Look at adding a logger interface
            WriteError(error);
        }

        private void WriteError(CompilerError error)
        {
            if (error.ColumnNumber != null || error.LineNumber != null)
            {
                Console.Error.WriteLine($"{error.File}({error.LineNumber.GetValueOrDefault()}, {error.ColumnNumber.GetValueOrDefault()})");
            }

            Console.Error.WriteLine(error.Description);
        }
    }
}
