// ConditionalAttribute.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Diagnostics {

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    [NonScriptable]
    [Imported]
    public sealed class ConditionalAttribute : Attribute {

        private string _conditionString;

        public ConditionalAttribute(string conditionString) {
            _conditionString = conditionString;
        }

        public string ConditionString {
            get {
                return _conditionString;
            }
        }
    }
}
