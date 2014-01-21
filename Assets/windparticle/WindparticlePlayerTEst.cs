using UnityEngine;
using System.Collections;

public class WindparticlePlayerTEst : MonoBehaviour {

	public Vector3 m_Accel;
	public Vector3 m_Velocity;
	public float m_Mass = 1f;
	public float windresis = 0.99f;
	public windparticle m_WindParticle;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			m_Velocity += Vector3.up * 5f;
		}
		m_Velocity.x = Mathf.Clamp(Input.GetAxis("Horizontal") * 1f + m_Velocity.x, -2f,2f);
		if(Input.GetKey(KeyCode.Space))
		{
			m_WindParticle.collider2D.enabled = true;
			m_Accel += Vector3.up * 10f;
		}else
		{
			m_WindParticle.collider2D.enabled = false;
		}
	}


	void FixedUpdate()
	{
		ProcessMove();
	}

	public void ProcessMove()
	{
		m_Velocity *= windresis;
		//m_Velocity = FluidSimulation.Instance.GetVelocityAtPosition(transform.position)/m_Mass;// * Time.fixedDeltaTime;
		m_Velocity += (m_Accel) * Time.fixedDeltaTime;
		transform.position += m_Velocity * Time.fixedDeltaTime;// + FluidSimulation.Instance.GetVelocityAtPosition(transform.position)/m_Mass * Time.fixedDeltaTime;
		m_Accel = Vector3.zero;
	}
}
