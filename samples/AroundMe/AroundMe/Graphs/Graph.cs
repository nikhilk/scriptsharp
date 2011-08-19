// Graph.cs
//

using System;
using System.Collections.Generic;

namespace AroundMe.Graphs {

    internal delegate void GraphNodePairVisitor(GraphNode node1, GraphNode node2);

    internal delegate void GraphNodeVisitor(GraphNode node);

    internal delegate void GraphEdgeVisitor(GraphEdge edge);

    internal class Graph {

        private List<GraphNode> _nodes;
        private List<GraphEdge> _edges;

        private GraphLayout _layout;

        private bool _updating;
        private bool _updated;

        public Graph() {
            _nodes = new List<GraphNode>();
            _edges = new List<GraphEdge>();
            _layout = new GraphLayout(this);
        }

        public GraphLayout Layout {
            get {
                return _layout;
            }
        }

        public List<GraphNode> Nodes {
            get {
                return _nodes;
            }
        }

        public List<GraphEdge> Edges {
            get {
                return _edges;
            }
        }

        public event EventHandler Changed;

        public void AddNode(GraphNode node) {
            _nodes.Add(node);
            if (_updating == false) {
                RaiseChangedEvent();
            }
            else {
                _updated = true;
            }
        }

        public void AddEdge(GraphEdge edge) {
            _edges.Add(edge);
            edge.FromNode.AddEdge(edge);
            edge.ToNode.AddEdge(edge);

            if (_updating == false) {
                RaiseChangedEvent();
            }
            else {
                _updated = true;
            }
        }

        public void BeginUpdate() {
            _updating = true;
        }

        public void EndUpdate() {
            _updating = false;
            if (_updated) {
                _updated = false;
                RaiseChangedEvent();
            }
        }

        private void RaiseChangedEvent() {
            if (Changed != null) {
                Changed(this, EventArgs.Empty);
            }
        }

        public void RemoveNode(GraphNode node) {
            foreach (GraphEdge edge in node.Edges) {
                RemoveEdge(edge);
            }

            _nodes.Remove(node);
            if (_updating == false) {
                RaiseChangedEvent();
            }
            else {
                _updated = true;
            }
        }

        public void RemoveEdge(GraphEdge edge) {
            edge.FromNode.RemoveEdge(edge);
            edge.ToNode.RemoveEdge(edge);

            _edges.Remove(edge);
            if (_updating == false) {
                RaiseChangedEvent();
            }
            else {
                _updated = true;
            }
        }

        public void Reset() {
            _nodes.Clear();
            _edges.Clear();
            if (_updating == false) {
                RaiseChangedEvent();
            }
            else {
                _updated = true;
            }
        }

        public void VisitEdges(GraphEdgeVisitor visitor) {
            foreach (GraphEdge edge in _edges) {
                visitor(edge);
            }
        }

        public void VisitNodes(GraphNodeVisitor visitor) {
            foreach (GraphNode node in _nodes) {
                visitor(node);
            }
        }

        public void VisitNodePairs(GraphNodePairVisitor visitor) {
            foreach (GraphNode n1 in _nodes) {
                foreach (GraphNode n2 in _nodes) {
                    if (n1 != n2) {
                        visitor(n1, n2);
                    }
                }
            }
        }
    }
}
