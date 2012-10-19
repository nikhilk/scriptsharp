// Function.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Function type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Function {

        /// <summary>
        /// Creates a new function with the specified implementation.
        /// </summary>
        /// <param name="functionBody">The implementation of the function.</param>
        public Function(string functionBody) {
        }

        /// <summary>
        /// Creates a new function with the specified implementation, and the
        /// set of named parameters.
        /// </summary>
        /// <param name="functionBody">The implementation of the function.</param>
        /// <param name="argNames">The names of the arguments required by the function.</param>
        public Function(string functionBody, params string[] argNames) {
        }

        /// <summary>
        /// Gets the number of parameters expected by the function.
        /// </summary>
        [ScriptField]
        public int Length {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public object Apply(object instance) {
            return null;
        }

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <param name="arguments">The set of arguments to pass in into the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public object Apply(object instance, object[] arguments) {
            return null;
        }

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public object Call(object instance) {
            return null;
        }

        /// <summary>
        /// Invokes the function against the specified object instance.
        /// </summary>
        /// <param name="instance">The object used as the value of 'this' within the function.</param>
        /// <param name="arguments">One or more arguments to pass in into the function.</param>
        /// <returns>Any return value returned from the function.</returns>
        public object Call(object instance, params object[] arguments) {
            return null;
        }

        public static explicit operator Type(Function f) {
            return null;
        }
    }
}
