using UnityEngine;
using System.Collections;

public class SubmarineBulletObject_Missile_Collider : MonoBehaviour {

	public SubmarineBulletObject_Missile m_Missile;

	void OnTriggerEnter(Collider _col)
	{
		if(m_Missile != null)
		{
			m_Missile.ApplyTarget(_col, 0);
		}
	}

	void OnTriggerStay(Collider _col)
	{
		if(m_Missile != null)
		{
			m_Missile.ApplyTarget(_col, 1);
		}
	}
}
