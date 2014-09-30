using UnityEngine;
using System.Collections;

public class FxDestory : MonoBehaviour {
	
	public float DestoryTime= 1.0f;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject , DestoryTime);
	}
	
}
