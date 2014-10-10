using UnityEngine;
using System.Collections;

public class ShipSelectUI_UpgradeConfirm_PopUp : MonoBehaviour {

	public ShipSelectUI m_ShipSelectUI;

	public UILabel m_TitleText;

	public UILabel m_ContentText_Attack;
	public UILabel m_ContentText_Defend;
	public UILabel m_ContentText_Movement;

	public UILabel m_ContentValue_Attack;
	public UILabel m_ContentValue_Defend;
	public UILabel m_ContentValue_Movement;

	public UILabel m_OkLabel;
	public UILabel m_CancleLabel;

	protected int m_ShipIndex;

	void Awake()
	{
		m_TitleText.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(218);
		m_ContentText_Attack.text = Constant.COLOR_BLACK + TextManager.Instance.GetString(219);
		m_ContentText_Defend.text = Constant.COLOR_BLACK + TextManager.Instance.GetString(220);
		m_ContentText_Movement.text = Constant.COLOR_BLACK + TextManager.Instance.GetString(221);
		m_OkLabel.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(223);
		m_CancleLabel.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(224);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowPopup(int _shipindex)
	{
		m_ShipIndex = _shipindex;
		NGUITools.SetActive (gameObject, true);

		UserShipData curusershipdata = Managers.UserData.GetUserShipData(m_ShipIndex);
		ShipStatInfo curshipstatinfo = Managers.GameBalanceData.GetShipStatInfo(curusershipdata.IndexNumber, curusershipdata.Level);
		ShipStatInfo nextshipstatinfo = Managers.GameBalanceData.GetShipStatInfo(curusershipdata.IndexNumber, curusershipdata.Level + 1);

		int attackdelta = (int)(nextshipstatinfo.AttackGrade - curshipstatinfo.AttackGrade);
		int defenddelta = (int)(nextshipstatinfo.DefenseGrade - curshipstatinfo.DefenseGrade);
		int movementdelta = (int)(nextshipstatinfo.MovementGrade - curshipstatinfo.MovementGrade);

		m_ContentValue_Attack.text = Constant.COLOR_RED + "+" + attackdelta.ToString() + TextManager.Instance.GetString(222);
		m_ContentValue_Defend.text = Constant.COLOR_RED + "+" + defenddelta.ToString() + TextManager.Instance.GetString(222);
		m_ContentValue_Movement.text = Constant.COLOR_RED + "+" + movementdelta.ToString() + TextManager.Instance.GetString(222);
	}

	public void HidePopup()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void OnClickOk()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		
		UserShipData selectshipdata = Managers.UserData.GetUserShipData(m_ShipIndex);
		
		ShipStatInfo shipinfo = Managers.GameBalanceData.GetShipStatInfo(m_ShipIndex, selectshipdata.Level + 1);
		
		int valueType = shipinfo.ValueType ;
		int submarineValue = shipinfo.Cost ;
		
		/// Money Process..
		if(valueType == 1){
			
			int spendState = Managers.UserData.SetSpendGold(submarineValue) ;
			
			if(spendState == 1) {
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
				
				//ST200KLogManager.Instance.SaveShopSubmarinePurchase(m_CurShipIndex, valueType, submarineValue);
				selectshipdata.Level++;
				Managers.UserData.SetSelectedUserShipData(selectshipdata);
				
				//ReLoad...
				
				if (Managers.DataStream != null){
					
					if(Managers.UserData != null){
						
						Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;

						Managers.UserData.UpdateSequence++;
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
						
						// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
						Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
						// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
						
					}
				}
				
				// ReLoad...Cash..
				GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
				m_ShipSelectUI.DisplayUpgradeEffect(m_ShipIndex);
				//Purchase Ok Message
				//GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PURCHASE_OK);
				
			}else{
				// Pop Up Payment Window...
				//Debug.Log("Pop Up Payment Window... Gold") ;
				GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN);
			}
			
		}else if(valueType == 2){
			
			int spendState = Managers.UserData.SetSpendJewel(submarineValue) ;
			
			if(spendState == 1) {
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
				//ST200KLogManager.Instance.SaveShopSubmarinePurchase(m_CurShipIndex, valueType, submarineValue);
				selectshipdata.Level++;
				Managers.UserData.SetSelectedUserShipData(selectshipdata);
				//ReLoad...
				
				if(Managers.DataStream != null){
					if(Managers.UserData != null){
						Managers.UserData.UpdateSequence++;
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;								
						Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
						// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
					}
				}
				
				// ReLoad...Cash..
				GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();					
				m_ShipSelectUI.DisplayUpgradeEffect(m_ShipIndex);
				//Purchase Ok Message
				//GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PURCHASE_OK);
				
			}else{
				// Pop Up Payment Window...	
				//Debug.Log("Pop Up Payment Window... Jewel") ;
				GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_JEWEL);
			}
			
		}
		HidePopup();
		m_ShipSelectUI.UpdateUI();
	}

	public void OnClickCancle()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		HidePopup();
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickCancle();
			return true;
		}
		return false;
	}
}
