using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePathManager2 : MonoBehaviour {

	private static GamePathManager2 instance;
	public static GamePathManager2 Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GamePathManager2)) as GamePathManager2;
			}
			return instance;
		}
	}


	void OnDestroy()
	{
		instance = null;
	}

	List<int> LastPath = new List<int>();
	void OnDrawGizmos()
	{
		if(!Application.isPlaying)
		{
			return;
		}

		//for(int i = 0; i < LastPath.Count; i++)
		//{
		//	float colorval = 1f;//1f / LastPath.Count;
		//	Color curcolor = Color.white;
		//	curcolor.r = colorval;
		//	curcolor.g = colorval;
		//	curcolor.b = colorval;
		//	curcolor.a = 0.5f;
		//	Gizmos.color = curcolor;
		//
		//	int curindex = LastPath[i];
		//	Gizmos.DrawSphere(m_TurnPointList[curindex].position, 2f);
		//}

		foreach(Dijkstras_Algorithm.Vector2D point in GraphManager.DijkstraGraph.AllNodes)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(m_TurnPointList[point.VertexID].position, 1f);
		}
		foreach(Dijkstras_Algorithm.Edge edge in GraphManager.DijkstraGraph.GetEdges())
		{
			Gizmos.DrawLine(m_TurnPointList[edge.PointA.VertexID].position, m_TurnPointList[edge.PointB.VertexID].position);
		}
	}

	public List<Transform> m_TurnPointList = new List<Transform>();
	public List<CircleCollider2D> m_ColliderList = new List<CircleCollider2D>();
	protected DijkstraGraphManager GraphManager;

	void Awake()
	{

	}

	public void Init()
	{
		GraphManager = new DijkstraGraphManager();

		for(int i = 0; i < m_TurnPointList.Count; i++)
		{
			Transform firstnode = m_TurnPointList[i];
			GraphManager.AddPoint(i);
		}

		//loop through turnpoints and set
		int linecount = 0;
		for(int i = 0; i < m_TurnPointList.Count; i++)
		{
			Transform firstnode = m_TurnPointList[i];
			for(int j = i; j < m_TurnPointList.Count; j++)
			{
				Transform secondnode = m_TurnPointList[j];

				if(!CollideWithLine(firstnode.position, secondnode.position))
				{
					GraphManager.AddEdge(i, j, Vector2.Distance(firstnode.position, secondnode.position));
					linecount++;
				}
			}
		}

		Debug.Log("INIT COMPLETE total " + linecount);
	}

	public void SetObstacle(CircleCollider2D _collider)
	{
		m_ColliderList.Add(_collider);
	}

	public void SetTurnPoint(Transform _turnpoint)
	{
		m_TurnPointList.Add(_turnpoint);
	}

	//user graph algorithm damn it..!!!
	//homework
	public Vector3 GetTargetPos(Vector3 _startpos, Vector3 _targetpos)
	{
		Vector3 targetpos = _startpos;

		if(CollideWithLine(_startpos, _targetpos))
		{
			int startnodeindex = 0;
			float startdistance = 99999f;
			int targetnodeindex = 0;
			float targetdistance = 99999f;

			for(int i = 0 ; i < m_TurnPointList.Count; i++)
			{
				Transform curtransform = m_TurnPointList[i];
				if(!CollideWithLine(_startpos, curtransform.position))
				{
					float curdistance = Vector2.Distance(_startpos, curtransform.position);
					if(startdistance > curdistance)
					{
						startdistance = curdistance;
						startnodeindex = i;
					}
				}

				if(!CollideWithLine(_targetpos, curtransform.position))
				{
					float curdistance = Vector2.Distance(_targetpos, curtransform.position);
					if(targetdistance > curdistance)
					{
						targetdistance = curdistance;
						targetnodeindex = i;
					}
				}
			}

			List<int> pathindexes = GraphManager.GetPath(startnodeindex, targetnodeindex);
			LastPath = pathindexes;
			//Debug.Log("GET PAHT COUNT: " + pathindexes.Count);
			Transform targetpoint = null;
			for(int i = 0 ; i < pathindexes.Count; i++)
			{
				int curindex = pathindexes[i];
				Transform curtransform = m_TurnPointList[curindex];
				if(!CollideWithLine(_startpos, curtransform.position))
				{
					targetpoint = curtransform;
				}
			}

			if(targetpoint != null)
			{
				targetpos.x = targetpoint.position.x;
				targetpos.y = targetpoint.position.y;
			}else
			{
				//Debug.Log("NO PATH");
			}

			//LinkedList<Transform> pathlist = new LinkedList<Transform>();
			//LinkedList<Transform> visitedlist = new LinkedList<Transform>();
			//
			//List<Transform> orderedbydistance = new List<Transform>();
			//List<float> distancechecker = new List<float>();
			//orderedbydistance.Add(m_TurnPointList[0]);
			//float distance = Vector3.Distance(_targetpos, orderedbydistance[0].position);
			//distancechecker.Add(distance);
			//
			//for(int i = 0; i < m_TurnPointList.Count; i++)
			//{
			//	Transform curturnpoint = m_TurnPointList[i];
			//	float curdistance = Vector3.Distance(_targetpos, orderedbydistance[i].position);
			//
			//	for(int j = 0; j < distancechecker.Count; j++)
			//	{
			//		float jdistance = distancechecker[j];
			//		if(curdistance < jdistance)
			//		{
			//			distancechecker.Insert(j, curdistance);
			//			orderedbydistance.Insert(j, curturnpoint);
			//			break;
			//		}
			//		if(j == distancechecker.Count - 1)
			//		{
			//			orderedbydistance.Add(curturnpoint);
			//			distancechecker.Add(curdistance);
			//		}
			//	}
			//}
			//
			//for(int i = 0; i < orderedbydistance.Count; i++)
			//{
			//	Transform curtransform = orderedbydistance[i];
			//	if(!CollideWithLine(_startpos, curtransform.position))
			//	{
			//		targetpos.x = curtransform.position.x;
			//		targetpos.y = curtransform.position.y;
			//		break;
			//	}
			//}
		}else
		{
			targetpos.x = _targetpos.x;
			targetpos.y = _targetpos.y;
		}

		return targetpos;
	}

	public bool CollideWithLine(Vector3 _startpos, Vector3 _targetpos)
	{
		// two points (sx, sy) , (tx, ty)
		// function that connects two vetices 
		// => y = mx + n;
		// m = (sy - ty) / (sx - tx)
		// n = (sx * ty - sy * tx) / (sx - tx)
		// distance from point (cx, cy)
		// d = |m cx - cy + n| / root(m*m + 1)

		float sx = _startpos.x;
		float sy = _startpos.y;
		float tx = _targetpos.x;
		float ty = _targetpos.y;

		float m = (sy - ty) / (sx - tx);
		float n = (sx * ty - sy * tx) / (sx - tx);

		for(int i = 0; i < m_ColliderList.Count; i++)
		{
			CircleCollider2D curcollider = m_ColliderList[i];

			float cx = curcollider.transform.position.x;
			float cy = curcollider.transform.position.y;
			float r = curcollider.radius;
			float d = Mathf.Abs(m * cx - cy + n) / (Mathf.Sqrt(m * m + 1));

			//should add condition that circle is in connected line.
			if(d < curcollider.radius)
			{
				//y = mx + n
				//(x - cx)^2 + (y - cy)^2 = c^2
				//intersection points P1, P2
				//v1 = m^2 + 1
				//v2 = cx - mn + m(cy)
				//v3 = cx^2 + n^2 - 2n(cy) + (cy)^2 - c^2
				//v1x^2 - 2v2x + v3 = 0
				//x = v2 +- root(v2^2 - v1v3) / v1
				//y = mx + n;

				float v1 = m * m + 1;
				float v2 = cx - m * n + m * cy;
				float v3 = cx * cx + n * n - 2 * n * cy + cy * cy - r * r;

				float x1 = (v2 + Mathf.Sqrt(v2 * v2 - v1 * v3)) / v1;
				float x2 = (v2 - Mathf.Sqrt(v2 * v2 - v1 * v3)) / v1;

				float y1 = x1 * m + n;
				float y2 = x2 * m + n;

				//Debug.Log("V1: " +v1 + " v2: " + v2 + " v3: " + v3);

				bool firstpointisinbound = false;
				bool secondpointisinbound = false;

				Vector2 linepoint1 = new Vector2(sx, sy);
				Vector2 linepoint2 = new Vector2(tx, ty);
				Vector2 crosspoint1 = new Vector2(x1, y1);
				Vector2 crosspoint2 = new Vector2(x2, y2);

				Vector2 linedirection = linepoint2 - linepoint1;
				Vector2 crossdirection1 = crosspoint1 - linepoint1;
				Vector2 crossdirection2 = crosspoint2 - linepoint1;

				if(((crossdirection1.x > 0) == (linedirection.x > 0))
				   &&((crossdirection1.y > 0) == (linedirection.y > 0)))
				{
					if(crossdirection1.magnitude < linedirection.magnitude)
					{
						firstpointisinbound = true;
					}
				}

				if(((crossdirection2.x > 0) == (linedirection.x > 0))
				   &&((crossdirection2.y > 0) == (linedirection.y > 0)))
				{
					if(crossdirection2.magnitude < linedirection.magnitude)
					{
						secondpointisinbound = true;
					}
				}

				//Debug.Log("linedir: " + linedirection + " cross1: " + crossdirection1 + " cross2: " + crossdirection2 + 
				//          " point1: " + crosspoint1 + " point2: " + crosspoint2
				//          + " startpoint: " + linepoint1 + " endpoint: " + linepoint2);

				if(firstpointisinbound || secondpointisinbound)
				{
					return true;
				}
			}
		}
		return false;
	}
}
