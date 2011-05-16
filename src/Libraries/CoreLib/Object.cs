// Object.cs
// Script#/Libraries/CoreLib
// Copyright (c) Nikhil Kothari.
// Copyright (c) Microsoft Corporation.
// This source code is subject to terms and conditions of the Microsoft 
// Public License. A copy of the license can be found in License.txt.
//

using System.Runtime.CompilerServices;

namespace System {

    /// <summary>
    /// Equivalent to the Object type in Javascript.
    /// </summary>
    [IgnoreNamespace]
    [Imported]
    public class Object {

        /// <summary>
        /// Retrieves the type associated with an object instance.
        /// </summary>
        /// <returns>The type of the object.</returns>
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
