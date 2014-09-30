using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class PatternObjectSet : DHPoolGameObject {
	
	[HideInInspector]
	public delegate void PatternObjectSetDelegate(PatternObjectSet patternObjectSet, PatternObject patternObject, int state);
	protected PatternObjectSetDelegate _patternObjectSetStateDelegate ;
	public event PatternObjectSetDelegate PatternObjectSetStateDelegate {
		add{
			
			_patternObjectSetStateDelegate = null ;
			
			if (_patternObjectSetStateDelegate == null)
        		_patternObjectSetStateDelegate += value;
        }
		
		remove{
            _patternObjectSetStateDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void PatternSetMoveStateDelegate(PatternObjectSet _pos);
	protected PatternSetMoveStateDelegate _patternSetMoveScreenOut, _patternSetMoveScreenEnd, _patternSetMoveScreenStart, _patternSetMoveScreenDestination;
	//public event PatternSetMoveStateDelegate PatternSetMoveScreenOut, PatternSetMoveScreenEnd;
	
	public event PatternSetMoveStateDelegate PatternSetMoveScreenOut {
		add{
			
			_patternSetMoveScreenOut = null ;
			
			if (_patternSetMoveScreenOut == null)
        		_patternSetMoveScreenOut += value;
        }
		
		remove{
            _patternSetMoveScreenOut -= value;
		}
	}
	public event PatternSetMoveStateDelegate PatternSetMoveScreenEnd {
		add{
			
			_patternSetMoveScreenEnd = null ;
			
			if (_patternSetMoveScreenEnd == null)
        		_patternSetMoveScreenEnd += value;
        }
		remove{
            _patternSetMoveScreenEnd -= value;
		}
	}
	public event PatternSetMoveStateDelegate PatternSetMoveScreenStart {
		add{
			
			_patternSetMoveScreenStart = null ;
			
			if (_patternSetMoveScreenStart == null)
        		_patternSetMoveScreenStart += value;
        }
		remove{
            _patternSetMoveScreenStart -= value;
		}
	}
	public event PatternSetMoveStateDelegate PatternSetMoveScreenDestination {
		add{
			
			_patternSetMoveScreenDestination = null ;
			
			if (_patternSetMoveScreenDestination == null)
        		_patternSetMoveScreenDestination += value;
        }
		remove{
            _patternSetMoveScreenDestination -= value;
		}
	}
	
	
	// Public.
	
	//public Camera _baseCamera ;
	public bool isFullScreenSizeWidth = false ;
	public bool isFullScreenSizeHeight = true ;
	
	public float startPositionGap = 0f ;
	
	public Vector2 destinationPosition ;
	
	
	
	// Protected.
	protected Vector2 _screenCenterPosition ;
	protected Vector2 _screenSize ;
	protected List<PatternObject> _patternObjectList ;
	
	//protected List<PatternObject> _patternObjectListOriginal ;
	protected List<Vector3> _patternObjectListOriginalPosition ;
	
	protected Vector2 _patternSetCenterPosition ;
	protected Vector2 _patternSetSize ;
	
	protected float _patternSetMoveSpeed ;
	protected bool _isMove = false ;
	
	protected bool _patternSetScreenOutState = false ;
	protected bool _patternSetScreenEndState = false ;
	protected bool _patternSetScreenStartState = false ;
	protected bool _patternSetScreenDestinationState = false ;

	
	// Property
	public Vector2 PatternSetSize {
		get { return _patternSetSize ; }
	}
	
	public float PatternSetMoveSpeed {
		get { return _patternSetMoveSpeed ; }
		set { _patternSetMoveSpeed = value ; }
	}
	
	
	//-----
	protected override void Awake ()
	{
		base.Awake ();
		
		_screenCenterPosition = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y) ;
		
		float screenSizeHeight = 2f * Camera.main.orthographicSize ;
		float screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		_screenSize = new Vector2(screenSizeWidth , screenSizeHeight) ;

	}
	
	protected virtual void OnEnable() {
		/*
		_patternSetScreenOutState = false ;
		_patternSetScreenEndState = false ;
		_patternSetScreenStartState = false ;
		_patternSetScreenDestinationState = false ;	
		*/
	}
	
	protected override void Start ()
	{
		base.Start ();
		
	}
	
	//--
	protected virtual void PatternObjectDelegate(PatternObject patternObject, int state){
		if(state >= 100 && state <= 200) { // State - 100 : Process Score..
			if(_patternObjectSetStateDelegate != null){
				_patternObjectSetStateDelegate(this, patternObject, state) ;
			}
			return ;
		}
	}
	
	//---
	protected virtual void SetPatternObjectList() { // Only If use auto position state.
		
		PatternObject[] allChildren = GetComponentsInChildren<PatternObject>() ;
		
		//_patternObjectListOriginal = new List<PatternObject>(allChildren.Length) ;
		_patternObjectListOriginalPosition = new List<Vector3>(allChildren.Length) ;
		
		//
		_patternObjectList = new List<PatternObject>(allChildren.Length) ;
		
		foreach (PatternObject child in allChildren) {
			_patternObjectList.Add(child) ;	
			//child.PatternObjectStateDelegate += PatternObjectDelegate ;
		}
		
	}
	
	/*
	protected virtual void SetPatternObjectSortList() {
		
		//_patternObjectListOriginal = new List<PatternObject>(_patternObjectList.Count) ;
		
		// Horizontal, Position X
		//float tempMinPatternObjectPositionX = _po.ThisTransform.localPosition.x - _po.SpriteSize.x ;
		//float tempMaxPatternObjectPositionX = _po.ThisTransform.localPosition.x + _po.SpriteSize.x ;
		
		for(int i=0 ; i < _patternObjectList.Count ; i++) {
			
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			Vector3 _poPosition = _po.ThisTransform.localPosition ;
			
			if(_patternObjectListOriginal.Count == 0) {
				_patternObjectListOriginal.Add(_po) ;
				_patternObjectListOriginalPosition.Add(_poPosition) ;
			}else{
		
				bool isExistComp = false ;
				float tempMinPatternObjectPositionX = _po.ThisTransform.localPosition.x - _po.SpriteSize.x ;
				
				for(int j=0 ; j < _patternObjectListOriginal.Count ; j++) {
					
					PatternObject tempPo = _patternObjectListOriginal[j] as PatternObject ;
					
					float tempMinPoPositionX = tempPo.ThisTransform.localPosition.x - tempPo.SpriteSize.x ;
						
					if(tempMinPoPositionX > tempMinPatternObjectPositionX) {
						_patternObjectListOriginal.Insert(j,_po) ;
						_patternObjectListOriginalPosition.Insert(j,_poPosition) ;
						isExistComp = true ;
						break ;
					}
					
				}
				
				if(!isExistComp) {
					_patternObjectListOriginal.Add(_po) ;
					_patternObjectListOriginalPosition.Add(_poPosition) ;
				}
				
			}
			
		}
		
		// Vertical, Position Y
		//float tempMinPatternObjectPositionY = _po.ThisTransform.localPosition.y - _po.SpriteSize.y ;
		//float tempMaxPatternObjectPositionY = _po.ThisTransform.localPosition.y + _po.SpriteSize.y ;
		
	}
	
	//--- Use R100 Trap Pattern
	public virtual void SetRelocationPatternObjects(float gameSpeed) {
	
		if(_patternObjectListOriginal.Count == 0) {
			SetPatternObjectSortList() ;
		}
		
		
		_patternObjectList.Clear() ;
		for(int i=0 ; i < _patternObjectListOriginal.Count ; i++) {
			PatternObject _po = _patternObjectListOriginal[i] as PatternObject ;
			_po.ThisTransform.localPosition = _patternObjectListOriginalPosition[i] ;
			_patternObjectList.Add(_po) ;
		}

		Vector3 firstObjectPositionVector = Vector3.zero ;
		for(int i = 0 ; i < _patternObjectList.Count ; i++) {
			
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			Vector3 currentPositionVector = _po.ThisTransform.localPosition ;
			
			if(i==0) {
				firstObjectPositionVector = currentPositionVector ;
			}else{
				
				float gapfirstObjectPosition = currentPositionVector.x - firstObjectPositionVector.x ;
				float gapSize = ((gameSpeed-1f)*0.01f) * gapfirstObjectPosition * 10f ;
				
				_po.ThisTransform.localPosition = new Vector3((currentPositionVector.x + gapSize), currentPositionVector.y, currentPositionVector.z) ;
				
			}
			
		}
		
		SetPatternSetSize() ; // after work ReadyPatternSetPosition().
		
	}
	*/
	
	protected virtual void InitSetPatternObjectListPosition() {
		
		for(int i=0 ; i < _patternObjectList.Count ; i++) {
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			_patternObjectListOriginalPosition.Add(_po.ThisTransform.localPosition) ;
		}
		
	}
	
	//--- Use R100 Trap Pattern
	public virtual void SetRelocationPatternObjects(float gameSpeed) {
		
		if(_patternObjectListOriginalPosition.Count == 0) {
			InitSetPatternObjectListPosition() ;
		}
		
		// Reset Original
		for(int i=0 ; i < _patternObjectList.Count ; i++) {
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			_po.ThisTransform.localPosition = _patternObjectListOriginalPosition[i] ;
		}
		
		//
		Vector3 firstObjectPositionVector = Vector3.zero ;
		for(int i = 0 ; i < _patternObjectList.Count ; i++) {
			
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			Vector3 currentPositionVector = _po.ThisTransform.localPosition ;
			
			if(i==0) {
				firstObjectPositionVector = currentPositionVector ;
			}else{
				
				float gapfirstObjectPosition = currentPositionVector.x - firstObjectPositionVector.x ;
				float gapSize = ((gameSpeed-1f)*0.05f) * gapfirstObjectPosition * 10f ;
				
				_po.ThisTransform.localPosition = new Vector3((currentPositionVector.x + gapSize), currentPositionVector.y, currentPositionVector.z) ;
				
			}
			
		}
		
		SetPatternSetSize() ; // after work ReadyPatternSetPosition().
		
	}
	
	
	//---
	protected virtual void SetPatternSetSize() {
	
		float patternSetWidth = 0f ;
		float patternSetHeight = 0f ;
		
		float minPatternObjectPositionX = 0f ;
		float maxPatternObjectPositionX = 0f ;
		float minPatternObjectPositionY = 0f ;
		float maxPatternObjectPositionY = 0f ;
		
		
		for(int i = 0 ; i < _patternObjectList.Count ; i++) {
			
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			
			if(i==0) {
			
				minPatternObjectPositionX = _po.ThisTransform.localPosition.x - _po.SpriteSize.x ;
				maxPatternObjectPositionX = _po.ThisTransform.localPosition.x + _po.SpriteSize.x ;
				
				minPatternObjectPositionY = _po.ThisTransform.localPosition.y - _po.SpriteSize.y ;
				maxPatternObjectPositionY = _po.ThisTransform.localPosition.y + _po.SpriteSize.y ;
				
			}else{
				
				float tempMinPatternObjectPositionX = _po.ThisTransform.localPosition.x - _po.SpriteSize.x ;
				float tempMaxPatternObjectPositionX = _po.ThisTransform.localPosition.x + _po.SpriteSize.x ;
				
				float tempMinPatternObjectPositionY = _po.ThisTransform.localPosition.y - _po.SpriteSize.y ;
				float tempMaxPatternObjectPositionY = _po.ThisTransform.localPosition.y + _po.SpriteSize.y ;
				
				minPatternObjectPositionX = Mathf.Min(minPatternObjectPositionX, tempMinPatternObjectPositionX) ;
				maxPatternObjectPositionX = Mathf.Max(maxPatternObjectPositionX, tempMaxPatternObjectPositionX) ;
				
				minPatternObjectPositionY = Mathf.Min(minPatternObjectPositionY, tempMinPatternObjectPositionY) ;
				maxPatternObjectPositionY = Mathf.Max(maxPatternObjectPositionY, tempMaxPatternObjectPositionY) ;				
			}			
		}
		
		
		float patternSetCenterPositionX = 0f ;
		float patternSetCenterPositionY = 0f ;
		
		if(isFullScreenSizeWidth) {
			patternSetWidth = _screenSize.x ;
			patternSetCenterPositionX = _screenCenterPosition.x ;
		}else{
			patternSetWidth = maxPatternObjectPositionX - minPatternObjectPositionX ;
			patternSetCenterPositionX = minPatternObjectPositionX + (patternSetWidth*0.5f) ;
		}
		
		if(isFullScreenSizeHeight) {
			patternSetHeight = _screenSize.y ;
			patternSetCenterPositionY = _screenCenterPosition.y ;
		}else{
			patternSetHeight = maxPatternObjectPositionY - minPatternObjectPositionY ;
			patternSetCenterPositionY = minPatternObjectPositionY + (patternSetHeight*0.5f) ;
		}
		
		
		_patternSetSize = new Vector2(patternSetWidth, patternSetHeight) ;
		
		_patternSetCenterPosition = new Vector2(_screenCenterPosition.x - patternSetCenterPositionX, _screenCenterPosition.y - patternSetCenterPositionY) ;

		ReadyPatternSetPosition() ; ///
	}
	
	
	//protected virtual void ReadyPatternSetPosition() {
	public virtual void ReadyPatternSetPosition() {
		_thisTransform.localPosition = new Vector3(_patternSetCenterPosition.x + (_patternSetSize.x*0.5f)+(_screenSize.x*0.5f) + startPositionGap , -_patternSetCenterPosition.y, _thisTransform.localPosition.z) ;
	}
	
	//---
	public virtual void ResetPatternObjects(float gameSpeed, int gameLevel, float weightLevel) {
		_patternSetScreenOutState = false ;
		_patternSetScreenEndState = false ;
		_patternSetScreenStartState = false ;
		_patternSetScreenDestinationState = false ;		
	}
	
	public virtual void ResetPatternObjects(float gameSpeed, int gameLevel) {
		_patternSetScreenOutState = false ;
		_patternSetScreenEndState = false ;
		_patternSetScreenStartState = false ;
		_patternSetScreenDestinationState = false ;	
	}
	
	public virtual void ResetPatternObjects(float resetValue) {
		_patternSetScreenOutState = false ;
		_patternSetScreenEndState = false ;
		_patternSetScreenStartState = false ;
		_patternSetScreenDestinationState = false ;	
	}
	
	public virtual void ResetPatternObjects() {
		_patternSetScreenOutState = false ;
		_patternSetScreenEndState = false ;
		_patternSetScreenStartState = false ;
		_patternSetScreenDestinationState = false ;	
	}
	
	//---
	public virtual void MovePatternSet(bool isMove, int moveState) {	// State : 1 - Play   2 - Stop  3 - Pause  4 - Resume
		
		_isMove = isMove ;
		
		if(_isMove) {
			
			for(int i = 0 ; i < _patternObjectList.Count ; i++) {
				PatternObject _po = _patternObjectList[i] as PatternObject ;
				if(moveState == 1) {
					_po.AnimationPlay() ;
				}else if(moveState == 4) {
					_po.AnimationResume() ;
				}
				
			}
			
		}else{
			for(int i = 0 ; i < _patternObjectList.Count ; i++) {
				PatternObject _po = _patternObjectList[i] as PatternObject ;
				if(moveState == 2) {
					_po.AnimationStop() ;
				}else if(moveState == 3) {
					_po.AnimationPause() ;
				}
				
			}
		}
		
		TranslatePatternSet(_patternSetMoveSpeed) ;
	}
	
	public virtual void TranslatePatternSet(float moveSpeed) {
		
		if(_isMove) {
			float amtMove = moveSpeed * Time.deltaTime ;
			_thisTransform.Translate(-Vector3.right * amtMove, Space.World) ;
			
		}
	}
	
	protected virtual void CheckPatternSetState() {
		
		if((_thisTransform.localPosition.x <= -(_screenSize.x * 0.5f)-(_patternSetSize.x*0.5f) + _patternSetCenterPosition.x) && !_patternSetScreenOutState) {
			
			_patternSetScreenOutState = true ;
			
			
			if(_patternSetMoveScreenOut != null) {
				_patternSetMoveScreenOut(this) ;
			}
				
			//_isMove = false ;
			
		}
			
		if((_thisTransform.localPosition.x < -(_patternSetSize.x * 0.5f ) + (_screenSize.x * 0.5f) + _patternSetCenterPosition.x) && !_patternSetScreenEndState) {
			
			_patternSetScreenEndState = true ;
			
			if(_patternSetMoveScreenEnd != null) {
				_patternSetMoveScreenEnd(this) ;
			}

		}
		
		if((_thisTransform.localPosition.x < (_patternSetSize.x * 0.5f ) + (_screenSize.x * 0.5f) + _patternSetCenterPosition.x) && !_patternSetScreenStartState) {
			
			_patternSetScreenStartState = true ;
			
			if(_patternSetMoveScreenStart != null) {
				_patternSetMoveScreenStart(this) ;
			}

		}
		
		if((_thisTransform.localPosition.x < (_patternSetSize.x * 0.5f ) + destinationPosition.x + _patternSetCenterPosition.x) && !_patternSetScreenDestinationState) {
			
			_patternSetScreenDestinationState = true ;
			
			if(_patternSetMoveScreenDestination != null) {
				_patternSetMoveScreenDestination(this) ;
			}

		}
		
		
	}
	
	//--
	public virtual void DestroyPatternObjects(int destroyType) {
	
		/////////////
		for(int i = 0 ; i < _patternObjectList.Count ; i++) {
			PatternObject _po = _patternObjectList[i] as PatternObject ;
			_po.DestroyPatternObject(destroyType) ;
			//_po.SetActivePatternObject(false) ;
		}
		/////////////
	}
	
	
	// Update is called once per frame
	protected virtual void Update () {
		if(_isMove) {
			TranslatePatternSet(_patternSetMoveSpeed) ;
			CheckPatternSetState() ;
		}
	}
	
}
