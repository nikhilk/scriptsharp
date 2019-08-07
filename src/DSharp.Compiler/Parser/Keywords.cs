// Keywords.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using DSharp.Compiler.CodeModel.Tokens;

namespace DSharp.Compiler.Parser
{
    /// <summary>
    ///     C# Keywords
    /// </summary>
    internal sealed class Keywords
    {
        private readonly Hashtable keywords;
        private readonly NameTable nameTable;

        /// <summary>
        ///     Initializes Keywords object. Adds all keywords to _nameTable.
        /// </summary>
        public Keywords(NameTable nameTable)
        {
            keywords = new Hashtable((int) TokenType.Identifier);
            this.nameTable = nameTable;

            for (TokenType token = 0; token < TokenType.Identifier; token += 1)
                keywords.Add(this.nameTable.Add(Token.GetString(token)), token);
        }

        /// <summary>
        ///     Returns true if name is a C# keyword
        /// </summary>
        public TokenType IsKeyword(Name name)
        {
            object o = keywords[name];

            if (o != null)
            {
                return (TokenType) o;
            }

            return TokenType.Invalid;
        }
    }
}