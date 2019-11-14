// EnumerationSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Diagnostics;

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class EnumerationSymbol : TypeSymbol
    {
        public EnumerationSymbol(string name, NamespaceSymbol parent, bool flags)
            : base(SymbolType.Enumeration, name, parent)
        {
            Flags = flags;
            TransformationCookie = -1;
        }

        public bool Constants => UseNamedValues || UseNumericValues;

        public bool Flags { get; }

        public int TransformationCookie { get; set; }

        public bool UseNamedValues { get; private set; }

        public bool UseNumericValues { get; private set; }

        public string CreateNamedValue(EnumerationFieldSymbol field)
        {
            Debug.Assert(UseNamedValues);
            Debug.Assert(field.Parent == this);

            if (field.IsTransformed)
            {
                return field.GeneratedName;
            }

            string name = field.Name;

            if (field.IsCasePreserved == false)
            {
                name = Utility.CreateCamelCaseName(name);
            }

            return name;
        }

        public void SetNamedValues()
        {
            Debug.Assert(UseNumericValues == false);

            UseNamedValues = true;
        }

        public void SetNumericValues()
        {
            Debug.Assert(UseNamedValues == false);

            UseNumericValues = true;
        }

        public override TypeSymbol GetBaseType()
        {
            return SymbolSet.ResolveIntrinsicType(IntrinsicType.Enum);
        }
    }
}
