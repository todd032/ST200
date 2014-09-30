using UnityEngine;
using System.Collections;

public class TutorialFingerAnim : MonoBehaviour {
		
	public Camera m_CurCam;
	public UISprite m_Sprite;
	protected float _screenSizeHeight ;
	protected float _screenSizeWidth ;
	protected float m_FingerWidth = 50f;
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
		StartCoroutine(PlayAnim());
	}

	IEnumerator PlayAnim()
	{
		//Debug.Log("START");
		Vector3 pivot = transform.localPosition;
		pivot.x += m_FingerWidth / 2f;

		float radius = m_FingerWidth/2f;
		float TotalRotateTimer = 2f;
		float anglepertime = 720f / TotalRotateTimer;

		float timer = 0f;
		while(timer < TotalRotateTimer)
		{
			timer += 0.02f;
			float posx = radius * Mathf.Sin(anglepertime * timer * Mathf.Deg2Rad);
			float posy = radius * Mathf.Cos(anglepertime * timer * Mathf.Deg2Rad);

			posx += pivot.x;
			posy += pivot.y;
			transform.localPosition = new Vector3(posx, posy, transform.localPosition.z);
			yield return null;
		}

		gameObject.SetActive(false);
		yield break;
	}
}
