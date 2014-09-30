using UnityEngine;
using System.Collections;

public class SpecialAttackMissile : SubmarineSpecialAttackCollider {

	public Collider m_Collider;
	public tk2dSprite m_MissileAnimation;
	public tk2dSpriteAnimator m_ExplosionAnimation;

	Vector3 m_StartPosition;
	public bool isPlaying = false;
	private bool m_Exploded = false;
	public float m_StartDelay = 1f;

	public float m_MoveFactor = 1f;

	private float m_DelayTimer = 0f;
	private float m_MoveValue = 0f;

	void Awake()
	{
		m_MissileAnimation.gameObject.SetActive(false);
		m_StartPosition = m_MissileAnimation.transform.position;
		m_ExplosionAnimation.AnimationCompleted += ExplosionAnimationEvent;
		m_Collider.enabled = false;
	}
	

	public void Process()
	{
		if(isPlaying)
		{
			m_DelayTimer += Time.deltaTime;
			if(m_DelayTimer > m_StartDelay)
			{
				m_MoveValue += Time.deltaTime * m_MoveFactor;
				m_MissileAnimation.transform.position = Vector3.Lerp(m_StartPosition, m_Collider.transform.position,
				                                                     m_MoveValue);

				if(m_MoveValue > 1f && !m_Exploded)
				{
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Explosion,false);
					m_Exploded = true;
					m_MissileAnimation.gameObject.SetActive(false);
					m_ExplosionAnimation.gameObject.SetActive(true);
					m_ExplosionAnimation.Play();
					m_Collider.enabled = true;
					GameManager.Instance._cameraShakeScript.DoCameraShake(0.075f, 0.004f);
				}
			}
		}
	}

	public void ResetObejct(float _delaytime)
	{
		m_StartDelay = _delaytime;
		m_DelayTimer = 0f;
		m_MoveValue = 0f;
		isPlaying = true;
		m_MissileAnimation.gameObject.SetActive(true);
		m_MissileAnimation.transform.position = m_StartPosition;
		m_Collider.enabled = false;
	}

	private void ExplosionAnimationEvent(tk2dSpriteAnimator _animator, tk2dSpriteAnimationClip _clip)
	{
		m_Collider.enabled = false;
		m_ExplosionAnimation.gameObject.SetActive(false);
		isPlaying = false;
		m_Exploded = false;
	}
}
