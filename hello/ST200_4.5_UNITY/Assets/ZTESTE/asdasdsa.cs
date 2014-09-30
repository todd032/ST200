using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class asdasdsa : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int remainder = 30000;
		int day = remainder / 60 / 60 / 24;
		int hour = remainder / 60 / 60 -  24 * day;
		int min = (remainder / 60) % 60;
		int second = remainder % 60;

		string[] strings = new string[]
		{
			day.ToString(),
			string.Format("{0:00}", hour),
			string.Format("{0:00}", min),
			string.Format("{0:00}", second),
		};
		Debug.Log(strings[0] + " " + strings[1] + " " + strings[2] + " " + strings[3] + " ");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
