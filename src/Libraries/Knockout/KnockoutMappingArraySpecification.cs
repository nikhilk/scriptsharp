// KnockoutMappingArraySpecification.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace KnockoutApi
{
	[IgnoreNamespace]
	[Imported]
	[ScriptName("Object")]
	public abstract class KnockoutMappingArraySpecification
	{
		protected KnockoutMappingArraySpecification() {
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
			set { }
        }

		[IntrinsicProperty]
		public Func<TModel, object> Key {
			get { 
				return null; 
			}
			set { }
		}

    }
}
