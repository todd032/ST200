using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class PatternSetRolling : MonoBehaviour {

	[HideInInspector]
	public delegate void PatternSetRollingDelegate(PatternSetRolling patternSetRolling, PatternObjectSet patternObjectSet, PatternObject patternObject, int state);
	protected PatternSetRollingDelegate _patternSetRollingStateDelegate ;
	public event PatternSetRollingDelegate PatternSetRollingStateDelegate {
		add{
			
			_patternSetRollingStateDelegate = null ;
			
			if (_patternSetRollingStateDelegate == null)
        		_patternSetRollingStateDelegate += value;
        }
		
		remove{
            _patternSetRollingStateDelegate -= value;
		}
	}
	
	
	[HideInInspector]
	public delegate void PatternSetStateDelegate(int state);
	protected PatternSetStateDelegate _patternSetStop ;
	public event PatternSetStateDelegate PatternSetStop {
		add{
			
			_patternSetStop = null ;
			
			if (_patternSetStop == null)
        		_patternSetStop += value;
        }
		
		remove{
            _patternSetStop -= value;
		}
	}

	
	// Public 
	public enum GamePatternSetRollingMode { NONE, MAIN, FEVER } ;
	public GamePatternSetRollingMode currentGamePatternSetRollingMode = GamePatternSetRollingMode.NONE ;
	
	// Public.
	public int numberOfPatternSet = 2 ;

	// Protected.
	protected Queue<PatternObjectSet> _patternObjectSetQueue ;
	protected PatternObjectSet _currentPatternObjectSet ;
	
	
	protected bool _isPatternManagerActive = true ;
	
	protected float _patternObjectSetMoveSpeed ;
	protected int _patternLevel ;
	protected float _weightLevel ;
	public bool IsPatternManagerActive {
		get { return _isPatternManagerActive ; }
	}
	
	public float PatternObjectSetMoveSpeed {
		set { _patternObjectSetMoveSpeed = value ; }
	}
	
	public int PatternLevel {
		set { _patternLevel = value ; }
	}
	
	public float WeightLevel {
		set { _weightLevel = value ; }
	}
	
	
	//-----
	protected virtual void Awake() {
		
		_patternObjectSetQueue = new Queue<PatternObjectSet>(numberOfPatternSet) ;
		
	}
	
	//-- *****
	//-- Special Init 
	public virtual void InitSettingPatternManager() {
		InitPatternObjectSet() ;
	}
	
	public virtual void InitStartPatternManager() {
		SetActivePatternManager(true) ;
		StartPatternObjectSet() ;
	}
	//-- *****
	
	
	//--
	public virtual void StartPatternManager(float delayTime) { // delayTime : 0 - Immediately Start
		
		StartCoroutine(StartDelayPatternManager(delayTime)) ;
		
	}
	
	public virtual void StopPatternManager(bool immediatelyStop, int destroyType) { // destroyType :  0- 
		
		SetActivePatternManager(false) ;
		
		if(immediatelyStop){
			StoptPatternObjectSet() ;
			DestroyCurrentPatternObjects(destroyType) ;
			ClearPatternObejctSet() ;
		}
		
	}
	
	public virtual void PausePatternManager() {
		PausePatternObjectSet() ;
	}
	
	public virtual void ResumePatternManager() {
		ResumePatternObjectSet() ;
	}
	
	
	private IEnumerator StartDelayPatternManager(float delayTime) {
		
		InitPatternObjectSet() ;
		
		yield return new WaitForSeconds(delayTime);
		
		SetActivePatternManager(true) ;
		StartPatternObjectSet() ;
		
	}
	
	
	//--
	protected virtual void SetActivePatternManager(bool isActive) {
		_isPatternManagerActive = isActive ;	
	}
	
	//--
	protected virtual void StartPatternObjectSet() {
		if(_currentPatternObjectSet != null) {
			_currentPatternObjectSet.MovePatternSet(true,1) ; // State : 1 - Play   2 - Stop  3 - Pause  4 - Resume
		}
	}
	
	protected virtual void StoptPatternObjectSet() {
		if(_currentPatternObjectSet != null) {
			_currentPatternObjectSet.MovePatternSet(false,2) ; // State : 1 - Play   2 - Stop  3 - Pause  4 - Resume
		}
	}
	
	protected virtual void PausePatternObjectSet() {
		if(_currentPatternObjectSet != null) {
			_currentPatternObjectSet.MovePatternSet(false,3) ; // State : 1 - Play   2 - Stop  3 - Pause  4 - Resume
			_currentPatternObjectSet.PatternSetMoveSpeed = 0f ;
		}
	}
	
	protected virtual void ResumePatternObjectSet() {
		if(_currentPatternObjectSet != null) {
			_currentPatternObjectSet.PatternSetMoveSpeed = _patternObjectSetMoveSpeed ;
			_currentPatternObjectSet.MovePatternSet(true,4) ; // State : 1 - Play   2 - Stop  3 - Pause  4 - Resume
		}
	}
	
	
	//--
	public virtual void ChangePatternObjectSetMoveSpeed(float moveSpeed) {
		
		_patternObjectSetMoveSpeed = moveSpeed ;
		
		if(_currentPatternObjectSet != null) {
			_currentPatternObjectSet.PatternSetMoveSpeed = _patternObjectSetMoveSpeed ;
		}
		
	}
	
	public virtual void ChangePatternObjectSetPatternLevel(int patternLevel) {
		_patternLevel = patternLevel ;
	}
	
	public virtual void ChangePatternObjectSetWeightLevel(float weightLevel) {
		_weightLevel = weightLevel ;
	}
	
	//--
	public virtual void DestroyCurrentPatternObjects(int destroyType) {
	
		if(_currentPatternObjectSet != null) {
			_currentPatternObjectSet.DestroyPatternObjects(destroyType) ;
		}
		
	}
	
	
	//--
	protected virtual void InitPatternObjectSet() {
		
		for(int i = 0 ; i < numberOfPatternSet ; i++) {
			PatternObjectSet _po = CreatePatternSet() ;
			//_po.ResetPatternObjects(_patternObjectSetMoveSpeed, _patternLevel) ;
			_po.ResetPatternObjects(_patternObjectSetMoveSpeed, _patternLevel, _weightLevel) ;
			_patternObjectSetQueue.Enqueue(_po) ;
		}
		_currentPatternObjectSet = _patternObjectSetQueue.Peek() as PatternObjectSet ;
		_currentPatternObjectSet.PatternSetMoveSpeed = _patternObjectSetMoveSpeed ;
		
	}
	
	protected virtual void ClearPatternObejctSet() {

		int queueCount = _patternObjectSetQueue.Count ;
		for(int i = 0 ; i < queueCount ; i++) {
			PatternObjectSet dequeuePo = _patternObjectSetQueue.Dequeue() ;
			dequeuePo.MovePatternSet(false,2);
			if(dequeuePo != null) {
				PoolManager.Despawn(dequeuePo.ThisGameObject) ;
			}
		}
		
		_patternObjectSetQueue.Clear() ;
		_currentPatternObjectSet = null ;
		
	}
	

	///// Create MeteorBulletObject Effect!!!!!
	public virtual void CreateMeteorBulletObject(Vector3 createPosition) {
		//Overrid...
	}

	//--
	protected virtual PatternObjectSet CreatePatternSet() {
		return null ;
	}

	/// <summary>
	/// PatternObjectSet의 4개의 대리자를 등록.
	/// </summary>
	protected virtual PatternObjectSet PatternObjectSetConnectDelegate(GameObject _go) {
		
		if(_go == null) return null ;
		
		PatternObjectSet _pos = _go.GetComponent<PatternObjectSet>() as PatternObjectSet ;
		
		
		if(_pos == null) return null ;
		
		_pos.PatternSetMoveScreenOut += PatternSetMoveScreenOut ;
		_pos.PatternSetMoveScreenEnd += PatternSetMoveScreenEnd ;
		_pos.PatternSetMoveScreenStart += PatternSetMoveScreenStart ;
		_pos.PatternSetMoveScreenDestination += PatternSetMoveScreenDestination ;
		
		_pos.PatternObjectSetStateDelegate += PatternObjectSetStateDelegate ;
		
		
		return _pos ;
		
	}
	
	//****************************
	//--- Event Process Part.
	protected virtual void PatternSetMoveScreenOut(PatternObjectSet _pos) {
		if(!_pos.Equals(_currentPatternObjectSet)) {
			return ;
		}
	}
	
	protected virtual void PatternSetMoveScreenEnd(PatternObjectSet _pos) {
		if(!_pos.Equals(_currentPatternObjectSet)) {
			return ;
		}
	}
	
	protected virtual void PatternSetMoveScreenStart(PatternObjectSet _pos) {
		if(!_pos.Equals(_currentPatternObjectSet)) {
			return ;
		}
	}
	
	protected virtual void PatternSetMoveScreenDestination(PatternObjectSet _pos) {
		if(!_pos.Equals(_currentPatternObjectSet)) {
			return ;
		}
	}
	
	protected virtual void PatternObjectSetStateDelegate(PatternObjectSet _pos, PatternObject _po, int state) {
		if(state >= 100 && state <= 200) {
			if(_patternSetRollingStateDelegate != null){
				_patternSetRollingStateDelegate(this, _pos, _po, state) ;
			}
			return ;
		}
	}
	
	//--- Event Process Part End.
	//****************************
}
