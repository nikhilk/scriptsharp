// CodeModelBuilder.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.IO;
using DSharp.Compiler.CodeModel.Tokens;
using DSharp.Compiler.CodeModel.Types;
using DSharp.Compiler.Errors;
using DSharp.Compiler.Parser;

namespace DSharp.Compiler.CodeModel
{
    internal sealed class CodeModelBuilder
    {
        private readonly IErrorHandler errorHandler;

        private readonly CompilerOptions options;

        private bool hasErrors;

        public CodeModelBuilder(CompilerOptions options, IErrorHandler errorHandler)
        {
            this.options = options;
            this.errorHandler = errorHandler;
        }

        public CompilationUnitNode BuildCodeModel(IStreamSource source)
        {
            hasErrors = false;

            string filePath = source.FullName;

            char[] buffer = GetBuffer(source);

            if (buffer == null)
            {
                errorHandler.ReportInputError(filePath);

                return null;
            }

            IDictionary definesTable = new Hashtable();

            if (options.Defines != null && options.Defines.Count != 0)
            {
                foreach (string s in options.Defines) definesTable[s] = null;
            }

            NameTable nameTable = new NameTable();
            LineMap lineMap = new LineMap(filePath);

            FileLexer lexer = new FileLexer(nameTable, filePath);
            lexer.OnError += OnError;
            Token[] tokens = lexer.Lex(buffer, definesTable, lineMap, /* includeComments */ false);

            if (hasErrors == false)
            {
                FileParser parser = new FileParser(nameTable, filePath);
                parser.OnError += OnError;

                CompilationUnitNode compilationUnit = parser.Parse(tokens, lineMap);

                foreach (ParseNode node in compilationUnit.Members)
                {
                    if (node is NamespaceNode namespaceNode)
                    {
                        namespaceNode.IncludeCompilationUnitUsingClauses();
                    }
                }

                if (hasErrors == false)
                {
                    return compilationUnit;
                }
            }

            return null;
        }

        private char[] GetBuffer(IStreamSource source)
        {
            char[] buffer = null;

            Stream stream = source.GetStream();

            if (stream != null)
            {
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();

                buffer = text.ToCharArray();
                source.CloseStream(stream);
            }

            return buffer;
        }

        private void OnError(object sender, FileLexerErrorEventArgs eventArgs)
        {
            FileLexer fileLexer = sender as FileLexer;

            hasErrors = true;

            errorHandler.ReportFileLexerError(fileLexer?.FilePath, eventArgs);
        }
    }
}
