using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelectUI : MonoBehaviour {

	public int m_CurCharacterIndex;

	public UILabel m_TitleText;
	public GameObject m_SelectButton;
	public GameObject m_BuyButton_Gold;
	public UILabel m_BuyLabel_Gold;
	public GameObject m_BuyButton_Cash;
	public UILabel m_BuyLabel_Cash;
	public GameObject m_SelectedButton;

	public List<UISprite> m_PlayerImageList = new List<UISprite>();
	protected float m_PlayerImageScrollIndex;
	protected float m_PlayerImageCurrentScroll;

	public UISprite m_PlayerImage;

	public UISprite m_PlayerAbilityImage;
	public UILabel m_PlayerNameLabel;
	public UILabel m_PlayerSubNameLabel;

	public UILabel m_PlayerSpecialDescriptionLabel;
	public UILabel m_SubshipAvailableTitleLabel;
	public UILabel m_SubshipAvailableCountLabel;
	public UILabel m_TacticTitleLabel;
	public UILabel m_TacticNameLabel;

	public GameObject m_LeftButton;
	public GameObject m_RightButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateScrollInput();
		UpdateCharacterScrollImage();
	}

	bool m_InitFlag = false;
	public void InitUI()
	{
		if(m_InitFlag)
		{
			return;
		}
		m_InitFlag = true;

		m_CurCharacterIndex = Managers.UserData.GetCurrentGameCharacter().IndexNumber;
		m_PlayerImageScrollIndex = 1f - m_CurCharacterIndex;
		m_TitleText.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString(226);
		UpdateUI();
	}

	public void UpdateUI()
	{
		GameCharacter character = Managers.UserData.GetGameCharacter(m_CurCharacterIndex);
		GameCharacterInfoBalance characterinfo = Managers.GameBalanceData.GetGameCharacterInfoBalance(m_CurCharacterIndex);
		if(!character.IsPurchase)
		{
			NGUITools.SetActive(m_SelectButton.gameObject, false);
			NGUITools.SetActive(m_SelectedButton.gameObject, false);
			if(characterinfo.ValueType == 1)
			{
				NGUITools.SetActive(m_BuyButton_Gold.gameObject, true);
				NGUITools.SetActive(m_BuyButton_Cash.gameObject, false);
			}else
			{
				NGUITools.SetActive(m_BuyButton_Gold.gameObject, false);
				NGUITools.SetActive(m_BuyButton_Cash.gameObject, true);
			}
		}else
		{
			if(character.IsSelect)
			{
				NGUITools.SetActive(m_SelectButton.gameObject, false);
				NGUITools.SetActive(m_BuyButton_Gold.gameObject, false);
				NGUITools.SetActive(m_BuyButton_Cash.gameObject, false);
				NGUITools.SetActive(m_SelectedButton.gameObject, true);
			}else
			{
				NGUITools.SetActive(m_SelectButton.gameObject, true);
				NGUITools.SetActive(m_BuyButton_Gold.gameObject, false);
				NGUITools.SetActive(m_BuyButton_Cash.gameObject, false);
				NGUITools.SetActive(m_SelectedButton.gameObject, false);
			}
		}
		//Debug.Log("INDEX: " + m_CurCharacterIndex + " SELECTED: " + character.IsSelect);
		string cost = "0";
		if(characterinfo.CharacterValue != 0)
		{
			cost = characterinfo.CharacterValue.ToString("#,#");
		}
		m_BuyLabel_Gold.text = Constant.COLOR_MAIN_SHIP_COST + cost;
		m_BuyLabel_Cash.text = Constant.COLOR_MAIN_SHIP_COST + cost;

		GameCharacterInfoMessageData descriptioninfo = Managers.GameBalanceData.GetGameCharacterInfoMessage(m_CurCharacterIndex);
		//m_PlayerImage.spriteName = ImageResourceManager.Instance.GetMainUICharacterImageName(m_CurCharacterIndex);
		m_PlayerAbilityImage.spriteName = ImageResourceManager.Instance.GetMainUICharacterAbilityImageName(m_CurCharacterIndex);
		m_PlayerNameLabel.text = Constant.COLOR_MAIN_NAME + descriptioninfo.GameCharacterNameKo;
		m_PlayerSubNameLabel.text = Constant.COLOR_MAIN_NAME + descriptioninfo.GameCharacterNameEn;
		m_PlayerSpecialDescriptionLabel.text = Constant.COLOR_MAIN_SHIP_SPECIAL_DESCRIPTION + descriptioninfo.GameCharacterSpecialMessageKo;

		m_SubshipAvailableTitleLabel.text = Constant.COLOR_BLACK + TextManager.Instance.GetString(228);
		m_SubshipAvailableCountLabel.text = Constant.COLOR_BLUE + characterinfo.AvailableTacticSlot.ToString() + TextManager.Instance.GetString(229);

		m_TacticTitleLabel.text = Constant.COLOR_BLACK + TextManager.Instance.GetString(230);
		m_TacticNameLabel.text = Constant.COLOR_BLUE;
		for(int i = 0; i < characterinfo.AvailableTacticList.Length; i++)
		{
			if(i != 0)
			{
				m_TacticNameLabel.text += ", ";
			}
			m_TacticNameLabel.text += Managers.GameBalanceData.GetSubShipTactic(characterinfo.AvailableTacticList[i]).TacticName;
		}
	}

	public void UpdateCharacterScrollImage()
	{
		m_PlayerImageCurrentScroll = m_PlayerImageCurrentScroll + (m_PlayerImageScrollIndex - m_PlayerImageCurrentScroll) * 0.3f;
		for(int i = 0; i < m_PlayerImageList.Count; i++)
		{
			float startangle = 270f;
			float deltaangleperimage = 360f / (float)m_PlayerImageList.Count;
			float currentangle = startangle + deltaangleperimage * (i + m_PlayerImageCurrentScroll);
			float convertedangleval = currentangle * Mathf.Deg2Rad;

			float radius = 150f;

			float minscale = 0.7f;

			Vector3 imagepos = new Vector3(Mathf.Cos(convertedangleval),
			                               0f,
			                               Mathf.Sin(convertedangleval));
			Vector3 localscale = Vector3.one * ((minscale - 1f)/2f * imagepos.z + (minscale + 1f)/2f);

			if(imagepos.z > 0.6f)
			{
				imagepos.x = 0.3f;				
			}
			m_PlayerImageList[i].transform.localPosition = imagepos * radius;
			m_PlayerImageList[i].transform.localScale = localscale;

			if(localscale.x > 0.9f)
			{
				m_PlayerImageList[i].depth = 11;
				m_PlayerImageList[i].color = new Color(1f,1f,1f,1f);
			}else
			{
				m_PlayerImageList[i].depth = 10;
				m_PlayerImageList[i].color = new Color(1f,1f,1f,0.5f);
			}
		}
	}
	
	public void OnClickRightButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(Managers.GameBalanceData.GetGameCharacterInfoBalance(m_CurCharacterIndex + 1).IndexNumber != 0)
		{
			m_CurCharacterIndex++;
			m_PlayerImageScrollIndex -= 1f;
		}else
		{
			m_CurCharacterIndex = 1;
			m_PlayerImageScrollIndex -= 1f;
		}
		UpdateUI();
	}
	
	public void OnClickLeftButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(Managers.GameBalanceData.GetGameCharacterInfoBalance(m_CurCharacterIndex - 1).IndexNumber != 0)
		{
			m_CurCharacterIndex--;
			m_PlayerImageScrollIndex += 1f;
		}else
		{
			m_CurCharacterIndex = Managers.GameBalanceData._gameCharacterInfoBalanceList.Count;
			m_PlayerImageScrollIndex += 1f;
		}
		
		UpdateUI();
	}


	public void OnClickSelectButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		Managers.UserData.SetSelectGameCharacter(m_CurCharacterIndex);
		Managers.UserData.CheckSubShip();
		GameUIManager.Instance.m_MainUI.UpdateUI();
	}

	public void OnClickCharacterBuyButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			GameCharacter gameCharacter = Managers.UserData.GetGameCharacter(m_CurCharacterIndex) ;
			
			if(!gameCharacter.IsPurchase && !gameCharacter.IsSelect){
				
				GameCharacterInfoBalance gameCharacterInfoBalance = Managers.GameBalanceData.GetGameCharacterInfoBalance(gameCharacter.IndexNumber) ;
				
				int valueType = gameCharacterInfoBalance.ValueType ;
				int characterValue = gameCharacterInfoBalance.CharacterValue ;
				
				/// Money Process..
				if(valueType == 1){
					
					int spendState = Managers.UserData.SetSpendGold(characterValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						ST200KLogManager.Instance.SaveShopCharacterPurchase(gameCharacter.IndexNumber, 1, characterValue);
						
						Managers.UserData.SetPurchaseGameCharacter(gameCharacter.IndexNumber) ;
						Managers.UserData.SetSelectGameCharacter(gameCharacter.IndexNumber) ;
						Managers.UserData.CheckSubShip();
						
						if(Managers.DataStream != null){
							if(Managers.UserData != null){
								
								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
							}
						}

						// ReLoad...Cash..
						GameUIManager.Instance.LoadGameGoldAndGameJewelInfo() ;
						
						//Purchase Ok Message
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
						
					}else{
						// Pop Up Payment Window...
						//Debug.Log("Pop Up Payment Window... Gold") ;
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN) ;
					}
					
				}else if(valueType == 2){
					
					int spendState = Managers.UserData.SetSpendJewel(characterValue) ;
					
					if(spendState == 1) {
						
						if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
						
						ST200KLogManager.Instance.SaveShopCharacterPurchase(gameCharacter.IndexNumber, 2, characterValue);
						
						Managers.UserData.SetPurchaseGameCharacter(gameCharacter.IndexNumber) ;
						Managers.UserData.SetSelectGameCharacter(gameCharacter.IndexNumber) ;
						Managers.UserData.CheckSubShip();
						//ReLoad...
						//SetCharacterUseAndPurchaseInfo(_selectCharacterIndex) ;
						//SetCharacterCardSelectedIconSprite(_selectCharacterIndex) ;
						
						
						if(Managers.DataStream != null){
							if(Managers.UserData != null){
								
								Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
								UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
								
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
								Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
								// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
							}
						}
						// ReLoad...Cash..
						GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
						
						//Purchase Ok Message
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_PURCHASE_OK) ;
						
					}else{
						// Pop Up Payment Window...	
						//Debug.Log("Pop Up Payment Window... Jewel") ;
						GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_JEWEL) ;
					}
					
				}
				
			}else{
				//Debug.Log("Already purchased Character...") ;
			}
			GameUIManager.Instance.m_MainUI.UpdateUI();
		}
	}

	public bool OnEscapePress()
	{
		
		return false;
	}


	protected bool m_CharacterScrollPressed = false;
	protected Vector3 prevpos;
	protected void UpdateScrollInput()
	{
		if(m_CharacterScrollPressed)
		{
			m_PlayerImageScrollIndex -= (-Input.mousePosition.x + prevpos.x) / 200f;
			prevpos = Input.mousePosition;
		}
	}

	public void OnCharacterScrollPress()
	{
		m_CharacterScrollPressed = true;
		prevpos = Input.mousePosition;
	}

	public void OnCharacterScrollRelease()
	{
		m_CharacterScrollPressed = false;
		m_PlayerImageScrollIndex = Mathf.RoundToInt(m_PlayerImageScrollIndex);

		int changeindex = (int)m_PlayerImageScrollIndex;
		while(changeindex > 0 || changeindex < -3)
		{
			if(changeindex > 0)
			{
				changeindex -= 4;
			}else
			{
				changeindex += 4;
			}
		}

		int displaycharacterindex = 1 - changeindex;
		m_CurCharacterIndex = displaycharacterindex;
		GameUIManager.Instance.m_MainUI.UpdateUI();
	}
}
