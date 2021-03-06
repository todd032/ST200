using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class GameBalanceDataManager : MonoBehaviour {

	public struct GameBalanceDataStruct {

		private string m_ShowAdmob ;
		public int ShowAdmob {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_ShowAdmob = encryptString ;
			}
			get {
				if(m_ShowAdmob == null || m_ShowAdmob.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_ShowAdmob,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_ShowAdmobAmount;
		public int ShowAdmobAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_ShowAdmobAmount = encryptString ;
			}
			get {
				if(m_ShowAdmobAmount == null || m_ShowAdmobAmount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_ShowAdmobAmount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_TenthDownloadEventFlag;
		public int TenthDownloadEventFlag {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TenthDownloadEventFlag = encryptString ;
			}
			get {
				if(m_TenthDownloadEventFlag == null || m_TenthDownloadEventFlag.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_TenthDownloadEventFlag,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_TenthDownloadEventStartTimer;
		public int TenthDownloadEventStartTimer {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TenthDownloadEventStartTimer = encryptString ;
			}
			get {
				if(m_TenthDownloadEventStartTimer == null || m_TenthDownloadEventStartTimer.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_TenthDownloadEventStartTimer,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_TenthDownloadEventEndTimer;
		public int TenthDownloadEventEndTimer {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_TenthDownloadEventEndTimer = encryptString ;
			}
			get {
				if(m_TenthDownloadEventEndTimer == null || m_TenthDownloadEventEndTimer.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_TenthDownloadEventEndTimer,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}


		private string m_PVPPlayCost;
		public int PVPPlayCost {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_PVPPlayCost = encryptString ;
			}
			get {
				if(m_PVPPlayCost == null || m_PVPPlayCost.Equals("")){
					return 300;	
				}
				string decryptString = LoadingWindows.NextD(m_PVPPlayCost,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_PVPPlayAttackIncreaseRatio;
		public float PVPPlayAttackIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_PVPPlayAttackIncreaseRatio = encryptString ;
			}
			get {
				if(m_PVPPlayAttackIncreaseRatio == null || m_PVPPlayAttackIncreaseRatio.Equals("")){
					return 2f ;	
				}
				string decryptString = LoadingWindows.NextD(m_PVPPlayAttackIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_PVPPlayOppHealthIncreaseRatio;
		public float PVPPlayOppHealthIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_PVPPlayOppHealthIncreaseRatio = encryptString ;
			}
			get {
				if(m_PVPPlayOppHealthIncreaseRatio == null || m_PVPPlayOppHealthIncreaseRatio.Equals("")){
					return 1f ;	
				}
				string decryptString = LoadingWindows.NextD(m_PVPPlayOppHealthIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_PVPPlayTime;
		public float PVPPlayTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_PVPPlayTime = encryptString ;
			}
			get {
				if(m_PVPPlayTime == null || m_PVPPlayTime.Equals("")){
					return 300f ;	
				}
				string decryptString = LoadingWindows.NextD(m_PVPPlayTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_PVPHealthIncreaseRatio;
		public float PVPHealthIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_PVPHealthIncreaseRatio = encryptString ;
			}
			get {
				if(m_PVPHealthIncreaseRatio == null || m_PVPHealthIncreaseRatio.Equals("")){
					return 10f ;	
				}
				string decryptString = LoadingWindows.NextD(m_PVPHealthIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_PVPSubshipHealthIncreaseRatio;
		public float PVPSubshipHealthIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_PVPSubshipHealthIncreaseRatio = encryptString ;
			}
			get {
				if(m_PVPSubshipHealthIncreaseRatio == null || m_PVPSubshipHealthIncreaseRatio.Equals("")){
					return 10f ;	
				}
				string decryptString = LoadingWindows.NextD(m_PVPSubshipHealthIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

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

		private string m_GamePlayRowSpeed;
		public float GamePlayRowSpeed {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayRowSpeed = encryptString ;
			}
			get {
				if(m_GamePlayRowSpeed == null || m_GamePlayRowSpeed.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayRowSpeed,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayRowResist ;
		public float GamePlayRowResist {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayRowResist = encryptString ;
			}
			get {
				if(m_GamePlayRowResist == null || m_GamePlayRowResist.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayRowResist,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayRowPressAmount ;
		public float GamePlayRowPressAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayRowPressAmount = encryptString ;
			}
			get {
				if(m_GamePlayRowPressAmount == null || m_GamePlayRowPressAmount.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayRowPressAmount,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayTapAmount;
		public float GamePlayTapAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayTapAmount = encryptString ;
			}
			get {
				if(m_GamePlayTapAmount == null || m_GamePlayTapAmount.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayTapAmount,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayKillGainCoinAmount ;
		public float GamePlayKillGainCoinAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayKillGainCoinAmount = encryptString ;
			}
			get {
				if(m_GamePlayKillGainCoinAmount == null || m_GamePlayKillGainCoinAmount.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayKillGainCoinAmount,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayMoveResist ;
		public float GamePlayMoveResist {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayMoveResist = encryptString ;
			}
			get {
				if(m_GamePlayMoveResist == null || m_GamePlayMoveResist.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayMoveResist,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayRotationResist ;
		public float GamePlayRotationResist {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayRotationResist = encryptString ;
			}
			get {
				if(m_GamePlayRotationResist == null || m_GamePlayRotationResist.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayRotationResist,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayReturnToBattleMaxTime ;
		public float GamePlayReturnToBattleMaxTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayReturnToBattleMaxTime = encryptString ;
			}
			get {
				if(m_GamePlayReturnToBattleMaxTime == null || m_GamePlayReturnToBattleMaxTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayReturnToBattleMaxTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		private string m_GamePlayReturnToBattleMaxDistance ;
		public float GamePlayReturnToBattleMaxDistance {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayReturnToBattleMaxDistance = encryptString ;
			}
			get {
				if(m_GamePlayReturnToBattleMaxDistance == null || m_GamePlayReturnToBattleMaxDistance.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayReturnToBattleMaxDistance,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayCharacter2DamageIncreaseRatio;
		public float GamePlayCharacter2DamageIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayCharacter2DamageIncreaseRatio = encryptString ;
			}
			get {
				if(m_GamePlayCharacter2DamageIncreaseRatio == null || m_GamePlayCharacter2DamageIncreaseRatio.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayCharacter2DamageIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayCharacter2AttackSpeedIncreaseRatio;
		public float GamePlayCharacter2AttackSpeedIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayCharacter2AttackSpeedIncreaseRatio = encryptString ;
			}
			get {
				if(m_GamePlayCharacter2AttackSpeedIncreaseRatio == null || m_GamePlayCharacter2AttackSpeedIncreaseRatio.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayCharacter2AttackSpeedIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_GamePlayCharacter3Duration;
		public float GamePlayCharacter3Duration {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_GamePlayCharacter3Duration = encryptString ;
			}
			get {
				if(m_GamePlayCharacter3Duration == null || m_GamePlayCharacter3Duration.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_GamePlayCharacter3Duration,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_AttackItemDamageIncreaseRatio;
		public float AttackItemDamageIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_AttackItemDamageIncreaseRatio = encryptString ;
			}
			get {
				if(m_AttackItemDamageIncreaseRatio == null || m_AttackItemDamageIncreaseRatio.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_AttackItemDamageIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		private string m_HealthItemIncreaseRatio;
		public float HealthItemIncreaseRatio {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_HealthItemIncreaseRatio = encryptString ;
			}
			get {
				if(m_HealthItemIncreaseRatio == null || m_HealthItemIncreaseRatio.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(m_HealthItemIncreaseRatio,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string m_SubShipEquipAvailableMaxCount ;
		public int SubShipEquipAvailableMaxCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_SubShipEquipAvailableMaxCount = encryptString ;
			}
			get {
				if(m_SubShipEquipAvailableMaxCount == null || m_SubShipEquipAvailableMaxCount.Equals("")){
					return 4;	
				}
				string decryptString = LoadingWindows.NextD(m_SubShipEquipAvailableMaxCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_SubShipUnlockCost2 ;
		public int SubShipUnlockCost2 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_SubShipUnlockCost2 = encryptString ;
			}
			get {
				if(m_SubShipUnlockCost2 == null || m_SubShipUnlockCost2.Equals("")){
					return 4;	
				}
				string decryptString = LoadingWindows.NextD(m_SubShipUnlockCost2,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_SubShipUnlockCost3 ;
		public int SubShipUnlockCost3 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_SubShipUnlockCost3 = encryptString ;
			}
			get {
				if(m_SubShipUnlockCost3 == null || m_SubShipUnlockCost3.Equals("")){
					return 4;	
				}
				string decryptString = LoadingWindows.NextD(m_SubShipUnlockCost3,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string m_SubShipUnlockCost4 ;
		public int SubShipUnlockCost4 {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_SubShipUnlockCost4 = encryptString ;
			}
			get {
				if(m_SubShipUnlockCost4 == null || m_SubShipUnlockCost4.Equals("")){
					return 4;	
				}
				string decryptString = LoadingWindows.NextD(m_SubShipUnlockCost4,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		//-----
		
		public List<GameMissionDataManager.MissionInfoData> _missionInfoDataGrade1List ;
		public List<GameMissionDataManager.MissionInfoData> _missionInfoDataGrade2List ;
		public List<GameMissionDataManager.MissionInfoData> _missionInfoDataGrade3List ;
		public List<GameMissionDataManager.MissionMessageData> _missionMessageDataList ;

		public List<AchievementInfoData> _achievementInfoDataList;
		public List<AchievementInfoMessageData> _achievementInfoMessageDataList;

		//-------------- new stage data
		public List<StageData> _stageDataList;
		public List<StageWaveData> _stageWaveDataList;
		public List<StageEnemyData> _stageEnemyDataList;

		public List<StageItemData> m_StageItemData;
		public List<StageItemSpawnData> m_StageItemSpawnDataList;
		//-------------- new stage data end


		public List<GamePetDescription> _gamePetDescriptionList;
		public List<GamePetBalance> _gamePetBalanceList;
		public List<GameSubweaponBalance> _subweaponBalanceList ;
		public List<GameSubweaponAttackBalance> _subweaponAttackBalanceList ;
		public List<EnemyObjectBalance> _enemyObejctBalanceList ;
	
		public List<GameItemBalance> _gameItemBalanceList ;
		public List<GameItemMessageData> _gameItemMessageDataList ;
	
		public List<SaleSubmarineInfo> _saleSubmarineInfoList;
		public List<GameSubmarineInfoBalance> _gameSubmarineInfoBalanceList ;
		public List<GameSubmarineInfoMessageData> _gameSubmarineInfoMessageDataList ;
	
		public List<ShipDescriptionInfo> _shipDescriptionInfoList;
		public List<ShipStatInfo> _shipStatInfoList;

		public List<SubShipDescriptionInfo> m_SubShipDescriptionInfoList;
		public List<SubShipStatInfo> m_SubShipStatInfoList;
		public List<SubShipTacTic> m_SubShipTactic;
		public List<SubShipGachaData> m_SubShipGachaDataList;

		public List<GameSubmarineBulletInfoBalance> _gameSubmarineBulletInfoBalanceList ;
		public List<GameSubmarineEnergyInfoBalance> _gameSubmarineEnergyInfoBalanceList;

		public List<SaleCharacterInfo> _saleCharacterInfoList;
		public List<GameCharacterInfoBalance> _gameCharacterInfoBalanceList ;
		public List<GameCharacterInfoMessageData> _gameCharacterInfoMessageDataList ;
	
		public List<GameTipInfoMessageData> _gameTipInfoMessageDataList ;
	
		public List<PaymentBuyInfoBalance> _paymentGoldBuyInfoBalanceList ;
		public List<PaymentBuyInfoBalance> _paymentJewelBuyInfoBalanceList ;
		public List<PaymentBuyInfoBalance> _paymentJewelIOSBuyInfoBalanceList ;
		public List<PaymentBuyInfoBalance> _paymentTorpedoBuyInfoBalanceList ;
	
		public GameSubweaponSlotBalance _gameSubweaponSlotBalance ;
		public GameSubweaponPurchaseBalance _gameSubweaponPurchaseBalance ;
	
		public BossEnemyBalance _bossEnemyBalance ;
		
		public List<MidBossEnemyBalance> _midBossEnemyBalanceList ;

		public List<GameEndMessageData> _gameEndMessageDataList ;

		private string _kakaoInviteMessageID;
		public int KakaoInviteMessageID {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_kakaoInviteMessageID = encryptString ;
			}
			get { 
				if(_kakaoInviteMessageID == null || _kakaoInviteMessageID.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_kakaoInviteMessageID,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _luckyGachaPerCoupon;
		public int LuckyGachaPerCoupon {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_luckyGachaPerCoupon = encryptString ;
			}
			get { 
				if(_luckyGachaPerCoupon == null || _luckyGachaPerCoupon.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_luckyGachaPerCoupon,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _luckyGachaCouponMax;
		public int LuckyGachaCouponMax {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_luckyGachaCouponMax = encryptString ;
			}
			get { 
				if(_luckyGachaCouponMax == null || _luckyGachaCouponMax.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_luckyGachaCouponMax,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		public List<LuckyPresent> _luckyPresentList;
		public List<LuckyPresentGradeProbability> _luckyPresentGradeProbabilityList;

		//----------
		private string _petGachaCost  ;
		public int PetGachaCost {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_petGachaCost = encryptString ;
			}
			get {
				if(_petGachaCost == null || _petGachaCost.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_petGachaCost,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _pet2SlotOpenCost  ;
		public int Pet2SlotOpenCost {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_pet2SlotOpenCost = encryptString ;
			}
			get {
				if(_pet2SlotOpenCost == null || _pet2SlotOpenCost.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_pet2SlotOpenCost,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		//Torpedo
		private string _torpedoMaxValue  ;
		public int TorpedoMaxValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_torpedoMaxValue = encryptString ;
			}
			get {
				if(_torpedoMaxValue == null || _torpedoMaxValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_torpedoMaxValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _nextRechargeTorpedoBaseTime  ;
		public int NextRechargeTorpedoBaseTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_nextRechargeTorpedoBaseTime = encryptString ;
			}
			get {
				if(_nextRechargeTorpedoBaseTime == null || _nextRechargeTorpedoBaseTime.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_nextRechargeTorpedoBaseTime,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		//Torpedo
		private string _torpedoRechargeCost  ;
		public int TorpedoRechargeCost {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_torpedoRechargeCost = encryptString ;
			}
			get {
				if(_torpedoRechargeCost == null || _torpedoRechargeCost.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_torpedoRechargeCost,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		//Ranking List
		private string _clanRankingListPageLimit  ;
		public int ClanRankingListPageLimit {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_clanRankingListPageLimit = encryptString ;
			}
			get {
				if(_clanRankingListPageLimit == null || _clanRankingListPageLimit.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_clanRankingListPageLimit,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _topRankingListPageLimit  ;
		public int TopRankingListPageLimit {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_topRankingListPageLimit = encryptString ;
			}
			get {
				if(_topRankingListPageLimit == null || _topRankingListPageLimit.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_topRankingListPageLimit,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		
		
		
		//Game Setting Balance Info
		private string _gameLevel  ;
		public int GameLevel {
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
		public int GameWeightLevel {
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
		public float GameSpeedIncrease {
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

		
		
		//---

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

		private string _gameSpeedIncreaseBaseDistance ;
		public int GameSpeedIncreaseBaseDistance {
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
		public int GameLevelIncreaseBaseDistance {
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
		public int GameWeightLevelIncreaseBaseDistance {
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
		public float GameSpeedMaxValue {
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
		public float StartBoosterTime {
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
		public float StartBoosterSpeed {
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
		public float LastBoosterTime {
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
		public float LastBoosterSpeed {
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
		public float ReviveBoosterTime {
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
		public float ReviveBoosterSpeed {
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
		public float FeverModeMaxGauge {
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
		public float FeverModeTime {
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
		private string _feverModeSpeed ;
		public float FeverModeSpeed {
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
		
		
		//--- Drop Items Ability
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

		private string _magnetTime ;
		public float MagnetTime {
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
		public float PowerShotTime {
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
		public float DobleScoreTime {
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
		public float BoosterTime {
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
		public float BoosterSpeed {
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
		
		private string _missileDamage ;
		public float MissileDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missileDamage = encryptString ;
			}
			get {
				if(_missileDamage == null || _missileDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_missileDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string _laserDamage ;
		public float LaserDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_laserDamage = encryptString ;
			}
			get {
				if(_laserDamage == null || _laserDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_laserDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string _laserDurationTime ;
		public float LaserDurationTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_laserDurationTime = encryptString ;
			}
			get {
				if(_laserDurationTime == null || _laserDurationTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_laserDurationTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		//--- Drop Item Probability
		private string _boosterProbability ;
		public int BoosterProbability {
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
		public int DoubleScoreProbability {
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
		public int MagnetProbability {
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
		public int PowerShotProbability {
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
		public int GoldProbability {
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
		public int BigGoldProbability {
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
		
		//--- Score
		private string _enemy1Score ;
		public int Enemy1Score {
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
		public int Enemy2Score {
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
		public int Enemy3Score {
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
		public int Enemy4Score {
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
		public int Enemy5Score {
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
		public int Enemy6Score {
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
		public int EnemyMineScore {
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
		public int AllKillScore {
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
		public int BossEnemyHeadPartsScore {
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
		public int BossEnemyFrontPartsScore {
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
		public int BossEnemyLegsPartsScore {
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
		public int BossEnemyAllBrokenScore {
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

		
		//-- Coin Info
		private string _coinPatternGold ;
		public int CoinPatternGold {
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
		public int CoinPatternBigGold {
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
		public int CoinDropItemGold {
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
		public int CoinDropItemBigGold {
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
		
		
		
		//-- Magnet Area Info
		private string _magnetAreaCharacter ;
		public float MagnetAreaCharacter {
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
		public float MagnetAreaDropItem {
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
		
		//-- Boss Controll Data
		private string _bossLuncherNextDistance  ;
		public int BossLuncherNextDistance {
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
		public int BossLuncherTermDistance {
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
		
		//---
		//--- Subweapon Gacha Probability
		private string _gachaGrade1Probability ;
		public float GachaGrade1Probability {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gachaGrade1Probability = encryptString ;
			}
			get {
				if(_gachaGrade1Probability == null || _gachaGrade1Probability.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_gachaGrade1Probability,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _gachaGrade2Probability ;
		public float GachaGrade2Probability {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gachaGrade2Probability = encryptString ;
			}
			get {
				if(_gachaGrade2Probability == null || _gachaGrade2Probability.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_gachaGrade2Probability,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _gachaGrade3Probability ;
		public float GachaGrade3Probability {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gachaGrade3Probability = encryptString ;
			}
			get {
				if(_gachaGrade3Probability == null || _gachaGrade3Probability.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_gachaGrade3Probability,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _gachaGrade4Probability ;
		public float GachaGrade4Probability {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gachaGrade4Probability = encryptString ;
			}
			get {
				if(_gachaGrade4Probability == null || _gachaGrade4Probability.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_gachaGrade4Probability,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _gachaGrade5Probability ;
		public float GachaGrade5Probability {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_gachaGrade5Probability = encryptString ;
			}
			get {
				if(_gachaGrade5Probability == null || _gachaGrade5Probability.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_gachaGrade5Probability,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		// 이어하기 수정 - 시작 (14.03.12 by 최원석).
		private string _crystalExpendForContinue  ;
		public int CrystalExpendForContinue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_crystalExpendForContinue = encryptString ;
			}
			get {
				if(_crystalExpendForContinue == null || _crystalExpendForContinue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_crystalExpendForContinue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}
		// 이어하기 수정 - 끝.

		public List<string> m_StringTextList;
	} ;
	
	
	
	
	
	
	// Base Info
	private string m_ShowAdmob ;
	public int ShowAdmob {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShowAdmob = encryptString ;
		}
		get {
			if(m_ShowAdmob == null || m_ShowAdmob.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShowAdmob,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_ShowAdmobAmount;
	public int ShowAdmobAmount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShowAdmobAmount = encryptString ;
		}
		get {
			if(m_ShowAdmobAmount == null || m_ShowAdmobAmount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShowAdmobAmount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_TenthDownloadEventFlag;
	public int TenthDownloadEventFlag {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TenthDownloadEventFlag = encryptString ;
		}
		get {
			if(m_TenthDownloadEventFlag == null || m_TenthDownloadEventFlag.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_TenthDownloadEventFlag,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_TenthDownloadEventStartTimer;
	public int TenthDownloadEventStartTimer {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TenthDownloadEventStartTimer = encryptString ;
		}
		get {
			if(m_TenthDownloadEventStartTimer == null || m_TenthDownloadEventStartTimer.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_TenthDownloadEventStartTimer,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_TenthDownloadEventEndTimer;
	public int TenthDownloadEventEndTimer {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TenthDownloadEventEndTimer = encryptString ;
		}
		get {
			if(m_TenthDownloadEventEndTimer == null || m_TenthDownloadEventEndTimer.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_TenthDownloadEventEndTimer,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_PVPPlayCost;
	public int PVPPlayCost {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPPlayCost = encryptString ;
		}
		get {
			if(m_PVPPlayCost == null || m_PVPPlayCost.Equals("")){
				return 300;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPPlayCost,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_PVPPlayAttackIncreaseRatio;
	public float PVPPlayAttackIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPPlayAttackIncreaseRatio = encryptString ;
		}
		get {
			if(m_PVPPlayAttackIncreaseRatio == null || m_PVPPlayAttackIncreaseRatio.Equals("")){
				return 2f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPPlayAttackIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_PVPPlayOppHealthIncreaseRatio;
	public float PVPPlayOppHealthIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPPlayOppHealthIncreaseRatio = encryptString ;
		}
		get {
			if(m_PVPPlayOppHealthIncreaseRatio == null || m_PVPPlayOppHealthIncreaseRatio.Equals("")){
				return 1f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPPlayOppHealthIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_PVPPlayTime;
	public float PVPPlayTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPPlayTime = encryptString ;
		}
		get {
			if(m_PVPPlayTime == null || m_PVPPlayTime.Equals("")){
				return 300f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPPlayTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_PVPHealthIncreaseRatio;
	public float PVPHealthIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPHealthIncreaseRatio = encryptString ;
		}
		get {
			if(m_PVPHealthIncreaseRatio == null || m_PVPHealthIncreaseRatio.Equals("")){
				return 10f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPHealthIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_PVPSubshipHealthIncreaseRatio;
	public float PVPSubshipHealthIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PVPSubshipHealthIncreaseRatio = encryptString ;
		}
		get {
			if(m_PVPSubshipHealthIncreaseRatio == null || m_PVPSubshipHealthIncreaseRatio.Equals("")){
				return 10f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PVPSubshipHealthIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private int _versionInfo ;
	public int VersionInfo {
		get { return _versionInfo ; }
		set { _versionInfo = value ; }
	}

	private string m_GamePlayRowSpeed;
	public float GamePlayRowSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayRowSpeed = encryptString ;
		}
		get {
			if(m_GamePlayRowSpeed == null || m_GamePlayRowSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayRowSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_GamePlayRowResist ;
	public float GamePlayRowResist {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayRowResist = encryptString ;
		}
		get {
			if(m_GamePlayRowResist == null || m_GamePlayRowResist.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayRowResist,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_GamePlayRowPressAmount ;
	public float GamePlayRowPressAmount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayRowPressAmount = encryptString ;
		}
		get {
			if(m_GamePlayRowPressAmount == null || m_GamePlayRowPressAmount.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayRowPressAmount,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_GamePlayTapAmount;
	public float GamePlayTapAmount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayTapAmount = encryptString ;
		}
		get {
			if(m_GamePlayTapAmount == null || m_GamePlayTapAmount.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayTapAmount,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_GamePlayKillGainCoinAmount ;
	public float GamePlayKillGainCoinAmount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayKillGainCoinAmount = encryptString ;
		}
		get {
			if(m_GamePlayKillGainCoinAmount == null || m_GamePlayKillGainCoinAmount.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayKillGainCoinAmount,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_GamePlayMoveResist ;
	public float GamePlayMoveResist {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayMoveResist = encryptString ;
		}
		get {
			if(m_GamePlayMoveResist == null || m_GamePlayMoveResist.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayMoveResist,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_GamePlayRotationResist ;
	public float GamePlayRotationResist {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayRotationResist = encryptString ;
		}
		get {
			if(m_GamePlayRotationResist == null || m_GamePlayRotationResist.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayRotationResist,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_GamePlayReturnToBattleMaxTime ;
	public float GamePlayReturnToBattleMaxTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayReturnToBattleMaxTime = encryptString ;
		}
		get {
			if(m_GamePlayReturnToBattleMaxTime == null || m_GamePlayReturnToBattleMaxTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayReturnToBattleMaxTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_GamePlayReturnToBattleMaxDistance ;
	public float GamePlayReturnToBattleMaxDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayReturnToBattleMaxDistance = encryptString ;
		}
		get {
			if(m_GamePlayReturnToBattleMaxDistance == null || m_GamePlayReturnToBattleMaxDistance.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayReturnToBattleMaxDistance,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_GamePlayCharacter2DamageIncreaseRatio;
	public float GamePlayCharacter2DamageIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayCharacter2DamageIncreaseRatio = encryptString ;
		}
		get {
			if(m_GamePlayCharacter2DamageIncreaseRatio == null || m_GamePlayCharacter2DamageIncreaseRatio.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayCharacter2DamageIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_GamePlayCharacter2AttackSpeedIncreaseRatio;
	public float GamePlayCharacter2AttackSpeedIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayCharacter2AttackSpeedIncreaseRatio = encryptString ;
		}
		get {
			if(m_GamePlayCharacter2AttackSpeedIncreaseRatio == null || m_GamePlayCharacter2AttackSpeedIncreaseRatio.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayCharacter2AttackSpeedIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_GamePlayCharacter3Duration;
	public float GamePlayCharacter3Duration {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_GamePlayCharacter3Duration = encryptString ;
		}
		get {
			if(m_GamePlayCharacter3Duration == null || m_GamePlayCharacter3Duration.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_GamePlayCharacter3Duration,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_AttackItemDamageIncreaseRatio;
	public float AttackItemDamageIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackItemDamageIncreaseRatio = encryptString ;
		}
		get {
			if(m_AttackItemDamageIncreaseRatio == null || m_AttackItemDamageIncreaseRatio.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackItemDamageIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_HealthItemIncreaseRatio;
	public float HealthItemIncreaseRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_HealthItemIncreaseRatio = encryptString ;
		}
		get {
			if(m_HealthItemIncreaseRatio == null || m_HealthItemIncreaseRatio.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_HealthItemIncreaseRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_SubShipEquipAvailableMaxCount ;
	public int SubShipEquipAvailableMaxCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SubShipEquipAvailableMaxCount = encryptString ;
		}
		get {
			if(m_SubShipEquipAvailableMaxCount == null || m_SubShipEquipAvailableMaxCount.Equals("")){
				return 4;	
			}
			string decryptString = LoadingWindows.NextD(m_SubShipEquipAvailableMaxCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_SubShipUnlockCost2 ;
	public int SubShipUnlockCost2 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SubShipUnlockCost2 = encryptString ;
		}
		get {
			if(m_SubShipUnlockCost2 == null || m_SubShipUnlockCost2.Equals("")){
				return 4;	
			}
			string decryptString = LoadingWindows.NextD(m_SubShipUnlockCost2,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_SubShipUnlockCost3 ;
	public int SubShipUnlockCost3 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SubShipUnlockCost3 = encryptString ;
		}
		get {
			if(m_SubShipUnlockCost3 == null || m_SubShipUnlockCost3.Equals("")){
				return 4;	
			}
			string decryptString = LoadingWindows.NextD(m_SubShipUnlockCost3,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_SubShipUnlockCost4 ;
	public int SubShipUnlockCost4 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SubShipUnlockCost4 = encryptString ;
		}
		get {
			if(m_SubShipUnlockCost4 == null || m_SubShipUnlockCost4.Equals("")){
				return 4;	
			}
			string decryptString = LoadingWindows.NextD(m_SubShipUnlockCost4,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	public struct AchievementInfoData {
		private string _indexNumber ;
		public int IndexNumber {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_indexNumber = encryptString ;
			}
			get {
				if(_indexNumber == null || _indexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_indexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _missionType ; // 11 : Distance(In Game) , 12 : Distance(Cumulative) , 21 : Gold(In Game) , 22 : Gold(Cumulative) ,  31 : Kill_Enemy(In Game) , 32 : Kill_Enemy(Cumulative) , 42 : Kill_Boss(Cumulative) , 51 : Use_Item , 62 : PlayGame(Cumulative)
		public int MissionType {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missionType = encryptString ;
			}
			get {
				if(_missionType == null || _missionType.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_missionType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _requirenumb ; // 1: Lowest ~ 6 : Most
		public int RequireNumber {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_requirenumb = encryptString ;
			}
			get {
				if(_requirenumb == null || _requirenumb.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_requirenumb,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}		
	} ;

	public struct AchievementInfoMessageData {
		private string _missionType ; // 11 : Distance(In Game) , 12 : Distance(Cumulative) , 21 : Gold(In Game) , 22 : Gold(Cumulative) ,  31 : Kill_Enemy(In Game) , 32 : Kill_Enemy(Cumulative) , 42 : Kill_Boss(Cumulative) , 51 : Use_Item , 62 : PlayGame(Cumulative)
		public int MissionType {
			set { 
				string encryptString =LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_missionType = encryptString ;
			}
			get {
				if(_missionType == null || _missionType.Equals("")){
					return 0 ;	
				}
				string decryptString =LoadingWindows.NextD(_missionType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _message ; // 11 : Distance(In Game) , 12 : Distance(Cumulative) , 21 : Gold(In Game) , 22 : Gold(Cumulative) ,  31 : Kill_Enemy(In Game) , 32 : Kill_Enemy(Cumulative) , 42 : Kill_Boss(Cumulative) , 51 : Use_Item , 62 : PlayGame(Cumulative)
		public string Message {
			set { 
				_message = value;;
			}
			get {
				if(_message == null || _message.Equals("")){
					return "";	
				}

				return _message;
			}
		}
	} ;

	//------ Enemy Pattern
	///한 패턴을 정의하는 구조체, 5*5에 배치를 하며(위치 정보), 타입으로 어떤 형태의 함정이 되는지 결정된다.( ex)0 - 물고기 랜덤, 1 - 기뢰 패턴) 
	public struct EnemyPatternMap
	{
		private string _AppearanceFactor;
		public int AppearanceFactor
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_AppearanceFactor = encryptString ;
			}
			get {
				if(_AppearanceFactor == null || _AppearanceFactor.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_AppearanceFactor,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}
		public byte[] Map;
		private string _EnemyPatternMapType;
		public int EnemyPatternMapType
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnemyPatternMapType = encryptString ;
			}
			get {
				if(_EnemyPatternMapType == null || _EnemyPatternMapType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnemyPatternMapType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		private string _EnemyPatternMapIndex;
		public int EnemyPatternMapIndex
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnemyPatternMapIndex = encryptString ;
			}
			get {
				if(_EnemyPatternMapIndex == null || _EnemyPatternMapIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnemyPatternMapIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

	}

	///해당 그룹에 어떤 적들이 들어가있는지 index들을 list로 가지고 있음.
	public struct EnemyGroup
	{
		private string _EnemyGroupIndex;
		public int EnemyGroupIndex
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnemyGroupIndex = encryptString ;
			}
			get {
				if(_EnemyGroupIndex == null || _EnemyGroupIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnemyGroupIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}
		public int[] EnemyIndexes;
	}

	///한 EnemyPattern에 어떤 Enemy들이 얼마나 존재하는지 설정.
	public struct EnemySetGroup
	{
		private string _EnemySetGroupIndex;
		public int EnemySetGroupIndex
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnemySetGroupIndex = encryptString ;
			}
			get {
				if(_EnemySetGroupIndex == null || _EnemySetGroupIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnemySetGroupIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		public int[] EnemyGroupIndexes;
		public int[] EnemyGroupNumbers;
	}

	///Section들을 담고 있는 구조체.(index들)
	public struct GameStage
	{
		private string _GameStageIndex;
		public int GameStageIndex
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_GameStageIndex = encryptString ;
			}
			get {
				if(_GameStageIndex == null || _GameStageIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_GameStageIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		public int[] Sections;
	}

	///Section이 어떻게 구성될지 결정하는 구조체.
	public struct GameStageSections
	{
		private string _GameStageSectionIndex;
		public int GameStageSectionIndex
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_GameStageSectionIndex = encryptString ;
			}
			get {
				if(_GameStageSectionIndex == null || _GameStageSectionIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_GameStageSectionIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		private string _EnemyPatternMapType;
		/// <summary>
		/// 해당 패턴에 의해 물고기출현, 기뢰 출현 결정.
		/// </summary>
		public int EnemyPatternMapType
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnemyPatternMapType = encryptString ;
			}
			get {
				if(_EnemyPatternMapType == null || _EnemyPatternMapType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnemyPatternMapType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		private string _EnemySetGroupIndex;
		public int EnemySetGroupIndex
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnemySetGroupIndex = encryptString ;
			}
			get {
				if(_EnemySetGroupIndex == null || _EnemySetGroupIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnemySetGroupIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		private string _PatternLength;
		public int PatternLength
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_PatternLength = encryptString ;
			}
			get {
				if(_PatternLength == null || _PatternLength.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_PatternLength,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		private string _PatternLengthAdd;
		public int PatternLengthAdd
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_PatternLengthAdd = encryptString ;
			}
			get {
				if(_PatternLengthAdd == null || _PatternLengthAdd.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_PatternLengthAdd,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		
		
		private string _PatternMaxLength;
		public int PatternMaxLength
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_PatternMaxLength = encryptString ;
			}
			get {
				if(_PatternMaxLength == null || _PatternMaxLength.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_PatternMaxLength,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString);
				return decryptInt;
			}
		}

		private string _PatternDelay;
		public float PatternDelay
		{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_PatternDelay = encryptString ;
			}
			get {
				if(_PatternDelay == null || _PatternDelay.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_PatternDelay,Constant.DefalutAppName) ;
				float decryptInt = float.Parse(decryptString);
				return decryptInt;
			}
		}
	}
	//-------Enemy Pattern END
	/*
	// Object Balance Info
	public struct GameSubmarineBalance {
		private int _indexNumber ;
		public int IndexNumber {
			get { return _indexNumber ; }
			set { _indexNumber = value ; }
		}
		
		private float _bulletDelayTime ; //Attack Speed
		public float BulletDelayTime {
			get { return _bulletDelayTime ; }
			set { _bulletDelayTime = value ; }
		}
		
		private float _bulletInitDamage ;
		public float BulletInitDamage {
			get { return _bulletInitDamage ; }
			set { _bulletInitDamage = value ; }
		}
		
		private float _bulletIncreaceDamage ;
		public float BulletIncreaceDamage {
			get { return _bulletIncreaceDamage ; }
			set { _bulletIncreaceDamage = value ; }
		}
		
		private float _bulletSpeed ;
		public float BulletSpeed {
			get { return _bulletSpeed ; }
			set { _bulletSpeed = value ; }
		}
		
	} ;
	*/

	public struct GamePetDescription
	{
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

		private string _rank ;
		public int Rank {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_rank = encryptString ;
			}
			get { 
				if(_rank == null || _rank.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_rank,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _petName ;
		public string PetName {
			set { 
				_petName = value ;
			}
			get {
				if(_petName == null || _petName.Equals("")){
					return "" ;	
				}
				return _petName;
			}
		}
		
		private string _petDescription ;
		public string PetDescription {
			set { 
				_petDescription = value ;
			}
			get {
				if(_petDescription == null || _petDescription.Equals("")){
					return "" ;	
				}
				return _petDescription;
			}
		}
	}

	public struct GamePetBalance {
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

		private string _petType ;
		public int PetType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_petType = encryptString ;
			}
			get { 
				if(_petType == null || _petType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_petType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _level;
		public int Level {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_level = encryptString ;
			}
			get { 
				if(_level == null || _level.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_level,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		//Subweapon Ability
		private string _bulletDelayTime ; //Attack Speed
		public float BulletDelayTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDelayTime = encryptString ;
			}
			get { 
				if(_bulletDelayTime == null || _bulletDelayTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDelayTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _bulletDamage ;
		public float BulletDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDamage = encryptString ;
			}
			get { 
				if(_bulletDamage == null || _bulletDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string _effectDuration ;
		public float EffectDuration {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_effectDuration = encryptString ;
			}
			get { 
				if(_effectDuration == null || _effectDuration.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_effectDuration,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string _itemEffectDuration ;
		public float ItemEffectDuration {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_itemEffectDuration = encryptString ;
			}
			get { 
				if(_itemEffectDuration == null || _itemEffectDuration.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_itemEffectDuration,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		public int[] ItemSpawnIndexList;
		public int[] ItemSpawnProbabilityList;
	} ;

	public struct GameSubweaponBalance {
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
		
		//Subweapon Ability
		private string _bulletDelayTime ; //Attack Speed
		public float BulletDelayTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDelayTime = encryptString ;
			}
			get { 
				if(_bulletDelayTime == null || _bulletDelayTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDelayTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _bulletDamage ;
		public float BulletDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDamage = encryptString ;
			}
			get { 
				if(_bulletDamage == null || _bulletDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _magnetTime ;
		public float MagnetTime {
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
		
		private string _doubleScoreTime ;
		public float DoubleScoreTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_doubleScoreTime = encryptString ;
			}
			get { 
				if(_doubleScoreTime == null || _doubleScoreTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_doubleScoreTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _boosterTime ;
		public float BoosterTime {
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
		
		private string _powerShotTime ;
		public float PowerShotTime {
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
		
		private string _bigGoldProbability ;
		public int BigGoldProbability {
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
		//

		
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
	} ;
	
	
	
	public struct GameSubweaponAttackBalance {
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
		
		private string _subweaponGrade ; // 1: Noraml  , 2:Elite , 3:Rare , 4:Unique , 5:Legend
		public int SubweaponGrade {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_subweaponGrade = encryptString ;
			}
			get { 
				if(_subweaponGrade == null || _subweaponGrade.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_subweaponGrade,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _subweaponType ; // 1:Attack , 2:Score, 3:Gain1 , 4:Gain2 , 5:Rush , 6:Item1 , 7:Item2
		public int SubweaponType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_subweaponType = encryptString ;
			}
			get { 
				if(_subweaponType == null || _subweaponType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_subweaponType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bulletType ;
		public int BulletType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletType = encryptString ;
			}
			get { 
				if(_bulletType == null || _bulletType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bulletDelayTime ; //Attack Speed
		public float BulletDelayTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDelayTime = encryptString ;
			}
			get { 
				if(_bulletDelayTime == null || _bulletDelayTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDelayTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _bulletDamage ;
		public float BulletDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDamage = encryptString ;
			}
			get { 
				if(_bulletDamage == null || _bulletDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _bulletSpeed ;
		public float BulletSpeed {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletSpeed = encryptString ;
			}
			get { 
				if(_bulletSpeed == null || _bulletSpeed.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletSpeed,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
	} ;
	
	
	// GameSubweaponSlotBalance
	public struct GameSubweaponSlotBalance {
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _slotValue ;
		public int SlotValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_slotValue = encryptString ;
			}
			get { 
				if(_slotValue == null || _slotValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_slotValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _slotPreviousValue ;
		public int SlotPreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_slotPreviousValue = encryptString ;
			}
			get { 
				if(_slotPreviousValue == null || _slotPreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_slotPreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isDiscount ;
		public bool IsDiscount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isDiscount = encryptString ;
			}
			get { 
				if(_isDiscount == null || _isDiscount.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isDiscount,Constant.DefalutAppName) ;
				
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
	
	// GameSubweaponPurchaseBalance
	public struct GameSubweaponPurchaseBalance {
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _purchaseValue ;
		public int PurchaseValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_purchaseValue = encryptString ;
			}
			get { 
				if(_purchaseValue == null || _purchaseValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_purchaseValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _purchasePreviousValue ;
		public int PurchasePreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_purchasePreviousValue = encryptString ;
			}
			get { 
				if(_purchasePreviousValue == null || _purchasePreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_purchasePreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isDiscount ;
		public bool IsDiscount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isDiscount = encryptString ;
			}
			get { 
				if(_isDiscount == null || _isDiscount.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isDiscount,Constant.DefalutAppName) ;
				
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
	
	
	public struct EnemyObjectBalance {
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
		
		private string _enemyInitHealth ;
		public float EnemyInitHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_enemyInitHealth = encryptString ;
			}
			get { 
				if(_enemyInitHealth == null || _enemyInitHealth.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_enemyInitHealth,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _enemyIncreaceHealth ;
		public float EnemyIncreaceHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_enemyIncreaceHealth = encryptString ;
			}
			get { 
				if(_enemyIncreaceHealth == null || _enemyIncreaceHealth.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_enemyIncreaceHealth,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _enemyInitDamage ;
		public float EnemyInitDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_enemyInitDamage = encryptString ;
			}
			get { 
				if(_enemyInitDamage == null || _enemyInitDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_enemyInitDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
	} ;
	
	
	
	// Game item Balance
	public struct GameItemBalance {		
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
		
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _itemValue ;
		public int ItemValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_itemValue = encryptString ;
			}
			get { 
				if(_itemValue == null || _itemValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_itemValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _itemPreviousValue ;
		public int ItemPreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_itemPreviousValue = encryptString ;
			}
			get { 
				if(_itemPreviousValue == null || _itemPreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_itemPreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isDiscount ;
		public bool IsDiscount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isDiscount = encryptString ;
			}
			get { 
				if(_isDiscount == null || _isDiscount.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isDiscount,Constant.DefalutAppName) ;
				
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
	
	// GameItemMessageData
	public struct GameItemMessageData {
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

		private string m_ItemNameTextIndex ;
		public int ItemNameTextIndex {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_ItemNameTextIndex = encryptString ;
			}
			get { 
				if(m_ItemNameTextIndex == null || m_ItemNameTextIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_ItemNameTextIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		} 

		private string m_ItemDescriptionTextIndex ;
		public int ItemDescriptionTextIndex {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				m_ItemDescriptionTextIndex = encryptString ;
			}
			get { 
				if(m_ItemDescriptionTextIndex == null || m_ItemDescriptionTextIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(m_ItemDescriptionTextIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _gameItemNameEn ;
		public string GameItemNameEn {
			get { return _gameItemNameEn ; }
			set { _gameItemNameEn = value ; }
		}
		
		private string _gameItemMessageEn ;
		public string GameItemMessageEn {
			get { return _gameItemMessageEn ; }
			set { _gameItemMessageEn = value ; }
		}
		
		private string _gameItemNameKo ;
		public string GameItemNameKo {
			get { return _gameItemNameKo ; }
			set { _gameItemNameKo = value ; }
		}
		
		private string _gameItemMessageKo ;
		public string GameItemMessageKo {
			get { return _gameItemMessageKo ; }
			set { _gameItemMessageKo = value ; }
		}
		
		private string _gameItemNameHant ;
		public string GameItemNameHant {
			get { return _gameItemNameHant ; }
			set { _gameItemNameHant = value ; }
		}
		
		private string _gameItemMessageHant ;
		public string GameItemMessageHant {
			get { return _gameItemMessageHant ; }
			set { _gameItemMessageHant = value ; }
		}
		
		private string _gameItemNameHans ;
		public string GameItemNameHans {
			get { return _gameItemNameHans ; }
			set { _gameItemNameHans = value ; }
		}
		
		private string _gameItemMessageHans ;
		public string GameItemMessageHans {
			get { return _gameItemMessageHans ; }
			set { _gameItemMessageHans = value ; }
		}
		
		private string _gameItemNameJa ;
		public string GameItemNameJa {
			get { return _gameItemNameJa ; }
			set { _gameItemNameJa = value ; }
		}
		
		private string _gameItemMessageJa ;
		public string GameItemMessageJa {
			get { return _gameItemMessageJa ; }
			set { _gameItemMessageJa = value ; }
		}
		
		private string _gameItemNameFr ;
		public string GameItemNameFr {
			get { return _gameItemNameFr ; }
			set { _gameItemNameFr = value ; }
		}
		
		private string _gameItemMessageFr ;
		public string GameItemMessageFr {
			get { return _gameItemMessageFr ; }
			set { _gameItemMessageFr = value ; }
		}		
	};

	public struct SaleSubmarineInfo{

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
		
		private string _submarineGrade ;
		public int SubmarineGrade { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarineGrade = encryptString ;
			}
			get { 
				if(_submarineGrade == null || _submarineGrade.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarineGrade,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _submarineValue ;
		public int SubmarineValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarineValue = encryptString ;
			}
			get { 
				if(_submarineValue == null || _submarineValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarineValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _submarinePreviousValue ;
		public int SubmarinePreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarinePreviousValue = encryptString ;
			}
			get { 
				if(_submarinePreviousValue == null || _submarinePreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarinePreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _DueTime ;
		public int DueTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_DueTime = encryptString ;
			}
			get { 
				if(_DueTime == null || _DueTime.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_DueTime,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _isActive ;
		public bool IsActive {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isActive = encryptString ;
			}
			get { 
				if(_isActive == null || _isActive.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isActive,Constant.DefalutAppName) ;
				
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

	// GameSubmarineInfoBalance
	public struct GameSubmarineInfoBalance {		
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
		
		private string _submarineGrade ;
		public int SubmarineGrade { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarineGrade = encryptString ;
			}
			get { 
				if(_submarineGrade == null || _submarineGrade.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarineGrade,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _submarineValue ;
		public int SubmarineValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarineValue = encryptString ;
			}
			get { 
				if(_submarineValue == null || _submarineValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarineValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _submarinePreviousValue ;
		public int SubmarinePreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarinePreviousValue = encryptString ;
			}
			get { 
				if(_submarinePreviousValue == null || _submarinePreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarinePreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isDiscount ;
		public bool IsDiscount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isDiscount = encryptString ;
			}
			get { 
				if(_isDiscount == null || _isDiscount.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isDiscount,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}

		private string _requiredAchievement ;
		public int RequiredAchievement {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_requiredAchievement = encryptString ;
			}
			get { 
				if(_requiredAchievement == null || _requiredAchievement.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_requiredAchievement,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
	} ;
	
	
	// GameSubmarineInfoMessageData
	public struct GameSubmarineInfoMessageData {
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
		
		private string _gameSubmarineNameEn ;
		public string GameSubmarineNameEn {
			get { return _gameSubmarineNameEn ; }
			set { _gameSubmarineNameEn = value ; }
		}
		
		private string _gameSubmarineMessageEn ;
		public string GameSubmarineMessageEn {
			get { return _gameSubmarineMessageEn ; }
			set { _gameSubmarineMessageEn = value ; }
		}
		
		private string _gameSubmarineNameKo ;
		public string GameSubmarineNameKo {
			get { return _gameSubmarineNameKo ; }
			set { _gameSubmarineNameKo = value ; }
		}
		
		private string _gameSubmarineMessageKo ;
		public string GameSubmarineMessageKo {
			get { return _gameSubmarineMessageKo ; }
			set { _gameSubmarineMessageKo = value ; }
		}
		
		private string _gameSubmarineNameHant ;
		public string GameSubmarineNameHant {
			get { return _gameSubmarineNameHant ; }
			set { _gameSubmarineNameHant = value ; }
		}
		
		private string _gameSubmarineMessageHant ;
		public string GameSubmarineMessageHant {
			get { return _gameSubmarineMessageHant ; }
			set { _gameSubmarineMessageHant = value ; }
		}
		
		private string _gameSubmarineNameHans ;
		public string GameSubmarineNameHans {
			get { return _gameSubmarineNameHans ; }
			set { _gameSubmarineNameHans = value ; }
		}
		
		private string _gameSubmarineMessageHans ;
		public string GameSubmarineMessageHans {
			get { return _gameSubmarineMessageHans ; }
			set { _gameSubmarineMessageHans = value ; }
		}
		
		private string _gameSubmarineNameJa ;
		public string GameSubmarineNameJa {
			get { return _gameSubmarineNameJa ; }
			set { _gameSubmarineNameJa = value ; }
		}
		
		private string _gameSubmarineMessageJa ;
		public string GameSubmarineMessageJa {
			get { return _gameSubmarineMessageJa ; }
			set { _gameSubmarineMessageJa = value ; }
		}
		
		private string _gameSubmarineNameFr ;
		public string GameSubmarineNameFr {
			get { return _gameSubmarineNameFr ; }
			set { _gameSubmarineNameFr = value ; }
		}
		
		private string _gameSubmarineMessageFr ;
		public string GameSubmarineMessageFr {
			get { return _gameSubmarineMessageFr ; }
			set { _gameSubmarineMessageFr = value ; }
		}	
		
	};
	
	
	// GameSubmarineBulletInfoBalance
	public struct GameSubmarineBulletInfoBalance {		
		private string _submarineIndexNumber ;
		public int SubmarineIndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarineIndexNumber = encryptString ;
			}
			get { 
				if(_submarineIndexNumber == null || _submarineIndexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarineIndexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bulletIndexNumber ;
		public int BulletIndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletIndexNumber = encryptString ;
			}
			get { 
				if(_bulletIndexNumber == null || _bulletIndexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletIndexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bulletValue ;
		public int BulletValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletValue = encryptString ;
			}
			get { 
				if(_bulletValue == null || _bulletValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bulletPreviousValue ;
		public int BulletPreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletPreviousValue = encryptString ;
			}
			get { 
				if(_bulletPreviousValue == null || _bulletPreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletPreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isDiscount ;
		public bool IsDiscount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isDiscount = encryptString ;
			}
			get { 
				if(_isDiscount == null || _isDiscount.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isDiscount,Constant.DefalutAppName) ;
				
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
		private string _bulletType ; // 1:Gold , 2:Jewel
		public int BulletType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletType = encryptString ;
			}
			get { 
				if(_bulletType == null || _bulletType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bulletDelayTime ; //Attack Speed
		public float BulletDelayTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDelayTime = encryptString ;
			}
			get { 
				if(_bulletDelayTime == null || _bulletDelayTime.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDelayTime,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _bulletDamage ;
		public float BulletDamage {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletDamage = encryptString ;
			}
			get { 
				if(_bulletDamage == null || _bulletDamage.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletDamage,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _bulletSpeed ;
		public float BulletSpeed {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bulletSpeed = encryptString ;
			}
			get { 
				if(_bulletSpeed == null || _bulletSpeed.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_bulletSpeed,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string _slowEffect;
		public float SlowEffect {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_slowEffect = encryptString ;
			}
			get { 
				if(_slowEffect == null || _slowEffect.Equals("")){
					return 1f ;	
				}
				string decryptString = LoadingWindows.NextD(_slowEffect,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
	} ;
	
	// GameSubmarineEnergyInfoBalance
	public struct GameSubmarineEnergyInfoBalance {		
		private string _submarineIndexNumber ;
		public int SubmarineIndexNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_submarineIndexNumber = encryptString ;
			}
			get { 
				if(_submarineIndexNumber == null || _submarineIndexNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_submarineIndexNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _EnergyLevel ;
		public int EnergyLevel {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_EnergyLevel = encryptString ;
			}
			get { 
				if(_EnergyLevel == null || _EnergyLevel.Equals("")){
					return 1 ;	
				}
				string decryptString = LoadingWindows.NextD(_EnergyLevel,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _costValue ;
		public int CostValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_costValue = encryptString ;
			}
			get { 
				if(_costValue == null || _costValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_costValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _costPreviousValue ;
		public int CostPreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_costPreviousValue = encryptString ;
			}
			get { 
				if(_costPreviousValue == null || _costPreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_costPreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _isDiscount ;
		public bool IsDiscount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isDiscount = encryptString ;
			}
			get { 
				if(_isDiscount == null || _isDiscount.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isDiscount,Constant.DefalutAppName) ;
				
				bool decryptBool = false ;
				if(decryptString.Equals("True")){
					decryptBool = true ;
				}else if(decryptString.Equals("False")){
					decryptBool = false ;
				}
				return decryptBool;
			}
		}

		private string _energyAmount ;
		public float EnergyAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_energyAmount = encryptString ;
			}
			get { 
				if(_energyAmount == null || _energyAmount.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_energyAmount,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}

		private string _hitDamageAmount ;
		public float HitDamageAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_hitDamageAmount = encryptString ;
			}
			get { 
				if(_hitDamageAmount == null || _hitDamageAmount.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_hitDamageAmount,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
	} ;

	public struct SaleCharacterInfo {

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
		
		private string _valueType ; // 1:Gold , 2:Jewel
		public int ValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_valueType = encryptString ;
			}
			get { 
				if(_valueType == null || _valueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_valueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _characterValue ;
		public int CharacterValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_characterValue = encryptString ;
			}
			get { 
				if(_characterValue == null || _characterValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_characterValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _characterPreviousValue ;
		public int CharacterPreviousValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_characterPreviousValue = encryptString ;
			}
			get { 
				if(_characterPreviousValue == null || _characterPreviousValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_characterPreviousValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _dueTime ;
		public int DueTime {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_dueTime = encryptString ;
			}
			get { 
				if(_dueTime == null || _dueTime.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_dueTime,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _isActive ;
		public bool IsActive {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_isActive = encryptString ;
			}
			get { 
				if(_isActive == null || _isActive.Equals("")){
					return false ;	
				}
				string decryptString = LoadingWindows.NextD(_isActive,Constant.DefalutAppName) ;
				
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
		
	// GameTipInfoMessageData
	public struct GameTipInfoMessageData {
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
		
		private string _gameTipMessageEn ;
		public string GameTipMessageEn {
			get { return _gameTipMessageEn ; }
			set { _gameTipMessageEn = value ; }
		}
		
		private string _gameTipMessageKo ;
		public string GameTipMessageKo {
			get { return _gameTipMessageKo ; }
			set { _gameTipMessageKo = value ; }
		}
		
		private string _gameTipMessageHant ;
		public string GameTipMessageHant {
			get { return _gameTipMessageHant ; }
			set { _gameTipMessageHant = value ; }
		}
		
		private string _gameTipMessageHans ;
		public string GameTipMessageHans {
			get { return _gameTipMessageHans ; }
			set { _gameTipMessageHans = value ; }
		}
		
		private string _gameTipMessageJa ;
		public string GameTipMessageJa {
			get { return _gameTipMessageJa ; }
			set { _gameTipMessageJa = value ; }
		}
		
		private string _gameTipMessageFr ;
		public string GameTipMessageFr {
			get { return _gameTipMessageFr ; }
			set { _gameTipMessageFr = value ; }
		}
			
	};
	
	
	
	
	// PaymentBuyInfoBalance
	public struct PaymentBuyInfoBalance {		
		private string _paymentItemIndex ;
		public int PaymentItemIndex {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_paymentItemIndex = encryptString ;
			}
			get { 
				if(_paymentItemIndex == null || _paymentItemIndex.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_paymentItemIndex,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _paymentItemValueType ; // 1:Gold , 2:Jewel, 3:Cash
		public int PaymentItemValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_paymentItemValueType = encryptString ;
			}
			get { 
				if(_paymentItemValueType == null || _paymentItemValueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_paymentItemValueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _paymentItemValue ;
		public float PaymentItemValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_paymentItemValue = encryptString ;
			}
			get { 
				if(_paymentItemValue == null || _paymentItemValue.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_paymentItemValue,Constant.DefalutAppName) ;
				float decryptFloat = float.Parse(decryptString) ;
				return decryptFloat;
			}
		}
		
		private string _productValueType ; // 1:Gold , 2:Jewel
		public int ProductValueType { 
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_productValueType = encryptString ;
			}
			get { 
				if(_productValueType == null || _productValueType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_productValueType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _productValue ;
		public int ProductValue {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_productValue = encryptString ;
			}
			get { 
				if(_productValue == null || _productValue.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_productValue,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bonusPercent ;
		public int BonusPercent {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bonusPercent = encryptString ;
			}
			get { 
				if(_bonusPercent == null || _bonusPercent.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bonusPercent,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _chocolateCount ;
		public int ChocolateCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_chocolateCount = encryptString ;
			}
			get { 
				if(_chocolateCount == null || _chocolateCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_chocolateCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
	} ;
	
	
	
	
	
	
	// BossEnemyBalance
	public struct BossEnemyBalance {		
		private string _bossEnemyFrontInitHealth ;
		public int BossEnemyFrontInitHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossEnemyFrontInitHealth = encryptString ;
			}
			get { 
				if(_bossEnemyFrontInitHealth == null || _bossEnemyFrontInitHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossEnemyFrontInitHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bossEnemyFrontWeightHealth ;
		public int BossEnemyFrontWeightHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossEnemyFrontWeightHealth = encryptString ;
			}
			get { 
				if(_bossEnemyFrontWeightHealth == null || _bossEnemyFrontWeightHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossEnemyFrontWeightHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bossEnemyHeadInitHealth ;
		public int BossEnemyHeadInitHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossEnemyHeadInitHealth = encryptString ;
			}
			get { 
				if(_bossEnemyHeadInitHealth == null || _bossEnemyHeadInitHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossEnemyHeadInitHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bossEnemyHeadWeightHealth ;
		public int BossEnemyHeadWeightHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossEnemyHeadWeightHealth = encryptString ;
			}
			get { 
				if(_bossEnemyHeadWeightHealth == null || _bossEnemyHeadWeightHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossEnemyHeadWeightHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		
		private string _bossEnemyLegInitHealth ;
		public int BossEnemyLegInitHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossEnemyLegInitHealth = encryptString ;
			}
			get { 
				if(_bossEnemyLegInitHealth == null || _bossEnemyLegInitHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossEnemyLegInitHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _bossEnemyLegWeightHealth ;
		public int BossEnemyLegWeightHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_bossEnemyLegWeightHealth = encryptString ;
			}
			get { 
				if(_bossEnemyLegWeightHealth == null || _bossEnemyLegWeightHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_bossEnemyLegWeightHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
	} ;
	
	
	// MidBossEnemyBalance
	public struct MidBossEnemyBalance {		
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
		
		private string _midBossType ;
		public int MidBossType {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossType = encryptString ;
			}
			get {
				if(_midBossType == null || _midBossType.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossType,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _midBossEnemyInitHealth ;
		public int MidBossEnemyInitHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossEnemyInitHealth = encryptString ;
			}
			get { 
				if(_midBossEnemyInitHealth == null || _midBossEnemyInitHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossEnemyInitHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _midBossEnemyWeightHealth ;
		public int MidBossEnemyWeightHealth {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossEnemyWeightHealth = encryptString ;
			}
			get { 
				if(_midBossEnemyWeightHealth == null || _midBossEnemyWeightHealth.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossEnemyWeightHealth,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _midBossEnemyAttackNumber ;
		public int MidBossEnemyAttackNumber {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossEnemyAttackNumber = encryptString ;
			}
			get { 
				if(_midBossEnemyAttackNumber == null || _midBossEnemyAttackNumber.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossEnemyAttackNumber,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _midBossEnemyAttackCount ;
		public int MidBossEnemyAttackCount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossEnemyAttackCount = encryptString ;
			}
			get { 
				if(_midBossEnemyAttackCount == null || _midBossEnemyAttackCount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossEnemyAttackCount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
		
		private string _midBossEnemyAttackGap ;
		public float MidBossEnemyAttackGap {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossEnemyAttackGap = encryptString ;
			}
			get { 
				if(_midBossEnemyAttackGap == null || _midBossEnemyAttackGap.Equals("")){
					return 0f ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossEnemyAttackGap,Constant.DefalutAppName) ;
				float decrypFloat = float.Parse(decryptString) ;
				return decrypFloat;
			}
		}
		
		private string _midBossEnemyKillScore ;
		public int MidBossEnemyKillScore {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_midBossEnemyKillScore = encryptString ;
			}
			get { 
				if(_midBossEnemyKillScore == null || _midBossEnemyKillScore.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_midBossEnemyKillScore,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _midBossName ;
		public string MidBossName {
			set { 
				_midBossName = value ;
			}
			get {
				if(_midBossName == null || _midBossName.Equals("")){
					return "" ;	
				}
				return _midBossName;
			}
		}

		private string _midBossDescription ;
		public string MidBossDescription {
			set { 
				_midBossDescription = value ;
			}
			get {
				if(_midBossDescription == null || _midBossDescription.Equals("")){
					return "" ;	
				}
				return _midBossDescription;
			}
		}
	} ;
	
	
	
	public List<AchievementInfoData> _achievementInfoDataList;
	public List<AchievementInfoMessageData> _achievementInfoMessageDataList;

	//-------new stage data list
	public List<StageData> _stageDataList;
	public List<StageWaveData> _stageWaveDataList;
	public List<StageEnemyData> _stageEnemyDataList;

	public List<StageItemData> m_StageItemData;
	public List<StageItemSpawnData> m_StageItemSpawnDataList;
	//-------new stage data end

	public List<GameItemBalance> _gameItemBalanceList ;
	private List<GameItemMessageData> _gameItemMessageDataList ;
	
	private List<SaleSubmarineInfo> _saleSubmarineInfoList;
	private List<GameSubmarineInfoBalance> _gameSubmarineInfoBalanceList ;
	private List<GameSubmarineInfoMessageData> _gameSubmarineInfoMessageDataList ;

	public List<ShipDescriptionInfo> _shipDescriptionInfoList;
	public List<ShipStatInfo> _shipStatInfoList;
	public List<SubShipDescriptionInfo> m_SubShipDescriptionInfoList;
	public List<SubShipStatInfo> m_SubShipStatInfoList;
	public List<SubShipTacTic> m_SubShipTactic;
	public List<SubShipGachaData> m_SubShipGachaDataList = new List<SubShipGachaData>();

	private List<GameSubmarineBulletInfoBalance> _gameSubmarineBulletInfoBalanceList ;
	private List<GameSubmarineEnergyInfoBalance> _gameSubmarineEnergyInfoBalanceList;

	private List<SaleCharacterInfo> _saleCharacterInfoList;
	public List<GameCharacterInfoBalance> _gameCharacterInfoBalanceList ;
	private List<GameCharacterInfoMessageData> _gameCharacterInfoMessageDataList ;
	
	private List<GameTipInfoMessageData> _gameTipInfoMessageDataList ;
	
	private List<PaymentBuyInfoBalance> _paymentGoldBuyInfoBalanceList ;
	private List<PaymentBuyInfoBalance> _paymentJewelBuyInfoBalanceList ;
	private List<PaymentBuyInfoBalance> _paymentJewelIOSBuyInfoBalanceList ;
	public List<PaymentBuyInfoBalance> _paymentTorpedoBuyInfoBalanceList ;
	
	
	private GameSubweaponSlotBalance _gameSubweaponSlotBalance ;
	private GameSubweaponPurchaseBalance _gameSubweaponPurchaseBalance ;
	
	private BossEnemyBalance _bossEnemyBalance ;
	private List<MidBossEnemyBalance> _midBossEnemyBalanceList ;

	private List<GameEndMessageData> _gameEndMessageDataList ;
	private List<LuckyPresent> _luckyPresentList = new List<LuckyPresent>();
	private List<LuckyPresentGradeProbability> _luckyPresentGradeProbabilityList = new List<LuckyPresentGradeProbability>();

	private string _petGachaCost  ;
	public int PetGachaCost {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_petGachaCost = encryptString ;
		}
		get {
			if(_petGachaCost == null || _petGachaCost.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_petGachaCost,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _pet2SlotOpenCost  ;
	public int Pet2SlotOpenCost {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_pet2SlotOpenCost = encryptString ;
		}
		get {
			if(_pet2SlotOpenCost == null || _pet2SlotOpenCost.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_pet2SlotOpenCost,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	//Torpedo
	private string _torpedoMaxValue  ;
	public int TorpedoMaxValue {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_torpedoMaxValue = encryptString ;
		}
		get {
			if(_torpedoMaxValue == null || _torpedoMaxValue.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_torpedoMaxValue,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
		
	private string _nextRechargeTorpedoBaseTime  ;
	public int NextRechargeTorpedoBaseTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_nextRechargeTorpedoBaseTime = encryptString ;
		}
		get {
			if(_nextRechargeTorpedoBaseTime == null || _nextRechargeTorpedoBaseTime.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_nextRechargeTorpedoBaseTime,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
		
	private string _torpedoRechargeCost  ;
	public int TorpedoRechargeCost {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_torpedoRechargeCost = encryptString ;
		}
		get {
			if(_torpedoRechargeCost == null || _torpedoRechargeCost.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_torpedoRechargeCost,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	//Ranking List
	private string _clanRankingListPageLimit  ;
	public int ClanRankingListPageLimit {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_clanRankingListPageLimit = encryptString ;
		}
		get {
			if(_clanRankingListPageLimit == null || _clanRankingListPageLimit.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_clanRankingListPageLimit,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
		
	private string _topRankingListPageLimit  ;
	public int TopRankingListPageLimit {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_topRankingListPageLimit = encryptString ;
		}
		get {
			if(_topRankingListPageLimit == null || _topRankingListPageLimit.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_topRankingListPageLimit,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	
	//Game Setting Balance Info
	private string _gameLevel  ;
	public int GameLevel {
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
	public int GameWeightLevel {
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
	public float GameSpeedIncrease {
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
	//---
	private string _gameSpeedIncreaseBaseDistance ;
	public int GameSpeedIncreaseBaseDistance {
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
	public int GameLevelIncreaseBaseDistance {
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
	public int GameWeightLevelIncreaseBaseDistance {
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
	public float GameSpeedMaxValue {
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
	public float StartBoosterTime {
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
	public float StartBoosterSpeed {
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
	public float LastBoosterTime {
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
	public float LastBoosterSpeed {
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
	public float ReviveBoosterTime {
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
	public float ReviveBoosterSpeed {
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
	public float FeverModeMaxGauge {
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
	public float FeverModeTime {
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
	private string _feverModeSpeed ;
	public float FeverModeSpeed {
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
	
	
	
	//--- Drop Items Ability
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


	private string _magnetTime ;
	public float MagnetTime {
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
	public float PowerShotTime {
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
	public float DobleScoreTime {
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
	public float BoosterTime {
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
	public float BoosterSpeed {
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
	
	private string _missileDamage ;
	public float MissileDamage {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_missileDamage = encryptString ;
		}
		get {
			if(_missileDamage == null || _missileDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_missileDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string _laserDamage ;
	public float LaserDamage {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_laserDamage = encryptString ;
		}
		get {
			if(_laserDamage == null || _laserDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_laserDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string _laserDurationTime ;
	public float LaserDurationTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_laserDurationTime = encryptString ;
		}
		get {
			if(_laserDurationTime == null || _laserDurationTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_laserDurationTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	//--- Drop Item Probability
	private string _boosterProbability ;
	public int BoosterProbability {
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
	public int DoubleScoreProbability {
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
	public int MagnetProbability {
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
	public int PowerShotProbability {
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
	public int GoldProbability {
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
	public int BigGoldProbability {
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
		
	
	//--- Score
	private string _enemy1Score ;
	public int Enemy1Score {
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
	public int Enemy2Score {
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
	public int Enemy3Score {
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
	public int Enemy4Score {
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
	public int Enemy5Score {
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
	public int Enemy6Score {
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
	public int EnemyMineScore {
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
	public int AllKillScore {
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
	public int BossEnemyHeadPartsScore {
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
	public int BossEnemyFrontPartsScore {
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
	public int BossEnemyLegsPartsScore {
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
	public int BossEnemyAllBrokenScore {
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
	//

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



	
	//-- Coin Info
	private string _coinPatternGold ;
	public int CoinPatternGold {
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
	public int CoinPatternBigGold {
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
	public int CoinDropItemGold {
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
	public int CoinDropItemBigGold {
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
	
	
	
	//-- Magnet Area Info
	private string _magnetAreaCharacter ;
	public float MagnetAreaCharacter {
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
	public float MagnetAreaDropItem {
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
	
	
	//-- Boss Controll Data
	private string _bossLuncherNextDistance  ;
	public int BossLuncherNextDistance {
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
	public int BossLuncherTermDistance {
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
	
	
	//--- Subweapon Gacha Probability
	private string _gachaGrade1Probability ;
	public float GachaGrade1Probability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gachaGrade1Probability = encryptString ;
		}
		get {
			if(_gachaGrade1Probability == null || _gachaGrade1Probability.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gachaGrade1Probability,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _gachaGrade2Probability ;
	public float GachaGrade2Probability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gachaGrade2Probability = encryptString ;
		}
		get {
			if(_gachaGrade2Probability == null || _gachaGrade2Probability.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gachaGrade2Probability,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _gachaGrade3Probability ;
	public float GachaGrade3Probability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gachaGrade3Probability = encryptString ;
		}
		get {
			if(_gachaGrade3Probability == null || _gachaGrade3Probability.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gachaGrade3Probability,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _gachaGrade4Probability ;
	public float GachaGrade4Probability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gachaGrade4Probability = encryptString ;
		}
		get {
			if(_gachaGrade4Probability == null || _gachaGrade4Probability.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gachaGrade4Probability,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _gachaGrade5Probability ;
	public float GachaGrade5Probability {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gachaGrade5Probability = encryptString ;
		}
		get {
			if(_gachaGrade5Probability == null || _gachaGrade5Probability.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gachaGrade5Probability,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}


	// GameTipInfoMessageData
	public struct GameEndMessageData {
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
		
		private string _gameEndMessageEn ;
		public string GameEndMessageEn {
			get { return _gameEndMessageEn ; }
			set { _gameEndMessageEn = value ; }
		}
		
		private string _gameEndMessageKo ;
		public string GameEndMessageKo {
			get { return _gameEndMessageKo ; }
			set { _gameEndMessageKo = value ; }
		}
		
		private string _gameEndMessageHant ;
		public string GameEndMessageHant {
			get { return _gameEndMessageHant ; }
			set { _gameEndMessageHant = value ; }
		}
		
		private string _gameEndMessageHans ;
		public string GameEndMessageHans {
			get { return _gameEndMessageHans ; }
			set { _gameEndMessageHans = value ; }
		}
		
		private string _gameEndMessageJa ;
		public string GameEndMessageJa {
			get { return _gameEndMessageJa ; }
			set { _gameEndMessageJa = value ; }
		}
		
		private string _gameEndMessageFr ;
		public string GameEndMessageFr {
			get { return _gameEndMessageFr ; }
			set { _gameEndMessageFr = value ; }
		}

	} ;

	private string _kakaoInviteMessageID;
	public int KakaoInviteMessageID {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_kakaoInviteMessageID = encryptString ;
		}
		get { 
			if(_kakaoInviteMessageID == null || _kakaoInviteMessageID.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_kakaoInviteMessageID,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _luckyGachaPerCoupon;
	public int LuckyGachaPerCoupon {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_luckyGachaPerCoupon = encryptString ;
		}
		get { 
			if(_luckyGachaPerCoupon == null || _luckyGachaPerCoupon.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_luckyGachaPerCoupon,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _luckyGachaCouponMax;
	public int LuckyGachaCouponMax {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_luckyGachaCouponMax = encryptString ;
		}
		get { 
			if(_luckyGachaCouponMax == null || _luckyGachaCouponMax.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_luckyGachaCouponMax,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	public struct LuckyPresent{
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

		private string _grade ;
		public int Grade {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_grade = encryptString ;
			}
			get { 
				if(_grade == null || _grade.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_grade,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

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

		private string _itemAmount ;
		public int ItemAmount {
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_itemAmount = encryptString ;
			}
			get { 
				if(_itemAmount == null || _itemAmount.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_itemAmount,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
	}

	public struct LuckyPresentGradeProbability{
		private string _Grade ;
		public int Grade{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_Grade = encryptString ;
			}
			get { 
				if(_Grade == null || _Grade.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_Grade,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}

		private string _probability ;
		public int Probability{
			set { 
				string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
				_probability = encryptString ;
			}
			get { 
				if(_probability == null || _probability.Equals("")){
					return 0 ;	
				}
				string decryptString = LoadingWindows.NextD(_probability,Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				return decryptInt;
			}
		}
	}
	
	// 이어하기 수정 - 시작 (14.03.12 by 최원석).
	private string _crystalExpendForContinue  ;
	public int CrystalExpendForContinue {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_crystalExpendForContinue = encryptString ;
		}
		get {
			if(_crystalExpendForContinue == null || _crystalExpendForContinue.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_crystalExpendForContinue,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}	
	// 이어하기 수정 - 끝.

	public List<string> m_StringTextList;

	//-----------------------------------
	private void Awake(){
		m_StringTextList = new List<string>();

		_achievementInfoDataList = new List<AchievementInfoData>();
		_achievementInfoMessageDataList = new List<AchievementInfoMessageData>();

		//_submarineBalanceList = new List<GameSubmarineBalance>() ;
		//-------Enemy Pattern
		_stageDataList = new List<StageData>();
		_stageWaveDataList = new List<StageWaveData>();
		_stageEnemyDataList = new List<StageEnemyData>();
				
		_gameItemBalanceList = new List<GameItemBalance>() ;
		_gameItemMessageDataList = new List<GameItemMessageData>() ;

		_saleSubmarineInfoList = new List<SaleSubmarineInfo>();
		_gameSubmarineInfoBalanceList = new List<GameSubmarineInfoBalance>() ;
		_gameSubmarineInfoMessageDataList = new List<GameSubmarineInfoMessageData>() ;

		_shipDescriptionInfoList = new List<ShipDescriptionInfo>();
		_shipStatInfoList = new List<ShipStatInfo>();

		m_SubShipDescriptionInfoList = new List<SubShipDescriptionInfo>();
		m_SubShipStatInfoList = new List<SubShipStatInfo>();
		m_SubShipTactic = new List<SubShipTacTic>();
		m_SubShipGachaDataList = new List<SubShipGachaData>();

		_gameSubmarineBulletInfoBalanceList = new List<GameSubmarineBulletInfoBalance>() ;
		_gameSubmarineEnergyInfoBalanceList = new List<GameSubmarineEnergyInfoBalance>();

		_saleCharacterInfoList = new List<SaleCharacterInfo>();
		_gameCharacterInfoBalanceList = new List<GameCharacterInfoBalance>() ;
		_gameCharacterInfoMessageDataList = new List<GameCharacterInfoMessageData>() ;
		
		_gameTipInfoMessageDataList = new List<GameTipInfoMessageData>() ;
		
		
		_paymentGoldBuyInfoBalanceList = new List<PaymentBuyInfoBalance>() ;
		_paymentJewelBuyInfoBalanceList = new List<PaymentBuyInfoBalance>() ;
		_paymentJewelIOSBuyInfoBalanceList = new List<PaymentBuyInfoBalance>() ;
		_paymentTorpedoBuyInfoBalanceList = new List<PaymentBuyInfoBalance>() ;
		
		_gameSubweaponSlotBalance = new GameSubweaponSlotBalance() ;
		_gameSubweaponPurchaseBalance = new GameSubweaponPurchaseBalance() ;
		_bossEnemyBalance = new BossEnemyBalance() ;
		
		_midBossEnemyBalanceList = new List<MidBossEnemyBalance>() ;

		_gameEndMessageDataList = new List<GameEndMessageData>() ;

		_luckyPresentList = new List<LuckyPresent>();
		_luckyPresentGradeProbabilityList = new List<LuckyPresentGradeProbability>();
		Initialize() ;
		
	}
	
	private void Initialize() {
		
		/*
		VersionInfo = "1.0.0" ;
		
		
		//Init Setting Game Balance Info
		GameLevel = 1 ;
		GameWeightLevel = 0 ;
		
		GameSpeed = 1f ;
		GameSpeedIncrease = 0.003f ;
		
		GameSpeedIncreaseBaseDistance = 1 ;
		GameLevelIncreaseBaseDistance = 50 ;
		GameWeightLevelIncreaseBaseDistance = 150 ;
		GameSpeedMaxValue = 3f ;
		
		
		StartBoosterTime = 5f ;
		StartBoosterSpeed = 9f ;
		LastBoosterTime = 5f ;
		LastBoosterSpeed = 9f ;
		ReviveBoosterTime = 1f ;
		ReviveBoosterSpeed = 7f ;
		
		FeverModeMaxGauge = 200f ;
		FeverModeTime = 8f ;
		FeverModeSpeed = 7f ;
		

		//Init Setting DropItem Balance Info
		MagnetTime = 5f ;
		PowerShotTime = 5f ;
		DobleScoreTime = 5f ;
		BoosterTime = 5f ;
		BoosterSpeed = 7f ;
		
		
		//Init Setting Drop Item Probability Balance Info
		BoosterProbability = 5;
		DoubleScoreProbability = 5;
		MagnetProbability = 5;
		PowerShotProbability = 5;
		GoldProbability = 5 ;
		BigGoldProbability = 5 ;
		
		
		// Init Setting GameSubweaponBalance
		SetGameSubweaponBalance(1, 0f, 1f, 0f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(2, 0f, 2f, 0f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(3, 0.03f, 2f, 0f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(4, 0.05f, 2f, 0f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(5, 0.07f, 3f, 0f, 0f, 0f, 0f, 0) ;
		
		SetGameSubweaponBalance(6, 0f, 0f, 0f, 0.5f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(7, 0f, 0f, 0f, 1f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(8, 0f, 1f, 0f, 1f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(9, 0f, 2f, 0f, 1f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(10, 0f, 3f, 0f, 1.5f, 0f, 0f, 0) ;
		
		SetGameSubweaponBalance(11, 0f, 0f, 0.5f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(12, 0f, 0f, 1f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(13, 0f, 1f, 1f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(14, 0f, 2f, 1f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(15, 0f, 3f, 1.5f, 0f, 0f, 0f, 0) ;
		
		SetGameSubweaponBalance(16, 0f, 0f, 0f, 0f, 0f, 0f, 1) ;
		SetGameSubweaponBalance(17, 0f, 0f, 0f, 0f, 0f, 0f, 3) ;
		SetGameSubweaponBalance(18, 0f, 0f, 0.5f, 0f, 0f, 0f, 3) ;
		SetGameSubweaponBalance(19, 0f, 0f, 1f, 0f, 0f, 0f, 3) ;
		SetGameSubweaponBalance(20, 0f, 0f, 1.5f, 0f, 0f, 0f, 5) ;
		
		SetGameSubweaponBalance(21, 0f, 0f, 0f, 0f, 0.5f, 0f, 0) ;
		SetGameSubweaponBalance(22, 0f, 0f, 0f, 0f, 1f, 0f, 0) ;
		SetGameSubweaponBalance(23, 0f, 1f, 0f, 0f, 1f, 0f, 0) ;
		SetGameSubweaponBalance(24, 0f, 2f, 0f, 0f, 1f, 0f, 0) ;
		SetGameSubweaponBalance(25, 0f, 3f, 0f, 0f, 1.5f, 0f, 0) ;
		
		SetGameSubweaponBalance(26, 0f, 0f, 0f, 0f, 0f, 0.5f, 0) ;
		SetGameSubweaponBalance(27, 0f, 0f, 0f, 0f, 0f, 1f, 0) ;
		SetGameSubweaponBalance(28, 0f, 0f, 0f, 0.5f, 0f, 1f, 0) ;
		SetGameSubweaponBalance(29, 0f, 0f, 0f, 1f, 0f, 1f, 0) ;
		SetGameSubweaponBalance(30, 0f, 0f, 0f, 1.5f, 0f, 1.5f, 0) ;
		
		SetGameSubweaponBalance(31, 0f, 0f, 0.5f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(32, 0f, 0f, 1f, 0f, 0f, 0f, 0) ;
		SetGameSubweaponBalance(33, 0f, 0f, 1f, 0f, 0.5f, 0f, 0) ;
		SetGameSubweaponBalance(34, 0f, 0f, 1f, 0f, 1f, 0f, 0) ;
		SetGameSubweaponBalance(35, 0f, 0f, 1.5f, 0f, 1.5f, 0f, 0) ;
		
		
		// init Setting GameSubweaponAttackBalance
		SetGameSubweaponAttackBalance(1, 1, 1, 1,  0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(2, 2, 1, 1, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(3, 3, 1, 1, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(4, 4, 1, 1, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(5, 5, 1, 1, 0.25f, 10f, 4f) ;
		
		SetGameSubweaponAttackBalance(6, 1, 2, 2, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(7, 2, 2, 2, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(8, 3, 2, 2, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(9, 4, 2, 2, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(10, 5, 2, 2, 0.25f, 10f, 4f) ;
		
		SetGameSubweaponAttackBalance(11, 1, 3, 3, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(12, 2, 3, 3, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(13, 3, 3, 3, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(14, 4, 3, 3, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(15, 5, 3, 3, 0.25f, 10f, 4f) ;
		
		SetGameSubweaponAttackBalance(16, 1, 4, 4, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(17, 2, 4, 4, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(18, 3, 4, 4, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(19, 4, 4, 4, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(20, 5, 4, 4, 0.25f, 10f, 4f) ;
		
		SetGameSubweaponAttackBalance(21, 1, 5, 5, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(22, 2, 5, 5, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(23, 3, 5, 5, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(24, 4, 5, 5, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(25, 5, 5, 5, 0.25f, 10f, 4f) ;
		
		SetGameSubweaponAttackBalance(26, 1, 6, 6, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(27, 2, 6, 6, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(28, 3, 6, 6, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(29, 4, 6, 6, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(30, 5, 6, 6, 0.25f, 10f, 4f) ;
		
		SetGameSubweaponAttackBalance(31, 1, 7, 7, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(32, 2, 7, 7, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(33, 3, 7, 7, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(34, 4, 7, 7, 0.25f, 10f, 4f) ;
		SetGameSubweaponAttackBalance(35, 5, 7, 7, 0.25f, 10f, 4f) ;
		
		
		// Init Setting GameSubweaponSlotBalance
		SetGameSubweaponSlotBalance(1, 10000, 0, false) ;
		
		// Init Setting GameSubweaponPurchaseBalance
		SetGameSubweaponPurchaseBalance(1, 5000, 0, false) ;
		
		
		
		// init Setting EnemyObjectBalance
		SetEnemyObjectBalance(1,50f,10f,0f) ;
		SetEnemyObjectBalance(2,70f,15f,0f) ;
		SetEnemyObjectBalance(3,60f,10f,0f) ;
		SetEnemyObjectBalance(4,60f,15f,0f) ;
		SetEnemyObjectBalance(5,70f,10f,0f) ;
		SetEnemyObjectBalance(6,50f,15f,0f) ;
		SetEnemyObjectBalance(51,1000f,1000f,0f) ; //Mine
		//
		
		// Init Score Data
		Enemy1Score = 20 ;
		Enemy2Score = 30 ;
		Enemy3Score = 40 ;
		Enemy4Score = 40 ;
		Enemy5Score = 50 ;
		Enemy6Score = 60 ;
		EnemyMineScore = 5 ;
		AllKillScore = 100 ;
		
		BossEnemyHeadPartsScore = 100 ;
		BossEnemyFrontPartsScore = 100 ;
		BossEnemyLegsPartsScore = 100 ;
		BossEnemyAllBrokenScore = 100 ;
		//
		
		
		// Init Coin Info
		CoinPatternGold = 1 ;
		CoinPatternBigGold = 5 ;
		CoinDropItemGold = 1 ;
		CoinDropItemBigGold = 5 ;
		
		
		//-- Init Magnet Area Info
		MagnetAreaCharacter = 0.3f ;
		MagnetAreaDropItem = 0.5f ;
		
		
		//-- Boss Controll Data
		BossLuncherNextDistance = 200 ;
		BossLuncherTermDistance = 300 ;
		
		
		
		//-- Init GameItemBalance
		SetGameItemBalance(1,1, 1000,0,false) ; // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
		SetGameItemBalance(2,1, 500,0,false) ; // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
		SetGameItemBalance(3,1, 1000,0,false) ; // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
		SetGameItemBalance(4,1, 2000,0,false) ; // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
		SetGameItemBalance(5,1, 1000,0,false) ; // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
		SetGameItemBalance(6,1, 1500,0,false) ; // 1:StartBooster , 2:Shield , 3:LastBooster , 4:Revive , 5:Brake , 6:EMP
		
		//-- Init GameItemMessageData
		SetGameItemMessageData(1,"StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster","StartBooster") ;
		SetGameItemMessageData(2,"Shield","Shield","Shield","Shield","Shield","Shield","Shield","Shield","Shield","Shield","Shield","Shield") ;
		SetGameItemMessageData(3,"LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster","LastBooster") ;
		SetGameItemMessageData(4,"Revive","Revive","Revive","Revive","Revive","Revive","Revive","Revive","Revive","Revive","Revive","Revive") ;
		SetGameItemMessageData(5,"Brake","Brake","Brake","Brake","Brake","Brake","Brake","Brake","Brake","Brake","Brake","Brake") ;
		SetGameItemMessageData(6,"EMP","EMP","EMP","EMP","EMP","EMP","EMP","EMP","EMP","EMP","EMP","EMP") ;
		
		
		
		
		//-- Init GameSubmarineInfoBalance
		SetGameSubmarineInfoBalance(0, 3, 2, 50, 0, false) ;
		SetGameSubmarineInfoBalance(1, 3, 2, 50, 0, false) ;
		SetGameSubmarineInfoBalance(2, 2, 2, 100, 0, false) ;
		SetGameSubmarineInfoBalance(3, 3, 1, 2000, 0, false) ;
		
		
		//-- Init GameSubmarineInfoBlanace
		SetGameSubmarineInfoMessageData(0, "Submainre0NameEn", "Submarine0MessageEn", "Submainre0NameKo", "Submarine0MessageKo", "Submainre0NameHant", "Submarine0MessageHant", "Submainre0NameHans", "Submarine0MessageHans", "Submainre0NameJa", "Submarine0MessageJa", "Submainre0NameFr", "Submarine0MessageFr") ;
		SetGameSubmarineInfoMessageData(1, "Submainre1NameEn", "Submarine1MessageEn", "Submainre1NameKo", "Submarine1MessageKo", "Submainre1NameHant", "Submarine1MessageHant", "Submainre1NameHans", "Submarine1MessageHans", "Submainre1NameJa", "Submarine1MessageJa", "Submainre1NameFr", "Submarine1MessageFr") ;
		SetGameSubmarineInfoMessageData(2, "Submainre2NameEn", "Submarine2MessageEn", "Submainre2NameKo", "Submarine2MessageKo", "Submainre2NameHant", "Submarine2MessageHant", "Submainre2NameHans", "Submarine2MessageHans", "Submainre2NameJa", "Submarine2MessageJa", "Submainre2NameFr", "Submarine2MessageFr") ;
		SetGameSubmarineInfoMessageData(3, "Submainre3NameEn", "Submarine3MessageEn", "Submainre3NameKo", "Submarine3MessageKo", "Submainre3NameHant", "Submarine3MessageHant", "Submainre3NameHans", "Submarine3MessageHans", "Submainre3NameJa", "Submarine3MessageJa", "Submainre3NameFr", "Submarine3MessageFr") ;
		
		
		
		
		
		//-- Init GameCharacterInfoBalance
		SetGameCharacterInfoBalance(1, 2, 100, 0, false) ;
		SetGameCharacterInfoBalance(2, 2, 250, 0, false) ;
		SetGameCharacterInfoBalance(3, 2, 300, 0, false) ;
		SetGameCharacterInfoBalance(4, 2, 350, 0, false) ;
		SetGameCharacterInfoBalance(5, 1, 2000, 0, false) ;
		
		//-- Init GameCharacterMessageData
		SetGameCharacterMessageData(1, "Character1NameEn", "Character1MessageEn", "Character1NameKo", "Character1MessageKo", "Character1NameHnat", "Character1MessageHant", "Character1NameHans", "Character1MessageHans", "Character1NameJa", "Character1MessageJa", "Character1NameFr", "Character1MessageFr") ;
		SetGameCharacterMessageData(2, "Character2NameEn", "Character2MessageEn", "Character2NameKo", "Character2MessageKo", "Character2NameHnat", "Character2MessageHant", "Character2NameHans", "Character2MessageHans", "Character2NameJa", "Character2MessageJa", "Character2NameFr", "Character2MessageFr") ;
		SetGameCharacterMessageData(3, "Character3NameEn", "Character3MessageEn", "Character3NameKo", "Character3MessageKo", "Character3NameHnat", "Character3MessageHant", "Character3NameHans", "Character3MessageHans", "Character3NameJa", "Character3MessageJa", "Character3NameFr", "Character3MessageFr") ;
		SetGameCharacterMessageData(4, "Character4NameEn", "Character4MessageEn", "Character4NameKo", "Character4MessageKo", "Character4NameHnat", "Character4MessageHant", "Character4NameHans", "Character4MessageHans", "Character4NameJa", "Character4MessageJa", "Character4NameFr", "Character4MessageFr") ;
		SetGameCharacterMessageData(5, "Character5NameEn", "Character5MessageEn", "Character5NameKo", "Character5MessageKo", "Character5NameHnat", "Character5MessageHant", "Character5NameHans", "Character5MessageHans", "Character5NameJa", "Character5MessageJa", "Character5NameFr", "Character5MessageFr") ;
		
		
		
		//-- Init GameSubmarineBulletInfoBalance
		SetGameSubmarineBulletInfoBalance(0,1,1,0,0,false, 0, 0.15f, 40f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,2,1,100,0,false, 0, 0.15f, 43f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,3,1,500,0,false, 0, 0.15f, 46f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,4,1,1000,0,false, 0, 0.15f, 49f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,5,1,1500,0,false, 0, 0.15f, 52f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,6,1,2000,0,false, 0, 0.15f, 55f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,7,1,2500,0,false, 0, 0.15f, 58f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,8,1,3000,0,false, 0, 0.15f, 61f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,9,1,3500,0,false, 0, 0.15f, 64f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,10,1,4000,0,false, 0, 0.15f, 67f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,11,1,4500,0,false, 0, 0.15f, 70f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,12,1,5000,0,false, 0, 0.15f, 73f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,13,1,5500,0,false, 0, 0.15f, 76f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,14,1,6000,0,false, 0, 0.15f, 79f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,15,1,6500,0,false, 0, 0.15f, 82f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,16,1,7000,0,false, 0, 0.15f, 85f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,17,1,7500,0,false, 0, 0.15f, 88f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,18,1,8000,0,false, 0, 0.15f, 91f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,19,1,8500,0,false, 0, 0.15f, 94f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,20,1,9000,0,false, 0, 0.15f, 97f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,21,1,9500,0,false, 0, 0.15f, 100f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,22,1,10000,0,false, 0, 0.15f, 103f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,23,1,10500,0,false, 0, 0.15f, 106f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,24,1,11000,0,false, 0, 0.15f, 109f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,25,1,11500,0,false, 0, 0.15f, 112f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,26,1,12000,0,false, 0, 0.15f, 115f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,27,1,12500,0,false, 0, 0.15f, 118f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,28,1,13000,0,false, 0, 0.15f, 121f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,29,1,13500,0,false, 0, 0.15f, 124f, 4f) ;
		SetGameSubmarineBulletInfoBalance(0,30,1,14000,0,false, 0, 0.15f, 127f, 4f) ;
		
		SetGameSubmarineBulletInfoBalance(1,1,1,0,0,false,  1, 0.25f, 70f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,2,1,100,0,false,  1, 0.25f, 76f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,3,1,500,0,false,  1, 0.25f, 82f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,4,1,1000,0,false,  1, 0.25f, 88f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,5,1,1500,0,false,  1, 0.25f, 94f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,6,1,2000,0,false,  1, 0.25f, 100f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,7,1,2500,0,false,  1, 0.25f, 106f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,8,1,3000,0,false,  1, 0.25f, 112f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,9,1,3500,0,false,  1, 0.25f, 118f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,10,1,4000,0,false,  1, 0.25f, 124f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,11,1,4500,0,false,  1, 0.25f, 130f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,12,1,5000,0,false,  1, 0.25f, 136f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,13,1,5500,0,false,  1, 0.25f, 142f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,14,1,6000,0,false,  1, 0.25f, 148f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,15,1,6500,0,false,  1, 0.25f, 154f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,16,1,7000,0,false,  1, 0.25f, 160f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,17,1,7500,0,false,  1, 0.25f, 166f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,18,1,8000,0,false,  1, 0.25f, 172f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,19,1,8500,0,false,  1, 0.25f, 178f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,20,1,9000,0,false,  1, 0.25f, 184f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,21,1,9500,0,false,  1, 0.25f, 190f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,22,1,10000,0,false,  1, 0.25f, 196f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,23,1,10500,0,false,  1, 0.25f, 202f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,24,1,11000,0,false,  1, 0.25f, 208f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,25,1,11500,0,false,  1, 0.25f, 214f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,26,1,12000,0,false,  1, 0.25f, 220f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,27,1,12500,0,false,  1, 0.25f, 226f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,28,1,13000,0,false,  1, 0.25f, 232f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,29,1,13500,0,false,  1, 0.25f, 238f, 4f) ;
		SetGameSubmarineBulletInfoBalance(1,30,1,14000,0,false,  1, 0.25f, 244f, 4f) ;
		
		SetGameSubmarineBulletInfoBalance(2,1,1,0,0,false,  0, 0.1f, 30f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,2,1,100,0,false,  0, 0.1f, 33f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,3,1,500,0,false,  0, 0.1f, 36f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,4,1,1000,0,false,  0, 0.1f, 39f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,5,1,1500,0,false,  0, 0.1f, 42f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,6,1,2000,0,false,  0, 0.1f, 45f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,7,1,2500,0,false,  0, 0.1f, 48f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,8,1,3000,0,false,  0, 0.1f, 51f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,9,1,3500,0,false,  0, 0.1f, 54f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,10,1,4000,0,false,  0, 0.1f, 57f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,11,1,4500,0,false,  0, 0.1f, 60f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,12,1,5000,0,false,  0, 0.1f, 63f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,13,1,5500,0,false,  0, 0.1f, 66f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,14,1,6000,0,false,  0, 0.1f, 69f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,15,1,6500,0,false,  0, 0.1f, 72f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,16,1,7000,0,false,  0, 0.1f, 75f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,17,1,7500,0,false,  0, 0.1f, 78f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,18,1,8000,0,false,  0, 0.1f, 81f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,19,1,8500,0,false,  0, 0.1f, 84f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,20,1,9000,0,false,  0, 0.1f, 87f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,21,1,9500,0,false,  0, 0.1f, 90f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,22,1,10000,0,false,  0, 0.1f, 93f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,23,1,10500,0,false,  0, 0.1f, 96f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,24,1,11000,0,false,  0, 0.1f, 99f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,25,1,11500,0,false,  0, 0.1f, 102f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,26,1,12000,0,false,  0, 0.1f, 105f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,27,1,12500,0,false,  0, 0.1f, 108f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,28,1,13000,0,false,  0, 0.1f, 111f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,29,1,13500,0,false,  0, 0.1f, 114f, 4f) ;
		SetGameSubmarineBulletInfoBalance(2,30,1,14000,0,false,  0, 0.1f, 117f, 4f) ;
		
		SetGameSubmarineBulletInfoBalance(3,1,1,0,0,false,   0, 0.12f, 50f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,2,1,100,0,false,   0, 0.12f, 55f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,3,1,500,0,false,   0, 0.12f, 60f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,4,1,1000,0,false,   0, 0.12f, 65f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,5,1,1500,0,false,   0, 0.12f, 70f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,6,1,2000,0,false,   0, 0.12f, 75f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,7,1,2500,0,false,   0, 0.12f, 80f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,8,1,3000,0,false,   0, 0.12f, 85f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,9,1,3500,0,false,   0, 0.12f, 90f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,10,1,4000,0,false,   0, 0.12f, 95f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,11,1,4500,0,false,   0, 0.12f, 100f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,12,1,5000,0,false,   0, 0.12f, 105f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,13,1,5500,0,false,   0, 0.12f, 110f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,14,1,6000,0,false,   0, 0.12f, 115f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,15,1,6500,0,false,   0, 0.12f, 120f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,16,1,7000,0,false,   0, 0.12f, 125f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,17,1,7500,0,false,   0, 0.12f, 130f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,18,1,8000,0,false,   0, 0.12f, 135f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,19,1,8500,0,false,   0, 0.12f, 140f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,20,1,9000,0,false,   0, 0.12f, 145f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,21,1,9500,0,false,   0, 0.12f, 150f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,22,1,10000,0,false,   0, 0.12f, 155f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,23,1,10500,0,false,   0, 0.12f, 160f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,24,1,11000,0,false,   0, 0.12f, 165f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,25,1,11500,0,false,   0, 0.12f, 170f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,26,1,12000,0,false,   0, 0.12f, 175f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,27,1,12500,0,false,   0, 0.12f, 180f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,28,1,13000,0,false,   0, 0.12f, 185f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,29,1,13500,0,false,   0, 0.12f, 190f, 4f) ;
		SetGameSubmarineBulletInfoBalance(3,30,1,14000,0,false,   0, 0.12f, 195f, 4f) ;
		
		
		
		//Init Setting GameTipInfoMessageData
		SetGameTipInfoMessageData(1, "Tip1En", "피버 게이지를 모두 모으면 골드피버모드로 들어갈 수 있어요!", "Tip1Hant", "Tip1Hans", "Tip1Ja", "Tip1Fr") ;
		SetGameTipInfoMessageData(2, "Tip2En", "한 번에 나타나는 몬스터 5마리를 모두 제거하면 올킬 보너스를 얻을 수 있습니다.", "Tip2Hant", "Tip2Hans", "Tip2Ja", "Tip2Fr") ;
		SetGameTipInfoMessageData(3, "Tip3En", "무적 상태로 호쾌하게 질주할 수 있습니다.", "Tip3Hant", "Tip3Hans", "Tip3Ja", "Tip3Fr") ;
		SetGameTipInfoMessageData(4, "Tip4En", "무기를 업그레이드 하면 더욱 유리하게 게임을 진행할 수 있습니다.", "Tip4Hant", "Tip4Hans", "Tip4Ja", "Tip4Fr") ;
		SetGameTipInfoMessageData(5, "Tip5En", "다양한 능력을 가진 캐릭터를 사용하면 게임이 더 쉬워집니다.", "Tip5Hant", "Tip5Hans", "Tip5Ja", "Tip5Fr") ;
		SetGameTipInfoMessageData(6, "Tip6En", "헬퍼피쉬는 노멀, 엘리트, 레어, 유니크, 레전드 등급으로 나누어져 있습니다.", "Tip6Hant", "Tip6Hans", "Tip6Ja", "Tip6Fr") ;
		SetGameTipInfoMessageData(7, "Tip7En", "더 멀리 더 많은 몬스터를 사냥할수록 점수가 높아 집니다.", "Tip7Hant", "Tip7Hans", "Tip7Ja", "Tip7Fr") ;
		SetGameTipInfoMessageData(8, "Tip8En", "보스의 공격 패턴을 잘 파악해서 과감한 역습을 시도하세요!", "Tip8Hant", "Tip8Hans", "Tip8Ja", "Tip8Fr") ;
		SetGameTipInfoMessageData(9, "Tip9En", "랭킹은 매주 수요일 초기화를 합니다. 매주 새로운 1등에 도전하세요!", "Tip9Hant", "Tip9Hans", "Tip9Ja", "Tip9Fr") ;
		
		
		
		// Init Setting PaymentBuyInfoBalance
		SetPaymentJewelBuyInfoBalance(1, 3, 0.99f, 2, 10, 0) ;
		SetPaymentJewelBuyInfoBalance(2, 3, 1.99f, 2, 35, 16) ;
		SetPaymentJewelBuyInfoBalance(3, 3, 3.99f, 2, 60, 20) ;
		SetPaymentJewelBuyInfoBalance(4, 3, 9.99f, 2, 130, 30) ;
		SetPaymentJewelBuyInfoBalance(5, 3, 29.99f, 2, 420, 40) ;
		SetPaymentJewelBuyInfoBalance(6, 3, 49.99f, 2, 750, 50) ;
		
		SetPaymentGoldBuyInfoBalance(1, 2, 5, 1, 2500, 0) ;
		SetPaymentGoldBuyInfoBalance(2, 2, 10, 1, 6000, 20) ;
		SetPaymentGoldBuyInfoBalance(3, 2, 20, 1, 14000, 40) ;
		SetPaymentGoldBuyInfoBalance(4, 2, 30, 1, 24000, 60) ;
		SetPaymentGoldBuyInfoBalance(5, 2, 50, 1, 45000, 80) ;
		SetPaymentGoldBuyInfoBalance(6, 2, 100, 1, 100000, 100) ;
		//
		
		
		//Init Setting BossEnemyBalance
		SetBossEnemyBalance(1000, 100, 1000, 100, 1000, 100) ;
		
		*/
		
	}
	//-----------------------------------
	public void ClearAllList(){

		_achievementInfoDataList.Clear();
		_achievementInfoMessageDataList.Clear();

		//_submarineBalanceList.Clear() ;
		_stageDataList.Clear();
		_stageWaveDataList.Clear();
		_stageEnemyDataList.Clear();
		m_StageItemData.Clear();
		m_StageItemSpawnDataList.Clear();

		_gameItemBalanceList.Clear() ;
		_gameItemMessageDataList.Clear() ;
		
		_gameSubmarineInfoBalanceList.Clear() ;
		_gameSubmarineInfoMessageDataList.Clear() ;

		_shipDescriptionInfoList.Clear();
		_shipStatInfoList.Clear();

		m_SubShipDescriptionInfoList.Clear();
		m_SubShipStatInfoList.Clear();
		m_SubShipTactic.Clear();
		m_SubShipGachaDataList.Clear();

		_gameSubmarineBulletInfoBalanceList.Clear() ;
		_gameSubmarineEnergyInfoBalanceList.Clear();

		_gameCharacterInfoBalanceList.Clear() ;
		_gameCharacterInfoMessageDataList.Clear() ;
		
		_gameTipInfoMessageDataList.Clear() ;
		
		
		_paymentGoldBuyInfoBalanceList.Clear() ;
		_paymentJewelBuyInfoBalanceList.Clear() ;
		_paymentJewelIOSBuyInfoBalanceList.Clear() ;
		_paymentTorpedoBuyInfoBalanceList.Clear() ;
	
		
		_midBossEnemyBalanceList.Clear() ;

		_gameEndMessageDataList.Clear() ;
		_luckyPresentList = new List<LuckyPresent>();
		_luckyPresentGradeProbabilityList = new List<LuckyPresentGradeProbability>();
		m_StringTextList.Clear();
	}
	
	
	/*
	// GameSubmarine Balance	
	public GameSubmarineBalance GetGameSubmarineBalance(int indexNumber){
		
		GameSubmarineBalance _selectGameSubmarineBalance = new GameSubmarineBalance();
		
		foreach(GameSubmarineBalance _gsb in _submarineBalanceList) {
			if(_gsb.IndexNumber == indexNumber){
				_selectGameSubmarineBalance = _gsb ;
				break ;
			}
		}
		
		return _selectGameSubmarineBalance ;
	}
	
	public void SetGameSubmarineBalance(GameSubmarineBalance gsb){
		
		int searchIndex = -1 ;
		int parameterIndex = gsb.IndexNumber ;
		
		
		for(int i = 0 ; i < _submarineBalanceList.Count ; i++){
			GameSubmarineBalance _selectGameSubmarineBalance = _submarineBalanceList[i] ;
			if(_selectGameSubmarineBalance.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_submarineBalanceList.Add(gsb) ;
		}else{
			_submarineBalanceList[searchIndex] = gsb ;
		}
		
	}
	
	public void SetGameSubmarineBalance(int indexNumber, float bulletDelayTime, float bulletInitDamage, float bulletIncreaceDamage, float bulletSpeed){
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _submarineBalanceList.Count ; i++){
			GameSubmarineBalance _selectGameSubmarineBalance = _submarineBalanceList[i] ;
			if(_selectGameSubmarineBalance.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		GameSubmarineBalance _gsb = new GameSubmarineBalance() ;
		_gsb.IndexNumber = indexNumber ;
		_gsb.BulletDelayTime = bulletDelayTime ;
		_gsb.BulletInitDamage = bulletInitDamage ;
		_gsb.BulletIncreaceDamage = bulletIncreaceDamage ;
		_gsb.BulletSpeed = bulletSpeed ;
		
		if(searchIndex == -1){ //No Exist
			_submarineBalanceList.Add(_gsb) ;
		}else{
			_submarineBalanceList[searchIndex] = _gsb ;
		}
	}
	*/

	public AchievementInfoData GetAchievementInfoData(int _index)
	{
		AchievementInfoData data = new AchievementInfoData();
		for(int i = 0; i < _achievementInfoDataList.Count; i++)
		{
			if(_achievementInfoDataList[i].IndexNumber == _index)
			{
				data = _achievementInfoDataList[i];
				break;
			}
		}
		return data;
	}

	public string GetAchievementInfoMessage(int _index)
	{
		string missiontext = "";

		AchievementInfoData _achievementdata = new AchievementInfoData();
		for(int i = 0; i < _achievementInfoDataList.Count; i++)
		{
			if(_achievementInfoDataList[i].IndexNumber == _index)
			{
				_achievementdata = _achievementInfoDataList[i];
				break;
			}
		}

		AchievementInfoMessageData data = new AchievementInfoMessageData();
		for(int i = 0; i < _achievementInfoMessageDataList.Count; i++)
	    {
			if(_achievementInfoMessageDataList[i].MissionType == _achievementdata.MissionType)
			{
				data = _achievementInfoMessageDataList[i];
				break;
			}
		}

		if(_achievementdata.MissionType == 1)
		{
			missiontext = TextManager.Instance.GetReplaceString(data.Message, _achievementdata.RequireNumber.ToString());
		}

		return missiontext;
	}

	public StageData GetStageData(int _index)
	{
		for(int i = 0; i < _stageDataList.Count; i++)
		{
			StageData selectedstagedata = _stageDataList[i];
			if(selectedstagedata.Index == _index)
			{
				return selectedstagedata;
			}
		}

		return new StageData();
	}

	public void SetStageData(StageData _stagedata)
	{
		if(_stageDataList == null)
		{
			_stageDataList = new List<StageData>();
		}

		for(int i = 0; i < _stageDataList.Count; i++)
		{
			if(_stageDataList[i].Index == _stagedata.Index)
			{
				_stageDataList[i] = _stagedata;
				return;
			}
		}

		_stageDataList.Add(_stagedata);
	}

	public StageWaveData GetStageWaveData(int _index)
	{
		for(int i = 0; i < _stageWaveDataList.Count; i++)
		{
			StageWaveData selecteddata = _stageWaveDataList[i];
			if(selecteddata.Index == _index)
			{
				return selecteddata;
			}
		}
		
		return new StageWaveData();
	}

	public void SetStageWaveData(StageWaveData _data)
	{
		if(_stageWaveDataList == null)
		{
			_stageWaveDataList = new List<StageWaveData>();
		}
		
		for(int i = 0; i < _stageWaveDataList.Count; i++)
		{
			if(_stageWaveDataList[i].Index == _data.Index)
			{
				_stageWaveDataList[i] = _data;
				return;
			}
		}
		
		_stageWaveDataList.Add(_data);
	}

	public StageEnemyData GetStageEnemyData(int _index)
	{
		for(int i = 0; i < _stageEnemyDataList.Count; i++)
		{
			StageEnemyData enemy = _stageEnemyDataList[i];
			if(enemy.Index == _index)
			{
				return enemy;
			}
		}

		return new StageEnemyData();
	}

	public void SetStageEnemyData(StageEnemyData _enemy)
	{
		if(_stageEnemyDataList == null)
		{
			_stageEnemyDataList = new List<StageEnemyData>();
		}

		for(int i = 0; i < _stageEnemyDataList.Count; i++)
		{
			if(_stageEnemyDataList[i].Index == _enemy.Index)
			{
				_stageEnemyDataList[i] = _enemy;
				return;
			}
		}
		
		_stageEnemyDataList.Add(_enemy);
	}

	public StageItemData GetStageItemData(int _index)
	{
		if(m_StageItemData == null)
		{
			m_StageItemData = new List<StageItemData>();
		}
		for(int i = 0; i < m_StageItemData.Count; i++)
		{
			StageItemData data = m_StageItemData[i];
			if(data.Index == _index)
			{
				return data;
			}
		}
		return new StageItemData();
	}
		
	public void SetStageItemData(StageItemData _data)
	{
		if(m_StageItemData == null)
		{
			m_StageItemData = new List<StageItemData>();
		}
		StageItemData data = _data;
		for(int i = 0; i < m_StageItemData.Count; i++)
		{
			if(m_StageItemData[i].Index == data.Index)
			{
				m_StageItemData[i] = data;
				return;
			}
		}

		m_StageItemData.Add(data);
	}

	public StageItemSpawnData GetStageItemSpawnData(int _index)
	{
		if(m_StageItemSpawnDataList == null)
		{
			m_StageItemSpawnDataList = new List<StageItemSpawnData>();
		}
		for(int i = 0; i < m_StageItemSpawnDataList.Count; i++)
		{
			StageItemSpawnData data = m_StageItemSpawnDataList[i];
			if(data.Index == _index)
			{
				return data;
			}
		}
		return new StageItemSpawnData();
	}
	
	public void SetStageItemSpawnData(StageItemSpawnData _data)
	{
		if(m_StageItemSpawnDataList == null)
		{
			m_StageItemSpawnDataList = new List<StageItemSpawnData>();
		}
		StageItemSpawnData data = _data;
		for(int i = 0; i < m_StageItemSpawnDataList.Count; i++)
		{
			if(m_StageItemSpawnDataList[i].Index == data.Index)
			{
				m_StageItemSpawnDataList[i] = data;
				return;
			}
		}
		
		m_StageItemSpawnDataList.Add(data);
	}
	// Game item Balance
	public GameItemBalance GetGameItemBalance(int itemType){
		
		GameItemBalance selectGameItemBalance = new GameItemBalance() ;
		
		foreach(GameItemBalance _gib in _gameItemBalanceList) {
			if(_gib.ItemType == itemType){
				selectGameItemBalance = _gib ;
				break ;
			}
		}
		
		return selectGameItemBalance ;
	}
	
	
	public void SetGameItemBalance(GameItemBalance gib){
		
		int searchIndex = -1 ;
		int parameterIndex = gib.ItemType ;
		
		for(int i = 0 ; i < _gameItemBalanceList.Count ; i++){
			GameItemBalance _selectGameItemBalance = _gameItemBalanceList[i] ;
			if(_selectGameItemBalance.ItemType == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameItemBalanceList.Add(gib) ;
		}else{
			_gameItemBalanceList[searchIndex] = gib ;
		}
		
	}
	
	
	public void SetGameItemBalance(int itemType, int valueType, int itemValue, int itemPreviousValue, bool isDiscount) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _gameItemBalanceList.Count ; i++){
			GameItemBalance _selectGameItemBalance = _gameItemBalanceList[i] ;
			if(_selectGameItemBalance.ItemType == itemType){
				searchIndex = i ;
				break ;
			}
		}
		
		GameItemBalance _gib = new GameItemBalance() ;
		_gib.ItemType = itemType ;
		_gib.ValueType = valueType ;
		_gib.ItemValue = itemValue ;
		_gib.ItemPreviousValue = itemPreviousValue ;
		_gib.IsDiscount = isDiscount ;
		
		
		if(searchIndex == -1){ //No Exist
			_gameItemBalanceList.Add(_gib) ;
		}else{
			_gameItemBalanceList[searchIndex] = _gib ;
		}
		
	}
	

	//--- GameItemMessageData
	public void SetGameItemMessageData(GameItemMessageData gmd){
		
		int searchIndex = -1 ;
		int parameterIndex = gmd.ItemType ;
		
		
		for(int i = 0 ; i < _gameItemMessageDataList.Count ; i++){
			GameItemMessageData _selectGameItemMessageData = _gameItemMessageDataList[i] ;
			if(_selectGameItemMessageData.ItemType == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameItemMessageDataList.Add(gmd) ;
		}else{
			_gameItemMessageDataList[searchIndex] = gmd ;
		}
		
		
	}
		
	public void SetGameItemMessageData(int itemType, 
														string gameItemNameEn, string gameItemMessageEn, 
														string gameItemNameKo, string gameItemMessageKo, 
														string gameItemNameHant, string gameItemMessageHant, 
														string gameItemNameHans, string gameItemMessageHans, 
														string gameItemNameJa, string gameItemMessageJa, 
														string gameItemNameFr, string gameItemMessageFr ){
		
		int searchIndex = -1 ;
		
		
		for(int i = 0 ; i < _gameItemMessageDataList.Count ; i++){
			GameItemMessageData _selectGameItemMessageData = _gameItemMessageDataList[i] ;
			if(_selectGameItemMessageData.ItemType == itemType){
				searchIndex = i ;
				break ;
			}
		}
		
		
		GameItemMessageData _gmd = new GameItemMessageData() ;
		_gmd.ItemType = itemType ;
		_gmd.GameItemNameEn = gameItemNameEn ;
		_gmd.GameItemMessageEn = gameItemMessageEn ;
		_gmd.GameItemNameKo = gameItemNameKo ;
		_gmd.GameItemMessageKo = gameItemMessageKo ;
		_gmd.GameItemNameHant = gameItemNameHant ;
		_gmd.GameItemMessageHant = gameItemMessageHant ;
		_gmd.GameItemNameHans = gameItemNameHans ;
		_gmd.GameItemMessageHans = gameItemMessageHans ;
		_gmd.GameItemNameJa = gameItemNameJa ;
		_gmd.GameItemMessageJa = gameItemMessageJa ;
		_gmd.GameItemNameFr = gameItemNameFr ;
		_gmd.GameItemMessageFr = gameItemMessageFr ;
		
		
		if(searchIndex == -1){ //No Exist
			_gameItemMessageDataList.Add(_gmd) ;
		}else{
			_gameItemMessageDataList[searchIndex] = _gmd ;
		}
		
	}
	
	public string GetGameItemName(int itemType, string languageCode){
		
		string selectGameItemName = null ;
		
		foreach(GameItemMessageData _gmd in _gameItemMessageDataList) {
			if(_gmd.ItemType == itemType){
				if(languageCode.Equals("En")){
					selectGameItemName = _gmd.GameItemNameEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameItemName = _gmd.GameItemNameKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameItemName = _gmd.GameItemNameHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameItemName = _gmd.GameItemNameHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameItemName = _gmd.GameItemNameJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameItemName = _gmd.GameItemNameFr ;
				}
				break ;
			}
		}
		
		return selectGameItemName ;
	}

	public GameItemMessageData GetGameItemMessage(int itemType)
	{
		GameItemMessageData selectGameItemName = new GameItemMessageData() ;

		foreach(GameItemMessageData _gmd in _gameItemMessageDataList) {
			if(_gmd.ItemType == itemType){
				selectGameItemName = _gmd;
				break ;
			}
		}
		return selectGameItemName;
	}

	public string GetGameItemMessage(int itemType, string languageCode){
		
		string selectGameItemMessage = null ;
		
		
		
		foreach(GameItemMessageData _gmd in _gameItemMessageDataList) {
			if(_gmd.ItemType == itemType){
				if(languageCode.Equals("En")){
					selectGameItemMessage = _gmd.GameItemMessageEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameItemMessage = _gmd.GameItemMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameItemMessage = _gmd.GameItemMessageHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameItemMessage = _gmd.GameItemMessageHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameItemMessage = _gmd.GameItemMessageJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameItemMessage = _gmd.GameItemMessageFr ;
				}
				break ;
			}
		}
		
		
		return selectGameItemMessage ;
	}
	
	
	public List<SaleSubmarineInfo> GetSaleSubmarineInfoList()
	{
		return _saleSubmarineInfoList;
	}

	public SaleSubmarineInfo GetSaleSubmarineInfoBalance(int indexNumber){
		
		SaleSubmarineInfo selectSaleSubmarineInfoBalance = new SaleSubmarineInfo() ;
		
		foreach(SaleSubmarineInfo _gsib in _saleSubmarineInfoList) {
			if(_gsib.IndexNumber == indexNumber){
				selectSaleSubmarineInfoBalance = _gsib ;
				break ;
			}
		}
		
		return selectSaleSubmarineInfoBalance ;
	}


	public List<GameSubmarineInfoBalance> GetGameSubmarinInfoList()
	{
		return _gameSubmarineInfoBalanceList;
	}
	
	// GameSubmarineInfoBalance
	public GameSubmarineInfoBalance GetGameSubmarineInfoBalance(int indexNumber){
		
		GameSubmarineInfoBalance selectGameSubmarineInfoBalance = new GameSubmarineInfoBalance() ;
		
		foreach(GameSubmarineInfoBalance _gsib in _gameSubmarineInfoBalanceList) {
			if(_gsib.IndexNumber == indexNumber){
				selectGameSubmarineInfoBalance = _gsib ;
				break ;
			}
		}
		
		return selectGameSubmarineInfoBalance ;
	}
	
	
	public void SetGameSubmarineInfoBalance(GameSubmarineInfoBalance gsib){
		
		int searchIndex = -1 ;
		int parameterIndex = gsib.IndexNumber ;
		
		for(int i = 0 ; i < _gameSubmarineInfoBalanceList.Count ; i++){
			GameSubmarineInfoBalance _selectGameSubmarineInfoBalance = _gameSubmarineInfoBalanceList[i] ;
			if(_selectGameSubmarineInfoBalance.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineInfoBalanceList.Add(gsib) ;
		}else{
			_gameSubmarineInfoBalanceList[searchIndex] = gsib ;
		}
		
	}
	
	
	public void SetGameSubmarineInfoBalance(int indexNumber, int submarineGrade, int valueType, int submarineValue, int submarinePreviousValue, bool isDiscount,
	                                        int _requiredAchievement) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _gameSubmarineInfoBalanceList.Count ; i++){
			GameSubmarineInfoBalance _selectGameSubmarineInfoBalance = _gameSubmarineInfoBalanceList[i] ;
			if(_selectGameSubmarineInfoBalance.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		GameSubmarineInfoBalance _gsib = new GameSubmarineInfoBalance() ;
		_gsib.IndexNumber = indexNumber ;
		_gsib.SubmarineGrade = submarineGrade ;
		_gsib.ValueType = valueType ;
		_gsib.SubmarineValue = submarineValue ;
		_gsib.SubmarinePreviousValue = submarinePreviousValue ;
		_gsib.IsDiscount = isDiscount ;
		_gsib.RequiredAchievement = _requiredAchievement;
		if(searchIndex == -1){ //No Exist
			_gameSubmarineInfoBalanceList.Add(_gsib) ;
		}else{
			_gameSubmarineInfoBalanceList[searchIndex] = _gsib ;
		}
		
	}
	
	
	
	//--- GameSubmarineInfoMessageData
	public void SetGameSubmarineInfoMessageData(GameSubmarineInfoMessageData gsimd){
		
		int searchIndex = -1 ;
		int parameterIndex = gsimd.IndexNumber ;
		
		
		for(int i = 0 ; i < _gameSubmarineInfoMessageDataList.Count ; i++){
			GameSubmarineInfoMessageData _selectGameSubmarineInfoMessageData = _gameSubmarineInfoMessageDataList[i] ;
			if(_selectGameSubmarineInfoMessageData.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineInfoMessageDataList.Add(gsimd) ;
		}else{
			_gameSubmarineInfoMessageDataList[searchIndex] = gsimd ;
		}
		
		
	}
		
	public void SetGameSubmarineInfoMessageData(int indexNumber, 
														string gameSubmarineNameEn, string gameSubmarineMessageEn, 
														string gameSubmarineNameko, string gameSubmarineMessageKo, 
														string gameSubmarineNameHant, string gameSubmarineMessageHant, 
														string gameSubmarineNameHans, string gameSubmarineMessageHans, 
														string gameSubmarineNameJa, string gameSubmarineMessageJa, 
														string gameSubmarineNameFr, string gameSubmarineMessageFr ){
		
		int searchIndex = -1 ;
		
		
		for(int i = 0 ; i < _gameSubmarineInfoMessageDataList.Count ; i++){
			GameSubmarineInfoMessageData _selectGameSubmarineInfoMessageData = _gameSubmarineInfoMessageDataList[i] ;
			if(_selectGameSubmarineInfoMessageData.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		GameSubmarineInfoMessageData _gsimd = new GameSubmarineInfoMessageData() ;
		_gsimd.IndexNumber = indexNumber ;
		_gsimd.GameSubmarineNameEn = gameSubmarineNameEn ;
		_gsimd.GameSubmarineMessageEn = gameSubmarineMessageEn ;
		_gsimd.GameSubmarineNameKo = gameSubmarineNameko ;
		_gsimd.GameSubmarineMessageKo = gameSubmarineMessageKo ;
		_gsimd.GameSubmarineNameHant = gameSubmarineNameHant ;
		_gsimd.GameSubmarineMessageHant = gameSubmarineMessageHant ;
		_gsimd.GameSubmarineNameHans = gameSubmarineNameHans ;
		_gsimd.GameSubmarineMessageHans = gameSubmarineMessageHans ;
		_gsimd.GameSubmarineNameJa = gameSubmarineNameJa ;
		_gsimd.GameSubmarineMessageJa = gameSubmarineMessageJa ;
		_gsimd.GameSubmarineNameFr = gameSubmarineNameFr ;
		_gsimd.GameSubmarineMessageFr = gameSubmarineMessageFr ;
		
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineInfoMessageDataList.Add(_gsimd) ;
		}else{
			_gameSubmarineInfoMessageDataList[searchIndex] = _gsimd ;
		}
		
	}
	
	public string GetGameSubmarineName(int indexNumber, string languageCode){
		
		string selectGameSubmarineName = null ;
		
		foreach(GameSubmarineInfoMessageData _gsimd in _gameSubmarineInfoMessageDataList) {
			if(_gsimd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectGameSubmarineName = _gsimd.GameSubmarineNameEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameSubmarineName = _gsimd.GameSubmarineNameKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameSubmarineName = _gsimd.GameSubmarineNameHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameSubmarineName = _gsimd.GameSubmarineNameHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameSubmarineName = _gsimd.GameSubmarineNameJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameSubmarineName = _gsimd.GameSubmarineNameFr ;
				}
				break ;
			}
		}
		
		return selectGameSubmarineName ;
		
	}
	
	public string GetGameSubmarineMessage(int indexNumber, string languageCode){
		
		string selectGameSubmarineMessage = null ;
		
		foreach(GameSubmarineInfoMessageData _gsimd in _gameSubmarineInfoMessageDataList) {
			if(_gsimd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectGameSubmarineMessage = _gsimd.GameSubmarineMessageEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameSubmarineMessage = _gsimd.GameSubmarineMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameSubmarineMessage = _gsimd.GameSubmarineMessageHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameSubmarineMessage = _gsimd.GameSubmarineMessageHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameSubmarineMessage = _gsimd.GameSubmarineMessageJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameSubmarineMessage = _gsimd.GameSubmarineMessageFr ;
				}
				break ;
			}
		}
		
		return selectGameSubmarineMessage ;
	}

	public ShipDescriptionInfo GetShipDescriptionInfo(int _index)
	{
		if(_shipDescriptionInfoList == null)
		{
			_shipDescriptionInfoList = new List<ShipDescriptionInfo>();
		}

		ShipDescriptionInfo data = new ShipDescriptionInfo();
		for(int i = 0; i < _shipDescriptionInfoList.Count; i++)
		{
			if(_shipDescriptionInfoList[i].ShipIndex == _index)
			{
				data = _shipDescriptionInfoList[i];
				break;;
			}
		}
		return data;
	}

	/// <summary>
	/// start from 1
	/// </summary>
	public ShipDescriptionInfo GetShipDescriptionInfoByDisplayIndex(int _index)
	{
		if(_shipDescriptionInfoList == null)
		{
			_shipDescriptionInfoList = new List<ShipDescriptionInfo>();
		}
		
		ShipDescriptionInfo data = new ShipDescriptionInfo();
		for(int i = 0; i < _shipDescriptionInfoList.Count; i++)
		{
			if(_shipDescriptionInfoList[i].ShipDisplayIndex == _index)
			{
				data = _shipDescriptionInfoList[i];
				break;;
			}
		}
		return data;
	}

	public ShipStatInfo GetShipStatInfo(int _index, int _level)
	{
		if(_shipStatInfoList == null)
		{
			_shipStatInfoList = new List<ShipStatInfo>();
		}

		ShipStatInfo info = new ShipStatInfo();
		for(int i = 0; i < _shipStatInfoList.Count; i++)
		{
			if(_shipStatInfoList[i].ShipIndex == _index && _shipStatInfoList[i].ShipLevel == _level)
			{
				info = _shipStatInfoList[i];
				break;
			}
		}
		return info;
	}	
	
	public void SetShipStatInfo(ShipStatInfo _info)
	{
		if(_shipStatInfoList == null)
		{
			_shipStatInfoList = new List<ShipStatInfo>();
		}

		ShipStatInfo info = _info;
		bool add = true;
		for(int i = 0; i < _shipStatInfoList.Count; i++)
		{
			if(_shipStatInfoList[i].ShipIndex == _info.ShipIndex &&
			   _shipStatInfoList[i].ShipLevel == _info.ShipLevel)
			{
				_shipStatInfoList[i] = _info;
				add = false;
				break;
			}
		}

		if(add)
		{
			_shipStatInfoList.Add(info);
		}
	}

	public SubShipStatInfo GetSubShipStatInfo(int _index, int _level)
	{
		if(m_SubShipStatInfoList == null)
		{
			m_SubShipStatInfoList = new List<SubShipStatInfo>();
		}

		SubShipStatInfo info = new SubShipStatInfo();
		for(int i = 0; i < m_SubShipStatInfoList.Count; i++)
		{
			if(m_SubShipStatInfoList[i].ShipIndex == _index && m_SubShipStatInfoList[i].ShipLevel == _level)
			{
				info = m_SubShipStatInfoList[i];
				break;
			}
		}

		return info;
	}

	public void SetSubShipStatInfo(SubShipStatInfo _info)
	{
		if(m_SubShipStatInfoList == null)
		{
			m_SubShipStatInfoList = new List<SubShipStatInfo>();
		}

		SubShipStatInfo info = _info;
		for(int i = 0; i < m_SubShipStatInfoList.Count; i++)
		{
			if(m_SubShipStatInfoList[i].ShipIndex == info.ShipIndex &&
			   m_SubShipStatInfoList[i].ShipLevel == info.ShipLevel)
			{
				m_SubShipStatInfoList[i] = info;
				return;
			}
		}

		m_SubShipStatInfoList.Add(info);
	}

	public SubShipDescriptionInfo GetSubShipDescriptionInfo(int _index)
	{
		if(m_SubShipDescriptionInfoList == null)
		{
			m_SubShipDescriptionInfoList = new List<SubShipDescriptionInfo>();
		}
		
		SubShipDescriptionInfo info = new SubShipDescriptionInfo();
		for(int i = 0; i < m_SubShipDescriptionInfoList.Count; i++)
		{
			if(m_SubShipDescriptionInfoList[i].ShipIndex == _index)
			{
				info = m_SubShipDescriptionInfoList[i];
				break;
			}
		}
		return info;
	}


	public void SetSubShipDescriptionInfo(SubShipDescriptionInfo _info)
	{
		if(m_SubShipDescriptionInfoList == null)
		{
			m_SubShipDescriptionInfoList = new List<SubShipDescriptionInfo>();
		}
		
		SubShipDescriptionInfo info = _info;
		for(int i = 0; i < m_SubShipDescriptionInfoList.Count; i++)
		{
			if(m_SubShipDescriptionInfoList[i].ShipIndex == info.ShipIndex)
			{
				m_SubShipDescriptionInfoList[i] = info;
				return;
			}
		}
		
		m_SubShipDescriptionInfoList.Add(info);
	}

	// GameSubmarineBulletInfoBalance
	public GameSubmarineBulletInfoBalance GetGameSubmarineBulletInfoBalance(int submarineIndexNumber, int bulletIndexNumber){
		
		GameSubmarineBulletInfoBalance selectGameSubmarineBulletInfoBalance = new GameSubmarineBulletInfoBalance() ;
		
		foreach(GameSubmarineBulletInfoBalance _gsbib in _gameSubmarineBulletInfoBalanceList) {
			if(_gsbib.SubmarineIndexNumber == submarineIndexNumber && _gsbib.BulletIndexNumber == bulletIndexNumber){
				selectGameSubmarineBulletInfoBalance = _gsbib ;
				break ;
			}
		}
		
		return selectGameSubmarineBulletInfoBalance ;
	}
	
	
	public void SetGameSubmarineBulletInfoBalance(GameSubmarineBulletInfoBalance gsbib){
		
		int searchIndex = -1 ;
		int parameterSubmarineIndex = gsbib.SubmarineIndexNumber ;
		int parameterBulletIndex = gsbib.BulletIndexNumber ;
		
		for(int i = 0 ; i < _gameSubmarineBulletInfoBalanceList.Count ; i++){
			GameSubmarineBulletInfoBalance _selectGameSubmarineBulletInfoBalance = _gameSubmarineBulletInfoBalanceList[i] ;
			if(_selectGameSubmarineBulletInfoBalance.SubmarineIndexNumber == parameterSubmarineIndex && _selectGameSubmarineBulletInfoBalance.BulletIndexNumber == parameterBulletIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineBulletInfoBalanceList.Add(gsbib) ;
		}else{
			_gameSubmarineBulletInfoBalanceList[searchIndex] = gsbib ;
		}
		
	}
	
	
	public void SetGameSubmarineBulletInfoBalance(int submarineIndexNumber, int bulletIndexNumber, int valueType, int bulletValue, int bulletPreviousValue, bool isDiscount,
																		int bulletType, float bulletDelayTime, float bulletDamage, float bulletSpeed, float sloweffect) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _gameSubmarineBulletInfoBalanceList.Count ; i++){
			GameSubmarineBulletInfoBalance _selectGameSubmarineBulletInfoBalance = _gameSubmarineBulletInfoBalanceList[i] ;
			if(_selectGameSubmarineBulletInfoBalance.SubmarineIndexNumber == submarineIndexNumber && _selectGameSubmarineBulletInfoBalance.BulletIndexNumber == bulletIndexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		GameSubmarineBulletInfoBalance _gsbib = new GameSubmarineBulletInfoBalance() ;
		_gsbib.SubmarineIndexNumber = submarineIndexNumber ;
		_gsbib.BulletIndexNumber = bulletIndexNumber ;
		_gsbib.ValueType = valueType ;
		_gsbib.BulletValue = bulletValue ;
		_gsbib.BulletPreviousValue = bulletPreviousValue ;
		_gsbib.IsDiscount = isDiscount ;
		
		_gsbib.BulletType = bulletType ;
		_gsbib.BulletDelayTime = bulletDelayTime ;
		_gsbib.BulletDamage = bulletDamage ;
		_gsbib.BulletSpeed = bulletSpeed ;
		_gsbib.SlowEffect = sloweffect;
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineBulletInfoBalanceList.Add(_gsbib) ;
		}else{
			_gameSubmarineBulletInfoBalanceList[searchIndex] = _gsbib ;
		}
		
	}

	// GameSubmarineEnergyInfoBalance
	public GameSubmarineEnergyInfoBalance GetGameSubmarineEnergyInfoBalance(int submarineIndexNumber, int level){
		
		GameSubmarineEnergyInfoBalance selectGameSubmarineEnergyInfoBalance = new GameSubmarineEnergyInfoBalance() ;
		
		foreach(GameSubmarineEnergyInfoBalance _gsbib in _gameSubmarineEnergyInfoBalanceList) {
			if(_gsbib.SubmarineIndexNumber == submarineIndexNumber && _gsbib.EnergyLevel == level){
				selectGameSubmarineEnergyInfoBalance = _gsbib ;
				break ;
			}
		}
		
		return selectGameSubmarineEnergyInfoBalance ;
	}
	
	
	public void SetGameSubmarineEnergyInfoBalance(GameSubmarineEnergyInfoBalance gsbib){
		
		int searchIndex = -1 ;
		int parameterSubmarineIndex = gsbib.SubmarineIndexNumber ;
		int level = gsbib.EnergyLevel ;
		
		for(int i = 0 ; i < _gameSubmarineEnergyInfoBalanceList.Count ; i++){
			GameSubmarineEnergyInfoBalance _selectGameSubmarineEnergyInfoBalance = _gameSubmarineEnergyInfoBalanceList[i] ;
			if(_selectGameSubmarineEnergyInfoBalance.SubmarineIndexNumber == parameterSubmarineIndex 
			   && _selectGameSubmarineEnergyInfoBalance.EnergyLevel == level){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineEnergyInfoBalanceList.Add(gsbib) ;
		}else{
			_gameSubmarineEnergyInfoBalanceList[searchIndex] = gsbib ;
		}
		
	}
	
	
	public void SetGameSubmarineEnergyInfoBalance(int submarineIndexNumber, int level, int valueType, int costvalue, 
	                                              int costpreviousvalue, 
	                                              bool isDiscount,
	                                              float energyamount,
	                                              float _hitdamageamount) {

		if(_gameSubmarineEnergyInfoBalanceList == null)
		{
			_gameSubmarineEnergyInfoBalanceList = new List<GameSubmarineEnergyInfoBalance>();
		}

		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _gameSubmarineEnergyInfoBalanceList.Count ; i++){
			GameSubmarineEnergyInfoBalance _selectGameSubmarineEnergyInfoBalance = _gameSubmarineEnergyInfoBalanceList[i] ;
			if(_selectGameSubmarineEnergyInfoBalance.SubmarineIndexNumber == submarineIndexNumber && _selectGameSubmarineEnergyInfoBalance.EnergyLevel == level){
				searchIndex = i ;
				break ;
			}
		}
		
		GameSubmarineEnergyInfoBalance _gsbib = new GameSubmarineEnergyInfoBalance() ;
		_gsbib.SubmarineIndexNumber = submarineIndexNumber ;
		_gsbib.EnergyLevel = level ;
		_gsbib.ValueType = valueType ;
		_gsbib.CostValue = costvalue ;
		_gsbib.CostPreviousValue = costpreviousvalue ;
		_gsbib.IsDiscount = isDiscount ;
		
		_gsbib.EnergyAmount = energyamount ;
		_gsbib.HitDamageAmount = _hitdamageamount;
		
		if(searchIndex == -1){ //No Exist
			_gameSubmarineEnergyInfoBalanceList.Add(_gsbib) ;
		}else{
			_gameSubmarineEnergyInfoBalanceList[searchIndex] = _gsbib ;
		}
		
	}

	public List<SaleCharacterInfo> GetSaleCharacterInfoBalanceList()
	{
		return _saleCharacterInfoList;
	}

	public SaleCharacterInfo GetSaleCharacterInfoBalance(int indexNumber){
		
		SaleCharacterInfo selectGameCharacterInfoBalance = new SaleCharacterInfo() ;
		
		foreach(SaleCharacterInfo _gcib in _saleCharacterInfoList) {
			if(_gcib.IndexNumber == indexNumber){
				selectGameCharacterInfoBalance = _gcib ;
				break ;
			}
		}
		
		return selectGameCharacterInfoBalance ;
	}

	public List<GameCharacterInfoBalance> GetGameCharacterInfoBalanceList()
	{
		return _gameCharacterInfoBalanceList;
	}

	// GameCharacterInfoBalance
	public GameCharacterInfoBalance GetGameCharacterInfoBalance(int indexNumber){
		
		GameCharacterInfoBalance selectGameCharacterInfoBalance = new GameCharacterInfoBalance() ;
		
		foreach(GameCharacterInfoBalance _gcib in _gameCharacterInfoBalanceList) {
			if(_gcib.IndexNumber == indexNumber){
				selectGameCharacterInfoBalance = _gcib ;
				break ;
			}
		}
		
		return selectGameCharacterInfoBalance ;
	}
	
	
	public void SetGameCharacterInfoBalance(GameCharacterInfoBalance gcib){
		
		int searchIndex = -1 ;
		int parameterIndex = gcib.IndexNumber ;
		
		for(int i = 0 ; i < _gameCharacterInfoBalanceList.Count ; i++){
			GameCharacterInfoBalance _selectGameCharacterInfoBalance = _gameCharacterInfoBalanceList[i] ;
			if(_selectGameCharacterInfoBalance.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameCharacterInfoBalanceList.Add(gcib) ;
		}else{
			_gameCharacterInfoBalanceList[searchIndex] = gcib ;
		}
		
	}
	
	
	public void SetGameCharacterInfoBalance(int indexNumber, int valueType, int characterValue, int characterPreviousValue, bool isDiscount) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _gameCharacterInfoBalanceList.Count ; i++){
			GameCharacterInfoBalance _selectGameCharacterInfoBalance = _gameCharacterInfoBalanceList[i] ;
			if(_selectGameCharacterInfoBalance.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		GameCharacterInfoBalance _gcib = new GameCharacterInfoBalance() ;
		_gcib.IndexNumber = indexNumber ;
		_gcib.ValueType = valueType ;
		_gcib.CharacterValue = characterValue ;
		_gcib.CharacterPreviousValue = characterPreviousValue ;
		_gcib.IsDiscount = isDiscount ;
		
		if(searchIndex == -1){ //No Exist
			_gameCharacterInfoBalanceList.Add(_gcib) ;
		}else{
			_gameCharacterInfoBalanceList[searchIndex] = _gcib ;
		}
		
	}
	
	
	//--- GameCharacterInfoMessageData
	public void SetGameCharacterInfoMessageData(GameCharacterInfoMessageData gcimd){
		
		int searchIndex = -1 ;
		int parameterIndex = gcimd.IndexNumber ;
		
		
		for(int i = 0 ; i < _gameCharacterInfoMessageDataList.Count ; i++){
			GameCharacterInfoMessageData _selectGameCharacterInfoMessageData = _gameCharacterInfoMessageDataList[i] ;
			if(_selectGameCharacterInfoMessageData.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameCharacterInfoMessageDataList.Add(gcimd) ;
		}else{
			_gameCharacterInfoMessageDataList[searchIndex] = gcimd ;
		}
		
		
	}
		
	public void SetGameCharacterMessageData(int indexNumber, 
														string gameCharacterNameEn, string gameCharacterMessageEn, 
														string gameCharacterNameKo, string gameCharacterMessageKo, 
														string gameCharacterNameHant, string gameCharacterMessageHant, 
														string gameCharacterNameHans, string gameCharacterMessageHans, 
														string gameCharacterNameJa, string gameCharacterMessageJa, 
														string gameCharacterNameFr, string gameCharacterMessageFr,
	                                        string GameCharacterSpecialMessageKo){
		
		int searchIndex = -1 ;
		
		
		for(int i = 0 ; i < _gameCharacterInfoMessageDataList.Count ; i++){
			GameCharacterInfoMessageData _selectGameCharacterInfoMessageData = _gameCharacterInfoMessageDataList[i] ;
			if(_selectGameCharacterInfoMessageData.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		GameCharacterInfoMessageData _gcimd = new GameCharacterInfoMessageData() ;
		_gcimd.IndexNumber = indexNumber ;
		_gcimd.GameCharacterNameEn = gameCharacterNameEn ;
		_gcimd.GameCharacterMessageEn = gameCharacterMessageEn ;
		_gcimd.GameCharacterNameKo = gameCharacterNameKo ;
		_gcimd.GameCharacterMessageKo = gameCharacterMessageKo ;
		_gcimd.GameCharacterNameHant = gameCharacterNameHant ;
		_gcimd.GameCharacterMessageHant = gameCharacterMessageHant ;
		_gcimd.GameCharacterNameHans = gameCharacterNameHans ;
		_gcimd.GameCharacterMessageHans = gameCharacterMessageHans ;
		_gcimd.GameCharacterNameJa = gameCharacterNameJa ;
		_gcimd.GameCharacterMessageJa = gameCharacterMessageJa ;
		_gcimd.GameCharacterNameFr = gameCharacterNameFr ;
		_gcimd.GameCharacterMessageFr = gameCharacterMessageFr ;
		_gcimd.GameCharacterSpecialMessageKo = GameCharacterSpecialMessageKo;
		
		if(searchIndex == -1){ //No Exist
			_gameCharacterInfoMessageDataList.Add(_gcimd) ;
		}else{
			_gameCharacterInfoMessageDataList[searchIndex] = _gcimd ;
		}
		
	}
	
	public string GetGameCharacterName(int indexNumber, string languageCode){
		
		string selectGameCharacterName = null ;
		
		foreach(GameCharacterInfoMessageData _gcimd in _gameCharacterInfoMessageDataList) {
			if(_gcimd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectGameCharacterName = _gcimd.GameCharacterNameEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameCharacterName = _gcimd.GameCharacterNameKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameCharacterName = _gcimd.GameCharacterNameHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameCharacterName = _gcimd.GameCharacterNameHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameCharacterName = _gcimd.GameCharacterNameJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameCharacterName = _gcimd.GameCharacterNameFr ;
				}
				break ;
			}
		}
		
		return selectGameCharacterName ;
	}

	public GameCharacterInfoMessageData GetGameCharacterInfoMessage(int _index)
	{
		foreach(GameCharacterInfoMessageData _gcimd in _gameCharacterInfoMessageDataList) {
			if(_gcimd.IndexNumber == _index){
				return _gcimd;
			}
		}	
		
		return new GameCharacterInfoMessageData() ;
	}

	public string GetGameCharacterMessage(int indexNumber, string languageCode = "Ko"){
		
		string selectGameCharacterMessage = null ;
		
		foreach(GameCharacterInfoMessageData _gcimd in _gameCharacterInfoMessageDataList) {
			if(_gcimd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectGameCharacterMessage = _gcimd.GameCharacterMessageEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameCharacterMessage = _gcimd.GameCharacterMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameCharacterMessage = _gcimd.GameCharacterMessageHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameCharacterMessage = _gcimd.GameCharacterMessageHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameCharacterMessage = _gcimd.GameCharacterMessageJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameCharacterMessage = _gcimd.GameCharacterMessageFr ;
				}
				break ;
			}
		}
		
		
		return selectGameCharacterMessage ;
	}
	
	public string GetGameCharacterSpecialMessage(int indexNumber, string languageCode){
		
		string selectGameCharacterMessage = null ;
		
		foreach(GameCharacterInfoMessageData _gcimd in _gameCharacterInfoMessageDataList) {
			if(_gcimd.IndexNumber == indexNumber){
				if(languageCode.Equals("En")){
					selectGameCharacterMessage = _gcimd.GameCharacterSpecialMessageKo ;
				}else if(languageCode.Equals("Ko")){
					selectGameCharacterMessage = _gcimd.GameCharacterSpecialMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameCharacterMessage = _gcimd.GameCharacterSpecialMessageKo ;
				}else if(languageCode.Equals("Hans")){
					selectGameCharacterMessage = _gcimd.GameCharacterSpecialMessageKo ;
				}else if(languageCode.Equals("Ja")){
					selectGameCharacterMessage = _gcimd.GameCharacterSpecialMessageKo ;
				}else if(languageCode.Equals("Fr")){
					selectGameCharacterMessage = _gcimd.GameCharacterSpecialMessageKo ;
				}
				break ;
			}
		}
		
		
		return selectGameCharacterMessage ;
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	//--- GameTipInfoMessageData
	public void SetGameTipInfoMessageData(GameTipInfoMessageData gtimd){
		
		int searchIndex = -1 ;
		int parameterIndex = gtimd.IndexNumber ;
		
		
		for(int i = 0 ; i < _gameTipInfoMessageDataList.Count ; i++){
			GameTipInfoMessageData _selectGameTipInfoMessageData = _gameTipInfoMessageDataList[i] ;
			if(_selectGameTipInfoMessageData.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameTipInfoMessageDataList.Add(gtimd) ;
		}else{
			_gameTipInfoMessageDataList[searchIndex] = gtimd ;
		}
		
		
	}
		
	public void SetGameTipInfoMessageData(int indexNumber, 
														string gameTipMessageEn, 
														string gameTipMessageKo,
														string gameTipMessageHant,
														string gameTipMessageHans,
														string gameTipMessageJa,
														string gameTipMessageFr ){
		
		int searchIndex = -1 ;
		
		
		for(int i = 0 ; i < _gameTipInfoMessageDataList.Count ; i++){
			GameTipInfoMessageData _selectGameTipInfoMessageData = _gameTipInfoMessageDataList[i] ;
			if(_selectGameTipInfoMessageData.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		GameTipInfoMessageData _gtimd = new GameTipInfoMessageData() ;
		_gtimd.IndexNumber = indexNumber ;
		_gtimd.GameTipMessageEn = gameTipMessageEn ;
		_gtimd.GameTipMessageKo = gameTipMessageKo ;
		_gtimd.GameTipMessageHant = gameTipMessageHant ;
		_gtimd.GameTipMessageHans = gameTipMessageHans ;
		_gtimd.GameTipMessageJa = gameTipMessageJa ;
		_gtimd.GameTipMessageFr = gameTipMessageFr ;
		
		
		if(searchIndex == -1){ //No Exist
			_gameTipInfoMessageDataList.Add(_gtimd) ;
		}else{
			_gameTipInfoMessageDataList[searchIndex] = _gtimd ;
		}
		
	}
	
	
	public string GetRandomGameTipInfoMessage(string languageCode){
		
		string selectGameTipInfoMessage = null ;
		
		int randomSelectGameTipInfoMessageIndex = Random.Range(0, _gameTipInfoMessageDataList.Count) ;
		
		randomSelectGameTipInfoMessageIndex += 1 ;
		
		foreach(GameTipInfoMessageData _gtimd in _gameTipInfoMessageDataList) {
			if(_gtimd.IndexNumber == randomSelectGameTipInfoMessageIndex){
				if(languageCode.Equals("En")){
					selectGameTipInfoMessage = _gtimd.GameTipMessageEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameTipInfoMessage = _gtimd.GameTipMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameTipInfoMessage = _gtimd.GameTipMessageHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameTipInfoMessage = _gtimd.GameTipMessageHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameTipInfoMessage = _gtimd.GameTipMessageJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameTipInfoMessage = _gtimd.GameTipMessageFr ;
				}
				break ;
			}
		}
		
		return selectGameTipInfoMessage ;
	}
	
	
	
	
	// Payment GoldBuyInfoBalance
	public PaymentBuyInfoBalance GetPaymentGoldBuyInfoBalance(int paymentItemIndex){
		
		PaymentBuyInfoBalance selectPaymentBuyInfoBalance= new PaymentBuyInfoBalance() ;
		
		foreach(PaymentBuyInfoBalance _pbib in _paymentGoldBuyInfoBalanceList) {
			if(_pbib.PaymentItemIndex == paymentItemIndex){
				selectPaymentBuyInfoBalance = _pbib ;
				break ;
			}
		}
		
		return selectPaymentBuyInfoBalance ;
	}
	
	
	public void SetPaymentGoldBuyInfoBalance(PaymentBuyInfoBalance pbib){
		
		int searchIndex = -1 ;
		int parameterIndex = pbib.PaymentItemIndex ;
		
		for(int i = 0 ; i < _paymentGoldBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentGoldBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_paymentGoldBuyInfoBalanceList.Add(pbib) ;
		}else{
			_paymentGoldBuyInfoBalanceList[searchIndex] = pbib ;
		}
		
	}
	
	
	public void SetPaymentGoldBuyInfoBalance(int paymentItemIndex, int paymentItemValueType, float paymentItemValue, int productValueType, int productValue, int bonusPercent, int chocolateCount) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _paymentGoldBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentGoldBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == paymentItemIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		PaymentBuyInfoBalance _pbib = new PaymentBuyInfoBalance() ;
		_pbib.PaymentItemIndex = paymentItemIndex ;
		_pbib.PaymentItemValueType = paymentItemValueType ;
		_pbib.PaymentItemValue = paymentItemValue ;
		_pbib.ProductValueType = productValueType ;
		_pbib.ProductValue = productValue ;
		_pbib.BonusPercent = bonusPercent ;
		_pbib.ChocolateCount = chocolateCount ;
		
		
		if(searchIndex == -1){ //No Exist
			_paymentGoldBuyInfoBalanceList.Add(_pbib) ;
		}else{
			_paymentGoldBuyInfoBalanceList[searchIndex] = _pbib ;
		}
		
	}
	
	
	// Payment Jewel BuyInfoBalance
	public PaymentBuyInfoBalance GetPaymentJewelBuyInfoBalance(int paymentItemIndex){
		
		PaymentBuyInfoBalance selectPaymentBuyInfoBalance= new PaymentBuyInfoBalance() ;
		
		foreach(PaymentBuyInfoBalance _pbib in _paymentJewelBuyInfoBalanceList) {
			if(_pbib.PaymentItemIndex == paymentItemIndex){
				selectPaymentBuyInfoBalance = _pbib ;
				break ;
			}
		}
		
		return selectPaymentBuyInfoBalance ;
	}
	
	
	public void SetPaymentJewelBuyInfoBalance(PaymentBuyInfoBalance pbib){
		
		int searchIndex = -1 ;
		int parameterIndex = pbib.PaymentItemIndex ;
		
		for(int i = 0 ; i < _paymentJewelBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentJewelBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_paymentJewelBuyInfoBalanceList.Add(pbib) ;
		}else{
			_paymentJewelBuyInfoBalanceList[searchIndex] = pbib ;
		}
		
	}
	
	
	public void SetPaymentJewelBuyInfoBalance(int paymentItemIndex, int paymentItemValueType, float paymentItemValue, int productValueType, int productValue, int bonusPercent, int chocolateCount) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _paymentJewelBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentJewelBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == paymentItemIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		PaymentBuyInfoBalance _pbib = new PaymentBuyInfoBalance() ;
		_pbib.PaymentItemIndex = paymentItemIndex ;
		_pbib.PaymentItemValueType = paymentItemValueType ;
		_pbib.PaymentItemValue = paymentItemValue ;
		_pbib.ProductValueType = productValueType ;
		_pbib.ProductValue = productValue ;
		_pbib.BonusPercent = bonusPercent ;
		_pbib.ChocolateCount = chocolateCount ;
		
		
		if(searchIndex == -1){ //No Exist
			_paymentJewelBuyInfoBalanceList.Add(_pbib) ;
		}else{
			_paymentJewelBuyInfoBalanceList[searchIndex] = _pbib ;
		}
		
	}
	
	
	// Payment Jewel IOS BuyInfoBalance
	public PaymentBuyInfoBalance GetPaymentJewelIOSBuyInfoBalance(int paymentItemIndex){
		
		PaymentBuyInfoBalance selectPaymentBuyInfoBalance= new PaymentBuyInfoBalance() ;
		
		foreach(PaymentBuyInfoBalance _pbib in _paymentJewelIOSBuyInfoBalanceList) {
			if(_pbib.PaymentItemIndex == paymentItemIndex){
				selectPaymentBuyInfoBalance = _pbib ;
				break ;
			}
		}
		
		return selectPaymentBuyInfoBalance ;
	}
	
	
	public void SetPaymentJewelIOSBuyInfoBalance(PaymentBuyInfoBalance pbib){
		
		int searchIndex = -1 ;
		int parameterIndex = pbib.PaymentItemIndex ;
		
		for(int i = 0 ; i < _paymentJewelIOSBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentJewelIOSBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_paymentJewelIOSBuyInfoBalanceList.Add(pbib) ;
		}else{
			_paymentJewelIOSBuyInfoBalanceList[searchIndex] = pbib ;
		}
		
	}
	
	
	public void SetPaymentJewelIOSBuyInfoBalance(int paymentItemIndex, int paymentItemValueType, float paymentItemValue, int productValueType, int productValue, int bonusPercent, int chocolateCount) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _paymentJewelIOSBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentJewelIOSBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == paymentItemIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		PaymentBuyInfoBalance _pbib = new PaymentBuyInfoBalance() ;
		_pbib.PaymentItemIndex = paymentItemIndex ;
		_pbib.PaymentItemValueType = paymentItemValueType ;
		_pbib.PaymentItemValue = paymentItemValue ;
		_pbib.ProductValueType = productValueType ;
		_pbib.ProductValue = productValue ;
		_pbib.BonusPercent = bonusPercent ;
		_pbib.ChocolateCount = chocolateCount ;
		
		
		if(searchIndex == -1){ //No Exist
			_paymentJewelIOSBuyInfoBalanceList.Add(_pbib) ;
		}else{
			_paymentJewelIOSBuyInfoBalanceList[searchIndex] = _pbib ;
		}
		
	}
	
	
	
	
	
	
	// Payment Torpedo BuyInfoBalance
	public PaymentBuyInfoBalance GetPaymentTorpedoBuyInfoBalance(int paymentItemIndex){
		
		PaymentBuyInfoBalance selectPaymentBuyInfoBalance= new PaymentBuyInfoBalance() ;
		
		foreach(PaymentBuyInfoBalance _pbib in _paymentTorpedoBuyInfoBalanceList) {
			if(_pbib.PaymentItemIndex == paymentItemIndex){
				selectPaymentBuyInfoBalance = _pbib ;
				break ;
			}
		}
		
		return selectPaymentBuyInfoBalance ;
	}
	
	
	public void SetPaymentTorpedoBuyInfoBalance(PaymentBuyInfoBalance pbib){
		
		int searchIndex = -1 ;
		int parameterIndex = pbib.PaymentItemIndex ;
		
		for(int i = 0 ; i < _paymentTorpedoBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentTorpedoBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_paymentTorpedoBuyInfoBalanceList.Add(pbib) ;
		}else{
			_paymentTorpedoBuyInfoBalanceList[searchIndex] = pbib ;
		}
		
	}
	
	
	public void SetPaymentTorpedoBuyInfoBalance(int paymentItemIndex, int paymentItemValueType, float paymentItemValue, int productValueType, int productValue, int bonusPercent, int chocolateCount) {
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _paymentTorpedoBuyInfoBalanceList.Count ; i++){
			PaymentBuyInfoBalance _selectPaymentBuyInfoBalance = _paymentTorpedoBuyInfoBalanceList[i] ;
			if(_selectPaymentBuyInfoBalance.PaymentItemIndex == paymentItemIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		PaymentBuyInfoBalance _pbib = new PaymentBuyInfoBalance() ;
		_pbib.PaymentItemIndex = paymentItemIndex ;
		_pbib.PaymentItemValueType = paymentItemValueType ;
		_pbib.PaymentItemValue = paymentItemValue ;
		_pbib.ProductValueType = productValueType ;
		_pbib.ProductValue = productValue ;
		_pbib.BonusPercent = bonusPercent ;
		_pbib.ChocolateCount = chocolateCount ;
		
		
		if(searchIndex == -1){ //No Exist
			_paymentTorpedoBuyInfoBalanceList.Add(_pbib) ;
		}else{
			_paymentTorpedoBuyInfoBalanceList[searchIndex] = _pbib ;
		}
		
	}
	
	
	
	
	// BossEnemyBalance
	public BossEnemyBalance GetBossEnemyBalance(){
		return _bossEnemyBalance ;
	}
	
	public void SetBossEnemyBalance(BossEnemyBalance beb){
		_bossEnemyBalance = beb ;
	}
	
	public void SetBossEnemyBalance(int bossEnemyFrontInitHealth, int bossEnemyFrontWeightHealth, int bossEnemyHeadInitHealth, int bossEnemyHeadWeightHealth, int bossEnemyLegInitHealth, int bossEnemyLegWeightHealth) {
		
		BossEnemyBalance _beb = new BossEnemyBalance() ;
		_beb.BossEnemyFrontInitHealth = bossEnemyFrontInitHealth ;
		_beb.BossEnemyFrontWeightHealth = bossEnemyFrontWeightHealth ;
		_beb.BossEnemyHeadInitHealth = bossEnemyHeadInitHealth ;
		_beb.BossEnemyHeadWeightHealth = bossEnemyHeadWeightHealth ;
		_beb.BossEnemyLegInitHealth = bossEnemyLegInitHealth ;
		_beb.BossEnemyLegWeightHealth = bossEnemyLegWeightHealth ;
		
		_bossEnemyBalance = _beb ;
		
	}
	
	
	
	// MidBossEnemyBalance
	public int GetMidBossEnemyBalanceListCount(){
		
		return _midBossEnemyBalanceList.Count ;
	}
	
	public MidBossEnemyBalance GetMidBossEnemyBalance(int indexNumber){
		
		MidBossEnemyBalance selectMidBossEnemyBalance = new MidBossEnemyBalance() ;
		
		foreach(MidBossEnemyBalance _mbeb in _midBossEnemyBalanceList) {
			if(_mbeb.IndexNumber == indexNumber){
				selectMidBossEnemyBalance = _mbeb ;
				break ;
			}
		}
		
		return selectMidBossEnemyBalance ;
	}
	
	public void SetMidBossEnemyBalance(MidBossEnemyBalance mbeb){
		
		int searchIndex = -1 ;
		int parameterIndex = mbeb.IndexNumber ;
		
		for(int i = 0 ; i < _midBossEnemyBalanceList.Count ; i++){
			MidBossEnemyBalance _selectMidBossEnemyBalance = _midBossEnemyBalanceList[i] ;
			if(_selectMidBossEnemyBalance.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_midBossEnemyBalanceList.Add(mbeb) ;
		}else{
			_midBossEnemyBalanceList[searchIndex] = mbeb ;
		}
		
	}
	
	public void SetMidBossEnemyBalance(int indexNumber, int midBossType, 
	                                   int midBossEnemyInitHealth, int midBossEnemyWeightHealth, 
	                                   int midBossEnemyAttackNumber, int midBossEnemyAttackCount, 
	                                   float midBossEnemyAttackGap, int midBossEnemyKillScore,
	                                   string midbossname, string midbossdescription){
		
		int searchIndex = -1 ;
		
		for(int i = 0 ; i < _midBossEnemyBalanceList.Count ; i++){
			MidBossEnemyBalance _selectMidBossEnemyBalance = _midBossEnemyBalanceList[i] ;
			if(_selectMidBossEnemyBalance.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		MidBossEnemyBalance _mbeb = new MidBossEnemyBalance() ;
		_mbeb.IndexNumber = indexNumber ;
		_mbeb.MidBossType = midBossType ;
		_mbeb.MidBossEnemyInitHealth = midBossEnemyInitHealth ;
		_mbeb.MidBossEnemyWeightHealth = midBossEnemyWeightHealth ;
		_mbeb.MidBossEnemyAttackNumber = midBossEnemyAttackNumber ;
		_mbeb.MidBossEnemyAttackCount = midBossEnemyAttackCount ;
		_mbeb.MidBossEnemyAttackGap = midBossEnemyAttackGap ;
		_mbeb.MidBossEnemyKillScore = midBossEnemyKillScore ;
		_mbeb.MidBossName = midbossname;
		_mbeb.MidBossDescription = midbossdescription;

		if(searchIndex == -1){ //No Exist
			_midBossEnemyBalanceList.Add(_mbeb) ;
		}else{
			_midBossEnemyBalanceList[searchIndex] = _mbeb ;
		}
		
	}
	

	//--- GameEndMessageData
	public void SetGameEndMessageData(GameEndMessageData gemd){
		
		int searchIndex = -1 ;
		int parameterIndex = gemd.IndexNumber ;
		
		
		for(int i = 0 ; i < _gameEndMessageDataList.Count ; i++){
			GameEndMessageData _selectGameEndMessageData = _gameEndMessageDataList[i] ;
			if(_selectGameEndMessageData.IndexNumber == parameterIndex){
				searchIndex = i ;
				break ;
			}
		}
		
		if(searchIndex == -1){ //No Exist
			_gameEndMessageDataList.Add(gemd) ;
		}else{
			_gameEndMessageDataList[searchIndex] = gemd ;
		}

	}
	
	public void SetGameEndMessageData(int indexNumber, 
	                                      string gameEndMessageEn, 
	                                      string gameEndMessageKo,
	                                      string gameEndMessageHant,
	                                      string gameEndMessageHans,
	                                      string gameEndMessageJa,
	                                      string gameEndMessageFr ){
		
		int searchIndex = -1 ;
		
		
		for(int i = 0 ; i < _gameEndMessageDataList.Count ; i++){
			GameEndMessageData _selectGameEndMessageData = _gameEndMessageDataList[i] ;
			if(_selectGameEndMessageData.IndexNumber == indexNumber){
				searchIndex = i ;
				break ;
			}
		}
		
		
		GameEndMessageData _gemd = new GameEndMessageData() ;
		_gemd.IndexNumber = indexNumber ;
		_gemd.GameEndMessageEn = gameEndMessageEn ;
		_gemd.GameEndMessageKo = gameEndMessageKo ;
		_gemd.GameEndMessageHant = gameEndMessageHant ;
		_gemd.GameEndMessageHans = gameEndMessageHans ;
		_gemd.GameEndMessageJa = gameEndMessageJa ;
		_gemd.GameEndMessageFr = gameEndMessageFr ;
		
		if(searchIndex == -1){ //No Exist
			_gameEndMessageDataList.Add(_gemd) ;
		}else{
			_gameEndMessageDataList[searchIndex] = _gemd ;
		}
		
	}
	
	
	public string GetRandomGameEndMessage(string languageCode){
		
		string selectGameEndMessage = null ;
		
		int randomSelectGameEndMessageIndex = Random.Range(0, _gameEndMessageDataList.Count) ;
		
		randomSelectGameEndMessageIndex += 1 ;
		
		foreach(GameEndMessageData _gemd in _gameEndMessageDataList) {
			if(_gemd.IndexNumber == randomSelectGameEndMessageIndex){
				if(languageCode.Equals("En")){
					selectGameEndMessage = _gemd.GameEndMessageEn ;
				}else if(languageCode.Equals("Ko")){
					selectGameEndMessage = _gemd.GameEndMessageKo ;
				}else if(languageCode.Equals("Hant")){
					selectGameEndMessage = _gemd.GameEndMessageHant ;
				}else if(languageCode.Equals("Hans")){
					selectGameEndMessage = _gemd.GameEndMessageHans ;
				}else if(languageCode.Equals("Ja")){
					selectGameEndMessage = _gemd.GameEndMessageJa ;
				}else if(languageCode.Equals("Fr")){
					selectGameEndMessage = _gemd.GameEndMessageFr ;
				}
				break ;
			}
		}
		
		return selectGameEndMessage ;
	}


	
	//----------------------------
	public GameBalanceDataStruct GetGameBalanceDataStruct(){
	
		GameBalanceDataStruct gameBalanceDataStruct = new GameBalanceDataStruct() ;

		//--
		gameBalanceDataStruct._missionInfoDataGrade1List = Managers.GameMissionData.GetMissionInfoDataGrade1List() ;
		gameBalanceDataStruct._missionInfoDataGrade2List = Managers.GameMissionData.GetMissionInfoDataGrade2List() ;
		gameBalanceDataStruct._missionInfoDataGrade3List = Managers.GameMissionData.GetMissionInfoDataGrade3List() ;
		
		gameBalanceDataStruct._missionMessageDataList = Managers.GameMissionData.GetMissionMessageDataList() ;

		gameBalanceDataStruct._achievementInfoDataList = _achievementInfoDataList;
		gameBalanceDataStruct._achievementInfoMessageDataList = _achievementInfoMessageDataList;

		gameBalanceDataStruct._stageDataList = _stageDataList;
		gameBalanceDataStruct._stageWaveDataList = _stageWaveDataList;
		gameBalanceDataStruct._stageEnemyDataList = _stageEnemyDataList;

		gameBalanceDataStruct.m_StageItemData = m_StageItemData;
		gameBalanceDataStruct.m_StageItemSpawnDataList = m_StageItemSpawnDataList;

		gameBalanceDataStruct._gameItemBalanceList = _gameItemBalanceList ;
		gameBalanceDataStruct._gameItemMessageDataList = _gameItemMessageDataList ;

		gameBalanceDataStruct._saleSubmarineInfoList = _saleSubmarineInfoList;
		gameBalanceDataStruct._gameSubmarineInfoBalanceList = _gameSubmarineInfoBalanceList ;
		gameBalanceDataStruct._gameSubmarineInfoMessageDataList = _gameSubmarineInfoMessageDataList ;

		gameBalanceDataStruct._shipDescriptionInfoList = _shipDescriptionInfoList;
		gameBalanceDataStruct._shipStatInfoList = _shipStatInfoList ;

		gameBalanceDataStruct.m_SubShipDescriptionInfoList = m_SubShipDescriptionInfoList;
		gameBalanceDataStruct.m_SubShipStatInfoList = m_SubShipStatInfoList;
		gameBalanceDataStruct.m_SubShipTactic = m_SubShipTactic;
		gameBalanceDataStruct.m_SubShipGachaDataList = m_SubShipGachaDataList;

		gameBalanceDataStruct._gameSubmarineBulletInfoBalanceList = _gameSubmarineBulletInfoBalanceList ;
		gameBalanceDataStruct._gameSubmarineEnergyInfoBalanceList = _gameSubmarineEnergyInfoBalanceList;

		gameBalanceDataStruct._saleCharacterInfoList = _saleCharacterInfoList;
		gameBalanceDataStruct._gameCharacterInfoBalanceList = _gameCharacterInfoBalanceList ;
		gameBalanceDataStruct._gameCharacterInfoMessageDataList = _gameCharacterInfoMessageDataList ;
	
		gameBalanceDataStruct._gameTipInfoMessageDataList = _gameTipInfoMessageDataList ;
	
		gameBalanceDataStruct._paymentGoldBuyInfoBalanceList = _paymentGoldBuyInfoBalanceList ;
		gameBalanceDataStruct._paymentJewelBuyInfoBalanceList = _paymentJewelBuyInfoBalanceList ;
		gameBalanceDataStruct._paymentJewelIOSBuyInfoBalanceList = _paymentJewelIOSBuyInfoBalanceList ;
		gameBalanceDataStruct._paymentTorpedoBuyInfoBalanceList = _paymentTorpedoBuyInfoBalanceList ;
		
		
		gameBalanceDataStruct._gameSubweaponSlotBalance = _gameSubweaponSlotBalance ;
		gameBalanceDataStruct._gameSubweaponPurchaseBalance = _gameSubweaponPurchaseBalance ;
	
		gameBalanceDataStruct._bossEnemyBalance = _bossEnemyBalance ;
		
		
		gameBalanceDataStruct._midBossEnemyBalanceList = _midBossEnemyBalanceList ;
		
		gameBalanceDataStruct._gameEndMessageDataList = _gameEndMessageDataList ;

		//----
		
		// Base Info
		gameBalanceDataStruct.ShowAdmob = ShowAdmob;
		gameBalanceDataStruct.ShowAdmobAmount = ShowAdmobAmount;
		gameBalanceDataStruct.TenthDownloadEventFlag = TenthDownloadEventFlag;
		gameBalanceDataStruct.TenthDownloadEventStartTimer = TenthDownloadEventStartTimer;
		gameBalanceDataStruct.TenthDownloadEventEndTimer = TenthDownloadEventEndTimer;

		gameBalanceDataStruct.PVPPlayCost = PVPPlayCost;
		gameBalanceDataStruct.PVPPlayAttackIncreaseRatio = PVPPlayAttackIncreaseRatio;
		gameBalanceDataStruct.PVPPlayOppHealthIncreaseRatio = PVPPlayOppHealthIncreaseRatio;
		gameBalanceDataStruct.PVPPlayTime = PVPPlayTime;
		gameBalanceDataStruct.PVPHealthIncreaseRatio = PVPHealthIncreaseRatio;
		gameBalanceDataStruct.PVPSubshipHealthIncreaseRatio = PVPSubshipHealthIncreaseRatio;

		gameBalanceDataStruct.VersionInfo = VersionInfo ;

		gameBalanceDataStruct.GamePlayRowSpeed = GamePlayRowSpeed;
		gameBalanceDataStruct.GamePlayRowResist = GamePlayRowResist;
		gameBalanceDataStruct.GamePlayRowPressAmount = GamePlayRowPressAmount;
		gameBalanceDataStruct.GamePlayTapAmount = GamePlayTapAmount;
		gameBalanceDataStruct.GamePlayKillGainCoinAmount = GamePlayKillGainCoinAmount;
		gameBalanceDataStruct.GamePlayMoveResist = GamePlayMoveResist;
		gameBalanceDataStruct.GamePlayRotationResist = GamePlayRotationResist;
		gameBalanceDataStruct.GamePlayReturnToBattleMaxTime = GamePlayReturnToBattleMaxTime;
		gameBalanceDataStruct.GamePlayReturnToBattleMaxDistance = GamePlayReturnToBattleMaxDistance;

		gameBalanceDataStruct.GamePlayCharacter2DamageIncreaseRatio = GamePlayCharacter2DamageIncreaseRatio;
		gameBalanceDataStruct.GamePlayCharacter2AttackSpeedIncreaseRatio = GamePlayCharacter2AttackSpeedIncreaseRatio;
		gameBalanceDataStruct.GamePlayCharacter3Duration = GamePlayCharacter3Duration;

		gameBalanceDataStruct.AttackItemDamageIncreaseRatio = AttackItemDamageIncreaseRatio;
		gameBalanceDataStruct.HealthItemIncreaseRatio = HealthItemIncreaseRatio;

		gameBalanceDataStruct.SubShipEquipAvailableMaxCount = SubShipEquipAvailableMaxCount;
		gameBalanceDataStruct.SubShipUnlockCost2 = SubShipUnlockCost2;
		gameBalanceDataStruct.SubShipUnlockCost3 = SubShipUnlockCost3;
		gameBalanceDataStruct.SubShipUnlockCost4 = SubShipUnlockCost4;

		gameBalanceDataStruct.PetGachaCost = PetGachaCost;
		gameBalanceDataStruct.Pet2SlotOpenCost = Pet2SlotOpenCost;
		//Torpedo
		gameBalanceDataStruct.TorpedoMaxValue = TorpedoMaxValue ;
		gameBalanceDataStruct.NextRechargeTorpedoBaseTime = NextRechargeTorpedoBaseTime ;
		gameBalanceDataStruct.TorpedoRechargeCost = TorpedoRechargeCost ;

		//Ranking List
		gameBalanceDataStruct.ClanRankingListPageLimit = ClanRankingListPageLimit ;
		gameBalanceDataStruct.TopRankingListPageLimit = TopRankingListPageLimit ;
		
		
		
		//Game Setting Balance Info
		gameBalanceDataStruct.GameLevel = GameLevel ;
		gameBalanceDataStruct.GameWeightLevel = GameWeightLevel ;
		
		gameBalanceDataStruct.GameSpeed = GameSpeed ;
		gameBalanceDataStruct.GameSpeedIncrease = GameSpeedIncrease ;
		gameBalanceDataStruct.EnergyDecreaseByHit = EnergyDecreaseByHit;
		gameBalanceDataStruct.EnergyDecreaseByTime = EnergyDecreaseByTime;
		gameBalanceDataStruct.EnergyAppearByDistance = EnergyAppearByDistance;
		gameBalanceDataStruct.EnergyAppearByDistanceIncrement = EnergyAppearByDistanceIncrement;

		//---
		gameBalanceDataStruct.GameSpeedIncreaseBaseDistance = GameSpeedIncreaseBaseDistance ;
		gameBalanceDataStruct.GameLevelIncreaseBaseDistance = GameLevelIncreaseBaseDistance ;
		
		gameBalanceDataStruct.GameWeightLevelIncreaseBaseDistance = GameWeightLevelIncreaseBaseDistance ;
		gameBalanceDataStruct.GameSpeedMaxValue = GameSpeedMaxValue ;
		
		
		//---
		gameBalanceDataStruct.StartBoosterTime = StartBoosterTime ;
		gameBalanceDataStruct.StartBoosterSpeed = StartBoosterSpeed ;
		
		gameBalanceDataStruct.LastBoosterTime = LastBoosterTime ;
		gameBalanceDataStruct.LastBoosterSpeed = LastBoosterSpeed ;
		
		gameBalanceDataStruct.ReviveBoosterTime = ReviveBoosterTime ;
		gameBalanceDataStruct.ReviveBoosterSpeed = ReviveBoosterSpeed ;
		
		gameBalanceDataStruct.FeverModeMaxGauge = FeverModeMaxGauge ;
		gameBalanceDataStruct.FeverModeTime = FeverModeTime ;
		gameBalanceDataStruct.FeverModeSpeed = FeverModeSpeed ;
		
		
		//--- Drop Items Ability
		gameBalanceDataStruct.EnergyHealAmount = EnergyHealAmount;
		gameBalanceDataStruct.MagnetTime = MagnetTime ;
		gameBalanceDataStruct.PowerShotTime = PowerShotTime ;
		gameBalanceDataStruct.DobleScoreTime = DobleScoreTime ;
		gameBalanceDataStruct.BoosterTime = BoosterTime ;
		gameBalanceDataStruct.BoosterSpeed = BoosterSpeed ;
		gameBalanceDataStruct.MissileDamage = MissileDamage;
		gameBalanceDataStruct.LaserDamage = LaserDamage;
		gameBalanceDataStruct.LaserDurationTime = LaserDurationTime;

		
		//--- Drop Item Probability
		gameBalanceDataStruct.BoosterProbability = BoosterProbability ;
		gameBalanceDataStruct.DoubleScoreProbability = DoubleScoreProbability ;
		gameBalanceDataStruct.MagnetProbability = MagnetProbability ;
		gameBalanceDataStruct.PowerShotProbability = PowerShotProbability ;
		gameBalanceDataStruct.GoldProbability = GoldProbability ;
		gameBalanceDataStruct.BigGoldProbability = BigGoldProbability ;
		gameBalanceDataStruct.SpecialAttackLaserProbability = SpecialAttackLaserProbability;
		gameBalanceDataStruct.SpecialAttackMissileProbability = SpecialAttackMissileProbability;
		gameBalanceDataStruct.EnergyItemProbability = EnergyItemProbability;

		//--- Score
		gameBalanceDataStruct.Enemy1Score = Enemy1Score ;
		gameBalanceDataStruct.Enemy2Score = Enemy2Score ;
		gameBalanceDataStruct.Enemy3Score = Enemy3Score ;
		gameBalanceDataStruct.Enemy4Score = Enemy4Score ;
		gameBalanceDataStruct.Enemy5Score = Enemy5Score ;
		gameBalanceDataStruct.Enemy6Score = Enemy6Score ;
		gameBalanceDataStruct.EnemyMineScore = EnemyMineScore ;
		gameBalanceDataStruct.AllKillScore = AllKillScore ;
		
		gameBalanceDataStruct.BossEnemyHeadPartsScore = BossEnemyHeadPartsScore ;
		gameBalanceDataStruct.BossEnemyFrontPartsScore = BossEnemyFrontPartsScore ;
		gameBalanceDataStruct.BossEnemyLegsPartsScore = BossEnemyLegsPartsScore ;
		gameBalanceDataStruct.BossEnemyAllBrokenScore = BossEnemyAllBrokenScore ;
		
		gameBalanceDataStruct.EnemyMeteorScore = EnemyMeteorScore ;
		gameBalanceDataStruct.EnemyMeteorBaseDistance = EnemyMeteorBaseDistance ;


		//-- Coin Info
		gameBalanceDataStruct.CoinPatternGold = CoinPatternGold ;
		gameBalanceDataStruct.CoinPatternBigGold = CoinPatternBigGold ;
		gameBalanceDataStruct.CoinDropItemGold = CoinDropItemGold ;
		gameBalanceDataStruct.CoinDropItemBigGold = CoinDropItemBigGold ;
		
		
		//-- Magnet Area Info
		gameBalanceDataStruct.MagnetAreaCharacter = MagnetAreaCharacter ;
		gameBalanceDataStruct.MagnetAreaDropItem = MagnetAreaDropItem ;
		
		
		//-- Boss Controll Data
		gameBalanceDataStruct.BossLuncherNextDistance = BossLuncherNextDistance ;
		gameBalanceDataStruct.BossLuncherTermDistance = BossLuncherTermDistance ;


		gameBalanceDataStruct.GachaGrade1Probability = GachaGrade1Probability ;
		gameBalanceDataStruct.GachaGrade2Probability = GachaGrade2Probability ;
		gameBalanceDataStruct.GachaGrade3Probability = GachaGrade3Probability ;
		gameBalanceDataStruct.GachaGrade4Probability = GachaGrade4Probability ;
		gameBalanceDataStruct.GachaGrade5Probability = GachaGrade5Probability ;

		// 이어하기 수정 - 시작 (14.03.12 by 최원석).
		gameBalanceDataStruct.CrystalExpendForContinue = CrystalExpendForContinue;
		// 이어하기 수정 - 끝.
		if(m_StringTextList == null)
		{
			m_StringTextList = new List<string>();
		}
		gameBalanceDataStruct.m_StringTextList = m_StringTextList;

		gameBalanceDataStruct.KakaoInviteMessageID = KakaoInviteMessageID;
		gameBalanceDataStruct.LuckyGachaPerCoupon = LuckyGachaPerCoupon;
		gameBalanceDataStruct.LuckyGachaCouponMax = LuckyGachaCouponMax;
		if(_luckyPresentList == null)
		{
			_luckyPresentList = new List<LuckyPresent>();
		}
		gameBalanceDataStruct._luckyPresentList = _luckyPresentList;

		if(_luckyPresentGradeProbabilityList == null)
		{
			_luckyPresentGradeProbabilityList = new List<LuckyPresentGradeProbability>();
		}
		gameBalanceDataStruct._luckyPresentGradeProbabilityList = _luckyPresentGradeProbabilityList;
		return gameBalanceDataStruct ;
		
	}
	
	public void SetGameBalanceDataStruct(GameBalanceDataStruct gameBalanceDataStruct) {
		
		
		
		Managers.GameMissionData.SetMissionInfoDataGrade1List(gameBalanceDataStruct._missionInfoDataGrade1List) ;
		Managers.GameMissionData.SetMissionInfoDataGrade2List(gameBalanceDataStruct._missionInfoDataGrade2List) ;
		Managers.GameMissionData.SetMissionInfoDataGrade3List(gameBalanceDataStruct._missionInfoDataGrade3List) ;
		
		Managers.GameMissionData.SetMissionMessageDataList(gameBalanceDataStruct._missionMessageDataList) ;
		
		_achievementInfoDataList = gameBalanceDataStruct._achievementInfoDataList;
		_achievementInfoMessageDataList = gameBalanceDataStruct._achievementInfoMessageDataList;

		//-------Enemy Pattern
		_stageDataList = gameBalanceDataStruct._stageDataList;
		_stageWaveDataList = gameBalanceDataStruct._stageWaveDataList;
		_stageEnemyDataList = gameBalanceDataStruct._stageEnemyDataList;

		m_StageItemData = gameBalanceDataStruct.m_StageItemData;
		m_StageItemSpawnDataList = gameBalanceDataStruct.m_StageItemSpawnDataList;
		
		_gameItemBalanceList = gameBalanceDataStruct._gameItemBalanceList ;
		_gameItemMessageDataList = gameBalanceDataStruct._gameItemMessageDataList ;

		_saleSubmarineInfoList = gameBalanceDataStruct._saleSubmarineInfoList;
		_gameSubmarineInfoBalanceList = gameBalanceDataStruct._gameSubmarineInfoBalanceList ;
		_gameSubmarineInfoMessageDataList = gameBalanceDataStruct._gameSubmarineInfoMessageDataList ;

		_shipDescriptionInfoList = gameBalanceDataStruct._shipDescriptionInfoList;
		_shipStatInfoList = gameBalanceDataStruct._shipStatInfoList ;

		m_SubShipDescriptionInfoList = gameBalanceDataStruct.m_SubShipDescriptionInfoList;
		m_SubShipStatInfoList = gameBalanceDataStruct.m_SubShipStatInfoList;
		m_SubShipTactic = gameBalanceDataStruct.m_SubShipTactic;
		m_SubShipGachaDataList = gameBalanceDataStruct.m_SubShipGachaDataList;

		_gameSubmarineBulletInfoBalanceList = gameBalanceDataStruct._gameSubmarineBulletInfoBalanceList ;
		_gameSubmarineEnergyInfoBalanceList = gameBalanceDataStruct._gameSubmarineEnergyInfoBalanceList;

		_saleCharacterInfoList = gameBalanceDataStruct._saleCharacterInfoList;
		_gameCharacterInfoBalanceList = gameBalanceDataStruct._gameCharacterInfoBalanceList ;
		_gameCharacterInfoMessageDataList = gameBalanceDataStruct._gameCharacterInfoMessageDataList ;
		
		_gameTipInfoMessageDataList = gameBalanceDataStruct._gameTipInfoMessageDataList ;
		
		_paymentGoldBuyInfoBalanceList = gameBalanceDataStruct._paymentGoldBuyInfoBalanceList ;
		_paymentJewelBuyInfoBalanceList = gameBalanceDataStruct._paymentJewelBuyInfoBalanceList ;
		_paymentJewelIOSBuyInfoBalanceList = gameBalanceDataStruct._paymentJewelIOSBuyInfoBalanceList ;
		_paymentTorpedoBuyInfoBalanceList = gameBalanceDataStruct._paymentTorpedoBuyInfoBalanceList ;
		
		_midBossEnemyBalanceList = gameBalanceDataStruct._midBossEnemyBalanceList ;

		_gameEndMessageDataList = gameBalanceDataStruct._gameEndMessageDataList ;
						
		// Init Setting BossEnemyBalance
		SetBossEnemyBalance(gameBalanceDataStruct._bossEnemyBalance) ;
		
		
		//----------
		ShowAdmob = gameBalanceDataStruct.ShowAdmob;
		ShowAdmobAmount = gameBalanceDataStruct.ShowAdmobAmount;
		TenthDownloadEventFlag = gameBalanceDataStruct.TenthDownloadEventFlag;
		TenthDownloadEventStartTimer = gameBalanceDataStruct.TenthDownloadEventStartTimer;
		TenthDownloadEventEndTimer = gameBalanceDataStruct.TenthDownloadEventEndTimer;

		PVPPlayCost = gameBalanceDataStruct.PVPPlayCost;
		PVPPlayAttackIncreaseRatio = gameBalanceDataStruct.PVPPlayAttackIncreaseRatio;
		PVPPlayOppHealthIncreaseRatio = gameBalanceDataStruct.PVPPlayOppHealthIncreaseRatio;
		PVPPlayTime = gameBalanceDataStruct.PVPPlayTime;
		PVPHealthIncreaseRatio = gameBalanceDataStruct.PVPHealthIncreaseRatio;
		PVPSubshipHealthIncreaseRatio = gameBalanceDataStruct.PVPSubshipHealthIncreaseRatio;

		VersionInfo = gameBalanceDataStruct.VersionInfo ;

		GamePlayRowSpeed = gameBalanceDataStruct.GamePlayRowSpeed;
		GamePlayRowResist = gameBalanceDataStruct.GamePlayRowResist;
		GamePlayRowPressAmount = gameBalanceDataStruct.GamePlayRowPressAmount;
		GamePlayTapAmount = gameBalanceDataStruct.GamePlayTapAmount;
		GamePlayKillGainCoinAmount = gameBalanceDataStruct.GamePlayKillGainCoinAmount;
		GamePlayMoveResist = gameBalanceDataStruct.GamePlayMoveResist;
		GamePlayRotationResist = gameBalanceDataStruct.GamePlayRotationResist;
		GamePlayReturnToBattleMaxTime = gameBalanceDataStruct.GamePlayReturnToBattleMaxTime;
		GamePlayReturnToBattleMaxDistance = gameBalanceDataStruct.GamePlayReturnToBattleMaxDistance;

		GamePlayCharacter2DamageIncreaseRatio = gameBalanceDataStruct.GamePlayCharacter2DamageIncreaseRatio;
		GamePlayCharacter2AttackSpeedIncreaseRatio = gameBalanceDataStruct.GamePlayCharacter2AttackSpeedIncreaseRatio;
		GamePlayCharacter3Duration = gameBalanceDataStruct.GamePlayCharacter3Duration;

		AttackItemDamageIncreaseRatio = gameBalanceDataStruct.AttackItemDamageIncreaseRatio;
		HealthItemIncreaseRatio = gameBalanceDataStruct.HealthItemIncreaseRatio;

		SubShipEquipAvailableMaxCount = gameBalanceDataStruct.SubShipEquipAvailableMaxCount;
		SubShipUnlockCost2 = gameBalanceDataStruct.SubShipUnlockCost2;
		SubShipUnlockCost3 = gameBalanceDataStruct.SubShipUnlockCost3;
		SubShipUnlockCost4 = gameBalanceDataStruct.SubShipUnlockCost4;

		PetGachaCost = gameBalanceDataStruct.PetGachaCost;
		Pet2SlotOpenCost = gameBalanceDataStruct.Pet2SlotOpenCost;
		//Torpedo
		TorpedoMaxValue = gameBalanceDataStruct.TorpedoMaxValue ;
		NextRechargeTorpedoBaseTime = gameBalanceDataStruct.NextRechargeTorpedoBaseTime  ;
		TorpedoRechargeCost = gameBalanceDataStruct.TorpedoRechargeCost ;

		//Ranking List
		ClanRankingListPageLimit = gameBalanceDataStruct.ClanRankingListPageLimit ;
		TopRankingListPageLimit = gameBalanceDataStruct.TopRankingListPageLimit ;
		
		
		
		//Init Setting Game Balance Info
		GameLevel = gameBalanceDataStruct.GameLevel ;
		GameWeightLevel = gameBalanceDataStruct.GameWeightLevel ;
		
		GameSpeed = gameBalanceDataStruct.GameSpeed ;
		GameSpeedIncrease = gameBalanceDataStruct.GameSpeedIncrease ;

		EnergyDecreaseByHit = gameBalanceDataStruct.EnergyDecreaseByHit;
		EnergyDecreaseByTime = gameBalanceDataStruct.EnergyDecreaseByTime;
		EnergyAppearByDistance = gameBalanceDataStruct.EnergyAppearByDistance;
		EnergyAppearByDistanceIncrement = gameBalanceDataStruct.EnergyAppearByDistanceIncrement;

		GameSpeedIncreaseBaseDistance = gameBalanceDataStruct.GameSpeedIncreaseBaseDistance ;
		GameLevelIncreaseBaseDistance = gameBalanceDataStruct.GameLevelIncreaseBaseDistance ;
		GameWeightLevelIncreaseBaseDistance = gameBalanceDataStruct.GameWeightLevelIncreaseBaseDistance ;
		GameSpeedMaxValue = gameBalanceDataStruct.GameSpeedMaxValue ;
		
		
		StartBoosterTime = gameBalanceDataStruct.StartBoosterTime ;
		StartBoosterSpeed = gameBalanceDataStruct.StartBoosterSpeed ;
		LastBoosterTime = gameBalanceDataStruct.LastBoosterTime ;
		LastBoosterSpeed = gameBalanceDataStruct.LastBoosterSpeed ;
		ReviveBoosterTime = gameBalanceDataStruct.ReviveBoosterTime ;
		ReviveBoosterSpeed = gameBalanceDataStruct.ReviveBoosterSpeed ;
		
		FeverModeMaxGauge = gameBalanceDataStruct.FeverModeMaxGauge ;
		FeverModeTime = gameBalanceDataStruct.FeverModeTime ;
		FeverModeSpeed = gameBalanceDataStruct.FeverModeSpeed ;
		

		//Init Setting DropItem Balance Info
		EnergyHealAmount = gameBalanceDataStruct.EnergyHealAmount ;
		MagnetTime = gameBalanceDataStruct.MagnetTime ;
		PowerShotTime = gameBalanceDataStruct.PowerShotTime ;
		DobleScoreTime = gameBalanceDataStruct.DobleScoreTime ;
		BoosterTime = gameBalanceDataStruct.BoosterTime ;
		BoosterSpeed = gameBalanceDataStruct.BoosterSpeed ;
		MissileDamage = gameBalanceDataStruct.MissileDamage;
		LaserDamage = gameBalanceDataStruct.LaserDamage;
		LaserDurationTime = gameBalanceDataStruct.LaserDurationTime;
		
		//Init Setting Drop Item Probability Balance Info
		BoosterProbability = gameBalanceDataStruct.BoosterProbability ;
		DoubleScoreProbability = gameBalanceDataStruct.DoubleScoreProbability ;
		MagnetProbability = gameBalanceDataStruct.MagnetProbability ;
		PowerShotProbability = gameBalanceDataStruct.PowerShotProbability ;
		GoldProbability = gameBalanceDataStruct.GoldProbability ;
		BigGoldProbability = gameBalanceDataStruct.BigGoldProbability ;
		SpecialAttackLaserProbability = gameBalanceDataStruct.SpecialAttackLaserProbability;
		SpecialAttackMissileProbability = gameBalanceDataStruct.SpecialAttackMissileProbability;
		EnergyItemProbability = gameBalanceDataStruct.EnergyItemProbability;
		// Init Score Data
		Enemy1Score = gameBalanceDataStruct.Enemy1Score ;
		Enemy2Score = gameBalanceDataStruct.Enemy2Score ;
		Enemy3Score = gameBalanceDataStruct.Enemy3Score ;
		Enemy4Score = gameBalanceDataStruct.Enemy4Score ;
		Enemy5Score = gameBalanceDataStruct.Enemy5Score ;
		Enemy6Score = gameBalanceDataStruct.Enemy6Score ;
		EnemyMineScore = gameBalanceDataStruct.EnemyMineScore ;
		AllKillScore = gameBalanceDataStruct.AllKillScore ;
		
		BossEnemyHeadPartsScore = gameBalanceDataStruct.BossEnemyHeadPartsScore ;
		BossEnemyFrontPartsScore = gameBalanceDataStruct.BossEnemyFrontPartsScore ;
		BossEnemyLegsPartsScore = gameBalanceDataStruct.BossEnemyLegsPartsScore ;
		BossEnemyAllBrokenScore = gameBalanceDataStruct.BossEnemyAllBrokenScore ;

		EnemyMeteorScore = gameBalanceDataStruct.EnemyMeteorScore ;
		EnemyMeteorBaseDistance = gameBalanceDataStruct.EnemyMeteorBaseDistance ;

		//
		
		
		// Init Coin Info
		CoinPatternGold = gameBalanceDataStruct.CoinPatternGold ;
		CoinPatternBigGold = gameBalanceDataStruct.CoinPatternBigGold ;
		CoinDropItemGold = gameBalanceDataStruct.CoinDropItemGold ;
		CoinDropItemBigGold = gameBalanceDataStruct.CoinDropItemBigGold ;
		
		
		//-- Init Magnet Area Info
		MagnetAreaCharacter = gameBalanceDataStruct.MagnetAreaCharacter ;
		MagnetAreaDropItem = gameBalanceDataStruct.MagnetAreaDropItem ;
		
		
		//-- Boss Controll Data
		BossLuncherNextDistance = gameBalanceDataStruct.BossLuncherNextDistance ;
		BossLuncherTermDistance = gameBalanceDataStruct.BossLuncherTermDistance ; 
		

		GachaGrade1Probability = gameBalanceDataStruct.GachaGrade1Probability ;
		GachaGrade2Probability = gameBalanceDataStruct.GachaGrade2Probability ;
		GachaGrade3Probability = gameBalanceDataStruct.GachaGrade3Probability ;
		GachaGrade4Probability = gameBalanceDataStruct.GachaGrade4Probability ;
		GachaGrade5Probability = gameBalanceDataStruct.GachaGrade5Probability ;

		// 이어하기 수정 - 시작 (14.03.12 by 최원석).
		CrystalExpendForContinue = gameBalanceDataStruct.CrystalExpendForContinue;
		// 이어하기 수정 - 끝.

		m_StringTextList = gameBalanceDataStruct.m_StringTextList;
		TextManager.Instance.SetTextList(m_StringTextList);

		KakaoInviteMessageID = gameBalanceDataStruct.KakaoInviteMessageID;
		LuckyGachaPerCoupon = gameBalanceDataStruct.LuckyGachaPerCoupon;
		LuckyGachaCouponMax = gameBalanceDataStruct.LuckyGachaCouponMax;

		_luckyPresentList = gameBalanceDataStruct._luckyPresentList;
		_luckyPresentGradeProbabilityList = gameBalanceDataStruct._luckyPresentGradeProbabilityList;
	}
	
	
		// 밸런싱 데이터 전송시에만 1회 만들기 위해 사용하는 모듈.
	public void MakeGameBalanceData() {

		//ShowAdmob = 0;

		//tempstage
		//StageData stagedata1 = new StageData();
		//stagedata1.Index = 1;
		//stagedata1.StageName = "Stage1";
		//stagedata1.ClearType = Constant.ST200_STAGE_CLEAR_TYPE_CLEARWAVE;
		//stagedata1.SpawnShipIndexList = new int[]{1};
		//stagedata1.SpawnShipRatioList = new float[]{1f};
		//stagedata1.SpawnShipMinNumb = 5;
		//stagedata1.SpawnShipMaxNumb = 10;
		//stagedata1.SpawnTimer = 2f;
		//stagedata1.WaveIndexList = new int[]{1};
		//SetStageData(stagedata1);

		//StageEnemyData stageenemydata1 = new StageEnemyData();
		//stageenemydata1.Index = 1;
		//stageenemydata1.EnemyType = 1;
		//stageenemydata1.MoveSpeed = 0.5f;
		//stageenemydata1.MoveForce = 1f;
		//stageenemydata1.Health = 1;
		//stageenemydata1.AttackType = 1;
		//stageenemydata1.AttackRate = 2f;
		//stageenemydata1.Score = 100;
		//SetStageEnemyData(stageenemydata1);

		//ShipStatInfo shipstatinfo1 = new ShipStatInfo();
		//shipstatinfo1.ShipIndex = 1;
		//shipstatinfo1.ShipLevel = 1;
		//shipstatinfo1.ValueType = 2;
		//shipstatinfo1.Cost = 10;
		//shipstatinfo1.Health = 100f;
		//shipstatinfo1.AttackType = 1;
		//shipstatinfo1.AttackDelayTime = 5f;
		//shipstatinfo1.AttackDamage = 10f;
		//shipstatinfo1.BulletSpeed = 2f;
		//shipstatinfo1.MaxMoveSpeed = 1f;
		//shipstatinfo1.PushForce = 5f;
		//SetShipStatInfo(shipstatinfo1);

		//StageWaveData stagewavedata1 = new StageWaveData();
		//stagewavedata1.Index = 1;
		//stagewavedata1.EnemyIndexList = new int[]{1,1,1,1,1};
		//SetStageWaveData(stagewavedata1);

		//if(_shipDescriptionInfoList == null)
		//{
		//	_shipDescriptionInfoList = new List<ShipDescriptionInfo>();
		//}
		//ShipDescriptionInfo shipdescriptioninfo1 = new ShipDescriptionInfo();
		//shipdescriptioninfo1.ShipIndex = 1;
		//shipdescriptioninfo1.ShipName = "TURTLE";
		//shipdescriptioninfo1.ShipSpecialDescription = "Special";
		//shipdescriptioninfo1.ShipDescription = "description";
		//_shipDescriptionInfoList.Add(shipdescriptioninfo1);

		//SubShipDescriptionInfo subshipdescriptioninfo1 = new SubShipDescriptionInfo();
		//subshipdescriptioninfo1.ShipIndex = 1;
		//subshipdescriptioninfo1.ShipName = "HI SHIP";
		//subshipdescriptioninfo1.ShipDescription = "SAYS HI";
		//subshipdescriptioninfo1.ShipSpecialDescription = "BRIGHT SMILE";
		//SetSubShipDescriptionInfo(subshipdescriptioninfo1);
		//
		//SubShipStatInfo subshipstatinfo1 = new SubShipStatInfo();
		//subshipstatinfo1.ShipIndex = 1;
		//subshipstatinfo1.ShipLevel = 1;
		//subshipstatinfo1.Health = 100f;
		//subshipstatinfo1.ValueType = 1;
		//subshipstatinfo1.Cost = 0;
		//subshipstatinfo1.MaxMoveSpeed = 1.3f;
		//subshipstatinfo1.MoveForce = 0.5f;
		//subshipstatinfo1.MaxRotationSpeed = 30f;
		//subshipstatinfo1.SpecialGaugeSpeed = 5f;
		//subshipstatinfo1.SpecialGaugeMax = 10f;
		//subshipstatinfo1.SpecialEffectValue = 10f;
		//subshipstatinfo1.SpecialEffectValue2 = 10f;
		//subshipstatinfo1.SpecialEffectValue3 = 5f;
		//subshipstatinfo1.PushDamage = 10f;
		//subshipstatinfo1.PushForce = 10f;
		//SetSubShipStatInfo(subshipstatinfo1);

		//StageItemData stageitemdata = new StageItemData();
		//stageitemdata.Index = 1;
		//stageitemdata.EffectType = 1;
		//SetStageItemData(stageitemdata);
		//
		//StageItemSpawnData stageitemspawndata = new StageItemSpawnData();
		//stageitemspawndata.Index = 1;
		//stageitemspawndata.StageItemIndexList = new int[]{1,};
		//stageitemspawndata.StageItemRatioList = new float[]{1f,};
		//SetStageItemSpawnData(stageitemspawndata);

		//for(int i = 0; i < _stageDataList.Count; i++)
		//{
		//	StageData stagedata = _stageDataList[i];
		//	stagedata.m_ItemShipIndexList = new int[]{0};
		//	stagedata.m_ItemShipRatioList = new float[]{1f};
		//	SetStageData(stagedata);
		//}


		//if(m_SubShipTactic == null)
		//{
		//	m_SubShipTactic = new List<SubShipTacTic>();
		//}
		//SubShipTacTic subshiptactic1 = new SubShipTacTic();
		//subshiptactic1.Index = 1;
		//subshiptactic1.TacticName = "Tactic";
		//subshiptactic1.ShipPosX1 = -3f;
		//subshiptactic1.ShipPosY1 = 0f;
		//subshiptactic1.ShipPosX2 = 3f;
		//subshiptactic1.ShipPosY2 = 0f;
		//subshiptactic1.ShipPosX3 = -6f;
		//subshiptactic1.ShipPosY3 = 0f;
		//subshiptactic1.ShipPosX4 = 6f;
		//subshiptactic1.ShipPosY4 = 0f;
		//SetSubShipTactic(subshiptactic1);

		//if(m_SubShipGachaDataList == null)
		//{
		//	m_SubShipGachaDataList = new List<SubShipGachaData>();
		//}
		//SubShipGachaData subshipgachadata = new SubShipGachaData();
		//subshipgachadata.Index = 1;
		//subshipgachadata.GradeList = new int[]{1};
		//subshipgachadata.GradeRatioList = new float[]{1f};
		//SetSubShipGachaData(subshipgachadata);

		//for(int i = 4 ; i < 13; i++)
		//{
		//	SubShipDescriptionInfo subshipdescription = GetSubShipDescriptionInfo(1);
		//	subshipdescription.ShipIndex = i;
		//	SetSubShipDescriptionInfo(subshipdescription);
		//
		//	for(int level = 1; level < 6; level++)
		//	{
		//		SubShipStatInfo statinfo = GetSubShipStatInfo(1,level);
		//		statinfo.ShipIndex = i;
		//		statinfo.ShipLevel = level;
		//		SetSubShipStatInfo(statinfo);
		//	}
		//}
		//for(int i = 0; i < 100; i++)
		//{
		//	StageData data = _stageDataList[i];
		//	data.Index += 100;
		//	data.Locked = 1;
		//	SetStageData(data);
		//}

		//for(int i = 0; i < _shipStatInfoList.Count; )
		//{
		//	if(_shipStatInfoList[i].ShipIndex == 7 || _shipStatInfoList[i].ShipIndex == 8)
		//	{
		//		_shipStatInfoList.RemoveAt(i);
		//		//Debug.Log("REMOVE....");
		//	}else
		//	{
		//		i++;
		//	}
		//}
		//for(int i = 0; i < 10; i++)
		//{
		//	ShipStatInfo info = GetShipStatInfo(1, i + 1);
		//	info.ShipIndex = 7;
		//	SetShipStatInfo(info);
		//}
		//for(int i = 0; i < 10; i++)
		//{
		//	ShipStatInfo info = GetShipStatInfo(4, i + 1);
		//	info.ShipIndex = 8;
		//	SetShipStatInfo(info);
		//}

		//for(int i = 241; i <= 280; i++)
		//{
		//	StageData data = GetStageData(i - 1);
		//	data.Index = i;
		//	SetStageData(data);
		//}

		//for(int i = 0; i < _gameCharacterInfoMessageDataList.Count; i++)
		//{
		//	GameCharacterInfoMessageData message = _gameCharacterInfoMessageDataList[i];
		//
		//	message.GameCharacterNameIndex = (Constant.ST200_ITEM_CHARACTER_STARTCODE + message.IndexNumber) * 10 + 1;
		//	message.GameCharacterName2Index = (Constant.ST200_ITEM_CHARACTER_STARTCODE + message.IndexNumber) * 10 + 2;
		//	message.GameCharacterDescription1Index = (Constant.ST200_ITEM_CHARACTER_STARTCODE + message.IndexNumber) * 10 + 3;
		//	message.GameCharacterDescription2Index = (Constant.ST200_ITEM_CHARACTER_STARTCODE + message.IndexNumber) * 10 + 4;
		//
		//	_gameCharacterInfoMessageDataList[i] = message;
		//}
		//
		//for(int i = 0; i < _shipDescriptionInfoList.Count; i++)
		//{
		//	ShipDescriptionInfo message = _shipDescriptionInfoList[i];
		//
		//
		//	message.ShipNameTextIndex = (Constant.ST200_ITEM_SHIP_STARTCODE + message.ShipIndex) * 10 + 1;
		//	message.ShipDescriptionTextIndex = (Constant.ST200_ITEM_SHIP_STARTCODE + message.ShipIndex) * 10 + 2;
		//	message.ShipSpecialDescriptionTextIndex = (Constant.ST200_ITEM_SHIP_STARTCODE + message.ShipIndex) * 10 + 3;
		//
		//	_shipDescriptionInfoList[i] = message;
		//}
		//
		//for(int i = 0; i < m_SubShipDescriptionInfoList.Count; i++)
		//{
		//	SubShipDescriptionInfo message = m_SubShipDescriptionInfoList[i];
		//
		//	message.ShipNameTextIndex = (Constant.ST200_ITEM_SUBSHIP_STARTCODE + message.ShipIndex) * 10 + 1;
		//	message.ShipDescriptionTextIndex = (Constant.ST200_ITEM_SUBSHIP_STARTCODE + message.ShipIndex) * 10 + 2;
		//	message.ShipSpecialDescriptionTextIndex = (Constant.ST200_ITEM_SUBSHIP_STARTCODE + message.ShipIndex) * 10 + 3;
		//
		//	m_SubShipDescriptionInfoList[i] = message;
		//}

		//for(int i = 0; i < 
		for(int i = 0; i < m_SubShipTactic.Count; i++)
		{
			SubShipTacTic tactic = m_SubShipTactic[i];
			tactic.TacticNameTextIndex = (Constant.ST200_ITEM_SUBSHIP_TACTIC_STARTCODE + tactic.Index) * 10 + 1;
			m_SubShipTactic[i] = tactic;
		}

		for(int i = 0; i < _gameItemMessageDataList.Count; i++)
		{
			GameItemMessageData message = _gameItemMessageDataList[i];
			message.ItemNameTextIndex = message.ItemType * 10+ 1;
			message.ItemDescriptionTextIndex = message.ItemType * 10 + 2;
			_gameItemMessageDataList[i] = message;
		}
	}
	
	
	public string GetMainBulletName(int _submarine, int _level)
	{
		string bulletname = "Bullet_0_1";
		if(_submarine == 2)
		{
			if(_level <= 20)
			{
				bulletname = "Bullet_2_" + _level.ToString();
			}else
			{
				bulletname = "Bullet_2_" + (16 + (_level - 21) % 5).ToString();
			}
		}else if(_submarine == 4)
		{
			//if(_level <= 5)
			//{
			//	bulletname = "Bullet_4_1";
			//}else if(_level <= 10)
			//{
			//	bulletname = "Bullet_4_5";
			//}else if(_level <= 15)
			//{
			//	bulletname = "Bullet_4_10";
			//}else
			//{
			//	bulletname = "Bullet_4_30";
			//}

			if(_level <= 20)
			{
				bulletname = "Bullet_4_" + _level.ToString();
			}else
			{
				bulletname = "Bullet_4_" + (16 + (_level - 21) % 5).ToString();
			}
		}else
		{
			bulletname = "Bullet_"+_submarine.ToString()+"_"+_level.ToString();
		}
		return bulletname;
	}

	public string GetSubBulletName(int _submarine, int _level)
	{
		string bulletname = "Bullet_0_1";

		if(_submarine == 2)
		{
			if(_level <= 20)
			{
				bulletname = "Bullet_2_" + (1 + (_level - 1) % 5).ToString();
			}else if(_level <= 25)
			{
				bulletname = "Bullet_2_" + (6 + (_level - 1) % 5).ToString();
			}else if(_level <= 30)
			{
				bulletname = "Bullet_2_" + (26 + (_level - 1) % 5).ToString();
			}
		}else if(_submarine == 4)
		{
			if(_level <= 20)
			{
				bulletname = "Bullet_4_" + (1 + (_level - 1) % 5).ToString();
			}else if(_level <= 25)
			{
				bulletname = "Bullet_4_" + (6 + (_level - 1) % 5).ToString();
			}else if(_level <= 30)
			{
				bulletname = "Bullet_4_" + (26 + (_level - 1) % 5).ToString();
			}
			//if(_level <= 5)
			//{
			//	bulletname = "Bullet_4_1";
			//}else if(_level <= 10)
			//{
			//	bulletname = "Bullet_4_1";
			//}else if(_level <= 15)
			//{
			//	bulletname = "Bullet_4_1";
			//}else if(_level <= 20)
			//{
			//	bulletname = "Bullet_4_5";
			//}else if(_level <= 25)
			//{
			//	bulletname = "Bullet_4_10";
			//}else
			//{
			//	bulletname = "Bullet_4_30";
			//}
		}

		return bulletname;
	}

	/// <summary>
	/// Get Random LuckyPresents 
	/// Item at index 0 is picked one
	/// </summary>
	public List<LuckyPresent> GetLuckyPresentGachaList(int _number)
	{
		List<LuckyPresent> SelectedPresents = new List<LuckyPresent>();
		List<LuckyPresent> SelectablePresents = new List<LuckyPresent>(_luckyPresentList);

		float TotalProbability = 0f;
		for(int i = 0; i < _luckyPresentGradeProbabilityList.Count; i++)
		{
			TotalProbability += _luckyPresentGradeProbabilityList[i].Probability;
		}

		for(int i = 0; i < 1; i++)
		{
			int SelectedGrade = -1;

			float RandomProbability = Random.Range(0f, TotalProbability);
			float CurrentProbability = 0f;
			for(int j = 0; j < _luckyPresentGradeProbabilityList.Count; j++)
			{
				CurrentProbability += _luckyPresentGradeProbabilityList[j].Probability;
				if(RandomProbability <= CurrentProbability)
				{
					SelectedGrade = _luckyPresentGradeProbabilityList[j].Grade;
					break;
				}
			}

			List<LuckyPresent> GradeMatchedPresents = new List<LuckyPresent>();
			for(int k = 0; k < SelectablePresents.Count; k++)
			{
				if(SelectablePresents[k].Grade == SelectedGrade)
				{
					GradeMatchedPresents.Add(SelectablePresents[k]);
				}
			}
			//Debug.Log("SELECTED GRADE: " + SelectedGrade + "  GRADE MATCHED COUNT: " + GradeMatchedPresents.Count);
			LuckyPresent randomselectpresent = GradeMatchedPresents[Random.Range(0, GradeMatchedPresents.Count)];
			SelectablePresents.Remove(randomselectpresent);
			SelectedPresents.Add(randomselectpresent);
		}

		for(int i = 0; i < _number - 1; i++)
		{
			int selectindex =  Random.Range(0,SelectablePresents.Count);
			SelectedPresents.Add(SelectablePresents[selectindex]);
			SelectablePresents.RemoveAt(selectindex);
		}

		return SelectedPresents;
	}

	public SubShipTacTic GetSubShipTactic(int _index)
	{
		SubShipTacTic info = new SubShipTacTic();
		for(int i = 0; i < m_SubShipTactic.Count; i++)
		{
			if(m_SubShipTactic[i].Index == _index)
			{
				info = m_SubShipTactic[i];
				return info;
			}
		}

		return new SubShipTacTic();
	}

	public void SetSubShipTactic(SubShipTacTic _tactic)
	{
		SubShipTacTic info = _tactic;
		for(int i = 0; i < m_SubShipTactic.Count; i++)
		{
			if(info.Index == m_SubShipTactic[i].Index)
			{
				m_SubShipTactic[i] = info;
				return;
			}
		}

		m_SubShipTactic.Add(info);
	}

	public SubShipGachaData GetSubShipGachaData(int _index)
	{
		SubShipGachaData info = new SubShipGachaData();
		for(int i = 0; i < m_SubShipGachaDataList.Count; i++)
		{
			if(m_SubShipGachaDataList[i].Index == _index)
			{
				info = m_SubShipGachaDataList[i];
				return info;
			}
		}

		return new SubShipGachaData();
	}

	public void SetSubShipGachaData(SubShipGachaData _data)
	{
		SubShipGachaData info = _data;
		for(int i = 0; i < m_SubShipGachaDataList.Count; i++)
		{
			if(info.Index == m_SubShipGachaDataList[i].Index)
			{
				m_SubShipGachaDataList[i] = info;
				return;
			}
		}
		m_SubShipGachaDataList.Add(info);
	}

	#region used for LuckyPresentGacha
	public string GetItemImageName(int _itemtype)
	{
		string itemname = "";

		if(_itemtype == 1)
		{
			itemname = "pop_img_missile3";
		}else if(_itemtype == 2)
		{
			itemname = "pop_img_gold2";
		}else if(_itemtype == 3)
		{
			itemname = "pop_img_crystal2";
		}else if(_itemtype == 4)
		{
			itemname = "lucky_luckyticket";
		}else if(_itemtype / 1000 == 1)
		{
			itemname = "shop_img_item" + (_itemtype%1000).ToString();
		}

		return itemname;
	}

	public string GetItemAmount(int _itemtype, int _amount)
	{
		string amountstring = "";
		if(_itemtype == 1)
		{
			amountstring = TextManager.Instance.GetString(98) + " +" + _amount.ToString();
		}else if(_itemtype == 2)
		{
			amountstring = TextManager.Instance.GetString(97) + " +" + _amount.ToString();;
		}else if(_itemtype == 3)
		{
			amountstring = TextManager.Instance.GetString(96) + " +" + _amount.ToString();;
		}else
		{
			//amountstring = GetGameItemName((_itemtype%1000), Managers.UserData.LanguageCode)+ " " + TextManager.Instance.GetReplaceString(181, _amount.ToString());
		}

		return amountstring;
	}
	#endregion
}

	