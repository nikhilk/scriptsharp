// KnockoutMappingArraySpecification.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public abstract class KnockoutMappingArraySpecification {

        internal KnockoutMappingArraySpecification() {
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class KnockoutMappingArraySpecification<TModel> : KnockoutMappingArraySpecification {

        [ScriptField]
        public Func<KnockoutMappingArrayCreateOptions, TModel> Create {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Func<TModel, object> Key {
            get {
                return null;
            }
            set {
            }
        }
    }
}
