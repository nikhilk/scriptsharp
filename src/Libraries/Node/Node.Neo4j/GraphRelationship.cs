// GraphRelationship.cs
// Script#/Libraries/Node/Neo4J
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;

namespace NodeApi.Neo4j {

    /// <summary>
    /// The class corresponding to a Neo4j relationship.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Relationship")]
    public sealed class GraphRelationship : GraphPropertyContainer {

        private GraphRelationship() {
        }

        /// <summary>
        /// The node this relationship goes to.
        /// </summary>
        [ScriptField]
        public GraphNode End {
            get {
                return null;
            }
        }

        /// <summary>
        /// The node this relationship goes from.
        /// </summary>
        [ScriptField]
        public GraphNode Start {
            get {
                return null;
            }
        }

        /// <summary>
        /// This relationship's type.
        /// </summary>
        [ScriptField]
        public string Type {
            get {
                return String.Empty;
            }
        }

        /// <summary>
        /// Add this relationship to the given relationship index under the given property key and value.
        /// </summary>
        /// <param name="index">The name of the index, e.g. 'likes'.</param>
        /// <param name="key">The property key to index under, e.g. 'created'.</param>
        /// <param name="value">The property value to index under, e.g. 1346713658393.</param>
        /// <param name="callback"></param>
        public void Index(string index, string key, object value, AsyncResultCallback<GraphNode> callback) {
        }

        /// <summary>
        /// Persist or update this relationship in the database. "Returns" (via callback) this same instance after the save.
        /// </summary>
        /// <param name="callback">Returns a Relationship</param>
        public void Save(AsyncResultCallback<GraphRelationship> callback) {
        }
    }
}
