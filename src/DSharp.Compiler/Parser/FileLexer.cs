// FileLexer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Diagnostics;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     Preprocesses and Lexes a C# compilation Unit.
    /// </summary>
    internal sealed class FileLexer : IFilePathProvider
    {
        private readonly Lexer lexer;
        private readonly PreprocessorLineParser parser;
        private IDictionary defines;
        private bool includeComments;
        private LineMap lineMap;

        private TextBuffer text;
        private ArrayList tokens;

        public string FilePath { get; }

        public FileLexer(NameTable nameTable, string filePath)
        {
            lexer = new Lexer(nameTable, filePath);
            lexer.OnError += ReportError;
            parser = new PreprocessorLineParser(nameTable);
            parser.OnError += ReportError;

            this.FilePath = filePath;
        }

        /// <summary>
        ///     Lexes a compilation unit.
        /// </summary>
        /// <param name="text"> The text to lex. </param>
        /// <param name="defines">
        ///     The set of preprocessor symbols defined in source.
        ///     Is modified to include results of #define/#undef found in this compilation unit.
        /// </param>
        /// <param name="lineMap">
        ///     The LineMap contains the source text to file/line mapping
        ///     as a result of #line directives.
        /// </param>
        /// <param name="includeComments"> Should comment tokens be generated. </param>
        /// <returns></returns>
        public Token[] Lex(char[] text, IDictionary defines, LineMap lineMap, bool includeComments)
        {
            // initialize
            this.text = new TextBuffer(text);
            this.defines = defines;
            this.lineMap = lineMap;
            this.includeComments = includeComments;

            LexFile();

            this.text = null;
            this.defines = null;
            this.lineMap = null;
            this.includeComments = false;

            return (Token[]) tokens.ToArray(typeof(Token));
        }

        public event FileErrorEventHandler OnError;

        /// <summary>
        ///     Returns whether a character is a C# line separator.
        /// </summary>
        public static bool IsLineSeparator(char ch)
        {
            return Lexer.IsLineSeparator(ch);
        }

        private void LexFile()
        {
            tokens = new ArrayList(text.Length / 8);
            tokens.Add(new Token(TokenType.Bof, FilePath, text.Position));

            PreprocessorLine line;

            do
            {
                line = LexBlock();

                if (line.Type != PreprocessorTokenType.EndOfLine)
                {
                    ReportError(PreprocessorError.UnexpectedDirective);
                }
            } while (line.Type != PreprocessorTokenType.EndOfLine);

            if (TokenType.Eof != ((Token) tokens[tokens.Count - 1]).Type)
            {
                tokens.Add(new Token(TokenType.Eof, FilePath, text.Position));
            }
        }

        private PreprocessorLine LexBlock()
        {
            while (lexer.LexBlock(text, tokens, includeComments))
            {
                PreprocessorLine line = parser.Parse(text, defines);

                if (line != null)
                {
                    DoLine:

                    switch (line.Type)
                    {
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

                            if (line.Type == PreprocessorTokenType.EndRegion)
                            {
                                break;
                            }
                            else
                            {
                                ReportError(PreprocessorError.EndRegionExpected);

                                goto DoLine;
                            }

                        case PreprocessorTokenType.If:
                            line = DoIf((PreprocessorIfLine) line);

                            if (line != null)
                            {
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

        private void DoSimpleLine(PreprocessorLine line)
        {
            switch (line.Type)
            {
                case PreprocessorTokenType.Define:
                case PreprocessorTokenType.Undef:

                    if (FoundNonComment())
                    {
                        // have more than BOF
                        ReportError(PreprocessorError.DefineAfterToken);
                    }
                    else
                    {
                        PreprocessorDeclarationLine decl = (PreprocessorDeclarationLine) line;

                        if (decl.Type == PreprocessorTokenType.Define)
                        {
                            defines.Add(decl.Identifier.Text, null);
                        }
                        else
                        {
                            defines.Remove(decl.Identifier.Text);
                        }
                    }

                    break;

                case PreprocessorTokenType.Warning:
                    ReportFormattedError(PreprocessorError.PpWarning, ((PreprocessorControlLine) line).Message);

                    break;

                case PreprocessorTokenType.Error:
                    ReportFormattedError(PreprocessorError.PpError, ((PreprocessorControlLine) line).Message);

                    break;

                case PreprocessorTokenType.Line:
                {
                    PreprocessorLineNumberLine lineNumber = (PreprocessorLineNumberLine) line;

                    if (lineNumber.File != null)
                    {
                        lineMap.AddEntry(text.Line, lineNumber.Line, lineNumber.File);
                    }
                    else
                    {
                        lineMap.AddEntry(text.Line, lineNumber.Line);
                    }
                }

                    break;
                case PreprocessorTokenType.Default:
                    lineMap.AddEntry(text.Line, text.Line, lineMap.FileName);

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

        private PreprocessorLine SkipBlock()
        {
            PreprocessorLine line;

            do
            {
                line = parser.ParseNextLine(text, defines);
                DoLine:

                switch (line.Type)
                {
                    case PreprocessorTokenType.Define:
                    case PreprocessorTokenType.Undef:
                    case PreprocessorTokenType.Warning:
                    case PreprocessorTokenType.Error:
                    case PreprocessorTokenType.Line:
                        line = null;

                        break;

                    case PreprocessorTokenType.Region:
                        line = SkipBlock();

                        if (line.Type != PreprocessorTokenType.EndRegion)
                        {
                            ReportError(PreprocessorError.EndRegionExpected);

                            goto DoLine;
                        }
                        else
                        {
                            line = null;

                            break;
                        }

                    case PreprocessorTokenType.If:
                        line = SkipElifBlock();

                        if (line != null)
                        {
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

        private PreprocessorLine DoIf(PreprocessorIfLine ifLine)
        {
            PreprocessorLine line;

            if (ifLine.Value)
            {
                line = LexBlock();

                switch (line.Type)
                {
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
            else
            {
                line = SkipBlock();

                switch (line.Type)
                {
                    case PreprocessorTokenType.Else:
                        line = DoElse();

                        break;

                    case PreprocessorTokenType.Elif:

                        return DoIf((PreprocessorIfLine) line);

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

        private PreprocessorLine DoElse()
        {
            PreprocessorLine line = LexBlock();

            if (line.Type == PreprocessorTokenType.Endif)
            {
                line = null;
            }
            else
            {
                ReportError(PreprocessorError.PpEndifExpected);
            }

            return line;
        }

        private PreprocessorLine SkipElseBlock()
        {
            PreprocessorLine line = SkipBlock();

            if (line.Type == PreprocessorTokenType.Endif)
            {
                line = null;
            }
            else
            {
                ReportError(PreprocessorError.PpEndifExpected);
            }

            return line;
        }

        private PreprocessorLine SkipElifBlock()
        {
            PreprocessorLine line = SkipBlock();

            if (line.Type == PreprocessorTokenType.Endif)
            {
                line = null;
            }
            else if (line.Type == PreprocessorTokenType.Else)
            {
                line = SkipElseBlock();
            }
            else if (line.Type == PreprocessorTokenType.Elif)
            {
                line = SkipElifBlock();
            }
            else
            {
                ReportError(PreprocessorError.PpEndifExpected);
            }

            return line;
        }

        private bool FoundNonComment()
        {
            // first token is BOF
            for (int i = 1; i < tokens.Count; i += 1)
                if (((Token) tokens[i]).Type != TokenType.Comment)
                {
                    return true;
                }

            return false;
        }

        private void ReportFormattedError(Error error, params object[] args)
        {
            BufferPosition position = text.Position;
            position.Line -= 1;
            ReportError(error, position, args);
        }

        private void ReportError(Error error)
        {
            BufferPosition position = text.Position;
            position.Line -= 1;
            ReportError(error, position);
        }

        private void ReportError(Error error, BufferPosition position, params object[] args)
        {
            if (OnError != null)
            {
                OnError(this, new FileLexerErrorEventArgs(error, lineMap.Map(position), args));
            }
        }

        private void ReportError(object sender, ErrorEventArgs e)
        {
            if (OnError != null)
            {
                OnError(this, new FileLexerErrorEventArgs(e, lineMap));
            }
        }
    }

    internal interface IFilePathProvider
    {
        string FilePath { get; }
    }
}
