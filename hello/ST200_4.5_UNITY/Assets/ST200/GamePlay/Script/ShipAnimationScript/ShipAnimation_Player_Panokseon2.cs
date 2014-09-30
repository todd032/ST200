using UnityEngine;
using System.Collections;

public class ShipAnimation_Player_Panokseon2 : ShipAnimation {
	
	public override void PlayIdleAnimation ()
	{
		base.PlayIdleAnimation ();
		if(!m_ShipAnimation.IsPlaying("PlayerShip2_Idle"))
		{
			m_ShipAnimation.Play("PlayerShip2_Idle");
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