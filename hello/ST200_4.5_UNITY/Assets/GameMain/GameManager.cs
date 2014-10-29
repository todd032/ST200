using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class GameManager : MonoBehaviour
{	
	private float _baseParallaxMoveSpeed = 0f ;
	private static GameManager instance ;
	public static GameManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GameManager)) as GameManager;
			}
			return instance;
		}
	}
	
	void OnDestroy()
	{
		instance = null;
	}

	[HideInInspector]
	public enum GameState {
		GameInitialize,
		GameTutorial,
		GameReady,
		GamePlayMode,
		GameFeverMode,
		//GameFeverModeDone,
		//GameBoosterMode,
		GamePlayerDead,
		GamePlayerReviveWait,
		GamePlayerRevive,
		GameClear,
		GameOver,
		GameResult,

		PVP_INIT,
		PVP_READY,
		PVP_PLAY,
		PVP_CLEAR,
		PVP_DEAD,
		PVP_RESULT,
	};

	public Camera m_GamePlayCamera;
	public GameEnemyNotifier m_EnemyNotifier;

	public int _lineCounter = 0;
	private GameState _gameState = GameState.GameInitialize ;
	public GameState GetGameState
	{
		get
		{
			return _gameState;
		}
	}
	// Screen Size..
	public float screenSizeWidth ;
	public float screenSizeHeight ;
	//
		
	// Component
	private GUIManager _guiManager;
	public GUIManager GUIManager
	{
		get
		{
			return _guiManager;
		}
	}

	public GameStageManager _GameStageManager;
	public BackgroundManager m_BackgroundManager;
	public GameBulletManager m_GameBulletObjectManager;
	public DHCameraShake _cameraShakeScript ;

	public PlayerShip m_Player;
	public PlayerController m_PlayerController;
	public PlayerShipAI m_OppAI;

	public FeverEffect m_FeverEffect;
	public FeverEffect m_FeverEffect2;
	public SingijeonEffect m_SingijeonEffect;
	public ShoutEffect m_ShoutEffect;

	public GamePlayTutorial m_TutorialManager;

	public ReturnToBattleWarningAnimation m_ReturnToBattleWarningAnimation;
	//Game Balance Data Setting

	private string m_CoinItemGet  ;
	private int CoinItemGet {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_CoinItemGet = encryptString ;
		}
		get {
			if(m_CoinItemGet == null || m_CoinItemGet.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_CoinItemGet,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 6;
			return decryptInt;
		}
	}

	private string m_GoldItemGet  ;
	private int GoldItemGet {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GoldItemGet = encryptString ;
		}
		get {
			if(m_GoldItemGet == null || m_GoldItemGet.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_GoldItemGet,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 6;
			return decryptInt;
		}
	}

	private string _gameStage  ;
	private int GameStage {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameStage = encryptString ;
		}
		get {
			if(_gameStage == null || _gameStage.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameStage,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 6;
			return decryptInt;
		}
	}

	private string _gameLevel  ;
	private int GameLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameLevel = encryptString ;
		}
		get {
			if(_gameLevel == null || _gameLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _gameWeightLevel ;
	private int GameWeightLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameWeightLevel = encryptString ;
		}
		get {
			if(_gameWeightLevel == null || _gameWeightLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameWeightLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	private string m_ReturnToBattleTimer ;
	private float ReturnToBattleTimer {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ReturnToBattleTimer = encryptString ;
		}
		get {
			if(m_ReturnToBattleTimer == null || m_ReturnToBattleTimer.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ReturnToBattleTimer,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_ReturnToBattleMaxTime ;
	private float ReturnToBattleMaxTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ReturnToBattleMaxTime = encryptString ;
		}
		get {
			if(m_ReturnToBattleMaxTime == null || m_ReturnToBattleMaxTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ReturnToBattleMaxTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	
	private string _gameSpeed ;
	public float GameSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameSpeed = encryptString ;
		}
		get {
			if(_gameSpeed == null || _gameSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gameSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _gameSpeedIncrease ;
	private float GameSpeedIncrease {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameSpeedIncrease = encryptString ;
		}
		get {
			if(_gameSpeedIncrease == null || _gameSpeedIncrease.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gameSpeedIncrease,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _initEnergyDecreaseByHit;
	public float InitEnergyDecreaseByHit {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_initEnergyDecreaseByHit = encryptString ;
		}
		get {
			if(_initEnergyDecreaseByHit == null || _initEnergyDecreaseByHit.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_initEnergyDecreaseByHit,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _energyDecreaseByHit;
	public float EnergyDecreaseByHit {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_energyDecreaseByHit = encryptString ;
		}
		get {
			if(_energyDecreaseByHit == null || _energyDecreaseByHit.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_energyDecreaseByHit,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string _energyDecreaseByTime;
	public float EnergyDecreaseByTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_energyDecreaseByTime = encryptString ;
		}
		get {
			if(_energyDecreaseByTime == null || _energyDecreaseByTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_energyDecreaseByTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _energyAppearByDistance;
	public float EnergyAppearByDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_energyAppearByDistance = encryptString ;
		}
		get {
			if(_energyAppearByDistance == null || _energyAppearByDistance.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_energyAppearByDistance,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _energyAppearByDistanceIncrement;
	public float EnergyAppearByDistanceIncrement {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_energyAppearByDistanceIncrement = encryptString ;
		}
		get {
			if(_energyAppearByDistanceIncrement == null || _energyAppearByDistanceIncrement.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_energyAppearByDistanceIncrement,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _energyHealAmount;
	public float EnergyHealAmount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_energyHealAmount = encryptString ;
		}
		get {
			if(_energyHealAmount == null || _energyHealAmount.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_energyHealAmount,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_GameClearFlag;
	public bool GameClearFlag {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GameClearFlag = encryptString ;
		}
		get {
			if(m_GameClearFlag == null || m_GameClearFlag.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_GameClearFlag,Constant.DefalutAppName) ;
			bool decryptFloat = bool.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_PVPResultFlag;
	public bool PVPResultFlag {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPResultFlag = encryptString ;
		}
		get {
			if(m_PVPResultFlag == null || m_PVPResultFlag.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPResultFlag,Constant.DefalutAppName) ;
			bool decryptFloat = bool.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_PVPRemainTimer ;
	private float PVPRemainTimer {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPRemainTimer = encryptString ;
		}
		get {
			if(m_PVPRemainTimer == null || m_PVPRemainTimer.Equals("")){
				return 300f;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPRemainTimer,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _deadEnabled;
	public bool DeadEnabled {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_deadEnabled = encryptString ;
		}
		get {
			if(_deadEnabled == null || _deadEnabled.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_deadEnabled,Constant.DefalutAppName) ;
			bool decryptFloat = bool.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string _gameSpeedIncreaseBaseDistance ;
	private int GameSpeedIncreaseBaseDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameSpeedIncreaseBaseDistance = encryptString ;
		}
		get {
			if(_gameSpeedIncreaseBaseDistance == null || _gameSpeedIncreaseBaseDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameSpeedIncreaseBaseDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _gameLevelIncreaseBaseDistance ;
	private int GameLevelIncreaseBaseDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameLevelIncreaseBaseDistance = encryptString ;
		}
		get {
			if(_gameLevelIncreaseBaseDistance == null || _gameLevelIncreaseBaseDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameLevelIncreaseBaseDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _gameWeightLevelIncreaseBaseDistance ;
	private int GameWeightLevelIncreaseBaseDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameWeightLevelIncreaseBaseDistance = encryptString ;
		}
		get {
			if(_gameWeightLevelIncreaseBaseDistance == null || _gameWeightLevelIncreaseBaseDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameWeightLevelIncreaseBaseDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _gameSpeedMaxValue ;
	private float GameSpeedMaxValue {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameSpeedMaxValue = encryptString ;
		}
		get {
			if(_gameSpeedMaxValue == null || _gameSpeedMaxValue.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gameSpeedMaxValue,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	//---
	private string _startBoosterTime ;
	private float StartBoosterTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_startBoosterTime = encryptString ;
		}
		get {
			if(_startBoosterTime == null || _startBoosterTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_startBoosterTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _startBoosterSpeed ;
	private float StartBoosterSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_startBoosterSpeed = encryptString ;
		}
		get {
			if(_startBoosterSpeed == null || _startBoosterSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_startBoosterSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	//---
	private string _lastBoosterTime ;
	private float LastBoosterTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_lastBoosterTime = encryptString ;
		}
		get {
			if(_lastBoosterTime == null || _lastBoosterTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_lastBoosterTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _lastBoosterSpeed ;
	private float LastBoosterSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_lastBoosterSpeed = encryptString ;
		}
		get {
			if(_lastBoosterSpeed == null || _lastBoosterSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_lastBoosterSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	//---
	private string _reviveBoosterTime ;
	private float ReviveBoosterTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_reviveBoosterTime = encryptString ;
		}
		get {
			if(_reviveBoosterTime == null || _reviveBoosterTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_reviveBoosterTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _reviveBoosterSpeed ;
	private float ReviveBoosterSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_reviveBoosterSpeed = encryptString ;
		}
		get {
			if(_reviveBoosterSpeed == null || _reviveBoosterSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_reviveBoosterSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	//---
	private string _feverModeMaxGauge ;
	private float FeverModeMaxGauge {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_feverModeMaxGauge = encryptString ;
		}
		get {
			if(_feverModeMaxGauge == null || _feverModeMaxGauge.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_feverModeMaxGauge,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _feverModeTime ;
	private float FeverModeTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_feverModeTime = encryptString ;
		}
		get {
			if(_feverModeTime == null || _feverModeTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_feverModeTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private float _specialAttackMaxGauge = 20f;
	private float SpecialAttackMaxGauge
	{
		set { 
			//string encryptString = LoadingWindows.NextE (value.ToString (), Constant.DefalutAppName);
			//_specialAttackMaxGauge = encryptString;
			_specialAttackMaxGauge = value;
		}
		get {
			//if (_specialAttackMaxGauge == null || _specialAttackMaxGauge.Equals ("")) {
			//	return 0f;	
			//}
			//string decryptString = LoadingWindows.NextD (_specialAttackMaxGauge, Constant.DefalutAppName);
			//float decryptFloat = float.Parse (decryptString);
			//return decryptFloat;
			return _specialAttackMaxGauge;
		}
	}

	private string _feverModeSpeed ;
	private float FeverModeSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_feverModeSpeed = encryptString ;
		}
		get {
			if(_feverModeSpeed == null || _feverModeSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_feverModeSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string _magnetTime ;
	private float MagnetTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_magnetTime = encryptString ;
		}
		get {
			if(_magnetTime == null || _magnetTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_magnetTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _powerShotTime ;
	private float PowerShotTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_powerShotTime = encryptString ;
		}
		get {
			if(_powerShotTime == null || _powerShotTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_powerShotTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _dobleScoreTime ;
	private float DobleScoreTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_dobleScoreTime = encryptString ;
		}
		get {
			if(_dobleScoreTime == null || _dobleScoreTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_dobleScoreTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _boosterTime ;
	private float BoosterTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_boosterTime = encryptString ;
		}
		get {
			if(_boosterTime == null || _boosterTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_boosterTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _boosterSpeed ;
	private float BoosterSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_boosterSpeed = encryptString ;
		}
		get {
			if(_boosterSpeed == null || _boosterSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_boosterSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	///
	private string _boosterProbability ;
	private int BoosterProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_boosterProbability = encryptString ;
		}
		get {
			if(_boosterProbability == null || _boosterProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_boosterProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _doubleScoreProbability ;
	private int DoubleScoreProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_doubleScoreProbability = encryptString ;
		}
		get {
			if(_doubleScoreProbability == null || _doubleScoreProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_doubleScoreProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _magnetProbability ;
	private int MagnetProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_magnetProbability = encryptString ;
		}
		get {
			if(_magnetProbability == null || _magnetProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_magnetProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _powerShotProbability ;
	private int PowerShotProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_powerShotProbability = encryptString ;
		}
		get {
			if(_powerShotProbability == null || _powerShotProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_powerShotProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _goldProbability ;
	private int GoldProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_goldProbability = encryptString ;
		}
		get {
			if(_goldProbability == null || _goldProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_goldProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _bigGoldProbability ;
	private int BigGoldProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bigGoldProbability = encryptString ;
		}
		get {
			if(_bigGoldProbability == null || _bigGoldProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bigGoldProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _specialAttackMissileProbability ;
	public int SpecialAttackMissileProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_specialAttackMissileProbability = encryptString ;
		}
		get {
			if(_specialAttackMissileProbability == null || _specialAttackMissileProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_specialAttackMissileProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _specialAttackLaserProbability ;
	public int SpecialAttackLaserProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_specialAttackLaserProbability = encryptString ;
		}
		get {
			if(_specialAttackLaserProbability == null || _specialAttackLaserProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_specialAttackLaserProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _EnergyItemProbability ;
	public int EnergyItemProbability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_EnergyItemProbability = encryptString ;
		}
		get {
			if(_EnergyItemProbability == null || _EnergyItemProbability.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_EnergyItemProbability,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _bulletDelay ;
	private float BulletDelay {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bulletDelay = encryptString ;
		}
		get {
			if(_bulletDelay == null || _bulletDelay.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_bulletDelay,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _bulletPower ;
	private float BulletPower {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bulletPower = encryptString ;
		}
		get {
			if(_bulletPower == null || _bulletPower.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_bulletPower,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	//	
	
	//--Setting.
	// Submarine Info
	private string _submarineNum ;
	private int SubmarineNum {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_submarineNum = encryptString ;
		}
		get {
			if(_submarineNum == null || _submarineNum.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_submarineNum,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _submarineLevel ;
	private int SubmarineLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_submarineLevel = encryptString ;
		}
		get {
			if(_submarineLevel == null || _submarineLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_submarineLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _submarineBulletLevel ;
	private int SubmarineBulletLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_submarineBulletLevel = encryptString ;
		}
		get {
			if(_submarineBulletLevel == null || _submarineBulletLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_submarineBulletLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _submarineEnergyLevel ;
	private int SubmarineEnergyLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_submarineEnergyLevel = encryptString ;
		}
		get {
			if(_submarineEnergyLevel == null || _submarineEnergyLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_submarineEnergyLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	// Character Info
	private string _characterNum ;
	private int CharacterNum {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_characterNum = encryptString ;
		}
		get {
			if(_characterNum == null || _characterNum.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_characterNum,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _haveCharacterStartBooster;
	private bool HaveCharacterStartBooster {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveCharacterStartBooster = encryptString ;
		}
		get { 
			if(_haveCharacterStartBooster == null || _haveCharacterStartBooster.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveCharacterStartBooster,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string _haveCharacterDoubleCoin ;
	private bool HaveCharacterDoubleCoin {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveCharacterDoubleCoin = encryptString ;
		}
		get { 
			if(_haveCharacterDoubleCoin == null || _haveCharacterDoubleCoin.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveCharacterDoubleCoin,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveCharacterMagnet ;
	private bool HaveCharacterMagnet {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveCharacterMagnet = encryptString ;
		}
		get { 
			if(_haveCharacterMagnet == null || _haveCharacterMagnet.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveCharacterMagnet,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveCharacterRevive ;
	private bool HaveCharacterRevive {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveCharacterRevive = encryptString ;
		}
		get { 
			if(_haveCharacterRevive == null || _haveCharacterRevive.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveCharacterRevive,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveCharacterShield ;
	private bool HaveCharacterShield {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveCharacterShield = encryptString ;
		}
		get { 
			if(_haveCharacterShield == null || _haveCharacterShield.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveCharacterShield,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	//pet info
	private string _pet1Numb ; // if 0 is Nothing..
	private int Pet1Numb {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_pet1Numb = encryptString ;
		}
		get {
			if(_pet1Numb == null || _pet1Numb.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_pet1Numb,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _pet2Numb ; // if 0 is Nothing..
	private int Pet2Numb {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_pet2Numb = encryptString ;
		}
		get {
			if(_pet2Numb == null || _pet2Numb.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_pet2Numb,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	// Subweapon Info
	private string _subweapon1Num ; // if 0 is Nothing..
	private int Subweapon1Num {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subweapon1Num = encryptString ;
		}
		get {
			if(_subweapon1Num == null || _subweapon1Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subweapon1Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subweapon2Num ; // if 0 is Nothing..
	private int Subweapon2Num {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subweapon2Num = encryptString ;
		}
		get {
			if(_subweapon2Num == null || _subweapon2Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subweapon2Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	// Items Info
	private string _haveItemStartBooster ;
	private bool HaveItemStartBooster {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemStartBooster = encryptString ;
		}
		get { 
			if(_haveItemStartBooster == null || _haveItemStartBooster.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemStartBooster,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveItemShield ;
	private bool HaveItemShield {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemShield = encryptString ;
		}
		get { 
			if(_haveItemShield == null || _haveItemShield.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemShield,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveItemLastBooster ;
	private bool HaveItemLastBooster {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemLastBooster = encryptString ;
		}
		get { 
			if(_haveItemLastBooster == null || _haveItemLastBooster.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemLastBooster,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveItemRevive ;
	private bool HaveItemRevive {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemRevive = encryptString ;
		}
		get { 
			if(_haveItemRevive == null || _haveItemRevive.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemRevive,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	
	private string _haveItemBrake ;
	private bool HaveItemBrake {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemBrake = encryptString ;
		}
		get { 
			if(_haveItemBrake == null || _haveItemBrake.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemBrake,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string _haveSpecialLaser ;
	private bool HaveSpecialLaser {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveSpecialLaser = encryptString ;
		}
		get { 
			if(_haveSpecialLaser == null || _haveSpecialLaser.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveSpecialLaser,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string _haveSpecialMissile ;
	private bool HaveSpecialMissile {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveSpecialMissile = encryptString ;
		}
		get { 
			if(_haveSpecialMissile == null || _haveSpecialMissile.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveSpecialMissile,Constant.DefalutAppName) ;

			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}


	private string m_HaveShoutItem ;
	private bool HaveShoutItem {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveShoutItem = encryptString ;
		}
		get { 
			if(m_HaveShoutItem == null || m_HaveShoutItem.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveShoutItem,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	private string m_HaveSingijeon ;
	private bool HaveSingijeon {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveSingijeon = encryptString ;
		}
		get { 
			if(m_HaveSingijeon == null || m_HaveSingijeon.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveSingijeon,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_HavePowerUpItem ;
	private bool HavePowerUpItem {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HavePowerUpItem = encryptString ;
		}
		get { 
			if(m_HavePowerUpItem == null || m_HavePowerUpItem.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HavePowerUpItem,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_HaveHealthUpItem ;
	private bool HaveHealthUpItem {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveHealthUpItem = encryptString ;
		}
		get { 
			if(m_HaveHealthUpItem == null || m_HaveHealthUpItem.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveHealthUpItem,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	
	private string m_HaveInvincible ;
	private bool HaveInvincible {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveInvincible = encryptString ;
		}
		get { 
			if(m_HaveInvincible == null || m_HaveInvincible.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveInvincible,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	// Select Submarine
	private Submarine _gameSubmarine;
	public Submarine GameSubMarine
	{
		get
		{
			return _gameSubmarine;
		}
	}
	
	public float _submarineSpeed = 1.1f; // Touch Move Speed ??
	public int _submarineSpeedMultiple = 1; // Touch Move Speed ??	

	public SubmarineSpecialAttackMissileObject m_SpecialAttackMissile;
	public SubmarineSpecialAttackLaserObject m_SpecialAttackLaser;

	
	private string _bossLuncherNextDistance  ;
	private int BossLuncherNextDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossLuncherNextDistance = encryptString ;
		}
		get {
			if(_bossLuncherNextDistance == null || _bossLuncherNextDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossLuncherNextDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _bossLuncherTermDistance ;
	private int BossLuncherTermDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossLuncherTermDistance = encryptString ;
		}
		get {
			if(_bossLuncherTermDistance == null || _bossLuncherTermDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossLuncherTermDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _bossLevel ;
	private int BossLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossLevel = encryptString ;
		}
		get {
			if(_bossLevel == null || _bossLevel.Equals("")){
				return 1 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _bossGroupLevel ;
	private int BossGroupLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossGroupLevel = encryptString ;
		}
		get {
			if(_bossGroupLevel == null || _bossGroupLevel.Equals("")){
				return 1 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossGroupLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private bool _isBossLuncher = false;
	private bool _isLoadBoss = false;
	private bool _isLoadBossWait = false ;
	 
	
	
	// Score Data
	private string _enemy1Score ;
	private int Enemy1Score {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemy1Score = encryptString ;
		}
		get {
			if(_enemy1Score == null || _enemy1Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemy1Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _enemy2Score ;
	private int Enemy2Score {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemy2Score = encryptString ;
		}
		get {
			if(_enemy2Score == null || _enemy2Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemy2Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _enemy3Score ;
	private int Enemy3Score {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemy3Score = encryptString ;
		}
		get {
			if(_enemy3Score == null || _enemy3Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemy3Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _enemy4Score ;
	private int Enemy4Score {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemy4Score = encryptString ;
		}
		get {
			if(_enemy4Score == null || _enemy4Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemy4Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _enemy5Score ;
	private int Enemy5Score {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemy5Score = encryptString ;
		}
		get {
			if(_enemy5Score == null || _enemy5Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemy5Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _enemy6Score ;
	private int Enemy6Score {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemy6Score = encryptString ;
		}
		get {
			if(_enemy6Score == null || _enemy6Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemy6Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _enemyMineScore ;
	private int EnemyMineScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemyMineScore = encryptString ;
		}
		get {
			if(_enemyMineScore == null || _enemyMineScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemyMineScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _allKillScore ;
	private int AllKillScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_allKillScore = encryptString ;
		}
		get {
			if(_allKillScore == null || _allKillScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_allKillScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _bossEnemyHeadPartsScore ;
	private int BossEnemyHeadPartsScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossEnemyHeadPartsScore = encryptString ;
		}
		get {
			if(_bossEnemyHeadPartsScore == null || _bossEnemyHeadPartsScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossEnemyHeadPartsScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _bossEnemyFrontPartsScore ;
	private int BossEnemyFrontPartsScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossEnemyFrontPartsScore = encryptString ;
		}
		get {
			if(_bossEnemyFrontPartsScore == null || _bossEnemyFrontPartsScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossEnemyFrontPartsScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _bossEnemyLegsPartsScore ;
	private int BossEnemyLegsPartsScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossEnemyLegsPartsScore = encryptString ;
		}
		get {
			if(_bossEnemyLegsPartsScore == null || _bossEnemyLegsPartsScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossEnemyLegsPartsScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _bossEnemyAllBrokenScore ;
	private int BossEnemyAllBrokenScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossEnemyAllBrokenScore = encryptString ;
		}
		get {
			if(_bossEnemyAllBrokenScore == null || _bossEnemyAllBrokenScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossEnemyAllBrokenScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _enemyMeteorScore ;
	public int EnemyMeteorScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemyMeteorScore = encryptString ;
		}
		get {
			if(_enemyMeteorScore == null || _enemyMeteorScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemyMeteorScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _enemyMeteorBaseDistance ;
	public int EnemyMeteorBaseDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemyMeteorBaseDistance = encryptString ;
		}
		get {
			if(_enemyMeteorBaseDistance == null || _enemyMeteorBaseDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemyMeteorBaseDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	//



	
	// Coin Info Data
	private string _coinPatternGold ;
	private int CoinPatternGold {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_coinPatternGold = encryptString ;
		}
		get {
			if(_coinPatternGold == null || _coinPatternGold.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_coinPatternGold,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _coinPatternBigGold ;
	private int CoinPatternBigGold {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_coinPatternBigGold = encryptString ;
		}
		get {
			if(_coinPatternBigGold == null || _coinPatternBigGold.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_coinPatternBigGold,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _coinDropItemGold ;
	private int CoinDropItemGold {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_coinDropItemGold = encryptString ;
		}
		get {
			if(_coinDropItemGold == null || _coinDropItemGold.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_coinDropItemGold,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _coinDropItemBigGold ;
	private int CoinDropItemBigGold {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_coinDropItemBigGold = encryptString ;
		}
		get {
			if(_coinDropItemBigGold == null || _coinDropItemBigGold.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_coinDropItemBigGold,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
		
	//-- Magnet Area Info Data
	private string _magnetAreaCharacter ;
	private float MagnetAreaCharacter {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_magnetAreaCharacter = encryptString ;
		}
		get {
			if(_magnetAreaCharacter == null || _magnetAreaCharacter.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_magnetAreaCharacter,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _magnetAreaDropItem ;
	private float MagnetAreaDropItem {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_magnetAreaDropItem = encryptString ;
		}
		get {
			if(_magnetAreaDropItem == null || _magnetAreaDropItem.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_magnetAreaDropItem,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
		
	
	//
	private Vector2 _submarineStartPosition ;
	private Vector2 _submarineFeverPosition ;
	public float _submarineEntreeSpeed = 0.5f ;
	//
	
	// Get Drop Item State
	private bool isGetItemDoubleScore = false ;
	private bool isGetItemMagnet = false ;
	private bool isGetItemPowerShot = false ;
	private bool isGetItemBooster = false ;
	private bool isGetItemLaser = false;
	private bool isGetItemMissile = false;
	private bool _isWorkingDropItem = true ;

	private bool m_IsUsingShout = false;
	private bool m_IsUsingSingijeon = false;
	//

	// Current Game Data (Result Data)
	private string _inTheGameGetScore ;
	private int InTheGameGetScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_inTheGameGetScore = encryptString ;
		}
		get {
			if(_inTheGameGetScore == null || _inTheGameGetScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_inTheGameGetScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private int PlayerHitCount;
	private int PlayerCrashCount;

	private string _enemyKillCount ;
	private int EnemyKillCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_enemyKillCount = encryptString ;
		}
		get {
			if(_enemyKillCount == null || _enemyKillCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_enemyKillCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	// Fever Gauge
	private string _inTheGameFeverGauge ;
	private float InTheGameFeverGauge {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_inTheGameFeverGauge = encryptString ;
		}
		get {
			if(_inTheGameFeverGauge == null || _inTheGameFeverGauge.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_inTheGameFeverGauge,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	// Mission
	private UserDataManager.GameMissionData _gameMissionGrade1Data ;
	private UserDataManager.GameMissionData _gameMissionGrade2Data ;
	private UserDataManager.GameMissionData _gameMissionGrade3Data ;
	
	
	
	
	// Game State
	private bool _isGameOver ;
	private bool _isTutorialMode ;
	
	// Ready Go Alert
	public GameObject _readyGoAlertObjectGameObject ;
	private ReadyGoAlertObject _readyGoAlertObject ;

	private void SyncUserData(){
		if ( Managers.UserData != null)  {

			GameCharacter _characterInfo = Managers.UserData.GetCurrentGameCharacter() ;
			CharacterNum = _characterInfo.IndexNumber ;
			if(CharacterNum == 2){
				HaveCharacterStartBooster = true ;
			}else if(CharacterNum == 3){
				HaveCharacterMagnet = true ;
			}else if(CharacterNum == 4){
				HaveCharacterRevive = true ;
			}else if(CharacterNum == 5){
				//HaveCharacterShield = true ;
				HaveCharacterDoubleCoin = true;
			}

			Managers.UserData.BeforeGameStart() ;

			HaveShoutItem = Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_SHOUT);
			HaveSingijeon = Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_SINGIJEON);
			HaveItemRevive = Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_REVIVE);
			HavePowerUpItem = Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_POWERUP);
			if(HavePowerUpItem)
			{
				Managers.UserData.SetUseGameItem(Constant.ST200_ITEM_POWERUP, 1);			
				ST200KLogManager.Instance.SaveGameItemUse(Constant.ST200_ITEM_POWERUP);
			}
			HaveHealthUpItem = Managers.UserData.GetGameItemEquip(Constant.ST200_ITEM_HEALTHUP);
			if(HaveHealthUpItem)
			{
				Managers.UserData.SetUseGameItem(Constant.ST200_ITEM_HEALTHUP, 1);
				ST200KLogManager.Instance.SaveGameItemUse(Constant.ST200_ITEM_HEALTHUP);
			}
			
			_gameMissionGrade1Data = Managers.UserData.GetGameMissionData(1) ;
			_gameMissionGrade2Data = Managers.UserData.GetGameMissionData(2) ;
			_gameMissionGrade3Data = Managers.UserData.GetGameMissionData(3) ;

		}
		
		
		if ( Managers.GameBalanceData != null) {
		
			//Game Balance Info
			GameWeightLevel = Managers.GameBalanceData.GameWeightLevel ;
			
			GameSpeed = Managers.GameBalanceData.GameSpeed;

			InitEnergyDecreaseByHit = Managers.GameBalanceData.GetGameSubmarineEnergyInfoBalance(SubmarineNum, SubmarineEnergyLevel).HitDamageAmount;
			EnergyDecreaseByHit = InitEnergyDecreaseByHit;
			EnergyDecreaseByTime = Managers.GameBalanceData.EnergyDecreaseByTime;
			EnergyAppearByDistance = Managers.GameBalanceData.EnergyAppearByDistance;
			EnergyAppearByDistanceIncrement = Managers.GameBalanceData.EnergyAppearByDistanceIncrement;

			EnergyHealAmount = Managers.GameBalanceData.EnergyHealAmount;
			DeadEnabled = false;

			GameSpeedIncrease = Managers.GameBalanceData.GameSpeedIncrease ;
			
			GameSpeedIncreaseBaseDistance = Managers.GameBalanceData.GameSpeedIncreaseBaseDistance ;
			GameLevelIncreaseBaseDistance = Managers.GameBalanceData.GameLevelIncreaseBaseDistance ;
			GameWeightLevelIncreaseBaseDistance = Managers.GameBalanceData.GameWeightLevelIncreaseBaseDistance ;
			GameSpeedMaxValue = Managers.GameBalanceData.GameSpeedMaxValue ;

			ReturnToBattleMaxTime = Managers.GameBalanceData.GamePlayReturnToBattleMaxTime;
			
			StartBoosterTime = Managers.GameBalanceData.StartBoosterTime ;
			StartBoosterSpeed = Managers.GameBalanceData.StartBoosterSpeed ;
			
			LastBoosterTime = Managers.GameBalanceData.LastBoosterTime ;
			LastBoosterSpeed = Managers.GameBalanceData.LastBoosterSpeed ;
	
			ReviveBoosterTime = Managers.GameBalanceData.ReviveBoosterTime ;
			ReviveBoosterSpeed = Managers.GameBalanceData.ReviveBoosterSpeed ;
	
			FeverModeMaxGauge = Managers.GameBalanceData.FeverModeMaxGauge ;
			FeverModeTime = Managers.GameBalanceData.FeverModeTime ;
			FeverModeSpeed = Managers.GameBalanceData.FeverModeSpeed ;
			
			MagnetTime = Managers.GameBalanceData.MagnetTime ;
			PowerShotTime = Managers.GameBalanceData.PowerShotTime ;
			DobleScoreTime = Managers.GameBalanceData.DobleScoreTime ;
			BoosterTime = Managers.GameBalanceData.BoosterTime ;
			BoosterSpeed = Managers.GameBalanceData.BoosterSpeed ;
			
			
			BoosterProbability = Managers.GameBalanceData.BoosterProbability ;
			DoubleScoreProbability =  Managers.GameBalanceData.DoubleScoreProbability ;
			MagnetProbability =  Managers.GameBalanceData.MagnetProbability;
			PowerShotProbability =  Managers.GameBalanceData.PowerShotProbability;
			GoldProbability = Managers.GameBalanceData.GoldProbability ;
			BigGoldProbability = Managers.GameBalanceData.BigGoldProbability ;
			SpecialAttackMissileProbability = Managers.GameBalanceData.SpecialAttackMissileProbability;
			SpecialAttackLaserProbability = Managers.GameBalanceData.SpecialAttackLaserProbability;
			EnergyItemProbability = Managers.GameBalanceData.EnergyItemProbability;

			float extendfactor = 1f;

			MagnetTime *= extendfactor;
			PowerShotTime *= extendfactor;
			DobleScoreTime *= extendfactor;
			BoosterTime *= extendfactor;
			//
			
			
			//Score Data
			Enemy1Score = Managers.GameBalanceData.Enemy1Score ;
			Enemy2Score  = Managers.GameBalanceData.Enemy2Score ;
			Enemy3Score = Managers.GameBalanceData.Enemy3Score ;
			Enemy4Score = Managers.GameBalanceData.Enemy4Score ;
			Enemy5Score = Managers.GameBalanceData.Enemy5Score ;
			Enemy6Score = Managers.GameBalanceData.Enemy6Score ;
			EnemyMineScore = Managers.GameBalanceData.EnemyMineScore ;

			AllKillScore = Managers.GameBalanceData.AllKillScore ;
	
			BossEnemyHeadPartsScore = Managers.GameBalanceData.BossEnemyHeadPartsScore ;
			BossEnemyFrontPartsScore = Managers.GameBalanceData.BossEnemyFrontPartsScore ;
			BossEnemyLegsPartsScore = Managers.GameBalanceData.BossEnemyLegsPartsScore ;
			BossEnemyAllBrokenScore = Managers.GameBalanceData.BossEnemyAllBrokenScore ;

			EnemyMeteorScore = Managers.GameBalanceData.EnemyMeteorScore ;
			EnemyMeteorBaseDistance = Managers.GameBalanceData.EnemyMeteorBaseDistance ;

			//
			
			
			// Coin Info Data
			CoinPatternGold = Managers.GameBalanceData.CoinPatternGold ;
			CoinPatternBigGold = Managers.GameBalanceData.CoinPatternBigGold ;
			CoinDropItemGold = Managers.GameBalanceData.CoinDropItemGold ;
			CoinDropItemBigGold = Managers.GameBalanceData.CoinDropItemBigGold ;
		
			//-- Magnet Area Info Data
			MagnetAreaCharacter = Managers.GameBalanceData.MagnetAreaCharacter ;
			MagnetAreaDropItem = Managers.GameBalanceData.MagnetAreaDropItem ;
			
			
			//-- Boss Controll Data
			BossLuncherNextDistance = Managers.GameBalanceData.BossLuncherNextDistance ;
			BossLuncherTermDistance = Managers.GameBalanceData.BossLuncherTermDistance ;
			
		}	
		
		BossLevel = 1 ;
		BossGroupLevel = 1 ;		
	}

	// 부스터시 배경에 씌우는 반투명 이미지.
	public GameObject boosterBgSprite;

	// 부스터시 별 이펙트.
	public GameObject _objBoosterTime_Effect;

	// 스테이지 클리어 팝업 추가 (by최원석 14.03.20) - 시작.
	public UIPanel StagePopupView_Panel;
	// 스테이지 클리어 팝업 추가 (by최원석 14.03.20) - 끝.

	
	private void Awake(){

		if(Managers.Audio != null)
		{
			Managers.Audio.StopBGMSound();
		}

		Managers.UserData.GamePlayCount++;

		// 스테이지 클리어 팝업 추가 (by최원석 14.03.20) - 시작.
		// 스테이지 클리어 팝업 추가 (by최원석 14.03.20) - 끝.

		// 부스터 효과(BG, 이펙트) - 숨기기.
		boosterBgSprite.gameObject.SetActive (false);
		_objBoosterTime_Effect.SetActive (false);

		Time.timeScale = 1f;
		
		
		PoolManager.instance.InitPrefabPools() ;
		
		
		SyncUserData();
		
		
		// Screen Size Info..
		screenSizeHeight = 2f * Camera.main.orthographicSize;
		screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		//

		GameStage = Managers.UserData.SelectedStageIndex;

		//GUIManager setting.
		_guiManager = GetComponent<GUIManager>() as GUIManager;
		_guiManager.GUIManagerGameModeEvent += GUIManagerGameModeEvent ;

		// Game State
		_isGameOver = false ;
		_isTutorialMode = Managers.UserData.TutorialIsProcessing ;
				
		// Ready Go Alert
		GameObject _go = Instantiate(_readyGoAlertObjectGameObject) as GameObject ;
		_readyGoAlertObject = _go.GetComponent<ReadyGoAlertObject>() as ReadyGoAlertObject ;
		_readyGoAlertObject.ReadyGoAlertObjectEvent += ReadyGoAlertObjectEvent ;
		_go.transform.parent = m_GamePlayCamera.transform;
		_go.transform.localPosition = Vector3.zero;
		_readyGoAlertObject.InitReadyGoAction() ;
		if(Managers.Audio != null)
		{
			Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_START_GAME,false);
		}
		//

		//special attack
		//m_SpecialAttackMissile.Reset(_gameSubmarine, Managers.GameBalanceData.MissileDamage);
		//m_SpecialAttackLaser.Reset(_gameSubmarine, Managers.GameBalanceData.LaserDamage, Managers.GameBalanceData.LaserDurationTime);

	}
	
	private void Start(){

		_GameStageManager.InitStageData(Managers.GameBalanceData.GetStageData(GameStage));

		_isWorkingDropItem = true ;

		//_guiManager.SetItemUseButton(HaveShoutItem, HaveSingijeon, HaveInvincible) ;
		
		if(Managers.UserData.SelectedGameType == Constant.ST200_GAMEMODE_STAGE_NORMAL)
		{
			_gameState = GameState.GameInitialize ;
		}else if(Managers.UserData.SelectedGameType == Constant.ST200_GAMEMODE_PVP)
		{
			_gameState = GameState.PVP_INIT;
		}
		StartCoroutine(_gameState.ToString()) ;

		_guiManager.InitUI(Managers.UserData.SelectedGameType);
	}
	
	
	// Update is called once per frame
	private void Update() {

		//if (Application.platform == RuntimePlatform.Android)
		//{
		//	if (Input.GetKeyUp(KeyCode.Escape)){
		//		if(_gameState == GameState.GameOver){
		//			_guiManager.AndroidEscapeWorking() ;
		//			return ;
		//		}else{
		//			_guiManager.OnClickPauseButton() ;
		//			return;
		//		}
		//	}
		//}
						
		if(m_Player != null)
		{
			_guiManager.DisplayHealthGauge(m_Player.m_CurHealth, m_Player.MaxHealth);
		}

#if UNITY_EDITOR
		if (Input.GetKey(KeyCode.F)) {
			//_guiManager.DisplayFeverGauge(200f, _feverModeMaxGauge);
		
			//_gameState = GameState.GameFeverMode ;
			CalculateGetFeverGauge(100f);
		}
		if(Input.GetKey(KeyCode.I))
		{
			ActivateCharacterInvincibleBuff();
		}
#endif
		
	}

	#region Event Functions
	public void PlayerStageItemGetEvent(PlayerShip _ship, StageItem _stageitem)
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Gain_Item,false);
		if(_stageitem.m_StageItemType == StageItemType.HEAL)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.BuffType = GameShipBuffType.HEAL;
			buff.BuffRemainType = (GameShipBuffRemainType)_stageitem.m_StageItemData.DurationType;
			buff.Value1 = _stageitem.m_StageItemData.Value1;
			buff.Value2 = _stageitem.m_StageItemData.Value2;
			buff.Value3 = _stageitem.m_StageItemData.Value3;

			_ship.AddBuff(buff);
			GamePlayFXManager.Instance.StartFX(GamePlayFXObject_Type.GAIN_HEALTH, _ship.transform.position);
		}else if(_stageitem.m_StageItemType == StageItemType.ATTACK_POWER)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.BuffType = GameShipBuffType.ATTACK_DAMAGE_BUFF;
			buff.BuffRemainType = (GameShipBuffRemainType)_stageitem.m_StageItemData.DurationType;
			buff.Value1 = _stageitem.m_StageItemData.Value1;
			buff.Value2 = _stageitem.m_StageItemData.Value2;
			buff.Value3 = _stageitem.m_StageItemData.Value3;
			
			_ship.AddBuff(buff);
			GamePlayFXManager.Instance.StartFX(GamePlayFXObject_Type.GAIN_ATTACK, _ship.transform.position);
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX,
			                                           _ship.transform.position);
		}else if(_stageitem.m_StageItemType == StageItemType.INVINCIBLE)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.BuffType = GameShipBuffType.INVINCIBLE;
			buff.BuffRemainType = (GameShipBuffRemainType)_stageitem.m_StageItemData.DurationType;
			buff.Value1 = _stageitem.m_StageItemData.Value1;
			buff.Value2 = _stageitem.m_StageItemData.Value2;
			buff.Value3 = _stageitem.m_StageItemData.Value3;
			
			_ship.AddBuff(buff);
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX,
			                                           _ship.transform.position);
		}else if(_stageitem.m_StageItemType == StageItemType.COIN)
		{
			CoinItemGet += (int)_stageitem.m_StageItemData.Value1;
			GamePlayFXManager.Instance.StartFontFX(Color.yellow, _ship.transform.position, "+" + ((int)_stageitem.m_StageItemData.Value1).ToString());
			GamePlayFXManager.Instance.StartFX(GamePlayFXObject_Type.GAIN_COIN, _ship.transform.position);
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX,
			                                           _ship.transform.position);
		}else if(_stageitem.m_StageItemType == StageItemType.GOLD_BAR)
		{
			GoldItemGet += (int)_stageitem.m_StageItemData.Value1;
			GamePlayFXManager.Instance.StartFontFX(Color.yellow, _ship.transform.position, "+" + ((int)_stageitem.m_StageItemData.Value1).ToString());
			GamePlayFXManager.Instance.StartFX(GamePlayFXObject_Type.GAIN_GOLD, _ship.transform.position);
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX,
			                                           _ship.transform.position);
		}

		StageItemManager.Instance.ReturnStageItem(_stageitem);
		//Debug.Log("STAGE ITEM GOT: " + _stageitem.m_StageItemType);
	}

	public void PlayerShootEvent(PlayerShip _player)
	{
		//Debug.Log("SHOOT EVENT MANAGER");
		//m_GameBulletObjectManager.ShootBullet(1, _player.m_ShipStatInfo.BulletDamage, m_Player.m_ShootPosition, m_Player.m_ShootDirection * m_Player.m_ShipStatInfo.BulletSpeed, m_Player.m_ShipStatInfo.BulletPushForce);
	}

	public void PlayerDamagedEvent(PlayerShip _player, float _damage)
	{

	}

	public void PlayerSubShipSpawnEvent(PlayerSubShip _subship)
	{
		//m_Player.AddTarget(_subship.transform);
	}

	public void EnemyDefendLinePassEvent(GameStageEnemyObject _enemy)
	{
		//m_Player.DoDamage(10f);
	}

	public void EnemyShootEvent(GameStageEnemyObject _enemy)
	{

	}

	public void EnemyDeadEvent(GameStageEnemyObject _enemy)
	{
		if(_enemy.m_Health <= 0f)
		{
			//Debug.Log("ENEMY DEAD:" + _enemy.gameObject.name + " SCORE: " + _enemy.m_StageEnemyData.Score);
			CalculateGetGameScore(_enemy.m_StageEnemyData.Score);
			GamePlayFXManager.Instance.StartFontFX(Color.white, _enemy.transform.position, ((int)_enemy.m_StageEnemyData.Score).ToString());
			EnemyKillCount++;
			if(!m_FeverEffect.m_IsPlaying && !m_FeverEffect2.m_IsPlaying)
			{
				//Debug.Log("CALCULATED");
				CalculateGetFeverGauge(1f);
			}

			//spawn item
			//StageItemManager.Instance.TrySpawnItem(_enemy.m_StageEnemyData.ItemSpawnIndex, _enemy.transform.position);
			StageItemManager.Instance.TrySpawnItem(m_Player.TeamIndex, _enemy.m_StageEnemyData.ItemSpawnIndex, _enemy.transform.position);
		}
	}

	public void EnemySpawnEvent(GameStageEnemyObject _enemy)
	{
		m_Player.AddTarget(_enemy.transform);
		for(int i = 0; i < GamePlayerManager.Instance.m_SubShipList.Count; i++)
		{
			GamePlayerManager.Instance.m_SubShipList[i].AddTarget(_enemy.transform);
		}
	}

	public void PlayerHitByBulletEvent()
	{
		PlayerHitCount++;
	}

	public void PlayerCrashWithEnemyEvent()
	{
		PlayerCrashCount++;
	}
	#endregion

	private void GUIManagerGameModeEvent(GUIManager guiManager, int state){
		if(state == 1) { //State 1 : Fever Mode Done
			
			//_gameSubmarine.ChangeStateSubmarineFeverModeEffect(false) ;
	
			//_gamePatternManager.ChangePatternSetFromFeverToMain(0) ;
			_GameStageManager.ResumeStage(1.5f);
		}else if(state == 101) { //State 101: Revive!!!
			
			int useGameItemState = 0 ;
			
			//  Use Revive Item
			if(Managers.UserData != null){
				useGameItemState = Managers.UserData.SetUseGameItem(Constant.ST200_ITEM_REVIVE,1) ;
			}

			if(useGameItemState == 1){
				
				// Mission
				CalculateMissionDataWithUseItem(6) ; //useItemType 1: LastBooster  , 2:EMP  , 3:StartBooster , 4:Shield , 5:Break, 6:Revive
				//	
				
				_gameState = GameState.GamePlayerRevive ;
			}else{

			
				_gameState = GameState.GameOver ;
			}
			
		}else if(state == 102) { //State 102: No Revive!! 

			if(_isLoadBoss){

				
			}
			
			_gameState = GameState.GameOver ;

		}else if(state == 501) { //State 501: Load Pause UI
			
			if(!_isGameOver && !_isTutorialMode){
				//_gameSubmarine.IsTouchable = false ;
				_guiManager.PauseModule() ;	
			}
			
		}else if(state == 502) { //State 502: Remove Pause UI
			
			//_gameSubmarine.IsTouchable = true ;
			
		}else if(state == 1001) { //State 1001: Use Brake Item
			

		}else if(state == 1003) // Use SpecialAttackLaser
		{

		}else if(state == 1004) // Use SpecialAttackMissile
		{

		}else if(state == 10000){ //End Of Tutorial..
			
			
			if(Managers.UserData != null){
				Managers.UserData.SetTutorlalState(true) ;
			}
			
			_guiManager.RemoveGamePlaySceneTutorialView() ;
			//_readyGoAlertObject.StartReadyGoAction() ;

			_isTutorialMode = false ;
			
		}// 이어하기 수정 - 시작 (14.03.12 by 최원석).
		else if(state == 2001) { //State 2001: 이어하기 팝업창 '닫기' 버튼.
			
			boolShownContinuePopupView = true;
			isGameOverState = true ;
			StartCoroutine(_gameState.ToString());
			
		}else if(state == 2002) { //State 2001: 이어하기 팝업창 '이어하기' 버튼.
			
			if(Managers.UserData != null) {
				
				int intExpendCrystal = 0;
				
				if (Managers.GameBalanceData != null){
					
					intExpendCrystal = Managers.GameBalanceData.CrystalExpendForContinue;
				}
				
				Managers.UserData.SetSpendJewel(intExpendCrystal);
				ST200KLogManager.Instance.SaveShopSpendCrystal("CONTINUE_INGAME", intExpendCrystal);

			}
			
			boolShownContinuePopupView = true;
			_gameState = GameState.GamePlayerRevive;
			
			StartCoroutine(_gameState.ToString());
			// 이어하기 수정 - 끝.
			
		}
		
	}

	private float fltCutInShowTime = 0.7f;//1.5f

	public void ActivateCharacterInvincibleBuff()
	{
		if (_gameState != GameState.GamePlayMode )
			return;

		if(HaveInvincible)
		{
			HaveInvincible = false;
			GameShipBuff invincible = new GameShipBuff();
			invincible.Init(GameShipBuffType.INVINCIBLE,
			              GameShipBuffRemainType.TIME,
			              Managers.GameBalanceData.GamePlayCharacter3Duration,
			              0f,
			              0f,
			              0f,
			              0f);
			m_Player.AddBuff(invincible);
			_guiManager.SetItemUseButton(HaveShoutItem, HaveSingijeon, HaveInvincible) ;
			StartCoroutine(IEInvincibleEffect(invincible));
		}
	}

	protected IEnumerator IEInvincibleEffect(GameShipBuff _buff)
	{

		GamePlayParticleFX particlefx = GamePlayFXManager.Instance.GetParticleFX(GamePlayParticleFX_Type.INVINCIBLE_FX,
		                                                                         m_Player.transform.position);
		particlefx.gameObject.SetActive (true);
		particlefx.Play();
		float timer = 0f;
		float remaintimer = Managers.GameBalanceData.GamePlayCharacter3Duration;
		while(!_buff.IsDone())
		{
			timer += Time.fixedDeltaTime;
			particlefx.SetPosition(m_Player.transform.position);
			particlefx.transform.eulerAngles = m_Player.transform.eulerAngles;
			yield return new WaitForFixedUpdate();
		}

		GamePlayFXManager.Instance.ReturnParticleFX(particlefx);
		yield break;
	}

	public void ActivateFever()
	{
		if(_gameState != GameState.GamePlayMode)
		{
			return;
		}

		if (InTheGameFeverGauge >= FeverModeMaxGauge){
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

			m_FeverEffect.PlayFever(m_Player.transform.position + m_Player.m_LookingVector.normalized * 5f);
			m_FeverEffect2.PlayFever(m_Player.transform.position - m_Player.m_LookingVector.normalized * 5f);
			InTheGameFeverGauge = 0f;

			GameShipBuff invinciblebuff = new GameShipBuff();
			invinciblebuff.Init(GameShipBuffType.INVINCIBLE, GameShipBuffRemainType.TIME,
			                    5f,
			                    0f,
			                    0f,
			                    0f,
			                    0f);
			m_Player.AddBuff(invinciblebuff);
		}
	}

	public void ShootShout()
	{
		if (_gameState != GameState.GamePlayMode)
			return;
		
		if (Managers.UserData != null) {
			if(!IsPlayingSpecialAction() && HaveShoutItem && Managers.UserData.SetUseGameItem(Constant.ST200_ITEM_SHOUT,1) == 1)
			{
				ST200KLogManager.Instance.SaveGameItemUse(Constant.ST200_ITEM_SHOUT);
				CalculateMissionDataWithUseItem(2);
				HaveShoutItem = false ;
				_guiManager.SetItemUseButton(HaveShoutItem, HaveSingijeon, HaveInvincible) ;

				GameShipBuff invinciblebuff = new GameShipBuff();
				invinciblebuff.Init(GameShipBuffType.INVINCIBLE, GameShipBuffRemainType.TIME,
				                    1f,
				                    0f,
				                    0f,
				                    0f,
				                    0f);
				m_Player.AddBuff(invinciblebuff);
				
				m_IsUsingShout = true;
				StartCoroutine(ShoutRoutine());
			}
		}
	}

	public IEnumerator ShoutRoutine()
	{
		_guiManager.PlayCutInFxAnimation_Shout(CharacterNum);
		while(_guiManager.m_CutInFxAnimation_Shout.IsPlaying())
		{
			yield return null;
		}

		_guiManager.StartLaserButtonAnim();

		m_IsUsingShout = false;
		m_ShoutEffect.PlayEffect(m_Player.transform.position);
		yield break;
	}

	public void ShootSingijeon()
	{
		if (_gameState != GameState.GamePlayMode)
			return;
		Debug.Log("SHOTT HAVEL :" + HaveSingijeon);

		if (Managers.UserData != null) {
			if(!IsPlayingSpecialAction() && HaveSingijeon && Managers.UserData.SetUseGameItem(Constant.ST200_ITEM_SINGIJEON,1) == 1)
			{
				ST200KLogManager.Instance.SaveGameItemUse(Constant.ST200_ITEM_SINGIJEON);
				HaveSingijeon = false ;
				_guiManager.SetItemUseButton(HaveShoutItem, HaveSingijeon, HaveInvincible) ;

				GameShipBuff invinciblebuff = new GameShipBuff();
				invinciblebuff.Init(GameShipBuffType.INVINCIBLE, GameShipBuffRemainType.TIME,
				                    1f,
				                    0f,
				                    0f,
				                    0f,
				                    0f);
				m_Player.AddBuff(invinciblebuff);
				
				
				m_IsUsingSingijeon = true;
				StartCoroutine(SingijeonRoutine());
			}
		}
	}

	private IEnumerator SingijeonRoutine()
	{				
		_guiManager.PlayCutInFxAnimation_Singijeon(CharacterNum);
		while(_guiManager.m_CutInFxAnimation_Singijeon.IsPlaying())
		{
			yield return null;
		}
		_guiManager.StartMissileButtonAnim();
		//yield return new WaitForSeconds(0.5f);
		//boosterBgSprite.gameObject.SetActive (true);
		
		//m_SpecialAttackMissile.PlaySpecialAttack(0.1f);	
		m_SingijeonEffect.Play(0.1f);
		float shaketimer = 0.75f;
		while(shaketimer > 0f)
		{
			shaketimer -= Time.deltaTime;
			_cameraShakeScript.DoCameraShake(0.05f, 0.004f);
			yield return null;
		}

		yield return new WaitForSeconds(1.3f);
		boosterBgSprite.gameObject.SetActive (false);
		m_IsUsingSingijeon = false; 
	}
		
	//---- Game Result Data
	private void CalculateGetGameScore(int gainScore){
		InTheGameGetScore += gainScore ;
		_guiManager.DisplayGameScore(InTheGameGetScore);
	}

	//---- Game Fever Mode!!!
	private void CalculateGetFeverGauge(float gainFeverGauge){

		if(!m_FeverEffect.m_IsPlaying)
		{
			InTheGameFeverGauge = Mathf.Min(InTheGameFeverGauge + gainFeverGauge, FeverModeMaxGauge) ;
			//Debug.Log("MAX: " + FeverModeMaxGauge + "  IN: " + InTheGameFeverGauge + " ONE: " + gainFeverGauge);
		}
	}
		
	//------------------------------------------------------

	#region FSM IENUMERATOR
	private IEnumerator PVP_INIT() {
		
		_guiManager.SetItemUseButtonDisable() ;
		
		//init player
		//m_Player
		GamePlayerManager.Instance.SpawnPlayer(Managers.UserData.GetCurrentUserShipData());
		m_Player = GamePlayerManager.Instance.m_CurrentPlayerShip;
		m_Player.ShootEvent += PlayerShootEvent;
		m_Player.DamagedEvent += PlayerDamagedEvent;
		_GameStageManager.EnemyShootEvent 				+= EnemyShootEvent;
		_GameStageManager.DefendLinePassEvent 			+= EnemyDefendLinePassEvent;
		_GameStageManager.EnemyDeadEvent				+= EnemyDeadEvent;

		for(int i = 1 ; i <= Managers.GameBalanceData.SubShipEquipAvailableMaxCount; i++)
		{
			int shipindex = Managers.UserData.GetEquipedSubShipIndex(i);
			if(shipindex != 0)
			{
				GamePlayerManager.Instance.SpawnSubShip (Managers.UserData.GetUserSubShipData(shipindex));
			}
		}
		
		m_PlayerController.Init(m_Player);

		//spawn opponent
		UserInfoData oppuserinfo = PVPDataManager.Instance.m_SelectedPVPUserInfo;
		GamePlayerManager.Instance.OppSpawnPlayer(oppuserinfo.ShipIndex, oppuserinfo.ShipLevel);
		for(int i = 0 ; i < oppuserinfo.SubShipIndexList.Length; i++)
		{
			int shipindex = oppuserinfo.SubShipIndexList[i];
			int shiplevel = oppuserinfo.SubShipLevelList[i];
			int selectindex = i + 1;
			if(shipindex != 0)
			{
				GamePlayerManager.Instance.OppSpawnSubShip(shipindex, shiplevel, selectindex);
			}
		}
		GamePlayerManager.Instance.m_OppPlayerShip.SetMarker(true);
		GamePlayerManager.Instance.m_OppPlayerShip.gameObject.AddComponent<PlayerShipAI>();
		PlayerShipAI oppshipai = GamePlayerManager.Instance.m_OppPlayerShip.gameObject.GetComponent<PlayerShipAI>();
		oppshipai.Init(GamePlayerManager.Instance.m_OppPlayerShip, GamePlayerManager.Instance.m_CurrentPlayerShip);
		m_OppAI = oppshipai;

		GamePlayerManager.Instance.m_CurrentPlayerShip.AddTarget(GamePlayerManager.Instance.m_OppPlayerShip.transform);
		GamePlayerManager.Instance.m_OppPlayerShip.AddTarget(GamePlayerManager.Instance.m_CurrentPlayerShip.transform);
		for(int i = 0; i < GamePlayerManager.Instance.m_SubShipList.Count; i++)
		{
			PlayerSubShip curplayersubship = GamePlayerManager.Instance.m_SubShipList[i];
			curplayersubship.AddTarget(GamePlayerManager.Instance.m_OppPlayerShip.transform);
			GamePlayerManager.Instance.m_OppPlayerShip.AddTarget(curplayersubship.transform);
			for(int j = 0; j < GamePlayerManager.Instance.m_OppSubShipList.Count; j++)
			{
				PlayerSubShip oppsubship = GamePlayerManager.Instance.m_OppSubShipList[j];
				oppsubship.AddTarget(GamePlayerManager.Instance.m_CurrentPlayerShip.transform);
				curplayersubship.AddTarget(oppsubship.transform);
				oppsubship.AddTarget(curplayersubship.transform);
				oppsubship.SetUseTactic(true);
				GamePlayerManager.Instance.m_CurrentPlayerShip.AddTarget(oppsubship.transform);
			}
		}

		for(int i = 0; i < GamePlayerManager.Instance.m_OppSubShipList.Count; i++)
		{
			PlayerSubShip subship = GamePlayerManager.Instance.m_OppSubShipList[i];
			subship.AddTarget(GamePlayerManager.Instance.m_CurrentPlayerShip.transform);
			subship.SetUseTactic(true);
			GamePlayerManager.Instance.m_CurrentPlayerShip.AddTarget(subship.transform);
			for(int j = 0; j < GamePlayerManager.Instance.m_SubShipList.Count; j++)
			{
				PlayerSubShip playersubship = GamePlayerManager.Instance.m_SubShipList[j];
				subship.AddTarget(playersubship.transform);
			}
		}

		//add buff		
		GameShipBuff pvphealthbuff = new GameShipBuff();
		pvphealthbuff.BuffRemainType = GameShipBuffRemainType.INFINITE;
		pvphealthbuff.BuffType = GameShipBuffType.HEALTH_INCREASE;
		pvphealthbuff.Value1 = Managers.GameBalanceData.PVPHealthIncreaseRatio;
		pvphealthbuff.Value2 = Managers.GameBalanceData.PVPHealthIncreaseRatio;

		GameShipBuff pvpsubshiphealthbuff = new GameShipBuff();
		pvpsubshiphealthbuff.BuffRemainType = GameShipBuffRemainType.INFINITE;
		pvpsubshiphealthbuff.BuffType = GameShipBuffType.HEALTH_INCREASE;
		pvpsubshiphealthbuff.Value1 = Managers.GameBalanceData.PVPSubshipHealthIncreaseRatio;
		pvpsubshiphealthbuff.Value2 = Managers.GameBalanceData.PVPSubshipHealthIncreaseRatio;

		m_Player.AddBuff(pvphealthbuff);
		m_Player.Revive();
		for(int i = 0; i < GamePlayerManager.Instance.m_SubShipList.Count; i++)
		{
			GamePlayerManager.Instance.m_SubShipList[i].AddBuff(pvpsubshiphealthbuff);
			GamePlayerManager.Instance.m_SubShipList[i].Revive();
		}
		GamePlayerManager.Instance.m_OppPlayerShip.AddBuff(pvphealthbuff);
		GamePlayerManager.Instance.m_OppPlayerShip.Revive();
		for(int i = 0; i < GamePlayerManager.Instance.m_OppSubShipList.Count; i++)
		{
			GamePlayerManager.Instance.m_OppSubShipList[i].AddBuff(pvpsubshiphealthbuff);
			GamePlayerManager.Instance.m_OppSubShipList[i].Revive();
		}

		GameShipBuff oppattackbuff = new GameShipBuff();
		oppattackbuff.BuffRemainType = GameShipBuffRemainType.INFINITE;
		oppattackbuff.BuffType = GameShipBuffType.ATTACK_DAMAGE_BUFF;
		oppattackbuff.Value1 = 1f;
		oppattackbuff.Value2 = Managers.GameBalanceData.PVPPlayAttackIncreaseRatio;

		GameShipBuff opphealthbuff = new GameShipBuff();
		opphealthbuff.BuffRemainType = GameShipBuffRemainType.INFINITE;
		opphealthbuff.BuffType = GameShipBuffType.HEALTH_INCREASE;
		opphealthbuff.Value1 = Managers.GameBalanceData.PVPPlayOppHealthIncreaseRatio;
		opphealthbuff.Value2 = Managers.GameBalanceData.PVPPlayOppHealthIncreaseRatio;

		GamePlayerManager.Instance.m_OppPlayerShip.AddBuff(oppattackbuff);
		GamePlayerManager.Instance.m_OppPlayerShip.AddBuff(opphealthbuff);
		GamePlayerManager.Instance.m_OppPlayerShip.Revive();
		for(int i = 0; i < GamePlayerManager.Instance.m_OppSubShipList.Count; i++)
		{
			GamePlayerManager.Instance.m_OppSubShipList[i].AddBuff(oppattackbuff);
			GamePlayerManager.Instance.m_OppSubShipList[i].AddBuff(opphealthbuff);
			GamePlayerManager.Instance.m_OppSubShipList[i].Revive();
		}

		//init effects
		m_ShoutEffect.Init(20f);//m_Player.m_ShipStatInfo.PushForce 
		m_SingijeonEffect.Init(m_Player.m_ShipStatInfo.BulletDamage * 2f);
		
		CharacterNum = Managers.UserData.GetCurrentGameCharacter().IndexNumber;
		
		
		//check character info and set buf
		if(CharacterNum == 2)
		{
			GameShipBuff damagebuff = new GameShipBuff();
			damagebuff.Init(GameShipBuffType.ATTACK_DAMAGE_BUFF, GameShipBuffRemainType.INFINITE, 
			                1f, 
			                Managers.GameBalanceData.GamePlayCharacter2DamageIncreaseRatio,
			                1f,
			                1f,
			                1f);
			m_Player.AddBuff(damagebuff);
			
			GameShipBuff attackratebuff = new GameShipBuff();
			attackratebuff.Init(GameShipBuffType.ATTACK_SPEED_BUFF, GameShipBuffRemainType.INFINITE,
			                    1f,
			                    Managers.GameBalanceData.GamePlayCharacter2AttackSpeedIncreaseRatio,
			                    1f,
			                    1f,
			                    1f);
			m_Player.AddBuff(attackratebuff);
		}else if(CharacterNum == 3)
		{
			//Debug.Log("INVINCIBLE POSSESS");
			HaveInvincible = true;
		}
		
		//check item buff
		if(HaveHealthUpItem)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.Init(GameShipBuffType.HEALTH_INCREASE, GameShipBuffRemainType.INFINITE,
			          1f,
			          Managers.GameBalanceData.HealthItemIncreaseRatio,
			          1f,
			          1f,
			          1f);
			m_Player.AddBuff(buff);
			m_Player.m_CurHealth = m_Player.MaxHealth;
			//m_Player.Heal(m_Player.MaxHealth);
		}
		if(HavePowerUpItem)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.Init(GameShipBuffType.ATTACK_DAMAGE_BUFF, GameShipBuffRemainType.INFINITE,
			          1f,
			          Managers.GameBalanceData.AttackItemDamageIncreaseRatio,
			          1f,
			          1f,
			          1f);
			m_Player.AddBuff(buff);
		}
		
		//GamePathManager.Instance.InitPath(Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance * 2f);
		m_BackgroundManager.SetRandomBackgroundObject();
		m_BackgroundManager.InitLineObstacle(Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance);
				
		_guiManager.InitItemButton(HaveShoutItem, HaveSingijeon, HaveInvincible);

		int remainopp = GamePlayerManager.Instance.GetOpponentAlive();
		int totalopp = GamePlayerManager.Instance.GetOpponentTotal();
		
		PVPRemainTimer = Managers.GameBalanceData.PVPPlayTime;
		_guiManager.UpdatePVPUI(remainopp, totalopp, (int)PVPRemainTimer);

		GamePathManager2.Instance.Init();
		yield return null ;
		
		while(_gameState == GameState.PVP_INIT) {		
			
			_gameState = GameState.PVP_READY ;
			
			yield return null ;			
		}
		
		StartCoroutine(_gameState.ToString()) ;
		
	}

	private IEnumerator PVP_READY() {
		
		_guiManager.SetItemUseButtonDisable() ;
		
		
		// Submarine FSM
		//_gameSubmarine.SetSubmarineStateReady() ;
		//
		
		//_gameSubmarine.ChangeSubmarineSpeed(0.3f) ;
		
		//Vector3 startPosition = _gameSubmarine.ThisTransform.position ;
		//Vector3 endPosition = new Vector3(_submarineStartPosition.x, _submarineStartPosition.y, startPosition.z) ;
		
		float t = 0f ;
		bool isDone = false ;
		
		
		yield return null ;
		
		while(_gameState == GameState.PVP_READY) {		
			
			if(!isDone){
				t += (Time.deltaTime*1f) ;
				//_gameSubmarine.ThisTransform.position = Vector3.Lerp(startPosition,endPosition,t) ;
				
				
				if(t > 1f) {
					
					if(Managers.UserData != null){
						
						//_readyGoAlertObject.StartReadyGoAction() ;
						//_guiManager.PlayCutInFxAnimation(1, CharacterNum);
						_guiManager.PlayCutInFxAnimation_PvpGo(PVPDataManager.Instance.m_SelectedPVPUserInfo.CharacterIndex);
					}
					
					//_readyGoAlertObject.StartReadyGoAction() ;
					isDone = true ;
				}
			}else
			{
				t += Time.fixedDeltaTime;
				if(t > 3f)
				{
					_gameState = GameState.PVP_PLAY ;
					if(Managers.UserData.GamePlayCount % 2 == 0)
					{
						if(Managers.Audio != null)
						{
							Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_GAMEPLAY1,true);
						}
					}else
					{
						if(Managers.Audio != null)
						{
							Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_GAMEPLAY2,true);
						}
					}
				}
			}
			
			yield return new WaitForFixedUpdate() ;			
		}
		//Debug.Log("READTY OUT");
		
		StartCoroutine(_gameState.ToString()) ;
		
	}

	private IEnumerator PVP_PLAY() {
		
		_guiManager.GameUIAllButtonEnable();
		_guiManager.SetItemUseButtonEnable(HaveShoutItem, HaveSingijeon, HaveInvincible) ;
		_GameStageManager.ChangeGameSpeed(GameSpeed);
		ReturnToBattleTimer = ReturnToBattleMaxTime;
		yield return null ;
		
		while(_gameState == GameState.PVP_PLAY) {
			float deltatime = Time.deltaTime;
			
			_guiManager.DisplayFeverGauge(InTheGameFeverGauge, FeverModeMaxGauge);
			
			if(!_guiManager.IsPlayingCutInAnimation() && !m_TutorialManager.IsPlaying())
			{
				GamePlayerManager.Instance.Process(deltatime);
				GamePlayerManager.Instance.ProcessOpp(deltatime);
				m_OppAI.Process(deltatime);
				//m_Player.Process(deltatime);
				m_GameBulletObjectManager.Process(deltatime);
				m_FeverEffect.Process(deltatime);
				m_FeverEffect2.Process(deltatime);
				CheckPlayerBound(deltatime);
				_guiManager.DisplayHealthGauge(m_Player.m_CurHealth, m_Player.MaxHealth);
			}
			//check game clear or fail

			ProcessPVPPlay(deltatime);
			yield return new WaitForFixedUpdate();
		}
		
		
		StartCoroutine(_gameState.ToString()) ;
		
	}

	protected void ProcessPVPPlay(float _timer)
	{
		PVPRemainTimer -= _timer;
				
		if (GamePlayerManager.Instance.GetOpponentAlive() == 0){
			
			// Game 중지 상태 호출.
			if (!_isGameOver && !_isTutorialMode){
				
				_guiManager.GameUIAllButtonDisable();
				//_gameSubmarine.SetSubmarineStateIdle();
				_gameState = GameState.PVP_CLEAR ;
			}
		}else if(m_Player.m_CurHealth <= 0)
		{
			if (!_isGameOver)
			{
				_guiManager.GameUIAllButtonDisable();
				_gameState = GameState.PVP_DEAD;
			}
		}else if(PVPRemainTimer <= 0f)
		{
			if (!_isGameOver)
			{
				_guiManager.GameUIAllButtonDisable();
				_gameState = GameState.PVP_DEAD;
			}
		}

		int remainopp = GamePlayerManager.Instance.GetOpponentAlive();
		int totalopp = GamePlayerManager.Instance.GetOpponentTotal();

		float remainsec = PVPRemainTimer;
		_guiManager.UpdatePVPUI(remainopp, totalopp, (int)remainsec);

		List<GameObject> targetlist = new List<GameObject>();
		targetlist.Add(GamePlayerManager.Instance.m_OppPlayerShip.gameObject);
		m_EnemyNotifier.UpdateTargetUI(targetlist);
	}

	private IEnumerator PVP_CLEAR() 
	{
		_guiManager.PlayWinAnimation();
		_guiManager.SetItemUseButtonDisable() ;
		Managers.Torpedo.AddTorpedo(1);
		//set user stage data
		Managers.UserData.SetUserStageDataClear(Managers.UserData.SelectedStageIndex);
		
		yield return new WaitForSeconds(2f) ;
		PVPResultFlag = true;
		_gameState = GameState.PVP_RESULT;
		StartCoroutine(_gameState.ToString());
		yield break;
	}

	private IEnumerator PVP_DEAD() {
		
		_guiManager.PlayLoseAnimation();
		_guiManager.SetItemUseButtonDisable() ;
		
		yield return new WaitForSeconds(2f) ;
		
		PVPResultFlag = false;
		_gameState = GameState.PVP_RESULT;
		StartCoroutine(_gameState.ToString());
		yield break;
	}

	private IEnumerator PVP_RESULT() {

		// Mission
		CalculateMissionDataWithPlayTime() ;
		
		float t =0f ;
		
		yield return null ;
		
		while(_gameState == GameState.PVP_RESULT) {		
			
			t += Time.deltaTime ;
			
			if(t > 1.5f && !_isGameOver){
				
				_isGameOver = true ;				
				int gaincoin = 0;
				if(PVPResultFlag)
				{
					gaincoin += PVPDataManager.Instance.m_SelectedPVPUserInfo.RewardAmount;
				}
				gaincoin += CoinItemGet;
				Managers.UserData.SetGainGold(gaincoin);

				Managers.DataStream.Event_Delegate_DataStreamManager_PVP += (int intResult_Code_Input, string strResult_Extend_Input) => 
				{
					if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK)
					{							
						_guiManager.LoadPVPResultUI(PVPResultFlag, gaincoin, PVPDataManager.Instance.MyWinCount, PVPDataManager.Instance.MyLoseCount);
					}else
					{
						Managers.DataStream.PVP_Request_SaveBattleResult(PVPDataManager.Instance.m_SelectedPVPUserInfo.UserIndex,
						                                                 PVPResultFlag);
					}
				};
				Managers.DataStream.PVP_Request_SaveBattleResult(PVPDataManager.Instance.m_SelectedPVPUserInfo.UserIndex,
				                                                 PVPResultFlag);

			}
			
			yield return null ;			
		}
		
	}
	//
	// GameManager FSM
	//------------------------------------
	private IEnumerator GameInitialize() {
				
		_guiManager.SetItemUseButtonDisable() ;

		//init player
		//m_Player
		GamePlayerManager.Instance.SpawnPlayer(Managers.UserData.GetCurrentUserShipData());
		m_Player = GamePlayerManager.Instance.m_CurrentPlayerShip;
		m_Player.ShootEvent += PlayerShootEvent;
		m_Player.DamagedEvent += PlayerDamagedEvent;
		_GameStageManager.EnemyShootEvent 				+= EnemyShootEvent;
		_GameStageManager.DefendLinePassEvent 			+= EnemyDefendLinePassEvent;
		_GameStageManager.EnemyDeadEvent				+= EnemyDeadEvent;
		
		for(int i = 1 ; i <= Managers.GameBalanceData.SubShipEquipAvailableMaxCount; i++)
		{
			int shipindex = Managers.UserData.GetEquipedSubShipIndex(i);
			if(shipindex != 0)
			{
				GamePlayerManager.Instance.SpawnSubShip (Managers.UserData.GetUserSubShipData(shipindex));
			}
		}
		
		m_PlayerController.Init(m_Player);
		
		//init effects
		m_ShoutEffect.Init(20f);//m_Player.m_ShipStatInfo.PushForce 
		m_SingijeonEffect.Init(m_Player.m_ShipStatInfo.BulletDamage * 2f);
		
		CharacterNum = Managers.UserData.GetCurrentGameCharacter().IndexNumber;
		
		
		//check character info and set buf
		if(CharacterNum == 2)
		{
			GameShipBuff damagebuff = new GameShipBuff();
			damagebuff.Init(GameShipBuffType.ATTACK_DAMAGE_BUFF, GameShipBuffRemainType.INFINITE, 
			                1f, 
			                Managers.GameBalanceData.GamePlayCharacter2DamageIncreaseRatio,
			                1f,
			                1f,
			                1f);
			m_Player.AddBuff(damagebuff);
			
			GameShipBuff attackratebuff = new GameShipBuff();
			attackratebuff.Init(GameShipBuffType.ATTACK_SPEED_BUFF, GameShipBuffRemainType.INFINITE,
			                    1f,
			                    Managers.GameBalanceData.GamePlayCharacter2AttackSpeedIncreaseRatio,
			                    1f,
			                    1f,
			                    1f);
			m_Player.AddBuff(attackratebuff);
		}else if(CharacterNum == 3)
		{
			Debug.Log("INVINCIBLE POSSESS");
			HaveInvincible = true;
		}
		
		//check item buff
		if(HaveHealthUpItem)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.Init(GameShipBuffType.HEALTH_INCREASE, GameShipBuffRemainType.INFINITE,
			          1f,
			          Managers.GameBalanceData.HealthItemIncreaseRatio,
			          1f,
			          1f,
			          1f);
			m_Player.AddBuff(buff);
			m_Player.m_CurHealth = m_Player.MaxHealth;
			//m_Player.Heal(m_Player.MaxHealth);
		}
		if(HavePowerUpItem)
		{
			GameShipBuff buff = new GameShipBuff();
			buff.Init(GameShipBuffType.ATTACK_DAMAGE_BUFF, GameShipBuffRemainType.INFINITE,
			          1f,
			          Managers.GameBalanceData.AttackItemDamageIncreaseRatio,
			          1f,
			          1f,
			          1f);
			m_Player.AddBuff(buff);
		}
		
		//GamePathManager.Instance.InitPath(Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance * 2f);
		m_BackgroundManager.SetBackgroundObject(Managers.GameBalanceData.GetStageData(Managers.UserData.SelectedStageIndex).BackgroundType);
		m_BackgroundManager.InitLineObstacle(Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance);
				
		_guiManager.InitItemButton(HaveShoutItem, HaveSingijeon, HaveInvincible);
		GamePathManager2.Instance.Init();
		yield return null ;
		
		while(_gameState == GameState.GameInitialize) {		
			
			_gameState = GameState.GameReady ;
			
			yield return null ;			
		}
		
		StartCoroutine(_gameState.ToString()) ;
		
	}
	
	/*
	private IEnumerator GameTutorial(){
		
		
		yield return null ;
		
		while(_gameState == GameState.GameTutorial) {		
			
			yield return null ;
			
		}
		
		StartCoroutine(_gameState.ToString()) ;
		
	}
	*/
	
	private void ReadyGoAlertObjectEvent(){
		_gameState = GameState.GamePlayMode ;
		Debug.Log ("?? CALLED?:");
		_GameStageManager.ResumeStage(1.5f);
	}
	
	//------------------------------------
	private IEnumerator GameReady() {
		
		_guiManager.SetItemUseButtonDisable() ;
		
		
		// Submarine FSM
		//_gameSubmarine.SetSubmarineStateReady() ;
		//
			
		//_gameSubmarine.ChangeSubmarineSpeed(0.3f) ;
		
		//Vector3 startPosition = _gameSubmarine.ThisTransform.position ;
		//Vector3 endPosition = new Vector3(_submarineStartPosition.x, _submarineStartPosition.y, startPosition.z) ;
		
		float t = 0f ;
		bool isDone = false ;
		
		
		yield return null ;
		
		while(_gameState == GameState.GameReady) {		
			
			if(!isDone){
				t += (Time.deltaTime*1f) ;
				//_gameSubmarine.ThisTransform.position = Vector3.Lerp(startPosition,endPosition,t) ;
				
				
				if(t > 1f) {
					
					if(Managers.UserData != null){

						//_readyGoAlertObject.StartReadyGoAction() ;
						//_guiManager.PlayCutInFxAnimation(1, CharacterNum);
						_guiManager.PlayCutInFxAnimation_GO(CharacterNum);
					}
					
					//_readyGoAlertObject.StartReadyGoAction() ;
					isDone = true ;
				}
			}else
			{
				t += Time.fixedDeltaTime;
				if(t > 3f)
				{
					_gameState = GameState.GamePlayMode ;
					if(Managers.UserData.GamePlayCount % 2 == 0)
					{
						if(Managers.Audio != null)
						{
							Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_GAMEPLAY1,true);
						}
					}else
					{
						if(Managers.Audio != null)
						{
							Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_GAMEPLAY2,true);
						}
					}
				}
			}

			yield return new WaitForFixedUpdate() ;			
		}
		//Debug.Log("READTY OUT");
		
		StartCoroutine(_gameState.ToString()) ;
		
	}

	//------------------------------------
	private IEnumerator GamePlayMode() {

		_guiManager.GameUIAllButtonEnable();
		_guiManager.SetItemUseButtonEnable(HaveShoutItem, HaveSingijeon, HaveInvincible) ;
		_GameStageManager.ChangeGameSpeed(GameSpeed);
		ReturnToBattleTimer = ReturnToBattleMaxTime;		
		yield return null ;

		if(GameStage == 1)
		{
			m_TutorialManager.StartTutorial();
		}

		while(_gameState == GameState.GamePlayMode) {
			float deltatime = Time.fixedDeltaTime;

			_guiManager.DisplayFeverGauge(InTheGameFeverGauge, FeverModeMaxGauge);

			if(!_guiManager.IsPlayingCutInAnimation() && !m_TutorialManager.IsPlaying())
			{
				GamePlayerManager.Instance.Process(deltatime);
				//m_Player.Process(deltatime);
				m_GameBulletObjectManager.Process(deltatime);
				m_FeverEffect.Process(deltatime);
				m_FeverEffect2.Process(deltatime);
				ProcessGameStageManager(deltatime);
				CheckPlayerBound(deltatime);
				_guiManager.DisplayHealthGauge(m_Player.m_CurHealth, m_Player.MaxHealth);
			}
			//check game clear or fail

			// 스테이지 클리어 체크.
			if (_GameStageManager.StageIsDone()){
				
				// Game 중지 상태 호출.
				if (!_isGameOver && !_isTutorialMode){
					
					_guiManager.GameUIAllButtonDisable();
					//_gameSubmarine.SetSubmarineStateIdle();
					_gameState = GameState.GameClear ;
				}
			}else if(m_Player.m_CurHealth <= 0)
			{
				if (!_isGameOver)
				{
					_guiManager.GameUIAllButtonDisable();
					_gameState = GameState.GamePlayerDead;
				}
			}
			yield return new WaitForFixedUpdate();
		}
		
		StartCoroutine(_gameState.ToString()) ;		
	}


	private IEnumerator GameClear() 
	{
		_guiManager.PlayWinAnimation();
		_guiManager.SetItemUseButtonDisable() ;
		Managers.Torpedo.AddTorpedo(1);
		//set user stage data
		Managers.UserData.SetUserStageDataClear(Managers.UserData.SelectedStageIndex);

		yield return new WaitForSeconds(2f) ;
		GameClearFlag = true;
		_gameState = GameState.GameResult;
		StartCoroutine(_gameState.ToString());
		yield break;
	}

	/*
	//------------------------------------
	private IEnumerator GameBoosterMode() {
		
		// Submarine FSM
		_gameSubmarine.SetSubmarineStateBooster() ;
		//
		
		yield return null ;
		
		while(_gameState == GameState.GameBoosterMode) {		
			
			yield return null ;			
		}

		
		StartCoroutine(_gameState.ToString()) ;
		
	}
	*/
	
	// 이어하기 수정 - 시작 (14.03.12 by 최원석).
	//private bool isShieldState = false ;
	private bool isGameOverState = false ;
	private bool boolShownContinuePopupView = false ;
	// 이어하기 수정 - 끝.
	
	//------------------------------------
	private IEnumerator GamePlayerDead() {
		//Debug.Log("GOT IN GAMEPLAYER DEAD");
		_guiManager.SetItemUseButtonDisable() ;
		
		// Submarine FSM
		//_gameSubmarine.SetSubmarineStateDead() ;
		//
		
		_cameraShakeScript.DoCameraShake(0.1f, 0.004f) ;

		isGameOverState = false ;

		{
			
			//_gameSubmarine.ChangeStateSubmarineDeadReadyEffect(true) ;

			
			if(HaveItemRevive){
				if(Managers.UserData != null){
					ST200KLogManager.Instance.SaveGameItemUse(Constant.ST200_ITEM_REVIVE);
					Managers.UserData.SetUseGameItem(Constant.ST200_ITEM_REVIVE,1) ;
				}
				HaveItemRevive = false;
				_gameState = GameState.GamePlayerReviveWait ;
				m_IsRevivedByItem = true;
			}else { 

				// 이어하기 수정 - 시작 (14.03.12 by 최원석).
				if (!m_IsRevivedByItem && !boolShownContinuePopupView && 
				    Managers.UserData.GameJewel >= Managers.GameBalanceData.CrystalExpendForContinue){
					
					// 딜레이 주기.
					yield return new WaitForSeconds(1);
					
					// 이어하기 팝업창 띄우기.
					_guiManager.Load_Continue_PopupView();
					
					// 메소드 정지하고 빠져나가기.
					yield break;
					
				} else {
					_guiManager.EndEnterAni() ;
					
					isGameOverState = true ;
				}
				// 이어하기 수정 - 끝.

			}
			
		}
		

		float t = 0f ;
		
		float tt = 0f ;
		bool _isTTDone = false ;
		
		yield return null ;
		
		while(_gameState == GameState.GamePlayerDead) {		
			
			if(isGameOverState){
				//Debug.Log("running player dead state");
				if(!_isTTDone)
				{				
					tt += Time.deltaTime ;
					//Debug.Log("UMM.... TIMER?: " + tt);
					if(tt >= 2.5f){
						//////
						//Boss Image Off
						//////
						_guiManager.EndOutAni() ;
						
						_isTTDone = true ;
						tt = 0f ;
						
						_gameState = GameState.GameOver ;
						//Debug.Log("UMM.... HI?");
					}					
				}
				
			}
			
			yield return null ;			
		}

		//Debug.Log("GOT OUT: " + _gameState);
		StartCoroutine(_gameState.ToString()) ;
		
	}

	bool m_IsRevivedByItem = false;
	//------------------------------------
	private IEnumerator GamePlayerReviveWait() {
		_guiManager.SetItemUseButtonDisable() ;
		
		// Submarine FSM
		//_gameSubmarine.SetSubmarineStateReviveWait() ;
		//

		// **GamePlayerDead State Pattern and Parallax and Distance All Pause..

		_gameState = GameState.GamePlayerRevive ;

		yield return new WaitForSeconds(1f);
		yield return null ;
		
		while(_gameState == GameState.GamePlayerReviveWait) {		
			
			yield return null ;			
		}

		
		StartCoroutine(_gameState.ToString()) ;
		
	}
	
	
	//------------------------------------
	private IEnumerator GamePlayerRevive() {

		GamePlayerManager.Instance.ReviveAll();

		_guiManager.SetItemUseButtonDisable() ;
		DeadEnabled = false;

		_gameState = GameState.GamePlayMode ;	

		float t = 0f ;
		bool isDone = false ;

		StartCoroutine(_gameState.ToString()) ;
		yield break;
	}

	
	//------------------------------------
	private IEnumerator GameOver() {

		_guiManager.PlayLoseAnimation();
		_guiManager.SetItemUseButtonDisable() ;
							
		yield return new WaitForSeconds(2f) ;

		GameClearFlag = false;
		_gameState = GameState.GameResult;
		StartCoroutine(_gameState.ToString());
		yield break;
	}

	private IEnumerator GameResult() {
		if(PlayerPrefs.GetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT) == Constant.INT_False)
		{
			Managers.UserData.GameClearCount++;
			//Debug.Log("CLEAR COUNT: " + Managers.UserData.GameClearCount);
			//if(Managers.UserData.GameClearCount % 10 == 0)
			//{
			//	Managers.UserData.AddLuckyCoupon(1);
			//}
		}
		//
		//_guiManager.SetResultData(InTheGameDistance, InTheGameGetCoin, InTheGameGetScore, AllKillCount) ;
		//
		
		// Mission
		CalculateMissionDataWithPlayTime() ;
		//	
		ST200KLogManager.Instance.SaveGameEnd(GameStage,
		                                      Managers.UserData.GetCurrentUserShipData().IndexNumber,
		                                      Managers.UserData.GetCurrentUserShipData().Level,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(1)).IndexNumber,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(1)).Level,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(2)).IndexNumber,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(2)).Level,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(3)).IndexNumber,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(3)).Level,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(4)).IndexNumber,
		                                      Managers.UserData.GetUserSubShipData(Managers.UserData.GetEquipedSubShipIndex(4)).Level,
		                                      Managers.UserData.GetCurrentGameCharacter().IndexNumber,
		                                      PlayerHitCount,
		                                      EnemyKillCount,
		                                      PlayerCrashCount);

		float t =0f ;
		
		yield return null ;
		
		while(_gameState == GameState.GameResult) {		
			
			t += Time.deltaTime ;
			
			if(t > 1.5f && !_isGameOver){

				_isGameOver = true ;

				StageData stagedata = Managers.GameBalanceData.GetStageData(GameStage);
				UserStageData data = Managers.UserData.GetUserStageData(GameStage);
				bool newscore = false;
				int gaincoin = 0;
				InTheGameGetScore += Mathf.Max(0, (int)(m_Player.m_CurHealth * 10f));
				if(GameClearFlag)
				{
					if(data.MaxScore < InTheGameGetScore)
					{
						newscore = true;
					}
					data.MaxScore = InTheGameGetScore;
					Managers.UserData.SetUserStageData(data);
					gaincoin = stagedata.WinCoinGetAmount;
				}else
				{
					gaincoin = stagedata.LoseCoinGetAmount;
				}

				int killgaincoin = (int)EnemyKillCount * (int)Managers.GameBalanceData.GamePlayKillGainCoinAmount;
				if(Managers.UserData.GetCurrentGameCharacter().IndexNumber == 4)
				{
					killgaincoin *= 2;
				}
				gaincoin += killgaincoin;
				gaincoin += CoinItemGet;

				Managers.UserData.SetGainGold(gaincoin);
				Managers.UserData.SetGainJewel(GoldItemGet);

				_guiManager.LoadResultGameUI(EnemyKillCount, gaincoin, GoldItemGet, InTheGameGetScore, newscore );

				//save worldrank
				int totalscore = 0;
				for(int i = 0; i < Managers.UserData.m_UserStageDataList.Count; i++)
				{
					UserStageData userdata = Managers.UserData.m_UserStageDataList[i];
					totalscore += userdata.MaxScore;
				}
				int maxstageopenindex = 0;
				for(int i = 0; i < Managers.UserData.m_UserStageDataList.Count; i++)
				{
					UserStageData userstagedata = Managers.UserData.m_UserStageDataList[i];
					if(userstagedata.IsOpen)
					{
						if(userstagedata.IndexNumber > maxstageopenindex)
						{
							maxstageopenindex = userstagedata.IndexNumber;
						}
					}
				}
				WorldRankManager.Instance.SaveWorldRanking(Managers.UserData.UserID,
				                                           Managers.UserData.UserNickName,
				                                           totalscore,
				                                           maxstageopenindex,
				                                           Managers.UserData.GetCurrentGameCharacter().IndexNumber.ToString());
			}
			
			yield return null ;			
		}
		
	}
	#endregion
	
	//-----------------------------------
	private void CalculateMissionDataWithGameDataWithDistance(int currentDistance, int currentGainDistance){
		
		// _gameMissionGrade1Data
		if(_gameMissionGrade1Data.MissionType == 11 && !_gameMissionGrade1Data.IsAttain) {
			if(_gameMissionGrade1Data.MissionCondition <= currentDistance) {
				
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 11 Mission Complete") ;
					
				}
			}
		}else if(_gameMissionGrade1Data.MissionType == 12 && !_gameMissionGrade1Data.IsAttain){
			
			_gameMissionGrade1Data.CumulativeNumber += currentGainDistance ; //(currentDistance - _gameMissionGrade1Data.CumulativeNumber) ;
			
			if(_gameMissionGrade1Data.MissionCondition <= _gameMissionGrade1Data.CumulativeNumber) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 12 Mission Complete") ;
					
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(1,_gameMissionGrade1Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade2Data
		if(_gameMissionGrade2Data.MissionType == 11 && !_gameMissionGrade2Data.IsAttain){
			if(_gameMissionGrade2Data.MissionCondition <= currentDistance) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 11 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade2Data.MissionType == 12 && !_gameMissionGrade2Data.IsAttain){
			
			_gameMissionGrade2Data.CumulativeNumber += currentGainDistance ; //(currentDistance - _gameMissionGrade2Data.CumulativeNumber) ;
			
			if(_gameMissionGrade2Data.MissionCondition <= _gameMissionGrade2Data.CumulativeNumber) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 12 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(2,_gameMissionGrade2Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade3Data
		if(_gameMissionGrade3Data.MissionType == 11 && !_gameMissionGrade3Data.IsAttain){
			if(_gameMissionGrade3Data.MissionCondition <= currentDistance) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 11 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade3Data.MissionType == 12 && !_gameMissionGrade3Data.IsAttain){
			
			_gameMissionGrade3Data.CumulativeNumber += currentGainDistance ; //(currentDistance - _gameMissionGrade3Data.CumulativeNumber) ;
			
			if(_gameMissionGrade3Data.MissionCondition <= _gameMissionGrade3Data.CumulativeNumber) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 12 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(3,_gameMissionGrade3Data.CumulativeNumber) ;
			}
			
		}
		
	}
	
	
	private void CalculateMissionDataWithGameDataWithCoin(int currentCoin, int gainCoin){
		
		// _gameMissionGrade1Data
		if(_gameMissionGrade1Data.MissionType == 21 && !_gameMissionGrade1Data.IsAttain){
			if(_gameMissionGrade1Data.MissionCondition <= currentCoin) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 21 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade1Data.MissionType == 22 && !_gameMissionGrade1Data.IsAttain){
			
			_gameMissionGrade1Data.CumulativeNumber += gainCoin ; //(currentCoin - _gameMissionGrade1Data.CumulativeNumber) ;
			
			if(_gameMissionGrade1Data.MissionCondition <= _gameMissionGrade1Data.CumulativeNumber) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 22 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(1,_gameMissionGrade1Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade2Data
		if(_gameMissionGrade2Data.MissionType == 21 && !_gameMissionGrade2Data.IsAttain){
			if(_gameMissionGrade2Data.MissionCondition <= currentCoin) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 21 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade2Data.MissionType == 22 && !_gameMissionGrade2Data.IsAttain){
			
			_gameMissionGrade2Data.CumulativeNumber += gainCoin ; //(currentCoin - _gameMissionGrade2Data.CumulativeNumber) ;
			
			if(_gameMissionGrade2Data.MissionCondition <= _gameMissionGrade2Data.CumulativeNumber) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 22 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(2,_gameMissionGrade2Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade3Data
		if(_gameMissionGrade3Data.MissionType == 21 && !_gameMissionGrade3Data.IsAttain){
			if(_gameMissionGrade3Data.MissionCondition <= currentCoin) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 21 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade3Data.MissionType == 22 && !_gameMissionGrade3Data.IsAttain){
			
			_gameMissionGrade3Data.CumulativeNumber += gainCoin ; //(currentCoin - _gameMissionGrade3Data.CumulativeNumber) ;
			
			if(_gameMissionGrade3Data.MissionCondition <= _gameMissionGrade3Data.CumulativeNumber) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 22 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(3,_gameMissionGrade3Data.CumulativeNumber) ;
			}
			
		}
		
	}
	

	private void CalculateMissionDataWithGameDataWithKillEnemy(int currentKillEnemy, int currentKillEnemyCount){
		
		// _gameMissionGrade1Data
		if(_gameMissionGrade1Data.MissionType == 31 && !_gameMissionGrade1Data.IsAttain){
			if(_gameMissionGrade1Data.MissionCondition <= currentKillEnemy) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 31 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade1Data.MissionType == 32 && !_gameMissionGrade1Data.IsAttain){
			
			_gameMissionGrade1Data.CumulativeNumber += currentKillEnemyCount ; //(currentKillEnemy - _gameMissionGrade1Data.CumulativeNumber) ;
			
			if(_gameMissionGrade1Data.MissionCondition <= _gameMissionGrade1Data.CumulativeNumber) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 32 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(1,_gameMissionGrade1Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade2Data
		if(_gameMissionGrade2Data.MissionType == 31 && !_gameMissionGrade2Data.IsAttain){
			if(_gameMissionGrade2Data.MissionCondition <= currentKillEnemy) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 31 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade2Data.MissionType == 32 && !_gameMissionGrade2Data.IsAttain){
			
			_gameMissionGrade2Data.CumulativeNumber += currentKillEnemyCount ; //(currentKillEnemy - _gameMissionGrade2Data.CumulativeNumber) ;
			
			if(_gameMissionGrade2Data.MissionCondition <= _gameMissionGrade2Data.CumulativeNumber) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 32 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(2,_gameMissionGrade2Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade3Data
		if(_gameMissionGrade3Data.MissionType == 31 && !_gameMissionGrade3Data.IsAttain){
			if(_gameMissionGrade3Data.MissionCondition <= currentKillEnemy) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 31 Mission Complete") ;
				}
			}
		}else if(_gameMissionGrade3Data.MissionType == 32 && !_gameMissionGrade3Data.IsAttain){
			
			_gameMissionGrade3Data.CumulativeNumber += currentKillEnemyCount ; //(currentKillEnemy - _gameMissionGrade3Data.CumulativeNumber) ;
			
			if(_gameMissionGrade3Data.MissionCondition <= _gameMissionGrade3Data.CumulativeNumber) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 32 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(3,_gameMissionGrade3Data.CumulativeNumber) ;
			}
			
		}
		
	}
	
	public void CalculateMissionDataWithKillBoss(){
		
		// _gameMissionGrade1Data
		if(_gameMissionGrade1Data.MissionType == 42 && !_gameMissionGrade1Data.IsAttain){
			
			_gameMissionGrade1Data.CumulativeNumber += 1 ;
			
			if(_gameMissionGrade1Data.MissionCondition <= _gameMissionGrade1Data.CumulativeNumber) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 42 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(1,_gameMissionGrade1Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade2Data
		if(_gameMissionGrade2Data.MissionType == 42 && !_gameMissionGrade2Data.IsAttain){
			
			_gameMissionGrade2Data.CumulativeNumber += 1 ;
			
			if(_gameMissionGrade2Data.MissionCondition <= _gameMissionGrade2Data.CumulativeNumber) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 42 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(2,_gameMissionGrade2Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade3Data
		if(_gameMissionGrade3Data.MissionType == 42 && !_gameMissionGrade3Data.IsAttain){
			
			_gameMissionGrade3Data.CumulativeNumber += 1 ;
			
			if(_gameMissionGrade3Data.MissionCondition <= _gameMissionGrade3Data.CumulativeNumber) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 42 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(3,_gameMissionGrade3Data.CumulativeNumber) ;
			}
			
		}
		
	}
	
	private void CalculateMissionDataWithPlayTime(){
		
		// _gameMissionGrade1Data
		if(_gameMissionGrade1Data.MissionType == 62 && !_gameMissionGrade1Data.IsAttain){
			
			_gameMissionGrade1Data.CumulativeNumber += 1 ;
			
			if(_gameMissionGrade1Data.MissionCondition <= _gameMissionGrade1Data.CumulativeNumber) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 62 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(1,_gameMissionGrade1Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade2Data
		if(_gameMissionGrade2Data.MissionType == 62 && !_gameMissionGrade2Data.IsAttain){
			
			_gameMissionGrade2Data.CumulativeNumber += 1 ;
			
			if(_gameMissionGrade2Data.MissionCondition <= _gameMissionGrade2Data.CumulativeNumber) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 62 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(2,_gameMissionGrade2Data.CumulativeNumber) ;
			}
			
		}
		
		// _gameMissionGrade3Data
		if(_gameMissionGrade3Data.MissionType == 62 && !_gameMissionGrade3Data.IsAttain){
			
			_gameMissionGrade3Data.CumulativeNumber += 1 ;
			
			if(_gameMissionGrade3Data.MissionCondition <= _gameMissionGrade3Data.CumulativeNumber) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 62 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(3,_gameMissionGrade3Data.CumulativeNumber) ;
			}
			
		}
		
	}
	
	private void CalculateMissionDataWithUseItem(int useItemType){
		
		//useItemType 1: LastBooster  , 2:EMP  , 3:StartBooster , 4:Shield , 5:Break, 6:Revive
		
		// _gameMissionGrade1Data
		if(_gameMissionGrade1Data.MissionType == 51 && !_gameMissionGrade1Data.IsAttain){
			
			if(_gameMissionGrade1Data.IndexNumber == 501 && useItemType == 1){ // LastBooster 
				_gameMissionGrade1Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade1Data.IndexNumber == 511 && useItemType == 2){ // EMP
				_gameMissionGrade1Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade1Data.IndexNumber == 521 && useItemType == 3){ // StartBooster
				_gameMissionGrade1Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade1Data.IndexNumber == 531 && useItemType == 4){ // Shield
				_gameMissionGrade1Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade1Data.IndexNumber == 541 && useItemType == 5){ // Break
				_gameMissionGrade1Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade1Data.IndexNumber == 551 && useItemType == 6){ // Revive
				_gameMissionGrade1Data.CumulativeNumber += 1 ;
			}
			
			if(_gameMissionGrade1Data.MissionCondition <= _gameMissionGrade1Data.CumulativeNumber) {
				_gameMissionGrade1Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(1,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade1Data 51 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(1,_gameMissionGrade1Data.CumulativeNumber) ;
			}
			
		}
	
		// _gameMissionGrade2Data
		if(_gameMissionGrade2Data.MissionType == 51 && !_gameMissionGrade2Data.IsAttain){
			
			if(_gameMissionGrade2Data.IndexNumber == 501 && useItemType == 1){ // LastBooster 
				_gameMissionGrade2Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade2Data.IndexNumber == 511 && useItemType == 2){ // EMP
				_gameMissionGrade2Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade2Data.IndexNumber == 521 && useItemType == 3){ // StartBooster
				_gameMissionGrade2Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade2Data.IndexNumber == 531 && useItemType == 4){ // Shield
				_gameMissionGrade2Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade2Data.IndexNumber == 541 && useItemType == 5){ // Break
				_gameMissionGrade2Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade2Data.IndexNumber == 551 && useItemType == 6){ // Revive
				_gameMissionGrade2Data.CumulativeNumber += 1 ;
			}
			
			if(_gameMissionGrade2Data.MissionCondition <= _gameMissionGrade2Data.CumulativeNumber) {
				_gameMissionGrade2Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(2,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade2Data 51 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(2,_gameMissionGrade2Data.CumulativeNumber) ;
			}
			
		}
		
		
		// _gameMissionGrade3Data
		if(_gameMissionGrade3Data.MissionType == 51 && !_gameMissionGrade3Data.IsAttain){
			
			if(_gameMissionGrade3Data.IndexNumber == 501 && useItemType == 1){ // LastBooster 
				_gameMissionGrade3Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade3Data.IndexNumber == 511 && useItemType == 2){ // EMP
				_gameMissionGrade3Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade3Data.IndexNumber == 521 && useItemType == 3){ // StartBooster
				_gameMissionGrade3Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade3Data.IndexNumber == 531 && useItemType == 4){ // Shield
				_gameMissionGrade3Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade3Data.IndexNumber == 541 && useItemType == 5){ // Break
				_gameMissionGrade3Data.CumulativeNumber += 1 ;
			}else if(_gameMissionGrade3Data.IndexNumber == 551 && useItemType == 6){ // Revive
				_gameMissionGrade3Data.CumulativeNumber += 1 ;
			}
			
			if(_gameMissionGrade3Data.MissionCondition <= _gameMissionGrade3Data.CumulativeNumber) {
				_gameMissionGrade3Data.IsAttain = true ;
				
				if(Managers.UserData != null){
					Managers.UserData.UpdateGameMissionDataStateAttain(3,true) ;	
					
					// Display Mission Attain State!!!
					//Debug.Log("_gameMissionGrade3Data 51 Mission Complete") ;
				}
			}
			
			if(Managers.UserData != null){
				Managers.UserData.UpdateGameMissionDataStateCumulativeNumber(3,_gameMissionGrade3Data.CumulativeNumber) ;
			}
			
		}
		
	}



	// 스테이지 클리어 팝업 추가 (by최원석 14.03.20) - 시작.
	public void ProcessGameStageManager(float _timer){

		if(Managers.UserData.TutorialIsProcessing)
		{
			return;
		}

		_GameStageManager.Process(_timer);
	}

	protected void CheckPlayerBound(float _timer)
	{
		if(Vector2.Distance (Vector3.zero, m_Player.transform.position) > Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance)
		{
			ReturnToBattleTimer -= _timer;
			m_ReturnToBattleWarningAnimation.StartAnimation();
			m_ReturnToBattleWarningAnimation.UpdateTimer(ReturnToBattleTimer);

			if(ReturnToBattleTimer < 0f)
			{
				m_Player.DoDamage(m_Player.MaxHealth, Constant.ST200_GAMEPLAY_DAMAGE_TYPE_NORETURN);
			}
		}else
		{
			ReturnToBattleTimer = ReturnToBattleMaxTime;
			m_ReturnToBattleWarningAnimation.StopAnimation();
		}
	}

	public bool IsPlayingSpecialAction()
	{
		return (m_IsUsingShout || m_IsUsingSingijeon || isGetItemMissile);
	}
}
