using UnityEngine;
using System.Collections;

public class PlayerController_Touch  : PlayerController {

	public UISprite m_RowGaugeRightSprite;
	public UISprite m_RowGaugeLeftSprite;

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
			if(m_PressLeft)
			{
				m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			}
			if(m_PressRight)
			{
				m_PlayerShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			}

			m_RowGaugeRightSprite.fillAmount = 1f - m_PlayerShip.RowGaugeRight / m_PlayerShip.MaxRowGauge;
			m_RowGaugeLeftSprite.fillAmount = 1f - m_PlayerShip.RowGaugeLeft / m_PlayerShip.MaxRowGauge;
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

	public void OnTapLeft()
	{
		if(m_PlayerShip != null)
		{
			m_PlayerShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayTapAmount, 1);
		}
	}

	public void OnTapRight()
	{
		if(m_PlayerShip != null)
		{
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