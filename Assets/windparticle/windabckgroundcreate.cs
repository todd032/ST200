using UnityEngine;
using System.Collections;

public class windabckgroundcreate : MonoBehaviour {

	public Object m_WindParticle;

	// Use this for initialization
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Init()
	{
		for(int i = 0; i <= 16; i++)
		{
			for(int j = 0; j <= 8; j++)
			{
				windparticle_turbulence turb = (Instantiate(m_WindParticle) as GameObject).GetComponent<windparticle_turbulence>();
				turb.gameObject.transform.position = new Vector3(-8f + i, -3f + j, 0f);
				turb.transform.parent = transform;
			}
		}
	}
}
