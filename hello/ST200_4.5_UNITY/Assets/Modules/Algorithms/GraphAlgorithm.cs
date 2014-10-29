using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Dijkstras_Algorithm;


public class DijkstraGraphManager
{
	public Dijkstras_Algorithm.Graph DijkstraGraph = new Dijkstras_Algorithm.Graph();
	public List<DijkstraPathData> PathList = new List<DijkstraPathData>();

	public List<int> GetPath(int _startindex, int _endindex)
	{
		for(int i = 0; i < PathList.Count; i++)
		{
			DijkstraPathData pathdata = PathList[i];
			if(pathdata.GetStartIndex() == _startindex && pathdata.GetEndIndex() == _endindex)
			{
				return pathdata.PathIndexes;
			}
		}

		//find
		FindPath(_startindex, _endindex);
		return GetPath(_startindex, _endindex);
	}

	public void FindPath(int _startindex, int _endindex)
	{
		DijkstraGraph.SourceVertexIndex = _startindex;
		DijkstraGraph.CalculateShortestPath();
		List<Vector2D> getlist = DijkstraGraph.RetrieveShortestPath(_endindex);

		DijkstraPathData pathdata = new DijkstraPathData();
		for(int i = 0; i < getlist.Count; i++)
		{
			pathdata.PathIndexes.Add(getlist[i].VertexID);
		}
		PathList.Add(pathdata);
	}

	public void AddPoint(int _index)
	{
		Dijkstras_Algorithm.Vector2D data = new Dijkstras_Algorithm.Vector2D(_index, false);
		DijkstraGraph.AddVertex(data);
	}

	public void AddEdge(int _startindex, int _endindex, float _cost)
	{
		Dijkstras_Algorithm.Vector2D startpoint = null;
		Dijkstras_Algorithm.Vector2D endpoint = null;
		foreach(Dijkstras_Algorithm.Vector2D point in DijkstraGraph.AllNodes)
		{
			if(point.VertexID == _startindex)
			{
				startpoint = point;
			}else if(point.VertexID == _endindex)
			{
				endpoint = point;
			}
		}
		Dijkstras_Algorithm.Edge data = new Dijkstras_Algorithm.Edge(startpoint, endpoint, _cost);
		DijkstraGraph.AddEdge(data);
	}
}

public class DijkstraPathData
{
	public List<int> PathIndexes = new List<int>();

	public int GetStartIndex()
	{
		if(PathIndexes.Count > 0)
		{
			return PathIndexes[0];
		}
		return -1;
	}

	public int GetEndIndex()
	{
		if(PathIndexes.Count > 0)
		{
			return PathIndexes[PathIndexes.Count - 1];
		}
		return -1;
	}		
}

	/*
	public class GraphDijkstraAlgorithm
	{
		public List<GraphRoad> GraphRoadList = new List<GraphRoad>();
		public List<GraphNode> GraphNodeList = new List<GraphNode>();
		public List<GraphTraverse> GraphTraverseList = new List<GraphTraverse>();

		public GraphRoad GetGraphRoad(int _startindex, int _endindex)
		{
			for(int roadindex = 0; roadindex < GraphRoadList.Count; roadindex++)
			{
				GraphRoad road = GraphRoadList[roadindex];
				if(road.GetStartNode().Index == _startindex && road.GetEndNode().Index == _endindex)
				{
					return road;
				}
			}

			//find road
			return FindGraphRoad(_startindex, _endindex);
		}

		public GraphRoad FindGraphRoad(int _startindex, int _endindex)
		{
			//http://ko.wikipedia.org/wiki/%EB%8D%B0%EC%9D%B4%ED%81%AC%EC%8A%A4%ED%8A%B8%EB%9D%BC_%EC%95%8C%EA%B3%A0%EB%A6%AC%EC%A6%98
			GraphNode curnode = new GraphNode();
			GraphTreeNode roottreenode = new GraphTreeNode();

			for(int startnodeselect = 0; startnodeselect < GraphNodeList.Count; startnodeselect++)
			{
				if(GraphNodeList[startnodeselect].Index == _startindex)
				{
					curnode = GraphNodeList[startnodeselect];
					break;
				}
			}
			roottreenode.Index = curnode.Index;

			List<GraphNode> VisitiedNode = new List<GraphNode>();
			List<GraphNode> SetOfVertices = new List<GraphNode>(GraphNodeList);
			if(SetOfVertices.Contains(curnode))
			{
				Debug.Log("check");
				SetOfVertices.Remove(curnode);
			}
			Dictionary<int, float> Distances = new Dictionary<int, float>();
			for(int i = 0; i < SetOfVertices.Count; i++)
			{
				int startindex = curnode.Index;
				int endindex = SetOfVertices[i].Index;
				if(GetTraverseList(startindex, endindex).Index != 0)
				{
					Distances.Add(endindex, GetTraverseList(startindex, endindex).Value);
				}else
				{
					Distances.Add(endindex, -1f);
				}
			}

			while(SetOfVertices.Count != 0)
			{
				GraphNode selectedendnode = new GraphNode();
				for(int graphnode = 0; graphnode < SetOfVertices.Count; graphnode++)
				{
					float mindistance = -1f;
					GraphTreeNode curchildnode = null;
					GraphNode curendnode = SetOfVertices[graphnode];
					//find least node
					for(int traverseindex = 0; traverseindex < GraphTraverseList.Count; traverseindex++)
					{
						GraphTraverse curtraverse = GraphTraverseList[traverseindex];
						if(curtraverse.StartNode == selectedendnode.Index && curtraverse.EndNode == curendnode.Index)
						{
							if(curtraverse.Index != 0)
							{
								if(mindistance == -1f)
								{
									mindistance = curtraverse.Value;
									curchildnode.Index = curtraverse.EndNode;
								}else
								{
									if(mindistance > curtraverse.Value)
									{
										mindistance = curtraverse.Value;
										curchildnode.Index = curtraverse.EndNode;
									}
								}
							}
						}
					}


				}
			}

			return new GraphRoad();
		}

		public GraphTraverse GetTraverseList(int _startindex, int _endindex)
		{
			for(int traverseindex = 0; traverseindex < GraphTraverseList.Count; traverseindex++)
			{
				GraphTraverse traverse = GraphTraverseList[traverseindex];
				if(traverse.StartNode == _startindex && traverse.EndNode == _endindex)
				{
					return traverse;
				}
			}
			return new GraphTraverse();
		}
	}

	public class GraphTreeNode
	{
		public int Index;
		public GraphTreeNode ParentNode;
		/// <summary>
		/// i don't think it will be used
		/// </summary>
		public List<GraphTreeNode> GraphTreeChildren = new List<GraphTreeNode>();
	}

	public struct GraphNode
	{
		public int Index;

	}

	public struct GraphTraverse
	{
		public int Index;
		public int StartNode;
		public int EndNode;
		public float Value;

	}

	public struct GraphRoad
	{
		public int Index;
		public List<GraphNode> GraphNodeList;

		public GraphNode GetStartNode()
		{
			if(GraphNodeList.Count > 0)
			{
				return GraphNodeList[0];
			}

			return new GraphNode();
		}

		public GraphNode GetEndNode()
		{
			if(GraphNodeList.Count > 0)
			{
				return GraphNodeList[GraphNodeList.Count - 1];
			}
			
			return new GraphNode();
		}
	}*/