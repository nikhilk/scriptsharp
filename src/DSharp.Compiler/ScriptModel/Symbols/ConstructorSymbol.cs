// MethodSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Text;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class ConstructorSymbol : MethodSymbol
    {
        public ConstructorSymbol(TypeSymbol parent, bool isStatic)
            : base(SymbolType.Constructor, /* name */ string.Empty, parent, /* associatedType */ parent)
        {
            SetVisibility(isStatic ? MemberVisibility.Public | MemberVisibility.Static : MemberVisibility.Public);
        }

        public override string DocumentationId
        {
            get
            {
                TypeSymbol parent = (TypeSymbol) Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("M:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".#ctor");

                if (Parameters != null)
                {
                    sb.Append("(");

                    for (int i = 0; i < Parameters.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }

                        sb.Append(Parameters[i].DocumentationId);
                    }

                    sb.Append(")");
                }

                return sb.ToString();
            }
        }
    }
}