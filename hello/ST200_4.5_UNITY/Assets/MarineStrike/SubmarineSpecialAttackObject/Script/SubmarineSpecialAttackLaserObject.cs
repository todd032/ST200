using UnityEngine;
using System.Collections;

public class SubmarineSpecialAttackLaserObject : SubmarineSpecialAttackObject {
	public float m_TimeRemain;
	public tk2dClippedSprite m_DisplaySprite;
	public tk2dAnimatedSprite m_AnimatedSprite;
	public tk2dSprite m_HitEffectSprite;
	public BoxCollider m_Collider;
	public Vector3 m_DeltaStartPosition = new Vector3(0.2f,0f,0f);
	public Vector3 m_DeltaEndPosition = new Vector3(-0.2f,0f, 0f);
	public Transform m_HitObjectTransform;
	protected float m_DurationTime = 0f;
	protected override void Awake ()
	{
		SetActive(false);
	}

	void LateUpdate()
	{
		UpdateDisplaySprite();
	}

	void OnDestroy()
	{
		if(AudioObject != null)
		{
			AudioObject.StopGameAudioObject();
			AudioObject = null;
		}
	}

	public void Reset(Submarine _sub, float _damage, float _duration)
	{
		Reset(_sub, _damage);
		m_DurationTime = _duration;
	}

	public override void PlaySpecialAttack (float delaytime)
	{
		StopAllCoroutines();
		
		StartCoroutine(ProcessSpecialAttack(delaytime));
	}

	GameAudioObject AudioObject;
	protected override IEnumerator ProcessSpecialAttack (float delaytime)
	{
		m_IsPlaying = true;		
		m_TimeRemain = 0f;
		yield return new WaitForSeconds(delaytime);
		SetActive(true);
		_Submarine.StopFireBullet();
		//m_AnimatedSprite.clipId = m_AnimatedSprite.GetClipIdByName("Special_Attack_Laser_Start_Anim");
		m_AnimatedSprite.Play();
		m_Collider.enabled = false;

		yield return null;

		AudioObject = null;
		if ( Managers.Audio != null) 
		{
			 AudioObject = Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Laser,true);
		}

		while(m_AnimatedSprite.IsPlaying("Special_Attack_Laser_Start_Anim"))
		{

			yield return null;
		}

		//m_AnimatedSprite.clipId = m_AnimatedSprite.GetClipIdByName("Special_Attack_Laser_Anim");	
		m_AnimatedSprite.Play();
		m_Collider.enabled = true;
		while(true)
		{
			if(m_TimeRemain > m_DurationTime)
			{
				break;
			}
			transform.position = _Submarine.transform.position;
			m_TimeRemain += Time.deltaTime;
			_Submarine.InvincibilityStart();
			yield return null;
		}

		//m_AnimatedSprite.clipId = m_AnimatedSprite.GetClipIdByName("Special_Attack_Laser_FadeOut_Anim");
		m_AnimatedSprite.Play();
		m_Collider.enabled = false; 
		m_HitObjectTransform = null;

		while(m_AnimatedSprite.IsPlaying("Special_Attack_Laser_FadeOut_Anim"))
		{
			_Submarine.InvincibilityStart();
			yield return null;
		}
		AudioObject.StopGameAudioObject();

		SetActive(false);
		_Submarine.StartFireBullet();
		_Submarine.InvincibilityStop();
		m_IsPlaying = false;
		yield break;
	}

	public override void SetActive (bool b)
	{
		base.SetActive (b);
		m_DisplaySprite.gameObject.SetActive(b);
	}

	bool createeffect = true;
	public override void ApplyGameStagePatternObject(Transform _hitobject)
	{
		if(_hitobject == null)
		{
			m_HitObjectTransform = null;
			return;
		}else
		{
			if(createeffect)
			{
				createeffect = false;
				Vector3 randomvec = new Vector3(Random.Range(-0.15f,0.15f), Random.Range(-0.15f,0.15f), 0f);
				Vector3 createposition = new Vector3(_hitobject.transform.position.x, _hitobject.transform.position.y,-1f) + randomvec;
				GameObject _go = PoolManager.Spawn("SpecialAttackLaserEffectObject") ;
				_go.transform.position = createposition;
				SpecialAttackLaserEffectObject effectobject = _go.GetComponent<SpecialAttackLaserEffectObject>();
				effectobject.SetActiveSpriteObject(true);
				effectobject.StartAction();

				if(Managers.Audio != null)
				{
					Managers.Audio.PlayMultiFXSound(AudioManager.FX_SOUND.FX_Explosion,false, 10);
				}
			}else
			{
				createeffect = true;
			}

		}
		//else
		//{
		//	if(m_HitObjectTransform == null)
		//	{
		//		m_HitObjectTransform = _hitobject;
		//	}else
		//	{
		//		if(m_HitObjectTransform.transform.position.x > _hitobject.transform.position.x)
		//		{
		//			m_HitObjectTransform = _hitobject;
		//		}
		//	}
		//}
	}

	protected void UpdateDisplaySprite()
	{
		m_DisplaySprite.transform.position = _Submarine.transform.position + m_DeltaStartPosition;
		m_DisplaySprite.SetSprite(m_DisplaySprite.GetSpriteIdByName(m_AnimatedSprite.CurrentSprite.name));
		//Debug.Log("??: " + m_AnimatedSprite.CurrentSprite.name + " ???:" + m_DisplaySprite.spriteId + " :::" + m_AnimatedSprite.spriteId);
		if(m_HitObjectTransform != null && !m_HitObjectTransform.gameObject.activeInHierarchy)
		{
			m_HitObjectTransform = null;
		}

		//check distance with hitobject and clip
		if(m_HitObjectTransform == null)
		{
			Rect newrect = m_DisplaySprite.ClipRect;
			newrect.width = 1f;
			m_DisplaySprite.ClipRect = newrect;
			m_HitEffectSprite.gameObject.SetActive(false);

			float width = m_DisplaySprite.GetUntrimmedBounds().size.x + m_DeltaEndPosition.x;
			m_Collider.center = new Vector3(width/2f, 0f,0f);
			m_Collider.size = new Vector3(width, m_Collider.size.y, 10f);
		}else
		{
			m_HitEffectSprite.gameObject.SetActive(true);
			Vector3 hiteffectposition = m_DisplaySprite.transform.position;
			hiteffectposition.x = m_HitObjectTransform.position.x + m_DeltaEndPosition.x;
			hiteffectposition.z -= 1f;
			m_HitEffectSprite.transform.position = hiteffectposition;

			//check distance and width of image
			float distance = Mathf.Abs(m_DisplaySprite.transform.position.x - m_HitObjectTransform.position.x) + m_DeltaEndPosition.x;
			float width = m_DisplaySprite.GetUntrimmedBounds().size.x;

			float clippedwidth = 1f;
			if(width > distance)
			{
				clippedwidth = distance/width;

				Rect newrect = m_DisplaySprite.ClipRect;
				newrect.width = clippedwidth;
				m_DisplaySprite.ClipRect = newrect;
			}

			m_Collider.center = new Vector3((distance - m_DeltaEndPosition.x)/2f, 0f,0f);
			m_Collider.size = new Vector3((distance - m_DeltaEndPosition.x), m_Collider.size.y, 10f);
		}
	}

	public override float GetContiniousDamage (Transform _object, float _deltatime)
	{
		return m_SpecialAttackDamage * _deltatime;
	}

	public override float GetDamage (Transform _object)
	{
		return 0f;
	}

	public void SpecialAttackDone()
	{
		m_TimeRemain = m_DurationTime;
	}
}
