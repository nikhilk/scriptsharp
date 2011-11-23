// BindingContext.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace KnockoutApi
{
    [Imported]
    [IgnoreNamespace]
    public class BindingContext<TRoot, TParent, T>
    {
        [IntrinsicProperty]
        [ScriptName("$data")]
        public T Data
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$parent")]
        public TParent Parent
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$parents")]
        public TParent[] Parents
        {
            get;
            set;
        }

        [IntrinsicProperty]
        [ScriptName("$root")]
        public TRoot[] Root
        {
            get;
            set;
        }
    }
}
