// GraphEdge.cs
//

using System;

namespace AroundMe.Graphs {

    internal class GraphEdge {

        private GraphNode _fromNode;
        private GraphNode _toNode;
        private int _length;

        public GraphEdge(GraphNode fromNode, GraphNode toNode, int length) {
            _fromNode = fromNode;
            _toNode = toNode;
            _length = length;
        }

        public GraphNode FromNode {
            get {
                return _fromNode;
            }
        }

        public int Length {
            get {
                return _length;
            }
        }

        public GraphNode ToNode {
            get {
                return _toNode;
            }
        }
    }
}
