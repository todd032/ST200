using UnityEngine;
using System.Collections;

public class windparticle_shoot :windparticle {

	public Vector3 m_PushVelocity = new Vector3(3f,0f,0f);
	public float windfactor = 0.1f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		m_Velocity = m_PushVelocity;
		ProcessMove();
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.layer == 9)
		{
			//Debug.Log("RR");
			//wind object
			windobject obj = col.gameObject.GetComponent<windobject>();
			
			float distance = Vector3.Distance(gameObject.transform.position, col.transform.position);
			distance = Mathf.Max(distance, 0.5f);
			Vector3 force = forcefactor * 
				(gameObject.transform.position - col.transform.position).normalized * m_WindForce / Mathf.Pow(distance,2f) + m_PushVelocity * m_WindForce * windfactor;
			obj.AddForce(force);
			
			//AddForce(-force);
		}
	}
}