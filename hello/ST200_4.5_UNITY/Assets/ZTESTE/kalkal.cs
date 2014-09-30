using UnityEngine;
using System.Collections;

public class kalkal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("HI");
			func();
		}
	}

	IEnumerator func()
	{
		Debug.Log("HELLO");
		yield return null;
	}
}
