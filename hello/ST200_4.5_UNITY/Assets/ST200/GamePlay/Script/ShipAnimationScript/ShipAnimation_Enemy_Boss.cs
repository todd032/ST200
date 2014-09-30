using UnityEngine;
using System.Collections;

public class ShipAnimation_Enemy_Boss  : ShipAnimation {
	
	public override void PlayIdleAnimation ()
	{
		base.PlayIdleAnimation ();
		m_ShipAnimation.Play("Boss1_Idle");
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