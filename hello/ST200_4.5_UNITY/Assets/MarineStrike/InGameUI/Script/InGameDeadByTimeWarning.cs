using UnityEngine;
using System.Collections;

public class InGameDeadByTimeWarning : MonoBehaviour {

	public TweenPosition m_PositionAnim;
	private bool m_IsPlaying = false;
	// Use this for initialization
	void Start () {
		//m_PositionAnim.Reset();
	}

	public void PlayAnim()
	{
		//m_PositionAnim.Reset();
		m_PositionAnim.Play(true);
		m_IsPlaying = true;
	}

	public bool IsPlaying()
	{
		bool flag = m_PositionAnim.tweenFactor < 1f;
		if(!flag)
		{
			m_IsPlaying = false;
		}
		//Debug.Log("H: " + m_PositionAnim.tweenFactor + " FLAG: " + flag);
		return flag && m_IsPlaying;
	}
}
