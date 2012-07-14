// KnockoutMappingPropertySpecification.cs
// Script#/Libraries/Knockout
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi {

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public abstract class KnockoutMappingPropertySpecification {

        protected KnockoutMappingPropertySpecification() {
        }
    }

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public sealed class KnockoutMappingPropertySpecification<TModel> : KnockoutMappingPropertySpecification {

        [IntrinsicProperty]
        public Func<KnockoutMappingCreateOptions, TModel> Create {
            get {
                return null;
            }
            set {
            }
        }

        [IntrinsicProperty]
        public Func<KnockoutMappingUpdateOptions, TModel> Update {
            get {
                return null;
            }
            set {
            }
        }
    }
}
