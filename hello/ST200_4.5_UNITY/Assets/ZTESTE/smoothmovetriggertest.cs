using UnityEngine;
using System.Collections;

public class smoothmovetriggertest : MonoBehaviour {

	public SmoothMoves.BoneAnimation m_Animation;

	// Use this for initialization
	void Start () {
		m_Animation.RegisterUserTriggerDelegate(userdel);
		//m_Animation.animation.
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			m_Animation.Play("Boss_Atteck");
		}else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			m_Animation.Play("Boss_Idle");
		}
		
	}

	public void userdel(SmoothMoves.UserTriggerEvent _event)
	{
		//Debug.Log("TRIGGER  " + _event.animationName + " : " + _event.tag);
		//AnimationEvent eve;
		//eve.intParameter 
	}
}
