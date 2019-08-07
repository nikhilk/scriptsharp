using System.Runtime.CompilerServices;

namespace System
{
    //TODO: Move to javascript library
    /// <summary>
    /// Equivalent to the Function type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Function
    {
        /// <summary>
        /// Creates a new function with the specified implementation.
        /// </summary>
        /// <param name="functionBody">The implementation of the function.</param>
        public Function(string functionBody) { }

        /// <summary>
        /// Creates a new function with the specified implementation, and the
        /// set of named parameters.
        /// </summary>
        /// <param name="functionBody">The implementation of the function.</param>
        /// <param name="argNames">The names of the arguments required by the function.</param>
        public Function(string functionBody, params string[] argNames) { }

        /// <summary>
        /// Gets the number of parameters expected by the function.
        /// </summary>
        [ScriptField]
        public extern int Length { get; }

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public extern object Apply(object instance);

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <param name="arguments">The set of arguments to pass in into the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public extern object Apply(object instance, object[] arguments);

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public extern object Call(object instance);

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <param name="arguments">One or more arguments to pass in into the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public extern object Call(object instance, params object[] arguments);

        public extern static explicit operator Type(Function f);
    }
}
