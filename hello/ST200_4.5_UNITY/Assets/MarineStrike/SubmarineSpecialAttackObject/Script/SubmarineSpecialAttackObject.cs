using UnityEngine;
using System.Collections;

public class SubmarineSpecialAttackObject : MonoBehaviour {

	protected bool m_IsPlaying = false;
	public Submarine _Submarine;
	public float m_SpecialAttackDamage = 20f;
	protected virtual void Awake()
	{

	}

	public virtual bool IsPlaying()
	{
		return m_IsPlaying;
	}

	public virtual void Reset(Submarine _sub, float _damage)
	{
		_Submarine = _sub;
		m_SpecialAttackDamage = _damage;
	}
	
	public virtual void PlaySpecialAttack(float delaytime)
	{
		StartCoroutine(ProcessSpecialAttack(delaytime));
	}
	
	protected virtual IEnumerator ProcessSpecialAttack(float delaytime)
	{
		yield return null;
	}
	
	public virtual void SetActive(bool b)
	{

	}

	public virtual void ApplyGameStagePatternObject(Transform _hitobject)
	{

	}

	public virtual float GetContiniousDamage(Transform _object, float _deltatime)
	{
		return 0f;
	}

	public virtual float GetDamage(Transform _object)
	{
		return 0f;
	}
}
