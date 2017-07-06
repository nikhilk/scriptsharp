// String.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the String type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class String {

        /// <summary>
        /// An empty zero-length string.
        /// </summary>
        public static readonly String Empty = "";

        /// <summary>
        /// The number of characters in the string.
        /// </summary>
        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the character at the specified position.
        /// </summary>
        /// <param name="index">The specified 0-based position.</param>
        /// <returns>The character within the string.</returns>
        [ScriptField]
        public char this[int index] {
            get {
                return '\0';
            }
        }

        /// <summary>
        /// Retrieves the character at the specified position.
        /// </summary>
        /// <param name="index">The specified 0-based position.</param>
        /// <returns>The character within the string.</returns>
        public char CharAt(int index) {
            return '\0';
        }

        /// <summary>
        /// Retrieves the character code of the character at the specified position.
        /// </summary>
        /// <param name="index">The specified 0-based position.</param>
        /// <returns>The character code of the character within the string.</returns>
        public int CharCodeAt(int index) {
            return 0;
        }

        [ScriptAlias("ss.compareStrings")]
        public static int Compare(string s1, string s2) {
            return 0;
        }

        [ScriptAlias("ss.compareStrings")]
        public static int Compare(string s1, string s2, bool ignoreCase) {
            return 0;
        }

        [ScriptAlias("ss.string")]
        public static string Concat(string s1, string s2) {
            return null;
        }

        [ScriptAlias("ss.string")]
        public static string Concat(string s1, string s2, string s3) {
            return null;
        }

        [ScriptAlias("ss.string")]
        public static string Concat(string s1, string s2, string s3, string s4) {
            return null;
        }

        /// <summary>
        /// Concatenates a set of individual strings into a single string.
        /// </summary>
        /// <param name="strings">The sequence of strings</param>
        /// <returns>The concatenated string.</returns>
        [ScriptAlias("ss.string")]
        public static string Concat(params string[] strings) {
            return null;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ScriptAlias("ss.string")]
        public static string Concat(object o1, object o2) {
            return null;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ScriptAlias("ss.string")]
        public static string Concat(object o1, object o2, object o3) {
            return null;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ScriptAlias("ss.string")]
        public static string Concat(object o1, object o2, object o3, object o4) {
            return null;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [ScriptAlias("ss.string")]
        public static string Concat(params object[] o) {
            return null;
        }

        /// <summary>
        /// Returns the unencoded version of a complete encoded URI.
        /// </summary>
        /// <returns>The unencoded string.</returns>
        [ScriptAlias("decodeURI")]
        public string DecodeUri() {
            return null;
        }

        /// <summary>
        /// Returns the unencoded version of a single part or component of an encoded URI.
        /// </summary>
        /// <returns>The unencoded string.</returns>
        [ScriptAlias("decodeURIComponent")]
        public string DecodeUriComponent() {
            return null;
        }

        /// <summary>
        /// Encodes the complete URI.
        /// </summary>
        /// <returns>The encoded string.</returns>
        [ScriptAlias("encodeURI")]
        public string EncodeUri() {
            return null;
        }

        /// <summary>
        /// Encodes a single part or component of a URI.
        /// </summary>
        /// <returns>The encoded string.</returns>
        [ScriptAlias("encodeURIComponent")]
        public string EncodeUriComponent() {
            return null;
        }

        /// <summary>
        /// Determines if the string ends with the specified character.
        /// </summary>
        /// <param name="ch">The character to test for.</param>
        /// <returns>true if the string ends with the character; false otherwise.</returns>
        [ScriptAlias("ss.endsWith")]
        public bool EndsWith(char ch) {
            return false;
        }

        /// <summary>
        /// Determines if the string ends with the specified substring or suffix.
        /// </summary>
        /// <param name="suffix">The string to test for.</param>
        /// <returns>true if the string ends with the suffix; false otherwise.</returns>
        [ScriptAlias("ss.endsWith")]
        public bool EndsWith(string suffix) {
            return false;
        }

        /// <summary>
        /// Encodes a string by replacing punctuation, spaces etc. with their escaped equivalents.
        /// </summary>
        /// <returns>The escaped string.</returns>
        [ScriptAlias("escape")]
        public string Escape() {
            return null;
        }

        [ScriptAlias("ss.format")]
        public static string Format(string format, params object[] values) {
            return null;
        }

        [ScriptAlias("ss.format")]
        public static string Format(CultureInfo culture, string format, params object[] values) {
            return null;
        }

        [ScriptAlias("ss.string")]
        public static string FromChar(char ch, int count) {
            return null;
        }

        public static string FromCharCode(int charCode) {
            return null;
        }

        public static string FromCharCode(params int[] charCodes) {
            return null;
        }

        public int IndexOf(char ch) {
            return 0;
        }

        public int IndexOf(string subString) {
            return 0;
        }

        public int IndexOf(char ch, int startIndex) {
            return 0;
        }

        public int IndexOf(string subString, int startIndex) {
            return 0;
        }

        [ScriptAlias("ss.insertString")]
        public string Insert(int index, string value) {
            return null;
        }

        [ScriptAlias("ss.emptyString")]
        public static bool IsNullOrEmpty(string s) {
            return false;
        }

        [ScriptAlias("ss.whitespace")]
        public static bool IsNullOrWhiteSpace(string s) {
            return false;
        }

        public int LastIndexOf(Char ch) {
            return 0;
        }

        public int LastIndexOf(string subString) {
            return 0;
        }

        public int LastIndexOf(char ch, int startIndex) {
            return 0;
        }

        public int LastIndexOf(string subString, int startIndex) {
            return 0;
        }

        public string[] Match(RegExp regex) {
            return null;
        }

        [ScriptAlias("ss.padLeft")]
        public string PadLeft(int totalWidth) {
            return null;
        }

        [ScriptAlias("ss.padLeft")]
        public string PadLeft(int totalWidth, char ch) {
            return null;
        }

        [ScriptAlias("ss.padRight")]
        public string PadRight(int totalWidth) {
            return null;
        }

        [ScriptAlias("ss.padRight")]
        public string PadRight(int totalWidth, char ch) {
            return null;
        }

        [ScriptAlias("ss.removeString")]
        public string Remove(int index) {
            return null;
        }

        [ScriptAlias("ss.removeString")]
        public string Remove(int index, int count) {
            return null;
        }

        [ScriptAlias("ss.replaceString")]
        public string Replace(string oldText, string replaceText) {
            return null;
        }

        [ScriptName("replace")]
        public string ReplaceFirst(string oldText, string replaceText) {
            return null;
        }

        [ScriptName("replace")]
        public string ReplaceRegex(RegExp regex, string replaceText) {
            return null;
        }

        [ScriptName("replace")]
        public string ReplaceRegex(RegExp regex, StringReplaceCallback callback) {
            return null;
        }

        public int Search(RegExp regex) {
            return 0;
        }

        public string[] Split(char ch) {
            return null;
        }

        public string[] Split(string separator) {
            return null;
        }

        public string[] Split(char ch, int limit) {
            return null;
        }

        public string[] Split(string separator, int limit) {
            return null;
        }

        public string[] Split(RegExp regex) {
            return null;
        }

        public string[] Split(RegExp regex, int limit) {
            return null;
        }

        [ScriptAlias("ss.startsWith")]
        public bool StartsWith(char ch) {
            return false;
        }

        [ScriptAlias("ss.startsWith")]
        public bool StartsWith(string prefix) {
            return false;
        }

        public string Substr(int startIndex) {
            return null;
        }

        public string Substr(int startIndex, int length) {
            return null;
        }

        public string Substring(int startIndex) {
            return null;
        }

        public string Substring(int startIndex, int endIndex) {
            return null;
        }

        public string ToLocaleLowerCase() {
            return null;
        }

        public string ToLocaleUpperCase() {
            return null;
        }

        [Obsolete("ToLowerCase() should not be used, switch to ToLower()")]
        public string ToLowerCase() {
            return null;
        }

        [ScriptName("toLowerCase")]
        public string ToLower()
        {
            return null;
        }

        [Obsolete("ToUpperCase() should not be used, switch to ToUpper()")]
        public string ToUpperCase()
        {
            return null;
        }

        [ScriptName("toUpperCase")]
        public string ToUpper()
        {
            return null;
        }

        [ScriptAlias("ss.trim")]
        public string Trim() {
            return null;
        }

        [ScriptAlias("ss.trim")]
        public string Trim(char[] trimCharacters) {
            return null;
        }

        [ScriptAlias("ss.trimEnd")]
        public string TrimEnd() {
            return null;
        }

        [ScriptAlias("ss.trimEnd")]
        public string TrimEnd(char[] trimCharacters) {
            return null;
        }

        [ScriptAlias("ss.trimStart")]
        public string TrimStart() {
            return null;
        }

        [ScriptAlias("ss.trimStart")]
        public string TrimStart(char[] trimCharacters) {
            return null;
        }

        /// <summary>
        /// Decodes a string by replacing escaped parts with their equivalent textual representation.
        /// </summary>
        /// <returns>The unescaped string.</returns>
        [ScriptAlias("unescape")]
        public string Unescape() {
            return null;
        }

        /// <internalonly />
        public static bool operator ==(string s1, string s2) {
            return false;
        }

        /// <internalonly />
        public static bool operator !=(string s1, string s2) {
            return false;
        }
    }
}
