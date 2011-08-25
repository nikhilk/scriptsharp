// GraphLayout.cs
//

using System;
using System.Diagnostics;

namespace AroundMe.Graphs {

    internal sealed class GraphLayout {

        internal const double RepulsionFactor = 0.75f;
        internal const double DefaultRepulsion = 100.0f;
        private const double MotionLimit = 0.01f;

        private Graph _graph;

        private double _damper;
        private bool _damping;
        private double _rigidity;
        private double _newRigidity;
        private double _maxMotion;
        private double _lastMaxMotion;
        private double _intermediateMaxMotion;

        // lastMaxMotion / maxMotion-1
        private double _motionRatio;

        public GraphLayout(Graph graph) {
            _graph = graph;

            // A low damper value causes the graph to move slowly; as
            // layout proceeds, the damper value decreases.
            _damper = 1.0f;
            _damping = true;

            // Rigidity has the same effect as the damper, except that it's a constant.
            // A low rigidity value causes things to go slowly.
            // A value that's too high will cause oscillation.
            _rigidity = 0.25f;
            _newRigidity = 0.25f;

            // Allow's tracking the fastest moving node to see if the graph is stabilizing
            _maxMotion = 0;
            _lastMaxMotion = 0;
            _motionRatio = 0;
            _intermediateMaxMotion = 0;
        }

        private void LayoutNode(GraphNode node) {
            if (node.moveable) {
                double dx = node.dx;
                double dy = node.dy;

                // The damper slows things down.  It cuts down jiggling at the last moment, and optimizes
                // layout. As an experiment, get rid of the damper in these lines, and make a
                // long straight line of nodes. It wiggles too much and doesn't straighten out.
                dx *= _damper;
                dy *= _damper;

                // Slow down, but dont stop. Nodes in motion store momentum. This helps when the force
                // on a node is very low, but you still want to get optimal layout.
                node.dx = dx / 2;
                node.dy = dy / 2;

                // How far did the node actually move?
                double distanceMoved = Math.Sqrt(dx * dx + dy * dy);

                // Don't move faster then 30 units at a time.
                // Stops severed nodes from flying away?

                node.x = node.x + Math.Max(-30, Math.Min(30, dx));
                node.y = node.y + Math.Max(-30, Math.Min(30, dy));

                _intermediateMaxMotion = Math.Max(distanceMoved, _intermediateMaxMotion);
            }
        }

        private void LayoutNodes() {
            _lastMaxMotion = _maxMotion;
            _intermediateMaxMotion = 0f;
            _graph.VisitNodes(new GraphNodeVisitor(LayoutNode));
            _maxMotion = _intermediateMaxMotion;

            if (_maxMotion > 0) {
                // Subtract 1 to make a positive value that implies that
                // things are moving faster
                _motionRatio = _lastMaxMotion / _maxMotion - 1;
            }
            else {
                _motionRatio = 0;
            }

            if (_damping) {
                if (_motionRatio <= 0.001) {
                    // Only damp when the graph starts to move faster
                    // When there is noise, you damp roughly half the time. (Which is a lot)
                    // If things are slowing down, then you can let them do so on their own,
                    // without damping.

                    if ((_maxMotion < 0.2 || (_maxMotion > 1 && _damper < 0.9)) &&
                        (_damper > 0.01)) {
                        // If maxMotion < 0.2, damp away
                        // If by the time the damper has gone down to 0.9, and
                        // maxMotion is still > 1, then damp away
                        // We never want the damper to be negative though.

                        _damper -= 0.01f;
                    }
                    else if (_maxMotion < 0.4 && _damper > 0.003) {
                        // If we've slowed down significanly, damp more aggresively
                        _damper -= 0.003f;
                    }
                    else if (_damper > 0.0001) {
                        // If max motion is pretty high, and we just started damping,
                        // then only damp slightly
                        _damper -= 0.0001f;
                    }
                }
            }
            if (_maxMotion < MotionLimit && _damping) {
                _damper = 0;
            }
        }

        public bool PerformLayout() {
            if (!(_damper < 0.1 && _damping && _maxMotion < MotionLimit)) {
                for (int i = 0; i < 5; i++) {
                    RelaxEdges();
                    RemoveOverlaps();
                    LayoutNodes();
                }

                if (_rigidity != _newRigidity) {
                    _rigidity = _newRigidity;
                }

                return true;
            }
            else {
                return false;
            }
        }

        public void PauseLayout() {
            _damping = false;
        }

        private void RelaxEdge(GraphEdge edge) {
            // Pull nodes closes together by 'relaxing' each edge

            double vx = edge.ToNode.x - edge.FromNode.x;
            double vy = edge.ToNode.y - edge.FromNode.y;
            double distance = Math.Sqrt(vx * vx + vy * vy);

            // Rigidity makes edges tighter
            double dx = vx * _rigidity;
            double dy = vy * _rigidity;

            int div = edge.Length * 100;
            dx = dx / div;
            dy = dy / div;

            // Edges pull directly in proportion to the distance between the nodes. This is good,
            // because we want the edges to be stretchy.  The edges are ideal rubberbands.  They
            // They don't become springs when they are too short. That only causes the graph to
            // oscillate.

            edge.ToNode.dx = edge.ToNode.dx - dx * distance;
            edge.ToNode.dy = edge.ToNode.dy - dy * distance;
            edge.FromNode.dx = edge.FromNode.dx + dx * distance;
            edge.FromNode.dy = edge.FromNode.dy + dy * distance;
        }

        private void RelaxEdges() {
            _graph.VisitEdges(new GraphEdgeVisitor(RelaxEdge));
        }

        private void RemoveOverlap(GraphNode node1, GraphNode node2) {
            double dx = 0;
            double dy = 0;
            double vx = node1.x - node2.x;
            double vy = node1.y - node2.y;
            double distance = vx * vx + vy * vy;

            // TODO: 36 should be a property instead of hardcoded
            // This is the radius of a node.

            if (distance < 36 * 36 * 2) {
                // If two nodes are right on top of each other, separate them
                // apart randomly
                dx = Math.Random();
                dy = Math.Random();
            }
            else if (distance < 360000) {
                // 600 * 600, because we don't want deleted nodes to fly too far away

                // If it was sqrt(len) then a single node surrounded by many others will
                // always look like a circle.  This might look good at first, but I think
                // it makes large graphs look ugly + it contributes to oscillation.  A
                // linear function does not fall off fast enough, so you get rough edges
                // in the 'force field'

                dx = vx / distance;
                dy = vy / distance;
            }

            double totalRepulsion = DefaultRepulsion * DefaultRepulsion / 100;
            double factor = totalRepulsion * _rigidity;

            node1.dx += dx * factor;
            node1.dy += dy * factor;
            node2.dx -= dx * factor;
            node2.dy -= dy * factor;
        }

        private void RemoveOverlaps() {
            _graph.VisitNodePairs(new GraphNodePairVisitor(RemoveOverlap));
        }

        public void ResetLayout() {
            _damping = true;
            _damper = 1.0f;
        }

        public void ResumeLayout() {
            _damping = true;
        }

        public void StopLayout() {
            _damping = false;
            _damper = 1.0f;
        }

        public void SlowLayout() {
            // Stabilize the graph, but do so gently by setting the damper
            // to a low value

            _damping = true;
            if (_damper > 0.3f) {
                _damper = 0.3f;
            }
            else {
                _damper = 0f;
            }
        }
    }
}
