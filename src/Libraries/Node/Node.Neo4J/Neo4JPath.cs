// Neo4JPath.cs
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
    public sealed class Neo4JPath {

        private Neo4JPath() {
        }

        /// <summary>
        /// The node that this path ends at.
        /// </summary>
        [ScriptField]
        public Neo4JNode End {
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
        public List<Neo4JNode> Nodes {
            get {
                return null;
            }
        }
        
        /// <summary>
        /// The relationships that make up this path.
        /// </summary>
        [ScriptField]
        public List<Neo4JRelationship> Relationships {
            get {
                return null;
            }
        }

        /// <summary>
        /// The node that this path starts at.
        /// </summary>
        [ScriptField]
        public Neo4JNode Start {
            get {
                return null;
            }
        }
    }
}
