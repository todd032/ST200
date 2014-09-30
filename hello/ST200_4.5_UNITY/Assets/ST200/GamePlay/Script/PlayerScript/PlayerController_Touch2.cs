using UnityEngine;
using System.Collections;

public class PlayerController_Touch2 : PlayerController {
	
	public UISprite m_RowGaugeRightSprite;

	protected bool m_PressStop = false;
	protected bool m_PressAccel = false;
	protected bool m_PressLeft = false;
	protected bool m_PressRight = false;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		
		#if UNITY_EDITOR
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			OnPressLeft();
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			OnPressRight();
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			OnReleaseLeft();
		}
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			OnReleaseRight();
		}
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			OnTapLeft();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			OnTapRight();
		}
		#endif
		
		if(m_PlayerShip != null)
		{			
			if(!m_PressStop)
			{
				m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				m_PlayerShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			}else
			{

			}

			if(m_PressLeft)
			{
				//m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				//m_PlayerShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				m_PlayerShip.SetRotationInput(1f);
			}
			if(m_PressRight)
			{
				//m_PlayerShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				//m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				m_PlayerShip.SetRotationInput(-1f);
			}

			if(!m_PressLeft && !m_PressRight)
			{
				m_PlayerShip.SetRotationInput(0f);
			}

			m_RowGaugeRightSprite.fillAmount = 1f - ((m_PlayerShip.RowGaugeRight - m_PlayerShip.MaxRowGauge * m_PlayerShip.RowGaugeLimitByPress)  / (m_PlayerShip.MaxRowGauge * (1f - m_PlayerShip.RowGaugeLimitByPress)));
		}
		
	}
	
	public void OnPressLeft()
	{
		
		m_PressLeft = true;
	}
	
	public void OnPressRight()
	{
		
		m_PressRight = true;
	}

	public void OnPressAccel()
	{
		m_PressAccel = true;
	}

	public void OnPressStop()
	{
		m_PressStop = true;
	}

	public void OnTapLeft()
	{
		if(m_PlayerShip != null)
		{
			m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayTapAmount, 1);
			m_PlayerShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayTapAmount, 1);
		}
	}
	
	public void OnTapRight()
	{
		if(m_PlayerShip != null)
		{
			m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayTapAmount, 1);
			m_PlayerShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayTapAmount, 1);
		}
	}
	
	public void OnReleaseLeft()
	{
		m_PressLeft = false;
	}
	
	public void OnReleaseRight()
	{
		m_PressRight = false;
	}

	public void OnReleaseAccel()
	{
		m_PressAccel = false;
	}

	public void OnReleaseStop()
	{
		m_PressStop = false;
	}

	public void OnClickTaticButton()
	{
		if(GamePlayerManager.Instance.IsSubShipAlive())
		{
			GamePlayerManager.Instance.ToggleTactic();
			if(!GamePlayerManager.Instance.m_IsUsingTactic)
			{
				//show fx
				GameManager.Instance.GUIManager.m_TacticAnimation.PlayAnimation(0);
			}else
			{
				GameManager.Instance.GUIManager.m_TacticAnimation.PlayAnimation(Managers.UserData.GetCurrentGameCharacter().SelectedTactic);
			}
		}
	}
}