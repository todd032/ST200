using UnityEngine;
using System.Collections;

public class InGameBossWarningLineAnimation : MonoBehaviour {

	public TweenColor m_MidLineColor;
	public TweenScale m_MidLineScale;

	public void StartAnimation()
	{
		StartCoroutine(PlayLineAnimation());
	}

	IEnumerator PlayLineAnimation()
	{
		m_MidLineColor.Play(true);

		//m_MidLineScale.Reset();
		m_MidLineScale.Play(true);

		while(m_MidLineScale.tweenFactor < 1f)
		{
			yield return null;
		}

		yield return null;
		yield break;
	}

	public void FadeOutAnimation()
	{
		m_MidLineColor.Play(false);
	}
}
