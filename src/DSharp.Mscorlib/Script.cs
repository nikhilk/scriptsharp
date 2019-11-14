using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The Script class contains various methods that represent global
    /// methods present in the underlying script engine.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public static class Script
    {
        [ScriptField]
        [ScriptAlias("$global")]
        public extern static object Global { get; }

        [ScriptField]
        [DSharpScriptMemberName("modules")] //TODO: Look into removing this
        public extern static Dictionary<string, object> Modules { get; }

        [ScriptField]
        [ScriptAlias("undefined")]
        public extern static object Undefined { get; }

        /// <summary>
        /// Converts an object into a boolean.
        /// </summary>
        /// <param name="o">The object to convert.</param>
        /// <returns>true if the object is not null, zero, empty string or undefined.</returns>
        public extern static bool Boolean(object o);

        [ScriptAlias("clearInterval")]
        public extern static void ClearInterval(int intervalID);

        [ScriptAlias("clearTimeout")]
        public extern static void ClearTimeout(int timeoutID);

        public extern static void DeleteField(object instance, string name);

        public extern static void DeleteField(Type type, string name);

        /// <summary>
        /// Enables you to evaluate (or execute) an arbitrary script
        /// literal. This includes JSON literals, where the return
        /// value is the deserialized object graph.
        /// </summary>
        /// <param name="s">The script to be evaluated.</param>
        /// <returns>The result of the evaluation.</returns>
        [ScriptAlias("eval")]
        public extern static object Eval(string s);

        [DSharpScriptMemberName("getConstructorParams")]
        public extern static Type[] GetConstructorParameterTypes(Type type);

        public extern static object GetField(object instance, string name);

        [ScriptIgnoreGenericArguments]
        public extern static T GetField<T>(object instance, string name);

        public extern static object GetField(Type type, string name);

        [ScriptIgnoreGenericArguments]
        public extern static T GetField<T>(Type type, string name);

        public extern static string GetScriptType(object instance);

        public extern static bool HasField(object instance, string name);

        public extern static bool HasField(Type type, string name);

        public extern static bool HasMethod(object instance, string name);

        public extern static bool HasMethod(Type type, string name);

        public extern static object InvokeMethod(object instance, string name, params object[] args);

        [ScriptIgnoreGenericArguments]
        public extern static T InvokeMethod<T>(object instance, string name, params object[] args);

        public extern static object InvokeMethod(Type type, string name, params object[] args);

        [ScriptIgnoreGenericArguments]
        public extern static T InvokeMethod<T>(Type type, string name, params object[] args);

        /// <summary>
        /// Checks if the specified object has a falsey value, i.e. it is null or
        /// undefined or empty string or false or zero.
        /// </summary>
        /// <param name="o">The object to test.</param>
        /// <returns>true if the object represents a falsey value; false otherwise.</returns>
        public extern static bool IsFalsey(object o);

        [ScriptAlias("isFinite")]
        public extern static bool IsFinite(object o);

        [ScriptAlias("isNaN")]
        public extern static bool IsNaN(object o);

        /// <summary>
        /// Checks if the specified object is null.
        /// </summary>
        /// <param name="o">The object to test against null.</param>
        /// <returns>true if the object is null; false otherwise.</returns>
        [DSharpScriptMemberName("isNull")]
        public extern static bool IsNull(object o);

        /// <summary>
        /// Checks if the specified object is null or undefined.
        /// The object passed in should be a local variable, and not
        /// a member of a class (to avoid potential script warnings).
        /// </summary>
        /// <param name="o">The object to test against null or undefined.</param>
        /// <returns>true if the object is null or undefined; false otherwise.</returns>
        [DSharpScriptMemberName("isNullOrUndefined")]
        public extern static bool IsNullOrUndefined(object o);

        /// <summary>
        /// Checks if the specified object is undefined.
        /// The object passed in should be a local variable, and not
        /// a member of a class (to avoid potential script warnings).
        /// </summary>
        /// <param name="o">The object to test against undefined.</param>
        /// <returns>true if the object is undefined; false otherwise.</returns>
        [DSharpScriptMemberName("isUndefined")]
        public extern static bool IsUndefined(object o);

        /// <summary>
        /// Checks if the specified object has a value, i.e. it is not
        /// null or undefined.
        /// </summary>
        /// <param name="o">The object to test.</param>
        /// <returns>true if the object represents a value; false otherwise.</returns>
        [DSharpScriptMemberName("isValue")]
        public extern static bool IsValue(object o);

        /// <summary>
        /// Checks if the specified object has a truthy value, i.e. it is not
        /// null or undefined or empty string or false or zero.
        /// </summary>
        /// <param name="o">The object to test.</param>
        /// <returns>true if the object represents a truthy value; false otherwise.</returns>
        public extern static bool IsTruthy(object o);

        /// <summary>
        /// Enables you to generate an arbitrary (literal) script expression.
        /// The script can contain simple String.Format style tokens (such as
        /// {0}, {1}, ...) to be replaced with the specified arguments.
        /// </summary>
        /// <param name="script">The script expression to be evaluated.</param>
        /// <param name="args">Optional arguments matching tokens in the script.</param>
        /// <returns>The result of the script expression.</returns>
        public extern static object Literal(string script, params object[] args);

        /// <summary>
        /// Gets the first truthy (true, non-null, non-undefined, non-empty, non-zero) value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value to check for validity.</param>
        /// <param name="alternateValue">The alternate value to use if the first is invalid.</param>
        /// <param name="alternateValues">Additional alternative values to use if the first is invalid.</param>
        /// <returns>The first valid value.</returns>
        [ScriptIgnoreGenericArguments]
        public extern static TValue Or<TValue>(TValue value, TValue alternateValue, params TValue[] alternateValues);

        public extern static void SetField(object instance, string name, object value);

        public extern static void SetField(Type type, string name, object value);

        [ScriptAlias("setInterval")]
        public extern static int SetInterval(string code, int milliseconds);

        [ScriptAlias("setInterval")]
        public extern static int SetInterval(Action callback, int milliseconds);

        [ScriptAlias("setInterval")]
        [ScriptIgnoreGenericArguments]
        public extern static int SetInterval<T>(Action<T> callback, int milliseconds, T arg);

        [ScriptAlias("setInterval")]
        [ScriptIgnoreGenericArguments]
        public extern static int SetInterval<T1, T2>(Action<T1, T2> callback, int milliseconds, T1 arg1, T2 arg2);

        [ScriptAlias("setInterval")]
        public extern static int SetInterval(Delegate d, int milliseconds, params object[] args);

        [ScriptAlias("setTimeout")]
        public extern static int SetTimeout(string code, int milliseconds);

        [ScriptAlias("setTimeout")]
        public extern static int SetTimeout(Action callback, int milliseconds);

        [ScriptAlias("setTimeout")]
        [ScriptIgnoreGenericArguments]
        public extern static int SetTimeout<T>(Action<T> callback, int milliseconds, T arg);

        [ScriptAlias("setTimeout")]
        [ScriptIgnoreGenericArguments]
        public extern static int SetTimeout<T1, T2>(Action<T1, T2> callback, int milliseconds, T1 arg1, T2 arg2);

        [ScriptAlias("setTimeout")]
        public extern static int SetTimeout(Delegate d, int milliseconds, params object[] args);

        /// <summary>
        /// Gets the first non-null and non-undefined value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value to check for validity.</param>
        /// <param name="alternateValue">The alternate value to use if the first is invalid.</param>
        /// <param name="alternateValues">Additional alternative values to use if the first is invalid.</param>
        /// <returns>The first valid value.</returns>
        [DSharpScriptMemberName("value")]
        [ScriptIgnoreGenericArguments]
        public extern static TValue Value<TValue>(TValue value, TValue alternateValue, params TValue[] alternateValues);
    }
}
