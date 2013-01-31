// CSSRuleList.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System.Html.CSS {

	[ScriptIgnoreNamespace]
	[ScriptImport]
	public sealed class CSSRuleList {

		private CSSRuleList() {
		}

		[ScriptField]
		public long Length {
			get {
				return 0;
			}
		}

		[ScriptField]
		public CSSRule this[int index] {
			get {
				return null;
			}
		}
	}
}
