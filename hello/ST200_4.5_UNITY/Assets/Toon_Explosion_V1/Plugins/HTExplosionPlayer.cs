using UnityEngine;
using System.Collections;

public class HTExplosionPlayer : MonoBehaviour {
	public HTExplosion m_Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			m_Explosion.PlayAnim();
		}
	}
}
