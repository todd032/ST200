using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Transform m_TargetTransform;
	public Vector3 DeltaVector;
	public float LerpFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(m_TargetTransform != null)
		{
			transform.position = Vector3.Lerp(transform.position, m_TargetTransform.position + DeltaVector, LerpFactor);
		}
	}
}
