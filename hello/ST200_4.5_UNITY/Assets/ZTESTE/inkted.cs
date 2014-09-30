using UnityEngine;
using System.Collections;

public class inkted : MonoBehaviour {
	public UITweener m_Tween;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("?");
			//m_Tween.Reset();
			m_Tween.Play(true);
		}
	}
}
