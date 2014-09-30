using UnityEngine;
using System.Collections;

public class GamePatternManager : MonoBehaviour {
	
	[HideInInspector]
	public delegate void PatternManagerDelegate(PatternObject patternObject, int state);
	protected PatternManagerDelegate _patternManagerStateDelegate ;
	public event PatternManagerDelegate PatternManagerStateDelegate {
		add{
			
			_patternManagerStateDelegate = null ;
			
			if (_patternManagerStateDelegate == null)
        		_patternManagerStateDelegate += value;
        }
		
		remove{
            _patternManagerStateDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void PatternManagerStageStateDelegate(int state);
	protected PatternManagerStageStateDelegate _patternManagerStageState ;
	public event PatternManagerStageStateDelegate PatternManagerStageState {
		add{
			
			_patternManagerStageState = null ;
			
			if (_patternManagerStageState == null)
        		_patternManagerStageState += value;
        }
		
		remove{
            _patternManagerStageState -= value;
		}
	}
	
	
	public GameObject patternSetRolling_main ;
	public GameObject patternSetRolling_fever ;
	
	private PatternSetRolling _mainPatternSetRolling ;
	private PatternSetRolling _feverPatternSetRolling ;
	
	private PatternSetRolling _currentPatternSetRolling ;
	private PatternSetRolling.GamePatternSetRollingMode currentGamePatternSetRollingMode ;
	
	void Awake() {
		
		//if(patternSetRolling_main != null) {
		//	GameObject mainPatternSetRollingObejct = Instantiate(patternSetRolling_main) as GameObject;
		//	_mainPatternSetRolling = mainPatternSetRollingObejct.GetComponent<PatternSetRolling>() as PatternSetRolling ;
		//	_mainPatternSetRolling.PatternSetStop += PatternSetStop ;
		//	_mainPatternSetRolling.PatternSetRollingStateDelegate += PatternSetRollingStateDelegate ;
		//	
		//	_currentPatternSetRolling = _mainPatternSetRolling ;
		//	currentGamePatternSetRollingMode = _currentPatternSetRolling.currentGamePatternSetRollingMode ;
		//	
		//}
		//
		//if(patternSetRolling_fever != null) {
		//	GameObject feverPatternSetRollingObejct = Instantiate(patternSetRolling_fever) as GameObject;
		//	_feverPatternSetRolling = feverPatternSetRollingObejct.GetComponent<PatternSetRolling>() as PatternSetRolling ;
		//	_feverPatternSetRolling.PatternSetStop += PatternSetStop ;
		//	_feverPatternSetRolling.PatternSetRollingStateDelegate += PatternSetRollingStateDelegate ;
		//}
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	//-- *****
	//-- Special Init
	// .....
	public void InitSettingMainPatternSetRolling(float gameSpeed, int patternLevel) {
		
		if(_mainPatternSetRolling != null) {
			_mainPatternSetRolling.PatternObjectSetMoveSpeed = gameSpeed ;
			_mainPatternSetRolling.PatternLevel = patternLevel ;
		}
		
	}
	
	public void InitSettingFeverPatternSetRolling(float gameSpeed, int patternLevel) {
		
		if(_feverPatternSetRolling != null){
			_feverPatternSetRolling.PatternObjectSetMoveSpeed = gameSpeed ;
			_feverPatternSetRolling.PatternLevel = patternLevel ;
		}
		
	}
	
	public void InitSettingMainPatternSetRolling(float gameSpeed, int patternLevel, float weightLevel) {
		
		if(_mainPatternSetRolling != null) {
			_mainPatternSetRolling.PatternObjectSetMoveSpeed = gameSpeed ;
			_mainPatternSetRolling.PatternLevel = patternLevel ;
			_mainPatternSetRolling.WeightLevel = weightLevel ;
		}
		
	}
	
	public void InitSettingFeverPatternSetRolling(float gameSpeed, int patternLevel, float weightLevel) {
		
		if(_feverPatternSetRolling != null){
			_feverPatternSetRolling.PatternObjectSetMoveSpeed = gameSpeed ;
			_feverPatternSetRolling.PatternLevel = patternLevel ;
			_feverPatternSetRolling.WeightLevel = weightLevel ;
		}
		
	}
	
	
	//-- *****
	
	
	//--
	public void StartCurrentPatternSetRolling(float delayStartTime) {
		_currentPatternSetRolling.StartPatternManager(delayStartTime) ;
	}
	
	public void StopCurrentPatternSetRolling(bool immediatelyStop, int destroyType) {
		_currentPatternSetRolling.StopPatternManager(immediatelyStop, destroyType) ;
	}
	
	public void PauseCurrentPatternSetRolling() {
        _currentPatternSetRolling.PausePatternManager() ;
    }
    
    public void ResumeCurrentPatternSetRolling() {
        _currentPatternSetRolling.ResumePatternManager() ;
    }
	
	//--
	public void ChangeCurrentPatternObjectSetMoveSpeed(float moveSpeed) {
		_currentPatternSetRolling.ChangePatternObjectSetMoveSpeed(moveSpeed) ;
	}
	
	public void ChangeCurrentPatternObjectSetPatternLevel(int patternLevel) {
		_currentPatternSetRolling.ChangePatternObjectSetPatternLevel(patternLevel) ;
	}
	
	public void ChangeCurrentPatternObjectSetWeightLevel(float weightLevel) {
		_currentPatternSetRolling.ChangePatternObjectSetWeightLevel(weightLevel) ;
	}
	
	public void DestroyCurrentPatternObjects(int destroyType){
		_currentPatternSetRolling.DestroyCurrentPatternObjects(destroyType) ;
	}
	
	public bool CheckCurrentPatternSetRollingActiveState(){
		return _currentPatternSetRolling.IsPatternManagerActive ;
	}
	
	//--
	/*
	public void ChangePatternSetFromMainToFever() {
		
		if(currentGamePatternSetRollingMode == PatternSetRolling.GamePatternSetRollingMode.MAIN) {
			
			_currentPatternSetRolling.StopPatternManager(true, 1) ;
			
			_currentPatternSetRolling = _feverPatternSetRolling ;
			currentGamePatternSetRollingMode = _currentPatternSetRolling.currentGamePatternSetRollingMode ;
			
			StartCurrentPatternSetRolling(3f) ;
			
		}
		
	}
	
	public void ChangePatternSetFromFeverToMain() {
		
		if(currentGamePatternSetRollingMode == PatternSetRolling.GamePatternSetRollingMode.FEVER) {
			
			_currentPatternSetRolling.StopPatternManager(true, 0) ;
			
			_currentPatternSetRolling = _mainPatternSetRolling ;
			currentGamePatternSetRollingMode = _currentPatternSetRolling.currentGamePatternSetRollingMode ;
			
			StartCurrentPatternSetRolling(3f) ;
			
		}
		
	}
	*/
	
	 public void ChangePatternSetFromMainToFever() {
        
        ChangePatternSetFromMainToFever(0) ;
        
    }
    
    public void ChangePatternSetFromMainToFever(int type) {
        
        if(currentGamePatternSetRollingMode == PatternSetRolling.GamePatternSetRollingMode.MAIN) {
            
            _currentPatternSetRolling.StopPatternManager(true, type) ;
            
            _currentPatternSetRolling = _feverPatternSetRolling ;
            currentGamePatternSetRollingMode = _currentPatternSetRolling.currentGamePatternSetRollingMode ;
            
            //StartCurrentPatternSetRolling(3f) ;
            
        }
        
    }
    
    public void ChangePatternSetFromFeverToMain() {
        ChangePatternSetFromFeverToMain(0);
//        if(currentGamePatternSetRollingMode == PatternSetRolling.GamePatternSetRollingMode.FEVER) {
//            
//            _currentPatternSetRolling.StopPatternManager(true, 0) ;
//            
//            _currentPatternSetRolling = _mainPatternSetRolling ;
//            currentGamePatternSetRollingMode = _currentPatternSetRolling.currentGamePatternSetRollingMode ;
//            
//            StartCurrentPatternSetRolling(3f) ;
//            
//        }
        
    }
	
    public void ChangePatternSetFromFeverToMain(int type) {
        
        if(currentGamePatternSetRollingMode == PatternSetRolling.GamePatternSetRollingMode.FEVER) {
            
            _currentPatternSetRolling.StopPatternManager(true, type) ;
            
            _currentPatternSetRolling = _mainPatternSetRolling ;
            currentGamePatternSetRollingMode = _currentPatternSetRolling.currentGamePatternSetRollingMode ;
            
            //StartCurrentPatternSetRolling(3f) ;
            
        }
        
    }

	///// Create MeteorBulletObject Effect!!!!!
	public virtual void CreateMeteorBulletObject(Vector3 createPosition) {

		if(_currentPatternSetRolling.currentGamePatternSetRollingMode == PatternSetRolling.GamePatternSetRollingMode.MAIN){
			_currentPatternSetRolling.CreateMeteorBulletObject(createPosition) ;
		}

	}


	//--- Delegate
	void PatternSetStop(int state) {
//		Debug.Log("Pattern Manager Stop") ;
		
		if(state == 0){
			_patternManagerStageState(state) ;
		}else if(state == 100){
			_patternManagerStageState(state) ;
		}
		
		
		/* R100 Stage Controll
		if(state == 101) { // end of stage 1.
			_patternManagerStageState(100) ; // 100 : BOSS!!
		}else if(state == 102) { // end of stage 2.
			_patternManagerStageState(100) ; // 100 : BOSS!!
		}else if(state == 103) { // end of stage 3.
			_patternManagerStageState(100) ; // 100 : BOSS!!
		}
		*/
		
	}
	
	//---
	void PatternSetRollingStateDelegate(PatternSetRolling patternSetRolling, PatternObjectSet patternObjectSet, PatternObject patternObject, int state) {
		if(state >= 100 && state <= 200) {
			if(_patternManagerStateDelegate != null){
				_patternManagerStateDelegate(patternObject, state) ;	
			}
		}		
	}
	
}
