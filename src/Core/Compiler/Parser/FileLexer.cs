// FileLexer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Diagnostics;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Parser {

    /// <summary>
    /// Preprocesses and Lexes a C# compilation Unit.
    /// </summary>
    internal sealed class FileLexer {

        private TextBuffer _text;
        private string _path;
        private IDictionary _defines;
        private LineMap _lineMap;
        private Lexer _lexer;
        private PreprocessorLineParser _parser;
        private ArrayList _tokens;
        private bool _includeComments;

        public FileLexer(NameTable nameTable, string path) {
            _lexer = new Lexer(nameTable, path);
            _lexer.OnError += new ErrorEventHandler(ReportError);
            _parser = new PreprocessorLineParser(nameTable);
            _parser.OnError += new ErrorEventHandler(ReportError);

            _path = path;
        }

        /// <summary>
        /// Lexes a compilation unit.
        /// </summary>
        /// <param name="text"> The text to lex. </param>
        /// <param name="defines"> The set of preprocessor symbols defined in source. 
        /// Is modified to include results of #define/#undef found in this compilation unit. </param>
        /// <param name="lineMap">The LineMap contains the source text to file/line mapping
        /// as a result of #line directives. </param>
        /// <param name="includeComments"> Should comment tokens be generated. </param>
        /// <returns></returns>
        public Token[] Lex(char[] text, IDictionary defines, LineMap lineMap, bool includeComments) {
            // initialize
            _text = new TextBuffer(text);
            _defines = defines;
            _lineMap = lineMap;
            _includeComments = includeComments;

            LexFile();

            _text = null;
            _defines = null;
            _lineMap = null;
            _includeComments = false;

            return (Token[])_tokens.ToArray(typeof(Token));
        }

        public event FileErrorEventHandler OnError;

        /// <summary>
        /// Returns whether a character is a C# line separator.
        /// </summary>
        public static bool IsLineSeparator(char ch) {
            return Lexer.IsLineSeparator(ch);
        }

        private void LexFile() {
            _tokens = new ArrayList(_text.Length / 8);
            _tokens.Add(new Token(TokenType.BOF, _path, _text.Position));

            PreprocessorLine line;
            do {
                line = LexBlock();
                if (line.Type != PreprocessorTokenType.EndOfLine) {
                    ReportError(PreprocessorError.UnexpectedDirective);
                }
            } while (line.Type != PreprocessorTokenType.EndOfLine);

            if (TokenType.EOF != ((Token)_tokens[_tokens.Count - 1]).Type) {
                _tokens.Add(new Token(TokenType.EOF, _path, _text.Position));
            }
        }

        private PreprocessorLine LexBlock() {
            while (_lexer.LexBlock(_text, _tokens, _includeComments)) {
                PreprocessorLine line = _parser.Parse(_text, _defines);

                if (line != null) {
                DoLine:
                    switch (line.Type) {
                        case PreprocessorTokenType.Define:
                        case PreprocessorTokenType.Undef:
                        case PreprocessorTokenType.Warning:
                        case PreprocessorTokenType.Error:
                        case PreprocessorTokenType.Line:
                        case PreprocessorTokenType.Default:
                        case PreprocessorTokenType.Hidden:
                        case PreprocessorTokenType.Pragma:
                            DoSimpleLine(line);
                            break;

                        case PreprocessorTokenType.Region:
                            line = LexBlock();
                            if (line.Type == PreprocessorTokenType.EndRegion) {
                                break;
                            }
                            else {
                                ReportError(PreprocessorError.EndRegionExpected);
                                goto DoLine;
                            }

                        case PreprocessorTokenType.If:
                            line = DoIf((PreprocessorIfLine)line);
                            if (line != null) {
                                goto DoLine;
                            }
                            break;

                        case PreprocessorTokenType.EndRegion:
                        case PreprocessorTokenType.Elif:
                        case PreprocessorTokenType.Else:
                        case PreprocessorTokenType.Endif:
                        case PreprocessorTokenType.EndOfLine:
                            return line;
                    }
                }
            }

            return new PreprocessorLine(PreprocessorTokenType.EndOfLine);
        }

        private void DoSimpleLine(PreprocessorLine line) {
            switch (line.Type) {
                case PreprocessorTokenType.Define:
                case PreprocessorTokenType.Undef:
                    if (FoundNonComment()) {
                        // have more than BOF
                        ReportError(PreprocessorError.DefineAfterToken);
                    }
                    else {
                        PreprocessorDeclarationLine decl = (PreprocessorDeclarationLine)line;
                        if (decl.Type == PreprocessorTokenType.Define) {
                            _defines.Add(decl.Identifier.Text, null);
                        }
                        else {
                            _defines.Remove(decl.Identifier.Text);
                        }
                    }
                    break;

                case PreprocessorTokenType.Warning:
                    ReportFormattedError(PreprocessorError.PPWarning, ((PreprocessorControlLine)line).Message);
                    break;

                case PreprocessorTokenType.Error:
                    ReportFormattedError(PreprocessorError.PPError, ((PreprocessorControlLine)line).Message);
                    break;

                case PreprocessorTokenType.Line: {
                        PreprocessorLineNumberLine lineNumber = ((PreprocessorLineNumberLine)line);
                        if (lineNumber.File != null) {
                            _lineMap.AddEntry(_text.Line, lineNumber.Line, lineNumber.File);
                        }
                        else {
                            _lineMap.AddEntry(_text.Line, lineNumber.Line);
                        }
                    }
                    break;
                case PreprocessorTokenType.Default:
                    _lineMap.AddEntry(_text.Line, _text.Line, _lineMap.FileName);
                    break;

                case PreprocessorTokenType.Hidden:
                    // #line hidden is for the weak
                    break;
                case PreprocessorTokenType.Pragma:
                    // no pragma's suported yet
                    break;
                default:
                    Debug.Fail("Bad preprocessor line");
                    break;
            }
        }

        private PreprocessorLine SkipBlock() {
            PreprocessorLine line;
            do {
                line = _parser.ParseNextLine(_text, _defines);
            DoLine:
                switch (line.Type) {
                    case PreprocessorTokenType.Define:
                    case PreprocessorTokenType.Undef:
                    case PreprocessorTokenType.Warning:
                    case PreprocessorTokenType.Error:
                    case PreprocessorTokenType.Line:
                        line = null;
                        break;

                    case PreprocessorTokenType.Region:
                        line = SkipBlock();
                        if (line.Type != PreprocessorTokenType.EndRegion) {
                            ReportError(PreprocessorError.EndRegionExpected);
                            goto DoLine;
                        }
                        else {
                            line = null;
                            break;
                        }

                    case PreprocessorTokenType.If:
                        line = SkipElifBlock();
                        if (line != null) {
                            goto DoLine;
                        }
                        break;

                    case PreprocessorTokenType.EndRegion:
                    case PreprocessorTokenType.Endif:
                    case PreprocessorTokenType.Else:
                    case PreprocessorTokenType.Elif:
                    case PreprocessorTokenType.EndOfLine:
                        break;
                }
            } while (line == null);

            return line;
        }

        private PreprocessorLine DoIf(PreprocessorIfLine ifLine) {
            PreprocessorLine line;

            if (ifLine.Value) {
                line = LexBlock();
                switch (line.Type) {
                    case PreprocessorTokenType.Endif:
                        line = null;
                        break;
                    case PreprocessorTokenType.Elif:
                        line = SkipElifBlock();
                        break;

                    case PreprocessorTokenType.Else:
                        line = SkipElseBlock();
                        break;

                    case PreprocessorTokenType.EndOfLine:
                        ReportError(PreprocessorError.UnexpectedEndOfFile);
                        break;

                    case PreprocessorTokenType.EndRegion:
                    default:
                        ReportError(PreprocessorError.UnexpectedDirective);
                        break;
                }
            }
            else {
                line = SkipBlock();
                switch (line.Type) {
                    case PreprocessorTokenType.Else:
                        line = DoElse();
                        break;

                    case PreprocessorTokenType.Elif:
                        return DoIf((PreprocessorIfLine)line);

                    case PreprocessorTokenType.Endif:
                        line = null;
                        break;

                    case PreprocessorTokenType.EndOfLine:
                        ReportError(PreprocessorError.UnexpectedEndOfFile);
                        break;

                    case PreprocessorTokenType.EndRegion:
                    default:
                        ReportError(PreprocessorError.UnexpectedDirective);
                        break;
                }
            }

            return line;
        }

        private PreprocessorLine DoElse() {
            PreprocessorLine line = LexBlock();
            if (line.Type == PreprocessorTokenType.Endif) {
                line = null;
            }
            else {
                ReportError(PreprocessorError.PPEndifExpected);
            }

            return line;
        }

        private PreprocessorLine SkipElseBlock() {
            PreprocessorLine line = SkipBlock();
            if (line.Type == PreprocessorTokenType.Endif) {
                line = null;
            }
            else {
                ReportError(PreprocessorError.PPEndifExpected);
            }

            return line;
        }

        private PreprocessorLine SkipElifBlock() {
            PreprocessorLine line = SkipBlock();
            if (line.Type == PreprocessorTokenType.Endif) {
                line = null;
            }
            else if (line.Type == PreprocessorTokenType.Else) {
                line = SkipElseBlock();
            }
            else if (line.Type == PreprocessorTokenType.Elif) {
                line = SkipElifBlock();
            }
            else {
                ReportError(PreprocessorError.PPEndifExpected);
            }

            return line;
        }

        private bool FoundNonComment() {
            // first token is BOF
            for (int i = 1; i < _tokens.Count; i += 1) {
                if (((Token)_tokens[i]).Type != TokenType.Comment)
                    return true;
            }

            return false;
        }

        private void ReportFormattedError(Error error, params object[] args) {
            BufferPosition position = _text.Position;
            position.Line -= 1;
            ReportError(error, position, args);
        }

        private void ReportError(Error error) {
            BufferPosition position = _text.Position;
            position.Line -= 1;
            ReportError(error, position);
        }

        private void ReportError(Error error, BufferPosition position, params object[] args) {
            if (OnError != null) {
                OnError(this, new FileErrorEventArgs(error, _lineMap.Map(position), args));
            }
        }

        private void ReportError(object sender, ErrorEventArgs e) {
            if (OnError != null) {
                OnError(this, new FileErrorEventArgs(e, _lineMap));
            }
        }
    }
}
