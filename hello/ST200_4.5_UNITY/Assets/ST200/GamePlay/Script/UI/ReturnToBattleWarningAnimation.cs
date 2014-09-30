using UnityEngine;
using System.Collections;

public class ReturnToBattleWarningAnimation : MonoBehaviour {

	public UISprite m_WarningSprite;
	public UITweener m_WarningTween;
	public UILabel m_CountingLabel;
	public UITweener m_CountingTween;

	protected bool m_IsPlaying = false;

	void Awake()
	{
		StopAnimation();
	}

	public void UpdateTimer(float _time)
	{
		m_CountingLabel.text = ((int)_time).ToString();
	}

	public void StartAnimation()
	{
		if(!m_IsPlaying)
		{
			m_IsPlaying = true;
			NGUITools.SetActive (m_WarningSprite.gameObject, true);
			NGUITools.SetActive (m_CountingLabel.gameObject, true);
			m_WarningTween.Play(true);
			m_CountingTween.Play(true);
		}
	}

	public void StopAnimation()
	{
		m_IsPlaying = false;
		m_WarningTween.ResetToBeginning();
		m_CountingTween.ResetToBeginning();
		NGUITools.SetActive (m_WarningSprite.gameObject, false);
		NGUITools.SetActive (m_CountingLabel.gameObject, false);
	}
}
