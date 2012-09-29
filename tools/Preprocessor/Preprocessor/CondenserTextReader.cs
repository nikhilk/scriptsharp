// CondenserTextReader.cs
// Script#/Tools/Preprocessor
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.IO;

namespace ScriptSharp.Preprocessor {

    internal sealed class CondenserTextReader : TextReader {

        private PreprocessorTextReader _sourceTextReader;
        private bool _stripCommentsOnly;

        private int _peekedCharacter;
        private int _lastCharacter;

        private bool _inDoubleQuotedString;
        private bool _inSingleQuotedString;
        private bool _inStringEscape;
        private bool _inRegex;
        private bool _inRegexEscape;
        private bool _inSignificantComment;
        private bool _inSignificantCommentStart;

        public CondenserTextReader(PreprocessorTextReader sourceTextReader, bool stripCommentsOnly) {
            Debug.Assert(sourceTextReader != null);
            _sourceTextReader = sourceTextReader;
            _stripCommentsOnly = stripCommentsOnly;

            _peekedCharacter = -1;
            _lastCharacter = ' ';
        }

        private int GetNextCharacter() {
            int ch = -1;

            while (ch == -1) {
                ch = _sourceTextReader.Read();

                if (ch == -1) {
                    break;
                }

                if (_inStringEscape) {
                    _inStringEscape = false;
                }
                else if (_inRegexEscape) {
                    _inRegexEscape = false;
                }
                else if (_inDoubleQuotedString) {
                    if (ch == '"') {
                        _inDoubleQuotedString = false;
                    }
                    else if (ch == '\\') {
                        _inStringEscape = true;
                    }
                }
                else if (_inSingleQuotedString) {
                    if (ch == '\'') {
                        _inSingleQuotedString = false;
                    }
                    else if (ch == '\\') {
                        _inStringEscape = true;
                    }
                }
                else if (_inRegex) {
                    if (ch == '/') {
                        _inRegex = false;
                    }
                    else if (ch == '\\') {
                        _inRegexEscape = true;
                    }
                }
                else if (_inSignificantComment) {
                    if (_inSignificantCommentStart) {
                        Debug.Assert(ch == '!');
                        ch = '/';

                        _inSignificantCommentStart = false;
                    }
                    if (ch == '\n') {
                        _inSignificantComment = false;
                    }
                }
                else {
                    if ((_stripCommentsOnly == false) && ((ch == ' ') || (ch == '\t') || (ch == '\n'))) {
                        if (ch == '\t') {
                            ch = ' ';
                        }
                        if ((_lastCharacter == ' ') || (_lastCharacter == '\n') ||
                            (IsSpaceSignificantAfter(_lastCharacter) == false) ||
                            (IsSpaceSignificantBefore(_sourceTextReader.Peek()) == false)) {
                            ch = -1;
                        }
                    }
                    else if (ch == '\'') {
                        _inSingleQuotedString = true;
                    }
                    else if (ch == '"') {
                        _inDoubleQuotedString = true;
                    }
                    else if (ch == '/') {
                        int nextChar = _sourceTextReader.Peek();
                        if (nextChar == '/') {
                            // Process single line comment to strip it out, unless the
                            // comment is significant, i.e., //!

                            // First consume the peeked '/', and then read until we see a new line
                            // or end of input itself.
                            _sourceTextReader.Read();

                            nextChar = _sourceTextReader.Peek();
                            if (nextChar == '!') {
                                _inSignificantComment = true;
                                _inSignificantCommentStart = true;
                            }
                            else {
                                for (; ; ) {
                                    ch = _sourceTextReader.Read();
                                    if ((ch == '\n') || (ch == -1)) {
                                        ch = -1;
                                        break;
                                    }
                                }
                            }
                        }
                        else if (nextChar == '*') {
                            // Process multiline comment to strip it out.

                            // First consume the peeked '*', and then read until we see the
                            // */ comment terminator.
                            _sourceTextReader.Read();
                            for (; ; ) {
                                ch = _sourceTextReader.Read();
                                if (ch == '*') {
                                    if (_sourceTextReader.Peek() == '/') {
                                        _sourceTextReader.Read();

                                        ch = -1;
                                        break;
                                    }
                                }
                                else if (ch == -1) {
                                    RaiseError("Unterminated multiline comment.");
                                }
                            }
                        }
                        else {
                            if ((_lastCharacter == '=') || (_lastCharacter == ':') ||
                                (_lastCharacter == '(') || (_lastCharacter == ',')) {
                                _inRegex = true;
                            }
                        }
                    }
                }
            }

            return ch;
        }

        private bool IsIdentifierCharacter(int ch) {
            return ((ch == '_') || (ch == '$') || (ch > 127) ||
                    ((ch >= 'a') && (ch <= 'z')) ||
                    ((ch >= 'A') && (ch <= 'Z')) ||
                    ((ch >= '0') && (ch <= '9')));
        }

        private bool IsSpaceSignificantAfter(int ch) {
            return IsIdentifierCharacter(ch) || (ch == '\\') || (ch == '}');
        }

        private bool IsSpaceSignificantBefore(int ch) {
            return IsIdentifierCharacter(ch);
        }

        public override int Peek() {
            if (_peekedCharacter == -1) {
                _peekedCharacter = GetNextCharacter();
            }

            return _peekedCharacter;
        }

        private void RaiseError(string errorMessage) {
            throw new PreprocessorException(errorMessage, _sourceTextReader.CurrentLine, _sourceTextReader.CurrentFile, _sourceTextReader.CurrentLineNumber);
        }

        public override int Read() {
            if (_peekedCharacter != -1) {
                _lastCharacter = _peekedCharacter;
                _peekedCharacter = -1;
                return _lastCharacter;
            }

            _lastCharacter = GetNextCharacter();

            if ((_lastCharacter == -1) && 
                (_inDoubleQuotedString || _inSingleQuotedString)) {
                RaiseError("Unterminated string.");
            }

            return _lastCharacter;
        }
    }
}
