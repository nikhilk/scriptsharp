// KnockoutMappingPropertySpecification.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public abstract class KnockoutMappingPropertySpecification {

        protected KnockoutMappingPropertySpecification() {
        }
    }

    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Object")]
    public sealed class KnockoutMappingPropertySpecification<TModel> : KnockoutMappingPropertySpecification {

        [ScriptField]
        public Func<KnockoutMappingCreateOptions, TModel> Create {
            get {
                return null;
            }
            set {
            }
        }

        [ScriptField]
        public Func<KnockoutMappingUpdateOptions, TModel> Update {
            get {
                return null;
            }
            set {
            }
        }
    }
}
