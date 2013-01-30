// Neo4JGraph.cs
// Script#/Libraries/Node/Neo4J
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.Neo4J {

    /// <summary>
    /// The class corresponding to a Neo4j graph database. Start here.
    /// </summary>
    //[ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("GraphDatabase")]
    public class Neo4JGraph {

        /// <summary>
        /// Construct a new client for the Neo4j graph database available at the given (root) URL.
        /// </summary>
        /// <param name="url">The root URL where the Neo4j graph database is available, e.g. 'http://localhost:7474/'. This URL should include HTTP Basic Authentication info if needed, e.g. 'http://user:password@example.com/'.</param>
        /// <example><code>Neo4JGraph db = new Neo4JGraph("http://localhost:7474");</code></example>
        public Neo4JGraph(string url) {
        }

        /// <summary>
        /// Construct a new client for the Neo4j graph database available at the given (root) URL. 
        /// </summary>
        /// <param name="opts">
        /// <para>url</para>: The root URL where the Neo4j graph database is available, e.g. 'http://localhost:7474/'. This URL should include HTTP Basic Authentication info if needed, e.g. 'http://user:password@example.com/'.
        /// <para>proxy</para>: An optional proxy URL for all requests.
        /// </param>
        /// <example><code>Neo4JGraph db = new Neo4JGraph(new Dictionary("url", "http://localhost:7474"));</code></example>
        public Neo4JGraph(Dictionary<string, object> opts) {
        }

        /// <summary>
        /// Create and immediately return a new, unsaved node with the given properties.
        /// Note: This node will not be persisted to the database until and unless its save() method is called.
        /// </summary>
        /// <param name="data">The properties this new node should have.</param>
        /// <returns>Node</returns>
        public Neo4JNode CreateNode(Dictionary<string, object> data) {
            return null;
        }

        /// <summary>
        /// Execute and "return" (via callback) the results of the given Gremlin script, optionally passing along the given script parameters 
        /// (recommended to avoid Gremlin injection security vulnerabilities). Any values in the returned results that represent nodes, relationships 
        /// or paths are returned as <see cref="Neo4JNode"/>, <see cref="Neo4JRelationship"/> or <see cref="Neo4JPath"/> instances.
        /// </summary>
        /// <param name="script">The Gremlin script. Can be multi-line.</param>
        /// <param name="parameters">A map of parameters for the Gremlin script.</param>
        /// <param name="callback">Returns List&lt;object&gt;</param>
        /// <example>
        /// <code>
        ///     var script = "g.v(userId).out('likes')";
        ///
        ///     var params = {
        ///       userId: currentUser.id
        ///     };
        ///
        ///     db.execute(script, params, function (err, likes) {
        ///       if (err) throw err;
        ///       likes.forEach(function (node) {
        ///         // ...
        ///        });
        ///     });
        /// </code>
        /// </example>
        public void Execute(string script, Dictionary<string, object> parameters, Action<object, List<object>> callback) {
        }
        
        /// <summary>
        /// Fetch and "return" (via callback) the node indexed under the given property and value in the given index. If none exists, returns undefined.
        /// Note: With this method, at most one node is returned. See <see cref="GetIndexedNodes"/> for returning multiple nodes.
        /// </summary>
        /// <param name="index">The name of the index, e.g. 'node_auto_index'.</param>
        /// <param name="property">The name of the property, e.g. 'username'.</param>
        /// <param name="value">The value of the property, e.g. 'aseemk'.</param>
        /// <param name="callback">Returns Node</param>
        public void GetIndexedNode(string index, string property, object value, Action<object, Neo4JNode> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the nodes indexed under the given property and value in the given index. If no such nodes exist, an empty array is returned.
        /// Note: This method will return multiple nodes if there are multiple hits. See #getIndexedNode for returning at most one node.
        /// </summary>
        /// <param name="index">The name of the index, e.g. 'node_auto_index'.</param>
        /// <param name="property">The name of the property, e.g. 'platform'.</param>
        /// <param name="value">The value of the property, e.g. 'xbox'.</param>
        /// <param name="callback">Returns List&lt;Node&gt;</param>
        public void GetIndexedNodes(string index, string property, object value, Action<object, List<Neo4JNode>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the relationship indexed under the given property and value in the given index. If none exists, returns undefined.
        /// Note: With this method, at most one relationship is returned. See <see cref="GetIndexedRelationships"/> for returning multiple relationships.
        /// </summary>
        /// <param name="index">The name of the index, e.g. 'relationship_auto_index'.</param>
        /// <param name="property">The name of the property, e.g. 'created'.</param>
        /// <param name="value">The value of the property, e.g. 1346713658393.</param>
        /// <param name="callback">Returns Relationship</param>
        public void GetIndexedRelationship(string index, string property, object value, Action<object, Neo4JRelationship> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the relationships indexed under the given property and value in the given index. If no such 
        /// relationships exist, an empty array is returned.
        /// Note: This method will return multiple relationships if there are multiple hits. See <see cref="GetIndexedRelationship"/> for returning at most one relationship.
        /// </summary>
        /// <param name="index">The name of the index, e.g. 'relationship_auto_index'.</param>
        /// <param name="property">The name of the property, e.g. 'favorite'.</param>
        /// <param name="value">The value of the property, e.g. true.</param>
        /// <param name="callback">Returns List&lt;Relationship&gt;</param>
        public void GetIndexedRelationships(string index, string property, object value, Action<object, List<Neo4JRelationship>> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the node with the given Neo4j ID.
        /// </summary>
        /// <param name="id">The integer ID of the node: <example>1234</example></param>
        /// <param name="callback">Returns Node</param>
        /// <exception>If no node exists with this ID.</exception>
        public void GetNodeById(int id, Action<object, Neo4JNode> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the relationship with the given Neo4j ID.
        /// </summary>
        /// <param name="id">The integer ID of the relationship, e.g. 1234.</param>
        /// <param name="callback">Returns Relationship</param>
        public void GetRelationshipById(int id, Action<object, Neo4JRelationship> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the Neo4j version as a float.
        /// </summary>
        /// <param name="callback">Returns Number</param>
        public void GetVersion(Action<object, long> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the results of the given Cypher query, optionally passing along the given query parameters 
        /// (recommended to avoid Cypher injection security vulnerabilities). The returned results are an array of "rows" (matches), 
        /// where each row is a map from key name (as given in the query) to value. Any values that represent nodes, relationships or 
        /// paths are returned as <see cref="Neo4JNode"/>, <see cref="Neo4JRelationship"/> or <see cref="Neo4JPath"/> instances.
        /// </summary>
        /// <param name="query">The Cypher query. Can be multi-line.</param>
        /// <param name="parameters">A map of parameters for the Cypher query.</param>
        /// <param name="callback">Returns List&lt;object&gt;</param>
        /// <example>
        /// <code>
        ///      var query = [
        ///       'START user=node({userId})',
        ///       'MATCH (user) -[:likes]-> (other)',
        ///       'RETURN other'
        ///     ].join('\n');
        ///     
        ///     var params = {
        ///       userId: currentUser.id
        ///     };
        ///     
        ///     db.query(query, params, function (err, results) {
        ///       if (err) throw err;
        ///       var likes = results.map(function (result) {
        ///         return result['other'];
        ///       });
        ///       // ...
        ///     });
        /// </code>
        /// </example>
        public void Query(string query, Dictionary<string, object> parameters, Action<object, object> callback) {
        }

        /// <summary>
        /// Fetch and "return" (via callback) the nodes matching the given query (in Lucene syntax) from the given index. If no such nodes exist, an empty array is returned.
        /// </summary>
        /// <param name="index">The name of the index, e.g. node_auto_index.</param>
        /// <param name="query">The Lucene query, e.g. foo:bar AND hello:world.</param>
        /// <param name="callback">Returns List&lt;Node&gt;</param>
        public void QueryNodeIndex(string index, string query, Action<object, List<Neo4JNode>> callback) {
        }
    }
}
