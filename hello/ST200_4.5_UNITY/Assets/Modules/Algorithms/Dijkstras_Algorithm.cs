﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Dijkstras_Algorithm
{
	//source from - sourceforge.net/projects/dijkstra_csharp
	public class Edge
    {

        private float _cost;
        private Vector2D _pointA, _pointB;
        private static int EdgeIDSequencer = 0;
        private int _edgeID;


        #region Properties

        public int EdgeID
        {
            get
            {
                return _edgeID;
            }
        }

        public float Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

        public Vector2D PointA
        {
            get
            {
                return _pointA;
            }
        }

        public Vector2D PointB
        {
            get
            {
                return _pointB;
            }
        }

        #endregion

        public Edge(Vector2D firstPoint, Vector2D secondPoint, float cost)
        {
            _cost = cost;
            _pointA = firstPoint; _pointB = secondPoint;
            _edgeID = ++EdgeIDSequencer;
        }

        public Vector2D GetTheOtherVertex(Vector2D baseVertex) {
            if (baseVertex == _pointA)
            {
                return _pointB;
            }
            else if (baseVertex == _pointB)
            {
                return _pointA;
            }
            else
            {
                // somehow the base vertex doesn't equal to either point A or B
                return null;
            }
        }

        public override string ToString()
        {
            return "Edge ID: " + _edgeID.ToString() 
                + "; Connected to vertices " + _pointA.VertexID + " and "
                + _pointB.VertexID + " at a cost of " + _cost;
        }
    }

	public class Vector2D 
    {
        public const float INFINITY = -1f;
        private bool _deadend;
        private bool _visited;
        private static int VertexIDSequencer = 0;
        private int _vertexID;
        private float _aggregateCost;
        private Edge _edgeWithLowestCost;


        #region Properties

        public int VertexID
        {
            get
            
            {
                return _vertexID;
            }
        }

        public float AggregateCost
        {
            get
            {
                return _aggregateCost;
            }
            set
            {
                _aggregateCost = value;
            }
        }


        public bool Deadend
        {
            get
            {
                return _deadend;
            }
        }

        public bool Visited
        {
            get
            {
                return _visited;
            }
            set
            {
                _visited = value;
            }
        }

        // Internal members
        internal Edge EdgeWithLowestCost
        {
            get
            {
                return _edgeWithLowestCost;
            }
            set
            {
                _edgeWithLowestCost = value;
            }
        }

        #endregion 

        public Vector2D(int index, bool deadend)
        {
            _visited = false;
            _deadend = deadend;
            _aggregateCost = INFINITY;
			_vertexID = index;
            _edgeWithLowestCost = null;
        }

        public override string ToString()
        {
            return "Vertex ID: " + _vertexID; // + "; Coords: X=" + _xCoord + ", Y=" + _yCoord;
        }
    }

    public class Graph
    {
        private Vector2D _sourceNode;
        private List<Vector2D> _listOfNodes;
        private List<Edge> _listOfEdges;

        #region Properties

        public List<Vector2D> AllNodes
        {
            get { return _listOfNodes; }
        }

        // Read-Write properties
        public Vector2D SourceVertex
        {
            get {
                return _sourceNode;
            } 
            set 
            {
                // SourceVertex is only valid if it is found in the graph.
                // Do not make any changes otherwise.
                for (int i = 0; i < _listOfNodes.Count; i++)
                {
                    if (_listOfNodes[i] == value)
                    {
                        _sourceNode = value;
                        break;
                    }
                }
            }
        }

		public int SourceVertexIndex
		{
			get
			{
				if(_sourceNode == null)
				{
					return -1;
				}else
				{
					return _sourceNode.VertexID;
				}
			}
			set
			{
				for (int i = 0; i < _listOfNodes.Count; i++)
				{
					if (_listOfNodes[i].VertexID == value)
					{
						_sourceNode = _listOfNodes[i];
						break;
					}
				}
			}
		}

        #endregion

        public Graph()
        {
            _listOfEdges = new List<Edge>();
            _listOfNodes = new List<Vector2D>();

            _sourceNode = null; //_targetNode = null;

            //_totalCost = -1;
            //_optimalTraversal = new List<Vector2D>();
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Edge edge) {
            _listOfEdges.Add(edge);

            // Reset stats due to a change to the graph.
            this.Reset();
        }

        /// <summary>
        /// Adds a vertex to the graph.
        /// </summary>
        /// <param name="node"></param>
        public void AddVertex(Vector2D node)
        {
            _listOfNodes.Add(node);

            // Reset stats due to a change to the graph.
            this.Reset();
        }

        /// <summary>
        /// As the name suggests, this method calculates the shortest path between the source and target node.
        /// If successful, it updates the TotalCost and the OptimalPath properties with the corresponding values.
        /// </summary>
        /// <returns>Success/Failure</returns>
        public bool CalculateShortestPath()
        {
            bool destUnreachable = false;

            if (_sourceNode == null) // || _targetNode == null)
            {
                return false;
            }

            // Algorithm starts here

            // Reset stats
            this.Reset();

            // Set the cost on the source node to 0 and flag it as visited
            _sourceNode.AggregateCost = 0;

            
            // if the targetnode is not the sourcenode
            // if (_targetNode.AggregateCost == Vector2D.INFINITY) {
                // Start the traversal across the graph
            this.PerformCalculationForAllNodes();
            //}
            

            //_totalCost = _targetNode.AggregateCost;


            if (destUnreachable)
            {
                return false;
            }

            return true;
        }

        public List<Vector2D> RetrieveShortestPath(int targetNodeindex)
        {
            List<Vector2D> shortestPath = new List<Vector2D>();

	        Vector2D currentNode = null;
			for(int i = 0; i < _listOfNodes.Count; i++)
		    {
				if(_listOfNodes[i].VertexID == targetNodeindex)
				{
					currentNode = _listOfNodes[i];
				}
			}

	        shortestPath.Add(currentNode);

	        while (currentNode.EdgeWithLowestCost != null)
	        {
	            currentNode = currentNode.EdgeWithLowestCost.GetTheOtherVertex(currentNode);
	            shortestPath.Add(currentNode);
	        }

            // reverse the order of the nodes, because we started from target node first
            shortestPath.Reverse();

            return shortestPath;
        }

        public List<Edge> GetConnectedEdges(Vector2D startNode)
        {
            List<Edge> connectedEdges = new List<Edge>();

            for (int i = 0; i < _listOfEdges.Count; i++)
            {
                if (_listOfEdges[i].GetTheOtherVertex(startNode) != null &&
                    !_listOfEdges[i].GetTheOtherVertex(startNode).Visited)
                {
                    connectedEdges.Add((Edge)_listOfEdges[i]);
                }
            }

            return connectedEdges;
        }

		public List<Edge> GetEdges()
		{
			List<Edge> connectedEdges = new List<Edge>();
			
			for (int i = 0; i < _listOfEdges.Count; i++)
			{
				if (_listOfEdges[i].PointA != null && _listOfEdges[i].PointB != null)				    
				{
					connectedEdges.Add((Edge)_listOfEdges[i]);
				}
			}
			
			return connectedEdges;
		}


        /// <summary>
        /// Resets the costs from this instance.
        /// </summary>
        private void Reset()
        {
            // reset visited flag and reset the aggregate cost on all nodes
            for (int i = 0; i < _listOfNodes.Count; i++)
            {
                // The current node is now considered visited
                _listOfNodes[i].Visited = false;
                _listOfNodes[i].AggregateCost = Vector2D.INFINITY;
                _listOfNodes[i].EdgeWithLowestCost = null;
            }
        }

        private List<Vector2D> GetAListOfVisitedNodes()
        {
            List<Vector2D> listOfVisitedNodes = new List<Vector2D>();

            foreach (Vector2D node in _listOfNodes)
            {
                if (node.Visited) {
                    listOfVisitedNodes.Add(node);
                }
            }

            return listOfVisitedNodes;
        }

        private void PerformCalculationForAllNodes()
        {
            Vector2D currentNode = _sourceNode;

            // Start by marking the source node as visited
            currentNode.Visited = true;

            do
            {
                Vector2D nextBestNode = null;

                // Retrieve a list of all visited nodes and for each node, get a list of all edges
                // that are not connected to visited nodes and update the aggregate cost on these other nodes.
                foreach (Vector2D visitedNode in this.GetAListOfVisitedNodes())
                {
                    foreach (Edge connectedEdge in this.GetConnectedEdges(visitedNode))
                    {
                        // Only update if the aggregate cost on the other node is infinite 
                        // or is greater and equal to the aggregate cost on the current visited node.
                        if (connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost == Vector2D.INFINITY
                            || (visitedNode.AggregateCost + connectedEdge.Cost) < connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost)
                        {
                            connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost = visitedNode.AggregateCost + connectedEdge.Cost;

                            // update the pointer to the edge with the lowest cost in the other node
                            connectedEdge.GetTheOtherVertex(visitedNode).EdgeWithLowestCost = connectedEdge;
                        }


                        if (nextBestNode == null || connectedEdge.GetTheOtherVertex(visitedNode).AggregateCost < nextBestNode.AggregateCost)
                        {
                            nextBestNode = connectedEdge.GetTheOtherVertex(visitedNode);
                        }
                    }


                }

                // Move the currentNode onto the next optimal node.
                currentNode = nextBestNode;

                // Now set the visited property of the current node to true
                currentNode.Visited = true;

            } while (this.MoreVisitedNodes()); // Loop until every node's been visited.
        }

        private bool MoreVisitedNodes()
        {
            return GetAListOfVisitedNodes().Count < _listOfNodes.Count;
        }
    }
}
