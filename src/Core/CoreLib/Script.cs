// Script.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The Script class contains various methods that represent global
    /// methods present in the underlying script engine.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public static class Script {

        [ScriptField]
        [ScriptAlias("$global")]
        public static object Global {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptAlias("ss.modules")]
        public static Dictionary<string, object> Modules {
            get {
                return null;
            }
        }

        [ScriptField]
        [ScriptAlias("undefined")]
        public static object Undefined {
            get {
                return null;
            }
        }

        /// <summary>
        /// Converts an object into a boolean.
        /// </summary>
        /// <param name="o">The object to convert.</param>
        /// <returns>true if the object is not null, zero, empty string or undefined.</returns>
        public static bool Boolean(object o) {
            return false;
        }

        [ScriptAlias("clearInterval")]
        public static void ClearInterval(int intervalID) {
        }

        [ScriptAlias("clearTimeout")]
        public static void ClearTimeout(int timeoutID) {
        }

        [Obsolete("Switch to using Activator.CreateInstance")]
        [ScriptAlias("ss.createInstance")]
        public static object CreateInstance(Type type, params object[] arguments) {
            return null;
        }

        public static void DeleteField(object instance, string name) {
        }

        public static void DeleteField(Type type, string name) {
        }

        /// <summary>
        /// Enables you to evaluate (or execute) an arbitrary script
        /// literal. This includes JSON literals, where the return
        /// value is the deserialized object graph.
        /// </summary>
        /// <param name="s">The script to be evaluated.</param>
        /// <returns>The result of the evaluation.</returns>
        [ScriptAlias("eval")]
        public static object Eval(string s) {
            return null;
        }

        [ScriptAlias("ss.getConstructorParams")]
        public static Type[] GetConstructorParameterTypes(Type type)
        {
            return null;
        }

        public static object GetField(object instance, string name) {
            return null;
        }

        public static T GetField<T>(object instance, string name) {
            return default(T);
        }

        public static object GetField(Type type, string name) {
            return null;
        }

        public static T GetField<T>(Type type, string name) {
            return default(T);
        }

        public static string GetScriptType(object instance) {
            return null;
        }

        public static bool HasField(object instance, string name) {
            return false;
        }

        public static bool HasField(Type type, string name) {
            return false;
        }

        public static bool HasMethod(object instance, string name) {
            return false;
        }

        public static bool HasMethod(Type type, string name) {
            return false;
        }

        public static object InvokeMethod(object instance, string name, params object[] args) {
            return null;
        }

        public static T InvokeMethod<T>(object instance, string name, params object[] args) {
            return default(T);
        }

        public static object InvokeMethod(Type type, string name, params object[] args) {
            return null;
        }

        public static T InvokeMethod<T>(Type type, string name, params object[] args) {
            return default(T);
        }

        /// <summary>
        /// Checks if the specified object has a falsey value, i.e. it is null or
        /// undefined or empty string or false or zero.
        /// </summary>
        /// <param name="o">The object to test.</param>
        /// <returns>true if the object represents a falsey value; false otherwise.</returns>
        public static bool IsFalsey(object o) {
            return false;
        }

        [ScriptAlias("isFinite")]
        public static bool IsFinite(object o) {
            return false;
        }

        [ScriptAlias("isNaN")]
        public static bool IsNaN(object o) {
            return false;
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
        /// Checks if the specified object has a truthy value, i.e. it is not
        /// null or undefined or empty string or false or zero.
        /// </summary>
        /// <param name="o">The object to test.</param>
        /// <returns>true if the object represents a truthy value; false otherwise.</returns>
        public static bool IsTruthy(object o) {
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
        /// Gets the first truthy (true, non-null, non-undefined, non-empty, non-zero) value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value to check for validity.</param>
        /// <param name="alternateValue">The alternate value to use if the first is invalid.</param>
        /// <param name="alternateValues">Additional alternative values to use if the first is invalid.</param>
        /// <returns>The first valid value.</returns>
        public static TValue Or<TValue>(TValue value, TValue alternateValue, params TValue[] alternateValues) {
            return default(TValue);
        }

        public static void SetField(object instance, string name, object value) {
        }

        public static void SetField(Type type, string name, object value) {
        }

        [ScriptAlias("setInterval")]
        public static int SetInterval(string code, int milliseconds) {
            return 0;
        }

        [ScriptAlias("setInterval")]
        public static int SetInterval(Action callback, int milliseconds) {
            return 0;
        }

        [ScriptAlias("setInterval")]
        public static int SetInterval<T>(Action<T> callback, int milliseconds, T arg) {
            return 0;
        }

        [ScriptAlias("setInterval")]
        public static int SetInterval<T1, T2>(Action<T1, T2> callback, int milliseconds, T1 arg1, T2 arg2) {
            return 0;
        }

        [ScriptAlias("setInterval")]
        public static int SetInterval(Delegate d, int milliseconds, params object[] args) {
            return 0;
        }

        [ScriptAlias("setTimeout")]
        public static int SetTimeout(string code, int milliseconds) {
            return 0;
        }

        [ScriptAlias("setTimeout")]
        public static int SetTimeout(Action callback, int milliseconds) {
            return 0;
        }

        [ScriptAlias("setTimeout")]
        public static int SetTimeout<T>(Action<T> callback, int milliseconds, T arg) {
            return 0;
        }

        [ScriptAlias("setTimeout")]
        public static int SetTimeout<T1, T2>(Action<T1, T2> callback, int milliseconds, T1 arg1, T2 arg2) {
            return 0;
        }

        [ScriptAlias("setTimeout")]
        public static int SetTimeout(Delegate d, int milliseconds, params object[] args) {
            return 0;
        }

        /// <summary>
        /// Gets the first non-null and non-undefined value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value to check for validity.</param>
        /// <param name="alternateValue">The alternate value to use if the first is invalid.</param>
        /// <param name="alternateValues">Additional alternative values to use if the first is invalid.</param>
        /// <returns>The first valid value.</returns>
        [ScriptAlias("ss.value")]
        public static TValue Value<TValue>(TValue value, TValue alternateValue, params TValue[] alternateValues) {
            return default(TValue);
        }
    }
}
