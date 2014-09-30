using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubShipScrollObject : MonoBehaviour {

	void Update()
	{
		Vector3 localscale = Vector3.one;
		float deltax = transform.localPosition.x;
		if(Mathf.Abs(deltax) > 10f)
		{
			transform.localScale = Vector3.one * 0.9f;
		}else
		{
			transform.localScale = Vector3.one;
		}
	}
}
