using UnityEngine;
using System.Collections;

public class FeverTimeAlertObject : DHPoolGameObject {
	
	// Protected.
	protected Animation _animation ;
	
	
	protected override void Awake ()
	{
		base.Awake ();
		
		_animation = _thisGameObject.animation ;
		
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}
	
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
