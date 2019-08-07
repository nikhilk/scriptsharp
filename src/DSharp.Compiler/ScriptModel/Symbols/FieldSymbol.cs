// FieldSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using System.Text;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal class FieldSymbol : MemberSymbol
    {
        private SymbolImplementation implementation;

        private object value;

        public FieldSymbol(string name, TypeSymbol parent, TypeSymbol valueType)
            : this(SymbolType.Field, name, parent, valueType)
        {
        }

        protected FieldSymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol valueType)
            : base(type, name, parent, valueType)
        {
        }

        public override string DocumentationId
        {
            get
            {
                TypeSymbol parent = (TypeSymbol) Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("F:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public bool HasInitializer { get; private set; }

        public SymbolImplementation Implementation
        {
            get
            {
                Debug.Assert(implementation != null);

                return implementation;
            }
        }

        public bool IsConstant { get; private set; }

        public bool IsGlobalField { get; private set; }

        public object Value
        {
            get
            {
                Debug.Assert(value != null);

                return value;
            }
            set
            {
                Debug.Assert(value != null);

                this.value = value;
            }
        }

        public void AddImplementation(SymbolImplementation implementation)
        {
            Debug.Assert(this.implementation == null);
            Debug.Assert(implementation != null);

            this.implementation = implementation;
        }

        public void SetTransformName(string transformName)
        {
            Debug.Assert((Visibility & MemberVisibility.Static) != 0);

            SetTransformedName(transformName);
            IsGlobalField = true;
        }

        public void SetConstant()
        {
            // NOTE: This is only called for fields built from application
            //       code. We use this information to do const inlining
            //       which is scoped to consts defined within the assembly
            //       being compiled.

            Debug.Assert(IsConstant == false);
            IsConstant = true;
        }

        public void SetImplementationState(bool hasInitializer)
        {
            HasInitializer = hasInitializer;
        }
    }
}
