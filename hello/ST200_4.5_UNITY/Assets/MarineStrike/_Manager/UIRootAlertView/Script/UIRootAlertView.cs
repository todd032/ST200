using UnityEngine;
using System.Collections;

public class UIRootAlertView : MonoBehaviour {

	[HideInInspector]
	public delegate void UIRootAlertViewDelegate(UIRootAlertView uiRootAlertView, int alertType);
	protected UIRootAlertViewDelegate _uiRootAlertViewDelegate ;
	public event UIRootAlertViewDelegate UIRootAlertViewEvent {
		add{
			
			_uiRootAlertViewDelegate = null ;
			
			if (_uiRootAlertViewDelegate == null)
        		_uiRootAlertViewDelegate += value;
        }
		
		remove{
            _uiRootAlertViewDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void Delegate_UIRootAlertView_Kakao(int intKakaoResponseCode_Input);
	protected Delegate_UIRootAlertView_Kakao _delegate_UIRootAlertView_Kakao;
	public event Delegate_UIRootAlertView_Kakao Event_Delegate_UIRootAlertView_Kakao{
		add {
			_delegate_UIRootAlertView_Kakao = null;
			if (_delegate_UIRootAlertView_Kakao == null){
				_delegate_UIRootAlertView_Kakao += value;
			}
		}
		remove {
			_delegate_UIRootAlertView_Kakao -= value;
		}
	}
	

	public UIButton _uiRootAlertViewCancelButton ;
	public UIButton _uiRootAlertViewOkButton ;
	
	public UILabel _uiRootAlertViewMessageLabel ;

	private int m_intAlertType ;
	

	protected float m_OkXPos = 85f;
	private void Awake(){
		
	}
	
	private void Start() {
		
	}
	
	public void InitLoadUIRootAlertView(){
		NGUITools.SetActive(gameObject, false) ;
	}


	protected string m_SendGameMessageTargetName = "";
	public void SetSendGameMessageTargetName(string _name)
	{
		m_SendGameMessageTargetName = _name;
	}

	public void LoadUIRootAlertView(int intAlertType_Input){
				
		m_intAlertType = intAlertType_Input ;
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetUIRootAlertView(intAlertType_Input, new string[]{}) ;
		
	}

	public void LoadUIRootAlertView(int intAlertType_Input, string[] _replacements){
		
		m_intAlertType = intAlertType_Input ;
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetUIRootAlertView(intAlertType_Input, _replacements) ;
		
	}

	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
	public void LoadUIRootAlertView_AhaEnglish(string strMessage_Input){

		NGUITools.SetActive(gameObject, true) ;
		NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
		_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
		
		_uiRootAlertViewMessageLabel.text = strMessage_Input;

	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

	public void RemoveUIRootAlertView() {

		NGUITools.SetActive(gameObject, false) ;
	}


	private void SetUIRootAlertView(int intAlertType_Input, string[] _replacements)
	{
		//Debug.Log ("ST110 UIRootAlertView.SetUIRootAlertView().intAlertType_Input = " + intAlertType_Input);
		
		if(intAlertType_Input == Constant.ST200_POPUP_PURCHASE_OK){ //Purchase Ok...
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(171);
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_RECHARGE_JEWEL){ //Go PaymentView Jewel....
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(170);
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_RECHARGE_COIN){ //Go PaymentView Gold....
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(169);
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_RECHARGE_HEART){ //Go PaymentView Torpedo....
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(172, Managers.GameBalanceData.TorpedoRechargeCost.ToString());
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_RECHARGE_HEART_TOP_UI){ //Go PaymentView Torpedo....
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(172, Managers.GameBalanceData.TorpedoRechargeCost.ToString());
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_EXIT){ //Go Quit

			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;

				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(153);

			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_PACKAGE_NOT_CORRECT){ // 패키지가 올바르지 않습니다.\n해당 마켓에서 다시 설치 후 실행해 주세요.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(6) ;
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD){ // 통신상태가 불안정합니다. 다시 실행해 주세요.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(4);
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_INCORRECTDATA){ // 데이터가 올바르지 않습니다. 다시 실행해 주세요.
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(5);
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_RECHARGE_HEART_NOTICE){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
			
				string languageCode = Managers.UserData.LanguageCode ;

				_uiRootAlertViewMessageLabel.text = 
					TextManager.Instance.GetReplaceString(173, (Managers.Torpedo.GetRegenInterval() / 60).ToString());
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT2){ // Unlock Pet2Slot
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;

			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(187,
				                                                                          Managers.GameBalanceData.SubShipUnlockCost2.ToString());
				
			}

		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT3){ // Unlock Pet2Slot
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(187,
				                                                                          Managers.GameBalanceData.SubShipUnlockCost3.ToString());
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT4){ // Unlock Pet2Slot
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, true) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(m_OkXPos, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if(Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(187,
				                                                                          Managers.GameBalanceData.SubShipUnlockCost4.ToString());
				
			}
			
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_FAILED_TO_GET_PRESENT)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(84);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_FAILED_TO_GET_HEART_FULL){

			//receive all cant get mor heart
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(169);
			}

		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_STAGE_LOCKED)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(196);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SHIP4_LOCKED)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(238);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SHIP3_LOCKED)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(237);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SHIP8_LOCKED)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(239);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_NICKNAME_ALREADY_EXIST)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(198);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_NICKNAME_INAPPROPRIATE_NAME)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(199);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_STAGESELECT_LOCKED_STAGE)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(214);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNALBLE_TO_EQUIP)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(231);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNABLETO_GACHA)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(233);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNABLETO_EQUIP_CHARACTER)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(235);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(240);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_PVP_FRIENDADD_SUCCESS)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(274, _replacements);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_PVP_FRIENDREMOVE_SUCCESS)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetReplaceString(275, _replacements);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_PVP_FRIEND_SEARCH_LENGTH_ERROR)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(276);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_PVP_FRIEND_SEARCH_NORESULT)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(277);
			}
		}else if(intAlertType_Input == Constant.ST200_POPUP_INSTALL_KAKAO)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Etc_Alert,false);
			
			NGUITools.SetActive(_uiRootAlertViewCancelButton.gameObject, false) ;
			_uiRootAlertViewOkButton.transform.localPosition = new Vector3(0f, _uiRootAlertViewOkButton.transform.localPosition.y, _uiRootAlertViewOkButton.transform.localPosition.z) ;
			
			if (Managers.UserData != null){
				
				string languageCode = Managers.UserData.LanguageCode ;
				
				_uiRootAlertViewMessageLabel.text = TextManager.Instance.GetString(301);
			}
		}
	}
	
	
	// ==================== Button Click 정의 - Start ====================
	private void OnClickPaymentPopupAlertViewCancelButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if (m_intAlertType == 4){ //Go PaymentView Torpedo....

			LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_HEART_NOTICE) ;

		} else {

			RemoveUIRootAlertView() ;
		}
	}

	private void OnClickPaymentPopupAlertViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		RemoveUIRootAlertView();
		
		if(_uiRootAlertViewDelegate != null) {
			_uiRootAlertViewDelegate(this, m_intAlertType) ;
		}	
		
	}

	// ==================== Button Click 정의 - End ====================
	private void Process_UnRegister_Network_DeleteUserData(){

		// EventDelegate 정의 - DeleteUserData.
		Managers.DataStream.Event_Delegate_DataStreamManager_DeleteUserData += (intNetworkResultCode_Input) => {
			
			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				#if UNITY_EDITOR

//				Application.Quit();
				Application.LoadLevel("Main");


				#else

				if(!Managers.UserData.IsGuestMode)
				{
					Process_UnRegister_Kakao_ActionDeleteMe();
				}else
				{
					Application.LoadLevel("Main");
				}

				#endif
			}
		};
		
		// DeleteUserData 퉁신하기.
		StartCoroutine(Managers.DataStream.Network_DeleteUserData()) ;

	}

	private void Process_UnRegister_Kakao_ActionDeleteMe(){

		// EventDelegate 정의 - KakaoManager_ActionDeleteMe.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionDeleteMe += (intResultCode_Input) => {
		//	
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//		
		//		Process_UnRegister_Kakao_ActionUnregister();
		//	}
		//};
		//
		//Managers.KaKao.ActionDeleteMe();
	}

	private void Process_UnRegister_Kakao_ActionUnregister(){
		
		// EventDelegate 정의 - KakaoManager_ActionUnregister.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionUnregister += (intResultCode_Input) => {
		//	
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//		PlayerPrefs.SetInt(Constant.PREFKEY_Agreement_INT, Constant.INT_False);
//		//		Application.Quit();
		//		Application.LoadLevel("Main");
		//	}
		//};
		//
		//Managers.KaKao.ActionUnregister();
	}
	

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			if(m_intAlertType == Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR)
			{
				Application.Quit();
			}else
			{
				RemoveUIRootAlertView();
			}
			return true;
		}
		return false;
	}
}
