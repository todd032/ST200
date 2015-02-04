using UnityEngine;
using System.Collections;

public class RotateByFrame : MonoBehaviour {

	public float RotationAngle;
	public int RotateFrame = 3;
	protected int CurFrame = 0;
	public Vector3 Axis = Vector3.forward;

	void LateUpdate()
	{
		Process();
	}

	void Process()
	{
		CurFrame++;
		if(CurFrame % RotateFrame == 0)
		{
			CurFrame = 0;
			transform.Rotate(Vector3.forward, RotationAngle);
		}
	}

}
