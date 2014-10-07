using UnityEngine;
using System.Collections;

public class ResultUI : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_DestroyShipLabel;
	public UILabel m_DestroyShipAmountLabel;
	public UILabel m_RewardLabel;
	public UILabel m_RewardAmountLabel_Coin;
	public UILabel m_RewardAmountLabel_Gold;
	public UILabel m_ScoreLabel;
	public UILabel m_ScoreAmountLabel;
	public GameObject m_OKButton;
	public UILabel m_OkButtonLabel;

	public GameObject m_NewScore;
	public TweenScale m_NewScoreAnimation;
	public TweenScale m_DoubleCoinAnimation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int _shipdestroyed, int _reward_coin, int _reward_gold, int _score, bool _bestscore)
	{
		NGUITools.SetActive (gameObject, true);
		m_TitleLabel.text = Constant.COLOR_RESULT_TITLE + TextManager.Instance.GetString(143);
		m_DestroyShipLabel.text = Constant.COLOR_RESULT_REWARD + TextManager.Instance.GetString(144);
		m_RewardLabel.text = Constant.COLOR_RESULT_REWARD + TextManager.Instance.GetString(145);
		m_ScoreLabel.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(146);
		m_OkButtonLabel.text = Constant.COLOR_RESULT_BUTTON + TextManager.Instance.GetString(147);

		m_DestroyShipAmountLabel.text = Constant.COLOR_RESULT_REWARD_AMOUNT + "x" + _shipdestroyed.ToString();
		string coingetstring = "0";
		if(_reward_coin != 0)
		{
			coingetstring = _reward_coin.ToString("#,#");
		}

		string goldgetstring = "0";
		if(_reward_gold != 0)
		{
			goldgetstring = _reward_gold.ToString("#,#");
		}

		m_RewardAmountLabel_Coin.text = Constant.COLOR_RESULT_REWARD_AMOUNT + "x" + coingetstring;
		m_RewardAmountLabel_Gold.text = Constant.COLOR_RESULT_REWARD_AMOUNT + "x" + goldgetstring;

		if(Managers.UserData.GetCurrentGameCharacter().IndexNumber == 4)
		{
			m_DoubleCoinAnimation.Play(true);
		}else
		{
			NGUITools.SetActive (m_DoubleCoinAnimation.gameObject, false);
		}

		StartCoroutine(NumberAnimation(_bestscore, m_ScoreAmountLabel, _score));
		
	}

	public IEnumerator NumberAnimation(bool _bestscore, UILabel _label, int _score) {
		
		_label.text = "0";

		NGUITools.SetActive(m_NewScore.gameObject, false);
		float currentScore = 0f; 
		float animationSeconds = 1.5f;
		float currentTime = 0f;
		float totalscore = (float)_score;
		while(currentTime < animationSeconds) {
			currentTime += Time.deltaTime;
			
			currentScore = totalscore * currentTime/animationSeconds;
			if(currentScore != 0)
			{
				_label.text = currentScore.ToString("#,#");
			}
			yield return null;
			
		}

		if(totalscore != 0)
		{
			_label.text = ((int)totalscore).ToString("#,#") ;
		}
		if(_bestscore) {
			
			//BJ Sound
			GameCharacter _characterInfo = Managers.UserData.GetCurrentGameCharacter() ;
			NGUITools.SetActive(m_NewScore.gameObject, true);
			m_NewScoreAnimation.Play();
		}

		// ===== 결과 애니메이션 추가 (by 최원석 14.05.23)- Start =====
		yield return new WaitForSeconds(0.2f);

		yield return new WaitForSeconds(1f);
		// ===== 결과 애니메이션 추가 (by 최원석 14.05.23)- End =====

		yield break;
	}

	public void OnClickOkButton()
	{
		if (Managers.Audio != null)
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		//_indicatorPopupView.LoadIndicatorPopupView();
		
		if (Managers.DataStream != null) {
			
			if (Managers.UserData != null) {
				ST200AdmobManager.Instance.ShowInterstitial();
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
				
				int intExperienceMode = PlayerPrefs.GetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT);
				
				// 체험전 모드 여부 - false.
				if (intExperienceMode == Constant.INT_False) {
					
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						
						//_indicatorPopupView.RemoveIndicatorPopupView();
						
						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK) {
							
							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel("Ranking");
							Time.timeScale = 1f;
							
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
							
							//_uiRootAlertView.LoadUIRootAlertView(11); 
							
						} else {
							
							//_uiRootAlertView.LoadUIRootAlertView(21); 
						}
					};
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
				} else {
					
					Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += (intNetworkResultCode_Input) => {
						
						PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);
						
						// 통신 결과.
						if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK) {
							// 성공.
							PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);
							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel("Ranking");
							Time.timeScale = 1f;
							
						} else if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
							
							//_uiRootAlertView.LoadUIRootAlertView(11); 
							
						} else {

							//_uiRootAlertView.LoadUIRootAlertView(21); 
						}
					};
					
					StartCoroutine(Managers.DataStream.Network_ReadUserData());
				}
			}
		}
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickOkButton();
			return true;
		}

		return false;
	}
}
