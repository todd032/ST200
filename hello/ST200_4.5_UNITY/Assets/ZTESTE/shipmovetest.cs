using UnityEngine;
using System.Collections;

public class shipmovetest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 speed = (transform.up + transform.right);
		transform.position += speed * Time.deltaTime;
		transform.up = transform.up + transform.right * Time.deltaTime;
	}
}
