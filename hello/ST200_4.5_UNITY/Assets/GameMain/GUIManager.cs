using UnityEngine;
using System.Collections;
using SimpleJSON ;

public class GUIManager : MonoBehaviour {
	
	[HideInInspector]
	public delegate void GUIManagerGameModeDelegate(GUIManager guiManager, int state);
	protected GUIManagerGameModeDelegate _guiManagerGameModeDelegate ;
	public event GUIManagerGameModeDelegate GUIManagerGameModeEvent {
		add{
			_guiManagerGameModeDelegate = null ;
			if (_guiManagerGameModeDelegate == null)
        		_guiManagerGameModeDelegate += value;
        }
		
		remove{
            _guiManagerGameModeDelegate -= value;
		}
	}
		
	public UIPanel _uiRootAlertViewObject ;
	public UIRootAlertView _uiRootAlertView ;
	
	//
	public IndicatorPopupView _indicatorPopupView ;
	//
	
	public GamePlaySceneTutorialView _gamePlaySceneTutorialView ;

	public UIPanel _continue_PopupViewObject;
	private Continue_PopupView _continue_PopupView;

	public CutIn _boosterCutIn;

	public LuckyCouponAlertView m_LuckyCouponAlertView;

	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
	private bool m_boolPopupAhaEnglish_Show;
	private string m_strAhaCouponPopup;
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

	public EnglishCouponPopupView m_EnglishCouponPopupView;

	public WinLoseAnimation m_WinLoseAnimation;
	public UILabel m_StageWaveLabel;
	public CutInFXAnimation_GO m_CutInFXAnimation_GO;
	public CutInFXAnimation_Continue m_CutInFxAnimation_Continue;
	public CutInFXAnimation_EnemyIncoming m_CutInFxAnimation_Incoming;
	public CutInFXAnimation_Shout m_CutInFxAnimation_Shout;
	public CutInFXAnimation_Singijeon m_CutInFxAnimation_Singijeon;
	public CutInFXAnimation_ItemShipIncoming m_CutInFxItemShipIncoming;
	public TacticCommandAnimation m_TacticAnimation;

	private void Awake() {

		// 자랑하기 수정부분 (14.04.14 by 최원석) - Start.
		NGUITools.SetActive(_resultGameUI.gameObject, false);

		_continue_PopupView = _continue_PopupViewObject.GetComponent<Continue_PopupView>() as Continue_PopupView;
		_continue_PopupView.Continue_PopupViewEvent += Continue_PopupViewDelegate ;
		_continue_PopupView.Init_Continue_PopupView();
				
		_uiRootAlertView = _uiRootAlertViewObject.GetComponent<UIRootAlertView>() as UIRootAlertView ;
		_uiRootAlertView.UIRootAlertViewEvent += UIRootAlertViewDelegate ;

		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
		_uiRootAlertView.Event_Delegate_UIRootAlertView_Kakao += Delegate_UIRootAlertView_Kakao;
		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.

		_gamePlaySceneTutorialView.GamePlaySceneTutorialViewEvent += GamePlaySceneTutorialViewDelegate ;
		
		
		//
		_indicatorPopupView.IndicatorPopupViewEvent += null ;
		//


		//_clanBattlePopupView.ClanBattlePopupViewEvent += ClanBattlePopupViewDelegate ; // Remove !!!!!


		//
		_indicatorPopupView.InitLoadIndicatorPopupView() ;
		//

		_uiRootAlertView.InitLoadUIRootAlertView() ;
		///
		
		_gamePlaySceneTutorialView.InitLoadShopSceneTutorialView() ;
		InitializeSpecialAttackButton();
		//
		//_clanBattlePopupView.InitLoadClanBattlePopupView() ; // Remove !!!!!
		//

		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
		m_boolPopupAhaEnglish_Show = false;
		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

	}
		
	private void Start () {
		
		GameUIAllButtonEnable() ;

		m_PauseContinueLabel.text = Constant.COLOR_RESULT_BUTTON + TextManager.Instance.GetString(162);
		m_PauseQuitLabel.text = Constant.COLOR_RESULT_BUTTON + TextManager.Instance.GetString(163);
	}
	
