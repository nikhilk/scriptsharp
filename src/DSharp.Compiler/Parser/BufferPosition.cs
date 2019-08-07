// BufferPosition.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     A line and column position in a source buffer.
    /// </summary>
    internal struct BufferPosition : IComparable
    {
        public BufferPosition(int line, int column, int offset)
        {
            Line = line;
            Column = column;
            Offset = offset;
        }

        /// <summary>
        ///     The line number of the position (0 based).
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        ///     The column number of the position (0 based).
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        ///     The character offset of the position (0 based).
        /// </summary>
        public int Offset { get; set; }

        public static bool operator ==(BufferPosition a, BufferPosition b)
        {
            return a.Line == b.Line && a.Column == b.Column && a.Offset == b.Offset;
        }

        public static bool operator !=(BufferPosition a, BufferPosition b)
        {
            return !(a == b);
        }

        public static bool operator <(BufferPosition a, BufferPosition b)
        {
            if (a.Line < b.Line)
            {
                return true;
            }

            if (a.Line == b.Line)
            {
                if (a.Column < b.Column)
                {
                    return true;
                }

                if (a.Column == b.Column)
                {
                    if (a.Offset < b.Offset)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator >(BufferPosition a, BufferPosition b)
        {
            return b < a;
        }

        public int CompareTo(BufferPosition pos)
        {
            if (this < pos)
            {
                return -1;
            }

            if (this == pos)
            {
                return 0;
            }

            return 1;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BufferPosition))
            {
                return false;
            }

            return this == (BufferPosition) obj;
        }

        public override int GetHashCode()
        {
            return Line * 64 + Column;
        }

        /// <summary>
        ///     Converts the position to a string suitable for display in an error _message
        /// </summary>
        public override string ToString()
        {
            if (Line == 0 && Column == 0)
            {
                return string.Empty;
            }

            // Add 1 to convert line/column indexes into numbers
            return "(" + (Line + 1) + ", " + (Column + 1) + ")";
        }

        #region Implementation of IComparable

        int IComparable.CompareTo(object o)
        {
            return CompareTo((BufferPosition) o);
        }

        #endregion
    }
}