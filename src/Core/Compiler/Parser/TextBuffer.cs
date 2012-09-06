// TextBuffer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Globalization;

namespace ScriptSharp.Parser {

    /// <summary>
    /// A text buffer which tracks current line and column.
    /// </summary>
    internal sealed class TextBuffer {

        private char[] text;
        private int ich;
        private int line;
        private int column;

        public TextBuffer(char[] text) {
            this.text = text;
        }

        /// <summary>
        /// Returns the current character.
        /// </summary>
        public char PeekChar() {
            return PeekChar(0);
        }

        /// <summary>
        /// Peeks ahead index chars from the current position.
        /// </summary>
        public char PeekChar(int index) {
            Debug.Assert(ich >= 0);
            Debug.Assert(index >= 0);

            if (ich + index >= text.Length) {
                Debug.Assert(ich + index == text.Length);
                return '\0';
            }
            return text[ich + index];
        }

        /// <summary>
        /// Advances the current position and returns the current character.
        /// </summary>
        public char NextChar() {
            bool wasCRLF;
            return NextChar(out wasCRLF);
        }

        /// <summary>
        /// Advances the current position and returns the current character.
        /// </summary>
        public char NextChar(out bool wasCRLF) {
            Debug.Assert(ich >= 0);
            Debug.Assert(ich < text.Length);

            wasCRLF = false;
            char ch = PeekChar();
            ich += 1;
            column += 1;
            if (Lexer.IsLineSeparator(ch)) {
                column = 0;
                line += 1;

                // carriage return followed by a line feed is considered one line break
                if (ch == '\xD' && ich < text.Length && PeekChar() == '\xA') {
                    ich += 1;
                    wasCRLF = true;
                }
            }

            Debug.Assert(ich <= text.Length);

            return ch;
        }

        /// <summary>
        /// The line number of the current position.
        /// </summary>
        public int Line {
            get {
                return line;
            }
        }

        /// <summary>
        /// The column number of the current postiion.
        /// Note that tabs are treated as a single column.
        /// </summary>
        public int Column {
            get {
                return column;
            }
        }

        /// <summary>
        /// The current position.
        /// </summary>
        public BufferPosition Position {
            get {
                return new BufferPosition(line, column, ich);
            }
        }

        /// <summary>
        /// The total number of characters in the buffer.
        /// </summary>
        public int Length {
            get {
                return text.Length;
            }
        }

        /// <summary>
        /// The number of characters remaining in the buffer.
        /// </summary>
        public int RemainingLength {
            get {
                return text.Length - ich;
            }
        }

        /// <summary>
        /// Is the current position at the end of the buffer.
        /// </summary>
        public bool EOF {
            get {
                return RemainingLength == 0;
            }
        }

        /// <summary>
        /// Move the current position backwards one character.
        /// </summary>
        public void Reverse() {
            Reverse(1);
        }

        /// <summary>
        /// Moves the current position backwards.
        /// </summary>
        public void Reverse(int numberOfCharacters) {
            Debug.Assert(numberOfCharacters >= 0 && numberOfCharacters <= ich);
            Debug.Assert(numberOfCharacters <= column, "Can't reverse over a line separator");

            ich -= numberOfCharacters;
            column -= numberOfCharacters;
        }
    }
}
