// Lexer.cs
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
    /// Lexes C# source code. Does not handle # preprocessor directives.
    /// </summary>
    internal sealed class Lexer {

        private TextBuffer _text;
        private string _path;
        private BufferPosition _position;
        private StringBuilder _value;
        private IList _tokenList;
        private int _lastLine;
        private NameTable _nameTable;
        private Keywords _keywords;
        private bool _includeComments;

        public Lexer(NameTable nameTable, string path) {
            _nameTable = nameTable;
            _path = path;
            _keywords = new Keywords(nameTable);
            _value = new StringBuilder(IdentifierToken.MaxIdentifierLength + 1);

            _lastLine = -1;
        }

        /// <summary>
        /// Lexes a block of C# text.
        /// Does not handle preprocessor directives.
        /// Will stop at EOF or before a # found as the first non-whitespace character
        /// on a line. Does not include comment tokens.
        /// </summary>
        /// <param name="text"> Buffer containing the text to lex. </param>
        /// <param name="tokenList"> List of tokens to add to. </param>
        /// <returns> true if a preprocessor directive was found, or false on end of buffer. </returns>
        public bool LexBlock(TextBuffer text, IList tokenList) {
            return LexBlock(text, tokenList, false);
        }

        /// <summary>
        /// Lexes a block of C# text.
        /// Does not handle preprocessor directives.
        /// Will stop at EOF or before a # found as the first non-whitespace character
        /// on a line. 
        /// </summary>
        /// <param name="text"> Buffer containing the text to lex. </param>
        /// <param name="tokenList"> List of tokens to add to. </param>
        /// <param name="includeComments"> Should comment tokens be generated. </param>
        /// <returns> true if a preprocessor directive was found, or false on end of buffer. </returns>
        public bool LexBlock(TextBuffer text, IList tokenList, bool includeComments) {
            Debug.Assert(_keywords != null);
            Debug.Assert(_nameTable != null);

            Debug.Assert(_text == null);
            Debug.Assert(_tokenList == null);
            Debug.Assert(_lastLine == -1);

            _text = text;
            _tokenList = tokenList;
            _lastLine = text.Line - 1;
            _includeComments = includeComments;

            // get the tokens
            Token next = null;
            do {
                next = NextToken();

                if (next == null) {
                    // pre-processor directive
                    break;
                }

                if (next.Type != TokenType.Error && next.Type != TokenType.EOF) {
                    tokenList.Add(next);
                }
            } while (next.Type != TokenType.EOF);

            _tokenList = null;
            _text = null;
            _lastLine = -1;
            _includeComments = false;
            ClearPosition();

            return next == null;
        }


        /// <summary>
        /// Event to subscribe to for Lex errors.
        /// </summary>
        public event ErrorEventHandler OnError;

        private static int IndexOfToken(Token[] tokens, Token token) {
            return Array.BinarySearch(tokens, token);
        }

        private Token NextToken() {
            SkipWhiteSpace();

            StartToken();

            bool atIdentifier = false;

            char ch = PeekChar();
            if (ch == '\0')
                return NewToken(TokenType.EOF);

            ch = NextChar();
            switch (ch) {
                case '\0':
                    Debug.Fail("Checked for EOF above");
                    return null;

                case '#':
                    if (_text.Line == _lastLine) {
                        ReportError(LexError.UnexpectedCharacter, ch.ToString());
                        return ErrorToken();
                    }
                    else {
                        ClearPosition();
                        _text.Reverse();
                        return null;
                    }

                // operators
                case '{': return NewToken(TokenType.OpenCurly);
                case '}': return NewToken(TokenType.CloseCurly);
                case '[': return NewToken(TokenType.OpenSquare);
                case ']': return NewToken(TokenType.CloseSquare);
                case '(': return NewToken(TokenType.OpenParen);
                case ')': return NewToken(TokenType.CloseParen);
                case ',': return NewToken(TokenType.Comma);
                case ':':
                    ch = PeekChar();
                    if (ch == ':') {
                        NextChar();
                        return NewToken(TokenType.ColonColon);
                    }
                    return NewToken(TokenType.Colon);

                case ';': return NewToken(TokenType.Semicolon);
                case '~': return NewToken(TokenType.Tilde);

                case '?':
                    ch = PeekChar();
                    if (ch == '?') {
                        NextChar();
                        return NewToken(TokenType.Coalesce);
                    }
                    return NewToken(TokenType.Question);

                case '+':
                    ch = PeekChar();
                    if (ch == '+') {
                        NextChar();
                        return NewToken(TokenType.PlusPlus);
                    }
                    else if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.PlusEqual);
                    }
                    return NewToken(TokenType.Plus);

                case '-':
                    ch = PeekChar();
                    if (ch == '-') {
                        NextChar();
                        return NewToken(TokenType.MinusMinus);
                    }
                    else if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.MinusEqual);
                    }
                    else if (ch == '>') {
                        NextChar();
                        return NewToken(TokenType.Arrow);
                    }
                    return NewToken(TokenType.Minus);

                case '*':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewToken(TokenType.StarEqual);
                    }
                    return NewToken(TokenType.Star);

                case '/':
                    ch = PeekChar();
                    if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.SlashEqual);
                    }
                    else if (ch == '/') {
                        NextChar();

                        CommentTokenType commentType;
                        if (!EOF && PeekChar() == '/') {
                            commentType = CommentTokenType.TripleSlash;
                            NextChar();
                        }
                        else {
                            commentType = CommentTokenType.DoubleSlash;
                        }

                        _value.Length = 0;
                        while (!EOF && !IsLineSeparator(PeekChar())) {
                            _value.Append(NextChar());
                        }

                        if (_includeComments) {
                            return new CommentToken(commentType, _value.ToString(), _path, TakePosition());
                        }
                        else {
                            TakePosition();
                            return NextToken();
                        }
                    }
                    else if (ch == '*') {
                        NextChar();

                        _value.Length = 0;
                        while (!EOF && (PeekChar() != '*' || PeekChar(1) != '/')) {
                            _value.Append(NextChar());
                        }
                        if (EOF) {
                            ReportError(LexError.UnexpectedEndOfFileStarSlash);
                            return ErrorToken();
                        }

                        NextChar();
                        NextChar();

                        _lastLine = _text.Line;

                        if (_includeComments) {
                            return new CommentToken(CommentTokenType.SlashStar, _value.ToString(), _path, TakePosition());
                        }
                        else {
                            TakePosition();
                            return NextToken();
                        }
                    }

                    return NewToken(TokenType.Slash);

                case '%':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewToken(TokenType.PercentEqual);
                    }
                    return NewToken(TokenType.Percent);

                case '&':
                    ch = PeekChar();
                    if (ch == '&') {
                        NextChar();
                        return NewToken(TokenType.LogAnd);
                    }
                    else if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.AndEqual);
                    }
                    return NewToken(TokenType.Ampersand);

                case '|':
                    ch = PeekChar();
                    if (ch == '|') {
                        NextChar();
                        return NewToken(TokenType.LogOr);
                    }
                    else if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.BarEqual);
                    }
                    return NewToken(TokenType.Bar);

                case '^':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewToken(TokenType.HatEqual);
                    }
                    return NewToken(TokenType.Hat);

                case '!':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewToken(TokenType.NotEqual);
                    }
                    return NewToken(TokenType.Bang);

                case '=':
                    if (PeekChar() == '=') {
                        NextChar();
                        return NewToken(TokenType.EqualEqual);
                    }
                    return NewToken(TokenType.Equal);

                case '<':
                    ch = PeekChar();
                    if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.LessEqual);
                    }
                    else if (ch == '<') {
                        NextChar();
                        if (PeekChar() == '=') {
                            NextChar();
                            return NewToken(TokenType.ShiftLeftEqual);
                        }
                        return NewToken(TokenType.ShiftLeft);
                    }
                    return NewToken(TokenType.Less);

                case '>':
                    ch = PeekChar();
                    if (ch == '=') {
                        NextChar();
                        return NewToken(TokenType.GreaterEqual);
                    }
                    return NewToken(TokenType.Greater);

                // literals
                case '\'':
                    // char literal
                    {
                        char ch2;
                        if (ScanCharValue('\'', false, out ch, out ch2)) {
                            if (PeekChar() != '\'') {
                                ReportError(LexError.BadCharConstant);
                            }
                            else {
                                NextChar();
                            }
                            return new CharToken(ch, _path, TakePosition());
                        }
                        else {
                            return ErrorToken();
                        }
                    }

                case '"':
                    // string literal
                    {
                        char ch2;
                        _value.Length = 0;
                        while (!EOF && ScanCharValue('"', true, out ch, out ch2)) {
                            _value.Append(ch);
                            if (ch2 != 0)
                                _value.Append(ch2);
                        }
                        if (EOF) {
                            ReportError(LexError.UnexpectedEndOfFileString);
                            return ErrorToken();
                        }
                        return new StringToken(_value.ToString(), _path, TakePosition());
                    }

                case '@':
                    ch = PeekChar();
                    if (ch == '"') {
                        // verbatim string literal
                        NextChar();
                        _value.Length = 0;
                        while (!EOF && (PeekChar() != '"' || PeekChar(1) == '"')) {
                            // this is the one place where a CR/LF pair is significant
                            bool wasCRLF;
                            ch = NextChar(out wasCRLF);
                            _value.Append(ch);
                            if (wasCRLF) {
                                _value.Append('\xA');
                            }
                            else if (ch == '"') {
                                NextChar();
                            }
                        }
                        if (EOF) {
                            ReportError(LexError.UnexpectedEndOfFileString);
                            return ErrorToken();
                        }
                        NextChar();
                        return new StringToken(_value.ToString(), _path, TakePosition());
                    }
                    atIdentifier = true;
                    goto default;

                case '0':
                    if (PeekChar() == 'x' || PeekChar() == 'X') {
                        NextChar();

                        // hexadecimal constant
                        ulong value = 0;
                        while (IsHexDigit(PeekChar())) {
                            if ((value & 0xF000000000000000) != 0) {
                                ReportError(LexError.NumericConstantOverflow);
                                return ErrorToken();
                            }
                            value = (value << 4) | (uint)HexValue(NextChar());
                        }

                        return CreateIntegerConstant(value, ScanIntegerSuffixOpt());
                    }
                    goto case '1';

                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                DoNumber: {
                        bool foundDecimalPoint = (ch == '.');
                        bool foundExponent = false;
                        NumericSuffix suffix = NumericSuffix.None;

                        _value.Length = 0;
                        _value.Append(ch);
                        while (true) {
                            ch = PeekChar();
                            if (ch == '.') {
                                if (foundDecimalPoint || !IsDigit(PeekChar(1))) {
                                    break;
                                }
                                foundDecimalPoint = true;
                            }
                            else if (ch == 'e' || ch == 'E') {
                                char nextChar = PeekChar(1);
                                if (IsDigit(nextChar) || ((nextChar == '+' || nextChar == '-') && IsDigit(PeekChar(2)))) {
                                    foundExponent = true;

                                    _value.Append(NextChar());
                                    _value.Append(NextChar());
                                    while (IsDigit(PeekChar())) {
                                        _value.Append(NextChar());
                                    }
                                }
                                break;
                            }
                            else if (!IsDigit(ch)) {
                                break;
                            }
                            _value.Append(NextChar());
                        }

                        if (!foundDecimalPoint && !foundExponent) {
                            suffix = ScanIntegerSuffixOpt();
                        }

                        if (suffix == NumericSuffix.None) {
                            suffix = ScanRealSuffixOpt();
                        }

                        if (suffix < NumericSuffix.F && !foundDecimalPoint && !foundExponent) {
                            // decimal integer constant
                            ulong numericValue = 0;
                            foreach (char digit in _value.ToString().ToCharArray()) {
                                ulong value10 = numericValue * 10;
                                if (value10 < numericValue) {
                                    ReportError(LexError.NumericConstantOverflow);
                                    return ErrorToken();
                                }
                                numericValue = value10 + (uint)(digit - '0');
                            }

                            return CreateIntegerConstant(numericValue, suffix);
                        }
                        else {
                            try {
                                // real constant
                                switch (suffix) {
                                    case NumericSuffix.F: {
                                            float f = float.Parse(_value.ToString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
                                            return new FloatToken(f, _path, TakePosition());
                                        }

                                    case NumericSuffix.D:
                                    case NumericSuffix.None: {
                                            double d = double.Parse(_value.ToString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
                                            return new DoubleToken(d, _path, TakePosition());
                                        }

                                    case NumericSuffix.M: {
                                            decimal dec = decimal.Parse(_value.ToString(), NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent, CultureInfo.InvariantCulture);
                                            return new DecimalToken(dec, _path, TakePosition());
                                        }
                                }
                            }
                            catch (Exception) {
                                // catch overflow exceptions from the numeric parse
                            }
                            ReportError(LexError.NumericConstantOverflow);
                            return ErrorToken();
                        }
                    }

                case '.':
                    if (IsDigit(PeekChar())) {
                        goto DoNumber;
                    }
                    return NewToken(TokenType.Dot);

                default: {
                        _value.Length = 0;
                        if (!IsIdentifierChar(ch)) {
                            ReportError(LexError.UnexpectedCharacter, ch.ToString());
                            return ErrorToken();
                        }
                        _value.Append(ch);

                        while (ScanIdentifierChar(out ch)) {
                            _value.Append(ch);
                        }

                        Debug.Assert(_value.Length > 0);

                        if (_value.Length > IdentifierToken.MaxIdentifierLength) {
                            ReportError(LexError.IdentifierTooLong);
                            return ErrorToken();
                        }

                        Name name = _nameTable.Add(_value);
                        if (!atIdentifier) {
                            // check for keywords
                            TokenType keyword = _keywords.IsKeyword(name);
                            if (Token.IsKeyword(keyword)) {
                                return new Token(keyword, _path, TakePosition());
                            }
                        }

                        return new IdentifierToken(name, atIdentifier, _path, TakePosition());
                    }
            }
        }

        private void SkipWhiteSpace() {
            while (IsWhiteSpace(PeekChar())) {
                NextChar();
            }
        }

        private enum NumericSuffix {
            None,

            // integer suffixes
            U = 0x01,
            L = 0x10,
            UL = 0x11,

            // floating point suffixes
            F,
            D,
            M
        }

        private Token CreateIntegerConstant(ulong value, NumericSuffix suffix) {
            switch (suffix) {
                case NumericSuffix.None:
                    if (value <= int.MaxValue) {
                        return new IntToken((int)value, _path, TakePosition());
                    }
                    else if (value <= uint.MaxValue) {
                        return new UIntToken((uint)value, _path, TakePosition());
                    }
                    else if (value <= long.MaxValue) {
                        return new LongToken((long)value, _path, TakePosition());
                    }
                    goto case NumericSuffix.UL;
                case NumericSuffix.U:
                    if (value <= uint.MaxValue) {
                        return new UIntToken((uint)value, _path, TakePosition());
                    }
                    goto case NumericSuffix.UL;
                case NumericSuffix.L:
                    if (value <= long.MaxValue) {
                        return new LongToken((long)value, _path, TakePosition());
                    }
                    goto case NumericSuffix.UL;
                case NumericSuffix.UL:
                default:
                    return new ULongToken(value, _path, TakePosition());
            }
        }

        private NumericSuffix ScanIntegerSuffixOpt() {
            NumericSuffix suffix = NumericSuffix.None;

            while (true) {
                char ch = PeekChar();
                if (ch == 'U' || ch == 'u') {
                    if ((suffix & NumericSuffix.U) != 0) {
                        break;
                    }
                    suffix |= NumericSuffix.U;
                }
                else if (ch == 'l' || ch == 'L') {
                    if ((suffix & NumericSuffix.L) != 0) {
                        break;
                    }
                    suffix |= NumericSuffix.L;
                }
                else {
                    break;
                }
                NextChar();
            }

            return suffix;
        }

        private NumericSuffix ScanRealSuffixOpt() {
            NumericSuffix suffix = NumericSuffix.None;

            switch (PeekChar()) {
                case 'F':
                case 'f':
                    suffix = NumericSuffix.F;
                    break;

                case 'D':
                case 'd':
                    suffix = NumericSuffix.D;
                    break;

                case 'M':
                case 'm':
                    suffix = NumericSuffix.M;
                    break;

                default:
                    return NumericSuffix.None;
            }

            NextChar();

            return suffix;
        }

        private bool ScanIdentifierChar(out char ch) {
            ch = '\0';

            char value = PeekChar();
            if (IsIdentifierChar(value)) {
                ch = NextChar();
                return true;
            }
            else if (value == '\\' && PeekChar(1) == 'u') {
                // unicode esape
                NextChar();
                NextChar();
                value = '\0';
                int i = 0;
                while (i < 4 && IsHexDigit(PeekChar())) {
                    value = (char)(value << 4 + HexValue(NextChar()));
                    i += 1;
                }
                if (i != 4) {
                    ReportError(LexError.BadEscapeSequence);
                    return false;
                }
                ch = value;
                return true;
            }
            else {
                return false;
            }
        }

        private bool ScanCharValue(char terminator, bool allowSurrogates, out char ch, out char ch2) {
            ch = '\0';
            ch2 = '\0';
            char value = PeekChar();
            if ('\\' == value) {
                NextChar();
                switch (PeekChar()) {
                    case '\'': value = '\''; break;
                    case '\"': value = '\"'; break;
                    case '\\': value = '\\'; break;
                    case '0': value = '\0'; break;
                    case 'a': value = '\a'; break;
                    case 'b': value = '\b'; break;
                    case 'f': value = '\f'; break;
                    case 'n': value = '\n'; break;
                    case 'r': value = '\r'; break;
                    case 't': value = '\t'; break;
                    case 'v': value = '\v'; break;
                    case 'x':
                    case 'u': {
                            // hex digits
                            NextChar();
                            value = '\0';
                            int i = 0;
                            while (i < 4 && IsHexDigit(PeekChar())) {

                                value = (char)((value << 4) + HexValue(NextChar()));
                                i += 1;
                            }
                            if (i == 0 || (ch == 'u' && i != 4)) {
                                ReportError(LexError.BadEscapeSequence);
                                return false;
                            }
                            ch = value;
                            return true;
                        }

                    case 'U': {
                            // unicode surrogates
                            NextChar();
                            uint surrogateValue = 0;
                            int i = 0;
                            while (i < 8 && IsHexDigit(PeekChar())) {

                                surrogateValue = (char)((surrogateValue << 4) + HexValue(NextChar()));
                                i += 1;
                            }
                            if (i != 8 || (!allowSurrogates && surrogateValue > 0xFFFF) || surrogateValue > 0x10FFFF) {
                                ReportError(LexError.BadEscapeSequence);
                                return false;
                            }
                            if (surrogateValue < 0x10000) {
                                ch = (char)surrogateValue;
                                return true;
                            }

                            ch = (char)((surrogateValue - 0x10000) / 0x400 + 0xD800);
                            ch2 = (char)((surrogateValue - 0x10000) % 0x400 + 0xDC00);

                            return true;
                        }

                    default:
                        ReportError(LexError.BadEscapeSequence);
                        return false;
                }
                NextChar();
                ch = value;
                return true;
            }
            else if (value == terminator) {
                NextChar();
                if (terminator == '\'') {
                    ReportError(LexError.EmptyCharConstant);
                }

                return false;
            }
            else if (IsLineSeparator(value)) {
                ReportError(LexError.WhiteSpaceInConstant);
                return false;
            }
            else {
                NextChar();
                ch = value;
                return true;
            }
        }

        private void ReportSyntaxError() {
            ReportError(LexError.SyntaxError);
        }

        private void ReportError(Error error, params object[] args) {
            if (OnError != null) {
                OnError(this, new ErrorEventArgs(error, _text.Position, args));
            }
        }

        /// <summary>
        /// Tests if ch is a whitespace character
        /// </summary>
        public static bool IsWhiteSpace(char ch) {
            switch (ch) {
                // line separators are whitespace
                case '\xD':
                case '\xA':
                case '\x2028':
                case '\x2029':

                // regular whitespace
                case '\f':
                case '\v':
                case ' ':
                case '\t':
                    return true;

                // handle odd unicode whitespace
                default:
                    return (ch > 127 && char.IsWhiteSpace(ch));
            }
        }

        /// <summary>
        /// Tests if ch is a line separator character.
        /// </summary>
        public static bool IsLineSeparator(char ch) {
            switch (ch) {
                case '\xD':
                case '\xA':
                case '\x2028':
                case '\x2029':
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Tests if ch is a decimal digit.
        /// </summary>
        public static bool IsDigit(char ch) {
            return (ch >= '0') && (ch <= '9');
        }

        /// <summary>
        /// Tests if ch is any valid identifier character.
        /// </summary>
        public static bool IsIdentifierChar(char ch) {
            return char.IsLetterOrDigit(ch) || (ch == '_');
        }

        /// <summary>
        /// Tests if ch is a valid hexadecimal digit.
        /// </summary>
        public static bool IsHexDigit(char ch) {
            return IsDigit(ch) || ((ch & 0xdf) >= 'A' && (ch & 0xdf) <= 'F');
        }

        private static int HexValue(char ch) {
            return IsDigit(ch) ? ch - '0' : (ch & 0xdf) - 'A' + 10;
        }

        private Token ErrorToken() {
            return NewToken(TokenType.Error);
        }

        private Token NewToken(TokenType type) {
            return new Token(type, _path, TakePosition());
        }

        private BufferPosition TakePosition() {
            _lastLine = _text.Line;
            BufferPosition position = _position;
            ClearPosition();
            return position;
        }

        private void ClearPosition() {
            _position = new BufferPosition();
        }

        private void StartToken() {
            _position = _text.Position;
        }

        private char NextChar() {
            return _text.NextChar();
        }

        private char NextChar(out bool wasCRLF) {
            return _text.NextChar(out wasCRLF);
        }

        private char PeekChar() {
            return PeekChar(0);
        }

        private char PeekChar(int index) {
            return _text.PeekChar(index);
        }

        private bool EOF {
            get {
                return PeekChar() == '\0';
            }
        }
    }
}
