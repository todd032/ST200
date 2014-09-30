using UnityEngine;
using System.Collections;

public class efefefefefef : MonoBehaviour {
	public SubmarineStartBoosterReadyEffectObject asdasd;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			asdasd.gameObject.SetActive(true);
			asdasd.StartAction();
		}
	}
}
