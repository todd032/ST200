using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAnimation : MonoBehaviour {

	public tk2dSpriteAnimator m_ShipAnimation;
	public List<tk2dSpriteAnimator> m_WaveAnimationList;
	public tk2dSpriteAnimator m_WaveLAnimation;
	public tk2dSpriteAnimator m_WaveRAnimation;

	void Awake()
	{
		InitAnimation();
		PlayIdleAnimation();
	}

	public virtual void InitAnimation()
	{
		PlayWaveAnimation(false);
	}

	public virtual void PlayIdleAnimation()
	{
		m_WaveLAnimation.gameObject.SetActive(true);
		m_WaveRAnimation.gameObject.SetActive(true);
		//PlayWaveAnimation(false);
	}

	public virtual void PlayMoveLeftAnimation()
	{
		m_WaveLAnimation.gameObject.SetActive(true);
		m_WaveRAnimation.gameObject.SetActive(false);
	}

	public virtual void PlayMoveRightAnimation()
	{
		m_WaveLAnimation.gameObject.SetActive(false);
		m_WaveRAnimation.gameObject.SetActive(true);
	}

	public virtual void PlayDeadAnimation()
	{
		m_ShipAnimation.Play("DeadAnimation");
		m_WaveLAnimation.gameObject.SetActive(false);
		m_WaveRAnimation.gameObject.SetActive(false);
	}

	public virtual void PlayWaveAnimation(bool _row)
	{

	}
}
