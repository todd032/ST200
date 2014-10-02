using UnityEngine;
using System.Collections;

public class BackgroundLandObject : MonoBehaviour {

	void Awake()
	{
		foreach(CircleCollider2D _col in GetComponentsInChildren<CircleCollider2D>())
		{
			GamePathManager.Instance.SetObstacle(_col.transform.position, _col.radius + 1f);
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}

}
