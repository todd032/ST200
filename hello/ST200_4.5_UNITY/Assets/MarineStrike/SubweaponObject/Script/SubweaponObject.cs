using UnityEngine;
using System.Collections;

public class SubweaponObject : MonoBehaviour {
	
	/*
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
	*/
	
	/*
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
	*/
	
	
	
	[HideInInspector]
	public enum CharacterState {
		Idle,
		PlayAndAttack,
		PlayAndNonAttack,
		AttackTogether, //
		AttackTogetherAfterGone,
		AttackTogetherDone ,
		Dead,
		ReviveWait,
		Revive,
		GameOver
	}   ;
	
	
	private CharacterState _characterState = CharacterState.Idle ;
	
	
	public Transform _bulletLuncherSp;	

	
	public GameObject _subweaponGradeEffectObject ; //Prefab
	private SubweaponEffectObject _subweaponGradeEffect ; //Script Component
	

	public GameObject _subweaponBulletObject ; //Prefab
	public GameObject _subweaponBulletEffectObject;
	
	
	
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
	
	private tk2dAnimatedSprite _thisAnimatedSprite;
	public tk2dAnimatedSprite ThisAnimatedSprite {
		get { return _thisAnimatedSprite ; }
	}
	
	// Setting Subweapon Data
	private int _subWeaponNum ;
	private int _subWeaponGrade ;
	private int _subWeaponType ;
	public int SubWeaponNum{ 
		get{	return _subWeaponNum;	}
		set{	_subWeaponNum = value;	}
	}
	public int SubWeaponGrade{ 
		get{	return _subWeaponGrade;	}
		set{	_subWeaponGrade = value;	}
	}
	public int SubWeaponType{ 
		get{	return _subWeaponType;	}
		set{	_subWeaponType = value;	}
	}
	
	
	// Subweapon Bullet Info
	private int _bulletType ;
	private float _bulletDamage ;
	private float _bulletDelayTime ;
	private float _bulletSpeed ;
	
	public int BulletType{ 
		get{	return _bulletType;	}
		set{	_bulletType = value;	}
	}
	public float BulletDamage{ 
		get{	return _bulletDamage;	}
		set{	_bulletDamage = value;	}
	}
	public float BulletDelayTime{ 
		get{	return _bulletDelayTime;	}
		set{	_bulletDelayTime = value; }
	}
	public float BulletSpeed{ 
		get{	return _bulletSpeed;	}
		set{	_bulletSpeed = value;	}
	}	
	
	
	private Transform _submarineSubweaponSp ;
	public Transform SubmarineSubweaponSp {
		set { 	_submarineSubweaponSp = value ; }
	}
	
	
	private void Awake (){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisAnimatedSprite = GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite;
		
		
		if(_subweaponGradeEffectObject != null){
			_subweaponGradeEffect = _subweaponGradeEffectObject.GetComponent<SubweaponEffectObject>() as SubweaponEffectObject ;	
		}
		
		
		// Setting Subweapon Bullet Pool Object
		PoolManager.instance.CreatePrefabPool(_subweaponBulletObject,20) ;
		//
		
		// Setting Subweapon Bullet Effect Pool Object
		PoolManager.instance.CreatePrefabPool(_subweaponBulletEffectObject,10) ;
		//
		
	}
	
	private void Start () {
		
	}
	
	
	private void Update () {

	}
	
	
	//
	public void Initialize(){
		
		if(_subweaponGradeEffect != null){
			_subweaponGradeEffect.InitializeEffectObject() ;	
		}
		
		_characterState = CharacterState.Idle ;		
		StartCoroutine(_characterState.ToString());
		
	}
	
	private void PauseSubweaponObject() {
		if(_thisAnimatedSprite.Playing){
			_thisAnimatedSprite.Pause() ;		
		}
	}
	
	private void ResumeSubweaponObject() {
		if(_thisAnimatedSprite.Paused){
			_thisAnimatedSprite.Resume() ;	
		}
	}
	
	
	//-- SubweaponGradeEffect Controll	
	private void StartSubweaponGradeEffect() {
		if(_subweaponGradeEffect != null){
			_subweaponGradeEffect.StartEffectObject() ;	
		}
	}
	
	private void StopSubweaponGradeEffect(){
		if(_subweaponGradeEffect != null){
			_subweaponGradeEffect.StopEffectObject() ;	
		}
	}
	
	private void PauseSubweaponGradeEffect(){
		if(_subweaponGradeEffect != null){
			_subweaponGradeEffect.EffectPause() ;	
		}		
	}
	
	private void ResumeSubweaponGradeEffect(){
		if(_subweaponGradeEffect != null){
			_subweaponGradeEffect.EffectResume() ;	
		}
	}
	
	
	
	//--FSM
	public void SetSubweaponStateIdle(){
		_characterState = CharacterState.Idle ;
	}
	
