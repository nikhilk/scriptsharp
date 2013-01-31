// GraphNode.cs
// Script#/Libraries/Node/Neo4J
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.Neo4J {

    /// <summary>
    /// The class corresponding to a Neo4j node.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Node")]
    public sealed class GraphNode : GraphPropertyContainer {

        private GraphNode() {
        }

        /// <summary>
        /// Persist or update this node in the database.
        /// </summary>
        /// <param name="callback">Returns (via callback) this same Node instance after the save.</param>
        public void Save(AsyncResultCallback<GraphNode> callback) {
        }

        /// <summary>
        /// Delete this node from the database. This will throw an error if this node has any relationships on it, unless the 
        /// force flag is passed in, in which case those relationships are also deleted.
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="force">If this node has any relationships on it, whether those relationships should be deleted as well. Note: For safety, it's recommended to not pass the force flag and instead manually and explicitly delete known relationships beforehand.</param>
        public void Delete(AsyncResultCallback<GraphNode> callback, bool force) {
        }

        /// <summary>
        /// Add this node to the given index under the given key-value pair.
        /// </summary>
        /// <param name="index">The name of the index, e.g. 'users'.</param>
        /// <param name="key">The key to index under, e.g. 'username'</param>
        /// <param name="value">The value to index under, e.g. 'aseemk'.</param>
        /// <param name="callback"></param>
        public void Index(string index, string key, object value, AsyncResultCallback<GraphNode> callback) {
        }

        /// <summary>
        /// Create and "return" (via callback) a relationship of the given type and with the given properties from this node to another node.
        /// </summary>
        /// <param name="otherNode">Node to create a relationship to</param>
        /// <param name="type">Type of relationship</param>
        /// <param name="data">The properties this relationship should have.</param>
        /// <param name="callback">Returns a Relationship</param>
        public void CreateRelationshipTo(GraphNode otherNode, string type, Dictionary<string, object> data, AsyncResultCallback<GraphRelationship> callback) {
        }

        /// <summary>
        /// Create and "return" (via callback) a relationship of the given type and with the given properties from another node to this node.
        /// </summary>
        /// <param name="otherNode">Node to create a relationship to</param>
        /// <param name="type">Type of relationship</param>
        /// <param name="data">The properties this relationship should have.</param>
        /// <param name="callback">Returns a Relationship</param>
        /// <returns></returns>
        public void CreateRelationshipFrom(GraphNode otherNode, string type, Dictionary<string, object> data, AsyncResultCallback<GraphRelationship> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the relationships of the given type or types from or to this node.
        /// </summary>
        /// <param name="types">The types of Relationships to return</param>
        /// <param name="callback">Returns a list of Relationships</param>
        /// <returns></returns>
        public void GetRelationships(List<string> types, AsyncResultCallback<List<GraphRelationship>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the relationships of the given type or types from this node.
        /// </summary>
        /// <param name="types">The types of outgoing Relationships</param>
        /// <param name="callback">Returns a list of Relationships</param>
        /// <returns></returns>
        public void Outgoing(List<string> types, AsyncResultCallback<List<GraphRelationship>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the Relationships of the given type or types to this node.
        /// </summary>
        /// <param name="types">The types of incoming Relationships</param>
        /// <param name="callback">Returns a list of Relationships</param>
        /// <returns></returns>
        public void Incoming(List<string> types, AsyncResultCallback<List<GraphRelationship>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the Relationships of the given type or types from or to this node.
        /// </summary>
        /// <param name="types">The types of incoming or outgoing Relationships</param>
        /// <param name="callback">Returns a list of Relationships</param>
        public void All(List<string> types, AsyncResultCallback<List<GraphRelationship>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the nodes adjacent to this one following only relationships of the given type(s) and/or direction(s).
        /// </summary>
        /// <param name="rels">It can be an array of string types, e.g. ['likes', 'loves'].</param>
        /// <param name="callback">Returns a list of Nodes</param>
        public void GetRelationshipNodes(List<String> rels, AsyncResultCallback<List<GraphNode>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the shortest path, if there is one, from this node to the given node. Returns null if no path exists.
        /// </summary>
        /// <param name="to">Destination node to find the shortest path to</param>
        /// <param name="type">The type of relationship to follow.</param>
        /// <param name="direction">One of 'in', 'out', or 'all'.</param>
        /// <param name="maxDepth">The maximum number of relationships to follow when searching for paths. The default is 1.</param>
        /// <param name="algorithm">This needs to be 'shortestPath' for now.</param>
        /// <param name="callback">Returns a <see cref="Path"/></param>
        public void Path(GraphNode to, string type, string direction, Int32 maxDepth, string algorithm, AsyncResultCallback<GraphPath> callback) {
        }
    }
}
