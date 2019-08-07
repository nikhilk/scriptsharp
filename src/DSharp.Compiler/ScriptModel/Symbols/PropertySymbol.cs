// PropertySymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using System.Text;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal class PropertySymbol : CodeMemberSymbol
    {
        private SymbolImplementation getterImplementation;
        private SymbolImplementation setterImplementation;

        public PropertySymbol(string name, TypeSymbol parent, TypeSymbol propertyType)
            : this(SymbolType.Property, name, parent, propertyType)
        {
        }

        protected PropertySymbol(SymbolType type, string name, TypeSymbol parent, TypeSymbol propertyType)
            : base(type, name, parent, propertyType)
        {
        }

        public override string DocumentationId
        {
            get
            {
                TypeSymbol parent = (TypeSymbol) Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("P:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public bool IsReadOnly => (ImplementationFlags & SymbolImplementationFlags.ReadOnly) != 0;

        public bool HasGetter => getterImplementation != null;

        public bool HasSetter => setterImplementation != null;

        public SymbolImplementation GetterImplementation
        {
            get
            {
                Debug.Assert(getterImplementation != null);

                return getterImplementation;
            }
        }

        public SymbolImplementation SetterImplementation
        {
            get
            {
                Debug.Assert(setterImplementation != null);

                return setterImplementation;
            }
        }

        public void AddImplementation(SymbolImplementation implementation, bool getter)
        {
            Debug.Assert(implementation != null);

            if (getter)
            {
                Debug.Assert(getterImplementation == null);
                getterImplementation = implementation;
            }
            else
            {
                Debug.Assert(setterImplementation == null);
                setterImplementation = implementation;
            }
        }
    }
}