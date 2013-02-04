// GraphPath.cs
// Script#/Libraries/Node/Neo4J
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NodeApi.Neo4J {

    /// <summary>
    /// The class corresponding to a Neo4j path.
    /// </summary>
    [ScriptIgnoreNamespace]
    [ScriptImport]
    [ScriptName("Path")]
    public sealed class GraphPath {

        private GraphPath() {
        }

        /// <summary>
        /// The node that this path ends at.
        /// </summary>
        [ScriptField]
        public GraphNode End {
            get {
                return null;
            }
        }

        /// <summary>
        /// The length of this path
        /// </summary>
        [ScriptField]
        public int Length {
            get {
                return -1;
            }
        }

        /// <summary>
        /// The nodes that make up this path.
        /// </summary>
        [ScriptField]
        public List<GraphNode> Nodes {
            get {
                return null;
            }
        }
        
        /// <summary>
        /// The relationships that make up this path.
        /// </summary>
        [ScriptField]
        public List<GraphRelationship> Relationships {
            get {
                return null;
            }
        }

        /// <summary>
        /// The node that this path starts at.
        /// </summary>
        [ScriptField]
        public GraphNode Start {
            get {
                return null;
            }
        }
    }
}
