using UnityEngine;
using System.Collections;

public class windobject : MonoBehaviour {

	public Vector3 m_Accel;
	public Vector3 m_Velocity;
	public float m_Mass = 1f;
	public float windresis = 0.99f;
	// Use this for initialization
	void Start () {
		//Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		AddForce(Vector3.up * -5f);
		ProcessMove();
	}

	void ProcessMove()
	{
		rigidbody2D.velocity *= windresis;
		//m_Velocity *= windresis;
		//m_Velocity = FluidSimulation.Instance.GetVelocityAtPosition(transform.position)/m_Mass;// * Time.fixedDeltaTime;
		//m_Velocity += (m_Accel) * Time.fixedDeltaTime;
		//transform.position += m_Velocity * Time.fixedDeltaTime;// + FluidSimulation.Instance.GetVelocityAtPosition(transform.position)/m_Mass * Time.fixedDeltaTime;
		//m_Accel = Vector3.zero;
	}

	public void AddForce(Vector3 force)
	{
		///mass is calculated from speed
		float factor = 1 - m_Velocity.magnitude/1000f;
		if(m_Velocity.magnitude/1000f >= 1f)
		{
			
		}else
		{
			float mass = m_Mass/Mathf.Pow(factor,0.5f);
			//m_Accel += force/mass;
			rigidbody2D.AddForce(force/mass);
		}
	}
}
