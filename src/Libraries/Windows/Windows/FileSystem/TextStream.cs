// TextStream.cs
// Script#/Libraries/Windows
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Windows.FileSystem {

    /// <summary>
    /// Provides the ability to sequentially read or write text to a file.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public sealed class TextStream {

        private TextStream() {
        }

        /// <summary>
        /// True if the file pointer is positioned before the end-of-line marker in the file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public bool AtEndOfLine {
            get {
                return false;
            }
        }

        /// <summary>
        /// True if the file pointer is positioned before the end-of-file marker in the file.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public bool AtEndOfStream {
            get {
                return false;
            }
        }

        /// <summary>
        /// The column number of the current character position.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int Column {
            get {
                return 0;
            }
        }

        /// <summary>
        /// The line number of the current character position.
        /// </summary>
        [IntrinsicProperty]
        [PreserveCase]
        public int Line {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Closes an opened TextStream.
        /// </summary>
        [PreserveCase]
        public void Close() {
        }

        /// <summary>
        /// Reads the specified number of characters from an opened TextStream.
        /// </summary>
        /// <param name="characters">The number of characters to read.</param>
        [PreserveCase]
        public string Read(int characters) {
            return null;
        }

        /// <summary>
        /// Reads all the text from an opened TextStream.
        /// </summary>
        [PreserveCase]
        public string ReadAll() {
            return null;
        }

        /// <summary>
        /// Reads all the text until a new line from an opened TextStream.
        /// </summary>
        [PreserveCase]
        public string ReadLine() {
            return null;
        }

        /// <summary>
        /// Skips past the specified number of characters from an opened TextStream.
        /// </summary>
        /// <param name="characters">The number of characters to skip.</param>
        [PreserveCase]
        public void Skip(int characters) {
        }

        /// <summary>
        /// Skips past text until a new line from an opened TextStream.
        /// </summary>
        [PreserveCase]
        public string SkipLine() {
            return null;
        }

        /// <summary>
        /// Writes the specified text to an opened TextStream.
        /// </summary>
        /// <param name="text">The text to write.</param>
        [PreserveCase]
        public void Write(string text) {
        }

        /// <summary>
        /// Writes the specified number of new lines to an opened TextStream.
        /// </summary>
        /// <param name="lines">The number of new lines to write.</param>
        [PreserveCase]
        public void WriteBlankLines(int lines) {
        }

        /// <summary>
        /// Writes a new line to an opened TextStream.
        /// </summary>
        [PreserveCase]
        public void WriteLine() {
        }

        /// <summary>
        /// Writes the specified text followed by a new line to an opened TextStream.
        /// </summary>
        /// <param name="text">The text to write.</param>
        [PreserveCase]
        public void WriteLine(string text) {
        }
    }
}
