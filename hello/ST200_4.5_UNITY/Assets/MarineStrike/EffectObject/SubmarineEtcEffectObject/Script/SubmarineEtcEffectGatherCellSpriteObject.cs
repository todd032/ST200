using UnityEngine;
using System.Collections;

public class SubmarineEtcEffectGatherCellSpriteObject : MonoBehaviour {

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
	
	public Color m_ImageColor;

	public Vector2 _minGapCreatePostion ;
	public Vector2 _maxGapCreatePostion ;
	
	
	public float _moveMinSpeed ;
	public float _moveMaxSpeed ;
	
	// Protected
	protected tk2dSprite _thisSprite;
	
	// FSM
	public enum	FSMState { Idle , Move, Gone} ;
	protected FSMState _fsmState = FSMState.Idle;
	
	
	protected float randomPositionX ;
	protected float randomPositionY ;
	
	protected Vector3 _moveEndPosition ;
	
	
	
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
	
	public virtual void InitSubmarineEtcEffectGatherCellSpriteObject(Color _color){
		m_ImageColor = _color;
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetSubmarineEtcEffectGatherCellSpriteObject(Vector3 createPosition){
		
		
		randomPositionX = Random.Range(_minGapCreatePostion.x, _maxGapCreatePostion.x) ;
		randomPositionY = Random.Range(_minGapCreatePostion.y, _maxGapCreatePostion.y) ;
		_thisTransform.position = new Vector3(createPosition.x + randomPositionX, createPosition.y + randomPositionY, createPosition.z) ;
		
		_moveEndPosition = createPosition ;
		
		_thisSprite.scale = new Vector3(1f, 1f , 1f) ;
		
		SetActiveSpriteObject(true) ;
		
		_thisSprite.color = m_ImageColor;
		
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
		
		float _moveSpeed = Random.Range(_moveMinSpeed, _moveMaxSpeed) ;
		
		Vector3 startPosition = _thisTransform.position ;
		Vector3 endPosition = _moveEndPosition ;
		
		Vector3 startVector = new Vector3(1f, 1f, 1f) ;
		Vector3 endVector = new Vector3(0f, 0f, 1f) ;
		
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			if(!isDone){
				t += (Time.deltaTime*_moveSpeed) ;
				
				//_thisTransform.Rotate(Vector3.forward * (10f*Time.timeScale));
				
				_thisSprite.scale = Vector3.Lerp(startVector,endVector, t);//Mathf.Pow(t, 2f/3f)) ;
				
				_thisTransform.position = Vector3.Lerp(startPosition,endPosition, Mathf.Pow(t, 2f/3f) * 0.9f) ;
				
				if(_thisTransform.position == endPosition) {
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
