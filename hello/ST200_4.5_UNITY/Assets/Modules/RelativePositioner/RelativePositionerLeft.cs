using UnityEngine;
using System.Collections;

public class RelativePositionerLeft : MonoBehaviour {

	public Camera m_CurCam;
	protected float _screenSizeHeight ;
	protected float _screenSizeWidth ;
	void Awake () {	
		
		_screenSizeHeight = 2f * m_CurCam.orthographicSize;
		_screenSizeWidth = _screenSizeHeight * m_CurCam.aspect;
		Vector3 position = m_CurCam.transform.position;
		position.x += -_screenSizeWidth/2f;
		position.y = transform.position.y;
		position.z = transform.position.z;

		transform.position = position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
