using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShipAnimation_PlayerShip_Index : ShipAnimation {

	public int m_Index;

	public List<GameObject> m_RowAnimationList = new List<GameObject>();
	public GameObject m_tempshadow;

	void LateUpdate()
	{
		if(m_tempshadow != null)
		{
			Vector3 newpos = transform.position;
			newpos.z += 2f;
			newpos.y -= 0.3f;
			m_tempshadow.transform.position = newpos;
		}
	}

	public override void PlayMoveLeftAnimation ()
	{
		if(!m_ShipAnimation.IsPlaying("PlayerShip"+ m_Index +"_Left"))
		{
			//Debug.Log("WTF@!!!");
			m_ShipAnimation.Play("PlayerShip"+ m_Index +"_Left");
		}
		m_RowAnimationList[0].gameObject.SetActive(false);
		m_WaveAnimationList[0].gameObject.SetActive(false);
	}

	public override void PlayMoveRightAnimation ()
	{
		if(!m_ShipAnimation.IsPlaying("PlayerShip"+ m_Index +"_Right"))
		{
			//Debug.Log("WTF@!!!");
			m_ShipAnimation.Play("PlayerShip"+ m_Index +"_Right");
		}
		m_RowAnimationList[2].gameObject.SetActive(false);
		m_WaveAnimationList[2].gameObject.SetActive(false);
	}

	public override void PlayIdleAnimation ()
	{
		base.PlayIdleAnimation ();
		if(!m_ShipAnimation.IsPlaying("PlayerShip"+ m_Index +"_Idle"))
		{
			//Debug.Log("WTF@!!!");
			m_ShipAnimation.Play("PlayerShip"+ m_Index +"_Idle");
		}
		//Debug.Log("??");
	}

	public override void PlayDeadAnimation ()
	{
		base.PlayDeadAnimation ();
		for(int i = 0; i < m_RowAnimationList.Count; i++)
		{
			m_RowAnimationList[i].gameObject.SetActive(false);
		}
		for(int i = 0; i < m_WaveAnimationList.Count; i++)
		{
			m_WaveAnimationList[i].gameObject.SetActive(false);
		}
	}

	//protected bool m_RowAnimationFlag = false;

	public override void PlayWaveAnimation (bool _row)
	{
		base.PlayWaveAnimation (_row);

		for(int i = 0; i < m_RowAnimationList.Count; i++)
		{
			m_RowAnimationList[i].gameObject.SetActive(_row);
		}

		for(int i = 0; i < m_WaveAnimationList.Count; i++)
		{
			m_WaveAnimationList[i].gameObject.SetActive(!_row);
		}
	}
}