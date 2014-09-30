using UnityEngine;
using System.Collections;

public class DropAnimationItemObject_MoveStable : DropItemObject {
	
	protected Animation _animation ;
	
	
	protected override void Awake (){
		base.Awake ();
		
		_animation = _thisGameObject.animation ;
		
	}
	
	// Use this for initialization
	protected override void Start () {
		base.Start () ;
	}
	
	
	//-------
	public override void DropItemStartAction(Vector3 createPosition, float directionMoveInitMinPower, float directionMoveInitMaxPower, Vector2 directionMoveMinPower, Vector2 directionMoveMaxPower) {
		
		base.DropItemStartAction(createPosition, directionMoveInitMinPower, directionMoveInitMaxPower, directionMoveMinPower, directionMoveMaxPower) ;

		EffectPlay() ;
		
	}
	//--------
	
	
	//---- Animation Controller
	public override void EffectPlay(){		
		base.EffectPlay() ;
		
		if(!IsActiveSpriteObject()) return ;
		
		if(!_animation.isPlaying){
			_animation.Play() ;
		}
	}
	
	public override void EffectStop(){
		base.EffectStop() ;
		
		if(!IsActiveSpriteObject()) return ;
		
		if(_animation.isPlaying){
			_animation.Stop() ;
		}
	}
	
	public override void EffectResume(){
		base.EffectResume() ;
		
		if(!IsActiveSpriteObject()) return ;
		
		if(!_animation.isPlaying){
			_animation.Play() ;
		}
		
	}
	
	public override void EffectPause(){
		base.EffectPause() ;
		
		if(!IsActiveSpriteObject()) return ;
		
		if(_animation.isPlaying){
			_animation.Stop() ;
		}
	}
	
	protected override IEnumerator Move ()
	{
		if(_dropItemType == DropItemType.DropItem_None) yield break ;	
		float movespeed = _directionMoveInitMinPower;
		
		yield return null;
		
		while(_dropItemState == DropItemState.Move) {
			
			if(_isMove){
				_thisTransform.Translate (-Vector3.right * movespeed * Time.deltaTime  , Space.World);
				
				
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
	
}
