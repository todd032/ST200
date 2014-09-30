using UnityEngine;
using System.Collections;

public class CoinMagnetBaseObject : DHPoolSpriteObject {
	
	public enum CoinObjectType { Coin_None, BigGold, Gold};
	public CoinObjectType _coinObjectType = CoinObjectType.Coin_None;
	
	// FSM
	public enum	CoinState { Idle , Ready, Clash , Gone} ;
	protected CoinState _coinState = CoinState.Idle;
	
	
	protected Transform _submarineTransform ;
	
	//****** DHPoolSpriteObject ******//
	protected override void Awake ()
	{
		base.Awake ();
		
	}
	
	// Use this for initialization
	protected override void Start () {
		base.Start() ;
	}
	
	//--
	//****** DHPoolSpriteObject Override End ******//
	
	//--
	public virtual void AnimationPlay() {
		
	}
	
	public virtual void AnimationStop() {
		
	}
	
	public virtual void AnimationPause() {
		
	}
	
	public virtual void AnimationResume() {
		
	}
	
	//---
	public virtual void ResetSpriteObject(Vector3 createPosition, Transform submarineTransform){ 
		
		AnimationPlay() ;
		
		_thisTransform.position = createPosition ;
		
		_submarineTransform = submarineTransform ;
		
		_coinState = CoinState.Idle;
		StartCoroutine(_coinState.ToString());
		
	}
	
	public override void DestroySpriteObject(int destroyType) {
		base.DestroySpriteObject(destroyType) ;
		
		if(destroyType == 1) {
			SetActiveSpriteObject(false) ;
		}else if(destroyType == 2){
			SetActiveSpriteObject(false) ;
		}
		
	}
	
	public virtual void CoinMagnetObjectCrashAction(){
		_coinState = CoinState.Clash ;
	}
	
	
	//--------
	//Idle
	protected  virtual IEnumerator Idle(){
		
		if(_coinObjectType == CoinObjectType.Coin_None) yield break ;
		
		
		float t = 0f ;
		yield return null;
	
		
		while(_coinState == CoinState.Idle) {

			t += Time.deltaTime * 6f;
			_thisTransform.position = Vector3.Lerp(_thisTransform.position, _submarineTransform.position, t) ;
			
			if(_thisTransform.position == _submarineTransform.position) {
				//Debug.Log("Coin Magnet State Change Gone") ;
				_coinState = CoinState.Gone ;
			}
			
			
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
		
		DestroySpriteObject(0) ;
		
		yield return null;
		
	}
	
}
