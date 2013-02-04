// GraphPropertyContainer.cs
// Script#/Libraries/Node/Neo4J
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.Neo4J {

    /// <summary>
    /// The abstract class corresponding to a Neo4j property container.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("PropertyContainer")]
    public abstract class GraphPropertyContainer {

        internal GraphPropertyContainer() {
        }

        /// <summary>
        /// Whether this property container exists in (has been persisted to) the Neo4j database.
        /// </summary>
        [ScriptField]
        public bool Exists {
            get {
                return false;
            }
        }

        /// <summary>
        /// This property container's properties. This is a map of key-value pairs.
        /// </summary>
        [ScriptField]
        public Dictionary<string, object> Data {
            get {
                return null;
            }
        }

        /// <summary>
        /// If this property container exists, its Neo4j integer ID.
        /// </summary>
        [ScriptField]
        public int Id {
            get {
                return -1;
            }
        }

        /// <summary>
        /// The URL of this property container.
        /// </summary>
        [ScriptField]
        public string Self {
            get {
                return string.Empty;
            }
        }
        
        /// <summary>
        /// A convenience alias for <seealso cref="Delete"/> since delete is a reserved keyword in JavaScript.
        /// </summary>
        public void Del() {
        }
        
        /// <summary>
        /// Delete this property container from the database.
        /// </summary>
        /// <param name="callback">Callback function to execute when the delete operation is complete</param>
        public void Delete(AsyncResultCallback<object> callback) {
        }

        /// <summary>
        /// Test whether the given object represents the same property container as this one. They can be separate instances with separate data.
        /// </summary>
        /// <param name="other">Object to compare for equality</param>
        /// <returns>True if equal</returns>
        public bool Equals(object other) {
            return false;
        }
    }
}
