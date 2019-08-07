// CodeMemberSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal abstract class CodeMemberSymbol : MemberSymbol
    {
        private List<AnonymousMethodSymbol> anonymousMethods;

        private List<ParameterSymbol> parameters;

        protected CodeMemberSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol associatedType)
            : base(type, name, parent, associatedType)
        {
        }

        public IList<AnonymousMethodSymbol> AnonymousMethods => anonymousMethods;

        protected SymbolImplementationFlags ImplementationFlags { get; private set; }

        public bool IsAbstract => (ImplementationFlags & SymbolImplementationFlags.Abstract) != 0;

        public bool IsOverride => (ImplementationFlags & SymbolImplementationFlags.Override) != 0;

        public IList<ParameterSymbol> Parameters => parameters;

        public virtual void AddAnonymousMethod(AnonymousMethodSymbol anonymousMethod)
        {
            Debug.Assert(anonymousMethod != null);

            if (anonymousMethods == null)
            {
                anonymousMethods = new List<AnonymousMethodSymbol>();
            }

            anonymousMethods.Add(anonymousMethod);
        }

        public void AddParameter(ParameterSymbol parameterSymbol)
        {
            Debug.Assert(parameterSymbol != null);

            if (parameters == null)
            {
                parameters = new List<ParameterSymbol>();
            }

            parameters.Add(parameterSymbol);
        }

        public void SetImplementationState(SymbolImplementationFlags implementationFlags)
        {
            Debug.Assert(ImplementationFlags == SymbolImplementationFlags.Regular);
            ImplementationFlags = implementationFlags;
        }
    }
}