using UnityEngine;
using System.Collections;

public class DropItemObject : DHPoolSpriteObject {
	
	// FSM
	[HideInInspector]
	public enum DropItemState { Idle, Ready, Move, Magnet, Clash , Dead , Gone } ;
	protected DropItemState _dropItemState = DropItemState.Idle;
	
	
	[HideInInspector]
	public	 enum DropItemType	{ DropItem_None, Booster , DoubleScore , Gold ,
		BigGold, Magnet , PowerShot , SpecialAttack_Missile, SpecialAttack_Laser, Energy};
	public DropItemType _dropItemType	 = DropItemType.DropItem_None ;	
	
	
	protected Transform _magnetTargetObject ;
	
	protected bool _isMove ;
	
	
	protected float _directionMoveInitMinPower ; 
	protected float _directionMoveInitMaxPower ; 
	protected Vector2 _directionMoveMinPower ; 
	protected Vector2 _directionMoveMaxPower ;	
	
	protected override void Awake (){
		base.Awake ();
		
		//_animation = _thisGameObject.animation ;
		
	}
	
	// Use this for initialization
	protected override void Start () {
		base.Start () ;
	}
	
	
	//-------
	public virtual void DropItemStartAction(Vector3 createPosition, float directionMoveInitMinPower, float directionMoveInitMaxPower, Vector2 directionMoveMinPower, Vector2 directionMoveMaxPower) {
		
		_thisTransform.position = createPosition ;
		
		_magnetTargetObject = null ;
		
		_isMove = true ;
		
		_directionMoveInitMinPower = directionMoveInitMinPower ;
		_directionMoveInitMaxPower = directionMoveInitMaxPower ;
		_directionMoveMinPower = directionMoveMinPower ; 
		_directionMoveMaxPower = directionMoveMaxPower ;
		
		
		_dropItemState = DropItemState.Idle ;
		StartCoroutine(_dropItemState.ToString());
		
	}
	//--------
	
	public virtual void DropItemCrashAction(){
		_dropItemState = DropItemState.Clash ;
	}
	
	public virtual void DropItemDeadAction(){
		_dropItemState = DropItemState.Dead ;
	}
	
	public virtual void DropItemResumeAction(){
		EffectResume() ;
		_isMove = true ;
	}
	
	public virtual void DropItemPauseAction(){
		EffectPause() ;
		_isMove = false ;
	}
	
	
	
	protected virtual void OnTriggerEnter (Collider coll) {
		
		 if ( coll.CompareTag("FX_MAGNET")){
			if(_dropItemState == DropItemState.Move) {
				_magnetTargetObject = coll.transform.parent ; // Submarine Detect...
				_dropItemState = DropItemState.Magnet ;
			}	
		}
		
	}
	
	
	//---- Animation Controller
	public virtual void EffectPlay(){		
	}
	
	public virtual void EffectStop(){
	}
	
	public virtual void EffectResume(){
	}
	
