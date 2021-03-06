using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using SimpleJSON;
//using UnityEditor;

public class UserDataManager : MonoBehaviour
{
	public struct PurchaseStruct
	{
		public int[] PurchaseList;
	}

	public List<int> PurchaseList = new List<int>();
	public void AddPurchaseList(int _index)
	{
		PurchaseList.Add(_index);
	}

	public void RemovePurchaseList(int _index)
	{
		PurchaseList.Remove(_index);
	}

	public PurchaseStruct GetPurchaseData()
	{
		PurchaseStruct data = new PurchaseStruct();
		data.PurchaseList = PurchaseList.ToArray();

		return data;
	}

	//public string CountryString = "us";

	/// <summary>
	/// 1 - move to submarineshop
	/// 2 - move to charactershop
	/// </summary>
	public int ToShopIndex = 0;
	public bool ReturnToRanking = false;
	public bool TutorialIsProcessing = false;
	public bool GiveTutorialPresent = false;

	public int SelectedStageIndex = 1;
	/// <summary>
	/// 0 - stage mode
	/// 1 - pvp mode
	/// </summary>
	public int SelectedGameType = 0;

	//---
	private string _appVersionInfo ; //Connect
	public string AppVersionInfo {
		set { 
			string encryptString = LoadingWindows.NextE(value,Constant.DefalutAppName) ;
			_appVersionInfo = encryptString ;
		}
		get {
			if(_appVersionInfo == null || _appVersionInfo.Equals("")){
				return null ;	
			}
			string decryptString = LoadingWindows.NextD(_appVersionInfo,Constant.DefalutAppName) ;
			return decryptString;
		}
	}

	///
	private string _userID ;
	public string UserID {
		set { _userID = value ;}
		get { return _userID;}
	}

