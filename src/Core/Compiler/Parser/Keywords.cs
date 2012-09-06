// Keywords.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Diagnostics;
using ScriptSharp.CodeModel;

namespace ScriptSharp.Parser {

    /// <summary>
    /// C# Keywords
    /// </summary>
    internal sealed class Keywords {

        private Hashtable _keywords;
        private NameTable _nameTable;

        /// <summary>
        /// Initializes Keywords object. Adds all keywords to _nameTable.
        /// </summary>
        public Keywords(NameTable nameTable) {
            _keywords = new Hashtable((int)TokenType.Identifier);
            _nameTable = nameTable;

            for (TokenType token = 0; token < TokenType.Identifier; token += 1) {
                _keywords.Add(_nameTable.Add(Token.GetString(token)), token);
            }
        }

        /// <summary>
        /// Returns true if name is a C# keyword
        /// </summary>
        public TokenType IsKeyword(Name name) {
            object o = _keywords[name];
            if (o != null) {
                return (TokenType)o;
            }
            return TokenType.Invalid;
        }
    }
}
