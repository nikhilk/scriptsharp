// Type.cs
// Script#/Libraries/CoreLib
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// The Type data type which is mapped to the Function type in Javascript.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    public sealed class Type {

        [ScriptName("$base")]
        [ScriptField]
        public Type BaseType {
            get {
                return null;
            }
        }

        public string Name {
            get {
                return null;
            }
        }

        /// <summary>
        /// Gets the prototype associated with the type.
        /// </summary>
        [ScriptField]
        public Dictionary Prototype {
            get {
                return null;
            }
        }

        [ScriptAlias("ss.type")]
        public static Type GetType(string typeName) {
            return null;
        }

        [ScriptAlias("ss.canAssign")]
        public bool IsAssignableFrom(Type type) {
            return false;
        }

        [ScriptAlias("ss.isClass")]
        public static bool IsClass(Type type) {
            return false;
        }

        [ScriptAlias("ss.isInterface")]
        public static bool IsInterface(Type type) {
            return false;
        }

        [ScriptAlias("ss.instanceOf")]
        public bool IsInstanceOfType(object instance) {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Type GetTypeFromHandle(RuntimeTypeHandle typeHandle) {
            return null;
        }
    }
}
