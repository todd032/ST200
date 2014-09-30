using UnityEngine;
using System.Collections;

public class MainTutorial_ItemBuy : MonoBehaviour {

	public UILabel m_CoinLabel;

	public GameObject m_Explain1;
	public UILabel m_Explain1Label1;
	public UILabel m_Explain1Label2;
	public UILabel m_Explain1Label3;
	
	public GameObject m_Explain2;
	public UILabel m_Explain2Label1;
	public UILabel m_Explain2Label2;
	
	public GameObject m_Explain3;
	public UILabel m_Explain3Label1;
	public UILabel m_Explain3Label2;

	public GameObject m_Explain4;
	
	public GameShopItemButtonObject m_ShoutButton;
	 
	void Awake()
	{		
		string coinstring = "0";
		if(Managers.UserData.GameCoin != 0)
		{
			coinstring = Managers.UserData.GameCoin.ToString("#,#");
		}
		m_CoinLabel.text =  coinstring;
		m_Explain1Label1.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(208);
		m_Explain1Label2.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(209);
		m_Explain1Label3.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(210);

		m_Explain2Label1.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(211);
		//m_Explain2Label2.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(210);

		m_Explain3Label1.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(212);
		m_Explain3Label2.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(213);

		NGUITools.SetActive (m_Explain1.gameObject, false);
		NGUITools.SetActive (m_Explain2.gameObject, true);
		NGUITools.SetActive (m_Explain3.gameObject, false);
		NGUITools.SetActive(m_Explain4.gameObject, false);
		m_ShoutButton.UpdateUI(true, false, Managers.UserData.GetGameItem(Constant.ST200_ITEM_SHOUT).ItemCount);
	}
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	bool flag = false;	
	// Update is called once per frame
	void Update () {
		string coinstring = "0";
		if(Managers.UserData.GetCoinDisplayGold() != 0)
		{
			coinstring = Managers.UserData.GetCoinDisplayGold().ToString("#,#");
		}
		m_CoinLabel.text =  coinstring;
	}
	
	public void OnClickBuy()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.SetPurchaseGameItem(Constant.ST200_ITEM_SHOUT, 1) ;
		
		NGUITools.SetActive (m_Explain1.gameObject, false);
		NGUITools.SetActive (m_Explain2.gameObject, true);
		m_ShoutButton.UpdateUI(true, false, Managers.UserData.GetGameItem(Constant.ST200_ITEM_SHOUT).ItemCount);
	}
	
	public void OnClickItem()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.ToggleGameItemEquip(Constant.ST200_ITEM_SHOUT);
		if(Managers.UserData.TutorialFlagV119)
		{
			//reduce displaycoin
			if(Managers.UserData.GetGameItemCount(Constant.ST200_ITEM_SHOUT) == 0)
			{
				Managers.UserData.ShopDisplayGameCoin = Managers.UserData.GetGameGold() - Managers.GameBalanceData.GetGameItemBalance(Constant.ST200_ITEM_SHOUT).ItemValue;
			}
		}

		m_ShoutButton.UpdateUI(true, true, Managers.UserData.GetGameItem(Constant.ST200_ITEM_SHOUT).ItemCount);
		
		NGUITools.SetActive (m_Explain2.gameObject, false);
		NGUITools.SetActive (m_Explain3.gameObject, true);
	}

	public void OnClickToGameStart()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		NGUITools.SetActive (m_Explain3.gameObject, false);
		NGUITools.SetActive (m_Explain4.gameObject, true);
	}

	public void OnClickEndTutorial()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		NGUITools.SetActive (gameObject, false);
		Managers.UserData.TutorialFlagV119 = true;
		GameUIManager.Instance.SwitchToGameShopManager();
	}

	// 월드랭킹 수정부분 (14.04.12 by 최원석) - Start
	public void OnClickGameStartButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_GameStart,false);
		
		//NGUITools.SetActive(_dontTouchPanel.gameObject, true) ;
		NGUITools.SetActive (gameObject, false);
		Managers.UserData.TutorialFlagV119 = true;

		if (Managers.Torpedo.HaveTorpedo()){
			
			// Connect Icon Start!!!!
			//_indicatorPopupView.LoadIndicatorPopupView() ;
			///
			
			//add item for purchased
			for(int i = 0; i < Managers.GameBalanceData._gameItemBalanceList.Count; i++)
			{
				GameBalanceDataManager.GameItemBalance gameitembalance = Managers.GameBalanceData._gameItemBalanceList[i];
				UserDataManager.GameItem gameitem = Managers.UserData.GetGameItem(gameitembalance.ItemType);
				
				if(Managers.UserData.GetGameItemEquip(gameitem.ItemType) && gameitem.ItemCount == 0)
				{
					Managers.UserData.SetPurchaseGameItem(gameitem.ItemType, 1);
				}
			}
			//end 
			
			Managers.Torpedo.ConsumeTorpedo();
			Managers.UserData.GameJewel = Managers.UserData.ShopDisplayGameJewel;
			Managers.UserData.GameCoin = Managers.UserData.ShopDisplayGameCoin;
			
			if (Managers.DataStream != null){
				
				if (Managers.UserData != null){
					
					// 카카오 리더보드에 점수 저장하기.
					#if UNITY_EDITOR
					
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						Debug.Log("GAME START RESULT: " + intResult_Code_Input);
						
						//_indicatorPopupView.RemoveIndicatorPopupView() ;
						
						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
							
							//_indicatorPopupView.RemoveIndicatorPopupView() ;
							
							//NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							
							ST200KLogManager.Instance.SaveGameStart();
							ST200KLogManager.Instance.SendToServer();
							
							Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
							
						} else {
							
							//NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							Managers.Torpedo.AddTorpedo(1);
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						}
					};
					
					UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
					
					#else
					
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						
						//_indicatorPopupView.RemoveIndicatorPopupView() ;
						
						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
							
							//NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							
							ST200KLogManager.Instance.SaveGameStart();
							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel(Constant.SCENE_GameMainLoadingScene);
							
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
							
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 통신상태가 불안정합니다. 다시 실행해 주세요.
							
						} else {
							
							//NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
							
							GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD) ; // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
						}
					};
					
					UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					
					#endif
					
				}
			}
			Debug.Log("GAME START CLICKED");
		}else{
			
			//NGUITools.SetActive(_dontTouchPanel.gameObject, false) ;
			
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_HEART) ; //Go PaymentView Torpedo....
		}
	}

}