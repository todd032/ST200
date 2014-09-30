using UnityEngine;
using System.Collections;

public class InGameBossWarningAnimation : MonoBehaviour {

	[HideInInspector]
	public delegate void BossComeInDelegate(int _state);
	protected BossComeInDelegate m_BossComeInDelegate ;
	public event BossComeInDelegate BossComeInEvent {
		add{
			m_BossComeInDelegate = null ;
			if (m_BossComeInDelegate == null) {
				m_BossComeInDelegate += value;
			}
		}
		remove{
			m_BossComeInDelegate -= value;
		}
	}

	public TweenScale m_WarningSpriteScaleAnim;
	public TweenColor m_WarningSpriteColorAnim;
	public InGameBossWarningLineAnimation m_TopLineAnimation;
	public InGameBossWarningLineAnimation m_BotLineAnimation;
	public TweenScale m_TextScaleAnim;
	public TweenColor m_TextColorAnim;
	public TweenColor m_BackgroundColorAnim;

	void Awake()
	{
		gameObject.SetActive(false);
	}

	void Update()
	{
	}

	public void PlayAnim(BossComeInDelegate _delegate)
	{
		BossComeInEvent += _delegate;
		gameObject.SetActive(true);
		StartCoroutine(PlayAnimation());
	}

	IEnumerator PlayAnimation()
	{
		//m_WarningSpriteScaleAnim.Reset();
		//m_BackgroundColorAnim.Reset();
		//m_WarningSpriteScaleAnim.Reset();
		//m_WarningSpriteColorAnim.Reset();
		//m_TextScaleAnim.Reset();
		//m_TextColorAnim.Reset();

		m_WarningSpriteScaleAnim.Play(true);

		m_TopLineAnimation.StartAnimation();
		m_BotLineAnimation.StartAnimation();

		yield return new WaitForSeconds(1f);
		m_BackgroundColorAnim.Play(true);
		m_TextScaleAnim.Play(true);

		yield return new WaitForSeconds(1f);
		m_WarningSpriteColorAnim.Play(true);
		m_TopLineAnimation.FadeOutAnimation();
		m_BotLineAnimation.FadeOutAnimation();
		m_TextColorAnim.Play(true);
		m_BackgroundColorAnim.Play(false);

		yield return new WaitForSeconds(0.5f);
		m_BossComeInDelegate(1);
		gameObject.SetActive(false);
		yield break;
	}
}
