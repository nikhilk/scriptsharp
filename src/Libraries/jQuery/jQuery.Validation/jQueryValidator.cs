// jQueryValidator.cs
// Script#/Libraries/jQuery/Validation
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections;
using System.Html;
using System.Runtime.CompilerServices;

namespace jQueryApi.Validation {

    [ScriptImport]
    [ScriptIgnoreNamespace]
    public sealed class jQueryValidator {

        private jQueryValidator() {
        }

        /// <summary>
        /// Add compound class methods
        /// </summary>
        /// <param name="rules">A map of class name - rules pairs.</param>
        [ScriptAlias("$.validator.addClassRules")]
        public static void AddClassRules(Dictionary rules) {
        }

        /// <summary>
        /// Adds a compound class method
        /// </summary>
        /// <param name="name">The name of the class rule to add</param>
        /// <param name="rules">The compound rules</param>
        [ScriptAlias("$.validator.addClassRules")]
        public static void AddClassRules(string name, Dictionary rules) {
        }

        /// <summary>
        /// Adds a custom validation method.
        /// </summary>
        /// <param name="name">The name of the method. Must be a valid Javascript identifier</param>
        /// <param name="callback">The method callback to invoke during validation</param>
        [ScriptAlias("$.validator.addMethod")]
        public static void AddMethod(string name, jQueryValidationMethod callback) {
        }

        /// <summary>
        /// Adds a custom validation method.
        /// </summary>
        /// <param name="name">The name of the method. Must be a valid Javascript identifier</param>
        /// <param name="callback">The method callback to invoke during validation</param>
        /// <param name="message">The default message to display for this method.</param>
        [ScriptAlias("$.validator.addMethod")]
        public static void AddMethod(string name, jQueryValidationMethod callback, string message) {
        }

        /// <summary>
        /// Formats a string, replacing {n} placeholders with arguments.
        /// </summary>
        /// <param name="template">The template string</param>
        /// <param name="args">The arguments</param>
        /// <returns>A formatted string where each placeholder has been replaced by its argument.</returns>
        [ScriptAlias("$.validator.format")]
        public static string Format(string template, params object[] args) {
            return null;
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
        /// Checks if the current element is optional.
        /// </summary>
        /// <param name="element">The element to validate</param>
        /// <returns>True if the element is optional, otherwise returns false.</returns>
        public static bool Optional(Element element) {
            return false;
        }

        /// <summary>
        /// Resets the controlled form
        /// </summary>
        public void ResetForm() {
        }

        /// <summary>
        /// Sets the default settings for validation
        /// </summary>
        /// <param name="options">The validation options to by used by default during validation</param>
        [ScriptAlias("$.validator.setDefaults")]
        public static void SetDefaults(jQueryValidatorOptions options) {
        }

        /// <summary>
        /// Shows the specified errors messages.
        /// </summary>
        /// <param name="errors">Key/value pairs of error messages, where the keys relate to names of elements in the form, and
        /// the values are the error messages to display for those elements.</param>
        public void ShowErrors(Dictionary errors) {
        }

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
        public bool ValidateForm() {
            return false;
        }
    }
}
