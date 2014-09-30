using UnityEngine;
using System.Collections;

public class SpecialAttackLaserEffectObject : DHPoolGameObject {
	
	public float _destroyTime = 0.5f;
	public tk2dAnimatedSprite m_SpriteAnimation;
	
	protected override void Awake() {
		base.Awake() ;
	}
	
	// Use this for initialization
	protected override void Start () {
		
	}
	
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	public virtual void DestroySpriteObject(int destroyType) {
		if(destroyType == 0) {
			PoolManager.Despawn(_thisGameObject) ;
		}
	}
	
	public virtual void ResetEffectObject(){
	}
	
	public virtual void ResetEffectObject(Vector3 createPosition){
		
		_thisTransform.position = createPosition ;
		
	}
	
	public virtual void StartAction(){

		m_SpriteAnimation.Play();
		StartCoroutine("CheckDestory") ;
		
	}
	
	private IEnumerator CheckDestory(){
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(!isDone){
			
			//t += Time.deltaTime ;
			
			if(!m_SpriteAnimation.IsPlaying(m_SpriteAnimation.CurrentClip)){
				
				isDone = true ;
			}
			
			yield return null ;
			
		}
		
		DestroySpriteObject(0) ;
		
	}
	
}