	// Update is called once per frame
	private void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			OnEscapePress();
		}

		UpdateStageWaveUI();
	}
	
	
	void OnApplicationPause(bool pause) {
		
		if (pause == false) OnClickPauseButton() ;
		
	}
	
	

	private void UIRootAlertViewDelegate(UIRootAlertView uiRootAlertView, int alertType) {
		if(alertType == 1){ // Purchase Ok
			//Nothing...
		}else if(alertType == 2){ // Recharge Jewel..

		}else if(alertType == 3){ // Recharge Gold..

		}
		/* Remove !!!!!
		else if(alertType == 90001){ //통신상태 불량..
			_clanBattlePopupView.OnClickClanBattlePopupViewCloseButton() ;
		}else if(alertType == 90002){ //데이터가 없음.
			_clanBattlePopupView.OnClickClanBattlePopupViewCloseButton() ;
		}
		*/ // End Remove !!!!!
	}

	// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
	private void Delegate_UIRootAlertView_Kakao (int intKakaoResponseCode_Input){

		if (intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Common
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_NotEffective_RefreshToken
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Invalid_Push_Token
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Invalid_Request
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Kakao){
			
			Application.LoadLevel(Constant.SCENE_Main);
		}
	}
	// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.
	
	private void GamePlaySceneTutorialViewDelegate(GamePlaySceneTutorialView gamePlaySceneTutorialView, int state){
		if(state == 1){
			if(_guiManagerGameModeDelegate != null){
				_guiManagerGameModeDelegate(this, 10000) ;
			}
		}
	}
	
	public void UpdateStageWaveUI()
	{
		m_StageWaveLabel.text = GameStageManager.Instance.CurTargetDestroyed.ToString() + "/" + GameStageManager.Instance.TotalTarget.ToString();
	}

	public void PlayCutInFxAnimation_GO(int _character)
	{
		m_CutInFXAnimation_GO.PlayAnimation(_character);
	}

	public void PlayCutInFXAnimation_Continue(int _character)
	{
		m_CutInFxAnimation_Continue.PlayAnimation(_character);
	}

	public void PlayCutInFxAnimation_Incoming()
	{
		m_CutInFxAnimation_Incoming.PlayAnimation();
	}

	public void PlayCutInFxAnimation_Shout(int _character)
	{
		m_CutInFxAnimation_Shout.PlayAnimation(_character);
	}

	public void PlayCutInFxAnimation_Singijeon(int _character)
	{
		m_CutInFxAnimation_Singijeon.PlayAnimation(_character);
	}

	public void PlayItemShipIncomingAnimation()
	{
		m_CutInFxItemShipIncoming.PlayAnimation();
	}

	public bool IsPlayingCutInAnimation()
	{
		return m_CutInFXAnimation_GO.IsPlaying()
				//|| m_CutInFxAnimation_Incoming.IsPlaying()
				|| m_CutInFxAnimation_Continue.IsPlaying()
				|| m_CutInFxAnimation_Shout.IsPlaying()
				|| m_CutInFxAnimation_Singijeon.IsPlaying();
	}

	/* Remove !!!!!
	private void ClanBattlePopupViewDelegate(ClanBattlePopupView clanBattlePopupView, int state) {
		if(state == 1){ //Close ClanBattlePopupView
			// Nothing...
		}else if(state == 100){ //데이터가 없음.
			_uiRootAlertView.LoadUIRootAlertView(90002) ;
		}else if(state == 200){ //통신상태 불량..
			_uiRootAlertView.LoadUIRootAlertView(90001) ;
		}
	}
	*/ // End Remove !!!!!

	
	
	//---GameTutorial
	
	public void LoadGamePlaySceneTutorialView() {
		_gamePlaySceneTutorialView.LoadShopSceneTutorialView() ;
	}
	
	public void RemoveGamePlaySceneTutorialView(){
		_gamePlaySceneTutorialView.RemoveShopSceneTutorialView() ;
	}
	
	
	
	public void AndroidEscapeWorking(){

		if(_indicatorPopupView.gameObject.activeSelf == false){
			if(_uiRootAlertView.gameObject.activeSelf){
				_uiRootAlertView.RemoveUIRootAlertView() ;
				return ;
			}else if(_resultGameUI.gameObject.activeSelf){
							
			}
		}

	}
	
	
	//---- Game UI
	public UILabel scoreLabel;
	public UISprite boosterCharacterSprite;

	public FeverGauge m_FeverGauge;

	public UITweener[] m_HealthWarningTweens;
	public UISprite m_HealthGaugeBar;
	public GameObject m_HealthGaugeBar_Effect;
	protected float m_HelathGaugeWidth;
	protected float m_HelathGaugeWidthInPixel;
	protected float m_HealthGaugeValue;

	public InGameDeadByTimeWarning m_DeadByTimeWarning;

	public InGameBossWarningAnimation m_BossWarningAnimation;
	public TweenScale m_BossHealthTweenScale;
	public GameObject m_BossHealthGaugeBarGameObject;
	public UISprite m_BossHealthGaugeBar;

	public UIButton _pauseButton ;
	public UILabel m_PauseContinueLabel;
	public UILabel m_PauseQuitLabel;

	public GameObject m_SingijeonButton;
	public UISprite m_SingijeonSprite;

	public GameObject m_ShoutButton;
	public UISprite m_ShoutSprite;

	public GameObject m_InvincibleButton;
	public UISprite m_InvincibleSprite;

	public void InitializeSpecialAttackButton()
	{
//		string imagename = "img_submarine" + (GameManager.Instance.GameSubMarine.SubmarineNum + 1).ToString();
//		Debug.Log("IMAGENAME: " + imagename);
	}
			
	public void GameUIAllButtonEnable(){
		_pauseButton.isEnabled = true ;
	}
	
	public void GameUIAllButtonDisable(){
		
		_pauseButton.isEnabled = false ;

		SetItemUseButtonDisable();
	}

	public void PauseModule(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		LoadPauseGameUI() ;
		
		Time.timeScale = 0f ;
		
	}

	public void StartBrakeButtonAnim()
	{
		StartCoroutine(ItemUseTweenTurnOff());
	}

	public void StartLaserButtonAnim()
	{


		StartCoroutine(ItemUseTweenTurnOff());
	}

	public void StartMissileButtonAnim()
	{


		StartCoroutine(ItemUseTweenTurnOff());
	}

	protected IEnumerator ItemUseTweenTurnOff()
	{
		yield return new WaitForSeconds(2f);
	}

	public void InitItemButton(bool _shout , bool _singijeon, bool _characterinvincible){
		if(_shout)
		{
			m_ShoutSprite.color = Color.white;
			m_ShoutButton.collider.enabled = true;
		}else
		{
			m_ShoutSprite.color = Color.gray;
			m_ShoutButton.collider.enabled = false;
			m_ShoutSprite.spriteName = "skill_none";
		}
		
		if(_singijeon)
		{
			m_SingijeonSprite.color = Color.white;
			m_SingijeonButton.collider.enabled = true;
		}else
		{
			m_SingijeonSprite.color = Color.gray;
			m_SingijeonButton.collider.enabled = false;
			m_SingijeonSprite.spriteName = "skill_none";
		}
		
		if(_characterinvincible)
		{
			NGUITools.SetActive(m_InvincibleButton.gameObject, true);
			m_InvincibleSprite.color = Color.white;
			m_InvincibleButton.collider.enabled = true;
		}else
		{
			//NGUITools.SetActive(m_InvincibleButton.gameObject, false);
			m_InvincibleSprite.color = Color.gray;
			m_InvincibleButton.collider.enabled = false;
			m_InvincibleSprite.spriteName = "skill_none";
		}		
	}

	public void SetItemUseButton(bool _shout , bool _singijeon, bool _characterinvincible){
		if(_shout)
		{
			m_ShoutSprite.color = Color.white;
			m_ShoutButton.collider.enabled = true;
		}else
		{
			m_ShoutSprite.color = Color.gray;
			m_ShoutButton.collider.enabled = false;
			//m_ShoutSprite.spriteName = "skill_none";
		}

		if(_singijeon)
		{
			m_SingijeonSprite.color = Color.white;
			m_SingijeonButton.collider.enabled = true;
		}else
		{
			m_SingijeonSprite.color = Color.gray;
			m_SingijeonButton.collider.enabled = false;
			//m_SingijeonSprite.spriteName = "skill_none";
		}

		if(_characterinvincible)
		{
			NGUITools.SetActive(m_InvincibleButton.gameObject, true);
			m_InvincibleSprite.color = Color.white;
			m_InvincibleButton.collider.enabled = true;
		}else
		{
			//NGUITools.SetActive(m_InvincibleButton.gameObject, false);
			m_InvincibleSprite.color = Color.gray;
			m_InvincibleButton.collider.enabled = false;
			//m_InvincibleSprite.spriteName = "skill_none";
		}		
	}
	
	public void SetItemUseButtonEnable(bool _shout , bool _singijeon, bool _characterinvincible){
		SetItemUseButton(_shout, _singijeon, _characterinvincible);
	}
	
	public void SetItemUseButtonDisable(){
		SetItemUseButton(false, false, false);
	}
		
	//-- GUI Controller
	public void StartFeverModeTime(float feverTimeSeconds){
		StartCoroutine("FeverTimeDecreaseGaugeForSecond",feverTimeSeconds) ;
	}
	
	public void DisplayFeverGauge(float feverGauge, float maxFeverGauge){
		
		m_FeverGauge.UpdateUI(feverGauge , maxFeverGauge);	
		
	}

	public void DisplayHealthGauge(float health, float maxHealth)
	{
		//Debug.Log("HEA: " + health + " MAX: " +maxHealth);
		float destinationvalue = health/maxHealth;
		m_HealthGaugeValue = Mathf.Clamp(m_HealthGaugeValue + (destinationvalue - m_HealthGaugeValue) * 0.02f * 5f ,
		                                 0f,
		                                 1f);
		m_HealthGaugeBar.fillAmount = m_HealthGaugeValue;

		//place effect 
		m_HealthGaugeBar_Effect.transform.localPosition = new Vector3(
			4f + (m_HealthGaugeBar.transform.localScale.x) * m_HealthGaugeValue,
			m_HealthGaugeBar_Effect.transform.localPosition.y,
			m_HealthGaugeBar_Effect.transform.localPosition.z);


		for(int i = 0; i < m_HealthWarningTweens.Length; i++)
		{
			UITweener tween = m_HealthWarningTweens[i];

			if(destinationvalue < 0.3f)
			{
				if(!tween.gameObject.activeSelf)
				{
					if ( Managers.Audio != null) Managers.Audio.PlayOnlyOneFXSound(AudioManager.FX_SOUND.FX_Boss_Alert,false);
					tween.gameObject.SetActive(true);
					//tween.Reset();
					tween.Play(true);
				}
			}else
			{
				tween.gameObject.SetActive(false);
			}
		}
	}


	public void DisplayGameScore(int gameScore){
		
		//scoreLabel.text = " [FFFF00]" + gameScore.ToString("#,#") + "[-]"; 
		scoreLabel.text =  gameScore.ToString("#,#") ; 
		
	}
	
	public void DisplayGameCoin(int gameCoin){

	}

	
	public GameObject _endMessageChild ;
	public UILabel _endImageMessageBalloonLabel ;
	
	public void EndEnterAni(){
		
		//NGUITools.SetActive(_endMessageChild, true) ;

		string languageCode = Managers.UserData.LanguageCode ;

		//string SelectMessage = Constant.EndImageMessageBalloonLabelString(languageCode) ;

		string SelectMessage = Managers.GameBalanceData.GetRandomGameEndMessage(languageCode) ;

		_endImageMessageBalloonLabel.text = SelectMessage ;
		
		_endMessageChild.animation.Play("EndEnterAni");
		
 	}
	
	public void EndOutAni(){
		
		//NGUITools.SetActive(_endMessageChild, true) ;
		
		_endMessageChild.animation.Play("EndOutAni");
		
 	}
	
	
	
	
	//-- Revive UI
	public UIPanel _reviveGameUI ;
	public UILabel _reviveCountLabel;
	
	public void LoadReviveGameUI() {
		NGUITools.SetActive(_reviveGameUI.gameObject, true) ;
		
		GameUIAllButtonDisable() ;
		
		StartCoroutine("ReviveCount") ;
		
		
	}
	
	public void RemoveReviveGameUI(){
		StopCoroutine("ReviveCount") ;
		NGUITools.SetActive(_reviveGameUI.gameObject, false) ;
		
		GameUIAllButtonEnable() ;
	}
	
	private IEnumerator ReviveCount() {

		//BJ Sound
		GameCharacter _characterInfo = Managers.UserData.GetCurrentGameCharacter() ;


		int reviveCount = 3 ;
		
		yield return null ;
		
		while(reviveCount > 0){
			
			_reviveCountLabel.text = reviveCount.ToString()   ;
			yield return new WaitForSeconds(1f);
			
			reviveCount--;
			
		}	
		
		if ( _guiManagerGameModeDelegate != null) {
			_guiManagerGameModeDelegate(this,102); //State 102: No Revive!! 
		}
		
		
	}
	
	
	
	//--- Pause UI
	public UIPanel _pauseGameUI ;
	
	public void LoadPauseGameUI() {
		NGUITools.SetActive(_pauseGameUI.gameObject, true) ;
		
		GameUIAllButtonDisable() ;
		
		InitializePauseGameUI() ;
		
	}
	
	public void RemovePauseGameUI(){
		NGUITools.SetActive(_pauseGameUI.gameObject, false) ;
		
		GameUIAllButtonEnable() ;
	}
	
	// 
	private void InitializePauseGameUI() {

	}		


	public UIPanel _resultGameUI ;
	public ResultUI m_ResultUI;

	private string _resultDistance ;
	private int ResultDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_resultDistance = encryptString ;
		}
		get {
			if(_resultDistance == null || _resultDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_resultDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _resultGainGold ;
	private int ResultGainGold {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_resultGainGold = encryptString ;
		}
		get {
			if(_resultGainGold == null || _resultGainGold.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_resultGainGold,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _resultScore ;
	private int ResultScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_resultScore = encryptString ;
		}
		get {
			if(_resultScore == null || _resultScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_resultScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _allKillCount ;
	private int AllKillCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_allKillCount = encryptString ;
		}
		get {
			if(_allKillCount == null || _allKillCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_allKillCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _currentBestScore ;
	private int CurrentBestScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_currentBestScore = encryptString ;
		}
		get {
			if(_currentBestScore == null || _currentBestScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_currentBestScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	
	public void SetResultData(int resultDistance, int resultGainGold, int resultScore, int allKillCount){
		
		GameUIAllButtonDisable() ;
		
		ResultDistance = resultDistance ;
		ResultGainGold = resultGainGold ;
		ResultScore = resultScore ;
		AllKillCount = allKillCount ;
	}

	private int m_intTotalScore;

	// 자랑하기 수정부분 (14.04.14 by 최원석) - Start.
	private int m_intMyRank_Before;
	private int m_intMyRank_After;
	// 자랑하기 수정부분 (14.04.14 by 최원석) - End.

	public void LoadResultGameUI(int _shipdestroyed, int _reward_coin, int _reward_gold, int _score, bool _newscore) {

		LoadResultGameUI_Network_SaveUserData(_shipdestroyed, _reward_coin, _reward_gold, _score, _newscore);
	}
	
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
	private void LoadResultGameUI_Network_SaveUserData(int _shipdestroyed, int _reward_coin, int _reward_gold, int _score, bool _newscore){

//		Debug.Log ("ST110 GUIManager.LoadResultGameUI_Network_SaveUserData().m_intTotalScore = " + m_intTotalScore.ToString());

		Managers.UserData.UpdateSequence++;
		UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
		Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView();
			
			if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK) {
				
				Managers.UserData.BestScore = m_intTotalScore;

				JSONNode jsonDataRoot = JSON.Parse(strResult_Extend_Input);

				m_ResultUI.Init(_shipdestroyed,  _reward_coin, _reward_gold, _score, _newscore);
			}else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
			{
				m_ResultUI.Init(_shipdestroyed,  _reward_coin, _reward_gold, _score, _newscore);
			}else {
				
				m_ResultUI.Init(_shipdestroyed,  _reward_coin, _reward_gold, _score, _newscore);
			}
			
			//PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, 0);

			Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
		};

		//Managers.UserData.BestScore = m_intTotalScore;

		//int intGameClearCount = Managers.UserData.GameClearCount;
		//Debug.Log ("ST110k GUIManager.LoadResultGameUI_Network_SaveUserData().intGameClearCount = " + intGameClearCount.ToString());

		Managers.DataStream.Network_SaveUserData_Input_2 (userDataStruct, m_intTotalScore);
	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

	// 자랑하기 수정부분 (14.04.14 by 최원석) - Start.
	private void Process_SaveScore_01_ActionUpdateResult(){

		_indicatorPopupView.LoadIndicatorPopupView ();

		string strPublicData = GameManager.Instance.GameSubMarine.SubmarineNum.ToString ();

//		Debug.Log ("ST110 GUIManager.Process_SaveScore_01_ActionUpdateResult().strPublicData = " + strPublicData);
		
		//KakaoLeaderBoard.Instance.gameResult.setResult(m_intTotalScore, 0, strPublicData, "");
		
		// EventDelegate 정의 - KakaoManager_ActionUpdateResult.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionUpdateResult += (intResultCode_Input) => {
		//
		//	_indicatorPopupView.RemoveIndicatorPopupView ();
		//
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//
		//		Process_SaveScore_02_ActionLoadGameMe();
		//
		//	} else {
		//		
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//	}
		//
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionUpdateResult += null;
		//};
		//
		//Managers.KaKao.ActionUpdateResult();
	}

	private void Process_SaveScore_02_ActionLoadGameMe(){

//		Debug.Log ("ST110 GUIManager.Process_SaveScore_02_ActionLoadGameMe().m_intTotalScore = " + m_intTotalScore.ToString());

		_indicatorPopupView.LoadIndicatorPopupView ();

		// EventDelegate 정의 - KakaoManager_ActionLoadGameMe.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionLoadGameMe += (intResultCode_Input) => {
		//
		//	_indicatorPopupView.RemoveIndicatorPopupView ();
		//
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//		
		//		Managers.UserData.UserID = KakaoLeaderBoard.Instance.gameMe.user_id;
		//		Managers.UserData.BestScore = KakaoLeaderBoard.Instance.gameMe.scores_season_score;
		//		Managers.UserData.TorpedoRechargeNextTime = KakaoLeaderBoard.Instance.gameMe.heart_regen_starts_at ;
		//		Process_SaveScore_03_ActionLoadGameFriends();
		//		
		//	} else {
		//		
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//	}
		//
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionLoadGameMe += null;
		//};
		//
		//Managers.KaKao.ActionLoadGameMe();
	}

	private void Process_SaveScore_03_ActionLoadGameFriends(){

//		Debug.Log ("ST110 GUIManager.Process_SaveScore_03_ActionLoadGameFriends().m_intTotalScore = " + m_intTotalScore.ToString());

		_indicatorPopupView.LoadIndicatorPopupView ();

		// EventDelegate 정의 - KakaoManager_ActionLoadGameFriends.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionLoadGameFriends += (intResultCode_Input) => {
		//
		//	_indicatorPopupView.RemoveIndicatorPopupView ();
		//
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//		
		//		for (int i = 0; i < KakaoLeaderBoard.Instance.appGameFriends.Count; i++){
		//			
		//			if (KakaoLeaderBoard.Instance.appGameFriends[i].user_id.Equals(KakaoLeaderBoard.Instance.gameMe.user_id)){
		//				
		//				m_intMyRank_After = KakaoLeaderBoard.Instance.appGameFriends[i].rank;
		//			}
		//		}
		//
//		//		Debug.Log ("ST110 GUIManager.Process_SaveScore_03_ActionLoadGameFriends().m_intMyRank_Before = " + m_intMyRank_Before.ToString());
//		//		Debug.Log ("ST110 GUIManager.Process_SaveScore_03_ActionLoadGameFriends().m_intMyRank_After = " + m_intMyRank_After.ToString());
		//
		//		Process_SaveScore_04_ActionWorldRankingUpdateResult();
		//
		//	} else {
		//		
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//	}
		//
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionLoadGameFriends += null;
		//};
		//
		//Managers.KaKao.ActionLoadGameFriends();
	}

	// 월드랭킹 수정부분 (14.04.17 by 최원석) - Start
	private void Process_SaveScore_04_ActionWorldRankingUpdateResult(){

//		Debug.Log ("ST110 GUIManager.Process_SaveScore_04_ActionWorldRankingUpdateResult().m_intTotalScore = " + m_intTotalScore.ToString());

		_indicatorPopupView.LoadIndicatorPopupView ();

		// EventDelegate 정의 - KakaoManager_ActionUpdateResult.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionWorldRankingUpdateResult += (intResultCode_Input) => {
		//
		//	_indicatorPopupView.RemoveIndicatorPopupView ();
		//
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//		
		//		Process_SaveScore_05_ActionWorldRankingData();
		//		
		//	} else {
		//		
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//	}
		//
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionWorldRankingUpdateResult += null;
		//};
		//
		//Managers.KaKao.ActionWorldRankingUpdateResult();
	}

	private void Process_SaveScore_05_ActionWorldRankingData(){
		
		_indicatorPopupView.LoadIndicatorPopupView ();
		
		// EventDelegate 정의 - KakaoManager_ActionUpdateResult.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionWorldRankingData += (intResultCode_Input) => {
		//	
		//	_indicatorPopupView.RemoveIndicatorPopupView ();
		//	
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//		
		//		StartCoroutine("DisplayResultTotalScore");
		//		
		//	} else {
		//		
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//	}
		//	
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionWorldRankingData += null;
		//};
		//
		//Managers.KaKao.ActionWorldRankingData();
	}
	// 월드랭킹 수정부분 (14.04.17 by 최원석) - End


	private void LoadResultGameUI_Network_ReadUserData(){

//		Debug.Log ("ST110 GUIManager.LoadResultGameUI_Network_ReadUserData Run!!!");

		_indicatorPopupView.LoadIndicatorPopupView ();

		Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += (intNetworkReadUserDataResultCode_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView();
			
			// 점수 UI 그리기.
			StartCoroutine("DisplayResultTotalScore");
			
			// 통신 결과.
			if (intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_OK) {
				// 성공.
				
				Time.timeScale = 1f;
				
			} else if (intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
				
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD); 
				
			}else if(intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
			{
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
			} else {
				
				_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA); 
			}
		};
		
		StartCoroutine(Managers.DataStream.Network_ReadUserData());
	}
	// 자랑하기 수정부분 (14.04.14 by 최원석) - End.

	public void RemoveResultGameUI(){
		NGUITools.SetActive(_resultGameUI.gameObject, false) ;
		
		//GameUIAllButtonEnable() ;
	}
	
	private bool m_ShowLuckyCouponGetWindow = false;


	private void PopupView_AhaEnglishCoupon(){

		if (m_boolPopupAhaEnglish_Show){
			
			//_uiRootAlertView.LoadUIRootAlertView_AhaEnglish(m_strAhaCouponPopup);
			m_EnglishCouponPopupView.ShowPopupView();
			EmitFireWork();
		}
	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

	private int CheckScorePerDistance (int distance) {

		int lastIndex = distance / 500;
		int rest = distance % 500;
		
		int distanceScore =0;
		
		for ( int i = 0 ; i <= lastIndex ; i ++) {
			if ( i  < lastIndex) {
 				 distanceScore += (10 + i * 2) * 500; 
			}else{ 
				distanceScore += (10 + i * 2) * rest ;
				
			}
			
		}
		
		return distanceScore;
		
	}
					
	private void Continue_PopupViewDelegate(Continue_PopupView continue_PopupView, int state){
		
		// '닫기' 버튼 클릭했을 때.
		if(state == 100) { //UpdateInfoPopupView Close!!
			
			_guiManagerGameModeDelegate(this,2001);
			
			// '이어하기' 버튼 클릭했을 때.
		} else if (state == 101){
			
			_guiManagerGameModeDelegate(this,2002);
		}
		
	}
	
	public void Load_Continue_PopupView() {
		
		NGUITools.SetActive(_continue_PopupView.gameObject, true) ;
		
		_continue_PopupView.Init_Continue_PopupView();
		
	}
	
	public void Remove_Continue_PopupView(){
		
		NGUITools.SetActive(_continue_PopupView.gameObject, false) ;
		
	}

	private void OnClickGoHomeButton() {
		
		if (Managers.Audio != null)
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		_indicatorPopupView.LoadIndicatorPopupView();
		
		if (Managers.DataStream != null) {
			
			if (Managers.UserData != null) {

				Managers.UserData.UpdateSequence++;
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
				
				int intExperienceMode = PlayerPrefs.GetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT);

				ST200AdmobManager.Instance.ShowInterstitial();

				// 체험전 모드 여부 - false.
				if (intExperienceMode == Constant.INT_False) {

					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						
						_indicatorPopupView.RemoveIndicatorPopupView();

						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK) {

							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel("Ranking");
							Time.timeScale = 1f;
							
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD); 
							
						}else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
						} else {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA); 
						}
					};
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
					
					// 체험전 모드 여부 - true.
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
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD); 
							
						}else if(intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
						}  else {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA); 
						}
					};
					
					StartCoroutine(Managers.DataStream.Network_ReadUserData());
				}
			}
		}
	}

	private void OnClickLaserButton()
	{
		if ( _guiManagerGameModeDelegate != null) {
			_guiManagerGameModeDelegate(this,1003); //State 1002: Use Boom Item
		}
	}
	
	private void OnClickMissileButton()
	{
		if ( _guiManagerGameModeDelegate != null) {
			_guiManagerGameModeDelegate(this,1004); //State 1002: Use Boom Item
		}
	}
	
	private void OnClickReviveButton(){ ////
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if ( _guiManagerGameModeDelegate != null) {
			_guiManagerGameModeDelegate(this,101); //State 101: Revive!!!
		}
		
	}
	




	
	public void OnClickPauseButton() {
		
		if ( _guiManagerGameModeDelegate != null) {
			_guiManagerGameModeDelegate(this,501); //State 501: Load Pause UI
		}
		
	}

	private void OnClickResumeGameButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		RemovePauseGameUI() ;
		
		if ( _guiManagerGameModeDelegate != null) {
			_guiManagerGameModeDelegate(this,502); //State 502: Remove Pause UI
		}
		
		Time.timeScale = 1f ;
		
	}
		
	private void OnClickPurchaseGoldButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

	}
	private void OnClickGoShopButton() {
		
		if (Managers.Audio != null)
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		_indicatorPopupView.LoadIndicatorPopupView();
		
		if (Managers.DataStream != null) {
			
			if (Managers.UserData != null) {

				Managers.UserData.UpdateSequence++;
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
				
				int intExperienceMode = PlayerPrefs.GetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT);
				ST200AdmobManager.Instance.ShowInterstitial();

				// 체험전 모드 여부 - false.
				if (intExperienceMode == 0) {

					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
					Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
						
						_indicatorPopupView.RemoveIndicatorPopupView();
						if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK) {
							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel("Ranking");
							Time.timeScale = 1f;
							
						} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD); 
							
						}else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
						}  else {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA); 
						}

						Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
					};
					
					Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
					// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.

					// 체험전 모드 여부 - true.
				} else {
					
					Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += (intNetworkResultCode_Input) => {
						
						_indicatorPopupView.RemoveIndicatorPopupView();
						
						PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);
						// 통신 결과.
						if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK) {
							// 성공.
							PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);
							ST200KLogManager.Instance.SendToServer();
							Application.LoadLevel("Ranking");
							Time.timeScale = 1f;
							
						} else if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network) {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_NETWORK_NOT_GOOD); 
							
						} else if(intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
						{
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_ERROR_USERSEQUENCE_ERROR); 
						} else {
							
							_uiRootAlertView.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_INCORRECTDATA); 
						}
					};
					
					StartCoroutine(Managers.DataStream.Network_ReadUserData());
					
				}
			}
		}
	}

	// 자랑하기 수정부분 (14.04.14 by 최원석) - Start.
	private void OnClickResultGoShopButton() {
		
		if (Managers.Audio != null){
			
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		}
		
		if (Managers.DataStream != null) {
			ST200AdmobManager.Instance.ShowInterstitial();

			if (Managers.UserData != null) {
				PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);
				ST200KLogManager.Instance.SendToServer();
				Application.LoadLevel("Ranking");
			}
		}
	}


	private void OnClick_ShowBoastPopup(){

	}


	// 자랑하기 수정부분 (14.04.14 by 최원석) - End.

	// ==================== 버튼 클릭이벤 트 - End ====================

	/*
	private void OnClickResultGoHomeButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		// Connect Icon Start!!!!
		_indicatorPopupView.LoadIndicatorPopupView() ;
		//
		
		if(Managers.DataStream != null){
			if(Managers.UserData != null){
				Managers.DataStream.DataStreamManagerEvent += (sendMode, state) => {
					if(sendMode.Equals("SaveUserData")){
						if(state == 301){
							_indicatorPopupView.RemoveIndicatorPopupView() ;
							Application.LoadLevel("Ranking");
						}else if(state == 311){
							// Popup.. Connect Fail... Popup Close
							// Connect Icon End!!!
							_indicatorPopupView.RemoveIndicatorPopupView() ;
							
							_uiRootAlertView.LoadUIRootAlertView(11) ; 
							
						}else if(state == 312){
							// Popup.. Connect Fail... Popup Close
							// Connect Icon End!!!
							_indicatorPopupView.RemoveIndicatorPopupView() ;
							
							_uiRootAlertView.LoadUIRootAlertView(21) ; 
						}
					}
				} ;
				
				
				UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
				///Connect
				StartCoroutine(Managers.DataStream.putUserData(userDataStruct,0)) ;
				///
					
			}
				
		}
		
	}
	*/

	public void PlayDeadByTimeWarningAnim()
	{
		m_DeadByTimeWarning.PlayAnim();
	}

	public void EmitFireWork()
	{

	}

	public void PlayWinAnimation()
	{
		m_WinLoseAnimation.PlayWinAnimation();
	}

	public void PlayLoseAnimation()
	{
		m_WinLoseAnimation.PlayLoseAnimation();
	}

	public bool OnEscapePress()
	{
		if(_pauseGameUI.gameObject.activeSelf)
		{
			OnClickResumeGameButton();
			return true;
		}else if(_continue_PopupView.gameObject.activeSelf)
		{
			_continue_PopupView.OnClickClose();
			return true;
		}else if(GameManager.Instance.GetGameState == GameManager.GameState.GamePlayMode && !_pauseGameUI.gameObject.activeSelf)
		{
			OnClickPauseButton() ;
			return true;
		}else if( GameManager.Instance.GetGameState == GameManager.GameState.GameResult && m_ResultUI.OnEscapePress())
		{
			return true;
		}
		
		return false;
	}
}

