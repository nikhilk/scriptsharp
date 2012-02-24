// jQueryValidation.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation
{
	[Imported]
	[IgnoreNamespace]
	public class jQueryValidation
	{
		[ScriptAlias("$.fn.validate.call")]
		public static Validator Validate(jQueryObject form) {
			return null;
		}

		[ScriptAlias("$.fn.valid.call")]
		public static bool Valid(jQueryObject form) {
			return false;
		}

		
	}
}
