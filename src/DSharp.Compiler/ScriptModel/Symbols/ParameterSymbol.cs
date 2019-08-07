// ParameterSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

namespace DSharp.Compiler.ScriptModel.Symbols
{
    internal sealed class ParameterSymbol : LocalSymbol
    {
        public ParameterSymbol(string name, MemberSymbol parent, TypeSymbol valueType, ParameterMode mode, bool containsThisPrefix = false)
            : base(SymbolType.Parameter, name, parent, valueType)
        {
            Mode = mode;
            ContainsThis = containsThisPrefix;
        }

        public override string Documentation => SymbolSet.GetParameterDocumentation(Parent.DocumentationId, Name);

        public override string DocumentationId
        {
            get
            {
                TypeSymbol parameterType = ValueType;

                if (parameterType.IsNativeArray)
                {
                    parameterType = ((ClassSymbol) parameterType).Indexer.AssociatedType;

                    return string.Format("{0}.{1}[]", parameterType.Namespace, parameterType.Name);
                }

                return string.Format("{0}.{1}", parameterType.Namespace, parameterType.Name);
            }
        }

        public ParameterMode Mode { get; }

        public bool ContainsThis { get; }
    }
}
