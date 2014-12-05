using UnityEngine;
using System.Collections;

public class StagePopupView : MonoBehaviour {

	// Layout
	protected bool m_AutoSkipProcessFlag = false;
	protected float m_AutoSkipTime = 3.5f;
	protected float m_AutoSkipTimer = 3f;

	public UILabel m_BossTitleStageLable;

	public UITweener m_WindowTweener;
	public UITweener m_ClearTweener;
	public UIPanel BossInfo_Panel;
	public UILabel BossInfo_StageNumTxt_Label;
	public UILabel BossInfo_Name_Label;
	public UILabel BossInfo_Info_Label;
	public UILabel BossInfo_TimeCount_Label;
	public UISprite BossInfo_Boss_Sprite;

	public UIPanel ItemShop_Panel;
	public UILabel ItemShop_StageNumTxt_Label;
	public UIButton [] ItemShop_ItemButton;
	public UISprite [] ItemShop_ItemButton_BG;
	public UISprite [] ItemShop_ItemButton_BG_Selected;
	public UILabel ItemShop_ItemName_Label;
	public UILabel ItemShop_ItemPrice_Label;
	public UILabel ItemShop_ItemInfo_Label;
	public UILabel ItemShop_UserCrystal_Label;
	public UILabel ItemShop_UserGold_Label;
	public GameShopItemButtonObject m_LaserItemButton;
	public GameShopItemButtonObject m_MissileItemButton;
	public GameShopItemButtonObject m_LastAttackItemButton;
	public GameShopItemButtonObject m_BrakeItemmButton;

	public ItemButtonSelectorSpriteObject _itemSelectSprite;
	// Event Delegate 정의.
	[HideInInspector]
	public delegate void Delegate_StagePopupView(int intEventCode_Input);
	protected Delegate_StagePopupView _delegate_StagePopupView ;
	public event Delegate_StagePopupView EventDelegate_StagePopupView {

		add{
			
			_delegate_StagePopupView = null ;
			
			if (_delegate_StagePopupView == null)
				_delegate_StagePopupView += value;
		}
		
		remove{
			_delegate_StagePopupView -= value;
		}
	}

	protected int m_SelectedItem = 6;

	// Use this for initialization
	void Start () {
		LoadGameItemExplain(m_SelectedItem);
		ShowLayout_BossInfo();
		UpdateInfos();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateAutoSkipTimer();
	}

	void UpdateAutoSkipTimer()
	{
		if(m_AutoSkipProcessFlag)
		{
			m_AutoSkipTimer -= Time.deltaTime;
			m_AutoSkipTimer = Mathf.Max(0f, m_AutoSkipTimer);
			BossInfo_TimeCount_Label.text = Mathf.FloorToInt(m_AutoSkipTimer).ToString(); 

			if(m_AutoSkipTimer <= 0f)
			{
				OnClick_Continue();
			}
		}
	}

	public void OnClick_GoItemShop(){
		m_AutoSkipProcessFlag = false;
		//Debug.Log("StagePopupView.OnClick_GoItemShop() Run!!!");
		ShowLayout_ItemShop();

	}

	public void OnClick_Continue(){
		m_AutoSkipProcessFlag = false;
		//Debug.Log("StagePopupView.OnClick_Continue() Run!!!");
		PopupView_Hide();
		_delegate_StagePopupView(1);

	}

	public void OnClick_BackBossInfo(){
		m_AutoSkipProcessFlag = true;
		m_AutoSkipTimer = m_AutoSkipTime;
		//Debug.Log("StagePopupView.OnClick_Continue() Run!!!");
		ShowLayout_BossInfo();

	}


	private void ShowLayout_BossInfo(){
		NGUITools.SetActive(BossInfo_Panel.gameObject, true);
		NGUITools.SetActive(ItemShop_Panel.gameObject, false);
	}

	private void ShowLayout_ItemShop(){
		m_AutoSkipProcessFlag = false;
		NGUITools.SetActive(BossInfo_Panel.gameObject, false);
		NGUITools.SetActive(ItemShop_Panel.gameObject, true);
		UpdateInfos() ;
	}

	protected bool isPopUpShown = false;
	public void PopupView_Show(int stage, int _bossindex){
		if(isPopUpShown)
		{
			return;
		}
		isPopUpShown = true;
		//m_WindowTweener.Reset();
		m_WindowTweener.Play(true);
		m_ClearTweener.gameObject.SetActive(false);
		//NGUITools.SetActive(gameObject, true);
		GameBalanceDataManager.MidBossEnemyBalance bossdata = Managers.GameBalanceData.GetMidBossEnemyBalance(_bossindex);
		BossInfo_Name_Label.text = bossdata.MidBossName;
		BossInfo_Info_Label.text = TextManager.Instance.GetReplacedString(bossdata.MidBossDescription);
		BossInfo_Boss_Sprite.spriteName = "pop_stage_boss_" + _bossindex.ToString();
		BossInfo_Boss_Sprite.MakePixelPerfect();
		m_BossTitleStageLable.text = stage.ToString();
		OnClickLaserItemButton();

		m_AutoSkipTimer = m_AutoSkipTime;
		BossInfo_TimeCount_Label.text = Mathf.FloorToInt(m_AutoSkipTimer).ToString(); 
	}

