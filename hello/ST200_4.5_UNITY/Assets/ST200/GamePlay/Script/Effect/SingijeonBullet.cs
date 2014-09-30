using UnityEngine;
using System.Collections;

public class SingijeonBullet : MonoBehaviour {
	
	public Collider2D m_Collider;
	public tk2dSprite m_MissileAnimation;
	public tk2dSpriteAnimator m_ExplosionAnimation;
	
	Vector3 m_StartPosition;
	Vector3 m_EndPosition;
	public bool isPlaying = false;
	private bool m_Exploded = false;
	public float m_StartDelay = 1f;
	
	public float m_MoveFactor = 1f;
	
	private float m_DelayTimer = 0f;
	private float m_MoveValue = 0f;
	
	void Awake()
	{
		m_MissileAnimation.gameObject.SetActive(false);
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
				transform.position = Vector3.Lerp(m_StartPosition, m_EndPosition,
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

	public void ShootBullet(float _delaytime, Vector3 _startposition, Vector3 _endposition)
	{
		m_StartDelay = _delaytime;
		m_DelayTimer = 0f;
		m_MoveValue = 0f;
		isPlaying = true;
		m_MissileAnimation.gameObject.SetActive(true);
		m_ExplosionAnimation.gameObject.SetActive(false);
		//m_MissileAnimation.transform.position = m_StartPosition;
		transform.position = _startposition;
		m_StartPosition = _startposition;
		m_EndPosition = _endposition;
		m_Collider.enabled = false;
		m_Exploded = false;
	}
	
	private void ExplosionAnimationEvent(tk2dSpriteAnimator _animator, tk2dSpriteAnimationClip _clip)
	{
		m_Collider.enabled = false;
		m_ExplosionAnimation.gameObject.SetActive(false);
		isPlaying = false;
		m_Exploded = false;
	}
}
