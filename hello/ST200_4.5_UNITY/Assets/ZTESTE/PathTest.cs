using UnityEngine;
using System.Collections;

public class PathTest : MonoBehaviour {
	public GameObject m_Startpos;
	public GameObject m_EndPos;

	// Use this for initialization
	void Start () {
		GamePathManager.Instance.InitPath(40f);
		for(int i = 0; i < 30; i++)
		{
			Vector3 startpos = new Vector3(Random.Range(-20f,20f), Random.Range(-20f,20f), 0f);

			GamePathManager.Instance.SetObstacle(startpos, Random.Range(1f, 3f));
		}
	}

	GamePathManager.PathNode Path;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{
			GamePathManager.Instance.InitPath(40f);
			for(int i = 0; i < 30; i++)
			{
				Vector3 startpos = new Vector3(Random.Range(-20f,20f), Random.Range(-20f,20f), 0f);
				
				GamePathManager.Instance.SetObstacle(startpos, Random.Range(1f, 3f));
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Vector3 startpos = new Vector3(Random.Range(-20f,20f), Random.Range(-20f,20f), 0f);
			Vector3 endpos = new Vector3(Random.Range(-20f,20f), Random.Range(-20f,20f), 0f);

			//Path = GamePathManager.Instance.GetPath(m_Startpos.transform.position, m_EndPos.transform.position);
			//Debug.Log ("HI START: " + startpos + " END: " + endpos + " NULL?: " + (Path == null) );
		}
	}

	void OnDrawGizmos()
	{
		GamePathManager.PathNode curpath = Path;
		while(curpath != null)
		{
			Gizmos.DrawSphere(new Vector3(curpath.x * GamePathManager.Instance.GetCellSize - 20f, -curpath.y * GamePathManager.Instance.GetCellSize + 20f, 0f), 0.2f);
			curpath = curpath.prev_node;
		}		
	}
}
