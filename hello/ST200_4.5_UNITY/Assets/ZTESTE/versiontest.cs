using UnityEngine;
using System.Collections;

public class versiontest : MonoBehaviour {

	string v1 = "1.1.1";
	string v2 = "2.1.0";
	// Use this for initialization
	void Start () {
		Debug.Log(vvv ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool vvv()
	{
		if(v2.CompareTo(v1) == 1 || v2.CompareTo(v1) == 0){
			return true ;	
		}else{
			return false ;
		}

		return false;
	}
}
