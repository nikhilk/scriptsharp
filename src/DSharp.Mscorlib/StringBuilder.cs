using System.Runtime.CompilerServices;

namespace System.Text
{
    /// <summary>
    /// Provides an optimized mechanism to concatenate strings.
    /// </summary>
    [ScriptImport]
    public sealed class StringBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringBuilder"/> class.
        /// </summary>
        public StringBuilder() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringBuilder"/> class.
        /// </summary>
        /// <param name="initialText">
        /// The string that is used to initialize the value of the instance.
        /// </param>
        public StringBuilder(string initialText) { }

        /// <summary>
        /// Gets whether the <see cref="StringBuilder"/> object has any content.
        /// </summary>
        /// <returns>true if the StringBuilder instance contains no text; otherwise, false.</returns>
        [ScriptField]
        public extern bool IsEmpty { get; }

        /// <summary>
        /// Appends a boolean value to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="b">The boolean value to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder Append(bool b);

        /// <summary>
        /// Appends a character to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="c">The character to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder Append(char c);

        /// <summary>
        /// Appends a number to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="n">The number to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder Append(Number n);

        /// <summary>
        /// Appends an object's string representation to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="o">The object to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder Append(object o);

        /// <summary>
        /// Appends the specified string to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="s">The string to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder Append(string s);

        /// <summary>
        /// Appends a string with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder AppendLine();

        /// <summary>
        /// Appends a boolean with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="b">The boolean value to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder AppendLine(bool b);

        /// <summary>
        /// Appends a character with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="c">The character to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder AppendLine(char c);

        /// <summary>
        /// Appends a number with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="n">The number to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder AppendLine(Number n);

        /// <summary>
        /// Appends an object's string representation with a line terminator to the end of the
        /// <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="o">The object to append to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder AppendLine(object o);

        /// <summary>
        /// Appends a string with a line terminator to the end of the <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="s">The string to append with a line terminator to the end of the StringBuilder instance.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        public extern StringBuilder AppendLine(string s);

        /// <summary>
        /// Clears the contents of the <see cref="StringBuilder"/> instance.
        /// </summary>
        public extern void Clear();

        /// <summary>
        /// Creates a string from the contents of a <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <returns>A string representation of the StringBuilder instance.</returns>
        public extern override string ToString();

        /// <summary>
        /// Creates a string from the contents of a <see cref="StringBuilder"/> instance, and
        /// optionally inserts a delimeter between each element of the created string.
        /// </summary>
        /// <param name="separator">A string to append between each element of the string that is returned.</param>
        /// <returns>
        /// A string representation of the StringBuilder instance. If <paramref name="separator"/>
        /// is specified, the delimeter string is inserted between each element of the returned string.
        /// </returns>
        public extern string ToString(string separator);
    }
}
