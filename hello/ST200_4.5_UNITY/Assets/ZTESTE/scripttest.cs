using UnityEngine;
using System.Collections;

public class scripttest : MonoBehaviour {
	public UIInput m_Input;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSubmit()
	{
		Debug.Log("SUBMIT: " + m_Input.value);
	}
}
