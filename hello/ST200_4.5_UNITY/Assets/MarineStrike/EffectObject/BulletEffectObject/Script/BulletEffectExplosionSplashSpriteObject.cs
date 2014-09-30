using UnityEngine;
using System.Collections;

public class BulletEffectExplosionSplashSpriteObject : MonoBehaviour {

	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ;
	
	public GameObject ThisGameObject 
	{
        get { 
			if(_thisGameObject == null)
			{
				_thisGameObject = gameObject;
			}
			return _thisGameObject ; }
    }
	
	public Transform ThisTransform
    {
        get { 
			if(_thisTransform == null)
			{
				_thisTransform = transform;
			}
			return _thisTransform ; }
    }
	
	protected tk2dSprite _thisSprite ;
	
	
	public enum CellColorType { White, Yellow , Blue, Orange} ;
	public CellColorType _cellColorType = CellColorType.White;
	
	public float _moveSpeed ;
	
	// FSM
	public enum	FSMState { Idle , Move, Gone} ;
	protected FSMState _fsmState = FSMState.Idle;
	
	
	void Awake(){				
	}
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	public virtual void SetActiveSpriteObject(bool isActiveSpriteObject) {
		ThisGameObject.SetActive(isActiveSpriteObject) ;
	}
	
	public virtual void InitBulletEffectExplosionBaseSpriteObject(){
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisSprite = GetComponent<tk2dSprite>() as tk2dSprite;

		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetBulletEffectExplosionBaseSpriteObject(Vector3 createPosition){

		_thisTransform.position = new Vector3(createPosition.x, createPosition.y, createPosition.z-0.01f) ;
		
		_thisSprite.scale = new Vector3(0f, 0f , 1f) ;
		
		SetActiveSpriteObject(true) ;
		
		if(_cellColorType == CellColorType.Yellow){
			int randomSelect = Random.Range(0, 3) ;
			
			if(randomSelect == 0){
				_thisSprite.color = new Color(255f/255f,250f/255f, 174f/255f, 1f) ;	
			}else if(randomSelect == 1){
				_thisSprite.color = new Color(252f/255f,255f/255f, 3f/255f, 1f) ;
			}else if(randomSelect == 2){
				_thisSprite.color = new Color(255f/255f,218f/255f, 0f, 1f) ;
			}
			
		}else if(_cellColorType == CellColorType.Blue){
			int randomSelect = Random.Range(0, 3) ;
			
			if(randomSelect == 0){
				_thisSprite.color = new Color(0f/255f,253f/255f, 251f/255f, 1f) ;	
			}else if(randomSelect == 1){
				_thisSprite.color = new Color(2f/255f,221f/255f, 251f/255f, 1f) ;
			}else if(randomSelect == 2){
				_thisSprite.color = new Color(14f/255f,157f/255f, 251f/255f, 1f) ;
			}
		}else if(_cellColorType == CellColorType.Orange){
			_thisSprite.color = new Color(255f/255f, 112f/255f, 38f/255f, 1f) ;
		}
		
		_fsmState = FSMState.Idle ;
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	public virtual void StartMoveAcation(){
		
		_fsmState = FSMState.Move;
		
	}
	
	
	// FSM
	protected virtual IEnumerator Idle() {
		
		yield return null ;
		
		while(_fsmState == FSMState.Idle) {
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	protected virtual IEnumerator Move() {
		
		Vector3 startVector = new Vector3(0f, 0f, 1f) ;
		Vector3 endVector = new Vector3(3f, 3f, 3f) ;
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			if(!isDone){
				t += (Time.deltaTime*_moveSpeed) ;
				
				_thisTransform.Rotate(Vector3.forward * (10f*Time.timeScale), Space.World);
				
				_thisSprite.scale = Vector3.Lerp(startVector,endVector,t) ;
				
				if(_thisSprite.scale == endVector) {
					_fsmState = FSMState.Gone ;
					isDone = true ;
				}
			}
			
			yield return null;
			
		}
		
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	
	protected virtual IEnumerator Gone() {
	
		SetActiveSpriteObject(false) ;
		
		yield return null ;
		
	}
	
}
