using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class windsource : MonoBehaviour {

	public int randval = 100;
	public Vector3 normalforce = new Vector3(10f,0f,0f);
	public float randomyforce = 4f;
	public float randomWindForce_min = 10f;
	public float randomWindForce_max = 30f;
	public Object m_WindParticle;
	public List<windparticle> ParticleList = new List<windparticle>();
	public int MaxParticleCount = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		process();
	}

	void process()
	{
		//if(ParticleList.Count < MaxParticleCount)
		{

			if(Random.Range(0,10000) < randval)
			{
				float randomy = Random.Range(-1f,1f) * randomyforce;
				Vector3 force = normalforce + Vector3.up * randomy;

				windparticle particle = (Instantiate(m_WindParticle,transform.position, Quaternion.identity) as GameObject).GetComponent<windparticle>();

				particle.m_Velocity = force;
				particle.m_WindForce = Random.Range(randomWindForce_min, randomWindForce_max);
			}
		}
	}
}