	public void PopupView_Hide(){
		isPopUpShown = false;
		//NGUITools.SetActive(gameObject, false);
		m_WindowTweener.Play(false);
	}

	void ShowClearAnim()
	{
		m_ClearTweener.gameObject.SetActive(true);
		//m_ClearTweener.Reset();
		m_ClearTweener.Play(true);
	}

	void StartTimerCount()
	{
		if(isPopUpShown)
		{
			m_AutoSkipProcessFlag = true;
			m_AutoSkipTimer = m_AutoSkipTime;
		}
	}

	private void OnClickStartBoosterItemButton() {
		if(m_SelectedItem != 1){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 1 ;
			
			//_itemSelectSprite.SetItemButtonSelectorSpritePosition(_startBoosterItemButton.ThisTransform.position) ;
			
			LoadGameItemExplain(m_SelectedItem) ;
			
		}
	}
	
	private void OnClickShieldItemButton() {
		if(m_SelectedItem != 2){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 2 ;
			
			//_itemSelectSprite.SetItemButtonSelectorSpritePosition(_shie.ThisTransform.position) ;

			
			LoadGameItemExplain(m_SelectedItem) ;
		}
	}
	
	private void OnClickLastBoosterItemButton() {
		if(m_SelectedItem != 3){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 3 ;
			
			_itemSelectSprite.SetItemButtonSelectorSpritePosition(m_LastAttackItemButton.ThisTransform.position) ;
			
			
			LoadGameItemExplain(m_SelectedItem) ;
		}
	}
	
	private void OnClickReviveItemButton() {
		if(m_SelectedItem != 4){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 4 ;
			
			//_itemSelectSprite.SetItemButtonSelectorSpritePosition(revive.ThisTransform.position) ;
			
			
			LoadGameItemExplain(m_SelectedItem) ;
		}
	}
	
	private void OnClickBrakeItemButton() {
		if(m_SelectedItem != 5){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 5 ;	
			
			_itemSelectSprite.SetItemButtonSelectorSpritePosition(m_BrakeItemmButton.ThisTransform.position) ;
			
			LoadGameItemExplain(m_SelectedItem) ;
			
		}
	}
	
