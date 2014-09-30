using UnityEngine;
using System.Collections;

public class ShipAnimation_PlayerSub_Index : ShipAnimation {

	public int m_Index;

	public override void PlayIdleAnimation ()
	{
		base.PlayIdleAnimation ();
		if(!m_ShipAnimation.IsPlaying("PlayerSubShip" + m_Index.ToString() + "_Idle"))
		{
			m_ShipAnimation.Play("PlayerSubShip" + m_Index.ToString() + "_Idle");
		}
		if(transform.eulerAngles.z > 180f)
		{
			transform.Rotate(Vector3.forward, 20f * Time.fixedDeltaTime);
		}else if(transform.eulerAngles.z > 0f)
		{
			transform.Rotate(Vector3.forward, -20f * Time.fixedDeltaTime);
		}
		//transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(0f,0f,0f), Time.fixedDeltaTime);
	}
}


