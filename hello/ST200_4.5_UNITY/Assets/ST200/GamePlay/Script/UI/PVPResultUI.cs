using UnityEngine;
using System.Collections;

public class PVPResultUI : MonoBehaviour {

	public UISprite m_TitleBG;
	public UISprite m_BG;

	public UILabel m_ResultLabel;
	public UILabel m_RewardText;
	public UILabel m_RewardLabel;

	public UILabel m_RateText;
	public UILabel m_RateLabel;

	public UILabel m_OkLabel;

	void Awake()
	{
		m_RewardText.text = Constant.COLOR_PVPRESULT_DESCRIPTION + TextManager.Instance.GetString(253);
		m_RateText.text = Constant.COLOR_PVPRESULT_DESCRIPTION + TextManager.Instance.GetString(254);
		m_OkLabel.text = TextManager.Instance.GetString(41);
	}

	public void InitUI(bool _win, int _reward, int _wincount, int _losecount)
	{
		NGUITools.SetActive (gameObject, true);
		if(_win)
		{
			m_TitleBG.spriteName = "main_title_bg";
			m_BG.spriteName = "main_char_info_box";
			m_ResultLabel.text = Constant.COLOR_BLUE + TextManager.Instance.GetString(251);
		}else
		{
			m_BG.spriteName = "ready_bg";
			m_TitleBG.spriteName = "ready_title_bg";
			m_ResultLabel.text = Constant.COLOR_RED + TextManager.Instance.GetString(252);
		}

		string reward = "0";
		if(_reward != 0)
		{
			reward = _reward.ToString("#,#");
		}
		m_RewardLabel.text = Constant.COLOR_RED + "x" + reward;

		m_RateLabel.text = Constant.COLOR_RED + _wincount.ToString() + TextManager.Instance.GetString(248) + " " + _losecount.ToString() + 
			TextManager.Instance.GetString(249);

	}

	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if (Managers.DataStream != null) {
			
			if (Managers.UserData != null) {
				ST200AdmobManager.Instance.ShowInterstitial();
				Managers.UserData.UpdateSequence++;
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
						
				// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
				Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
					
					//_indicatorPopupView.RemoveIndicatorPopupView();
					
					if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK) {
						
						ST200KLogManager.Instance.SendToServer();
						Application.LoadLevel("Ranking");
						Time.timeScale = 1f;
						
					} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
						
						//_uiRootAlertView.LoadUIRootAlertView(11); 
						
					} else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
					{
						GameManager.Instance.GUIManager._uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
					} else {
						
						//_uiRootAlertView.LoadUIRootAlertView(21); 
					}
				};
					
				Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
				 
			}
		}
	}

}
