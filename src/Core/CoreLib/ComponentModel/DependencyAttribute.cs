// DependencyAttribute.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.ComponentModel {

    /// <summary>
    /// This attribute can be placed on a property, or constructor parameter.
    /// When placed on a property or parameter this can be used to mark a dependency
    /// and whether it is optional or not.
    /// </summary>
    [Imported]
    [NonScriptable]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public sealed class DependencyAttribute : Attribute {

        private bool _optional;

        /// <summary>
        /// Gets or sets whether the dependency is optional.
        /// </summary>
        public bool Optional {
            get {
                return _optional;
            }
            set {
                _optional = value;
            }
        }
    }
}
