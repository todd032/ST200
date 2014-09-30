using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Submarine : MonoBehaviour {

	private Vector3 m_NormalColliderSize = new Vector3(0.2f, 0.14f, 4f);
	private Vector3 m_BoosterColliderSize = new Vector3(1.1f,1.5f,4f);

	[HideInInspector]
	public delegate void SubmarineStateDelegate(Submarine submarine, int state);
	protected SubmarineStateDelegate _submarineStateDelegate ;
	public event SubmarineStateDelegate SubmarineStateEvent {
		add{
			_submarineStateDelegate = null ;
			if (_submarineStateDelegate == null) {
        		_submarineStateDelegate += value;
			}
        }
		remove{
            _submarineStateDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void SubmarineCrashDelegate(Submarine submarine, int state);
	protected SubmarineCrashDelegate _submarineCrashDelegate ;
	public event SubmarineCrashDelegate SubmarineCrashEvent {
		add{
			_submarineCrashDelegate = null ;
			if (_submarineCrashDelegate == null) {
        		_submarineCrashDelegate += value;
			}
        }
		remove{
            _submarineCrashDelegate -= value;
		}
	}

	protected SubmarineStateDelegate _submarineHealthReducedDelegate;
	public event SubmarineStateDelegate SubmarineHealthReducedEvent
	{
		add{
			_submarineHealthReducedDelegate = null ;
			if (_submarineHealthReducedDelegate == null) {
				_submarineHealthReducedDelegate += value;
			}
		}
		remove{
			_submarineHealthReducedDelegate -= value;
		}
	}

	[HideInInspector]
	public delegate void SubmarineGetItemDelegate(Submarine submarine, DropItemObject dropItem, int state);
	protected SubmarineGetItemDelegate _submarineGetItemDelegate ;
	public event SubmarineGetItemDelegate SubmarineGetItemEvent {
		add{
			_submarineGetItemDelegate = null ;
			if (_submarineGetItemDelegate == null) {
        		_submarineGetItemDelegate += value;
			}
        }
		remove{
            _submarineGetItemDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void SubmarineGetCoinDelegate(Submarine submarine, int state, int whereInfo); //WhereInfo 1 : Drop Item , 2 : Coin Pattern, 3 : Coin Magnet
	protected SubmarineGetCoinDelegate _submarineGetCoinDelegate ;
	public event SubmarineGetCoinDelegate SubmarineGetCoinEvent {
		add{
			_submarineGetCoinDelegate = null ;
			if (_submarineGetCoinDelegate == null) {
        		_submarineGetCoinDelegate += value;
			}
        }
		remove{
            _submarineGetCoinDelegate -= value;
		}
	}
	
	
	
	
	[HideInInspector]
	public enum CharacterState {
		Idle,
		Ready,
		StartBoosterReady,
		StartBooster,
		Play,
		Fever,
		Booster, //
		Dead,
		ReviveWait,
		Revive,
		LastBoosterReady,
		LastBooster,
		GameOver,
	}  ;
	
	
	private CharacterState _characterState = CharacterState.Idle ;

	//[HideInInspector]
	public float _MaxHealth = 100f;
	//[HideInInspector]
	public float _Health = 100f;
	public Transform _bulletLuncherSp;	
	public Transform _subweapon1Sp;
	public Transform _subweapon2Sp;
	
	public GameObject _submarineBodyObject; //Prefab
	private SubmarineBody _submarineBody ; //Script Component
	
	public GameObject _submarineDrivingEffectObject ; //Prefab
	private SubmarineDrivingEffect _submarineDrivingEffect ; //Script Component
	
	public GameObject _submarineShieldEffectObject ; //Prefab
	private SubmarineShieldEffectObject _submarineShieldEffect ; //Script Component
	
	public GameObject _submarineMagnetEffectObject ; //Prefab
	private SubmarineMagnetEffectObject _submarineMagnetEffect ; //Script Component
	
	public GameObject _submarineDoubleScoreEffectObject ; //Prefab
	private SubmarineDoubleScoreEffectObject _submarineDoubleScoreEffect ; //Script Component
	
	public GameObject _submarinePowerShotEffectObject ; //Prefab
	private SubmarinePowerShotEffectObject _submarinePowerShotEffect ; //Script Component
	
	public GameObject _submarineBoosterEffectObject ; //Prefab
	private SubmarineBoosterEffectObject _submarineBoosterEffect ; //Script Component
	
	public GameObject _submarineStartBoosterEffectObject ; //Prefab
	private SubmarineBoosterEffectObject _submarineStartBoosterEffect ; //Script Component
	
	public GameObject _submarineLastBoosterEffectObject ; //Prefab
	private SubmarineBoosterEffectObject _submarineLastBoosterEffect ; //Script Component
	
	
	public GameObject _submarineFeverModeEffectObject ; //Prefab
	private SubmarineFeverModeEffectObject _submarineFeverModeEffect ; //Script Component
	
	public GameObject _submarineDeadReadyEffectObject ; //Prefab
	private SubmarineDeadReadyEffectObject _submarineDeadReadyEffect ; //Script Component
	
	
	/*
	public GameObject _subMarineDeadBubEffectObject ; //Prefab
	private SubMarineDeadBubEffectObject _subMarineDeadBubEffect ; //Script Component
	
	public GameObject _subMarineDeadSmokeEffectObject ; //Prefab
	private SubMarineDeadSmokeEffectObject _subMarineDeadSmokeEffect ; //Script Component
	*/
	
	public GameObject _submarineBulletObject ; //Prefab
	public GameObject _bulletEffectObject;

	public GameObject _shootEffect;

	// private 
	private GameObject _thisGameObject ;
	public GameObject ThisGameObject
    {
        get { return _thisGameObject ; }
    }
	
	private Transform _thisTransform ;
	public Transform ThisTransform
    {
        get { return _thisTransform ; }
    }
	
	private bool _isInvincibilityAction = false ;
	
	
	// Setting Submarine Data
	// Move!!
	private float _subMarineSpeed ;
	private int _subMarineSpeedMultiple ; //subMarine Moving Speed Multiple *1, *2, *3.
	public float SubMarineSpeed{ 
		get{	return _subMarineSpeed;	}
		set{ _subMarineSpeed = value; }
	}
	public int SubMarineSpeedMultiple{ 
		get{  return _subMarineSpeedMultiple;	}
		set{  _subMarineSpeedMultiple    = value; }
	}
	
	// Submarine Info
	private string _subMarineNum ;
	public int SubmarineNum{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subMarineNum = encryptString ;
		}
		get {
			if(_subMarineNum == null || _subMarineNum.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subMarineNum,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private string _energyLevel ;
	public int EnergyLevel{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_energyLevel = encryptString ;
		}
		get {
			if(_energyLevel == null || _energyLevel.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_energyLevel,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	// Submarine Bullet Info
	private string _bulletLevel ;
	public int BulletLevel{ 
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
		}
	}
	private string _bulletType ;
	public int BulletType{
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
	private string _bulletDamage ;
	public float BulletDamage{ 
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
	private string _bulletDelayTime ;
	public float BulletDelayTime{ 
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
	private string _bulletSpeed ;
	public float BulletSpeed{
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
	private string _bulletSlowEffect ;
	public float BulletSlowEffect{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_bulletSlowEffect = encryptString ;
		}
		get {
			if(_bulletSlowEffect == null || _bulletSlowEffect.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_bulletSlowEffect,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	//pet info
	private string _pet1Num ;
	public int Pet1Num{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_pet1Num = encryptString ;
		}
		get {
			if(_pet1Num == null || _pet1Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_pet1Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _pet2Num ;
	public int Pet2Num{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_pet2Num = encryptString ;
		}
		get {
			if(_pet2Num == null || _pet2Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_pet2Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}

	private PetObject _Pet1;
	private PetObject _Pet2;

	// Subweapon Info
	private SubweaponObject _gameSubweapon1 ;
	private SubweaponObject _gameSubweapon2 ;
	
	private string _subWeapon1Num ;
	public int SubWeapon1Num{
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1Num = encryptString ;
		}
		get {
			if(_subWeapon1Num == null || _subWeapon1Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon1Grade ;
	public int SubWeapon1Grade{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1Grade = encryptString ;
		}
		get {
			if(_subWeapon1Grade == null || _subWeapon1Grade.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1Grade,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon1Type ;
	public int SubWeapon1Type{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1Type = encryptString ;
		}
		get {
			if(_subWeapon1Type == null || _subWeapon1Type.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1Type,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon1BulletType ;
	public int SubWeapon1BulletType{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1BulletType = encryptString ;
		}
		get {
			if(_subWeapon1BulletType == null || _subWeapon1BulletType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1BulletType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon1Damage ;
	public float SubWeapon1Damage{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1Damage = encryptString ;
		}
		get {
			if(_subWeapon1Damage == null || _subWeapon1Damage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1Damage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _subWeapon1DelayTime ;
	public float SubWeapon1DelayTime{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1DelayTime = encryptString ;
		}
		get {
			if(_subWeapon1DelayTime == null || _subWeapon1DelayTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1DelayTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _subWeapon1BulletSpeed ;
	public float SubWeapon1BulletSpeed{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon1BulletSpeed = encryptString ;
		}
		get {
			if(_subWeapon1BulletSpeed == null || _subWeapon1BulletSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon1BulletSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	
	private string _subWeapon2Num ;
	public int SubWeapon2Num{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2Num = encryptString ;
		}
		get {
			if(_subWeapon2Num == null || _subWeapon2Num.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2Num,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon2Grade ;
	public int SubWeapon2Grade{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2Grade = encryptString ;
		}
		get {
			if(_subWeapon2Grade == null || _subWeapon2Grade.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2Grade,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon2Type ;
	public int SubWeapon2Type{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2Type = encryptString ;
		}
		get {
			if(_subWeapon2Type == null || _subWeapon2Type.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2Type,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon2BulletType ;
	public int SubWeapon2BulletType{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2BulletType = encryptString ;
		}
		get {
			if(_subWeapon2BulletType == null || _subWeapon2BulletType.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2BulletType,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	private string _subWeapon2Damage ;
	public float SubWeapon2Damage{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2Damage = encryptString ;
		}
		get {
			if(_subWeapon2Damage == null || _subWeapon2Damage.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2Damage,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _subWeapon2DelayTime ;
	public float SubWeapon2DelayTime{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2DelayTime = encryptString ;
		}
		get {
			if(_subWeapon2DelayTime == null || _subWeapon2DelayTime.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2DelayTime,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	private string _subWeapon2BulletSpeed ;
	public float SubWeapon2BulletSpeed{ 
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_subWeapon2BulletSpeed = encryptString ;
		}
		get {
			if(_subWeapon2BulletSpeed == null || _subWeapon2BulletSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_subWeapon2BulletSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	
	
	private string _bulletSpriteName ; //= "Bullet_" + SubmarineNum.ToString() + "_" + BulletLevel.ToString() ;
	
	
	// Item State
	private string _isGetItemPowerShot ;
	private bool GetItemPowerShot {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_isGetItemPowerShot = encryptString ;
		}
		get { 
			if(_isGetItemPowerShot == null || _isGetItemPowerShot.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_isGetItemPowerShot,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	
	
	/// Move
	//subMarine mover factor
	private bool _isMove = false;
	private bool _isTouchable = true;
	public bool IsTouchable {
		get {return _isTouchable;}
		set { _isTouchable = value ;}
	}
	private Vector3 currentPosition = Vector3.zero;
	private Vector3 newPosition = Vector3.zero;	
	///
	
	
	// Screen Size..
	public float screenSizeWidth ;
	public float screenSizeHeight ;
	//


	private void Awake (){
		_MaxHealth = 200f;
		_Health = _MaxHealth;
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
	
		
		// Screen Size Info..
		screenSizeHeight = 2f * Camera.main.orthographicSize;
		screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		//
		
		
		
		_submarineBody = _submarineBodyObject.GetComponent<SubmarineBody>() as SubmarineBody; 
		_submarineBody.OnTriggerEnterEx += OnTriggerEnterEx;
		_submarineBody.OnTriggerStayEx += OnTriggerStayEx;
		_submarineBody.InvincibilityActionDone += InvincibilityActionDone ;
		
		
		_submarineDrivingEffect = _submarineDrivingEffectObject.GetComponent<SubmarineDrivingEffect>() as SubmarineDrivingEffect ;
		_submarineShieldEffect = _submarineShieldEffectObject.GetComponent<SubmarineShieldEffectObject>() as SubmarineShieldEffectObject ;
		_submarineMagnetEffect = _submarineMagnetEffectObject.GetComponent<SubmarineMagnetEffectObject>() as SubmarineMagnetEffectObject ;
		_submarineDoubleScoreEffect = _submarineDoubleScoreEffectObject.GetComponent<SubmarineDoubleScoreEffectObject>() as SubmarineDoubleScoreEffectObject ;
		_submarinePowerShotEffect = _submarinePowerShotEffectObject.GetComponent<SubmarinePowerShotEffectObject>() as SubmarinePowerShotEffectObject ;
		_submarineBoosterEffect = _submarineBoosterEffectObject.GetComponent<SubmarineBoosterEffectObject>() as SubmarineBoosterEffectObject ;
		
		_submarineStartBoosterEffect = _submarineStartBoosterEffectObject.GetComponent<SubmarineBoosterEffectObject>() as SubmarineBoosterEffectObject ;
		_submarineLastBoosterEffect = _submarineLastBoosterEffectObject.GetComponent<SubmarineBoosterEffectObject>() as SubmarineBoosterEffectObject ;
		
		_submarineFeverModeEffect = _submarineFeverModeEffectObject.GetComponent<SubmarineFeverModeEffectObject>() as SubmarineFeverModeEffectObject ;
		
		_submarineDeadReadyEffect = _submarineDeadReadyEffectObject.GetComponent<SubmarineDeadReadyEffectObject>() as SubmarineDeadReadyEffectObject ;
		
		
		//_subMarineDeadBubEffect = _subMarineDeadBubEffectObject.GetComponent<SubMarineDeadBubEffectObject>() as SubMarineDeadBubEffectObject ;
		//_subMarineDeadSmokeEffect = _subMarineDeadSmokeEffectObject.GetComponent<SubMarineDeadSmokeEffectObject>() as SubMarineDeadSmokeEffectObject ;


		
		// Setting Submarine Bullet Pool Object
		PoolManager.instance.CreatePrefabPool(_submarineBulletObject,20) ;
		//
		
		// Setting Submarine Bullet Effect Pool Object
		PoolManager.instance.CreatePrefabPool(_bulletEffectObject,10) ;
		//
		
		//
		GetItemPowerShot = false ;
		
		_shootEffect.SetActive (false);
	}
	
	private void Start () {
		
	}
	
	Vector3 touchstartposition;
	Vector3 touchcurrentposition;
	Vector3 touchpreviousposition;
	Vector3 submarinetouchedstartposition;
	Vector3 submarinedestinationposition;
	private void Update () {

		if (!IsTouchable) {
			_isMove = false ;
			return;
		}
		
			
		if(_characterState ==  CharacterState.Play || _characterState == CharacterState.Booster || 
			_characterState == CharacterState.StartBooster || _characterState == CharacterState.LastBooster ||
			_characterState == CharacterState.Fever ){

//			Debug.Log("Input.touchCount = " + Input.touchCount);
#if UNITY_EDITOR
			if (Input.GetMouseButtonDown(0)){
				
				_isMove = true;
				
				currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				touchstartposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				touchcurrentposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				touchpreviousposition = touchcurrentposition;
				submarinetouchedstartposition = _thisTransform.position;
			}

			if(Input.GetMouseButton(0))
			{
				newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				touchcurrentposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

				Vector3 touchdirection = touchcurrentposition - touchpreviousposition;
				submarinedestinationposition = submarinetouchedstartposition + (touchcurrentposition - touchstartposition) * 1.5f;// + touchdirection;
				submarinedestinationposition.z = _thisTransform.position.z;
				touchpreviousposition = touchcurrentposition;
			}else
			{
				submarinedestinationposition = _thisTransform.position;
			}
			
			if (Input.GetMouseButtonUp(0)){
				
				_isMove = false;
			}

			if(Input.GetKeyDown(KeyCode.Space))
			{
				_Health = 100f;
			}
#else
			if (Input.GetMouseButtonDown(0)){
				
				_isMove = true;

				Touch touch = Input.GetTouch(0);

				currentPosition = Camera.main.ScreenToWorldPoint(touch.position);
				newPosition = Camera.main.ScreenToWorldPoint(touch.position);
				
				touchstartposition = Camera.main.ScreenToWorldPoint(touch.position);
				touchcurrentposition = Camera.main.ScreenToWorldPoint(touch.position);
				touchpreviousposition = touchcurrentposition;
				submarinetouchedstartposition = _thisTransform.position;
			}
			
			if(Input.GetMouseButton(0))
			{
				Touch touch = Input.GetTouch(0);
				newPosition = Camera.main.ScreenToWorldPoint(touch.position);
				touchcurrentposition = Camera.main.ScreenToWorldPoint(touch.position);
				
				Vector3 touchdirection = touchcurrentposition - touchpreviousposition;
				submarinedestinationposition = submarinetouchedstartposition + (touchcurrentposition - touchstartposition) * 1.5f;// + touchdirection;
				submarinedestinationposition.z = _thisTransform.position.z;
				touchpreviousposition = touchcurrentposition;
			}else
			{
				submarinedestinationposition = _thisTransform.position;
			}
			
			if (Input.GetMouseButtonUp(0)){
				
				_isMove = false;
			}
#endif
			/*
			Vector2 pos = Camera.main.WorldToScreenPoint(_thisTransform.position);
			if(pos.y < Screen.height * 0.1f){
				//Vector3 newpos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height * 0.1f,0));
				Vector3 newpos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height * 0.1f,0));
				_thisTransform.position = new Vector3(_thisTransform.position.x,newpos.y,_thisTransform.position.z);
			}else if (pos.y > Screen.height * 0.9f){
				//Vector3 newpos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height * 0.9f,0));
				Vector3 newpos = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height * 0.9f,0));
				_thisTransform.position = new Vector3(_thisTransform.position.x,newpos.y,_thisTransform.position.z);
			}
			*/
		}else
		{
			submarinedestinationposition = _thisTransform.position;
		}
		
	}

	void FixedUpdate()
	{
		if (!IsTouchable) {
			_isMove = false ;
			return;
		}

		if(_characterState ==  CharacterState.Play || _characterState == CharacterState.Booster || 
		   _characterState == CharacterState.StartBooster || _characterState == CharacterState.LastBooster ||
		   _characterState == CharacterState.Fever )
		{
			_thisTransform.position = submarinedestinationposition;//Vector3.Lerp(_thisTransform.position, submarinedestinationposition, 1f);
			// 잠수함 이동 제한.
			if (_thisTransform.position.y > 0.8f){
				
				_thisTransform.position = new Vector3(_thisTransform.position.x , 0.8f , _thisTransform.position.z) ;
				
			}else if (_thisTransform.position.y < -0.6f){
				
				_thisTransform.position = new Vector3(_thisTransform.position.x ,  -0.6f , _thisTransform.position.z) ;
			}
			
			if (_thisTransform.position.x > 1.3f){
				
				_thisTransform.position = new Vector3(1.3f , _thisTransform.position.y , _thisTransform.position.z) ;
				
			}else if (_thisTransform.position.x < -1.3f){
				
				_thisTransform.position = new Vector3(-1.3f , _thisTransform.position.y , _thisTransform.position.z) ;
			}
		}

	}

	//---Collision Check
	private void OnTriggerEnterEx(Collider coll)
	{
		if (_characterState != CharacterState.GameOver) {
		
			if(coll.CompareTag("COIN_PATTERN")){
			

				
			}
			//else if(coll.CompareTag("COIN_MAGNET"))
			//{
			//
			//	CoinMagnetBaseObject coinMagnetBaseObject = coll.GetComponent<CoinMagnetBaseObject>() as CoinMagnetBaseObject ;
			//	
			//	coinMagnetBaseObject.CoinMagnetObjectCrashAction() ;
			//	
			//	if(coinMagnetBaseObject._coinObjectType == CoinMagnetBaseObject.CoinObjectType.BigGold) {
			//
			//		if(_submarineGetCoinDelegate != null){
			//			_submarineGetCoinDelegate(this,2, 3) ; // State 1 : Gold , State 2 : BigGold	   //WhereInfo 1 : Drop Item , 2 : Coin Pattern, 3 : Coin Magnet
			//		}
			//	
			//	}else if(coinMagnetBaseObject._coinObjectType == CoinMagnetBaseObject.CoinObjectType.Gold) {
			//		
			//		if(_submarineGetCoinDelegate != null){
			//			_submarineGetCoinDelegate(this,1, 3) ; // State 1 : Gold , State 2 : BigGold	  //WhereInfo 1 : Drop Item , 2 : Coin Pattern, 3 : Coin Magnet
			//		}
			//		
			//	}
			//	
			//	
			//}
			else if(coll.CompareTag("DROP_ITEM")){
			
				DropItemObject dropItemObject = coll.GetComponent<DropItemObject>() as DropItemObject ;
				
				dropItemObject.DropItemCrashAction() ;
				
				
				if(dropItemObject._dropItemType == DropItemObject.DropItemType.BigGold) {
			
					if(_submarineGetCoinDelegate != null){
						_submarineGetCoinDelegate(this,2, 1) ; // State 1 : Gold , State 2 : BigGold	  //WhereInfo 1 : Drop Item , 2 : Coin Pattern, 3 : Coin Magnet
					}
				
				}else if( dropItemObject._dropItemType == DropItemObject.DropItemType.Gold) {
					
					if(_submarineGetCoinDelegate != null){
						_submarineGetCoinDelegate(this,1, 1) ; // State 1 : Gold , State 2 : BigGold	  //WhereInfo 1 : Drop Item , 2 : Coin Pattern, 3 : Coin Magnet
					}
					
				}else{
					if(_submarineGetItemDelegate != null){
						_submarineGetItemDelegate(this,dropItemObject,1) ;
					}
				}
				
			}
			
		}
		
		if(_isInvincibilityAction) return ;

		if (_characterState == CharacterState.Play) {
			
			if(coll.CompareTag("ENEMY") || coll.CompareTag("ENEMY_EXPLOSION") ||
				coll.CompareTag("BOSS_LASER") || coll.CompareTag("BOSS_MINE") || coll.CompareTag("BOSS_MISSILE")){
			
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Damaged,false);
				if(_submarineCrashDelegate != null) 
				{
					_submarineCrashDelegate(this,1) ; 
				}
				if(_Health > 0f)
				{
					InvincibilityActionStart();
				}
			}
			
		}	
	}

	private void OnTriggerStayEx(Collider coll)
	{		
		if(_isInvincibilityAction) return ;
		
		if (_characterState == CharacterState.Play) {
			
			if(coll.CompareTag("ENEMY") || coll.CompareTag("ENEMY_EXPLOSION") ||
			   coll.CompareTag("BOSS_LASER") || coll.CompareTag("BOSS_MINE") || coll.CompareTag("BOSS_MISSILE")){
				
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Damaged,false);
				if(_submarineCrashDelegate != null) 
				{
					_submarineCrashDelegate(this,1) ; 
				}
				if(_Health > 0f)
				{
					InvincibilityActionStart();
				}
			}
			
		}	
	}

	//
	public void Initialize(){
		
		SetSubweapon() ;
		SetSubmarineBullet() ;
		
		_submarineDrivingEffect.InitialzieEffectObject(new Vector3(_thisTransform.position.x-_submarineBody.SpriteSize.x, _thisTransform.position.y, _thisTransform.position.z+0.01f)) ;
		
		_submarineDeadReadyEffect.InitialzieEffectObject() ;
		
		//_subMarineDeadBubEffect.InitializeEffectObject() ;
		//_subMarineDeadSmokeEffect.InitializeEffectObject() ;
		
		_characterState = CharacterState.Idle ;		
		StartCoroutine(_characterState.ToString());
		
	}
	
	public void ItemInitialize(bool haveCharacterMagnet, float magnetAreaCharacter, float magnetAreaDropItem, bool haveCharacterShield, bool haveItemShield){
		
		_submarineShieldEffect.InitializeEffectObject(haveCharacterShield, haveItemShield) ;
		_submarineMagnetEffect.InitializeEffectObject(haveCharacterMagnet, magnetAreaCharacter, magnetAreaDropItem) ;
		_submarineDoubleScoreEffect.InitializeEffectObject() ;
		_submarinePowerShotEffect.InitializeEffectObject() ;
		_submarineBoosterEffect.InitializeEffectObject() ;
		
		_submarineStartBoosterEffect.InitializeEffectObject() ;
		_submarineLastBoosterEffect.InitializeEffectObject() ;
		
		_submarineFeverModeEffect.InitializeEffectObject() ;
		
	}
	
	
	
	private void SetSubweapon(){		

		//Debug.Log("?: "+ SubmarineNum);
		//if(SubmarineNum == 1)
		{
			//List<Object> PetResources = new List<Object>(Resources.LoadAll("Prefab/Pet/"));
			if(Pet1Num > 0)
			//if(SubWeapon1Num > 0)
			{
				//string strSubweapon = "Prefab/Pet/Pet" + random[0].ToString();// + SubWeapon1Num.ToString() ;
				//GameObject subweaponResource = Resources.Load(strSubweapon) as GameObject;
				int index = Pet1Num;//Random.Range(0,PetResources.Count);
				GameObject subweaponResource = Resources.Load("Prefab/Pet/Pet"+index.ToString()) as GameObject;
				GameObject subweaponObject = Instantiate(subweaponResource,  _subweapon1Sp.position, Quaternion.identity) as GameObject;
				_Pet1 = subweaponObject.GetComponent<PetObject>() as PetObject;
				_Pet1.Init(this, _subweapon1Sp);
				_Pet1.StartPet();
			}
			if(Pet2Num > 0)
			{
				//string strSubweapon = "Prefab/Pet/Pet"  + random[1].ToString();// + SubWeapon1Num.ToString() ;
				//GameObject subweaponResource = Resources.Load(strSubweapon) as GameObject;
				int index = Pet2Num;//Random.Range(0,PetResources.Count);
				GameObject subweaponResource = Resources.Load("Prefab/Pet/Pet"+index.ToString()) as GameObject;
				GameObject subweaponObject = Instantiate(subweaponResource,  _subweapon2Sp.position, Quaternion.identity) as GameObject;
				_Pet2 = subweaponObject.GetComponent<PetObject>() as PetObject;
				_Pet2.Init(this, _subweapon2Sp);
				_Pet2.StartPet();
			}
		}
				
	}
	
	private void SetSubmarineBullet(){
		_bulletSpriteName = Managers.GameBalanceData.GetMainBulletName(SubmarineNum, BulletLevel);
	}
	
	
	// Submarine Body Delegate
	private void InvincibilityActionDone(int state) { //State 0 : Action Success  , 1 : Forced Stop Action
		if(state == 0 || state == 1){
			_isInvincibilityAction = false ;
		}
	}
	
	//-- Submarine Body Controller
	public void InvincibilityActionStart(){
		_isInvincibilityAction = true ;
		_submarineBody.InvincibilityActionStart() ;
	}
	
	public void InvincibilityActionStop() {
		_submarineBody.InvincibilityActionStop() ;
	}
	//--
	
	public void InvincibilityStart(){
		_isInvincibilityAction = true ;
	}
	
	public void InvincibilityStop(){
		_isInvincibilityAction = false ;
	}
	
	
	//-- SubmarineDrivingEffect Controll
	public void ChangeSubmarineSpeed(float gameSpeed) {
		_submarineDrivingEffect.ChangeEffectPerSpeed(gameSpeed) ;
	}
	
	private void StopSubmarineDrivingEffect(){
		_submarineDrivingEffect.EffectStop() ;
	}
	
	private void PlaySubmarineDrivingEffect(){
		_submarineDrivingEffect.EffectPlay() ;
	}
	//--
	
	
	//-- Submarine Shield Effect Controll
	public void ChangeStateSubmarineShieldEffect(bool haveCharacterShield, bool haveItemShield) {
		_submarineShieldEffect.ChangeStateSubmarineShieldEffect(haveCharacterShield, haveItemShield) ;
		
		GameObject _go = PoolManager.Spawn("SubmarineShieldOffEffectObject") ;
		SubmarineShieldOffEffectObject _submarineShieldOffEffectObject = _go.GetComponent<SubmarineShieldOffEffectObject>() as SubmarineShieldOffEffectObject ;
		Vector3 createPosition = new Vector3(_thisTransform.position.x, _thisTransform.position.y, _thisTransform.position.z-1f) ;
		_submarineShieldOffEffectObject.ResetEffectObject(createPosition) ;	
		_submarineShieldOffEffectObject.StartAction() ;
		
	}
	//
	
	//-- Submarine Magnet Effect Controll
	public void ChangeStateSubmarineMagnetEffect(bool haveCharacterMagnet, bool getItemMagnet) {
		_submarineMagnetEffect.ChangeStateSubmarineMagnetEffect(haveCharacterMagnet, getItemMagnet) ;
	}
	
	private void PauseSubmarineMagnetEffect(){
		//_submarineMagnetEffect.EffectPause() ;
	}
	
	private void ResumeSubmarineMagnetEffect(){
		//_submarineMagnetEffect.EffectResume() ;
	}
	//
	
	//-- Submarine DoubleScore Effect Controll
	public void ChangeStateSubmarineDoubleScoreEffect(bool getItemDoubleScore) {
		_submarineDoubleScoreEffect.ChangeStateSubmarineDoubleScoreEffect(getItemDoubleScore) ;
	}
	
	private void PauseSubmarineDoubleScoreEffect(){
		//_submarineDoubleScoreEffect.EffectPause() ;
	}
	
	private void ResumeSubmarineDoubleScoreEffect(){
		//_submarineDoubleScoreEffect.EffectResume() ;
	}
	//
	
	//-- Submarine PowerShot Effect Controll
	public void ChangeStateSubmarinePowerShotEffect(bool getItemPowerShot) {
		GetItemPowerShot = getItemPowerShot ;
		
		_submarinePowerShotEffect.ChangeStateSubmarinePowerShotEffect(getItemPowerShot) ;
	}
	
	private void PauseSubmarinePowerShotEffect(){
		//_submarinePowerShotEffect.EffectPause() ;
	}
	
	private void ResumeSubmarinePowerShotEffect(){
		//_submarinePowerShotEffect.EffectResume() ;
	}
	//
	
	//-- Submarine Booster Effect Controll
	public void ChangeStateSubmarineBoosterEffect(bool getItemBooster) {
		_submarineBoosterEffect.ChangeStateSubmarineBoosterEffect(getItemBooster) ;
	}
	//		
	
	//-- Submarine Start Booster Effect Controll
	public void ChangeStateSubmarineStartBoosterEffect(bool startBoosterMode) {
		_submarineStartBoosterEffect.ChangeStateSubmarineBoosterEffect(startBoosterMode) ;
	}
	//	
	
	//-- Submarine Last Booster Effect Controll
	public void ChangeStateSubmarineLastBoosterEffect(bool lastBoosterMode) {
		_submarineLastBoosterEffect.ChangeStateSubmarineBoosterEffect(lastBoosterMode) ;
	}
	//	
	
	//-- Submarine FeverMode Effect Controll
	public void ChangeStateSubmarineFeverModeEffect(bool feverMode) {
		_submarineFeverModeEffect.ChangeStateSubmarineFeverModeEffect(feverMode) ;
		ChangeStateSubmarineLastBoosterEffect(feverMode) ;
		
		ChangeStateSubmarineBoosterEffect(false) ;
		ChangeStateSubmarineStartBoosterEffect(false) ;
		
	}
	//	
	
	//-- Submarine DeadReady Effect Controll
	public void ChangeStateSubmarineDeadReadyEffect(bool deadReadyMode) {
		
		if(deadReadyMode){
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Dead,false);
		
			GameObject _go = PoolManager.Spawn("SubmarineEtcDeadEffectObject") ;
			SubmarineEtcDeadEffectObject _submarineEtcDeadEffectObject = _go.GetComponent<SubmarineEtcDeadEffectObject>() as SubmarineEtcDeadEffectObject ;
			Vector3 createPosition = new Vector3(_thisTransform.position.x, _thisTransform.position.y, _thisTransform.position.z-1f) ;
			_submarineEtcDeadEffectObject.ResetEffectObject(createPosition) ;
			_submarineEtcDeadEffectObject.StartAction() ;	
			
			_submarineDeadReadyEffect.ChangeStateSubmarineDeadReadyEffect(deadReadyMode) ;
			
		}else{
			
			_submarineDeadReadyEffect.ChangeStateSubmarineDeadReadyEffect(deadReadyMode) ;
			
		}
		
	}
	//
	
	/*
	//-- Submarine DeadBub Effect Controll
	public void ChangeStateSubmarineDeadBubEffect(bool deadMode) {
		_subMarineDeadBubEffect.ChangeStateSubmarineDeadBubEffect(deadMode) ;
	}
	//
	*/
	
	/*
	//-- SubmarineDeadSmokeEffect Controll
	public void ChangeSubmarineDeadSmokeSpeed(float gameSpeed) {
		_subMarineDeadSmokeEffect.ChangeEffectPerSpeed(gameSpeed) ; //
	}
	
	
	public void StartSubmarineDeadSmokeEffect() {
		_subMarineDeadSmokeEffect.StartEffectObject() ;
	}
	
	private void StopSubmarineDeadSmokeEffect(){
		_subMarineDeadSmokeEffect.EffectStop() ;
	}
	
	private void PlaySubmarineDeadSmokeEffect(){
		_subMarineDeadSmokeEffect.EffectPlay() ;
	}
	*/
	//--
	
	
	
	//-- All Submarine Effect Controll
	private void PauseSubmarineAllEffect() {
		PauseSubmarineMagnetEffect() ;
		PauseSubmarineDoubleScoreEffect() ;
		PauseSubmarinePowerShotEffect() ;
		
	}
	
	private void ResumeSubmarineAllEffect() {
		ResumeSubmarineMagnetEffect() ;
		ResumeSubmarineDoubleScoreEffect() ;
		ResumeSubmarinePowerShotEffect() ;
	}
	
	private void RemoveSubmarineAllEffect() {
		ChangeStateSubmarineMagnetEffect(false, false) ;
		ChangeStateSubmarineDoubleScoreEffect(false) ;
		ChangeStateSubmarinePowerShotEffect(false) ;
		ChangeStateSubmarineFeverModeEffect(false) ;
	}
	//
	
	
	
	//--FSM
	public void SetSubmarineStateIdle(){
		_characterState = CharacterState.Idle ;
	}
	
	public void SetSubmarineStateReady(){
		_characterState = CharacterState.Ready ;
	}
	
	public void SetSubmarineStateStartBoosterReady(){
		_characterState = CharacterState.StartBoosterReady ;
	}
	
	public void SetSubmarineStateStartBooster(){
		_characterState = CharacterState.StartBooster ;
	}
	
	public void SetSubmarineStatePlay(){
		_characterState = CharacterState.Play ;
	}
	
	public void SetSubmarineStateFever(){
		_characterState = CharacterState.Fever ;
	}
	
	public void SetSubmarineStateBooster(){
		_characterState = CharacterState.Booster ;
	}
	
	public void SetSubmarineStateDead(){
		_characterState = CharacterState.Dead ;
	}
	
	public void SetSubmarineStateReviveWait(){
		_characterState = CharacterState.ReviveWait ;
	}
	
	public void SetSubmarineStateRevive(){
		_characterState = CharacterState.Revive ;
		_Health = _MaxHealth;// * 0.8f;
		//Debug.Log("REVIVE CALLED");
	}
	
	public void SetSubmarineStateLastBoosterReady(){
		_characterState = CharacterState.LastBoosterReady ;
	}
	
	public void SetSubmarineStateLastBooster(){
		_characterState = CharacterState.LastBooster ;
	}
	
	public void SetSubmarineStateGameOver(){
		_characterState = CharacterState.GameOver ;
	}

	public void ReduceHealth(float _Damage, bool _vibrate, bool _ignoreInvincible, int _type)
	{
		if(_vibrate && _Health > 0f)
		{
			Managers.UserData.Vibrate();
		}
		if(_isInvincibilityAction && !_ignoreInvincible)
		{
			return;
		}
		_Health -= _Damage;
		_submarineHealthReducedDelegate(this, _type);
	}
	
	//------------------------------------
	private IEnumerator Idle() {
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStateIdle() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStateIdle() ;
		//}
		///
		
		
		PlaySubmarineDrivingEffect() ;
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Idle) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator Ready() {
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndNonAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndNonAttack() ;
		//}
		///
		
		
		PlaySubmarineDrivingEffect() ;
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Ready) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator StartBoosterReady() {
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}
		
		StopSubmarineDrivingEffect() ;		
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Boss_LaserReady,false);
		
		
		GameObject _go = PoolManager.Spawn("SubmarineStartBoosterReadyEffectObject") ;
		SubmarineStartBoosterReadyEffectObject _startBoosterReadyEffectObject = _go.GetComponent<SubmarineStartBoosterReadyEffectObject>() as SubmarineStartBoosterReadyEffectObject ;
		_startBoosterReadyEffectObject.ResetEffectObject(new Vector3(_thisTransform.position.x-0.15f, _thisTransform.position.y, _thisTransform.position.z-1f), Color.white) ;
		_startBoosterReadyEffectObject.StartAction() ;
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.StartBoosterReady) {
			
			
			yield return null ;
			
		}
		
		_startBoosterReadyEffectObject.DestroySpriteObject(0) ;
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator StartBooster() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Item_Booster,false);
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(false);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(false);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}

		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndNonAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndNonAttack() ;
		//}
		///
		
		GameObject _go = PoolManager.Spawn("SubmarineEtcBoosterEffectObject") ;
		SubmarineEtcBoosterEffectObject _submarineEtcBoosterEffectObject = _go.GetComponent<SubmarineEtcBoosterEffectObject>() as SubmarineEtcBoosterEffectObject ;
		Vector3 createPosition = new Vector3(_thisTransform.position.x-0.25f, _thisTransform.position.y, _thisTransform.position.z-1f) ;
		_submarineEtcBoosterEffectObject.ResetEffectObject(createPosition) ;
		_submarineEtcBoosterEffectObject.StartAction() ;
		
		
		PlaySubmarineDrivingEffect() ;
		
		ChangeStateSubmarineStartBoosterEffect(true) ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.StartBooster) {
			
			
			yield return null ;
			
		}
		
		ChangeStateSubmarineStartBoosterEffect(false) ;
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator Play() {

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(true);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(true);
		}
		if(_Pet1 != null)
		{
			_Pet1.DoAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndAttack() ;
		//}
		///
		
		
		PlaySubmarineDrivingEffect() ;
		ResumeSubmarineAllEffect() ;
		
		_submarineBody.AnimationResume() ;
		
		
		StartFireBullet();
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Play) {
			
			
			yield return null ;
			
		}
		
		StopFireBullet();
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator Fever() {

		_shootEffect.SetActive (false);
		_submarineBody.SetCollider(m_NormalColliderSize);
		InvincibilityActionStop();

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(true);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(true);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndNonAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndNonAttack() ;
		//}
		///
		
		
		PlaySubmarineDrivingEffect() ;
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Fever) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator Booster() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Item_Booster,false);
		
		_shootEffect.SetActive (false);
		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(false);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(false);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndNonAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndNonAttack() ;
		//}
		///
		
		
		GameObject _go = PoolManager.Spawn("SubmarineEtcBoosterEffectObject") ;
		SubmarineEtcBoosterEffectObject _submarineEtcBoosterEffectObject = _go.GetComponent<SubmarineEtcBoosterEffectObject>() as SubmarineEtcBoosterEffectObject ;
		Vector3 createPosition = new Vector3(_thisTransform.position.x-0.25f, _thisTransform.position.y, _thisTransform.position.z-1f) ;
		_submarineEtcBoosterEffectObject.ResetEffectObject(createPosition) ;
		_submarineEtcBoosterEffectObject.StartAction() ;
		
		
		PlaySubmarineDrivingEffect() ;
		
		ChangeStateSubmarineBoosterEffect(true) ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Booster) {
			
			
			yield return null ;
			
		}
		
		ChangeStateSubmarineBoosterEffect(false) ;
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator Dead() {
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(false);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(false);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStateDead() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStateDead() ;
		//}
		///
		
		StopSubmarineDrivingEffect() ;
		PauseSubmarineAllEffect() ;
		
		_submarineBody.AnimationPause() ;
		
		yield return null ;
		
		while(_characterState == CharacterState.Dead) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator LastBoosterReady() {
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(false);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(false);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndNonAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndNonAttack() ;
		//}
		///
		
		StopSubmarineDrivingEffect() ;
		ResumeSubmarineAllEffect() ;
		
		//StartSubmarineDeadSmokeEffect() ; //Smoke On
		
		_submarineBody.AnimationResume() ;
		
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Boss_LaserReady,false);
		
		
		GameObject _go = PoolManager.Spawn("SubmarineStartBoosterReadyEffectObject") ;
		SubmarineStartBoosterReadyEffectObject _lastBoosterReadyEffectObject = _go.GetComponent<SubmarineStartBoosterReadyEffectObject>() as SubmarineStartBoosterReadyEffectObject ;
		_lastBoosterReadyEffectObject.ResetEffectObject(new Vector3(_thisTransform.position.x-0.15f, _thisTransform.position.y, _thisTransform.position.z-1f), Color.white) ;
		_lastBoosterReadyEffectObject.StartAction() ;
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.LastBoosterReady) {
			
			
			yield return null ;
			
		}
		
		_lastBoosterReadyEffectObject.DestroySpriteObject(0) ;
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator LastBooster() {
		
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Item_Booster,false);
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(false);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(false);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStatePlayAndNonAttack() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStatePlayAndNonAttack() ;
		//}
		///
		
		GameObject _go = PoolManager.Spawn("SubmarineEtcBoosterEffectObject") ;
		SubmarineEtcBoosterEffectObject _submarineEtcBoosterEffectObject = _go.GetComponent<SubmarineEtcBoosterEffectObject>() as SubmarineEtcBoosterEffectObject ;
		Vector3 createPosition = new Vector3(_thisTransform.position.x-0.25f, _thisTransform.position.y, _thisTransform.position.z-1f) ;
		_submarineEtcBoosterEffectObject.ResetEffectObject(createPosition) ;
		_submarineEtcBoosterEffectObject.StartAction() ;
		
		
		PlaySubmarineDrivingEffect() ;
		
		ChangeStateSubmarineLastBoosterEffect(true) ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.LastBooster) {
			
			
			yield return null ;
			
		}
		
		ChangeStateSubmarineLastBoosterEffect(false) ;
		
		//StopSubmarineDeadSmokeEffect() ; //Smoke Off
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator ReviveWait() {
		
		_shootEffect.SetActive (false);


		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStateReviveWait() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStateReviveWait() ;
		//}
		///
		
		StopSubmarineDrivingEffect() ;
		PauseSubmarineAllEffect() ;
		
		_submarineBody.AnimationPause() ;
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.ReviveWait) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator Revive() {
		
		_shootEffect.SetActive (false);

		//if(_Pet1 != null)
		//{
		//	_Pet1.DoAttack();
		//}
		//
		//if(_Pet2 != null)
		//{
		//	_Pet2.DoAttack();
		//}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStateRevive() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStateRevive() ;
		//}
		///
		
		PlaySubmarineDrivingEffect() ;
		ResumeSubmarineAllEffect() ;
		
		_submarineBody.AnimationResume() ;
		
		
		_characterState = CharacterState.Booster ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Revive) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator GameOver() {
		
		_shootEffect.SetActive (false);

		if(_Pet1 != null)
		{
			_Pet1.gameObject.SetActive(false);
		}
		if(_Pet2 != null)
		{
			_Pet2.gameObject.SetActive(false);
		}

		if(_Pet1 != null)
		{
			_Pet1.DoNotAttack();
		}
		
		if(_Pet2 != null)
		{
			_Pet2.DoNotAttack();
		}

		/// Subweapon FSM
		//if(_gameSubweapon1 != null) {
		//	_gameSubweapon1.SetSubweaponStateGameOver() ;
		//}
		//
		//if(_gameSubweapon2 != null) {
		//	_gameSubweapon2.SetSubweaponStateGameOver() ;
		//}
		///
		
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Submarine_Dead,false);
		
		
		GameObject _go = PoolManager.Spawn("SubmarineEtcDeadEffectObject") ;
		SubmarineEtcDeadEffectObject _submarineEtcDeadEffectObject = _go.GetComponent<SubmarineEtcDeadEffectObject>() as SubmarineEtcDeadEffectObject ;
		Vector3 createPosition = new Vector3(_thisTransform.position.x, _thisTransform.position.y, _thisTransform.position.z-1f) ;
		_submarineEtcDeadEffectObject.ResetEffectObject(createPosition) ;
		_submarineEtcDeadEffectObject.StartAction() ;
		
		
		
		StopSubmarineDrivingEffect() ;
		
		//ChangeStateSubmarineDeadBubEffect(true) ;
		
		RemoveSubmarineAllEffect() ;
		
		_submarineBody.AnimationPause() ;
		//_submarineBody.SubmarineDead() ;
		
		
		_thisGameObject.SetActive(false) ;
		
		
		/*
		Vector3 startPosition = _thisTransform.position ;
		Vector3 endPosition = new Vector3(startPosition.x, (startPosition.y-2f), _thisTransform.position.z) ;
		
		Quaternion startAngle = _thisTransform.localRotation ;
		Quaternion endAngle = Quaternion.Euler(0f,0f,160f) ;
		
		float t = 0f ;
		bool isDone = false ;
		*/
		
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.GameOver) {
			
			/*
			if(!isDone){
				
				t += (Time.deltaTime*0.1f) ;
				_thisTransform.localPosition = Vector3.Lerp(startPosition,endPosition,t) ;
				_thisTransform.localRotation = Quaternion.Lerp(startAngle,endAngle,t);
				
				if(_thisTransform.localPosition == endPosition) {
					isDone = true ;
					//ChangeStateSubmarineDeadBubEffect(false) ;
				}
			}
			*/
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	public void StartFireBullet()
	{
		StartCoroutine("FireBullet");
	}

	public void StopFireBullet()
	{
		StopCoroutine("FireBullet");
	}

	private IEnumerator FireBullet(){
		
		//string _bulletSpriteName = "Bullet_" + SubmarineNum.ToString() + "_" + BulletLevel.ToString() ;
		
		_shootEffect.SetActive (true);

		while(_characterState == CharacterState.Play){
				
			if(GetItemPowerShot){
				
				GameObject _go1 = PoolManager.Spawn("SubmarineBulletObject") ;
				SubmarineBulletObject _submarineBullet1 = _go1.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject;
				Vector2 _bulletSpriteSize1 = _submarineBullet1.ResetFireBulletAction(_bulletSpriteName, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect) ;
				_submarineBullet1.FireBulletAction(new Vector3(_bulletLuncherSp.position.x, (_bulletLuncherSp.position.y+_bulletSpriteSize1.y), _bulletLuncherSp.position.z)) ;
				
				GameObject _go2 = PoolManager.Spawn("SubmarineBulletObject") ;
				SubmarineBulletObject _submarineBullet2 = _go2.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject;
				Vector2 _bulletSpriteSize2 = _submarineBullet2.ResetFireBulletAction(_bulletSpriteName, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect) ;
				_submarineBullet2.FireBulletAction(new Vector3(_bulletLuncherSp.position.x, (_bulletLuncherSp.position.y-_bulletSpriteSize2.y), _bulletLuncherSp.position.z)) ;
				
			}else{

				if(SubmarineNum == 2)
				{
					for(int i = 0 ; i < 3; i++)
					{
						GameObject _go = PoolManager.Spawn("SubmarineBulletObject");
						SubmarineBulletObject _submarineBullet = _go.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject;
						string subbulletname = Managers.GameBalanceData.GetSubBulletName(SubmarineNum, BulletLevel);
						if(i == 1)
						{
							_submarineBullet.ResetFireBulletAction(_bulletSpriteName, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect) ;
						}else
						{
							_submarineBullet.ResetFireBulletAction(subbulletname, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect) ;
						}
						_submarineBullet.FireBulletAction(_bulletLuncherSp.position);
						_submarineBullet.ThisTransform.localEulerAngles = new Vector3(0f,0f,-7f + i * 7f);
					}
				}else if(SubmarineNum == 4)
				{
					for(int i = 0 ; i < 3; i++)
					{
						string subbulletname = Managers.GameBalanceData.GetSubBulletName(SubmarineNum, BulletLevel);
						if(i == 1)
						{
							GameObject _go = PoolManager.Spawn("SubmarineBulletObject");
							SubmarineBulletObject _submarineBullet = _go.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject;
							
							_submarineBullet.ResetFireBulletAction(_bulletSpriteName, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect) ;
							_submarineBullet.FireBulletAction(_bulletLuncherSp.position);
							_submarineBullet.ThisTransform.localEulerAngles = new Vector3(0f,0f,-7f + i * 7f);
						}else
						{
							GameObject _go = PoolManager.Spawn("SubmarineBulletObject_Missile");
							SubmarineBulletObject_Missile _submarineBullet = _go.GetComponent<SubmarineBulletObject_Missile>() as SubmarineBulletObject_Missile;

							_submarineBullet.ResetFireBulletAction(subbulletname, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect) ;
							_submarineBullet.FireBulletAction(_bulletLuncherSp.position);
							_submarineBullet.ThisTransform.localEulerAngles = new Vector3(0f,0f,-7f + i * 7f);
						}
					}
				}else
				{
					GameObject _go = PoolManager.Spawn("SubmarineBulletObject");
					SubmarineBulletObject _submarineBullet = _go.GetComponent<SubmarineBulletObject>() as SubmarineBulletObject;
					_submarineBullet.ResetFireBulletAction(_bulletSpriteName, BulletType, BulletDamage, BulletSpeed, BulletSlowEffect);
					_submarineBullet.FireBulletAction(_bulletLuncherSp.position);
				}
				
			}
			
			yield return new WaitForSeconds(BulletDelayTime);
			
		}
		
	}

	// 부스터 모드시 애니메이션 효과 ---------------------------------------------------------------.

	private tk2dAnimatedSprite tkAnimBooster;
	private Vector3 v3Original;
	private float fltTemp;

	// 각 애니메이션 이름 - 해당 애니메이션 추가되면 수정할 것.
	private static readonly string AnimTK2DName_SubMarine_NormalToBooster_0 = "Marine_NormalToBooster_0";
	private static readonly string AnimTK2DName_SubMarine_NormalToBooster_1 = "Marine_NormalToBooster_0";
	private static readonly string AnimTK2DName_SubMarine_NormalToBooster_2 = "Marine_NormalToBooster_0";
	private static readonly string AnimTK2DName_SubMarine_NormalToBooster_3 = "Marine_NormalToBooster_0";

	private static readonly string AnimTK2DName_SubMarine_BoosterToNormal_0 = "Marine_BoosterToNormal_0";
	private static readonly string AnimTK2DName_SubMarine_BoosterToNormal_1 = "Marine_BoosterToNormal_0";
	private static readonly string AnimTK2DName_SubMarine_BoosterToNormal_2 = "Marine_BoosterToNormal_0";
	private static readonly string AnimTK2DName_SubMarine_BoosterToNormal_3 = "Marine_BoosterToNormal_0";

	private static readonly string AnimTK2DName_SubMarine_Normal_0 = "Marine0-1";
	private static readonly string AnimTK2DName_SubMarine_Normal_1 = "Marine1-1";
	private static readonly string AnimTK2DName_SubMarine_Normal_2 = "Marine2-1";
	private static readonly string AnimTK2DName_SubMarine_Normal_3 = "Marine3-1";

	private string strAnimName = "";

	private bool boolBoosterWork = false;

	// 부스터 관련 이펙트 준비.
	public void BoosterMode_Ready(){

		if (!boolBoosterWork) {

			// 서브웨폰(펫) 숨기기.
			setSubWeapon_Hide ();
			
			// 애니메이션 선택 및 실행.
			tkAnimBooster = _submarineBody.GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite;
		}
	}


	// 부스터모드 시작 변신 애니메이션.
	public void AnimTK2D_SubMarine_NormalToBooster(){

		if (!boolBoosterWork){

			fltTemp = -(screenSizeWidth * 0.5f) + 1f;
			v3Original = _thisTransform.position;
			
			// 잠수함 위치 이동 - 변신중.
			MovePosition_Submarine_Change ();

			switch(SubmarineNum){
			case 0 : strAnimName = AnimTK2DName_SubMarine_NormalToBooster_0; break;
			case 1 : strAnimName = AnimTK2DName_SubMarine_NormalToBooster_1; break;
			case 2 : strAnimName = AnimTK2DName_SubMarine_NormalToBooster_2; break;
			case 3 : strAnimName = AnimTK2DName_SubMarine_NormalToBooster_3; break;
			default : strAnimName = AnimTK2DName_SubMarine_NormalToBooster_0; break;
			}

			tkAnimBooster.Play (strAnimName);
			tkAnimBooster.animationCompleteDelegate = AnimTK2D_DG_SubMarine_Booster;
			_submarineBody.SetCollider(m_BoosterColliderSize);
			boolBoosterWork = true;
		}
	}

	// 부스터모드 애니메이션 - Delegate.
	private void AnimTK2D_DG_SubMarine_Booster(tk2dAnimatedSprite sprite,int clipId){
		
		// 잠수함 위치 이동 - 돌진.
		MovePosition_Submarine_Booster ();

		strAnimName = "Marine_Booster_0";

		strAnimName = "Marine_Booster_" + SubmarineNum.ToString();
		// 애니메이션 선택 및 실행.
		//switch(SubmarineNum){
		//case 0 : strAnimName = AnimTK2DName_SubMarine_Booster_0; break;
		//case 1 : strAnimName = AnimTK2DName_SubMarine_Booster_1; break;
		//case 2 : strAnimName = AnimTK2DName_SubMarine_Booster_2; break;
		//case 3 : strAnimName = AnimTK2DName_SubMarine_Booster_3; break;
		//case 4 : strAnimName = AnimTK2DName_SubMarine_Booster_4; break;
		//default : strAnimName = AnimTK2DName_SubMarine_Booster_0; break;
		//}

		tkAnimBooster.Play (strAnimName);
	}

	// 부스터모드 엔딩 변신 애니메이션.
	public void AnimTK2D_SubMarine_BoosterToNormal(){

		if (boolBoosterWork) {

			// 잠수함 위치 이동 - 변신중.
			MovePosition_Submarine_Change ();
			
			// 애니메이션 선택 및 실행.
			switch(SubmarineNum){
			case 0 : strAnimName = AnimTK2DName_SubMarine_BoosterToNormal_0; break;
			case 1 : strAnimName = AnimTK2DName_SubMarine_BoosterToNormal_1; break;
			case 2 : strAnimName = AnimTK2DName_SubMarine_BoosterToNormal_2; break;
			case 3 : strAnimName = AnimTK2DName_SubMarine_BoosterToNormal_3; break;
			default : strAnimName = AnimTK2DName_SubMarine_BoosterToNormal_0; break;
			}
			
			tkAnimBooster.Play (strAnimName);

			tkAnimBooster.animationCompleteDelegate = AnimTK2D_DG_SubMarine_Normal;
			_submarineBody.SetCollider(m_NormalColliderSize);
			boolBoosterWork = false;
		}
	}


	// 부스터모드 해제하고 정상모드 애니메이션 - Delegate.
	private void AnimTK2D_DG_SubMarine_Normal(tk2dAnimatedSprite sprite,int clipId){

		// 서브웨폰(펫) 보이기.
		setSubWeapon_Show ();

		// 잠수함 위치 이동 - 원래자리.
		MovePosition_Submarine_Normal ();

		strAnimName = "Marine0-1";
		strAnimName = "Marine"+SubmarineNum.ToString() + "-1";
		// 애니메이션 선택 및 실행.
		//switch(SubmarineNum){
		//case 0 : strAnimName = AnimTK2DName_SubMarine_Normal_0; break;
		//case 1 : strAnimName = AnimTK2DName_SubMarine_Normal_1; break;
		//case 2 : strAnimName = AnimTK2DName_SubMarine_Normal_2; break;
		//case 3 : strAnimName = AnimTK2DName_SubMarine_Normal_3; break;
		//default : strAnimName = AnimTK2DName_SubMarine_Normal_0; break;
		//}
		
		tkAnimBooster.Play (strAnimName);

		boolBoosterWork = false;
	}

	// 정상모드 애니메이션 복귀.
	public void AnimTK2D_SubMarine_Normal(){

		if (boolBoosterWork) {

			// 서브웨폰(펫) 보이기.
			setSubWeapon_Show ();
			
			// 잠수함 위치 이동 - 원래자리.
			MovePosition_Submarine_Normal ();

			strAnimName = "Marine0-1";
			strAnimName = "Marine"+SubmarineNum.ToString() + "-1";
			// 애니메이션 선택 및 실행.
			//switch(SubmarineNum){
			//case 0 : strAnimName = AnimTK2DName_SubMarine_Normal_0; break;
			//case 1 : strAnimName = AnimTK2DName_SubMarine_Normal_1; break;
			//case 2 : strAnimName = AnimTK2DName_SubMarine_Normal_2; break;
			//case 3 : strAnimName = AnimTK2DName_SubMarine_Normal_3; break;
			//default : strAnimName = AnimTK2DName_SubMarine_Normal_0; break;
			//}
			
			tkAnimBooster.Play (strAnimName);

			boolBoosterWork = false;
		}
	}

	private void MovePosition_Submarine_Normal(){

//		Debug.Log ("v3Original.x = " + v3Original.x);

		_thisTransform.position = new Vector3(v3Original.x, v3Original.y, v3Original.z);
		_submarineBody.transform.position = new Vector3(v3Original.x, v3Original.y, 0f);
	}

	private void MovePosition_Submarine_Booster(){
		
		_thisTransform.position = new Vector3(fltTemp, v3Original.y, v3Original.z);
		_submarineBody.transform.position = new Vector3(fltTemp, v3Original.y, -1f);
	}

	private void MovePosition_Submarine_Change(){
		
		_thisTransform.position = new Vector3(fltTemp - 0.4f, v3Original.y, v3Original.z);
	}

	public void setSubWeapon_Hide(){

		if (SubWeapon1Num > 0) {
			
			_gameSubweapon1.setSubWeaponActive_False ();
		}
		
		if (SubWeapon2Num > 0) {
			
			_gameSubweapon2.setSubWeaponActive_False ();
		}
	}

	private void setSubWeapon_Show(){

		if (SubWeapon1Num > 0) {
			
			_gameSubweapon1.setSubWeaponActive_True ();
			_gameSubweapon1.Initialize() ;
			_gameSubweapon1.SetSubweaponStatePlayAndAttack ();
		}
		
		if (SubWeapon2Num > 0) {
			
			_gameSubweapon2.setSubWeaponActive_True ();
			_gameSubweapon2.Initialize() ;
			_gameSubweapon2.SetSubweaponStatePlayAndAttack ();
		}
	}

	public bool isInvincible()
	{
		return _isInvincibilityAction;
	}

	public CharacterState GetState()
	{
		return _characterState;
	}
}
