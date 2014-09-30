using UnityEngine;
using System.Collections;

public class BulletEffectExplosionBaseSpriteObject : MonoBehaviour {

	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ;
	
	public GameObject ThisGameObject 
	{
        get { return _thisGameObject ; }
    }
	
	public Transform ThisTransform
    {
        get { return _thisTransform ; }
    }
	
	
	public string _animationName ;
	public enum CellColorType { White, Yellow , Blue} ;
	public CellColorType _cellColorType = CellColorType.White;

	// Protected
	protected tk2dAnimatedSprite _thisAnimatedSprite;

	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisAnimatedSprite = GetComponent<tk2dAnimatedSprite>() as tk2dAnimatedSprite;
		
	}
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		_thisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual void InitBulletEffectExplosionBaseSpriteObject(){
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetBulletEffectExplosionBaseSpriteObject(Vector3 createPosition){

		//_thisTransform.position = new Vector3(createPosition.x, createPosition.y, createPosition.z-0.01f) ;
		_thisTransform.position = createPosition ;
		
		
		SetActiveSpriteObject(true) ;
		
		if(_cellColorType == CellColorType.Yellow){
			int randomSelect = Random.Range(0, 3) ;
			
			if(randomSelect == 0){
				_thisAnimatedSprite.color = new Color(255f/255f,250f/255f, 174f/255f, 1f) ;	
			}else if(randomSelect == 1){
				_thisAnimatedSprite.color = new Color(252f/255f,255f/255f, 3f/255f, 1f) ;
			}else if(randomSelect == 2){
				_thisAnimatedSprite.color = new Color(255f/255f,218f/255f, 0f, 1f) ;
			}
			
		}else if(_cellColorType == CellColorType.Blue){
			int randomSelect = Random.Range(0, 3) ;
			
			if(randomSelect == 0){
				_thisAnimatedSprite.color = new Color(0f/255f,253f/255f, 251f/255f, 1f) ;	
			}else if(randomSelect == 1){
				_thisAnimatedSprite.color = new Color(2f/255f,221f/255f, 251f/255f, 1f) ;
			}else if(randomSelect == 2){
				_thisAnimatedSprite.color = new Color(14f/255f,157f/255f, 251f/255f, 1f) ;
			}
		}
		
	}
	
	
	
	private void AnimationCompleteDelegate(tk2dAnimatedSprite sprite, int clipId) {
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void StartAcation(){
		
		if(!_thisAnimatedSprite.IsPlaying(_animationName)){
			_thisAnimatedSprite.Play(_animationName);
			_thisAnimatedSprite.animationCompleteDelegate =  AnimationCompleteDelegate;
			_thisAnimatedSprite.animationEventDelegate = null ;
		}
		
	}
	
}
