using UnityEngine;
using System.Collections;

public class windparticle : MonoBehaviour {

	public Vector3 m_Accel;
	public Vector3 m_Velocity;
	public float m_WindForce;
	public float forcefactor = 0.1f;
	public float windresis = 0.99f;

	public bool destroy = true;
	// Use this for initialization
	void Start () {
		if(destroy)
		{
			Destroy(gameObject,2f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		ProcessMove();
		ProcessCheckCollision();
	}

	protected void ProcessMove()
	{
		m_Velocity *= windresis;
		m_Velocity += m_Accel * Time.fixedDeltaTime;
		transform.position += m_Velocity * Time.fixedDeltaTime;
		m_Accel = Vector3.zero;

		//ProcessCheckCollision();
	}

	protected void ProcessCheckCollision()
	{
		float distancewithfloor = transform.position.y + 3.5f;
		if(distancewithfloor < 0f && destroy)
		{
			AddForce(Vector3.up * m_WindForce/Mathf.Pow(Mathf.Max(0.5f, Mathf.Abs(distancewithfloor)),2f));
		}
		//if(transform.position.y < 4f)
		//{
		//	transform.position = transform.position + Vector3.up * (-transform.position.y - 4f);
		//}
	}

	public void AddForce(Vector3 force)
	{
		///mass is calculated from speed
		float factor = 1 - m_Velocity.magnitude/1000f;
		if(m_Velocity.magnitude/1000f >= 1f)
		{

		}else
		{
			float mass = 1f/Mathf.Pow(factor,0.5f);
			m_Accel += force/mass;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.gameObject.layer == 8)
		{
			//Debug.Log("COLLIDED");
			//windpartice
			windparticle wind = col.gameObject.GetComponent<windparticle>();
			if(wind.destroy && destroy)
			{
				float distance = Vector3.Distance(gameObject.transform.position, col.transform.position);
				distance = Mathf.Max(distance, 1f);
				Vector3 force = forcefactor * (gameObject.transform.position - col.transform.position).normalized * wind.m_WindForce / Mathf.Pow(distance,2f);
					AddForce(force);
			}
		}else if(col.gameObject.layer == 9)
		{
			//wind object
			windobject obj = col.gameObject.GetComponent<windobject>();

			float distance = Vector3.Distance(gameObject.transform.position, col.transform.position);
			distance = Mathf.Max(distance, 0.5f);
			Vector3 force = forcefactor * 
				(gameObject.transform.position - col.transform.position).normalized * m_WindForce / Mathf.Pow(distance,2f);
			obj.AddForce(force);
			
			//AddForce(-force);
		}
	}
}
