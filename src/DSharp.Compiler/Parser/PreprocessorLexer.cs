// PreprocessorLexer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Text;

namespace DSharp.Compiler.Parser
{
    internal sealed class PreprocessorLexer
    {
        private readonly PreprocessorKeywords keywords;
        private readonly NameTable nameTable;
        private readonly StringBuilder value;

        private TextBuffer text;

        public PreprocessorLexer(NameTable symbolTable)
        {
            value = new StringBuilder();
            nameTable = symbolTable;
            keywords = new PreprocessorKeywords(symbolTable);
        }

        public bool Eof => PeekChar() == '\0';

        public event ErrorEventHandler OnError;

        public PreprocessorToken NextToken(TextBuffer text)
        {
            this.text = text;

            SkipWhiteSpace();
            BufferPosition position = text.Position;

            char ch = PeekChar();

            if (ch == '\0' || IsLineSeparator(ch))
            {
                return NewPpToken(PreprocessorTokenType.EndOfLine, position);
            }

            ch = NextChar();

            switch (ch)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                {
                    int intValue = ch - '0';

                    while (IsDigit(PeekChar()))
                    {
                        int value10 = intValue * 10;

                        if (value10 < intValue)
                        {
                            ReportError(LexError.NumericConstantOverflow);
                        }
                        else
                        {
                            intValue = value10 + (NextChar() - '0');
                        }
                    }

                    return new PreprocessorIntToken(intValue, position);
                }

                case '=':

                    if (PeekChar() == '=')
                    {
                        NextChar();

                        return NewPpToken(PreprocessorTokenType.EqualEqual, position);
                    }

                    break;

                case '!':

                    if (PeekChar() == '=')
                    {
                        NextChar();

                        return NewPpToken(PreprocessorTokenType.NotEqual, position);
                    }
                    else
                    {
                        return NewPpToken(PreprocessorTokenType.Not, position);
                    }

                case '&':

                    if (PeekChar() == '&')
                    {
                        NextChar();

                        return NewPpToken(PreprocessorTokenType.And, position);
                    }

                    break;

                case '|':

                    if (PeekChar() == '|')
                    {
                        NextChar();

                        return NewPpToken(PreprocessorTokenType.Or, position);
                    }

                    break;

                case '(':

                    return NewPpToken(PreprocessorTokenType.OpenParen, position);

                case ')':

                    return NewPpToken(PreprocessorTokenType.CloseParen, position);

                case '"':
                    value.Length = 0;

                    while ((ch = PeekChar()) != '"')
                    {
                        if (Eof)
                        {
                            ReportError(LexError.UnexpectedEndOfFileString);

                            break;
                        }

                        if (IsLineSeparator(ch))
                        {
                            ReportError(LexError.WhiteSpaceInConstant);

                            break;
                        }

                        value.Append(ch);
                        NextChar();
                    }

                    NextChar();

                    return new PreprocessorStringToken(value.ToString(), position);

                case '/':

                    if (PeekChar() == '/')
                    {
                        IgnoreRestOfLine();

                        return NewPpToken(PreprocessorTokenType.EndOfLine, position);
                    }

                    break;

                default:

                    if (IsLineSeparator(ch))
                    {
                        return NewPpToken(PreprocessorTokenType.EndOfLine, position);
                    }

                    if (!IsIdentifierChar(ch))
                    {
                        break;
                    }

                    value.Length = 0;
                    value.Append(ch);
                    while (IsIdentifierChar(PeekChar())) value.Append(NextChar());
                    Name id = nameTable.Add(value);
                    PreprocessorTokenType type = keywords.IsKeyword(id);

                    if (type != PreprocessorTokenType.Invalid)
                    {
                        return NewPpToken(type, position);
                    }
                    else
                    {
                        return new PreprocessorIdentifierToken(id, position);
                    }
            }

            return NewPpToken(PreprocessorTokenType.Unknown, position);
        }

        public void SkipWhiteSpace()
        {
            while (!Eof && IsWhiteSpace(PeekChar()) && !IsLineSeparator(PeekChar())) NextChar();
        }

        public string GetRestOfLine()
        {
            value.Length = 0;

            while (!Eof && !IsLineSeparator(PeekChar())) value.Append(NextChar());

            if (!Eof)
            {
                NextChar();
            }

            return value.ToString();
        }

        public void IgnoreRestOfLine()
        {
            while (!Eof && !IsLineSeparator(NextChar()))
            {
            }
        }

        private PreprocessorToken NewPpToken(PreprocessorTokenType type, BufferPosition position)
        {
            return new PreprocessorToken(type, position);
        }

        private void ReportError(Error error, params object[] args)
        {
            if (OnError != null)
            {
                OnError(this, new ErrorEventArgs(error, text.Position, args));
            }
        }

        private bool IsLineSeparator(char ch)
        {
            return Lexer.IsLineSeparator(ch);
        }

        private bool IsWhiteSpace(char ch)
        {
            return Lexer.IsWhiteSpace(ch);
        }

        private bool IsDigit(char ch)
        {
            return Lexer.IsDigit(ch);
        }

        private bool IsIdentifierChar(char ch)
        {
            return Lexer.IsIdentifierChar(ch);
        }

        private char NextChar()
        {
            return text.NextChar();
        }

        private char PeekChar()
        {
            return text.PeekChar();
        }

        private char PeekChar(int index)
        {
            return text.PeekChar(index);
        }
    }
}