// KnockoutMappingArraySpecification.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public abstract class KnockoutMappingArraySpecification {

        internal KnockoutMappingArraySpecification() {
        }
    }

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class KnockoutMappingArraySpecification<TModel> : KnockoutMappingArraySpecification {

        [IntrinsicProperty]
        public Func<KnockoutMappingArrayCreateOptions, TModel> Create {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public Func<TModel, object> Key {
            get {
                return null;
            }
            set {
            }
        }
    }
}
