using UnityEngine;
using System.Collections;

public class windparticle2 : windparticle {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
				Vector3.Project((gameObject.transform.position - col.transform.position).normalized , transform.right) * m_WindForce / Mathf.Pow(distance,2f);
			obj.AddForce(force + transform.up * force.magnitude/2f);
			
			//AddForce(-force);
		}
	}
}
