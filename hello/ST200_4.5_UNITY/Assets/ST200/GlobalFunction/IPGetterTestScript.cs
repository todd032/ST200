using UnityEngine;
using System.Collections;

public class IPGetterTestScript : MonoBehaviour {

	public IPGetter m_IPGetter;
	// Use this for initialization
	void Start () {
		m_IPGetter.Init();
	}
	
	// Update is called once per frame
	void Update () {	
		
		if(Input.GetKeyDown(KeyCode.R))
		{
			m_IPGetter.GetIP();
		}
	}
}