	public void SetSubweaponStatePlayAndAttack(){
		_characterState = CharacterState.PlayAndAttack ;
	}
	
	public void SetSubweaponStatePlayAndNonAttack() {
		_characterState = CharacterState.PlayAndNonAttack ;
	}
	
	public void SetSubweaponStateAttackTogether() {
		_characterState = CharacterState.AttackTogether ;
	}
	
	public void SetSubweaponStateAttackTogetherAfterGone() {
		_characterState = CharacterState.AttackTogetherAfterGone ;
	}
	
	public void SetSubweaponStateAttackTogetherDone() {
		_characterState = CharacterState.AttackTogetherDone ;
	}
	
	public void SetSubweaponStateDead(){
		_characterState = CharacterState.Dead ;
	}
	
	public void SetSubweaponStateReviveWait(){
		_characterState = CharacterState.ReviveWait ;
	}
	
	public void SetSubweaponStateRevive(){
		_characterState = CharacterState.Revive ;
	}
	
	public void SetSubweaponStateGameOver(){
		_characterState = CharacterState.GameOver ;
	}
	
	
	//------------------------------------
	private IEnumerator Idle() {
		
		StartSubweaponGradeEffect() ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Idle) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator PlayAndAttack() {
		
		ResumeSubweaponObject() ;
		ResumeSubweaponGradeEffect() ;
		
		StartCoroutine("FireBullet") ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.PlayAndAttack) {
			
			_thisTransform.position = Vector3.Lerp(_thisTransform.position, _submarineSubweaponSp.position, Time.deltaTime * 7f);
			
			yield return null ;
			
		}
		
		StopCoroutine("FireBullet") ;
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator PlayAndNonAttack() {
		
		ResumeSubweaponObject() ;
		ResumeSubweaponGradeEffect() ;
		
		yield return null ;
		
		while(_characterState == CharacterState.PlayAndNonAttack) {
			
			_thisTransform.position = Vector3.Lerp(_thisTransform.position, _submarineSubweaponSp.position, Time.deltaTime * 7f);
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator AttackTogether() {
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.AttackTogether) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator AttackTogetherAfterGone() {
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.AttackTogetherAfterGone) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator AttackTogetherDone() {
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.AttackTogetherDone) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator Dead() {
		
		PauseSubweaponObject() ;
		PauseSubweaponGradeEffect() ;
		
		
		yield return null ;
		
		while(_characterState == CharacterState.Dead) {
			
			
			yield return null ;
			
		}
		
		ResumeSubweaponObject() ;
		ResumeSubweaponGradeEffect() ;
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator ReviveWait() {
		
		PauseSubweaponObject() ;
		PauseSubweaponGradeEffect() ;
		
		yield return null ;
		
		
		while(_characterState == CharacterState.ReviveWait) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	private IEnumerator Revive() {
		
		
		yield return null ;
		
		
		while(_characterState == CharacterState.Revive) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		
	}
	
	
	private IEnumerator GameOver() {
		
		StopSubweaponGradeEffect() ;
		
		// Subweapon Dead Effect
		GameObject _go = PoolManager.Spawn("SubweaponDeadEffectObject") ;
		SubweaponDeadEffectObject _subweaponDeadEffectObject = _go.GetComponent<SubweaponDeadEffectObject>() as SubweaponDeadEffectObject ;
		_subweaponDeadEffectObject.ResetEffectObject(_thisTransform.position) ;
		_subweaponDeadEffectObject.StartAction() ;
		//
		
		yield return null ;
		
		_thisGameObject.SetActive(false) ;
		
		/*
		while(_characterState == CharacterState.GameOver) {
			
			
			yield return null ;
			
		}
		
		StartCoroutine(_characterState.ToString()) ;
		*/
	}

	
	
	private IEnumerator FireBullet(){
		
		string _bulletSpriteName = "subweaponBullet_" + BulletType.ToString() ;
		
		
		while(_characterState == CharacterState.PlayAndAttack){
			
			GameObject _go = PoolManager.Spawn("SubweaponBulletObject") ;
			SubweaponBulletObject _subweaponBullet = _go.GetComponent<SubweaponBulletObject>() as SubweaponBulletObject;
			_subweaponBullet.ResetFireBulletAction(_bulletSpriteName, BulletType, BulletDamage, BulletSpeed) ;
			_subweaponBullet.FireBulletAction(_bulletLuncherSp.position) ;
			
			yield return new WaitForSeconds(BulletDelayTime);
			
		}
		
	}



	public void destroy_Subweapon(){

		Destroy (_thisGameObject);

	}

	public void setSubWeaponActive_True(){

		_thisGameObject.SetActive (true);
	}

	public void setSubWeaponActive_False(){
		
		_thisGameObject.SetActive (false);
	}




}
