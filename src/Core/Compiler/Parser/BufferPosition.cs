// BufferPosition.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    /// <summary>
    /// A line and column position in a source buffer.
    /// </summary>
    internal struct BufferPosition : IComparable {

        private int _offset;
        private int _line;
        private int _column;

        public BufferPosition(int line, int column, int offset) {
            _line = line;
            _column = column;
            _offset = offset;
        }

        /// <summary>
        /// The line number of the position (0 based).
        /// </summary>
        public int Line {
            get {
                return _line;
            }
            set {
                _line = value;
            }
        }

        /// <summary>
        /// The column number of the position (0 based).
        /// </summary>
        public int Column {
            get {
                return _column;
            }
            set {
                _column = value;
            }
        }

        /// <summary>
        /// The character offset of the position (0 based).
        /// </summary>
        public int Offset {
            get {
                return _offset;
            }
            set {
                _offset = value;
            }
        }

        public static bool operator ==(BufferPosition a, BufferPosition b) {
            return (a._line == b._line) && (a._column == b._column) && (a._offset == b._offset);
        }

        public static bool operator !=(BufferPosition a, BufferPosition b) {
            return !(a == b);
        }

        public static bool operator <(BufferPosition a, BufferPosition b) {
            if (a._line < b._line) {
                return true;
            }
            if (a._line == b._line) {
                if (a._column < b._column) {
                    return true;
                }
                if (a._column == b._column) {
                    if (a._offset < b._offset) {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator >(BufferPosition a, BufferPosition b) {
            return b < a;
        }

        public int CompareTo(BufferPosition pos) {
            if (this < pos) {
                return -1;
            }
            else if (this == pos) {
                return 0;
            }
            else {
                return 1;
            }
        }

        public override bool Equals(object obj) {
            if (!(obj is BufferPosition)) {
                return false;
            }

            return this == (BufferPosition)obj;
        }

        public override int GetHashCode() {
            return (_line * 64) + _column;
        }

        /// <summary>
        /// Converts the position to a string suitable for display in an error _message
        /// </summary>
        public override string ToString() {
            if ((_line == 0) && (_column == 0)) {
                return String.Empty;
            }
            else {
                // Add 1 to convert line/column indexes into numbers
                return "(" + (_line + 1) + ", " + (_column + 1) + ")";
            }
        }

        #region Implementation of IComparable
        int IComparable.CompareTo(object o) {
            return CompareTo((BufferPosition)o);
        }
        #endregion
    }
}
