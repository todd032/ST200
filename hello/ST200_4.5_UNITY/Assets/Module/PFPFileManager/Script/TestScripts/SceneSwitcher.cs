using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	
	public void LoadScene1()
	{
		Application.LoadLevel(1);
	}

	public void LoadScene2()
	{
		Application.LoadLevel(2);
	}
}
