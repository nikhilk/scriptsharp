// PreprocessorKeywords.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;

namespace DSharp.Compiler.Parser
{
    internal sealed class PreprocessorKeywords
    {
        private readonly Hashtable keywords;

        public PreprocessorKeywords(NameTable symbolTable)
        {
            keywords = new Hashtable();

            for (PreprocessorTokenType token = 0; token < PreprocessorTokenType.Identifier; token += 1)
                keywords.Add(symbolTable.Add(PreprocessorToken.TypeString(token)), token);
        }

        public PreprocessorTokenType IsKeyword(Name value)
        {
            object o = keywords[value];

            if (o != null)
            {
                return (PreprocessorTokenType) o;
            }

            return PreprocessorTokenType.Invalid;
        }
    }
}