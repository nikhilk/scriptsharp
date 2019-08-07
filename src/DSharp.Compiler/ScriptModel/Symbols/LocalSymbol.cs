// LocalSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal abstract class LocalSymbol : Symbol
    {
        protected LocalSymbol(SymbolType type, string name, MemberSymbol parent, TypeSymbol valueType)
            : base(type, name, parent)
        {
            ValueType = valueType;
        }

        public TypeSymbol ValueType { get; }

        public override bool MatchFilter(SymbolFilter filter)
        {
            if ((filter & SymbolFilter.Locals) == 0)
            {
                return false;
            }

            return true;
        }
    }
}