using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#region Game Balance Data
// GameCharacterInfoBalance
public struct GameCharacterInfoBalance {		
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

	private string m_AvailableTacticSlot;
	public int AvailableTacticSlot {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AvailableTacticSlot = encryptString ;
		}
		get { 
			if(m_AvailableTacticSlot == null || m_AvailableTacticSlot.Equals("")){
				return 2;	
			}
			string decryptString = LoadingWindows.NextD(m_AvailableTacticSlot,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private int[] m_AvailableTacticList;
	public int[] AvailableTacticList
	{
		set
		{
			m_AvailableTacticList = value;
		}
		get
		{
			if(m_AvailableTacticList == null)
			{
				m_AvailableTacticList = new int[]{1};
			}
			return m_AvailableTacticList;
		}
	}
} ;


// GameCharacterInfoMessageData
public struct GameCharacterInfoMessageData {
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
	
	private string _gameCharacterNameEn ;
	public string GameCharacterNameEn {
		get { return _gameCharacterNameEn ; }
		set { _gameCharacterNameEn = value ; }
	}
	
	private string _gameCharacterMessageEn ;
	public string GameCharacterMessageEn {
		get { return _gameCharacterMessageEn ; }
		set { _gameCharacterMessageEn = value ; }
	}
	
	private string _gameCharacterNameKo ;
	public string GameCharacterNameKo {
		get { return _gameCharacterNameKo ; }
		set { _gameCharacterNameKo = value ; }
	}
	
	private string _gameCharacterMessageKo ;
	public string GameCharacterMessageKo {
		get { return _gameCharacterMessageKo ; }
		set { _gameCharacterMessageKo = value ; }
	}
	
	private string _gameCharacterNameHant ;
	public string GameCharacterNameHant {
		get { return _gameCharacterNameHant ; }
		set { _gameCharacterNameHant = value ; }
	}
	
	private string _gameCharacterMessageHant ;
	public string GameCharacterMessageHant {
		get { return _gameCharacterMessageHant ; }
		set { _gameCharacterMessageHant = value ; }
	}
	
	private string _gameCharacterNameHans ;
	public string GameCharacterNameHans {
		get { return _gameCharacterNameHans ; }
		set { _gameCharacterNameHans = value ; }
	}
	
	private string _gameCharacterMessageHans ;
	public string GameCharacterMessageHans {
		get { return _gameCharacterMessageHans ; }
		set { _gameCharacterMessageHans = value ; }
	}
	
	private string _gameCharacterNameJa ;
	public string GameCharacterNameJa {
		get { return _gameCharacterNameJa ; }
		set { _gameCharacterNameJa = value ; }
	}
	
	private string _gameCharacterMessageJa ;
	public string GameCharacterMessageJa {
		get { return _gameCharacterMessageJa ; }
		set { _gameCharacterMessageJa = value ; }
	}
	
	private string _gameCharacterNameFr ;
	public string GameCharacterNameFr {
		get { return _gameCharacterNameFr ; }
		set { _gameCharacterNameFr = value ; }
	}
	
	private string _gameCharacterMessageFr ;
	public string GameCharacterMessageFr {
		get { return _gameCharacterMessageFr ; }
		set { _gameCharacterMessageFr = value ; }
	}
	
	private string _gameCharacterSpecialMessageKo ;
	public string GameCharacterSpecialMessageKo {
		get { return _gameCharacterSpecialMessageKo ; }
		set { _gameCharacterSpecialMessageKo = value ; }
	}
};

public struct StageData
{
	private string m_Index;
	public int Index
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_Locked;
	public int Locked
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Locked = encryptString ;
		}
		get {
			if(m_Locked == null || m_Locked.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Locked,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_WinCoinGetAmount;
	public int WinCoinGetAmount
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_WinCoinGetAmount = encryptString ;
		}
		get {
			if(m_WinCoinGetAmount == null || m_WinCoinGetAmount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_WinCoinGetAmount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_LoseCoinGetAmount;
	public int LoseCoinGetAmount
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_LoseCoinGetAmount = encryptString ;
		}
		get {
			if(m_LoseCoinGetAmount == null || m_LoseCoinGetAmount.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_LoseCoinGetAmount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_StageName ;
	public string StageName {
		set {
			m_StageName = value;
		}
		get {
			return m_StageName;
		}
	}

	private string m_BackgroundType;
	public int BackgroundType
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_BackgroundType = encryptString ;
		}
		get {
			if(m_BackgroundType == null || m_BackgroundType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_BackgroundType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_ClearType;
	public int ClearType
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ClearType = encryptString ;
		}
		get {
			if(m_ClearType == null || m_ClearType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ClearType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	public int[] SpawnShipIndexList;
	public float[] SpawnShipRatioList;

	private string m_SpawnShipMinNumb;
	public int SpawnShipMinNumb
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpawnShipMinNumb = encryptString ;
		}
		get {
			if(m_SpawnShipMinNumb == null || m_SpawnShipMinNumb.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpawnShipMinNumb,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_SpawnShipMaxNumb;
	public int SpawnShipMaxNumb
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpawnShipMaxNumb = encryptString ;
		}
		get {
			if(m_SpawnShipMaxNumb == null || m_SpawnShipMaxNumb.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpawnShipMaxNumb,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_SpawnTimer;
	public float SpawnTimer {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpawnTimer = encryptString ;
		}
		get {
			if(m_SpawnTimer == null || m_SpawnTimer.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpawnTimer,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	public int[] WaveIndexList;
	private string m_WaveRestTime;
	public float WaveRestTime {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_WaveRestTime = encryptString ;
		}
		get {
			if(m_WaveRestTime == null || m_WaveRestTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_WaveRestTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	public int[] m_ItemShipIndexList;
	public float[] m_ItemShipRatioList;

	private string m_ItemShipSpawnRatio;
	public float ItemShipSpawnRatio {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ItemShipSpawnRatio = encryptString ;
		}
		get {
			if(m_ItemShipSpawnRatio == null || m_ItemShipSpawnRatio.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ItemShipSpawnRatio,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_ItemShipMaxSpawnNumb;
	public int ItemShipMaxSpawnNumb {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ItemShipMaxSpawnNumb = encryptString ;
		}
		get {
			if(m_ItemShipMaxSpawnNumb == null || m_ItemShipMaxSpawnNumb.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ItemShipMaxSpawnNumb,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}
}

public struct StageWaveData
{
	private string m_Index;
	public int Index
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}
	public int[] EnemyIndexList;
}

public struct StageItemSpawnData
{
	private string m_Index;
	public int Index
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}
	public int[] StageItemIndexList;
	public float[] StageItemRatioList;
}

public struct StageItemData
{
	private string m_Index;
	public int Index
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_ImageIndex;
	public int ImageIndex
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ImageIndex = encryptString ;
		}
		get {
			if(m_ImageIndex == null || m_ImageIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ImageIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}
	
	private string m_EffectType;
	public int EffectType
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_EffectType = encryptString ;
		}
		get {
			if(m_EffectType == null || m_EffectType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_EffectType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_DurationType;
	public int DurationType
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_DurationType = encryptString ;
		}
		get {
			if(m_DurationType == null || m_DurationType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_DurationType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}
		
	private string m_Value1;
	public float Value1{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Value1 = encryptString ;
		}
		get {
			if(m_Value1 == null || m_Value1.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_Value1,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_Value2;
	public float Value2{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Value2 = encryptString ;
		}
		get {
			if(m_Value2 == null || m_Value2.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_Value2,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_Value3;
	public float Value3{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Value3 = encryptString ;
		}
		get {
			if(m_Value3 == null || m_Value3.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_Value3,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

}


public struct StageEnemyData
{
	private string m_Index;
	public int Index
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_EnemyType;
	public int EnemyType
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_EnemyType = encryptString ;
		}
		get {
			if(m_EnemyType == null || m_EnemyType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_EnemyType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_ItemSpawnIndex;
	public int ItemSpawnIndex
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ItemSpawnIndex = encryptString ;
		}
		get {
			if(m_ItemSpawnIndex == null || m_ItemSpawnIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ItemSpawnIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_MoveSpeed;
	public float MoveSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MoveSpeed = encryptString ;
		}
		get {
			if(m_MoveSpeed == null || m_MoveSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MoveSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_MoveForce;
	public float MoveForce {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MoveForce = encryptString ;
		}
		get {
			if(m_MoveForce == null || m_MoveForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MoveForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_RotationSpeed;
	public float RotationSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_RotationSpeed = encryptString ;
		}
		get {
			if(m_RotationSpeed == null || m_RotationSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_RotationSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_RotationForce;
	public float RotationForce {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_RotationForce = encryptString ;
		}
		get {
			if(m_RotationForce == null || m_RotationForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_RotationForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_Health;
	public int Health
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Health = encryptString ;
		}
		get {
			if(m_Health == null || m_Health.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Health,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}

	private string m_SpecialGaugeSpeed;
	public float SpecialGaugeSpeed
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialGaugeSpeed = encryptString ;
		}
		get {
			if(m_SpecialGaugeSpeed == null || m_SpecialGaugeSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialGaugeSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_SpecialGaugeMax;
	public float SpecialGaugeMax{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialGaugeMax = encryptString ;
		}
		get {
			if(m_SpecialGaugeMax == null || m_SpecialGaugeMax.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialGaugeMax,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_SpecialEffectValue;
	public float SpecialEffectValue{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue = encryptString ;
		}
		get {
			if(m_SpecialEffectValue == null || m_SpecialEffectValue.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_SpecialEffectValue2;
	public float SpecialEffectValue2{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue2 = encryptString ;
		}
		get {
			if(m_SpecialEffectValue2 == null || m_SpecialEffectValue2.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue2,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_SpecialEffectValue3;
	public float SpecialEffectValue3{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue3 = encryptString ;
		}
		get {
			if(m_SpecialEffectValue3 == null || m_SpecialEffectValue3.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue3,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_PlayerCrashDamage;
	public float PlayerCrashDamage{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PlayerCrashDamage = encryptString ;
		}
		get {
			if(m_PlayerCrashDamage == null || m_PlayerCrashDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PlayerCrashDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_SelfCrashDamage;
	public float SelfCrashDamage{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SelfCrashDamage = encryptString ;
		}
		get {
			if(m_SelfCrashDamage == null || m_SelfCrashDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SelfCrashDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_Weight;
	public float Weight{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Weight = encryptString ;
		}
		get {
			if(m_Weight == null || m_Weight.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_Weight,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_Score;
	public int Score
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Score = encryptString ;
		}
		get {
			if(m_Score == null || m_Score.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Score,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString);
			return decryptInt;
		}
	}
}

// GameSubmarineBulletInfoBalance
public struct ShipDescriptionInfo
{
	private string m_ShipIndex ;
	public int ShipIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipIndex = encryptString ;
		}
		get { 
			if(m_ShipIndex == null || m_ShipIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_ShipDisplayIndex ;
	public int ShipDisplayIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipDisplayIndex = encryptString ;
		}
		get { 
			if(m_ShipDisplayIndex == null || m_ShipDisplayIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipDisplayIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_ShipName ;
	public string ShipName {
		get { return m_ShipName ; }
		set { m_ShipName = value ; }
	}

	private string m_ShipDescription ;
	public string ShipDescription {
		get { return m_ShipDescription ; }
		set { m_ShipDescription = value ; }
	}

	private string m_ShipSpecialDescription ;
	public string ShipSpecialDescription {
		get { return m_ShipSpecialDescription ; }
		set { m_ShipSpecialDescription = value ; }
	}
}

public struct ShipStatInfo {		
	private string m_ShipIndex;
	public int ShipIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipIndex = encryptString ;
		}
		get { 
			if(m_ShipIndex == null || m_ShipIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ShipLevel;
	public int ShipLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipLevel = encryptString ;
		}
		get { 
			if(m_ShipLevel == null || m_ShipLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ValueType ; // 1:Gold , 2:Jewel
	public int ValueType { 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ValueType = encryptString ;
		}
		get { 
			if(m_ValueType == null || m_ValueType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ValueType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_Cost;
	public int Cost {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Cost = encryptString ;
		}
		get { 
			if(m_Cost == null || m_Cost.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Cost,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}


	private string m_Health ;
	public float Health {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Health = encryptString ;
		}
		get { 
			if(m_Health == null || m_Health.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_Health,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_MaxMoveSpeed ;
	public float MaxMoveSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MaxMoveSpeed = encryptString ;
		}
		get { 
			if(m_MaxMoveSpeed == null || m_MaxMoveSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MaxMoveSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_MoveForce ;
	public float MoveForce {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MoveForce = encryptString ;
		}
		get { 
			if(m_MoveForce == null || m_MoveForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MoveForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_MaxRotationSpeed;
	public float MaxRotationSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MaxRotationSpeed = encryptString ;
		}
		get { 
			if(m_MaxRotationSpeed == null || m_MaxRotationSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MaxRotationSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	//
	private string m_AttackType;
	public int AttackType { 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackType = encryptString ;
		}
		get { 
			if(m_AttackType == null || m_AttackType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_AttackGaugeSpeed ; //Attack Speed
	public float AttackGaugeSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackGaugeSpeed = encryptString ;
		}
		get { 
			if(m_AttackGaugeSpeed == null || m_AttackGaugeSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackGaugeSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_AttackMaxGauge ; //Attack Speed
	public float AttackMaxGauge {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackMaxGauge = encryptString ;
		}
		get { 
			if(m_AttackMaxGauge == null || m_AttackMaxGauge.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackMaxGauge,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_BulletDamage ;
	public float BulletDamage {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_BulletDamage = encryptString ;
		}
		get { 
			if(m_BulletDamage == null || m_BulletDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_BulletDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_BulletPushForce ;
	public float BulletPushForce{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_BulletPushForce = encryptString ;
		}
		get { 
			if(m_BulletPushForce == null || m_BulletPushForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_BulletPushForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString);
			return decryptFloat;
		}
	}


	private string m_BulletSpeed ;
	public float BulletSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_BulletSpeed = encryptString ;
		}
		get { 
			if(m_BulletSpeed == null || m_BulletSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_BulletSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_PushDamage;
	public float PushDamage {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PushDamage = encryptString ;
		}
		get { 
			if(m_PushDamage == null || m_PushDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PushDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_PushForce ;
	public float PushForce {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PushForce = encryptString ;
		}
		get { 
			if(m_PushForce == null || m_PushForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PushForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_AttackGrade;
	public float AttackGrade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackGrade = encryptString ;
		}
		get { 
			if(m_AttackGrade == null || m_AttackGrade.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackGrade,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_DefenseGrade;
	public float DefenseGrade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_DefenseGrade = encryptString ;
		}
		get { 
			if(m_DefenseGrade == null || m_DefenseGrade.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_DefenseGrade,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_MovementGrade;
	public float MovementGrade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MovementGrade = encryptString ;
		}
		get { 
			if(m_MovementGrade == null || m_MovementGrade.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MovementGrade,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
} ;


public struct SubShipDescriptionInfo
{
	private string m_ShipIndex ;
	public int ShipIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipIndex = encryptString ;
		}
		get { 
			if(m_ShipIndex == null || m_ShipIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_Grade;
	public int Grade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Grade = encryptString ;
		}
		get { 
			if(m_Grade == null || m_Grade.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Grade,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ShipName ;
	public string ShipName {
		get { return m_ShipName ; }
		set { m_ShipName = value ; }
	}
	
	private string m_ShipDescription ;
	public string ShipDescription {
		get { return m_ShipDescription ; }
		set { m_ShipDescription = value ; }
	}
	
	private string m_ShipSpecialDescription ;
	public string ShipSpecialDescription {
		get { return m_ShipSpecialDescription ; }
		set { m_ShipSpecialDescription = value ; }
	}
}

public struct SubShipStatInfo {		
	private string m_ShipIndex ;
	public int ShipIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipIndex = encryptString ;
		}
		get { 
			if(m_ShipIndex == null || m_ShipIndex.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ShipLevel ;
	public int ShipLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipLevel = encryptString ;
		}
		get { 
			if(m_ShipLevel == null || m_ShipLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ValueType ; // 1:Gold , 2:Jewel
	public int ValueType { 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ValueType = encryptString ;
		}
		get { 
			if(m_ValueType == null || m_ValueType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_ValueType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_Cost;
	public int Cost {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Cost = encryptString ;
		}
		get { 
			if(m_Cost == null || m_Cost.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Cost,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	
	private string m_Health ;
	public float Health {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Health = encryptString ;
		}
		get { 
			if(m_Health == null || m_Health.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_Health,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_MaxMoveSpeed ;
	public float MaxMoveSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MaxMoveSpeed = encryptString ;
		}
		get { 
			if(m_MaxMoveSpeed == null || m_MaxMoveSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MaxMoveSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_MoveForce ;
	public float MoveForce {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MoveForce = encryptString ;
		}
		get { 
			if(m_MoveForce == null || m_MoveForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MoveForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_MaxRotationSpeed;
	public float MaxRotationSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MaxRotationSpeed = encryptString ;
		}
		get { 
			if(m_MaxRotationSpeed == null || m_MaxRotationSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MaxRotationSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	
	private string m_SpecialGaugeSpeed;
	public float SpecialGaugeSpeed
	{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialGaugeSpeed = encryptString ;
		}
		get {
			if(m_SpecialGaugeSpeed == null || m_SpecialGaugeSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialGaugeSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_SpecialGaugeMax;
	public float SpecialGaugeMax{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialGaugeMax = encryptString ;
		}
		get {
			if(m_SpecialGaugeMax == null || m_SpecialGaugeMax.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialGaugeMax,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_SpecialEffectValue;
	public float SpecialEffectValue{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue = encryptString ;
		}
		get {
			if(m_SpecialEffectValue == null || m_SpecialEffectValue.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_SpecialEffectValue2;
	public float SpecialEffectValue2{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue2 = encryptString ;
		}
		get {
			if(m_SpecialEffectValue2 == null || m_SpecialEffectValue2.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue2,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string m_SpecialEffectValue3;
	public float SpecialEffectValue3{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue3 = encryptString ;
		}
		get {
			if(m_SpecialEffectValue3 == null || m_SpecialEffectValue3.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue3,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string m_SpecialEffectValue4;
	public float SpecialEffectValue4{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue4 = encryptString ;
		}
		get {
			if(m_SpecialEffectValue4 == null || m_SpecialEffectValue4.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue4,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}


	private string m_SpecialEffectValue5;
	public float SpecialEffectValue5{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SpecialEffectValue5 = encryptString ;
		}
		get {
			if(m_SpecialEffectValue5 == null || m_SpecialEffectValue5.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_SpecialEffectValue5,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	
	private string m_PushDamage;
	public float PushDamage {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PushDamage = encryptString ;
		}
		get { 
			if(m_PushDamage == null || m_PushDamage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PushDamage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_PushForce ;
	public float PushForce {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PushForce = encryptString ;
		}
		get { 
			if(m_PushForce == null || m_PushForce.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_PushForce,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_AttackGrade;
	public float AttackGrade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackGrade = encryptString ;
		}
		get { 
			if(m_AttackGrade == null || m_AttackGrade.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackGrade,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_DefenseGrade;
	public float DefenseGrade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_DefenseGrade = encryptString ;
		}
		get { 
			if(m_DefenseGrade == null || m_DefenseGrade.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_DefenseGrade,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_MovementGrade;
	public float MovementGrade {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MovementGrade = encryptString ;
		}
		get { 
			if(m_MovementGrade == null || m_MovementGrade.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_MovementGrade,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
} ;


public struct SubShipTacTic
{
	private string m_Index ;
	public int Index {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_TacticName ;
	public string TacticName {
		set {
			m_TacticName = value;
		}
		get {
			return m_TacticName;
		}
	}
	
	
	private string m_ShipPosX1;
	public float ShipPosX1 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosX1 = encryptString ;
		}
		get { 
			if(m_ShipPosX1 == null || m_ShipPosX1.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosX1,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosY1;
	public float ShipPosY1 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosY1 = encryptString ;
		}
		get { 
			if(m_ShipPosY1 == null || m_ShipPosY1.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosY1,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosX2;
	public float ShipPosX2 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosX2 = encryptString ;
		}
		get { 
			if(m_ShipPosX2 == null || m_ShipPosX2.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosX2,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosY2;
	public float ShipPosY2 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosY2 = encryptString ;
		}
		get { 
			if(m_ShipPosY2 == null || m_ShipPosY2.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosY2,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosX3;
	public float ShipPosX3 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosX3 = encryptString ;
		}
		get { 
			if(m_ShipPosX3 == null || m_ShipPosX3.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosX3,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosY3;
	public float ShipPosY3 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosY3 = encryptString ;
		}
		get { 
			if(m_ShipPosY3 == null || m_ShipPosY3.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosY3,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosX4;
	public float ShipPosX4 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosX4 = encryptString ;
		}
		get { 
			if(m_ShipPosX4 == null || m_ShipPosX4.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosX4,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	private string m_ShipPosY4;
	public float ShipPosY4 {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipPosY4 = encryptString ;
		}
		get { 
			if(m_ShipPosY4 == null || m_ShipPosY4.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipPosY4,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
}


public struct SubShipGachaData
{
	private string m_Index ;
	public int Index {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Index = encryptString ;
		}
		get {
			if(m_Index == null || m_Index.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_Index,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_CostType;
	public int CostType {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_CostType = encryptString ;
		}
		get { 
			if(m_CostType == null || m_CostType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_CostType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_CostValue;
	public int CostValue {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_CostValue = encryptString ;
		}
		get { 
			if(m_CostValue == null || m_CostValue.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_CostValue,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string[] m_GradeList;
	public int[] GradeList {
		set { 
			m_GradeList = new string[value.Length];
			for(int i = 0; i < value.Length; i++)
			{
				string encryptString = LoadingWindows.NextE(value[i].ToString(),Constant.DefalutAppName) ;
				m_GradeList[i] = encryptString ;
			}
		}
		get {
			if(m_GradeList == null){
				return new int[]{0};	
			}

			int[] gradelist = new int[m_GradeList.Length];
			for(int i = 0; i < gradelist.Length; i++)
			{
				string decryptString = LoadingWindows.NextD(m_GradeList[i],Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				gradelist[i] = decryptInt;
			}
			return gradelist;
		}
	}

	private string[] m_GradeRatioList;
	public float[] GradeRatioList {
		set { 
			m_GradeRatioList = new string[value.Length];
			for(int i = 0; i < value.Length; i++)
			{
				string encryptString = LoadingWindows.NextE(value[i].ToString(),Constant.DefalutAppName) ;
				m_GradeRatioList[i] = encryptString ;
			}
		}
		get {
			if(m_GradeRatioList == null){
				return new float[]{0};	
			}
			
			float[] gradelist = new float[m_GradeRatioList.Length];
			for(int i = 0; i < gradelist.Length; i++)
			{
				string decryptString = LoadingWindows.NextD(m_GradeRatioList[i],Constant.DefalutAppName) ;
				float decryptInt = float.Parse(decryptString) ;
				gradelist[i] = decryptInt;
			}
			return gradelist;
		}
	}
}
#endregion 

#region User Data
public struct UserShipData {
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
	
	private string _Level ; //1 ~30 (== Bullet Upgrade Grade!!)
	public int Level {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_Level = encryptString ;
		}
		get {
			if(_Level == null || _Level.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_Level,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
			//return 1;
		}
	}

	private string m_IsLocked ;
	public bool IsLocked {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_IsLocked = encryptString ;
		}
		get { 
			if(m_IsLocked == null || m_IsLocked.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_IsLocked,Constant.DefalutAppName) ;
			
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


public struct UserSubShipData {
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
			//return 1;
		}
	}
	
	private string _Level ; //1 ~30 (== Bullet Upgrade Grade!!)
	public int Level {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_Level = encryptString ;
		}
		get {
			if(_Level == null || _Level.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_Level,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
			//return 1;
		}
	}
} ;

public struct UserStageData {
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
	
	private string m_IsClear ;
	public bool IsClear {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_IsClear = encryptString ;
		}
		get { 
			if(m_IsClear == null || m_IsClear.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_IsClear,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	
	private string m_IsOpen ;
	public bool IsOpen {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_IsOpen = encryptString ;
		}
		get { 
			if(m_IsOpen == null || m_IsOpen.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_IsOpen,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_MaxScore ;
	public int MaxScore {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_MaxScore = encryptString ;
		}
		get {
			if(m_MaxScore == null || m_MaxScore.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(m_MaxScore,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
};

public struct GameCharacter {
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

	private string m_SelectedTactic ;
	public int SelectedTactic {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_SelectedTactic = encryptString ;
		}
		get {
			if(m_SelectedTactic == null || m_SelectedTactic.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_SelectedTactic,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
} ;

public struct UserHistoryData
{
	public UserInfoData m_UserInfoData;
	private string m_PastSecond;
	public int PastSecond {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_PastSecond = encryptString ;
		}
		get {
			if(m_PastSecond == null || m_PastSecond.Equals("")){
				return 0;	
			}
			string decryptString = LoadingWindows.NextD(m_PastSecond,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_Win ;
	public bool Win {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Win = encryptString ;
		}
		get { 
			if(m_Win == null || m_Win.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_Win,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}

	private string m_AttackHistory;
	public bool AttackHistory {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_AttackHistory = encryptString ;
		}
		get { 
			if(m_AttackHistory == null || m_AttackHistory.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(m_AttackHistory,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
}

public struct UserInfoData
{
	private string m_UserIndex;
	public int UserIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_UserIndex = encryptString ;
		}
		get {
			if(m_UserIndex == null || m_UserIndex.Equals("")){
				return 0;	
			}
			string decryptString = LoadingWindows.NextD(m_UserIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	public string UserNickName;

	private string m_RepairSecond;
	public int RepairSecond {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_RepairSecond = encryptString ;
		}
		get {
			if(m_RepairSecond == null || m_RepairSecond.Equals("")){
				return 0;	
			}
			string decryptString = LoadingWindows.NextD(m_RepairSecond,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_RewardAmount;
	public int RewardAmount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_RewardAmount = encryptString ;
		}
		get {
			if(m_RewardAmount == null || m_RewardAmount.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_RewardAmount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_CharacterIndex;
	public int CharacterIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_CharacterIndex = encryptString ;
		}
		get {
			if(m_CharacterIndex == null || m_CharacterIndex.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_CharacterIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_TacticIndex;
	public int TacticIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_TacticIndex = encryptString ;
		}
		get {
			if(m_TacticIndex == null || m_TacticIndex.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_TacticIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_ShipIndex;
	public int ShipIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipIndex = encryptString ;
		}
		get {
			if(m_ShipIndex == null || m_ShipIndex.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_ShipLevel;
	public int ShipLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipLevel = encryptString ;
		}
		get {
			if(m_ShipLevel == null || m_ShipLevel.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string[] m_SubShipIndexList;
	public int[] SubShipIndexList {
		set { 
			m_SubShipIndexList = new string[value.Length];
			for(int i = 0; i < value.Length; i++)
			{
				string encryptString = LoadingWindows.NextE(value[i].ToString(),Constant.DefalutAppName) ;
				m_SubShipIndexList[i] = encryptString ;
			}
			//Debug.Log("SET CALLED");
		}
		get {
			if(m_SubShipIndexList == null){
				return new int[]{0};	
			}
			
			int[] gradelist = new int[m_SubShipIndexList.Length];
			for(int i = 0; i < gradelist.Length; i++)
			{
				string decryptString = LoadingWindows.NextD(m_SubShipIndexList[i],Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				gradelist[i] = decryptInt;
			}
			//Debug.Log("Get called///??");
			return gradelist;
		}
	}

	private string[] m_SubShipLevelList;
	public int[] SubShipLevelList {
		set { 
			m_SubShipLevelList = new string[value.Length];
			for(int i = 0; i < value.Length; i++)
			{
				string encryptString = LoadingWindows.NextE(value[i].ToString(),Constant.DefalutAppName) ;
				m_SubShipLevelList[i] = encryptString ;
			}
		}
		get {
			if(m_SubShipLevelList == null){
				return new int[]{0};	
			}
			
			int[] gradelist = new int[m_SubShipLevelList.Length];
			for(int i = 0; i < gradelist.Length; i++)
			{
				string decryptString = LoadingWindows.NextD(m_SubShipLevelList[i],Constant.DefalutAppName) ;
				int decryptInt = int.Parse(decryptString) ;
				gradelist[i] = decryptInt;
			}
			return gradelist;
		}
	}
}

public struct UserPVPRankInfoData
{
	public int UserIndex;
	public string UserNickName;

	private string m_Rank;
	public int Rank {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_Rank = encryptString ;
		}
		get {
			if(m_Rank == null || m_Rank.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_Rank,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_CharacterIndex;
	public int CharacterIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_CharacterIndex = encryptString ;
		}
		get {
			if(m_CharacterIndex == null || m_CharacterIndex.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_CharacterIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
		
	private string m_ShipIndex;
	public int ShipIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipIndex = encryptString ;
		}
		get {
			if(m_ShipIndex == null || m_ShipIndex.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ShipLevel;
	public int ShipLevel {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ShipLevel = encryptString ;
		}
		get {
			if(m_ShipLevel == null || m_ShipLevel.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_ShipLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string m_WinCount;
	public int WinCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_WinCount = encryptString ;
		}
		get {
			if(m_WinCount == null || m_WinCount.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_WinCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}


	private string m_LoseCount;
	public int LoseCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_LoseCount = encryptString ;
		}
		get {
			if(m_LoseCount == null || m_LoseCount.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_LoseCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

}

public struct PVPRewardData
{
	public string WinColor;

	private string m_WinCount;
	public int WinCount {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_WinCount = encryptString ;
		}
		get {
			if(m_WinCount == null || m_WinCount.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_WinCount,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string m_ImageIndex;
	public int ImageIndex {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			m_ImageIndex = encryptString ;
		}
		get {
			if(m_ImageIndex == null || m_ImageIndex.Equals("")){
				return 1;	
			}
			string decryptString = LoadingWindows.NextD(m_ImageIndex,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	public string RewardString;
}
#endregion