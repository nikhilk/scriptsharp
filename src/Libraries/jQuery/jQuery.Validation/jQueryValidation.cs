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
		/// <param name="element">The element to return the rules for</param>
		/// <returns>The rules which have been assigned to the specified element.</returns>
		[ScriptAlias("$.fn.rules.call")]
		public static ValidationMethodOptions GetRules(jQueryObject element) {
			return null;
		}

		/// <summary>
		/// Removes the specified attributes from the first matched element
		/// </summary>
		/// <param name="element">The element</param>
		/// <param name="attributes">The attribute names to remove</param>
		/// <returns>The attributes which have been removed</returns>
		[ScriptAlias("$.fn.removeAttrs.call")]
		public static string RemoveAttributes(jQueryObject element, string attributes) {
			return null;
		}

		/// <summary>
		/// Adds or removes the specified rules to the first matched element. Requires that the parent form has 
		/// been validated prior to the call.
		/// </summary>
		/// <param name="element">The element</param>
		/// <param name="action">The action to perform. Should be 'add' or 'remove'</param>
		/// <param name="rules">The rules to add or remove to the specified element.</param>
		/// <returns>The current state of the rules collection for the first matched element.</returns>
		[ScriptAlias("$.fn.rules.call")]
		public static ValidationMethodOptions Rules(jQueryObject element, string action, ValidationMethodOptions rules) {
			return null;
		}

		/// <summary>
		/// Validates the selected form.
		/// </summary>
		/// <param name="form">The form to validate</param>
		/// <returns>An instance of the validation controller for the specified form.</returns>
		[ScriptAlias("$.fn.validate.call")]
		public static Validator Validate(jQueryObject form) {
			return null;
		}

		/// <summary>
		/// Validates the selected form.
		/// </summary>
		/// <param name="form">The form to validate</param>
		/// <param name="options">The validation options</param>
		/// <returns>An instance of the validation controller for the specified form.</returns>
		[ScriptAlias("$.fn.validate.call")]
		public static Validator Validate(jQueryObject form, ValidatorOptions options) {
			return null;
		}

		/// <summary>
		/// Checks whether the selected form is valid or whether all selected elements are valid.
		/// </summary>
		/// <param name="form">The form to perform the validation test on.</param>
		/// <returns>True if the form is valid, otherwise false.</returns>
		[ScriptAlias("$.fn.valid.call")]
		public static bool Valid(jQueryObject form) {
			return false;
		}

		
	}
}
