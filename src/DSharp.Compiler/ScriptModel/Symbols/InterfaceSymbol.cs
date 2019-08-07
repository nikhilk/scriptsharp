// InterfaceSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class InterfaceSymbol : TypeSymbol
    {
        public InterfaceSymbol(string name, NamespaceSymbol parent)
            : base(SymbolType.Interface, name, parent)
        {
        }

        public IndexerSymbol Indexer { get; private set; }

        public ICollection<InterfaceSymbol> Interfaces { get; private set; }

        public override void AddMember(MemberSymbol memberSymbol)
        {
            Debug.Assert(memberSymbol != null);

            if (memberSymbol.Type == SymbolType.Indexer)
            {
                Debug.Assert(Indexer == null);
                Indexer = (IndexerSymbol) memberSymbol;
            }
            else
            {
                base.AddMember(memberSymbol);
            }
        }

        public override MemberSymbol GetMember(string name)
        {
            MemberSymbol member = base.GetMember(name);

            if (member == null && Interfaces != null)
            {
                foreach (InterfaceSymbol interfaceSymbol in Interfaces)
                {
                    member = interfaceSymbol.GetMember(name);

                    if (member != null)
                    {
                        return member;
                    }
                }
            }

            return member;
        }

        public void SetInheritance(ICollection<InterfaceSymbol> interfaces)
        {
            Interfaces = interfaces;
        }
    }
}
