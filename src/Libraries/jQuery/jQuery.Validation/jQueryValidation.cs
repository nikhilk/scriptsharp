// jQueryValidation.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation
{
	[Imported]
	[IgnoreNamespace]
	public sealed class jQueryValidation : jQueryObject
	{
		/// <summary>
		/// Formats a string, replacing {n} placeholders with arguments.
		/// </summary>
		/// <param name="template">The template string</param>
		/// <param name="args">The arguments</param>
		/// <returns>A formatted string where each placeholder has been replaced by its argument.</returns>
		[ScriptAlias("$.validator.format")]
		public static string Format(string template, params object [] args) {
			return null;
		}

		/// <summary>
		/// Returns the validation rules for the first selected argument.
		/// </summary>
		/// <returns>The rules which have been assigned to the specified element.</returns>
		[ScriptName("rules")]
		public ValidationMethodOptions GetRules() {
			return null;
		}

		/// <summary>
		/// Removes the specified attributes from the first matched element
		/// </summary>
		/// <param name="attributes">The attribute names to remove</param>
		/// <returns>The attributes which have been removed</returns>
        [ScriptName("removeAttrs")]
		public string RemoveAttributes(string attributes) {
			return null;
		}

		/// <summary>
		/// Adds or removes the specified rules to the first matched element. Requires that the parent form has 
		/// been validated prior to the call.
		/// </summary>
		/// <param name="action">The action to perform. Should be 'add' or 'remove'</param>
		/// <param name="rules">The rules to add or remove to the specified element.</param>
		/// <returns>The current state of the rules collection for the first matched element.</returns>
		public ValidationMethodOptions Rules(string action, ValidationMethodOptions rules) {
			return null;
		}

		/// <summary>
		/// Validates the selected form.
		/// </summary>
		/// <returns>An instance of the validation controller for the specified form.</returns>
		public Validator Validate() {
			return null;
		}

		/// <summary>
		/// Validates the selected form.
		/// </summary>
		/// <param name="options">The validation options</param>
		/// <returns>An instance of the validation controller for the specified form.</returns>
		public Validator Validate(ValidatorOptions options) {
			return null;
		}

		/// <summary>
		/// Checks whether the selected form is valid or whether all selected elements are valid.
		/// </summary>
		/// <returns>True if the form is valid, otherwise false.</returns>
		public bool Valid() {
			return false;
		}	
	}
}
