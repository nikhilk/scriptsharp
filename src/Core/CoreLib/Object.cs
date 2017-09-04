// Object.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Object type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public class Object {

        [ScriptName("name")]
        public const string NAME_DEFINITION = "Object";

        /// <summary>
        /// Retrieves the type associated with an object instance.
        /// </summary>
        /// <returns>The type of the object.</returns>
        [ScriptAlias("ss.typeOf")]
        public Type GetType() {
            return null;
        }

        /// <summary>
        /// Converts an object to its string representation.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public virtual string ToString() {
            return null;
        }

        /// <summary>
        /// Converts an object to its culture-sensitive string representation.
        /// </summary>
        /// <returns>The culture-sensitive string representation of the object.</returns>
        public virtual string ToLocaleString() {
            return null;
        }
    }
}
