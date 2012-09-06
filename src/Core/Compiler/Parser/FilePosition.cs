// FilePosition.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;

namespace ScriptSharp.Parser {

    /// <summary>
    /// A position in a source file.
    /// </summary>
    internal struct FilePosition {

        private BufferPosition _position;
        private string _fileName;

        public FilePosition(BufferPosition position, string fileName) {
            _position = position;
            _fileName = fileName;
        }

        public BufferPosition Position {
            get {
                return _position;
            }
            set {
                _position = value;
            }
        }

        public string FileName {
            get {
                return _fileName;
            }
            set {
                _fileName = value;
            }
        }

        /// <summary>
        /// Returns a string suitable for display in an error _message.
        /// </summary>
        public override string ToString() {
            return _fileName + _position.ToString();
        }
    }
}
