using UnityEngine;
using System.Collections;

public class WinLoseAnimation : MonoBehaviour {

	public TweenScale m_ScaleAnimation;
	public UISprite m_UISprite;
	public void PlayWinAnimation()
	{
		gameObject.SetActive(true);	
		m_ScaleAnimation.Play(true);
		m_UISprite.spriteName = "result_win";

		StartCoroutine(PlayAnimation());
	}

	public void PlayLoseAnimation()
	{
		gameObject.SetActive(true);
		m_ScaleAnimation.Play(true);
		m_UISprite.spriteName = "result_lose";

		StartCoroutine(PlayAnimation());
	}

	protected IEnumerator PlayAnimation()
	{
		yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);

		yield break;
	}

}
