using UnityEngine;
using System.Collections;

public class SubmarineEtcEffectGatherBaseSpriteObject : MonoBehaviour {

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
	
	
	//public enum CellColorType { White, Yellow , Green} ;
	//public CellColorType _cellColorType = CellColorType.White;
	public Color m_ImageColor = Color.white;
	
	public float _moveSpeed ;
	
	// Protected
	protected tk2dSprite _thisSprite;
	
	// FSM
	public enum	FSMState { Idle , Move, Gone} ;
	protected FSMState _fsmState = FSMState.Idle;
	
	
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
	
	public virtual void InitSubmarineEtcEffectGatherBaseSpriteObject(Color _color){
		m_ImageColor = _color;
		SetActiveSpriteObject(false) ;
	}
	
	public virtual void ResetSubmarineEtcEffectGatherBaseSpriteObject(Vector3 createPosition){
		
		_thisTransform.position = createPosition ;
		
		_thisSprite.scale = new Vector3(1f, 1f , 1f) ;
		
		SetActiveSpriteObject(true) ;

		_thisSprite.color = m_ImageColor ;
		
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
		
		Vector3 startVector = new Vector3(3f, 3f, 1f) ;
		Vector3 endVector = new Vector3(0f, 0f, 1f) ;
		
		
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(_fsmState == FSMState.Move) {
			
			if(!isDone){
				t += (Time.deltaTime*_moveSpeed) ;
				
				_thisSprite.scale = Vector3.Lerp(startVector,endVector, t * t) ;
				
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
