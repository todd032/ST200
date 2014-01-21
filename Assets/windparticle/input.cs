using UnityEngine;
using System.Collections;

public class input : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			collider2D.enabled = true;
		}else
		{
			collider2D.enabled = false;
		}
	}

	void LateUpdate()
	{
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position -= Vector3.forward * transform.position.z;
	}
}
