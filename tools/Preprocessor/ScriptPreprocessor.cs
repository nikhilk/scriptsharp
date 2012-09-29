// ScriptSharpPreprocessor.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using ScriptSharp.Preprocessor;

namespace ScriptSharp {

    internal sealed class ScriptPreprocessor {

        private IStreamResolver _includeResolver;
        private IErrorHandler _errorHandler;

        public ScriptPreprocessor(IStreamResolver includeResolver, IErrorHandler errorHandler) {
            _includeResolver = includeResolver;
            _errorHandler = errorHandler;
        }

        public void Preprocess(PreprocessorOptions options) {
            Stream outputStream = options.TargetFile.GetStream();
            StreamWriter outputWriter = null;

            PreprocessorTextReader preprocessor = null;
            try {
                if (outputStream != null) {
                    outputWriter = new StreamWriter(outputStream);
                    preprocessor = new PreprocessorTextReader(options.SourceFile,
                                                              options.PreprocessorVariables,
                                                              _includeResolver);

                    TextReader contentReader = preprocessor;
                    if (options.Minimize) {
                        contentReader = new CondenserTextReader(preprocessor, options.StripCommentsOnly);
                    }

                    if (preprocessor.Initialize(outputWriter)) {
                        int ch;
                        while ((ch = contentReader.Read()) != -1) {
                            if (options.UseWindowsLineBreaks && (ch == '\n')) {
                                outputWriter.Write('\r');
                            }
                            outputWriter.Write((char)ch);
                        }
                    }
                }
            }
            catch (PreprocessorException pe) {
                if (_errorHandler != null) {
                    _errorHandler.ReportError(pe.Message, pe.SourceFile + " (" + pe.Line + ", 1)");
                }

                if (pe.InnerException != null) {
                    throw pe.InnerException;
                }
            }
            finally {
                if (preprocessor != null) {
                    preprocessor.Close();
                }
                if (outputWriter != null) {
                    outputWriter.Flush();
                }
                if (outputStream != null) {
                    options.TargetFile.CloseStream(outputStream);
                }
            }
        }
    }
}
