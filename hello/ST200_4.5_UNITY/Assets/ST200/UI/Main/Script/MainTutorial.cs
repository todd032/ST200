using UnityEngine;
using System.Collections;

public class MainTutorial : MonoBehaviour {

	public GameObject m_StartTutorialGameObject;

	public GameObject m_CharacterGameObject;
	public GameObject m_TacticGameObject;
	public GameObject m_ShipGameObject;
	public GameObject m_SubShipGameObject;
	public GameObject m_ReadyGameObject;
	public GameObject m_SelectStageGameObject;

	public GameObject m_ItemBuyGameObject;

	public void StartTutorial()
	{
		m_StartTutorialGameObject.gameObject.SetActive(true);
	}

	public void OnClickStartTutorial()
	{
		m_StartTutorialGameObject.gameObject.SetActive(false);
		m_CharacterGameObject.SetActive(true);
	}

	public void OnClickCharacter()
	{
		m_CharacterGameObject.SetActive(false);
		m_TacticGameObject.SetActive (true);

	}

	public void OnTactic()
	{
		m_TacticGameObject.SetActive (false);
		m_ShipGameObject.SetActive(true);
		GameUIManager.Instance.m_MainUI.ChangePanel(0);
	}

	public void OnClickShip()
	{
		m_ShipGameObject.SetActive(false);
		m_SubShipGameObject.SetActive(true);
		GameUIManager.Instance.m_MainUI.ChangePanel(2);
	}

	public void OnClickSubShip()
	{
		m_SubShipGameObject.SetActive(false);
		m_ReadyGameObject.SetActive (true);
	}

	public void OnClickReady()
	{
		m_ReadyGameObject.SetActive (false);
		m_SelectStageGameObject.SetActive (true);
		GameUIManager.Instance.SwitchToStageSelectManager();
	}

	public void OnStageSelect()
	{
		m_SelectStageGameObject.SetActive (false);
		m_ItemBuyGameObject.SetActive (true);
		Managers.UserData.SelectedStageIndex = 1;
		Managers.UserData.SelectedGameType = Constant.ST200_GAMEMODE_STAGE_NORMAL;
		GameUIManager.Instance.SwitchToGameShopManager();
	}

	public void OnClickGameStart()
	{
		m_CharacterGameObject.SetActive(false);
		m_ShipGameObject.SetActive(true);
	}
}
