// GraphNode.cs
//

using System;
using System.Collections.Generic;

namespace AroundMe.Graphs {

	internal class GraphNode {

        private List<GraphEdge> _edges;

        public double x;
        public double y;
        internal double dx;
        internal double dy;
        public bool moveable;

		public GraphNode() {
            _edges = new List<GraphEdge>();
            moveable = true;
		}

        public List<GraphEdge> Edges {
            get {
                return _edges;
            }
        }

        internal void AddEdge(GraphEdge edge) {
            _edges.Add(edge);
        }

        internal void ClearEdges() {
            _edges.Clear();
        }

        internal void RemoveEdge(GraphEdge edge) {
            _edges.Remove(edge);
        }
	}
}
