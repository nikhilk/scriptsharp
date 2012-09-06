// PreprocessorLineParser.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;

namespace ScriptSharp.Parser {

    internal sealed class PreprocessorLineParser {

        private PreprocessorLexer lexer;
        private TextBuffer text;
        private IDictionary defines;
        private PreprocessorToken token;

        public PreprocessorLineParser(NameTable symbolTable) {
            lexer = new PreprocessorLexer(symbolTable);
            lexer.OnError += new ErrorEventHandler(this.ReportError);
        }

        public event ErrorEventHandler OnError;

        public PreprocessorLine ParseNextLine(TextBuffer text, IDictionary defines) {
            PreprocessorLine line = null;

            do {
                lexer.SkipWhiteSpace();
                if (lexer.EOF) {
                    line = new PreprocessorLine(PreprocessorTokenType.EndOfLine);
                }
                else if (text.PeekChar() != '#') {
                    lexer.IgnoreRestOfLine();
                }
                else {
                    line = Parse(text, defines);
                }
            } while (line == null);

            return line;
        }

        public PreprocessorLine Parse(TextBuffer text, IDictionary defines) {
            this.text = text;
            this.defines = defines;

            Debug.Assert(text.PeekChar() == '#');
            text.NextChar();

            PreprocessorToken token = NextToken();
            PreprocessorTokenType type = token.Type;
            switch (type) {
                case PreprocessorTokenType.Define:
                case PreprocessorTokenType.Undef:
                    token = Eat(PreprocessorTokenType.Identifier);
                    EatEndOfLine();
                    if (token != null) {
                        return new PreprocessorDeclarationLine(type, ((PreprocessorIdentifierToken)token).Value);
                    }
                    else {
                        return null;
                    }

                case PreprocessorTokenType.Warning:
                case PreprocessorTokenType.Error:
                    return new PreprocessorControlLine(type, lexer.GetRestOfLine());

                case PreprocessorTokenType.Line:
                    // hidden, default
                    type = PeekType();
                    if (type == PreprocessorTokenType.Default || type == PreprocessorTokenType.Hidden) {
                        NextToken();
                        EatEndOfLine();
                        return new PreprocessorLine(type);
                    }

                    token = Eat(PreprocessorTokenType.Int);
                    if (token != null) {
                        int line = ((PreprocessorIntToken)token).Value;
                        string file = null;
                        if (PeekType() == PreprocessorTokenType.String) {
                            file = ((PreprocessorStringToken)NextToken()).Value;
                        }
                        EatEndOfLine();

                        return new PreprocessorLineNumberLine(line, file);
                    }
                    else {
                        lexer.IgnoreRestOfLine();
                        return null;
                    }

                case PreprocessorTokenType.If:
                case PreprocessorTokenType.Elif:
                    return new PreprocessorIfLine(type, EvalExpression());

                case PreprocessorTokenType.Else:
                case PreprocessorTokenType.Endif:
                    return new PreprocessorLine(type);

                case PreprocessorTokenType.Region:
                case PreprocessorTokenType.EndRegion:
                    lexer.IgnoreRestOfLine();
                    return new PreprocessorLine(type);

                case PreprocessorTokenType.Pragma:
                    lexer.IgnoreRestOfLine();
                    return new PreprocessorLine(type);
                default:
                    ReportError(PreprocessorError.UnexpectedDirective, token.Position);
                    return null;
            }
        }

        private bool EvalExpression() {
            bool value = EvalEqualsExpression();
            EatEndOfLine();
            return value;
        }

        private bool EvalEqualsExpression() {
            bool value = EvalOrExpression();
            PreprocessorTokenType type = PeekType();
            while (type == PreprocessorTokenType.EqualEqual || type == PreprocessorTokenType.NotEqual) {
                NextToken();
                value = (value == EvalOrExpression());
                if (type == PreprocessorTokenType.NotEqual) {
                    value = !value;
                }
            }
            return value;
        }

        private bool EvalOrExpression() {
            bool value = EvalAndExpression();
            while (PeekType() == PreprocessorTokenType.Or) {
                NextToken();
                bool rightValue = EvalAndExpression();
                value = (value || rightValue);
            }
            return value;
        }

        private bool EvalAndExpression() {
            bool value = EvalUnaryExpression();
            while (PeekType() == PreprocessorTokenType.And) {
                NextToken();
                bool rightValue = EvalUnaryExpression();
                value = (value && rightValue);
            }
            return value;
        }

        private bool EvalUnaryExpression() {
            if (PeekType() == PreprocessorTokenType.Not) {
                NextToken();
                return !EvalUnaryExpression();
            }
            else {
                return EvalPrimaryExpression();
            }
        }

        private bool EvalPrimaryExpression() {
            bool value;
            switch (PeekType()) {
                case PreprocessorTokenType.OpenParen:
                    NextToken();
                    value = EvalEqualsExpression();
                    Eat(PreprocessorTokenType.CloseParen);
                    break;

                case PreprocessorTokenType.True:
                    value = true;
                    NextToken();
                    break;

                case PreprocessorTokenType.False:
                    value = false;
                    NextToken();
                    break;

                case PreprocessorTokenType.Identifier:
                    value = this.defines.Contains(((PreprocessorIdentifierToken)NextToken()).Value.Text);
                    break;

                case PreprocessorTokenType.CloseParen:
                case PreprocessorTokenType.EndOfLine:
                default:
                    ReportError(PreprocessorError.MisingPPExpression);
                    value = true;
                    break;
            }
            return value;
        }

        private void EatEndOfLine() {
            if (Eat(PreprocessorTokenType.EndOfLine) == null) {
                lexer.IgnoreRestOfLine();
            }
        }

        private PreprocessorTokenType PeekType() {
            if (token == null) {
                token = NextToken();
            }
            return token.Type;
        }

        private PreprocessorToken NextToken() {
            if (this.token == null) {
                return lexer.NextToken(text);
            }
            else {
                PreprocessorToken token = this.token;
                this.token = null;
                return token;
            }
        }

        private PreprocessorToken Eat(PreprocessorTokenType type) {
            if (PeekType() != type) {
                ReportFormattedError(PreprocessorError.TokenExpected, PreprocessorToken.TypeString(type));
                return null;
            }
            return NextToken();
        }

        private void ReportError(Error error) {
            ReportError(error, token.Position);
        }

        private void ReportFormattedError(Error error, params object[] args) {
            ReportError(error, token.Position, args);
        }

        private void ReportError(Error error, BufferPosition position, params object[] args) {
            if (OnError != null) {
                OnError(this, new ErrorEventArgs(error, position, args));
            }
        }

        private void ReportError(object sender, ErrorEventArgs e) {
            if (OnError != null) {
                OnError(this, e);
            }
        }
    }
}
