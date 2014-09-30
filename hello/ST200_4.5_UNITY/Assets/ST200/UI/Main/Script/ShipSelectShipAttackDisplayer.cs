using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipSelectShipAttackDisplayer : MonoBehaviour {

	public List<ShipSelectShipBullet> m_ShipBulletList = new List<ShipSelectShipBullet>();
	public List<UISpriteAnimation> m_SmokeAnimationList = new List<UISpriteAnimation>();

	public float m_DisplayTime = 2f;
	protected float m_DisplayTimer = 0f;

	protected virtual void Update()
	{
		m_DisplayTimer += Time.deltaTime;
		if(m_DisplayTimer > m_DisplayTime)
		{
			m_DisplayTimer = 0f;
			Shoot();
		}

		for(int i = 0; i < m_SmokeAnimationList.Count; i++)
		{
			if(!m_SmokeAnimationList[i].isPlaying)
			{
				NGUITools.SetActive (m_SmokeAnimationList[i].gameObject, false);
			}
		}
	}

	public virtual void Shoot()
	{
		for(int i = 0; i < m_SmokeAnimationList.Count; i++)
		{
			m_SmokeAnimationList[i].Reset();
			NGUITools.SetActive(m_SmokeAnimationList[i].gameObject, true);
		}

		for(int i = 0; i < m_ShipBulletList.Count; i++)
		{
			m_ShipBulletList[i].Shoot();
		}
	}
}
