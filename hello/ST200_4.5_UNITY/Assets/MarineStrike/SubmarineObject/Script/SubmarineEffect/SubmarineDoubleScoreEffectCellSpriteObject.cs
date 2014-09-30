using UnityEngine;
using System.Collections;

public class SubmarineDoubleScoreEffectCellSpriteObject : MonoBehaviour {

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
	
	
	public enum CellColorType { White, Green, Yellow} ;
	public CellColorType _cellColorType = CellColorType.White;
	
	
	public float _moveSpeed ;
	
	// Protected
	protected tk2dSprite _thisSprite;
	
	// FSM
	public enum	FSMState { Idle , Move, Gone} ;
	protected FSMState _fsmState = FSMState.Idle;
	
	//
	protected float _rotateDirect ;
	
	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisSprite = GetComponent<tk2dSprite>() as tk2dSprite;
		
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
	
	public virtual bool IsActiveSpriteObject() {
		return _thisGameObject.activeSelf ;
	}
	
	public virtual void InitSubmarineCellSpriteObject(){
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetSubmarineCellSpriteObject(Vector3 createPosition){
		
		_thisTransform.position = createPosition ;
		
		_rotateDirect = 7f ;
		int selectRotateDirect = Random.Range(0,2) ;
		if(selectRotateDirect == 0){
			_rotateDirect = 7f ;
		}else if(selectRotateDirect == 1){
			_rotateDirect = 7f ;
		}
		
		
		//_thisSprite.scale = new Vector3(1f, 1f , 1f) ;
		_thisSprite.scale = new Vector3(0f, 0f , 1f) ;
		
		SetActiveSpriteObject(true) ;
		
		if(_cellColorType == CellColorType.White){
		
			_thisSprite.color = Color.white ;
			
		}else if(_cellColorType == CellColorType.Green){
			
			int randomSelect = Random.Range(0, 3) ;
			
			if(randomSelect == 0){
				_thisSprite.color = new Color(153f/255f, 255f/255f, 235f/255f, 1f) ;	
			}else if(randomSelect == 1){
				_thisSprite.color = new Color(45f/255f, 255f/255f, 203f/255f, 1f) ;	
			}else if(randomSelect == 2){
				_thisSprite.color = new Color(30f/255f, 218f/255f, 163f/255f, 1f) ;
			}
			
		}else if(_cellColorType == CellColorType.Yellow){
			
			_thisSprite.color = Color.yellow ;
			
		}
		
		
		_fsmState = FSMState.Idle ;
		StartCoroutine(_fsmState.ToString()) ;
		
	}
	
	public virtual void StartMoveAcation(){
		
		_fsmState = FSMState.Move;
		
	}
	
	public virtual void SetTransformPosition(Vector3 newPosition){
		_thisTransform.position = newPosition ;
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
		
		//Vector3 startVector = new Vector3(1f, 1f, 1f) ;
		//Vector3 endVector = new Vector3(0f, 0f, 1f) ;
		Vector3 startVector = new Vector3(0f, 0f, 1f) ;
		Vector3 endVector = new Vector3(1f, 1f, 1f) ;
		
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			if(!isDone){
				t += (Time.deltaTime*_moveSpeed) ;
				
				_thisTransform.Rotate(Vector3.forward * (_rotateDirect*Time.timeScale), Space.World);
				
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
