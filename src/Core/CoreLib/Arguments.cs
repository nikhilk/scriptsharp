// Arguments.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Provides access to the arguments of the current function.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("arguments")]
    public static class Arguments {

        /// <summary>
        /// Retrieves the arguments list.
        /// </summary>
        /// <returns>The arguments list.</returns>
        [ScriptAlias("arguments")]
        [ScriptField]
        public static object[] Current {
            get {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the number of actual arguments passed to the function.
        /// </summary>
        /// <returns>The count of arguments.</returns>
        [ScriptField]
        public static int Length {
            get {
                return 0;
            }
        }

        /// <summary>
        /// Retrieves the specified actual argument value passed to the
        /// function by index.
        /// </summary>
        /// <param name="index">The index of the argument to retrieve.</param>
        /// <returns>The value of the specified argument.</returns>
        public static object GetArgument(int index) {
            return null;
        }

        /// <summary>
        /// Retrieves the specified actual argument value passed to the
        /// function by index.
        /// </summary>
        /// <param name="index">The index of the argument to retrieve.</param>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <returns>The value of the specified argument.</returns>
        public static T GetArgument<T>(int index) {
            return default(T);
        }

        [ScriptAlias("Array.toArray")]
        public static Array ToArray() {
            return null;
        }
    }
}
