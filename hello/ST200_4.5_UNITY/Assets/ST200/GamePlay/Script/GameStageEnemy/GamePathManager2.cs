using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePathManager2 : MonoBehaviour {

	private static GamePathManager2 instance ;
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
	
	void OnDrawGizmos()
	{

	}

	public List<Transform> m_TurnPointList = new List<Transform>();
	public List<CircleCollider2D> m_ColliderList = new List<CircleCollider2D>();
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
			LinkedList<Transform> pathlist = new LinkedList<Transform>();
			LinkedList<Transform> visitedlist = new LinkedList<Transform>();

			List<Transform> orderedbydistance = new List<Transform>();
			List<float> distancechecker = new List<float>();
			orderedbydistance.Add(m_TurnPointList[0]);
			float distance = Vector3.Distance(_targetpos, orderedbydistance[0].position);
			distancechecker.Add(distance);

			for(int i = 0; i < m_TurnPointList.Count; i++)
			{
				Transform curturnpoint = m_TurnPointList[i];
				float curdistance = Vector3.Distance(_targetpos, orderedbydistance[i].position);

				for(int j = 0; j < distancechecker.Count; j++)
				{
					float jdistance = distancechecker[j];
					if(curdistance < jdistance)
					{
						distancechecker.Insert(j, curdistance);
						orderedbydistance.Insert(j, curturnpoint);
						break;
					}
					if(j == distancechecker.Count - 1)
					{
						orderedbydistance.Add(curturnpoint);
						distancechecker.Add(curdistance);
					}
				}
			}

			for(int i = 0; i < orderedbydistance.Count; i++)
			{
				Transform curtransform = orderedbydistance[i];
				if(!CollideWithLine(_startpos, curtransform.position))
				{
					targetpos.x = curtransform.position.x;
					targetpos.y = curtransform.position.y;
					break;
				}
			}
		}else
		{
			targetpos.x = _targetpos.x;
			targetpos.y = _targetpos.y;
		}

		return targetpos;
	}

	protected bool CollideWithLine(Vector3 _startpos, Vector3 _targetpos)
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
			float d = Mathf.Abs(m * cx - cy * n) / (Mathf.Sqrt(m * m + 1));

			if(d < curcollider.radius)
			{
				return true;
			}
		}
		return false;
	}
}
