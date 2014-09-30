using UnityEngine;
using System.Collections;

public class PetBulletObject : MonoBehaviour {

	protected float m_Damage = 50f;
	protected bool m_IsProcessing;
	protected bool m_IsPlaying = false;
	protected float m_BulletSpeed = 2f;
	public Transform m_PetObject;
	public virtual void Process()
	{
		if(!m_IsProcessing)
		{
			return;
		}
	}

	public virtual void Pause()
	{
		m_IsProcessing = false;
	}

	public virtual void Resume()
	{
		m_IsProcessing = true;
	}

	public virtual void StartAction()
	{
		m_IsProcessing = true;
	}

	public virtual void ResetObject(Transform _petObject, float _damage)
	{
		m_PetObject = _petObject;
		m_Damage = _damage;
	}

	public virtual float GetHitDamage()
	{
		return 0f;
	}

	public virtual float GetContinousDamage()
	{
		return 0f;
	}

	public virtual void ApplyHitObject(Transform _object)
	{

	}

	public virtual bool IsPlaying()
	{
		return m_IsPlaying;
	}
}
