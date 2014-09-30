using UnityEngine;
using System.Collections;

public class ShipAnimation_Enemy_Index_Animation :  ShipAnimation {

	public int m_Type;

	public override void PlayIdleAnimation ()
	{
		base.PlayIdleAnimation ();
		m_ShipAnimation.Play("Enemy" + m_Type + "_Idle");
	}
	
	public override void PlayMoveLeftAnimation ()
	{
		base.PlayMoveLeftAnimation ();
	}
	
	public override void PlayMoveRightAnimation ()
	{
		base.PlayMoveRightAnimation ();
	}
	
	public override void PlayDeadAnimation ()
	{
		base.PlayDeadAnimation ();
		if(!m_ShipAnimation.IsPlaying("DeadAnimation"))
		{
			m_ShipAnimation.Play("DeadAnimation");
		}
	}
}
