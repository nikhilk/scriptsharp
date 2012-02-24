// ValidatorOptions.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections;

namespace jQueryApi.Validation
{
	[Imported]
	[IgnoreNamespace]
	[ScriptName("Object")]
	public sealed class ValidatorOptions {

		[IntrinsicProperty]
		public bool Debug {
			get { 
				return false; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public string ErrorClass {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public string ErrorContainer {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public string ErrorElement {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public string ErrorLabelContainer {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public bool FocusCleanup {
			get	{
				return false;
			}
			set {
			}
		}

		[IntrinsicProperty]
		public bool FocusInvalid {
			get	{
				return false;
			}
			set {
			}
		}

		[IntrinsicProperty]
		public Dictionary Groups {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		[ScriptName("ignore")]
		public string IgnoreSelector {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public Action<jQueryEvent, Validator> InvalidHandler {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public Dictionary Messages {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public string Meta	{
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public Dictionary Rules {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public Action<jQueryObject> SubmitHandler {
			get { 
				return null; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		[ScriptName("onclick")]
		public bool ValidateOnClick	{
			get { 
				return false;
			}
			set { 
			}
		}

		[IntrinsicProperty]
		[ScriptName("onfocusout")]
		public bool ValidateOnFocusOut	{
			get { 
				return false;
			}
			set { 
			}
		}

		[IntrinsicProperty]
		[ScriptName("onkeyup")]
		public bool ValidateOnKeyUp	{
			get { 
				return false;
			}
			set { 
			}
		}

		[IntrinsicProperty]
		[ScriptName("onsubmit")]
		public bool ValidateOnSubmit {
			get { 
				return false; 
			}
			set { 
			}
		}

		[IntrinsicProperty]
		public string ValidClass {
			get { 
				return null; 
			}
			set { 
			}
		}	

		[IntrinsicProperty]
		public string Wrapper {
			get { 
				return null; 
			}
			set { 
			}
		}
	}
}
