// Validator.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Html;
using System.Collections;

namespace jQueryApi.Validation
{
	[Imported]
	[IgnoreNamespace]
	public class Validator	{

		/// <summary>
		/// Validates the specified element
		/// </summary>
		/// <param name="element">The element to validate</param>
		/// <returns>True if the form is valid, otherwise returns false.</returns>
		[ScriptName("element")]
		public bool ValidateElement(Element element) {
			return false;
		}

		/// <summary>
		/// Validates the controlled form
		/// </summary>
		/// <returns>True if the form is valid, otherwise returns false.</returns>
		[ScriptName("form")]
		public bool ValidateForm()	{
			return false;
		}

		/// <summary>
		/// Gets the number of invalid fields on the controlled form.
		/// </summary>
		/// <returns>The number of invalid fields</returns>
		[ScriptName("numberOfInvalids")]
		public int GetInvalidFieldCount() {
			return 0;
		}

		/// <summary>
		/// Resets the controlled form
		/// </summary>
		public void ResetForm() {
		}

		/// <summary>
		/// Shows the specified errors messages.
		/// </summary>
		/// <param name="errors">Key/value pairs of error messages, where the keys relate to names of elements in the form, and
		/// the values are the error messages to display for those elements.</param>
		public void ShowErrors(Dictionary errors) {
		}

	}
}
