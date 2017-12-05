// Utility.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace ScriptSharp {

    internal static class Utility {

        private static readonly string Base64Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$_";
        private static readonly string Base54Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$_";

        private static readonly string[] ScriptKeywords =
            new string[] {
                // Current keywords
                "break", "delete", "function", "return", "typeof", "case", "do",
                "if", "switch", "var", "catch", "else", "in", "this",
                "void", "continue", "false", "instanceof", "throw", "while",
                "debugger", "finally", "new", "true", "with", "default",
                "for", "null", "try",
                // Future reserved words
                "abstract", "double", "goto", "native", "static", "boolean",
                "enum", "implements", "package", "super", "byte", "export",
                "import", "private", "synchronized", "char", "extends", "int",
                "protected", "throws", "class", "final", "interface", "public",
                "transient", "const", "float", "long", "short", "volatile",
                // Script#-specific words
                "ss", "global"
            };
        private static Hashtable _keywordTable;

        public static string CreateCamelCaseName(string name) {
            if (String.IsNullOrEmpty(name)) {
                return name;
            }

            // Some exceptions that simply need to be special cased
            if (name.Equals("ID", StringComparison.Ordinal)) {
                return "id";
            }

            bool hasLowerCase = false;
            int conversionLength = 0;

            for (int i = 0; i < name.Length; i++) {
                if (Char.IsUpper(name, i)) {
                    conversionLength++;
                }
                else {
                    hasLowerCase = true;
                    break;
                }
            }

            if (((hasLowerCase == false) && (name.Length != 1)) || (conversionLength == 0)) {
                // Name is all upper case, or all lower case;
                // leave it as-is.
                return name;
            }

            if (conversionLength > 1) {
                // Convert the leading uppercase segment, except the last character
                // which is assumed to be the first letter of the next word
                return name.Substring(0, conversionLength - 1).ToLower(CultureInfo.InvariantCulture) +
                       name.Substring(conversionLength - 1);
            }
            else if (name.Length == 1) {
                return name.ToLower(CultureInfo.InvariantCulture);
            }
            else {
                // Convert the leading upper case character to lower case
                return Char.ToLower(name[0], CultureInfo.InvariantCulture) + name.Substring(1);
            }
        }

        public static string CreateEncodedName(int number, bool useDigits) {
            string alphabet = useDigits ? Base64Alphabet : Base54Alphabet;
            if (number == 0) {
                return alphabet[0].ToString();
            }

            string name = String.Empty;
            while (number > 0) {
                int remainder = number % alphabet.Length;
                number = (int)(number / alphabet.Length);

                name = alphabet[remainder] + name;
            }

            return name;
        }

        public static string GetResourceFileLocale(string fileName) {
            string extension = Path.GetExtension(fileName);

            if (String.Compare(extension, ".resx", StringComparison.OrdinalIgnoreCase) == 0) {
                fileName = Path.GetFileNameWithoutExtension(fileName);

                extension = Path.GetExtension(fileName);
                if (String.IsNullOrEmpty(extension) == false) {
                    return extension.Substring(1);
                }
            }

            return String.Empty;
        }

        public static string GetResourceFileName(string fileName) {
            string extension = Path.GetExtension(fileName);

            if (String.Compare(extension, ".resx", StringComparison.OrdinalIgnoreCase) == 0) {
                fileName = Path.GetFileNameWithoutExtension(fileName);

                extension = Path.GetExtension(fileName);
                if (String.IsNullOrEmpty(extension) == false) {
                    fileName = Path.GetFileNameWithoutExtension(fileName);
                }
            }

            return fileName;
        }

        public static bool IsKeyword(string identifier) {
            return IsKeyword(identifier, /* testCamelCase */ false);
        }

        public static bool IsKeyword(string identifier, bool testCamelCase) {
            Debug.Assert(String.IsNullOrEmpty(identifier) == false);

            if (_keywordTable == null) {
                _keywordTable = new Hashtable(StringComparer.Ordinal);
                foreach (string word in ScriptKeywords) {
                    _keywordTable.Add(word, null);
                }
            }

            if (testCamelCase) {
                identifier = CreateCamelCaseName(identifier);
            }
            return _keywordTable.ContainsKey(identifier);
        }

        public static bool IsValidIdentifier(string name) {
            if (String.IsNullOrEmpty(name)) {
                return false;
            }
            if (IsKeyword(name)) {
                return false;
            }
            if (Char.IsDigit(name[0])) {
                return false;
            }
            for (int i = 0; i < name.Length; i++) {
                char ch = name[i];
                if ((ch != '_') && (ch != '$') &&
                    (Char.IsLetterOrDigit(ch) == false)) {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidScriptNamespace(string name) {
            if (String.IsNullOrEmpty(name)) {
                return false;
            }
            foreach (string part in name.Split('.')) {
                if (!IsValidIdentifier(part)) {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidScriptName(string name) {
            if (String.IsNullOrEmpty(name)) {
                return true;
            }
            if (IsKeyword(name)) {
                return false;
            }
            if (Char.IsDigit(name[0])) {
                return false;
            }
            for (int i = 0; i < name.Length; i++) {
                char ch = name[i];
                if ((Char.IsLetterOrDigit(ch) == false) && (ch != '.') && (ch != '_')) {
                    return false;
                }
            }
            return true;
        }

        public static string QuoteString(string s) {
            if (String.IsNullOrEmpty(s)) {
                return "''";
            }

            bool useDoubleQuotes = (s.IndexOf('\'') >= 0);

            StringBuilder b = null;
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < s.Length; i++) {
                char c = s[i];

                // Append the unhandled characters (that do not require special treament)
                // to the string builder when special characters are detected.
                if (c == '\r' || c == '\t' ||
                    c == '\\' || c == '\r' || c < ' ' || c > 0x7F ||
                    ((c == '\"') && useDoubleQuotes) ||
                    ((c == '\'') && (useDoubleQuotes == false))) {
                    if (b == null) {
                        b = new StringBuilder(s.Length + 6);
                    }

                    if (count > 0) {
                        b.Append(s, startIndex, count);
                    }

                    startIndex = i + 1;
                    count = 0;
                }

                switch (c) {
                    case '\r':
                        b.Append("\\r");
                        break;
                    case '\t':
                        b.Append("\\t");
                        break;
                    case '\\':
                        b.Append("\\\\");
                        break;
                    case '\n':
                        b.Append("\\n");
                        break;
                    case '\"':
                        if (useDoubleQuotes) {
                            b.Append("\\\"");
                            break;
                        }
                        goto default;
                    case '\'':
                        if (!useDoubleQuotes) {
                            b.Append("\\\'");
                            break;
                        }
                        goto default;
                    default:
                        if ((c < ' ') || (c > 0x7F)) {
                            b.AppendFormat(CultureInfo.InvariantCulture, "\\u{0:x4}", (int)c);
                        }
                        else {
                            count++;
                        }
                        break;
                }
            }

            string processedString = s;
            if (b != null) {
                if (count > 0) {
                    b.Append(s, startIndex, count);
                }
                processedString = b.ToString();
            }

            if (useDoubleQuotes) {
                return "\"" + processedString + "\"";
            }
            return "'" + processedString + "'";
        }
    }
}
