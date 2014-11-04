using UnityEngine;
using System.Collections;

public class PVPUI_DetailUI : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_RewardLabel;
	public UILabel m_FightCostLabel;

	public PVPUI_Detail_PlayerUI m_PlayerUI;
	public PVPUI_Detail_OppUI m_OppUI;

	void Awake()
	{
		m_TitleLabel.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString(260);
	}

	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void InitUI()
	{
		m_PlayerUI.InitUI();
		m_OppUI.InitUI(PVPDataManager.Instance.m_SelectedPVPUserInfo);
		m_RewardLabel.text = PVPDataManager.Instance.m_SelectedPVPUserInfo.RewardAmount.ToString();
		m_FightCostLabel.text = Managers.GameBalanceData.PVPPlayCost.ToString();
	}

	public void OnClickFightButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.SelectedGameType = Constant.ST200_GAMEMODE_PVP;

		if(Managers.UserData.SetSpendGold(Managers.GameBalanceData.PVPPlayCost) == 1)
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
							
				if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){

					ST200KLogManager.Instance.SaveGamePVPStart();
					ST200KLogManager.Instance.SendToServer();
					Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
					
				} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
					
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
					Managers.UserData.SetGainGold(Managers.GameBalanceData.PVPPlayCost);
				} else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
					Managers.UserData.SetGainGold(Managers.GameBalanceData.PVPPlayCost);
				}else {

					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
					Managers.UserData.SetGainGold(Managers.GameBalanceData.PVPPlayCost);
				}
			};
			
			Managers.UserData.UpdateSequence++;
			UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
			
			Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
		}else
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN);
		}
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_PVPUI.ShowPVPUI(false);
	}
}
