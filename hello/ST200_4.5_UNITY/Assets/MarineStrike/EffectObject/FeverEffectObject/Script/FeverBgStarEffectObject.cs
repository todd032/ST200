using UnityEngine;
using System.Collections;

public class FeverBgStarEffectObject : DHPoolGameObject {
	
	// Protected.
	protected ParticleSystem _particleSystem ;
	
	
	protected override void Awake ()
	{
		base.Awake ();
		
		_particleSystem = _thisGameObject.particleSystem ;
		
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
		//if(!CheckEffectIsAlive()) return ;
		
	}
	
	/*
	//********
	protected virtual bool CheckEffectIsAlive() {
		if (!_particleSystem.IsAlive()){ 
			DestroyEffectObject(0) ;
			return false ;
		}
		return true ;
	}
	*/
	
	public virtual void ResetEffectObject(Vector3 createPosition) {
		
		_thisTransform.position = createPosition ;
		
	}
	
	//--
	public virtual void DestroyEffectObject(int destroyType) {
		if(destroyType == 0){
			_thisTransform.parent = null ;
			PoolManager.Despawn(_thisGameObject) ;	
		}
	}
	
	
	
}
