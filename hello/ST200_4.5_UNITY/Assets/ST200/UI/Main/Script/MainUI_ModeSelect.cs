using UnityEngine;
using System.Collections;

public class MainUI_ModeSelect : MonoBehaviour {

	public UILabel m_StageModeExplainLabel;
	public UILabel m_StageModeButtonLabel;
	public UILabel m_PVPModeExplainLabel;
	public UILabel m_PVPModeButtonLabel;

	void Awake()
	{
		m_StageModeButtonLabel.text = Constant.COLOR_MAIN_TITLE + TextManager.Instance.GetString(241);
		m_PVPModeButtonLabel.text = Constant.COLOR_MAIN_TITLE + TextManager.Instance.GetString(241);

		m_StageModeExplainLabel.text = Constant.COLOR_WHITE + TextManager.Instance.GetReplaceString(242, Managers.UserData.UserNickName);
		m_PVPModeExplainLabel.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(243);
	}
		
	public void RemoveUI()
	{
		NGUITools.SetActive(gameObject, false);
	}
	
	public void ShowUI()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickCloseButton();
			return true;
		}
		return false;
	}

	public void OnClickStageModeButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		// Connect Icon Start!!!!
		//_indicatorPopupView.LoadIndicatorPopupView();
		Managers.UserData.ExperienceIndex = 0;
		//
		
		if (Managers.DataStream != null){
			
			if (Managers.UserData != null){
				
				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
				Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
					
					//_indicatorPopupView.RemoveIndicatorPopupView() ;
					
					if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
						
						//	_indicatorPopupView.RemoveIndicatorPopupView() ;
					} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
						
						//	_uiRootAlertView.LoadUIRootAlertView(11) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
						//	_uiRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate ;
						
					}else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
					{
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
					} else {
						
						//	_uiRootAlertView.LoadUIRootAlertView(21) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						//	_uiRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate ;
					}
					//Debug.Log("RESULT: " + intResult_Code_Input);
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
				};
				
				Managers.UserData.UpdateSequence++;
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
				
				Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
				GameUIManager.Instance.SwitchToStageSelectManager();
				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
			}
		}
		RemoveUI();
	}

	protected bool initpvp = false;
	public void OnClickPVPModeButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.SelectedGameType = Constant.ST200_GAMEMODE_PVP;

		if(!initpvp)
		{
			Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
			{
				if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
				{					
					Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input2, string strResult_Extend_Input2) => 
					{
						if(intResult_Code_Input2 == Constant.NETWORK_RESULTCODE_OK)
						{							
							GameUIManager.Instance.SwitchToPVPUI();
							RemoveUI();
						}else
						{
							Managers.DataStream.PVP_Request_FriendList(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
						}
					};
					Managers.DataStream.PVP_Request_FriendList(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
				}else
				{
					Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
				}
			};
			Managers.DataStream.PVP_Request_Recommend(Managers.UserData.UserNickName, Managers.UserData.GetUserMaxClearStage());
		}else
		{
			GameUIManager.Instance.SwitchToPVPUI();
			RemoveUI();
		}
		
		initpvp = true;
		//Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveUI();
	}
}
