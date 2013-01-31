// CSSMediaRule.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace System.Html.CSS {

	[ScriptIgnoreNamespace]
	[ScriptImport]
	public sealed class CSSMediaRule : CSSRule {

		private CSSMediaRule() {
		}

		[ScriptField]
		[ScriptName("cssRules")]
		public CSSRuleList CSSRules {
			get {
				return null;
			}
		}

		[ScriptField]
		public MediaList Media {
			get {
				return null;
			}
		}

		public int InsertRule(string rule, int index) {
			return 0;
		}

		public void DeleteRule(int index) {
		}
	}
}
