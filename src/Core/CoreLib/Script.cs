// Script.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The Script class contains various methods that represent global
    /// methods present in the underlying script engine.
    /// </summary>
    [GlobalMethods]
    [IgnoreNamespace]
    [Imported]
    public static class Script {

        /// <summary>
        /// Displays a message box containing the specified message text.
        /// </summary>
        /// <param name="message">The text of the message.</param>
        public static void Alert(string message) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="b">The boolean to display.</param>
        public static void Alert(bool b) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="d">The date to display.</param>
        public static void Alert(Date d) {
        }

        /// <summary>
        /// Displays a message box containing the specified value converted
        /// into a string.
        /// </summary>
        /// <param name="n">The number to display.</param>
        public static void Alert(Number n) {
        }

        /// <summary>
        /// Converts an object into a boolean.
        /// </summary>
        /// <param name="o">The object to convert.</param>
        /// <returns>true if the object is not null, zero, empty string or undefined.</returns>
        public static bool Boolean(object o) {
            return false;
        }

        /// <summary>
        /// Prompts the user with a yes/no question.
        /// </summary>
        /// <param name="message">The text of the question.</param>
        /// <returns>true if the user chooses yes; false otherwise.</returns>
        public static bool Confirm(string message) {
            return false;
        }

        /// <summary>
        /// Enables you to evaluate (or execute) an arbitrary script
        /// literal. This includes JSON literals, where the return
        /// value is the deserialized object graph.
        /// </summary>
        /// <param name="s">The script to be evaluated.</param>
        /// <returns>The result of the evaluation.</returns>
        public static object Eval(string s) {
            return null;
        }

        /// <summary>
        /// Checks if the specified object is null.
        /// </summary>
        /// <param name="o">The object to test against null.</param>
        /// <returns>true if the object is null; false otherwise.</returns>
        [ScriptAlias("ss.isNull")]
        public static bool IsNull(object o) {
            return false;
        }

        /// <summary>
        /// Checks if the specified object is null or undefined.
        /// The object passed in should be a local variable, and not
        /// a member of a class (to avoid potential script warnings).
        /// </summary>
        /// <param name="o">The object to test against null or undefined.</param>
        /// <returns>true if the object is null or undefined; false otherwise.</returns>
        [ScriptAlias("ss.isNullOrUndefined")]
        public static bool IsNullOrUndefined(object o) {
            return false;
        }

        /// <summary>
        /// Checks if the specified object is undefined.
        /// The object passed in should be a local variable, and not
        /// a member of a class (to avoid potential script warnings).
        /// </summary>
        /// <param name="o">The object to test against undefined.</param>
        /// <returns>true if the object is undefined; false otherwise.</returns>
        [ScriptAlias("ss.isUndefined")]
        public static bool IsUndefined(object o) {
            return false;
        }

        /// <summary>
        /// Checks if the specified object has a value, i.e. it is not
        /// null or undefined.
        /// </summary>
        /// <param name="o">The object to test.</param>
        /// <returns>true if the object represents a value; false otherwise.</returns>
        [ScriptAlias("ss.isValue")]
        public static bool IsValue(object o) {
            return false;
        }

        /// <summary>
        /// Enables you to generate an arbitrary (literal) script expression.
        /// The script can contain simple String.Format style tokens (such as
        /// {0}, {1}, ...) to be replaced with the specified arguments.
        /// </summary>
        /// <param name="script">The script expression to be evaluated.</param>
        /// <param name="args">Optional arguments matching tokens in the script.</param>
        /// <returns>The result of the script expression.</returns>
        public static object Literal(string script, params object[] args) {
            return null;
        }

        /// <summary>
        /// Loads the specified scripts.
        /// </summary>
        /// <param name="scriptNames">The names of scripts that are required and must be loaded.</param>
        [ScriptAlias("ss.loadScripts")]
        public static void LoadScripts(string[] scriptNames) {
        }

        /// <summary>
        /// Loads the specified scripts and invokes the specified callback once they have been
        /// loaded.
        /// </summary>
        /// <param name="scriptNames">The names of scripts that are required and must be loaded.</param>
        /// <param name="callback">A callback to be invoked once the scripts have been loaded.</param>
        [ScriptAlias("ss.loadScripts")]
        public static void LoadScripts(string[] scriptNames, Action callback) {
        }

        /// <summary>
        /// Loads the specified scripts and invokes the specified callback once they have been
        /// loaded.
        /// </summary>
        /// <param name="scriptNames">The names of scripts that are required and must be loaded.</param>
        /// <param name="callback">A callback to be invoked once the scripts have been loaded.</param>
        /// <param name="context">The object to be passed in into the callback.</param>
        /// <typeparam name="TContext">The type of the context object.</typeparam>
        [ScriptAlias("ss.loadScripts")]
        public static void LoadScripts<TContext>(string[] scriptNames, Action<TContext> callback, TContext context) {
        }

        /// <summary>
        /// Registers the specified callback to be invoked when the DOM is ready,
        /// and before any script loading has begun.
        /// </summary>
        /// <param name="callback">The callback to invoke.</param>
        [ScriptAlias("ss.init")]
        public static void OnInit(Action callback) {
        }

        /// <summary>
        /// Registers a callback to be invoked once any necessary scripts
        /// have been loaded.
        /// </summary>
        /// <param name="callback">The callback to be invoked.</param>
        [ScriptAlias("ss.ready")]
        public static void OnReady(Action callback) {
        }

        /// <summary>
        /// Prompts the user to enter a value.
        /// </summary>
        /// <param name="message">The text of the prompt.</param>
        /// <returns>The value entered by the user.</returns>
        public static string Prompt(string message) {
            return null;
        }

        /// <summary>
        /// Prompts the user to enter a value, along with providing a default
        /// value.
        /// </summary>
        /// <param name="message">The text of the prompt.</param>
        /// <param name="defaultValue">The default value for the prompt.</param>
        /// <returns>The value entered by the user.</returns>
        public static string Prompt(string message, string defaultValue) {
            return null;
        }

        /// <summary>
        /// Registers information about a script.
        /// </summary>
        /// <param name="scriptInfo">The information about a script.</param>
        [ScriptAlias("ss.registerScript")]
        public static void RegisterScript(ScriptInfo scriptInfo) {
        }

        /// <summary>
        /// Gets the first valid (non-null, non-undefined, non-empty) value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value to check for validity.</param>
        /// <param name="alternateValue">The alternate value to use if the first is invalid.</param>
        /// <param name="alternateValues">Additional alternative values to use if the first is invalid.</param>
        /// <returns>The first valid value.</returns>
        public static TValue Value<TValue>(TValue value, TValue alternateValue, params TValue[] alternateValues) {
            return default(TValue);
        }
    }
}