	private string m_TutorialFlagV119 ;

	
	public bool TutorialFlagV119 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TutorialFlagV119 = encryptString ;
		}
		get { 
			if(m_TutorialFlagV119 == null || m_TutorialFlagV119.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_TutorialFlagV119,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
		
	private string m_TutorialFlag ;
	public bool TutorialFlag {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TutorialFlag = encryptString ;
		}
		get { 
			if(m_TutorialFlag == null || m_TutorialFlag.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_TutorialFlag,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_TutorialChar ;
	public bool TutorialChar {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TutorialChar = encryptString ;
		}
		get { 
			if(m_TutorialChar == null || m_TutorialChar.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_TutorialChar,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_TutorialItem ;
	public bool TutorialItem {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TutorialItem = encryptString ;
		}
		get { 
			if(m_TutorialItem == null || m_TutorialItem.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_TutorialItem,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string _firstInAppPurchaseFlag ; //Connect
	public int FirstInAppPurchaseFlag {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_firstInAppPurchaseFlag = encryptString ;
		}
		get {
			if(_firstInAppPurchaseFlag == null || _firstInAppPurchaseFlag.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_firstInAppPurchaseFlag,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 10;
			return decryptInt;
		}
	}

	private string m_SubShipEquipAvailableSlotCount ; //Connect
	public int SubShipEquipAvailableSlotCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SubShipEquipAvailableSlotCount = encryptString ;
		}
		get {
			if(m_SubShipEquipAvailableSlotCount == null || m_SubShipEquipAvailableSlotCount.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_SubShipEquipAvailableSlotCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 10;
			return decryptInt;
		}
	}


	private string _luckyCoupon ;
	public int LuckyCoupon {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_luckyCoupon = encryptString ;
		}
		get {
			if(_luckyCoupon == null || _luckyCoupon.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_luckyCoupon,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 10;
			return decryptInt;
		}
	}

	private string m_GamePlayCount ;
	public int GamePlayCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayCount = encryptString ;
		}
		get {
			if(m_GamePlayCount == null || m_GamePlayCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _gameClearCount ;
	public int GameClearCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameClearCount = encryptString ;
		}
		get {
			if(_gameClearCount == null || _gameClearCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameClearCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	public bool IsGuestMode = false;
	private string _guestTorpedo ;
	public int GuestTorpedo {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_guestTorpedo = encryptString ;
		}
		get {
			if(_guestTorpedo == null || _guestTorpedo.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_guestTorpedo,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			//return 10;
			return decryptInt;
		}
	}

	private string _friendMessageSent ;
	/// <summary>
	/// Used for boast
	/// </summary>
	public int FriendMessageSent {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_friendMessageSent = encryptString ;
		}
		get {
			if(_friendMessageSent == null || _friendMessageSent.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_friendMessageSent,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _maxBossClear ;
	public int MaxBossClear {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_maxBossClear = encryptString ;
		}
		get {
			if(_maxBossClear == null || _maxBossClear.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_maxBossClear,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _bestScore ;
	public int BestScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bestScore = encryptString ;
		}
		get {
			if(_bestScore == null || _bestScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bestScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	private string _inboxMessageCount ;
	public int InboxMessageCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_inboxMessageCount = encryptString ;
		}
		get {
			if(_inboxMessageCount == null || _inboxMessageCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_inboxMessageCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	public int FriendMessageNew ;

	private string _inboxMessageCountNew ;
	public int InboxMessageCountNew {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_inboxMessageCountNew = encryptString ;
		}
		get {
			if(_inboxMessageCountNew == null || _inboxMessageCountNew.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_inboxMessageCountNew,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	public struct RewardChocolateData {
		private int _chocolateNum ;
		public int ChocolateNum {
			set { _chocolateNum = value ; }
			get { return _chocolateNum ; }
		}

		private string _rewardMessage ;
		public string RewardMessage {
			set { _rewardMessage = value ; }
			get { return _rewardMessage ; }
		}

	};
	
	private Queue<RewardChocolateData> _chocolateRewardMessageQueue ;
	
	
	private string _serverTimeToLocalTimeGap ;
	private int ServerTimeToLocalTimeGap {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_serverTimeToLocalTimeGap = encryptString ;
		}
		get {
			if(_serverTimeToLocalTimeGap == null || _serverTimeToLocalTimeGap.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_serverTimeToLocalTimeGap,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	
	
	// Connect Data..
	private string _torpedoCount ;
	public int TorpedoCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_torpedoCount = encryptString ;
		}
		get {
			if(_torpedoCount == null || _torpedoCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_torpedoCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _torpedoRechargeNextTime ;
	public int TorpedoRechargeNextTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_torpedoRechargeNextTime = encryptString ;
		}
		get {
			if(_torpedoRechargeNextTime == null || _torpedoRechargeNextTime.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_torpedoRechargeNextTime,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	
	///

	private int petSelectedSlotIndex = 1;
	public int PetSelectedSlotIndex {
		set { petSelectedSlotIndex = value;}
		get { return petSelectedSlotIndex;}
	}

	private int characterPageIndex = 1; //1: Submarine  2:Character 
	public int CharacterPageIndex {
		set { characterPageIndex = value;}
		get { return characterPageIndex;}
	}
	
	private int previousPageIndex = 1; //1: Ranking   2: Shop   3:SubmarineSelect   4:Character
	public int PreviousPageIndex {
		set { previousPageIndex = value;}
		get { return previousPageIndex;}
	}

	private bool m_SoundFlag = true;
	public bool SoundFlag {
		set {
			PlayerPrefs.SetInt(Constant.PLAYER_PREF_SOUND, value ? 1 : 0);
			//Debug.Log("?: " + value);
			m_SoundFlag = value ;
		}
		get { 
			if(!PlayerPrefs.HasKey(Constant.PLAYER_PREF_SOUND))
			{
				PlayerPrefs.SetInt(Constant.PLAYER_PREF_SOUND, 1);
				//Debug.Log("DDD");
			}
			//Debug.Log("SOUND: " + m_SoundFlag + " PREF: "+ PlayerPrefs.GetInt(Constant.PLAYER_PREF_SOUND));
			return m_SoundFlag && (PlayerPrefs.GetInt(Constant.PLAYER_PREF_SOUND) == 1);
		}
	}
	
	private bool m_PushFlag = true;
	public bool PushFlag {
		set { m_PushFlag = value ;}
		get { return m_PushFlag;}
	}

	private bool _vibrateFlag = true;
	public bool VibrateFlag {
		set { _vibrateFlag = value ;}
		get { return _vibrateFlag;}
	}
	
	private string _languageCode ;
	public string LanguageCode {
		set { _languageCode = value ;}
		get { return _languageCode;}
	}

	//-------------------------------------------------------
	public struct UserDataStruct {

		private bool m_SoundFlag;
		public bool SoundFlag {
			set { m_SoundFlag = value ;}
			get { return m_SoundFlag;}
		}
		
		private bool m_PushFlag;
		public bool PushFlag {
			set { m_PushFlag = value ;}
			get { return m_PushFlag;}
		}
		
		private bool _vibrateFlag ;
		public bool VibrateFlag {
			set { _vibrateFlag = value ;}
			get { return _vibrateFlag;}
		}
		public List<AchievementData> _achievementDataList;
		public List<UserShipData> m_UserShipDataList;
		public List<UserSubShipData> m_UserSubShipDataList;
		public List<UserStageData> m_UserStageDataList;
		public List<GameCharacter> _characterList ;
		public List<GameItem> _gameItemList ;
		
		public GameMissionData _gameMissionGrade1Data ;
		public GameMissionData _gameMissionGrade2Data ;
		public GameMissionData _gameMissionGrade3Data ;

		
		// Base Info
		private string _versionInfo ;
		public int VersionInfo {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_versionInfo = encryptString ;
			}
			get {
				if(_versionInfo == null || _versionInfo.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_versionInfo,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		
		//Game Setting
		private string _userNickName ;
		public string UserNickName {
			set { _userNickName = value ;}
			get { return _userNickName;}
		}
		
		
		// Torpedo Data..
		private string _torpedoCount ;
		public int TorpedoCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_torpedoCount = encryptString ;
			}
			get {
				if(_torpedoCount == null || _torpedoCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_torpedoCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _torpedoRechargeNextTime ;
		public int TorpedoRechargeNextTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_torpedoRechargeNextTime = encryptString ;
			}
			get {
				if(_torpedoRechargeNextTime == null || _torpedoRechargeNextTime.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_torpedoRechargeNextTime,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		
		
		//	user data
		private string _userLevel ;
		public int UserLevel {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_userLevel = encryptString ;
			}
			get { 
				if(_userLevel == null || _userLevel.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_userLevel,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _gameJewel ;
		public int GameJewel {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gameJewel = encryptString ;
			}
			get {
				if(_gameJewel == null || _gameJewel.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_gameJewel,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _gameCoin ;
		public int GameCoin {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gameCoin = encryptString ;
			}
			get {
				if(_gameCoin == null || _gameCoin.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_gameCoin,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _guestTorpedo ;
		public int GuestTorpedo {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_guestTorpedo = encryptString ;
			}
			get {
				if(_guestTorpedo == null || _guestTorpedo.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_guestTorpedo,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				//return 10;
				return decryptInt;
			}
		}

		private string m_TutorialFlagV119 ;
		public bool TutorialFlagV119 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TutorialFlagV119 = encryptString ;
			}
			get { 
				if(m_TutorialFlagV119 == null || m_TutorialFlagV119.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(m_TutorialFlagV119,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}

		private string m_TutorialFlag ;
		public bool TutorialFlag {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TutorialFlag = encryptString ;
			}
			get { 
				if(m_TutorialFlag == null || m_TutorialFlag.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(m_TutorialFlag,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}

		private string m_TutorialChar ;
		public bool TutorialChar {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TutorialChar = encryptString ;
			}
			get { 
				if(m_TutorialChar == null || m_TutorialChar.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(m_TutorialChar,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
		
		private string m_TutorialItem ;
		public bool TutorialItem {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TutorialItem = encryptString ;
			}
			get { 
				if(m_TutorialItem == null || m_TutorialItem.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(m_TutorialItem,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}

		private string _firstInAppPurchaseFlag ; //Connect
		public int FirstInAppPurchaseFlag {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_firstInAppPurchaseFlag = encryptString ;
			}
			get {
				if(_firstInAppPurchaseFlag == null || _firstInAppPurchaseFlag.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_firstInAppPurchaseFlag,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				//return 10;
				return decryptInt;
			}
		}

		private string m_SubShipEquipAvailableSlotCount ; //Connect
		public int SubShipEquipAvailableSlotCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_SubShipEquipAvailableSlotCount = encryptString ;
			}
			get {
				if(m_SubShipEquipAvailableSlotCount == null || m_SubShipEquipAvailableSlotCount.Equals("")){
					return 1;	
				}
				string decryptString = LoadingWindows.NextD(m_SubShipEquipAvailableSlotCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				//return 10;
				return decryptInt;
			}
		}

		private string _luckyCoupon ;
		public int LuckyCoupon {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_luckyCoupon = encryptString ;
			}
			get {
				if(_luckyCoupon == null || _luckyCoupon.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_luckyCoupon,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				//return 0;
				return decryptInt;
			}
		}

		private string m_GamePlayCount ;
		public int GamePlayCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayCount = encryptString ;
			}
			get {
				if(m_GamePlayCount == null || m_GamePlayCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _gameClearCount ;
		public int GameClearCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gameClearCount = encryptString ;
			}
			get {
				if(_gameClearCount == null || _gameClearCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_gameClearCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _friendMessageSent ;
		public int FriendMessageSent {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_friendMessageSent = encryptString ;
			}
			get {
				if(_friendMessageSent == null || _friendMessageSent.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_friendMessageSent,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _maxBossClear ;
		public int MaxBossClear {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_maxBossClear = encryptString ;
			}
			get {
				if(_maxBossClear == null || _maxBossClear.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_maxBossClear,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		//-- User Record
		private string _userBestDistance ;
		public int UserBestDistance {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_userBestDistance = encryptString ;
			}
			get { 
				if(_userBestDistance == null || _userBestDistance.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_userBestDistance,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _userBestScore ;
		public int UserBestScore {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_userBestScore = encryptString ;
			}
			get { 
				if(_userBestScore == null || _userBestScore.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_userBestScore,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _userPlayCount ;
		public int UserPlayCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_userPlayCount = encryptString ;
			}
			get { 
				if(_userPlayCount == null || _userPlayCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_userPlayCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _userPlayTime ;
		public float UserPlayTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_userPlayTime = encryptString ;
			}
			get { 
				if(_userPlayTime == null || _userPlayTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_userPlayTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _allKillCount ;
		public int AllKillCount {
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
		
		private string _bossKillCount ;
		public int BossKillCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossKillCount = encryptString ;
			}
			get { 
				if(_bossKillCount == null || _bossKillCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossKillCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _enemyKillCount ;
		public int EnemyKillCount {
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
		//
		// 체험전이벤트 수정부분 - 시작 (14.03.10 by 최원석)
		private string _experienceIndex;
		public int ExperienceIndex {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_experienceIndex = encryptString ;
			}
			get {
				if(_experienceIndex == null || _experienceIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_experienceIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		// 체험전이벤트 수정부분 - 끝

		private string _pet2Open;
		public int Pet2Open {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_pet2Open = encryptString ;
			}
			get { 
				if(_pet2Open == null || _pet2Open.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_pet2Open,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _petGachaLowGradeConsePicked;
		public int PetGachaLowGradeConsePicked {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_petGachaLowGradeConsePicked = encryptString ;
			}
			get { 
				if(_petGachaLowGradeConsePicked == null || _petGachaLowGradeConsePicked.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_petGachaLowGradeConsePicked,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _petGachaOutcome1;
		public int PetGachaOutcome1 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_petGachaOutcome1 = encryptString ;
			}
			get { 
				if(_petGachaOutcome1 == null || _petGachaOutcome1.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_petGachaOutcome1,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _petGachaOutcome2;
		public int PetGachaOutcome2 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_petGachaOutcome2 = encryptString ;
			}
			get { 
				if(_petGachaOutcome2 == null || _petGachaOutcome2.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_petGachaOutcome2,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _petGachaOutcome3;
		public int PetGachaOutcome3 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_petGachaOutcome3 = encryptString ;
			}
			get { 
				if(_petGachaOutcome3 == null || _petGachaOutcome3.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_petGachaOutcome3,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _tutorialRewarded;
		public int TutorialRewarded {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_tutorialRewarded = encryptString ;
			}
			get { 
				if(_tutorialRewarded == null || _tutorialRewarded.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_tutorialRewarded,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		// 개인정보동의 수정 (by 최원석 14.04.22) -------- Start.
		private string m_strUserProfileBlock;
		public int UserProfileBlock {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_strUserProfileBlock = encryptString ;
			}
			get {
				if(m_strUserProfileBlock == null || m_strUserProfileBlock.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_strUserProfileBlock,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		// 개인정보동의 수정 (by 최원석 14.04.22) -------- End.

		// 초대보상 수정부분 (14.04.17 by 최원석) - Start
		private string m_strInviteFriend_Num;
		public int InviteFriend_Num {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_strInviteFriend_Num = encryptString ;
			}
			get {
				if(m_strInviteFriend_Num == null || m_strInviteFriend_Num.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_strInviteFriend_Num,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		// 초대보상 수정부분 (14.04.17 by 최원석) - End

		private string m_UpdateSequence ;
		public int UpdateSequence {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_UpdateSequence = encryptString ;
			}
			get {
				if(m_UpdateSequence == null || m_UpdateSequence.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_UpdateSequence,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
	} ;
	
	
	
	// Base Info
	private string _versionInfo ;
	public int VersionInfo {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_versionInfo = encryptString ;
		}
		get {
			if(_versionInfo == null || _versionInfo.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_versionInfo,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	//Game Setting
	private string _userNickName ;
	public string UserNickName {
		set { _userNickName = value ;}
		get { return _userNickName;}
	}
	
	public struct AchievementData {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _achieveType ;
		public int AchieveType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_achieveType = encryptString ;
			}
			get { 
				if(_achieveType == null || _achieveType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_achieveType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _curValue ;
		public int CurValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_curValue = encryptString ;
			}
			get { 
				if(_curValue == null || _curValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_curValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _isClear ;
		public bool IsClear {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isClear = encryptString ;
			}
			get { 
				if(_isClear == null || _isClear.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isClear,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
	} ;

	///
	public struct GameSubmarine {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isPurchase ;
		public bool IsPurchase {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isPurchase = encryptString ;
			}
			get { 
				if(_isPurchase == null || _isPurchase.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isPurchase,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
		
		private string _isSelect ;
		public bool IsSelect {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isSelect = encryptString ;
			}
			get { 
				if(_isSelect == null || _isSelect.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isSelect,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
		
		private string _bulletLevel ; //1 ~30 (== Bullet Upgrade Grade!!)
		public int BulletLevel {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletLevel = encryptString ;
			}
			get {
				if(_bulletLevel == null || _bulletLevel.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletLevel,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
				//return 1;
			}
		}

		private string _energyLevel ; //1 ~30 (== Bullet Upgrade Grade!!)
		public int EnergyLevel {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_energyLevel = encryptString ;
			}
			get {
				if(_energyLevel == null || _energyLevel.Equals("")){
					return 1 ;	
				}
				string decryptString = LoadingWindows.NextD(_energyLevel,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
				//return 1;
			}
		}

		public int Level {
			get { 
				 int _level = 1 ;
				
				if (BulletLevel > 20) {
					_level = 3;
				}else if (BulletLevel > 10) {
					_level = 2;
				}else {
					_level = 1;
				}
				
				return _level ; 
			}
		}
		
	} ;
	
	

	public struct GamePet {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
	
		/// <summary>
		/// 0 - not equip
		/// 1 - pet1 equip
		/// 2 - pet2 equip
		/// </summary>
		private string _isSelect ;
		public int IsSelect {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isSelect = encryptString ;
			}
			get {
				if(_isSelect == null || _isSelect.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_isSelect,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _level ;
		public int Level {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_level = encryptString ;
			}
			get {
				if(_level == null || _level.Equals("")){
					return 1;	
				}
				string decryptString = LoadingWindows.NextD(_level,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
	} ;

	public struct GameSubweapon {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isPurchase ;
		public bool IsPurchase {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isPurchase = encryptString ;
			}
			get { 
				if(_isPurchase == null || _isPurchase.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isPurchase,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
		
		private string _isSelect ;
		public bool IsSelect {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isSelect = encryptString ;
			}
			get { 
				if(_isSelect == null || _isSelect.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isSelect,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
		
	} ;
	
	
	public struct GameSubweaponSlot {
		private string _slotNumber ;
		public int SlotNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_slotNumber = encryptString ;
			}
			get {
				if(_slotNumber == null || _slotNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_slotNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _subweaponIndexNumber ;
		public int SubweaponIndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_subweaponIndexNumber = encryptString ;
			}
			get {
				if(_subweaponIndexNumber == null || _subweaponIndexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_subweaponIndexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isPurchase ;
		public bool IsPurchase {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isPurchase = encryptString ;
			}
			get { 
				if(_isPurchase == null || _isPurchase.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isPurchase,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
	} ;
	
	
	public struct GameItem {
		private string _itemType ;
		public int ItemType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_itemType = encryptString ;
			}
			get {
				if(_itemType == null || _itemType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_itemType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _itemCount ;
		public int ItemCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_itemCount = encryptString ;
			}
			get {
				if(_itemCount == null || _itemCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_itemCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
	} ;
	
	
	public struct GameMissionData {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _missionType ;
		public int MissionType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missionType = encryptString ;
			}
			get {
				if(_missionType == null || _missionType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_missionType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _gradeInfo ;
		public int GradeInfo {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gradeInfo = encryptString ;
			}
			get {
				if(_gradeInfo == null || _gradeInfo.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_gradeInfo,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _missionCondition ;
		public int MissionCondition {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missionCondition = encryptString ;
			}
			get {
				if(_missionCondition == null || _missionCondition.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_missionCondition,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _cumulativeNumber ;
		public int CumulativeNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_cumulativeNumber = encryptString ;
			}
			get {
				if(_cumulativeNumber == null || _cumulativeNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_cumulativeNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isAttain ; // 
		public bool IsAttain {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isAttain = encryptString ;
			}
			get { 
				if(_isAttain == null || _isAttain.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isAttain,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}
		
	} ;
	
	private GameMissionData _gameMissionGrade1Data ;
	private GameMissionData _gameMissionGrade2Data ;
	private GameMissionData _gameMissionGrade3Data ;

	//	user data
	private string _userLevel ;
	public int UserLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_userLevel = encryptString ;
		}
		get { 
			if(_userLevel == null || _userLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_userLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	private string _gameJewel ;
	private string _gameCoin ;
	public int GameJewel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameJewel = encryptString ;
			_shopDisplayGameJewel = encryptString;
		}
		get {
			if(_gameJewel == null || _gameJewel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameJewel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	public int GameCoin {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameCoin = encryptString ;
			_shopDisplayGameCoin = encryptString;
		}
		get {
			if(_gameCoin == null || _gameCoin.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_gameCoin,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	
	private string _shopDisplayGameCoin ;
	public int ShopDisplayGameCoin {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_shopDisplayGameCoin = encryptString ;
		}
		get {
			if(_shopDisplayGameCoin == null || _shopDisplayGameCoin.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_shopDisplayGameCoin,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}	

	private string _shopDisplayGameJewel ;
	public int ShopDisplayGameJewel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_shopDisplayGameJewel = encryptString ;
		}
		get {
			if(_shopDisplayGameJewel == null || _shopDisplayGameJewel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_shopDisplayGameJewel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	//-- User Record
	private string _userBestDistance ;
	public int UserBestDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_userBestDistance = encryptString ;
		}
		get { 
			if(_userBestDistance == null || _userBestDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_userBestDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _userBestScore ;
	public int UserBestScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_userBestScore = encryptString ;
		}
		get { 
			if(_userBestScore == null || _userBestScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_userBestScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _userPlayCount ;
	public int UserPlayCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_userPlayCount = encryptString ;
		}
		get { 
			if(_userPlayCount == null || _userPlayCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_userPlayCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _userPlayTime ;
	public float UserPlayTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_userPlayTime = encryptString ;
		}
		get { 
			if(_userPlayTime == null || _userPlayTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_userPlayTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string _allKillCount ;
	public int AllKillCount {
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
	
	private string _bossKillCount ;
	public int BossKillCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bossKillCount = encryptString ;
		}
		get { 
			if(_bossKillCount == null || _bossKillCount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_bossKillCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _enemyKillCount ;
	public int EnemyKillCount {
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
	//
	// 체험전이벤트 수정부분 - 시작 (14.03.10 by 최원석)
	private string _experienceIndex;
	public int ExperienceIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_experienceIndex = encryptString ;
		}
		get {
			if(_experienceIndex == null || _experienceIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_experienceIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	// 체험전이벤트 수정부분 - 끝
	private string _pet2Open;
	public int Pet2Open {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_pet2Open = encryptString ;
		}
		get { 
			if(_pet2Open == null || _pet2Open.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_pet2Open,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _petGachaLowGradeConsePicked;
	public int PetGachaLowGradeConsePicked {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_petGachaLowGradeConsePicked = encryptString ;
		}
		get { 
			if(_petGachaLowGradeConsePicked == null || _petGachaLowGradeConsePicked.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_petGachaLowGradeConsePicked,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _petGachaOutcome1;
	public int PetGachaOutcome1 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_petGachaOutcome1 = encryptString ;
		}
		get { 
			if(_petGachaOutcome1 == null || _petGachaOutcome1.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_petGachaOutcome1,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _petGachaOutcome2;
	public int PetGachaOutcome2 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_petGachaOutcome2 = encryptString ;
		}
		get { 
			if(_petGachaOutcome2 == null || _petGachaOutcome2.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_petGachaOutcome2,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _petGachaOutcome3;
	public int PetGachaOutcome3 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_petGachaOutcome3 = encryptString ;
		}
		get { 
			if(_petGachaOutcome3 == null || _petGachaOutcome3.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_petGachaOutcome3,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _tutorialRewarded;
	public int TutorialRewarded {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_tutorialRewarded = encryptString ;
		}
		get { 
			if(_tutorialRewarded == null || _tutorialRewarded.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_tutorialRewarded,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	// 개인정보동의 수정 (by 최원석 14.04.22) -------- Start.
	private string m_strUserProfileBlock;
	public int UserProfileBlock {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_strUserProfileBlock = encryptString ;
		}
		get {
			if(m_strUserProfileBlock == null || m_strUserProfileBlock.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_strUserProfileBlock,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	// 개인정보동의 수정 (by 최원석 14.04.22) -------- End.

	// 초대보상 수정부분 (14.04.17 by 최원석) - Start
	private string m_strInviteFriend_Num;
	public int InviteFriend_Num {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_strInviteFriend_Num = encryptString ;
		}
		get {
			if(m_strInviteFriend_Num == null || m_strInviteFriend_Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_strInviteFriend_Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	// 초대보상 수정부분 (14.04.17 by 최원석) - End

	// In the game...
	/*
	private bool _haveItemStartBooster ;
	private bool _haveItemShield ;
	private bool _haveItemLastBooster ;
	private bool _haveItemRevive ;
	
	private bool _haveItemBrake ;
	private bool _haveItemBoom ;
	*/
	
	private string _haveItemStartBooster ;
	private string _haveItemShield ;
	private string _haveItemLastBooster ;
	private string _haveItemRevive ;
	
	private string _haveItemBrake ;
	private string _haveItemBoom ;
	private string _haveItemLaser;
	private string _haveItemMissile;

	public bool ItemStartBooster {
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
	public bool ItemShield {
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
	public bool ItemLastBooster {
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
	public bool ItemRevive {
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
	public bool ItemBrake {
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
	public bool ItemBoom {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemBoom = encryptString ;
		}
		get { 
			if(_haveItemBoom == null || _haveItemBoom.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemBoom,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	public bool ItemLaser {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemLaser = encryptString ;
		}
		get { 
			if(_haveItemLaser == null || _haveItemLaser.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemLaser,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	public bool ItemMissile {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_haveItemMissile = encryptString ;
		}
		get { 
			if(_haveItemMissile == null || _haveItemMissile.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_haveItemMissile,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_haveItemShout;
	public bool ItemShout {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_haveItemShout = encryptString ;
		}
		get { 
			if(m_haveItemShout == null || m_haveItemShout.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_haveItemShout,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_HaveItemSingijeon;
	public bool ItemSingijeon {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveItemSingijeon = encryptString ;
		}
		get { 
			if(m_HaveItemSingijeon == null || m_HaveItemSingijeon.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveItemSingijeon,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_HaveItemPowerUp;
	public bool HaveItemPowerUp {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveItemPowerUp = encryptString ;
		}
		get { 
			if(m_HaveItemPowerUp == null || m_HaveItemPowerUp.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveItemPowerUp,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_HaveItemHealthUp;
	public bool HaveItemHealthUp {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HaveItemHealthUp = encryptString ;
		}
		get { 
			if(m_HaveItemHealthUp == null || m_HaveItemHealthUp.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_HaveItemHealthUp,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	//
	
	
	private List<AchievementData> _achievementDataList;
	public List<UserShipData> m_UserShipDataList;
	public List<UserSubShipData> m_UserSubShipDataList;
	public List<UserStageData> m_UserStageDataList;
	private List<GameCharacter> _characterList ;
	private List<GameItem> _gameItemList ;

	private string m_UpdateSequence ;
	public int UpdateSequence {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_UpdateSequence = encryptString ;
		}
		get {
			if(m_UpdateSequence == null || m_UpdateSequence.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_UpdateSequence,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	//-----------------------------------
	private void Awake(){
		
		//
		_chocolateRewardMessageQueue = new Queue<RewardChocolateData>() ;
		//
		
		_achievementDataList = new List<AchievementData>();
		m_UserShipDataList = new List<UserShipData>();
		m_UserSubShipDataList = new List<UserSubShipData>();
		m_UserStageDataList = new List<UserStageData>();
		_characterList = new List<GameCharacter>() ;
		_gameItemList = new List<GameItem>() ;
		
		
		_gameMissionGrade1Data = new GameMissionData() ;
		_gameMissionGrade2Data = new GameMissionData() ;
		_gameMissionGrade3Data = new GameMissionData() ;

		Initialize() ;
		
	}
	
	private void Initialize() {
		
		//PlayerPrefs.SetString("NoticeNubmer", "") ;
		//PlayerPrefs.SetString("NoticeCheck", "") ;
		//PlayerPrefs.SetString("EventNubmer", "") ;
		//PlayerPrefs.SetString("EventCheck", "") ;
		
		
		//AppVersionInfo = "1.0.0" ; // Imsy..
		//InitializeSetAppVersionInfo() ;

		//SetTutorlalState(false) ;


		InitializeSetNoticeNumberInfo() ;
		InitializeSetEventNumberInfo() ;
		
		//
		InitializeSetLangueCode() ;
		//SoundFlag = true;
		//VibrateFlag = true;
		//PushFlag = true;
		
		/*
		VersionInfo = 1 ;
		
		// Init Setting GameSubmarine
		SetGameSubmarine(0,true,true,1) ;
		SetGameSubmarine(1,false,false,1) ;
		SetGameSubmarine(2,false,false,1) ;
		SetGameSubmarine(3,false,false,1) ;
		
		SetSelectGameSubmarine(0) ;
		
		// Init Setting GameCharacter
		SetGameCharacter(1,true,true) ;
		SetGameCharacter(2,false,false) ;
		SetGameCharacter(3,false,false) ;
		SetGameCharacter(4,false,false) ;
		SetGameCharacter(5,false,false) ;
		
		SetSelectGameCharacter(1) ;
		
		
		
		// Init Setting GameSubweapon
		SetGameSubweapon(1, false, false) ;
		SetGameSubweapon(2, false, false) ;
		SetGameSubweapon(3, false, false) ;
		SetGameSubweapon(4, false, false) ;
		SetGameSubweapon(5, false, false) ;
		SetGameSubweapon(6, false, false) ;
		SetGameSubweapon(7, false, false) ;
		SetGameSubweapon(8, false, false) ;
		SetGameSubweapon(9, false, false) ;
		SetGameSubweapon(10, false, false) ;
		SetGameSubweapon(11, false, false) ;
		SetGameSubweapon(12, false, false) ;
		SetGameSubweapon(13, false, false) ;
		SetGameSubweapon(14, false, false) ;
		SetGameSubweapon(15, false, false) ;
		SetGameSubweapon(16, false, false) ;
		SetGameSubweapon(17, false, false) ;
		SetGameSubweapon(18, false, false) ;
		SetGameSubweapon(19, false, false) ;
		SetGameSubweapon(20, false, false) ;
		SetGameSubweapon(21, false, false) ;
		SetGameSubweapon(22, false, false) ;
		SetGameSubweapon(23, false, false) ;
		SetGameSubweapon(24, false, false) ;
		SetGameSubweapon(25, false, false) ;
		SetGameSubweapon(26, false, false) ;
		SetGameSubweapon(27, false, false) ;
		SetGameSubweapon(28, false, false) ;
		SetGameSubweapon(29, false, false) ;
		SetGameSubweapon(30, false, false) ;
		SetGameSubweapon(31, false, false) ;
		SetGameSubweapon(32, false, false) ;
		SetGameSubweapon(33, false, false) ;
		SetGameSubweapon(34, false, false) ;
		SetGameSubweapon(35, false, false) ;
		
		// Init Setting GameSubweaponSlot
		SetGameSubweaponSlot(1,0,true) ;
		SetGameSubweaponSlot(2,0,false) ;
	
		
		// Init Setting GameItem
		SetGameItem(1, 0) ;
		SetGameItem(2, 0) ;
		SetGameItem(3, 0) ;
		SetGameItem(4, 0) ;
		SetGameItem(5, 0) ;
		SetGameItem(6, 0) ;
		
		
		
		// Init GameMissionData
		SetGameMissionGrade1Data(101, 11, 1, 1000, 0, false) ;
		SetGameMissionGrade2Data(251, 22, 4, 5000, 0, false) ;
		SetGameMissionGrade3Data(305, 31, 5, 250, 0, false) ;
		
		
		
		// Init User Data
		UserLevel = 1 ;
		
		
		SetPurchaseGold(1000) ;
		SetPurchaseJewel(10) ;
		
		
		UserBestScore = 0 ;
		UserBestDistance = 0 ;
		*/
		
	}
	
	public void ClearAllList(){

		_achievementDataList.Clear();
		m_UserShipDataList.Clear();
		m_UserSubShipDataList.Clear();
		m_UserStageDataList.Clear();
		_characterList.Clear() ;
		_gameItemList.Clear() ;
		
	}
	
	
	
	//---------
	public bool GetTutorialState(){
		
		bool _isTutorialDone = false;
		
		string getTutorialState = PlayerPrefs.GetString("TutorialState") ;
		
		if(getTutorialState == null || getTutorialState.Equals("")){
			
			_isTutorialDone = false;
			
		}else{
			
			if(getTutorialState.Equals("True")){
				_isTutorialDone = true;
			}else{
				_isTutorialDone = false;
			}
			
		}
		
		return _isTutorialDone ;
		
	}
	
	public void SetTutorlalState(bool tutorialState){
		if(tutorialState){
			PlayerPrefs.SetString("TutorialState", "True") ;	
		}else{
			PlayerPrefs.SetString("TutorialState", "False") ;
		}
	}

	public bool GetTutorialSkipState()
	{
		bool _tutorialskip = false;

		string getTutorialState = PlayerPrefs.GetString("TutorialSkipState") ;
		
		if(getTutorialState == null || getTutorialState.Equals("")){
			
			_tutorialskip = false ;
			
		}else{
			
			if(getTutorialState.Equals("True")){
				_tutorialskip = true ;
			}else{
				_tutorialskip = false ;
			}
			
		}
		
		return _tutorialskip ;
	}

	public void SetTutorialSkipState(bool _state)
	{
		if(_state){
			PlayerPrefs.SetString("TutorialSkipState", "True") ;	
		}else{
			PlayerPrefs.SetString("TutorialSkipState", "False") ;
		}
	}
	//---------
	
	
	
	public void SetMessageCount(string jsonString){
		
		if(jsonString == null || jsonString.Equals("")) return ;
		
		JSONNode root = JSON.Parse(jsonString);
		
		string messageCountString = root["MessageCount"];
		InboxMessageCount = int.Parse(messageCountString);
	}

	public void SetMessageNewCount(string jsonString){
		//Debug.Log("SET MESSAGE NEW COUNT CALLED");
		if(jsonString == null || jsonString.Equals("")) return ;
		
		JSONNode root = JSON.Parse(jsonString);

		string messageCountNew = root["MessageNewCount"];
		InboxMessageCountNew = int.Parse(messageCountNew);
		//Debug.Log("INBOXMESAGE NEW COUNT: " + InboxMessageCountNew);
	}
	
	//
	public void SetServerTime(string jsonString){
		
		if(jsonString == null || jsonString.Equals("")) return ;
		
		JSONNode root = JSON.Parse(jsonString);
		
		string receiveServerTime = root["ServerTime"] ;
		int serverTime = int.Parse(receiveServerTime) ;
		
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int timestamp = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
		
		//System.DateTime epochStart = new System.DateTime(1970, 1, 1, 9, 0, 0);
		//int timestamp = (int)(System.DateTime.Now - epochStart).TotalSeconds;
		
		ServerTimeToLocalTimeGap = serverTime - timestamp ;
		
		
	}
	
	public int GetSyncServerTime(){
		
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
		int timestamp = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;
		
		int syncRealServerTime = timestamp +  ServerTimeToLocalTimeGap ;

		//Debug.Log("TimeStamp: " + timestamp);
		//Debug.Log("ServerTimeToLocalTimeGap: " + ServerTimeToLocalTimeGap);
		return syncRealServerTime ;
		
	}
	//
	




	///
	public void SetChocolateRewardMessageQueue(string jsonString){
		
		if(jsonString == null || jsonString.Equals("")) return ;
		
		JSONNode root = JSON.Parse(jsonString);
		for( int i=0; i<root["Reward"].Count; ++i ) {

			RewardChocolateData rewardChocolateData = new RewardChocolateData() ;

			JSONNode data = root["Reward"][i];

			rewardChocolateData.ChocolateNum = data["chocolate_num"].AsInt ;
			rewardChocolateData.RewardMessage = data["reward_message"] ;

			_chocolateRewardMessageQueue.Enqueue(rewardChocolateData) ;
		}
		
	}
	
	public RewardChocolateData GetChocolateRewardMessageQueue(){

		RewardChocolateData rewardChocolateData = _chocolateRewardMessageQueue.Dequeue() ;
		
		return rewardChocolateData ;
	}
	
	public int GetChocolateRewardMessageQueueCount(){
		return _chocolateRewardMessageQueue.Count ;
	}
	
	public void ClearChocolateRewardMessageQueue(){
		_chocolateRewardMessageQueue.Clear() ;
	}
	///






	//-----------
	public bool CheckAppVersionInfo(string appVersion){
		int result = Constant.AppVersionInfo.CompareTo(appVersion);
		if(result == 1 || result == 0){
			return true ;	
		}else{
			return false ;
		}
	}
	
	
	
	//
	private void InitializeSetNoticeNumberInfo(){
		
		string getNoticeNubmerInfo = PlayerPrefs.GetString("NoticeNubmer") ;
		
		if(getNoticeNubmerInfo == null || getNoticeNubmerInfo.Equals("")){
			SaveNoticeNumberInfo("0") ;
		}
		
	}
	
	public bool CompareNoticeNumberInfo(string noticeNumberInfo){
		
		string getNoticeNubmerInfo = PlayerPrefs.GetString("NoticeNubmer") ;
		
		if(getNoticeNubmerInfo.Equals(noticeNumberInfo)){
			return true ;
		}else{
			return false ;
		}
	}
	
	public void SaveNoticeNumberInfo(string noticeNumberInfo){
		PlayerPrefs.SetString("NoticeNubmer", noticeNumberInfo) ;
	}
	
	
	///
	private void InitializeSetEventNumberInfo(){
		
		string getEventNubmerInfo = PlayerPrefs.GetString("EventNubmer") ;
		
		if(getEventNubmerInfo == null || getEventNubmerInfo.Equals("")){
			SaveEventNumberInfo("0") ;
		}
		
	}
	
	public bool CompareEventNumberInfo(string eventNumberInfo){
		
		string getEventNubmerInfo = PlayerPrefs.GetString("EventNubmer") ;
		
		if(getEventNubmerInfo.Equals(eventNumberInfo)){
			return true ;
		}else{
			return false ;
		}
	}
	
	public void SaveEventNumberInfo(string eventNumberInfo){
		PlayerPrefs.SetString("EventNubmer", eventNumberInfo) ;
	}

	public void SaveFriendMessageCheckTime(){
		PlayerPrefs.SetInt("FriendMessageCheckTime", GetSyncServerTime()) ;
	}

	public int GetFriendMessageCheckTime()
	{
		return PlayerPrefs.GetInt("FriendMessageCheckTime");
	}

	//-----------------------------------
	private void InitializeSetLangueCode(){
		
		// Afreeca version is Only Korean...
		LanguageCode = "Ko" ;

	}
	
	public void SaveLangueCode(string langueCode){
		
		PlayerPrefs.SetString("LangueCode", langueCode) ;
		
		LanguageCode = langueCode ;
		
	}

	private void InitializeSetVibrate(){
		
		string getVibrate = PlayerPrefs.GetString("Vibrate") ;
		
		if(getVibrate == null || getVibrate.Equals("")){
			
			SaveVibrate(true) ; // 0~3
			
		}else{
			
			bool vibflag = false;
			//Debug.Log(getVibrate);
			if(getVibrate == "True")
			{
				vibflag = true ;
			}else
			{
				vibflag = false ;
			}
			
			VibrateFlag = vibflag ;
			
		}
		
	}
	
	public void SaveVibrate(bool _flag){		
		PlayerPrefs.SetString("Vibrate", _flag.ToString()) ;				
		VibrateFlag = _flag ;		
	}

	public bool GetVibrateFlag(){
		return VibrateFlag;
	}

	//ahcievement
	public AchievementData GetAchievementData(int _index)
	{
		if(_achievementDataList == null)
		{
			_achievementDataList = new List<AchievementData>();
		}

		for(int i = 0; i < _achievementDataList.Count; i++)
		{
			if(_achievementDataList[i].IndexNumber == _index)
			{
				return _achievementDataList[i];
			}
		}

		return new AchievementData();
	}

	public void UpdateAchievementData(int _type, int _value)
	{
		//check achievedata from balancelist
		for(int i = 0; i < Managers.GameBalanceData._achievementInfoDataList.Count; i++)
		{
			GameBalanceDataManager.AchievementInfoData achievedata = Managers.GameBalanceData._achievementInfoDataList[i];
			if(achievedata.MissionType == _type)
			{
				CheckAchievementData(achievedata.IndexNumber, _type, _value);
			}
		}
	}

	public void CheckAchievementData(int _index, int _type, int _value)
	{
		bool found = false;
		int foundindex = 0;
		AchievementData achievedata = new AchievementData();
		for(int i = 0; i < _achievementDataList.Count; i++)
		{
			AchievementData data = _achievementDataList[i];
			if(data.IndexNumber == _index)
			{
				found = true;
				achievedata = data;
				foundindex = i;
				break;
			}
		}

		if(found)
		{
			achievedata.CurValue += _value;
		}else
		{
			//_achievementDataList[found
			achievedata.IndexNumber = _index;
			achievedata.AchieveType = _type;
			achievedata.CurValue += _value;
			achievedata.IsClear = false;
		}

		if(achievedata.AchieveType == 1)
		{
			GameBalanceDataManager.AchievementInfoData achieveinfo = Managers.GameBalanceData.GetAchievementInfoData(_index);
			if(MaxBossClear >= achieveinfo.RequireNumber)
			{
				achievedata.IsClear = true;
			}else
			{

			}
		}else
		{
			GameBalanceDataManager.AchievementInfoData achieveinfo = Managers.GameBalanceData.GetAchievementInfoData(_index);
			if(achievedata.CurValue > achieveinfo.RequireNumber)
			{
				achievedata.IsClear = true;
			}
		}

		if(found)
		{
			_achievementDataList[foundindex] = achievedata;
		}else
		{
			_achievementDataList.Add(achievedata);
		}
	}

	public void InitializeStageData()
	{
		m_UserStageDataList = new List<UserStageData>();
		UserStageData data = new UserStageData();
		data.IndexNumber = 1;
		data.IsOpen = true;
		data.IsClear = false;
		SetUserStageData(data);
	}

	public void SetUserStageData(UserStageData _data)
	{
		bool matched = false;
		for(int i = 0; i < m_UserStageDataList.Count; i++)
		{
			if(m_UserStageDataList[i].IndexNumber == _data.IndexNumber)
			{
				matched = true;
				m_UserStageDataList[i] = _data;
				break;
			}
		}
		if(!matched)
		{
			m_UserStageDataList.Add(_data);
		}
	}

	public void SetUserStageDataClear(int _index)
	{
		UserStageData curstagedata = GetUserStageData(_index);
		UserStageData nextuserstagedata = GetUserStageData(_index + 1);

		curstagedata.IsOpen = true;
		curstagedata.IsClear = true;

		nextuserstagedata.IsOpen = true;
		SetUserStageData(curstagedata);
		SetUserStageData(nextuserstagedata);
	}

	public int GetUserMaxClearStage()
	{
		int maxstageopenindex = 0;
		for(int i = 0; i < Managers.UserData.m_UserStageDataList.Count; i++)
		{
			UserStageData stagedata = Managers.UserData.m_UserStageDataList[i];
			if(stagedata.IsOpen)
			{
				if(stagedata.IndexNumber > maxstageopenindex)
				{
					maxstageopenindex = stagedata.IndexNumber;
				}
			}
		}
		return maxstageopenindex;
	}

	public UserStageData GetUserStageData(int _index)
	{
		if(m_UserStageDataList == null)
		{
			InitializeStageData();
		}
		UserStageData data = new UserStageData();
		for(int i = 0; i < m_UserStageDataList.Count; i++)
		{
			if(m_UserStageDataList[i].IndexNumber == _index)
			{
				data = m_UserStageDataList[i];
				if(_index == 1)
				{
					data.IsOpen = true;
				}

				if(Constant.VALTEST1)
				{
					data.IsOpen = true;
				}
				return data;
			}
		}

		data.IndexNumber = _index;
		data.IsOpen = false;
		data.IsClear = false;
		SetUserStageData(data);
		return data;
	}

	public void InitializeShipData()
	{
		m_UserShipDataList = new List<UserShipData>();
		UserShipData data = new UserShipData();
		data.IndexNumber = 1;
		data.IsSelect = true;
		data.IsPurchase = true;
		data.Level = 1;
		SetUserShipData(data);
	}

	public UserShipData GetCurrentUserShipData()
	{
		if(m_UserShipDataList == null)
		{
			InitializeShipData();
		}
		UserShipData data = new UserShipData();
		for(int i = 0; i < m_UserShipDataList.Count; i++)
		{
			if(m_UserShipDataList[i].IsSelect)
			{
				data = m_UserShipDataList[i];
				break;
			}
		}
		if(data.IsSelect == false)
		{
			InitializeShipData();
			data = GetCurrentUserShipData();
		}
		return data;
	}

	public void SetSelectedUserShipData(UserShipData _usershipdata)
	{
		UserShipData newcurrentusershipdata = _usershipdata;
		newcurrentusershipdata.IsSelect = true;

		UserShipData currentusershipdata = GetCurrentUserShipData();

		currentusershipdata.IsSelect = false;

		SetUserShipData(currentusershipdata);
		SetUserShipData(newcurrentusershipdata);
	}

	public void SetUserShipData(UserShipData _data)
	{
		bool matched = false;
		for(int i = 0; i < m_UserShipDataList.Count; i++)
		{
			if(m_UserShipDataList[i].IndexNumber == _data.IndexNumber)
			{
				matched = true;
				m_UserShipDataList[i] = _data;
				break;
			}
		}
		if(!matched)
		{
			m_UserShipDataList.Add(_data);
		}
	}

	public UserShipData GetUserShipData(int _index)
	{
		if(m_UserShipDataList == null)
		{
			InitializeShipData();
		}

		for(int i = 0; i < m_UserShipDataList.Count; i++)
		{
			UserShipData usershipdata = m_UserShipDataList[i];
			if(usershipdata.IndexNumber == _index)
			{
				if(usershipdata.IndexNumber == 4)
				{
					bool locked = false;
					if(!GetUserShipData(3).IsPurchase)
					{
						locked = true;
					}
					usershipdata.IsLocked = locked;
				}else if(usershipdata.IndexNumber == 3)
				{
					bool locked = false;
					if(!GetUserShipData(1).IsPurchase ||
					   !GetUserShipData(2).IsPurchase ||
					   !GetUserShipData(5).IsPurchase ||
					   !GetUserShipData(6).IsPurchase ||
					   !GetUserShipData(7).IsPurchase)
					{
						locked = true;
					}
					usershipdata.IsLocked = locked;
				}else if(usershipdata.IndexNumber == 8)
				{
					bool locked = false;
					if(!GetUserShipData(4).IsPurchase)
					{
						locked = true;
					}
					usershipdata.IsLocked = locked;
				}else
				{
					usershipdata.IsLocked = false;
				}
				SetUserShipData(usershipdata);
				return usershipdata;
			}
		}

		UserShipData data = new UserShipData();
		data.IndexNumber = _index;
		data.IsPurchase = false;
		data.IsSelect = false;
		data.Level = 1;
		SetUserShipData(data);
		return data;
	}

	public void InitializeSubShipData()
	{
		m_UserSubShipDataList = new List<UserSubShipData>();
		UserSubShipData data = new UserSubShipData();
		data.IndexNumber = 1;
		data.IsPurchase = true;
		data.IsSelect = 0;
		data.Level = 1;
		SetUserSubShipData(data);

		UserSubShipData data2 = new UserSubShipData();
		data2.IndexNumber = 2;
		data2.IsPurchase = true;
		data2.IsSelect = 0;
		data2.Level = 1;
		SetUserSubShipData(data2);

		UserSubShipData data3 = new UserSubShipData();
		data3.IndexNumber = 3;
		data3.IsPurchase = false;
		data3.IsSelect = 0;
		data3.Level = 1;
		SetUserSubShipData(data3);
	}

	public void CheckSubShip()
	{
		int max = Managers.GameBalanceData.GetGameCharacterInfoBalance(GetCurrentGameCharacter().IndexNumber).AvailableTacticSlot;
		for(int i = 0; i < m_UserSubShipDataList.Count; i++)
		{
			UserSubShipData data = m_UserSubShipDataList[i];
			if(data.IsSelect > max)
			{
				data.IsSelect = 0;
			}
			m_UserSubShipDataList[i] = data;
		}
	}

	public void SetUserSubShipData(UserSubShipData _data)
	{
		//Debug.Log("???? call set usersubship: " + _data.IndexNumber + " TOTAL: " + m_UserSubShipDataList.Count);
		bool matched = false;
		for(int i = 0; i < m_UserSubShipDataList.Count; i++)
		{
			if(m_UserSubShipDataList[i].IndexNumber == _data.IndexNumber)
			{
				matched = true;
				m_UserSubShipDataList[i] = _data;
				return;
			}
		}

		if(!matched)
		{
			//Debug.Log("????W");
			m_UserSubShipDataList.Add(_data);
		}
	}

	/// <summary>
	/// [return]
	/// 0 - no ship at that index
	/// [_equppos]
	/// ranges from 1 ~ 4
	/// </summary>
	public int GetEquipedSubShipIndex(int _equippos)
	{
		int subshipindex = 0;

		GameCharacter curcharacter = Managers.UserData.GetCurrentGameCharacter();
		if(Managers.GameBalanceData.GetGameCharacterInfoBalance(curcharacter.IndexNumber).AvailableTacticSlot < _equippos)
		{
			return 0;
		}
		
		for(int i = 0; i < m_UserSubShipDataList.Count; i++)
		{
			if(m_UserSubShipDataList[i].IsSelect == _equippos)
			{
				subshipindex = m_UserSubShipDataList[i].IndexNumber;
				break;
			}
		}

		return subshipindex;
	}

	public UserSubShipData GetUserSubShipData(int _index)
	{
		if(m_UserSubShipDataList == null)
		{
			InitializeSubShipData();
		}

		UserSubShipData data = new UserSubShipData();
		data.IndexNumber = _index;
		data.IsPurchase = false;
		data.IsSelect = 0;
		data.Level = 1;

		for(int i = 0; i < m_UserSubShipDataList.Count; i++)
		{
			if(m_UserSubShipDataList[i].IndexNumber == _index)
			{
				data = m_UserSubShipDataList[i];
				if(Constant.VALTEST1)
				{
					data.IsPurchase = true;
				}
				return data;
			}
		}

		SetUserSubShipData(data);
		if(Constant.VALTEST1)
		{
			data.IsPurchase = true;
		}
		return data;
	}

	
	// GameCharacter
	public GameCharacter GetCurrentGameCharacter(){
		
		GameCharacter selectGameCharacter = new GameCharacter() ;
		
		foreach(GameCharacter _gc in _characterList) {
			if(_gc.IsSelect){
				selectGameCharacter = _gc ;
				break ;
			}
		}
		
		return selectGameCharacter ;
	}
	
	public GameCharacter GetGameCharacter(int indexNumber){
		
		GameCharacter selectGameCharacter = new GameCharacter() ;
		
		foreach(GameCharacter _gc in _characterList) {
			if(_gc.IndexNumber == indexNumber){
				selectGameCharacter = _gc ;
				break ;
			}
		}

		if(selectGameCharacter.IndexNumber == 0)
		{
			selectGameCharacter.IndexNumber = indexNumber;
			selectGameCharacter.IsPurchase = false;
			selectGameCharacter.IsSelect = false;
			selectGameCharacter.SelectedTactic = 1;
			SetGameCharacter(selectGameCharacter);
		}
		return selectGameCharacter ;
	}
	
	public List<GameCharacter> GetGameCharacterList(){
		return _characterList ;
	}
	
	public void ClearGameCharacterList(){
		_characterList.Clear() ;
	}
	
	public void SetGameCharacter(GameCharacter gc){
		
		int searchIndex = -1 ;
		int parameterIndex = gc.IndexNumber ;
		
		
		for(int i = 0 ; i < _characterList.Count ; i++){
			GameCharacter _selectGameCharacter = _characterList[i] ;
			if(_selectGameCharacter.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_characterList.Add(gc) ;
		}else{
			_characterList[searchIndex] = gc ;
		}
		
	}
	
	public void SetGameCharacter(int indexNumber, bool isPurchase, bool isSelect){
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _characterList.Count ; i++){
			GameCharacter _selectGameCharacter = _characterList[i] ;
			if(_selectGameCharacter.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		GameCharacter _gc = new GameCharacter();
		_gc.IndexNumber = indexNumber ;
		_gc.IsPurchase = isPurchase ;
		_gc.IsSelect = isSelect ;
		
		if(searchIndex == -1){ //No Exist
			_characterList.Add(_gc) ;
		}else{
			_characterList[searchIndex] = _gc ;
		}
	}
	
	public bool SetSelectGameCharacter(int indexNumber){
		
		bool isSelectElementPurchase = false ;
		for(int i = 0 ; i < _characterList.Count ; i++){
			GameCharacter _selectGameCharacter = _characterList[i] ;
			if(_selectGameCharacter.IndexNumber == indexNumber){
				if(_selectGameCharacter.IsPurchase){
					isSelectElementPurchase = true ;
				}
				break ;
			}
		}
		
		if(!isSelectElementPurchase) return false ; //No Change
		
		for(int i = 0 ; i < _characterList.Count ; i++){
			GameCharacter _selectGameCharacter = _characterList[i] ;
			if(_selectGameCharacter.IndexNumber == indexNumber){
				_selectGameCharacter.IsSelect = true ;
			}else{
				_selectGameCharacter.IsSelect = false ;
			}
			_characterList[i] = _selectGameCharacter ;
		}
		return true ; // Change Done..
		
	}
	
	public int SetPurchaseGameCharacter(int indexNumber){ // Return 0 : Already purchased    , 1 : Purchase Success ,  99 : Not Search Index..
		
		int state = 99 ;
		
		for(int i = 0 ; i < _characterList.Count ; i++){
			GameCharacter _selectGameCharacter = _characterList[i] ;
			if(_selectGameCharacter.IndexNumber == indexNumber){
				
				if(_selectGameCharacter.IsPurchase){
					state = 0 ;
				}else{
					_selectGameCharacter.IsPurchase = true ;
					_characterList[i] = _selectGameCharacter ;
					state = 1 ;
				}
				break ;
			}
		}

		if(state == 99)
		{
			GameCharacter newchar = new GameCharacter();
			newchar.IndexNumber = indexNumber;
			newchar.IsPurchase = true;
			newchar.SelectedTactic = 1;
			SetGameCharacter(newchar);
			state = 1 ;
		}
		
		return state ;
		
	}

	//public int SetPurchaseGameSubweapon(int indexNumber){ // Return 0 : Already purchased    , 1 : Purchase Success ,  99 : Not Search Index..
	//	
	//	int state = 99 ;
	//	
	//	for(int i = 0 ; i < _subweaponList.Count ; i++){
	//		GameSubweapon _selectGameSubweapon = _subweaponList[i] ;
	//		if(_selectGameSubweapon.IndexNumber == indexNumber){
	//			
	//			if(_selectGameSubweapon.IsPurchase){
	//				state = 0 ;
	//			}else{
	//				_selectGameSubweapon.IsPurchase = true ;
	//				_subweaponList[i] = _selectGameSubweapon ;
	//				state = 1 ;
	//			}
	//			break ;
	//		}
	//	}
	//	
	//	return state ;
	//	
	//}
	//game pet end
		
	
	// GameItem
	public GameItem GetGameItem(int itemName){
		
		GameItem _selectGameItem = new GameItem();
		
		foreach(GameItem _gi in _gameItemList) {
			if(_gi.ItemType == itemName){
				_selectGameItem = _gi ;
				break ;
			}
		}

		if(_selectGameItem.ItemType == 0)
		{
			_selectGameItem.ItemType = itemName;
			_selectGameItem.ItemCount = 0;
			_gameItemList.Add(_selectGameItem);
		}

		return _selectGameItem ;
	}
	
	public int GetGameItemCount(int itemName){
		
		int currentGameItemCount = 0 ;
		
		foreach(GameItem _gi in _gameItemList) {
			if(_gi.ItemType == itemName){
				currentGameItemCount = _gi.ItemCount ;
				break ;
			}
		}

		return currentGameItemCount ;
	}
	
	public List<GameItem> GetGameItemList(){
		return _gameItemList ;
	}
	
	public void ClearGameGameItemList(){
		_gameItemList.Clear() ;
	}

	protected Dictionary<int, bool> m_ItemEquipDic = new Dictionary<int, bool>();
	public void ResetGameItemEquip()
	{
		//Debug.Log("KEYS: " + m_ItemEquipDic.Keys.Count);
		int[] keys = new int[m_ItemEquipDic.Keys.Count];
		m_ItemEquipDic.Keys.CopyTo(keys,
		                           0);
		foreach(int key in keys)
		{
			//Debug.Log("?:" + key);
			m_ItemEquipDic[key] = false;
		}
	}

	public void ToggleGameItemEquip(int _index)
	{
		if(m_ItemEquipDic.ContainsKey(_index))
		{
			//if(GetCountGameItem(_index) > 0)
			{
				m_ItemEquipDic[_index] = !m_ItemEquipDic[_index];
			}
			//else
			//{
			//	m_ItemEquipDic[_index] = false;
			//}
		}else
		{
			//if(GetCountGameItem(_index) > 0)
			{
				m_ItemEquipDic.Add(_index, true);
			}
			//else
			//{
			//	m_ItemEquipDic.Add(_index, false);
			//}
		}
	}

	public bool GetGameItemEquip(int _index)
	{
		if(m_ItemEquipDic.ContainsKey(_index))
		{
			return m_ItemEquipDic[_index];
		}else
		{
			m_ItemEquipDic.Add(_index, false);
			return false;
		}
	}

	public void SetGameItem(GameItem gi){
		Debug.Log("GI: " + gi.ItemType);
		int searchIndex = -1 ;
		int parameterIndex = gi.ItemType ;
		
		
		for(int i = 0 ; i < _gameItemList.Count ; i++){
			GameItem _selectGameItem = _gameItemList[i] ;
			if(_selectGameItem.ItemType == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameItemList.Add(gi) ;
		}else{
			_gameItemList[searchIndex] = gi ;
		}
		
	}
	
	public void SetGameItem(int itemName, int itemCount){
		//Debug.Log("GI: " + itemName + " ITEMCOUNT: " + itemCount);
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _gameItemList.Count ; i++){
			GameItem _selectGameItem = _gameItemList[i] ;
			if(_selectGameItem.ItemType == itemName){
				searchIndex = i ;
				break ;
			}
		}
		
		GameItem _gi = new GameItem() ;
		_gi.ItemType = itemName ;
		_gi.ItemCount = itemCount ;
		
		if(searchIndex == -1){ //No Exist
			_gameItemList.Add(_gi) ;
		}else{
			_gameItemList[searchIndex] = _gi ;
		}
	}
	
	
	public int SetPurchaseGameItem(int itemName, int itemPurchaseCount){ // Return 1 : Purchase Success ,  99 : Not Search Index..
		
		int state = 99 ;
		
		for(int i = 0 ; i < _gameItemList.Count ; i++){
			GameItem _selectGameItem = _gameItemList[i] ;
			if(_selectGameItem.ItemType == itemName){
				_selectGameItem.ItemCount += itemPurchaseCount ;
				_gameItemList[i] = _selectGameItem ;
				state = 1 ;
				break ;
			}
		}

		if(state == 99)
		{
			SetGameItem(itemName, itemPurchaseCount);
			state = 1;
		}
		
		return state ;
		
	}
	
	public int SetUseGameItem(int itemName, int itemUseCount)
	{
		// Return 0 : Item Count 0 ,  1 : Use Item Success ,  2 : (CurrentItemCount <  itemUseCount), 99 : Not Search Index..
		//Debug.Log ("HLHLHLHLH: " + itemName + " Itemuse: " + itemUseCount);
		int state = 99 ;

		bool found = false;
		for(int i = 0 ; i < _gameItemList.Count ; i++){
			GameItem _selectGameItem = _gameItemList[i] ;
			if(_selectGameItem.ItemType == itemName)
			{
				found = true;
				if(_selectGameItem.ItemCount > 0) {
					if(_selectGameItem.ItemCount >= itemUseCount) {
						_selectGameItem.ItemCount -= itemUseCount ;
						_gameItemList[i] = _selectGameItem ;
						state = 1 ;
						//Debug.Log("ITEM NO: " + itemName + "ITEM USE: " + itemUseCount + " REMAIN: " + _selectGameItem.ItemCount);
					}else{
						state = 1 ;
					}
				}else{
					state = 1 ;
				}
				break ;
			}
		}

		return 1;
		
	}
	
	public int GetCountGameItem(int itemName){ // Return 0 : Item Count 0 ,  1 : Use Item Success ,  2 : (CurrentItemCount <  itemUseCount), 99 : Not Search Index..
		
		int count = -1 ;
		
		for(int i = 0 ; i < _gameItemList.Count ; i++){
			GameItem _selectGameItem = _gameItemList[i] ;
			if(_selectGameItem.ItemType == itemName){
				count = _selectGameItem.ItemCount ;
				break ;
			}
		}
		
		return count ;
		
	}
	
	
	//-----GameMissionData
	public void SetGameMissionGrade1Data(GameMissionData gmd){
		_gameMissionGrade1Data = gmd ;
	}
		
	public void SetGameMissionGrade1Data(int indexNumber, int missionType, int gradeInfo, int missionCondition, int cumulativeNumber, bool isAttain ){
		
		GameMissionData _gmd = new GameMissionData() ;
		_gmd.IndexNumber = indexNumber ;
		_gmd.MissionType = missionType ;
		_gmd.GradeInfo = gradeInfo ;
		_gmd.MissionCondition = missionCondition ;
		_gmd.CumulativeNumber = cumulativeNumber ;
		_gmd.IsAttain = isAttain ;
		
		_gameMissionGrade1Data = _gmd ;
		
	}
	
	public void SetGameMissionGrade2Data(GameMissionData gmd){
		_gameMissionGrade2Data = gmd ;
	}
		
	public void SetGameMissionGrade2Data(int indexNumber, int missionType, int gradeInfo, int missionCondition, int cumulativeNumber, bool isAttain ){
		
		GameMissionData _gmd = new GameMissionData() ;
		_gmd.IndexNumber = indexNumber ;
		_gmd.MissionType = missionType ;
		_gmd.GradeInfo = gradeInfo ;
		_gmd.MissionCondition = missionCondition ;
		_gmd.CumulativeNumber = cumulativeNumber ;
		_gmd.IsAttain = isAttain ;
		
		_gameMissionGrade2Data = _gmd ;
		
	}
	
	
	public void SetGameMissionGrade3Data(GameMissionData gmd){
		_gameMissionGrade3Data = gmd ;
	}
		
	public void SetGameMissionGrade3Data(int indexNumber, int missionType, int gradeInfo, int missionCondition, int cumulativeNumber, bool isAttain ){
		
		GameMissionData _gmd = new GameMissionData() ;
		_gmd.IndexNumber = indexNumber ;
		_gmd.MissionType = missionType ;
		_gmd.GradeInfo = gradeInfo ;
		_gmd.MissionCondition = missionCondition ;
		_gmd.CumulativeNumber = cumulativeNumber ;
		_gmd.IsAttain = isAttain ;
		
		_gameMissionGrade3Data = _gmd ;
		
	}
	
	
	public GameMissionData GetGameMissionData(int missionDataGrade){
		
		GameMissionData _gmd = new GameMissionData() ;
		
		if(missionDataGrade == 1){
			_gmd = _gameMissionGrade1Data ;
		}else if(missionDataGrade == 2){
			_gmd = _gameMissionGrade2Data ;
		}else if(missionDataGrade == 3){
			_gmd = _gameMissionGrade3Data ;
		}
		
		return _gmd ;
		
	}
	
	public GameMissionData UpdateGameMissionDataStateAttain(int missionDataGrade, bool isAttain){
		
		GameMissionData _gmd = new GameMissionData() ;
		
		if(missionDataGrade == 1){
			_gmd = _gameMissionGrade1Data ;
			_gmd.IsAttain = isAttain ;
			_gameMissionGrade1Data = _gmd ;
		}else if(missionDataGrade == 2){
			_gmd = _gameMissionGrade2Data ;
			_gmd.IsAttain = isAttain ;
			_gameMissionGrade2Data = _gmd ;
		}else if(missionDataGrade == 3){
			_gmd = _gameMissionGrade3Data ;
			_gmd.IsAttain = isAttain ;
			_gameMissionGrade3Data = _gmd ;
		}
		
		//_gmd.IsAttain = isAttain ;
		
		return _gmd ;
		
	}
	
	public GameMissionData UpdateGameMissionDataStateCumulativeNumber(int missionDataGrade, int cumulativeNumber){
		
		GameMissionData _gmd = new GameMissionData() ;
		
		if(missionDataGrade == 1){
			_gmd = _gameMissionGrade1Data ;
			_gmd.CumulativeNumber = cumulativeNumber ;
			_gameMissionGrade1Data = _gmd ;
		}else if(missionDataGrade == 2){
			_gmd = _gameMissionGrade2Data ;
			_gmd.CumulativeNumber = cumulativeNumber ;
			_gameMissionGrade2Data = _gmd ;
		}else if(missionDataGrade == 3){
			_gmd = _gameMissionGrade3Data ;
			_gmd.CumulativeNumber = cumulativeNumber ;
			_gameMissionGrade3Data = _gmd ;
		}
		
		//_gmd.CumulativeNumber = cumulativeNumber ;
		
		return _gmd ;
		
	}
	
	
	//--------
	public void BeforeGameStart() {
		
		if(GetCountGameItem(Constant.ST200_ITEM_SHOUT) > 0){
			ItemShout = true ;
		}else{
			ItemShout = false ;
		}
		
		if(GetCountGameItem(Constant.ST200_ITEM_SINGIJEON) > 0) {
			ItemSingijeon = true;	
		}else{
			ItemSingijeon = false;
		}		
		
		if(GetCountGameItem(Constant.ST200_ITEM_REVIVE) > 0)
		{
			ItemRevive = true;
		}else
		{
			ItemRevive = false;
		}

		if(GetCountGameItem(Constant.ST200_ITEM_POWERUP) > 0)
		{
			HaveItemPowerUp = true;
		}else
		{
			HaveItemPowerUp = false;
		}

		if(GetCountGameItem(Constant.ST200_ITEM_HEALTHUP) > 0)
		{
			HaveItemHealthUp = true;
		}else
		{
			HaveItemHealthUp = false;
		}
	}
	
	//---- Gold & Jewel
	public void SetGainGold(int gainCount){
		GameCoin += gainCount ;
	}
	
	public void SetPurchaseGold(int purchaseCount){
		GameCoin += purchaseCount ;
	}
	
	public int SetSpendGold(int spendCount){ // Return 0 : Spend Error ,  1 : Spend Success ,
		
		int state = 0 ;

		//Debug.Log("GAMECOIN: " + GameCoin + " SPEND: " + spendCount);
		if(GameCoin >= spendCount){
			GameCoin -= spendCount ;
			state = 1 ;
		}else {
			state = 0 ;
		}
		
		return state ;
		
	}
	
	public int GetGameGold() {
		return GameCoin ;	
	}

	public int GetCoinDisplayGold()
	{
		return ShopDisplayGameCoin;
	}

	public int GetJewelDisplay()
	{
		return ShopDisplayGameJewel;
	}
	
	//
	public void SetGainJewel(int gainCount){
		GameJewel += gainCount ;
	}
	
	public void SetPurchaseJewel(int purchaseCount){
		int actualcount = purchaseCount;

#if UNITY_ANDROID 
		//if(Constant.CURRENT_MARKET == "2" && FirstInAppPurchaseFlag == 0)
		//{
		//	FirstInAppPurchaseFlag = 1;
		//	actualcount = Mathf.CeilToInt(actualcount * 1.5f);
		//}
#endif

		GameJewel += actualcount ;
		AddLuckyCoupon(purchaseCount/5);
		ST200KLogManager.Instance.SaveShopJewelBuy(actualcount);
	}
	
	public int SetSpendJewel(int spendCount){ // Return 0 : Spend Error ,  1 : Spend Success ,
		
		int state = 0 ;
		
		if(GameJewel >= spendCount){
			GameJewel -= spendCount ;
			state = 1 ;
		}else {
			state = 0 ;
		}
		
		return state ;
		
	}
	
	public int GetGameJewel() {
		return GameJewel ;	
	}
	
	public void AddLuckyCoupon(int _numb)
	{
		LuckyCoupon += _numb;
	}
	
	
	
	//----------------------------
	public UserDataStruct GetUserDataStruct(){
	
		UserDataStruct userDataStruct = new UserDataStruct() ;
		userDataStruct.SoundFlag = SoundFlag;
		userDataStruct.VibrateFlag = VibrateFlag;
		userDataStruct.PushFlag = PushFlag;
		if(_achievementDataList == null)
		{
			_achievementDataList = new List<AchievementData>();
		}
		userDataStruct._achievementDataList = _achievementDataList;
		if(m_UserShipDataList == null)
		{
			InitializeShipData();
		}
		userDataStruct.m_UserShipDataList = m_UserShipDataList;
		if(m_UserSubShipDataList == null)
		{
			InitializeSubShipData();
		}
		userDataStruct.m_UserSubShipDataList = m_UserSubShipDataList;
		if(m_UserStageDataList == null)
		{
			InitializeStageData();
		}
		userDataStruct.m_UserStageDataList = m_UserStageDataList;

		userDataStruct._characterList = _characterList ;
		userDataStruct._gameItemList = _gameItemList ;
		
		userDataStruct._gameMissionGrade1Data = _gameMissionGrade1Data ;
		userDataStruct._gameMissionGrade2Data = _gameMissionGrade2Data ;
		userDataStruct._gameMissionGrade3Data = _gameMissionGrade3Data ;

		// 체험전이벤트 수정부분 - 시작 (14.03.10 by 최원석)
		userDataStruct.ExperienceIndex = ExperienceIndex;
		// 체험전이벤트 수정부분 - 끝
		userDataStruct.Pet2Open = Pet2Open;
		userDataStruct.PetGachaLowGradeConsePicked = PetGachaLowGradeConsePicked;
		userDataStruct.PetGachaOutcome1 = PetGachaOutcome1;
		userDataStruct.PetGachaOutcome2 = PetGachaOutcome2;
		userDataStruct.PetGachaOutcome3 = PetGachaOutcome3;

		userDataStruct.TutorialRewarded = TutorialRewarded;

		// 월드랭킹 수정부분 (14.04.12 by 최원석) - Start
		userDataStruct.UserProfileBlock = UserProfileBlock;
		// 월드랭킹 수정부분 (14.04.12 by 최원석) - End
		userDataStruct.InviteFriend_Num = InviteFriend_Num;

		// Base Info
		userDataStruct.VersionInfo = VersionInfo ;
		
		
		// Game Setting
		userDataStruct.UserNickName = UserNickName ;
		
		
		// user data
		userDataStruct.UserLevel = UserLevel ;
		
		userDataStruct.GameJewel = GameJewel ;
		userDataStruct.GameCoin = GameCoin ;
		
		
		//-- User Record
		userDataStruct.GuestTorpedo = GuestTorpedo;
		userDataStruct.TutorialFlagV119 = TutorialFlagV119;
		userDataStruct.TutorialChar = TutorialChar;
		userDataStruct.TutorialItem = TutorialItem;
		//userDataStruct.FirstInAppPurchaseFlag = FirstInAppPurchaseFlag;
		userDataStruct.SubShipEquipAvailableSlotCount = SubShipEquipAvailableSlotCount;
		userDataStruct.LuckyCoupon = LuckyCoupon;
		userDataStruct.GamePlayCount = GamePlayCount;
		userDataStruct.GameClearCount = GameClearCount;
		userDataStruct.FriendMessageSent = FriendMessageSent;
		userDataStruct.MaxBossClear = MaxBossClear;
		userDataStruct.UserBestDistance = UserBestDistance ;
		userDataStruct.UserBestScore = UserBestScore ;
		userDataStruct.UserPlayCount = UserPlayCount ;
		userDataStruct.UserPlayTime = UserPlayTime ;
		userDataStruct.AllKillCount = AllKillCount ;
		userDataStruct.BossKillCount = BossKillCount ;
				
		// Torpedo Data..
		userDataStruct.TorpedoCount = TorpedoCount ;
		userDataStruct.TorpedoRechargeNextTime = TorpedoRechargeNextTime ;

		userDataStruct.UpdateSequence = UpdateSequence;
		//

		return userDataStruct ;
		
	}
	
	public void SetUserDataStruct(UserDataStruct userDataStruct) {

		SoundFlag = userDataStruct.SoundFlag;
		VibrateFlag = userDataStruct.VibrateFlag;
		PushFlag = userDataStruct.PushFlag;
		_achievementDataList = userDataStruct._achievementDataList;
		if(_achievementDataList == null)
		{
			_achievementDataList = new List<AchievementData>();
		}
		m_UserShipDataList = userDataStruct.m_UserShipDataList;
		if(m_UserShipDataList == null)
		{
			InitializeShipData();
		}
		m_UserSubShipDataList = userDataStruct.m_UserSubShipDataList;
		if(m_UserSubShipDataList == null)
		{
			InitializeSubShipData();
		}

		m_UserStageDataList = userDataStruct.m_UserStageDataList;
		if(m_UserStageDataList == null)
		{
			InitializeStageData();
		}
		_characterList = userDataStruct._characterList ;
		_gameItemList = userDataStruct._gameItemList ;
		
		
		
		if(userDataStruct._gameMissionGrade1Data.IndexNumber == 0){
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(701, 1); //Managers.GameMissionData.GetRandomMissionInfoData(1) ;
			SetGameMissionGrade1Data(getMissionInfoData.IndexNumber, getMissionInfoData.MissionType, getMissionInfoData.GradeInfo, getMissionInfoData.MissionCondition, 0, false) ;
		}else{
			
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(userDataStruct._gameMissionGrade1Data.IndexNumber, userDataStruct._gameMissionGrade1Data.GradeInfo) ;
			SetGameMissionGrade1Data(getMissionInfoData.IndexNumber, getMissionInfoData.MissionType, getMissionInfoData.GradeInfo, getMissionInfoData.MissionCondition, userDataStruct._gameMissionGrade1Data.CumulativeNumber , userDataStruct._gameMissionGrade1Data.IsAttain) ;
			//SetGameMissionGrade1Data(userDataStruct._gameMissionGrade1Data );
		}
		
		if(userDataStruct._gameMissionGrade2Data.IndexNumber == 0){
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(702, 3);//Managers.GameMissionData.GetRandomMissionInfoData(3) ;
			SetGameMissionGrade2Data(getMissionInfoData.IndexNumber, getMissionInfoData.MissionType, getMissionInfoData.GradeInfo, getMissionInfoData.MissionCondition, 0, false) ;
		}else{
			
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(userDataStruct._gameMissionGrade2Data.IndexNumber, userDataStruct._gameMissionGrade2Data.GradeInfo) ;
			SetGameMissionGrade2Data(getMissionInfoData.IndexNumber, getMissionInfoData.MissionType, getMissionInfoData.GradeInfo, getMissionInfoData.MissionCondition, userDataStruct._gameMissionGrade2Data.CumulativeNumber , userDataStruct._gameMissionGrade2Data.IsAttain) ;
			//SetGameMissionGrade2Data(userDataStruct._gameMissionGrade2Data );
		}
		
		if(userDataStruct._gameMissionGrade3Data.IndexNumber == 0){
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetRandomMissionInfoData(5) ;
			SetGameMissionGrade3Data(getMissionInfoData.IndexNumber, getMissionInfoData.MissionType, getMissionInfoData.GradeInfo, getMissionInfoData.MissionCondition, 0, false) ;
		}else{
			
			GameMissionDataManager.MissionInfoData getMissionInfoData = Managers.GameMissionData.GetMissionInfoData(userDataStruct._gameMissionGrade3Data.IndexNumber, userDataStruct._gameMissionGrade3Data.GradeInfo) ;
			SetGameMissionGrade3Data(getMissionInfoData.IndexNumber, getMissionInfoData.MissionType, getMissionInfoData.GradeInfo, getMissionInfoData.MissionCondition, userDataStruct._gameMissionGrade3Data.CumulativeNumber , userDataStruct._gameMissionGrade3Data.IsAttain) ;
			//SetGameMissionGrade3Data(userDataStruct._gameMissionGrade3Data );
		}
		
		
		/*
		SetGameMissionGrade1Data(userDataStruct._gameMissionGrade1Data );
		SetGameMissionGrade2Data(userDataStruct._gameMissionGrade2Data );
		SetGameMissionGrade3Data(userDataStruct._gameMissionGrade3Data );
		*/

		// TestEvent
		ExperienceIndex = userDataStruct.ExperienceIndex;
		// TestEvent

		Pet2Open = userDataStruct.Pet2Open;
		PetGachaLowGradeConsePicked = userDataStruct.PetGachaLowGradeConsePicked;
		PetGachaOutcome1 = userDataStruct.PetGachaOutcome1;
		PetGachaOutcome2 = userDataStruct.PetGachaOutcome2;
		PetGachaOutcome3 = userDataStruct.PetGachaOutcome3;

		TutorialRewarded = userDataStruct.TutorialRewarded;

		// 월드랭킹 수정부분 (14.04.12 by 최원석) - Start
		UserProfileBlock = userDataStruct.UserProfileBlock;
		// 월드랭킹 수정부분 (14.04.12 by 최원석) - End
		InviteFriend_Num = userDataStruct.InviteFriend_Num;

		// Base Info
		VersionInfo = userDataStruct.VersionInfo ;
		
		
		// Game Setting
		UserNickName = userDataStruct.UserNickName ;
		
		
		// User Data
		UserLevel = userDataStruct.UserLevel ;
		
		GameJewel = userDataStruct.GameJewel ;
		GameCoin = userDataStruct.GameCoin ;
		
		
		//-- User Record
		GuestTorpedo = userDataStruct.GuestTorpedo;
		TutorialFlagV119 = userDataStruct.TutorialFlagV119;
		TutorialChar = userDataStruct.TutorialChar;
		TutorialItem = userDataStruct.TutorialItem;
		//FirstInAppPurchaseFlag = userDataStruct.FirstInAppPurchaseFlag;
		SubShipEquipAvailableSlotCount = userDataStruct.SubShipEquipAvailableSlotCount;
		LuckyCoupon = userDataStruct.LuckyCoupon;
		GamePlayCount = userDataStruct.GamePlayCount;
		GameClearCount = userDataStruct.GameClearCount;
		FriendMessageSent = userDataStruct.FriendMessageSent;
		MaxBossClear = userDataStruct.MaxBossClear;
		UserBestDistance = userDataStruct.UserBestDistance ;
		UserBestScore = userDataStruct.UserBestScore ;
		UserPlayCount = userDataStruct.UserPlayCount ;
		UserPlayTime = userDataStruct.UserPlayTime ;
		AllKillCount = userDataStruct.AllKillCount ;
		BossKillCount = userDataStruct.BossKillCount ;
		EnemyKillCount = userDataStruct.EnemyKillCount ;
		
		
		// Torpedo Data..
		TorpedoCount = userDataStruct.TorpedoCount ;
		TorpedoRechargeNextTime = userDataStruct.TorpedoRechargeNextTime ;

		UpdateSequence = userDataStruct.UpdateSequence;
		//

		//temp init
		//if(_petList == null)
		//{
		//	_petList = new List<GamePet>();
		//	Debug.Log("INIT");
		//	for(int i = 0; i < 10; i++)
		//	{
		//		GamePet pet = new GamePet();
		//		pet.IndexNumber = i + 1;
		//		pet.IsSelect = 0;
		//		pet.Level = 1;
		//		_petList.Add(pet);
		//	}
		//}
	}
	
	
	// User 데이터 전송시에만 1회 만들기 위해 사용하는 모듈.
	public void MakeUserData() {

		VersionInfo = 1 ;

		// Init Setting GameCharacter
		SetGameCharacter(1,true,true) ;
		SetGameCharacter(2,false,false) ;
		SetGameCharacter(3,false,false) ;
		
		SetSelectGameCharacter(1) ;

		
		// Init Setting GameItem
		SetGameItem(1, 0);
		SetGameItem(2, 0);
		SetGameItem(3, 0);
		SetGameItem(4, 0);
		SetGameItem(5, 0);
		SetGameItem(6, 0);
		SetGameItem(7, 0);

		
		//SetPurchaseGold(1000) ;
		//SetPurchaseJewel(10000) ;
		GameCoin = 1000000;
		GameJewel = 10000;

		InitializeShipData();
		//InitializeStageData();
		InitializeSubShipData();
		for(int i = 0; i < m_UserStageDataList.Count; i++)
		{
			UserStageData stagedata = m_UserStageDataList[i];
			if(stagedata.IndexNumber < 15)
			{
				stagedata.IsOpen = true;
			}else
			{
				stagedata.IsOpen = false;
			}
			SetUserStageData(stagedata);
		}
		Debug.Log("USER DATA INIT");
	}


	public void Vibrate()
	{
		if(VibrateFlag)
		{
			Handheld.Vibrate();
		}
	}

	public void GivePresent(int _itemtype, int _itemamount)
	{
		if(_itemtype == 1)
		{
			Managers.Torpedo.AddTorpedo(_itemamount);
		}else if(_itemtype == 2)
		{
			SetGainGold(_itemamount);
		}else if(_itemtype == 3)
		{
			SetGainJewel(_itemamount);
		}else if(_itemtype / 1000 == 1)
		{
			SetPurchaseGameItem(_itemtype - 1000, _itemamount);
		}
	}
}
