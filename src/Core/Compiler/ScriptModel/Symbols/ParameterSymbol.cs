// ParameterSymbol.cs
// Script#/Core/Compiler
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Diagnostics;
using System.Text;

namespace ScriptSharp.ScriptModel {
    
    internal sealed class ParameterSymbol : LocalSymbol {

        private ParameterMode _mode;

        public ParameterSymbol(string name, MemberSymbol parent, TypeSymbol valueType, ParameterMode mode)
            : base(SymbolType.Parameter, name, parent, valueType) {
            _mode = mode;
        }

        public override string Documentation {
            get {
                return SymbolSet.GetParameterDocumentation(Parent.DocumentationID, Name);
            }
        }

        public override string DocumentationID {
            get {
                TypeSymbol parameterType = ValueType;

                if (parameterType.IsArray) {
                    parameterType = ((ClassSymbol)parameterType).Indexer.AssociatedType;

                    return String.Format("{0}.{1}[]", parameterType.Namespace, parameterType.Name);
                }
                else {
                    return String.Format("{0}.{1}", parameterType.Namespace, parameterType.Name);
                }
            }
        }

        public ParameterMode Mode {
            get {
                return _mode;
            }
        }
    }
}
