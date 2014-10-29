using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePathNode : MonoBehaviour {

	void Awake()
	{
		if(GamePathManager2.Instance != null)
		{
			GamePathManager2.Instance.SetTurnPoint(transform);
		}
	}
}
