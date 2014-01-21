using UnityEngine;
using System.Collections;

public class WindRealSource : MonoBehaviour {

	public Vector3 SourceForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		FluidSimulation.Instance.AddInputVel(transform.position, SourceForce);
	}
}
