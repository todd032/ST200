using UnityEngine;
using System.Collections;

public class CoinBasePatternObject : PatternObject {

	public enum CoinObjectType { Coin_None, BigGold, Gold};
	public CoinObjectType _coinObjectType = CoinObjectType.Coin_None;
	
	// FSM
	public enum	CoinState { Idle , Ready, Clash , Gone} ;
	protected CoinState _coinState = CoinState.Idle;

	
	protected float _currentGameLevel ;
	
	
	protected override void Awake() {
		base.Awake() ;
	}
	
	//****** PatternObject Override ******//
	//-- 
	public override void SetActivePatternObject(bool isActivePatternObject) {
		base.SetActivePatternObject(isActivePatternObject) ;
	}
	
	public override void ResetPatternObject(float settingValue, float weightLevel){
		base.ResetPatternObject(settingValue, weightLevel) ;
	}
	
	public override void ResetPatternObject(float settingValue){
		base.ResetPatternObject(settingValue) ;
	}
	
	public override void ResetPatternObject(){
		base.ResetPatternObject() ;
	}
	
	public override void DestroyPatternObject(int destroyType) {
		base.DestroyPatternObject(destroyType) ;
		
		if(destroyType == 1) {
			SetActivePatternObject(false) ;
		}else if(destroyType == 2){
			SetActivePatternObject(false) ;
		}
		
	}
	
	//--
	public override void StartPatternObject() {
		base.StartPatternObject() ;
		
		AnimationPlay() ;
	}
	
	public override void StopPatternObject() {
		base.StopPatternObject() ;
		
		AnimationStop() ;
	}
	
	//--
	public override void AnimationPlay() {
		base.AnimationPlay() ;
	}
	
	public override void AnimationStop() {
		base.AnimationStop() ;
	}
	
	public override void AnimationPause() {
		base.AnimationPause() ;
	}
	
	public override void AnimationResume() {
		base.AnimationResume() ;
	}
	//--
	//****** PatternObject Override End ******//
	
	
	public virtual void CoinPatternObjectCrashAction(){
		_coinState = CoinState.Clash ;
	}

	
	//---
	protected virtual void OnTriggerEnter (Collider coll){
		
		if(_coinState == CoinState.Clash ||_coinState == CoinState.Gone) return ;

		
		if ( coll.CompareTag("FX_MAGNET")) {
			
			string selectCoinName = null ;
			
			if(_coinObjectType == CoinObjectType.BigGold){
				selectCoinName = "CoinMagnetBigGoldObject" ;
			}else if(_coinObjectType == CoinObjectType.Gold){
				selectCoinName = "CoinMagnetGoldObject" ;
			}
				
			if(selectCoinName != null){
				GameObject _go = PoolManager.Spawn(selectCoinName) ;
				CoinMagnetBaseObject _coinMagnetBaseObject = _go.GetComponent<CoinMagnetBaseObject>() as CoinMagnetBaseObject ;
				_coinMagnetBaseObject.ResetSpriteObject(_thisTransform.position, coll.transform.parent) ;
			}
			
			_coinState = CoinState.Gone ;
				
		}
		
	}
	
	//--FSM
	//--------
	//Idle
	protected  virtual IEnumerator Idle(){
		
		if(_coinObjectType == CoinObjectType.Coin_None) yield break ;
		
		
		yield return null;
	
		
		while(_coinState == CoinState.Idle) {

			yield return null;
			
		}
		
		StartCoroutine(_coinState.ToString());
		
	}
	
	//Ready
	private IEnumerator Ready(){
		
		if(_coinObjectType == CoinObjectType.Coin_None) yield break ;
		
		
		yield return null;
		
		while(_coinState == CoinState.Ready) {
			
			yield return null;
			
		}
		
		StartCoroutine(_coinState.ToString());
		
	}
	
	//Clash	
	protected virtual IEnumerator Clash(){
		
		if(_coinObjectType == CoinObjectType.Coin_None) yield break ;
		
		// Spawn Get effect..
		GameObject _go = PoolManager.Spawn("SubmarineGetItemEffectObject") ;
		SubmarineGetItemEffectObject _submarineGetItemEffectObject = _go.GetComponent<SubmarineGetItemEffectObject>() as SubmarineGetItemEffectObject ;
		_submarineGetItemEffectObject.ResetEffectObject(new Vector3(_thisTransform.position.x, _thisTransform.position.y, _thisTransform.position.z-1f)) ;
		_submarineGetItemEffectObject.StartAction() ;
		
		
		_coinState = CoinState.Gone ;
		
		yield return null;
		
		
		StartCoroutine(_coinState.ToString());
		
	}
	
	protected virtual IEnumerator Gone(){
		
		if(_coinObjectType == CoinObjectType.Coin_None) yield break ;
		
		DestroyPatternObject(0) ;
		
		yield return null;
		
	}
	
}
