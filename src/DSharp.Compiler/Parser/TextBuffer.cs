// TextBuffer.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     A text buffer which tracks current line and column.
    /// </summary>
    internal sealed class TextBuffer
    {
        private readonly char[] text;
        private int ich;

        public TextBuffer(char[] text)
        {
            this.text = text;
        }

        /// <summary>
        ///     The line number of the current position.
        /// </summary>
        public int Line { get; private set; }

        /// <summary>
        ///     The column number of the current postiion.
        ///     Note that tabs are treated as a single column.
        /// </summary>
        public int Column { get; private set; }

        /// <summary>
        ///     The current position.
        /// </summary>
        public BufferPosition Position => new BufferPosition(Line, Column, ich);

        /// <summary>
        ///     The total number of characters in the buffer.
        /// </summary>
        public int Length => text.Length;

        /// <summary>
        ///     The number of characters remaining in the buffer.
        /// </summary>
        public int RemainingLength => text.Length - ich;

        /// <summary>
        ///     Is the current position at the end of the buffer.
        /// </summary>
        public bool Eof => RemainingLength == 0;

        /// <summary>
        ///     Returns the current character.
        /// </summary>
        public char PeekChar()
        {
            return PeekChar(0);
        }

        /// <summary>
        ///     Peeks ahead index chars from the current position.
        /// </summary>
        public char PeekChar(int index)
        {
            Debug.Assert(ich >= 0);
            Debug.Assert(index >= 0);

            if (ich + index >= text.Length)
            {
                Debug.Assert(ich + index == text.Length);

                return '\0';
            }

            return text[ich + index];
        }

        /// <summary>
        ///     Advances the current position and returns the current character.
        /// </summary>
        public char NextChar()
        {
            bool wasCrlf;

            return NextChar(out wasCrlf);
        }

        /// <summary>
        ///     Advances the current position and returns the current character.
        /// </summary>
        public char NextChar(out bool wasCrlf)
        {
            Debug.Assert(ich >= 0);
            Debug.Assert(ich < text.Length);

            wasCrlf = false;
            char ch = PeekChar();
            ich += 1;
            Column += 1;

            if (Lexer.IsLineSeparator(ch))
            {
                Column = 0;
                Line += 1;

                // carriage return followed by a line feed is considered one line break
                if (ch == '\xD' && ich < text.Length && PeekChar() == '\xA')
                {
                    ich += 1;
                    wasCrlf = true;
                }
            }

            Debug.Assert(ich <= text.Length);

            return ch;
        }

        /// <summary>
        ///     Move the current position backwards one character.
        /// </summary>
        public void Reverse()
        {
            Reverse(1);
        }

        /// <summary>
        ///     Moves the current position backwards.
        /// </summary>
        public void Reverse(int numberOfCharacters)
        {
            Debug.Assert(numberOfCharacters >= 0 && numberOfCharacters <= ich);
            Debug.Assert(numberOfCharacters <= Column, "Can't reverse over a line separator");

            ich -= numberOfCharacters;
            Column -= numberOfCharacters;
        }
    }
}