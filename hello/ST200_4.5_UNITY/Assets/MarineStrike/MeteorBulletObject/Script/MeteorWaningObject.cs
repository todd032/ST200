using UnityEngine;
using System.Collections;

public class MeteorWaningObject : DHPoolGameObject {

	protected float screenSizeWidth ;
	protected float screenSizeHeight ;

	public GameObject _meteorWarningMarkSprite ;
	public GameObject _meteorLineSprite ;

	protected Transform _followTransform;
	protected override void Awake (){
		base.Awake ();	
		
		screenSizeHeight = 2f * Camera.main.orthographicSize;
		screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		
	}
	
	// Use this for initialization
	protected override void Start () {
		
	}
	
	public virtual void DestroyGameObject(int destroyType) {		
		if(_followTransform != null)
		{
			_followTransform = null;
			ThisTransform.parent = null;
		}

		if(destroyType == 0) {
			PoolManager.Despawn(_thisGameObject) ;
		}
	}
	
	public virtual void ResetSpriteObject(Vector3 createPosition){
		_followTransform = null;
		Vector3 reCreatePosition = new Vector3( (screenSizeWidth * 0.5f) - 0.1f , createPosition.y , _thisTransform.position.z) ;
		_thisTransform.eulerAngles = Vector3.zero;
		_thisTransform.position = reCreatePosition ;
		StartCoroutine("MeteorWarningModule") ;
	}

	public void FollowTransform(Transform _follow)
	{	
		_followTransform = null;
		_followTransform = _follow;
		ThisTransform.parent = _followTransform;
		ThisTransform.localPosition = Vector3.zero;
		ThisTransform.localEulerAngles = Vector3.zero;
		StartCoroutine("MeteorWarningModule") ;
	}

	//-------------------
	protected IEnumerator MeteorWarningModule() {

		for(int i = 0 ; i < 10 ; i++) {

			_meteorWarningMarkSprite.SetActive(true) ;
			_meteorLineSprite.SetActive(true) ;

			yield return new WaitForSeconds(0.1f);
			
			_meteorWarningMarkSprite.SetActive(false) ;
			_meteorLineSprite.SetActive(false) ;

			yield return new WaitForSeconds(0.1f);
		}
		
		if(_followTransform != null)
		{
			_followTransform = null;
			ThisTransform.parent = null;
		}
	}


}
