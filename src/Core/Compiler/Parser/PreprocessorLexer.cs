// PreprocessorLexer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Text;

namespace ScriptSharp.Parser {

    internal sealed class PreprocessorLexer {

        private TextBuffer _text;
        private NameTable _nameTable;
        private PreprocessorKeywords _keywords;
        private StringBuilder _value;

        public PreprocessorLexer(NameTable symbolTable) {
            _value = new StringBuilder();
            _nameTable = symbolTable;
            _keywords = new PreprocessorKeywords(symbolTable);
        }

        public event ErrorEventHandler OnError;

        public PreprocessorToken NextToken(TextBuffer text) {
            _text = text;

            SkipWhiteSpace();
            BufferPosition position = text.Position;

            char ch = PeekChar();
            if (ch == '\0' || IsLineSeparator(ch)) {
                return NewPPToken(PreprocessorTokenType.EndOfLine, position);
            }

            ch = NextChar();
            switch (ch) {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9': {
                        int intValue = (ch - '0');
                        while (IsDigit(PeekChar())) {
                            int value10 = intValue * 10;
                            if (value10 < intValue) {
                                ReportError(LexError.NumericConstantOverflow);
                            }
                            else {
                                intValue = value10 + (NextChar() - '0');
                            }
                        }

                        return new PreprocessorIntToken(intValue, position);
                    }

                case '=':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewPPToken(PreprocessorTokenType.EqualEqual, position);
                    }
                    break;

                case '!':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewPPToken(PreprocessorTokenType.NotEqual, position);
                    }
                    else {
                        return NewPPToken(PreprocessorTokenType.Not, position);
                    }

                case '&':
                    if (PeekChar() == '&') {
                        NextChar();
                        return NewPPToken(PreprocessorTokenType.And, position);
                    }
                    break;

                case '|':
                    if (PeekChar() == '|') {
                        NextChar();
                        return NewPPToken(PreprocessorTokenType.Or, position);
                    }
                    break;

                case '(':
                    return NewPPToken(PreprocessorTokenType.OpenParen, position);

                case ')':
                    return NewPPToken(PreprocessorTokenType.CloseParen, position);

                case '"':
                    _value.Length = 0;
                    while ((ch = PeekChar()) != '"') {
                        if (EOF) {
                            ReportError(LexError.UnexpectedEndOfFileString);
                            break;
                        }
                        else if (IsLineSeparator(ch)) {
                            ReportError(LexError.WhiteSpaceInConstant);
                            break;
                        }
                        _value.Append(ch);
                        NextChar();
                    }
                    NextChar();
                    return new PreprocessorStringToken(_value.ToString(), position);

                case '/':
                    if (PeekChar() == '/') {
                        IgnoreRestOfLine();
                        return NewPPToken(PreprocessorTokenType.EndOfLine, position);
                    }
                    break;

                default:
                    if (IsLineSeparator(ch)) {
                        return NewPPToken(PreprocessorTokenType.EndOfLine, position);
                    }

                    if (!IsIdentifierChar(ch)) {
                        break;
                    }

                    _value.Length = 0;
                    _value.Append(ch);
                    while (IsIdentifierChar(PeekChar())) {
                        _value.Append(NextChar());
                    }
                    Name id = _nameTable.Add(_value);
                    PreprocessorTokenType type = _keywords.IsKeyword(id);
                    if (type != PreprocessorTokenType.Invalid) {
                        return NewPPToken(type, position);
                    }
                    else {
                        return new PreprocessorIdentifierToken(id, position);
                    }
            }

            return NewPPToken(PreprocessorTokenType.Unknown, position);
        }

        public void SkipWhiteSpace() {
            while (!EOF && IsWhiteSpace(PeekChar()) && !IsLineSeparator(PeekChar())) {
                NextChar();
            }
        }

        public string GetRestOfLine() {
            _value.Length = 0;

            while (!EOF && !IsLineSeparator(PeekChar())) {
                _value.Append(NextChar());
            }
            if (!EOF) {
                NextChar();
            }

            return _value.ToString();
        }

        public void IgnoreRestOfLine() {
            while (!EOF && !IsLineSeparator(NextChar())) {
            }
        }

        private PreprocessorToken NewPPToken(PreprocessorTokenType type, BufferPosition position) {
            return new PreprocessorToken(type, position);
        }

        private void ReportError(Error error, params object[] args) {
            if (OnError != null) {
                OnError(this, new ErrorEventArgs(error, _text.Position, args));
            }
        }

        public bool EOF {
            get {
                return PeekChar() == '\0';
            }
        }

        private bool IsLineSeparator(char ch) {
            return Lexer.IsLineSeparator(ch);
        }

        private bool IsWhiteSpace(char ch) {
            return Lexer.IsWhiteSpace(ch);
        }

        private bool IsDigit(char ch) {
            return Lexer.IsDigit(ch);
        }

        private bool IsIdentifierChar(char ch) {
            return Lexer.IsIdentifierChar(ch);
        }

        private char NextChar() {
            return _text.NextChar();
        }

        private char PeekChar() {
            return _text.PeekChar();
        }

        private char PeekChar(int index) {
            return _text.PeekChar(index);
        }
    }
}
