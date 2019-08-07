// FieldSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;
using System.Text;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class EventSymbol : CodeMemberSymbol
    {
        private SymbolImplementation adderImplementation;
        private SymbolImplementation removerImplementation;

        public EventSymbol(string name, TypeSymbol parent, TypeSymbol handlerType)
            : base(SymbolType.Event, name, parent, handlerType)
        {
            ParameterSymbol valueParameter = new ParameterSymbol("value", this, handlerType, ParameterMode.In);
            AddParameter(valueParameter);
        }

        public string AddAccessor { get; private set; }

        public SymbolImplementation AdderImplementation
        {
            get
            {
                Debug.Assert(adderImplementation != null);

                return adderImplementation;
            }
        }

        public bool DefaultImplementation => (ImplementationFlags & SymbolImplementationFlags.Generated) != 0;

        public override string DocumentationId
        {
            get
            {
                TypeSymbol parent = (TypeSymbol) Parent;

                StringBuilder sb = new StringBuilder();
                sb.Append("E:");
                sb.Append(parent.Namespace);
                sb.Append(".");
                sb.Append(parent.Name);
                sb.Append(".");
                sb.Append(Name);

                return sb.ToString();
            }
        }

        public bool HasCustomAccessors => AddAccessor != null && RemoveAccessor != null;

        public string RemoveAccessor { get; private set; }

        public SymbolImplementation RemoverImplementation
        {
            get
            {
                Debug.Assert(removerImplementation != null);

                return removerImplementation;
            }
        }

        public void AddImplementation(SymbolImplementation implementation, bool adder)
        {
            Debug.Assert(implementation != null);

            if (adder)
            {
                Debug.Assert(adderImplementation == null);
                adderImplementation = implementation;
            }
            else
            {
                Debug.Assert(removerImplementation == null);
                removerImplementation = implementation;
            }
        }

        public void SetAccessors(string addAccessor, string removeAccessor)
        {
            Debug.Assert(AddAccessor == null && RemoveAccessor == null);
            Debug.Assert(string.IsNullOrEmpty(addAccessor) == false);
            Debug.Assert(string.IsNullOrEmpty(removeAccessor) == false);

            AddAccessor = addAccessor;
            RemoveAccessor = removeAccessor;
        }
    }
}