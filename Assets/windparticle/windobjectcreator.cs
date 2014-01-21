using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class windobjectcreator : MonoBehaviour {

	public int randval = 100;
	public Vector3 normalforce = new Vector3(10f,0f,0f);
	public float randomyforce = 4f;
	public float randomWindForce_min = 10f;
	public float randomWindForce_max = 30f;
	public Object m_WindObject;
	public List<windobject> ParticleList = new List<windobject>();
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
		if(ParticleList.Count < MaxParticleCount)
		{
			if(Random.Range(0,10000) < randval)
			{
				float randomy = Random.Range(-1f,1f) * randomyforce;
				Vector3 force = normalforce + Vector3.up * randomy;
				
				windobject particle = (Instantiate(m_WindObject,transform.position + Vector3.right * Random.Range(0.5f,1f), Quaternion.identity) as GameObject).GetComponent<windobject>();
				ParticleList.Add(particle);
			}
		}
	}
}