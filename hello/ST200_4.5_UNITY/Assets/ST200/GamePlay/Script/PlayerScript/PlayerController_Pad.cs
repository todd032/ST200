using UnityEngine;
using System.Collections;

public class PlayerController_Pad : PlayerController {
	protected bool m_Pressed = false;
	protected Vector3 m_DragStartPosition = Vector3.zero;
	
	public GameObject m_PadPivot;
	public UISprite m_PadSprite;
	protected float m_PadMaxMoveDistance = 50f;
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(m_PlayerShip != null)
		{
			if(m_Pressed)
			{
				Vector3 currentmousposition = Input.mousePosition;
				Vector3 deltamousposition = (m_DragStartPosition - currentmousposition);
				//Debug.Log("DELTA: " + deltamousposition);
				m_PlayerShip.m_HeadDirection = deltamousposition.normalized;

				NGUITools.SetActive(m_PadPivot.gameObject , true);
				Vector3 padposition = -deltamousposition;
				if(padposition.magnitude > m_PadMaxMoveDistance)
				{
					padposition = padposition.normalized * m_PadMaxMoveDistance;
				}
				m_PadSprite.transform.localPosition =  padposition;
			}else
			{
				m_PlayerShip.m_HeadDirection = Vector3.zero;
				NGUITools.SetActive(m_PadPivot.gameObject , false);
			}
		}
	}
	
	public void OnPressMoveScreen()
	{
		m_Pressed = true;
		m_DragStartPosition = Input.mousePosition;
		Vector3 screentoworld = m_UICamera.ScreenToWorldPoint(m_DragStartPosition);
		m_PadPivot.transform.position = screentoworld;
	}
	
	public void OnReleaseMoveScreen()
	{
		m_Pressed = false;
	}
}
