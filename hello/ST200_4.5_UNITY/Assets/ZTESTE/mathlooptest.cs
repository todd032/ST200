using UnityEngine;
using System.Collections;

public class mathlooptest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Simulate();
		}
	}

	void Simulate()
	{
		
		float starttime = Time.realtimeSinceStartup;
		
		for(int i = 0; i < 1440 * 1440; i++)
		{
			bool fal = (1 + 1 == 2);
		}
		
		float endtime = Time.realtimeSinceStartup;
		
		Debug.Log("Time SPEND: " + (endtime - starttime).ToString());
	}
}
