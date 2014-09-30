using UnityEngine;
using System.Collections;

public class shipattackdisplaytester : MonoBehaviour {

	public ShipSelectShipAttackDisplayer m_Displayer;
	public float displaytime = 2f;

	// Use this for initialization
	void Start () {
	
	}

	protected float displaytimer = 0f;
	// Update is called once per frame
	void Update () {
		displaytimer += Time.deltaTime;
		if(displaytimer > displaytime)
		{
			displaytimer = 0f;
			m_Displayer.Shoot();
		}
	}
}
