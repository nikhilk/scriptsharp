using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Equivalent to the String type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    // CLR reference: https://source.dot.net/#q=String
    public sealed partial class String
    /* String implements these interfaces: IComparable, IEnumerable, IConvertible, IEnumerable<char>, IComparable<string?>
#nullable disable
    IEquatable<string>,
#nullable restore
    ICloneable */
    {
        /// <summary>
        /// An empty zero-length string.
        /// </summary>
        public static readonly string Empty = "";

        /// <summary>
        /// The number of characters in the string.
        /// </summary>
        [ScriptField]
        public extern int Length { get; }

        /// <summary>
        /// Retrieves the character at the specified position.
        /// </summary>
        /// <param name="index">The specified 0-based position.</param>
        /// <returns>The character within the string.</returns>
        [ScriptField]
        public extern char this[int index] { get; }

        [DSharpScriptMemberName("compareStrings")]
        public extern static int Compare(string s1, string s2);

        [DSharpScriptMemberName("compareStrings")]
        public extern static int Compare(string s1, string s2, bool ignoreCase);

        [DSharpScriptMemberName("string")]
        public extern static string Concat(string s1, string s2);

        [DSharpScriptMemberName("string")]
        public extern static string Concat(string s1, string s2, string s3);

        [DSharpScriptMemberName("string")]
        public extern static string Concat(string s1, string s2, string s3, string s4);

        /// <summary>
        /// Concatenates a set of individual strings into a single string.
        /// </summary>
        /// <param name="strings">The sequence of strings</param>
        /// <returns>The concatenated string.</returns>
        [DSharpScriptMemberName("string")]
        public extern static string Concat(params string[] strings);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DSharpScriptMemberName("string")]
        public extern static string Concat(object o1, object o2);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DSharpScriptMemberName("string")]
        public extern static string Concat(object o1, object o2, object o3);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DSharpScriptMemberName("string")]
        public extern static string Concat(object o1, object o2, object o3, object o4);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DSharpScriptMemberName("string")]
        public extern static string Concat(params object[] o);

        /// <summary>
        /// Determines if the string ends with the specified character.
        /// </summary>
        /// <param name="ch">The character to test for.</param>
        /// <returns>true if the string ends with the character; false otherwise.</returns>
        [DSharpScriptMemberName("endsWith")]
        public extern bool EndsWith(char ch);

        /// <summary>
        /// Determines if the string ends with the specified substring or suffix.
        /// </summary>
        /// <param name="suffix">The string to test for.</param>
        /// <returns>true if the string ends with the suffix; false otherwise.</returns>
        [DSharpScriptMemberName("endsWith")]
        public extern bool EndsWith(string suffix);

        [DSharpScriptMemberName("format")]
        // The CLR signature most similar to this is:  Format(IFormatProvider? provider, string format, params object?[] args)
        public extern static string Format(string format, params object[] values);

        [DSharpScriptMemberName("format")]
        public extern static string Format(CultureInfo culture, string format, params object[] values);

        public extern int IndexOf(string subString);

        public extern int IndexOf(string subString, int startIndex);

        [DSharpScriptMemberName("insertString")]
        public extern string Insert(int index, string value);

        public extern int LastIndexOf(Char ch);

        public extern int LastIndexOf(char ch, int startIndex);

        [DSharpScriptMemberName("padLeft")]
        public extern string PadLeft(int totalWidth);

        [DSharpScriptMemberName("padLeft")]
        public extern string PadLeft(int totalWidth, char ch);

        [DSharpScriptMemberName("padRight")]
        public extern string PadRight(int totalWidth);

        [DSharpScriptMemberName("padRight")]
        public extern string PadRight(int totalWidth, char ch);

        [DSharpScriptMemberName("removeString")]
        public extern string Remove(int index);

        [DSharpScriptMemberName("removeString")]
        public extern string Remove(int index, int count);

        [DSharpScriptMemberName("replaceString")]
        public extern string Replace(string oldText, string replaceText);

        // I guess this method is totally equivalent to this one on the CLR: string[] Split(char separator, StringSplitOptions options = StringSplitOptions.None)
        public extern string[] Split(char ch);

        // I guess this method is totally equivalent to this one on the CLR: string[] Split(string? separator, StringSplitOptions options = StringSplitOptions.None)
        public extern string[] Split(string separator);

        // I guess this method is totally equivalent to this one on the CLR: string[] Split(char separator, int count, StringSplitOptions options = StringSplitOptions.None)
        public extern string[] Split(char ch, int limit);

        // I guess this method is totally equivalent to this one on the CLR: string[] Split(string? separator, int count, StringSplitOptions options = StringSplitOptions.None)
        public extern string[] Split(string separator, int limit);

        [DSharpScriptMemberName("startsWith")]
        public extern bool StartsWith(char ch);

        [DSharpScriptMemberName("startsWith")]
        public extern bool StartsWith(string prefix);

        public extern string Substring(int startIndex);

        public extern string Substring(int startIndex, int endIndex);

        [ScriptName("toLowerCase")]
        public extern string ToLower();

        [ScriptName("toUpperCase")]
        public extern string ToUpper();

        [DSharpScriptMemberName("trim")]
        public extern string Trim();

        [DSharpScriptMemberName("trim")]
        // the signature for this is has been changed. Test the implementation pls
        public extern string Trim(params char[] trimChars);

        [DSharpScriptMemberName("trimEnd")]
        public extern string TrimEnd();

        [DSharpScriptMemberName("trimEnd")]
        // the signature for this is has been changed. Test the implementation pls
        public extern string TrimEnd(params char[] trimChars);

        [DSharpScriptMemberName("trimStart")]
        public extern string TrimStart();

        [DSharpScriptMemberName("trimStart")]
        // the signature for this is has been changed. Test the implementation pls
        public extern string TrimStart(params char[] trimChars);

        [DSharpScriptMemberName("emptyString")]
        public extern static bool IsNullOrEmpty(string s);

        [DSharpScriptMemberName("whitespace")]
        public extern static bool IsNullOrWhiteSpace(string s);

        public extern static bool operator ==(string s1, string s2);

        public extern static bool operator !=(string s1, string s2);
    }
}
