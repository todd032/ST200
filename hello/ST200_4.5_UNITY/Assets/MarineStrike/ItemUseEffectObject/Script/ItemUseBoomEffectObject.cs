using UnityEngine;
using System.Collections;

public class ItemUseBoomEffectObject : DHPoolGameObject {

	protected float _destoryTime ;
	
	protected override void Awake ()
	{
		base.Awake ();
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}
	
	//********
	public virtual void ResetEffectObject(Vector3 createPosition, float durationTIme) {
		
		_thisTransform.position = createPosition ;
		
		//StartCoroutine("WorkingEffect", durationTIme) ;
		
	}
	
	protected IEnumerator WorkingEffect(float durationTIme) {
	
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(!isDone) {
			
			t += Time.deltaTime ;
			
			if(t >= durationTIme) {
				isDone = true ;
			}
			
			yield return null ;
		}
		
		DestroyEffectObject(0) ;
		
	}
	
	//--
	public virtual void DestroyEffectObject(int destroyType) {
		if(destroyType == 0){
			_thisTransform.parent = null ;
			PoolManager.Despawn(_thisGameObject) ;	
		}
	}
	
}
