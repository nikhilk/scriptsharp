// AnonymousMethodSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class AnonymousMethodSymbol : MethodSymbol
    {
        public AnonymousMethodSymbol(CodeMemberSymbol containingMember, ISymbolTable stackContext,
                                     TypeSymbol returnType, bool isStatic)
            : base(SymbolType.AnonymousMethod, /* name */ string.Empty, (TypeSymbol) containingMember.Parent,
                returnType)
        {
            SetVisibility(isStatic ? MemberVisibility.Public | MemberVisibility.Static : MemberVisibility.Public);
            ContainingMember = containingMember;
            StackContext = stackContext;

            ContainingMember.AddAnonymousMethod(this);
        }

        public CodeMemberSymbol ContainingMember { get; }

        public int Depth
        {
            get
            {
                int depth = 1;

                if (ContainingMember is AnonymousMethodSymbol)
                {
                    depth += ((AnonymousMethodSymbol) ContainingMember).Depth;
                }

                return depth;
            }
        }

        public ISymbolTable StackContext { get; }

        public override void AddAnonymousMethod(AnonymousMethodSymbol anonymousMethod)
        {
            ContainingMember.AddAnonymousMethod(anonymousMethod);
        }
    }
}