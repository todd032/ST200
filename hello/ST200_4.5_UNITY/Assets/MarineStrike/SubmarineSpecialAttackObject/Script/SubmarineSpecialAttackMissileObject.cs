using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubmarineSpecialAttackMissileObject : SubmarineSpecialAttackObject {

	public List<SpecialAttackMissile> m_Missiles = new List<SpecialAttackMissile>();
	public List<Transform> m_HitPatternObjects = new List<Transform>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0))
		//{
		//	for(int i = 0; i < m_Missiles.Count; i++)
		//	{
		//		m_Missiles[i].ResetObejct(0.15f * (float)(i + 1f));
		//	}
		//
		//	PlaySpecialAttack(0f);
		//}
	}

	public override float GetDamage (Transform _object)
	{
		if(m_HitPatternObjects.Contains(_object))
		{
			return 0f;
		}else
		{
			m_HitPatternObjects.Add(_object);
		}

		return m_SpecialAttackDamage;
	}

	public override void PlaySpecialAttack (float delaytime)
	{
		m_HitPatternObjects.Clear();
		StopAllCoroutines();
		for(int i = 0; i < m_Missiles.Count; i++)
		{
			m_Missiles[i].ResetObejct(0.15f * (float)(i + 1f));
		}

		StartCoroutine(ProcessSpecialAttack(delaytime));
	}

	protected override IEnumerator ProcessSpecialAttack (float delaytime)
	{
		m_IsPlaying = true;
		while(true)
		{
			for(int i = 0; i < m_Missiles.Count; i++)
			{
				m_Missiles[i].Process();
			}

			bool finished = true;
			for(int i = 0; i < m_Missiles.Count; i++)
			{
				if(m_Missiles[i].isPlaying)
				{
					finished = false;
					break;
				}
			}

			if(finished)
			{
				break;
			}
			_Submarine.InvincibilityStart();
			yield return null;
		}
		m_IsPlaying = false;
		_Submarine.InvincibilityStop();
	}
}
