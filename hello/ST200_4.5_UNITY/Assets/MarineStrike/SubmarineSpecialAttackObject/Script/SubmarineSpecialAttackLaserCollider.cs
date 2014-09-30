using UnityEngine;
using System.Collections;

public class SubmarineSpecialAttackLaserCollider : SubmarineSpecialAttackCollider {
	public SubmarineSpecialAttackLaserObject m_LaserObject;

	void OnTriggerEnter(Collider coll)
	{
		if(coll.CompareTag("ENEMY"))
		{	
			//Debug.Log("enter ~_~");
			m_LaserObject.ApplyGameStagePatternObject(coll.transform);
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if(coll.CompareTag("ENEMY"))
		{
			//Debug.Log("stay ~_~");
			m_LaserObject.ApplyGameStagePatternObject(coll.transform);
		}
	}

	void OnTriggerExit(Collider coll)
	{
		if(coll.CompareTag("ENEMY"))
		{	
			//Debug.Log("EXIT ~_~");
			m_LaserObject.ApplyGameStagePatternObject(null);
		}
	}
}