	public virtual void EffectPause(){
	}
	
	
	
	
	//---FSM
	protected virtual IEnumerator Idle(){
		
		 if(_dropItemType == DropItemType.DropItem_None) yield break ;
		
		_dropItemState = DropItemState.Move ;
		
		yield return null;
	
		while(_dropItemState == DropItemState.Idle) {
			
			yield return null;
			
		}
		
		StartCoroutine(_dropItemState.ToString());
		
	}
	
	
	protected virtual IEnumerator Move(){
		
		if(_dropItemType == DropItemType.DropItem_None) yield break ;
		
		
		
		Vector2 _directionMoveInitPower = new Vector2( Random.Range(_directionMoveInitMinPower, _directionMoveInitMaxPower), 0f) ;
		float directionPowerX =  Random.Range(_directionMoveMinPower.x , _directionMoveMaxPower.x);
		float directionPowerY =  Random.Range(_directionMoveMinPower.y , _directionMoveMaxPower.y);
		
		yield return null;
	
		while(_dropItemState == DropItemState.Move) {
			
			if(_isMove){
				
				_directionMoveInitPower.x -= directionPowerX * Time.deltaTime;
				_directionMoveInitPower.y += directionPowerY * Time.deltaTime;
			
				_thisTransform.Translate (_directionMoveInitPower * Time.deltaTime  , Space.World);
			
				if(_thisTransform.position.y < -0.6f)
				{
					directionPowerY = Mathf.Abs(directionPowerY);
					_directionMoveInitPower.y = Mathf.Abs(_directionMoveInitPower.y);
				}else if(_thisTransform.position.y > 0.7f )
				{
					directionPowerY = -Mathf.Abs(directionPowerY);
					_directionMoveInitPower.y = -Mathf.Abs(_directionMoveInitPower.y);
				}

				if((_thisTransform.position.x < -(_screenSizeWidth*0.5f) /*|| _thisTransform.position.x > (_screenSizeWidth*0.5f)*/) ||
					(_thisTransform.position.y < -1.1f)  || _thisTransform.position.y > 1.1f ){
					//(_thisTransform.position.y < -(_screenSizeHeight*0.5f))  || _thisTransform.position.y > (_screenSizeHeight*0.5f) ) ){
					_dropItemState = DropItemState.Gone ;
				}
				
			}
			
			
			
			yield return null;
			
		}
		
		StartCoroutine(_dropItemState.ToString());
		
	}
	
	
	protected virtual IEnumerator Magnet(){
		
		if(_dropItemType == DropItemType.DropItem_None) yield break ;
		
		float t = 0f ;
		
		yield return null;
	
		while(_dropItemState == DropItemState.Magnet) {
			
			if(_isMove){
			
				t += Time.deltaTime * 6f;
				_thisTransform.position = Vector3.Lerp(_thisTransform.position, _magnetTargetObject.position, t) ;
			
				
				if(_thisTransform.position == _magnetTargetObject.position) {
					//Debug.Log("Drop Item Magnet State Change Gone") ;
					_dropItemState = DropItemState.Gone ;
				}
				
				
			}
			
			yield return null;
			
		}
		
		StartCoroutine(_dropItemState.ToString());
		
	}
	
	
	//Clash	
	protected virtual IEnumerator Clash(){
		
		if(_dropItemType == DropItemType.DropItem_None) yield break ;
		
		
		// Spawn Clash effect..
		GameObject _go = PoolManager.Spawn("SubmarineGetItemEffectObject") ;
		SubmarineGetItemEffectObject _submarineGetItemEffectObject = _go.GetComponent<SubmarineGetItemEffectObject>() as SubmarineGetItemEffectObject ;
		_submarineGetItemEffectObject.ResetEffectObject(new Vector3(_thisTransform.position.x, _thisTransform.position.y, _thisTransform.position.z-1f)) ;
		_submarineGetItemEffectObject.StartAction() ;
		
		
		_dropItemState = DropItemState.Gone ;
		
		yield return null;
		
		/*
		while(_dropItemState == DropItemState.Clash) {
			
			yield return null;
			
		}
		*/
		
		StartCoroutine(_dropItemState.ToString());
		
	}
	
	
	
	//Dead	
	protected virtual IEnumerator Dead(){
		
		if(_dropItemType == DropItemType.DropItem_None) yield break ;
		
		// Drop Item Dead Effect!!
		
		
		_dropItemState = DropItemState.Gone ;
		
		yield return null;
		
		StartCoroutine(_dropItemState.ToString());
		
	}
	
	
	protected virtual IEnumerator Gone(){
		
		if(_dropItemType == DropItemType.DropItem_None) yield break ;
		
		if(_spriteObjectStateDelegate != null){
			_spriteObjectStateDelegate(this,0) ;	
		}
		
		DestroySpriteObject(0) ;
		
		yield return null;
		
		
	}
	
}