	private void OnClickLaserItemButton()
	{
		if(m_SelectedItem != 6)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 6 ;
			
			_itemSelectSprite.SetItemButtonSelectorSpritePosition(m_LaserItemButton.ThisTransform.position) ;
			
			LoadGameItemExplain(m_SelectedItem) ;
		}
	}
	
	private void OnClickMissileItemButton()
	{
		if(m_SelectedItem != 7)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			m_SelectedItem = 7 ;
			
			_itemSelectSprite.SetItemButtonSelectorSpritePosition(m_MissileItemButton.ThisTransform.position) ;
			
			LoadGameItemExplain(m_SelectedItem) ;
		}
	}

	private void LoadGameItemExplain(int selectItemType){
		
		string languageCode = "En" ; //Default..
		
		if(Managers.UserData != null){
			languageCode = Managers.UserData.LanguageCode ;
		}
		
		if(Managers.GameBalanceData != null){

			GameBalanceDataManager.GameItemMessageData messagedata = Managers.GameBalanceData.GetGameItemMessage(selectItemType);
			ItemShop_ItemName_Label.text = TextManager.Instance.GetString(messagedata.ItemNameTextIndex);
			ItemShop_ItemInfo_Label.text = TextManager.Instance.GetString(messagedata.ItemDescriptionTextIndex);
			
			GameBalanceDataManager.GameItemBalance gameItemBalance = Managers.GameBalanceData.GetGameItemBalance(selectItemType) ;
			
			int valueType = gameItemBalance.ValueType ;
			int currentItemValue = gameItemBalance.ItemValue ;
			
			string valueTypeString = "[ffffff]" ;
			if(valueType == 1){
				valueTypeString = "[ffc800]" ;
			}else if(valueType == 2){
				valueTypeString = "[00ffff]" ;
			}
			
			ItemShop_ItemPrice_Label.text = valueTypeString + currentItemValue.ToString("#,#") ;
			
		}
		
	}

	private void UpdateInfos()
	{
		int gamejewel = Managers.UserData.GetGameJewel();
		int gamegold = Managers.UserData.GetGameGold();

		if(gamejewel == 0) {
			ItemShop_UserCrystal_Label.text = gamejewel.ToString() ;	
		}else {
			ItemShop_UserCrystal_Label.text = gamejewel.ToString("#,#") ;	
		}

		if(gamegold == 0) {
			ItemShop_UserGold_Label.text = gamegold.ToString() ;	
		}else {
			ItemShop_UserGold_Label.text = gamegold.ToString("#,#") ;	
		}


		if ( Managers.UserData != null)  {
		}
	}

	private void OnClickItemPurchaseButton() {
		
		if(m_SelectedItem == 0) return ;

		if(PlayerPrefs.GetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT) == Constant.INT_True)
		{
			return;
		}

		if(Managers.GameBalanceData != null){
			
			GameBalanceDataManager.GameItemBalance gameItemBalance = Managers.GameBalanceData.GetGameItemBalance(m_SelectedItem) ;
			
			int valueType = gameItemBalance.ValueType ;
			int currentItemValue = gameItemBalance.ItemValue ;
			
			////Debug.Log("INDEX: " + m_SelectedItem + " VALUETYEP: " + valueType + " CVALUE: " + currentItemValue);
			if(Managers.UserData != null){
				
				/// Money Process..
				if(valueType == 1){
					
					int spendState = Managers.UserData.SetSpendGold(currentItemValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						Managers.UserData.SetPurchaseGameItem(	m_SelectedItem, 1) ;
						
						//ReLoad...
						//LoadGameItem() ;
						
						
						if(Managers.DataStream != null){
							if(Managers.UserData != null){
								
								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
								Managers.UserData.UpdateSequence++;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

							}
						}
						
						//Save Log...
						///Connect
						/// 1001 : StartBooster , 1002 : Shield , 1003 : LastBooster , 1004 : Revive , 1005 : Brake ,1006 : Laser, 1007 : Missile
						/// 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
						int itemCode = 0 ;
						if(gameItemBalance.ItemType == 1){ 
							itemCode = 1001 ;
						}else if(gameItemBalance.ItemType == 2){
							itemCode = 1002 ;
						}else if(gameItemBalance.ItemType == 3){
							itemCode = 1003 ;
						}else if(gameItemBalance.ItemType == 4){
							itemCode = 1004 ;
						}else if(gameItemBalance.ItemType == 5){
							itemCode = 1005 ;
						}else if(gameItemBalance.ItemType == 6){
							itemCode = 1006 ;
						}else if(gameItemBalance.ItemType == 6){
							itemCode = 1006 ;
						}else if(gameItemBalance.ItemType == 7){
							itemCode = 1007 ;
						}

						ST200KLogManager.Instance.SaveGameItemPurchaseMid(itemCode, currentItemValue);
						StartCoroutine(Managers.DataStream.Network_SaveLog(4, itemCode)) ; //4 : ItemShop
						
						// ReLoad...Cash..
						UpdateInfos() ;
						
					}else{
						// Pop Up Payment Window...
						////Debug.Log("Pop Up Payment Window... Gold") ;
						//_uiRootAlertView.LoadUIRootAlertView(3) ;
					}
					
				}else if(valueType == 2){
					
					int spendState = Managers.UserData.SetSpendJewel(currentItemValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						Managers.UserData.SetPurchaseGameItem(	m_SelectedItem, 1) ;
						
						//ReLoad...
						//LoadGameItem() ;
						
						
						if(Managers.DataStream != null){
							
							if(Managers.UserData != null){
								
								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
								Managers.UserData.UpdateSequence++;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

							}
						}
						
						
						//Save Log...
						///Connect
						/// 1001 : StartBooster , 1002 : Shield , 1003 : LastBooster , 1004 : Revive , 1005 : Brake ,1006 : Laser, 1007: Missile
						/// 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
						int itemCode = 0 ;
						if(gameItemBalance.ItemType == 1){ 
							itemCode = 1001 ;
						}else if(gameItemBalance.ItemType == 2){
							itemCode = 1002 ;
						}else if(gameItemBalance.ItemType == 3){
							itemCode = 1003 ;
						}else if(gameItemBalance.ItemType == 4){
							itemCode = 1004 ;
						}else if(gameItemBalance.ItemType == 5){
							itemCode = 1005 ;
						}else if(gameItemBalance.ItemType == 6){
							itemCode = 1006 ;
						}else if(gameItemBalance.ItemType == 7){
							itemCode = 1007 ;
						}
						
						StartCoroutine(Managers.DataStream.Network_SaveLog(4, itemCode)) ; //4 : ItemShop
						
						// ReLoad...Cash..
						UpdateInfos() ;
						
					}else{
						// Pop Up Payment Window...	
						////Debug.Log("Pop Up Payment Window... Jewel") ;
						//_uiRootAlertView.LoadUIRootAlertView(2) ;
					}
				}
			}
		}
	}
}
