using UnityEngine;
using System.Collections;

public class Physicsmovetest : MonoBehaviour {

	public Rigidbody2D m_RigidBody;
	public float moveforce = 10f;
	public float rotateforce = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
		{
			m_RigidBody.AddTorque(-rotateforce * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			m_RigidBody.AddTorque(rotateforce * Time.deltaTime);
		}

		m_RigidBody.AddForce(transform.up * Time.deltaTime * moveforce);

	}
}
