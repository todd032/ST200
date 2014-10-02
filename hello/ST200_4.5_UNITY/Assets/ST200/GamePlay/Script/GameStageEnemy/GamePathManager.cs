using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePathManager : MonoBehaviour {

	private static GamePathManager instance ;
	public static GamePathManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GamePathManager)) as GamePathManager;
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
		float startxpos = -m_MaxSize/2f;
		float startypos = m_MaxSize/2f;
		for(int x = 0; x < m_CellCount; x++)
		{
			for(int y = 0; y < m_CellCount; y++)
			{
				if(m_CellData[x,y] == 0)
				{
					Gizmos.color = Color.green;
				}else
				{
					Gizmos.color = Color.red;
				}
				Gizmos.DrawCube(new Vector3(startxpos + x * m_CellSize, startypos - y * m_CellSize), 0.2f * Vector3.one);
			}
		}

		if(LastestPath != null)
		{
			GamePathManager.PathNode curpath = LastestPath;
			while(curpath != null)
			{
				if(curpath == LastestPath)
				{
					Gizmos.color = Color.black;
				}else if(curpath.prev_node != null && curpath.prev_node.prev_node != null && curpath.prev_node.prev_node.prev_node == null )
				{
					Gizmos.color = Color.yellow;
					Vector3 convertpos = ConvertIndexToPos(curpath.x, curpath.y);
					Gizmos.DrawSphere(convertpos, 0.5f);
				}else
				{
					Gizmos.color = Color.blue;
				}
				Vector3 pos = new Vector3(curpath.x * GamePathManager.Instance.GetCellSize - m_MaxSize / 2f, -curpath.y * GamePathManager.Instance.GetCellSize + m_MaxSize / 2f, 0f);
				Gizmos.DrawSphere(pos, 0.2f);
				curpath = curpath.next_node;
				//Debug.Log("DRAW GIZMO");
			}
		}
	}

	protected float m_MaxSize = 40f;
	protected float m_CellSize = 2f;
	public float GetCellSize
	{
		get
		{
			return m_CellSize;
		}
	}
	protected int m_CellCount = 0;
	protected int[,] m_CellData;
	public void InitPath(float _maxsize)
	{
		//Debug.Log("Init CAlled");
		m_MaxSize = _maxsize;

		int cellcount = (int)(m_MaxSize / m_CellSize);
		m_CellCount = cellcount;
		m_CellData = new int[m_CellCount, m_CellCount];

	}

	public void SetObstacle(Vector3 _pos, float _radius)
	{
		//Debug.Log("SET CALLED");
		float startxpos = -m_MaxSize/2f;
		float startypos = m_MaxSize/2f;

		float curxpos = _pos.x;
		float curypos = _pos.y;

		int curxindex = (int)((curxpos - startxpos) / m_CellSize);
		int curyindex = (int)((startypos - curypos) / m_CellSize);

		int checkindexrange = (int)(_radius / m_CellSize);

		//Debug.Log("index x: " + curxindex + " y: " +curyindex + " range: " + checkindexrange); 
		for(int x = curxindex - checkindexrange; x <= curxindex + checkindexrange; x++)
		{
			for(int y = curyindex - checkindexrange; y <= curyindex + checkindexrange; y++)
			{
				if(x > 0 && x < m_CellCount && y > 0 && y < m_CellCount)
				{
					m_CellData[x,y] = 1;
				}
			}
		}
	}

	Stack<PathNode> NodeStack = new Stack<PathNode>();
	PathNode open = null;
	PathNode best = null;
	PathNode closed = null;
	PathNode LastestPath = null;
	public Vector3 GetTargetPos(Vector3 _target, Vector3 _start)
	{
		Vector3 targetpos = _start;
		PathNode path = GetPath(_target, _start);
		LastestPath = path;

		PathNode curpath = path;
		while(curpath != null)
		{
			if(curpath.prev_node != null && curpath.prev_node.prev_node != null && curpath.prev_node.prev_node.prev_node == null )
			{
				Vector3 convertpos = ConvertIndexToPos(curpath.x, curpath.y);
				targetpos.x = convertpos.x;
				targetpos.y = convertpos.y;
				break;
			}
			curpath = curpath.prev_node;
		}

		//if(curpath == null && curpath.next_node != null)
		//{
		//	Vector3 convertpos = ConvertIndexToPos(curpath.next_node.x, curpath.next_node.y);
		//	Debug.Log("targetpos: " + convertpos);
		//	targetpos.x = convertpos.x;
		//	targetpos.y = convertpos.y;
		//}

		return targetpos;
	}

	protected Vector3 ConvertIndexToPos(int _x, int _y)
	{
		Vector3 position = Vector3.zero;
		position.x = -m_MaxSize / 2f + _x * m_CellSize;
		position.y = m_MaxSize / 2f - _y * m_CellSize;

		//Debug.Log("targetpos: " + position + " INDEX X:" + _x + " Y: " + _y);

		return position;
	}

	protected PathNode GetPath(Vector3 _target, Vector3 _start)
	{
		NodeStack = new Stack<PathNode>();
		LinkedList<PathNode> BestNodeList = new LinkedList<PathNode>();

		float startxpos = -m_MaxSize/2f;
		float startypos = m_MaxSize/2f;
		
		int startxindex = (int)((_target.x - startxpos) / m_CellSize);
		int startyindex = (int)((startypos - _target.y) / m_CellSize);

		float endxpos = -m_MaxSize/2f;
		float endypos = m_MaxSize/2f;
		
		int endxindex = (int)((_start.x - endxpos) / m_CellSize);
		int endyindex = (int)((endypos - _start.y) / m_CellSize);

		PathNode curnode = null;
		curnode = new PathNode();
		curnode.degree = 0;
		curnode.distance = 0f;
		curnode.value_factor = 0f;
		curnode.x = endxindex;
		curnode.y = endyindex;

		int pathfindcounter = 0;
		
		open = curnode;
		best = null;
		closed = null;
		while(pathfindcounter < 100)
		{
			if(open == null)
			{
				return best;
			}
			best = open;
			open = best.next_node;
			best.next_node = closed;
			closed = best;

			if(best == null)
			{
				return null;
			}

			if(best.x == startxindex && best.y == startyindex)
			{
				return best;
			}

			if(!MakeChild(best, startxindex, startyindex) && pathfindcounter == 0)
			{
				return null;
			}
			pathfindcounter++;
		}

		return best;
	}

	protected bool MakeChild(PathNode _node, int _destx, int _desty)
	{
		//Debug.Log ("MAKE CHILD CALLED  x: " + _destx + " y: " + _desty + "Cur Node: " + _node.x + " y: " + _node.y);
		bool extended = false;
		int x = _node.x;
		int y = _node.y;

		List<int> xlist = new List<int>();
		List<int> ylist = new List<int>();
		xlist.Add(x - 1);ylist.Add(y + 1);
		xlist.Add(x);ylist.Add(y + 1);
		xlist.Add(x);ylist.Add(y + 1);
		xlist.Add(x - 1);ylist.Add(y);
		xlist.Add(x + 1);ylist.Add(y);
		xlist.Add(x - 1);ylist.Add(y - 1);
		xlist.Add(x);ylist.Add(y - 1);
		xlist.Add(x + 1);ylist.Add(y - 1);

		List<int> ordernode = new List<int>();
		List<int> distancelist = new List<int>();
		ordernode.Add(0);
		distancelist.Add (Mathf.Abs(_destx - xlist[0]) + Mathf.Abs(_desty - ylist[0]));

		for(int i = 1; i < 8; i++)
		{
			for(int j = 0; j < i; j++)
			{
				int curdistance = (Mathf.Abs(_destx - xlist[i]) + Mathf.Abs(_desty - ylist[i]));
				//Debug.Log("CHEKC: " + curdistance + " LA: " + distancelist[j]);
				if(curdistance < distancelist[j])
				{
					distancelist.Insert(j, curdistance);
					ordernode.Insert(j, i);
					//Debug.Log ("DAD");
					break;
				}

				if(j == i - 1)
				{
					distancelist.Add(curdistance);
					ordernode.Add(i);
					//Debug.Log ("DAD222");
				}
			}
		}
		for(int i = 0; i < ordernode.Count; i++)
		{
			//Debug.Log("ORDER INDEX: " + ordernode[i] + " DISTANCE: " + distancelist[i]);
		}

		//Debug.Log("HMM::? " + ordernode.Count);
		for(int i = 0; i < ordernode.Count; i++)
		{
			if(IsAvailableCell(xlist[i], ylist[i]))
			{
				ExtendNode(_node, xlist[i], ylist[i], _destx, _desty, ordernode[i]);
				extended = true;
			}
		}

		return extended;
	}

	protected void ExtendNode(PathNode _node, int _curx, int _cury, int _destx, int _desty, int _curdir)
	{
		//Debug.Log("EXTEND CALLED: " + _curdir);
		PathNode old = null;
		PathNode child = null;
		int i;
		int degree = _node.degree + 1;


		if((old = IsOpen(_curx, _cury)) != null)
		{
			//Debug.Log("OPEN");
			_node.Direct[_curdir] = old;

			if(degree < old.degree)
			{
				old.prev_node = _node;
				old.degree = degree;
				old.value_factor = old.distance + old.degree;
			}
		}else if((old = IsClosed(_curx, _cury)) != null)
		{
			//Debug.Log("close");
			_node.Direct[_curdir] = old;

			if(degree < old.degree)
			{
				old.prev_node = _node;
				old.degree = degree;
				old.value_factor = old.distance + old.degree;
				MakeSort(old);
			}
		}else
		{
			//Debug.Log("create");
			child = new PathNode();
			child.prev_node = _node;
			child.degree = degree;
			child.distance = Mathf.Pow((_curx - _destx),2f) + Mathf.Pow((_cury - _desty),2f);
			child.value_factor = child.distance + child.degree;
			child.x = _curx;
			child.y = _cury;

			InsertNode(child);
			_node.Direct[_curdir] = child;
		}
	}

	protected void MakeSort(PathNode _node)
	{
		PathNode direct, previous;
		int degree = _node.degree + 1;

		for(int i = 0; i < 8; i++)
		{
			if((direct = _node.Direct[i]) == null)
			{
				continue;
			}

			if(direct.degree > degree)
			{
				direct.prev_node = _node;
				direct.degree = degree;
				direct.value_factor = direct.distance + direct.degree;

				NodeStack.Push(direct);
			}
		}

		while(NodeStack.Count != 0)
		{
			previous = NodeStack.Pop();

			for(int i = 0; i < 8; i++)
			{
				if((direct = previous.Direct[i]) == null)
					break;
				if(direct.degree > previous.degree + 1)
				{
					direct.prev_node = previous;
					direct.degree = previous.degree + 1;
					direct.value_factor = direct.distance + direct.degree;
					NodeStack.Push(direct);
				}
			}
		}
	}

	void InsertNode(PathNode _node)
	{
		PathNode old = null, temp = null;

		if(open == null)
		{
			open = _node;
			return;
		}

		temp = open;
		while(temp != null && (temp.value_factor < _node.value_factor))
		{
			old = temp;
			temp = temp.next_node;
		}

		if(old != null)
		{
			_node.next_node = temp;
			old.next_node = _node;
		}else
		{
			_node.next_node = temp;
			open = _node;
		}
	}

	protected bool IsAvailableCell(int _x, int _y)
	{
		if(_x > 0 && _x < m_CellCount && _y > 0 && _y < m_CellCount && m_CellData[_x,_y] == 0)
		{
			return true;
		}
		return false;
	}

	protected PathNode IsOpen(int _x, int _y)
	{
		PathNode curnode = open;
		while(curnode != null)
		{
			if(curnode.x == _x && curnode.y == _y)
			{
				return curnode;
			}
			curnode = curnode.prev_node;
		}

		return null;
	}

	protected PathNode IsClosed(int _x, int _y)
	{
		PathNode curnode = closed;
		while(curnode != null)
		{
			if(curnode.x == _x && curnode.y == _y)
			{
				return curnode;
			}
			curnode = curnode.prev_node;
		}
		return null;
	}

	public class PathNode
	{
		public int degree;
		public float distance;
		public float value_factor;
		public int x;
		public int y;
		public PathNode[] Direct = new PathNode[8];
		public PathNode prev_node;
		public PathNode next_node;
	}
}
