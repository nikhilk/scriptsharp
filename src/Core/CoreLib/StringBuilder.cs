// StringBuilder.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Text {

    /// <summary>
    /// Provides an optimized mechanism to concatenate strings.
    /// </summary>
    [ScriptImport]
    public sealed class StringBuilder {

        /// <summary>
        /// Initializes a new instance of the <see cref="StringBuilder"/> class.
        /// </summary>
        public StringBuilder() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringBuilder"/> class.
        /// </summary>
        /// <param name="initialText">
        /// The string that is used to initialize the value of the instance.
        /// </param>
        public StringBuilder(string initialText) {
        }

        /// <summary>
        /// Gets whether the <see cref="StringBuilder"/> object has any content.
        /// </summary>
        /// <returns>true if the StringBuilder instance contains no text; otherwise, false.</returns>
        [ScriptField]
        public bool IsEmpty {
            get {
                return false;
            }
        }

        /// <summary>
        /// Appends a boolean value to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="b">The boolean value to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(bool b) {
            return null;
        }

        /// <summary>
        /// Appends a character to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="c">The character to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(char c) {
            return null;
        }

        /// <summary>
        /// Appends a number to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="n">The number to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(Number n) {
            return null;
        }

        /// <summary>
        /// Appends an object's string representation to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="o">The object to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(object o) {
            return null;
        }

        /// <summary>
        /// Appends the specified string to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="s">The string to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder Append(string s) {
            return null;
        }

        /// <summary>
        /// Appends a string with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine() {
            return null;
        }

        /// <summary>
        /// Appends a boolean with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="b">The boolean value to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine(bool b) {
            return null;
        }

        /// <summary>
        /// Appends a character with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="c">The character to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine(char c) {
            return null;
        }

        /// <summary>
        /// Appends a number with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="n">The number to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine(Number n) {
            return null;
        }

        /// <summary>
        /// Appends an object's string representation with a line terminator to the end of the
        /// <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="o">The object to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine(object o) {
            return null;
        }

        /// <summary>
        /// Appends a string with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="s">The string to append with a line terminator to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public StringBuilder AppendLine(string s) {
            return null;
        }

        /// <summary>
        /// Clears the contents of the <see cref="StringBuilder"/> instance.
        /// </summary>
        public void Clear() {
        }

        /// <summary>
        /// Creates a string from the contents of a <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <returns>A string representation of the StringBuilder instance.</returns>
        public override string ToString() {
            return null;
        }

        /// <summary>
        /// Creates a string from the contents of a <see cref="StringBuilder"/> instance, and
        /// optionally inserts a delimeter between each element of the created string.
        /// </summary>
        /// <param name="separator">A string to append between each element of the string that is returned.</param>
        /// <returns>
        /// A string representation of the StringBuilder instance. If <paramref name="separator"/>
        /// is specified, the delimeter string is inserted between each element of the returned string.
        /// </returns>
        public string ToString(string separator) {
            return null;
        }
    }
}
