using UnityEngine;
using System.Collections;

public class DHDistanceManager : MonoBehaviour {
	
	[HideInInspector]
	public delegate void DistanceManagerDelegate(DHDistanceManager distanceManager, int currentDistance, DistanceManagerState distanceManagerState);
	protected DistanceManagerDelegate _distanceManagerDelegate ;
	public event DistanceManagerDelegate DistanceManagerEvnet {
		add{
			_distanceManagerDelegate = null ;
			
			if (_distanceManagerDelegate == null)
        		_distanceManagerDelegate += value;
        }
		
		remove{
            _distanceManagerDelegate -= value;
		}
	}
	
	
	public enum	DistanceManagerState { Idle, GamePlay} ;
	private DistanceManagerState _distanceManagerState ;
	//private DistanceManagerState _distanceManagerState = DistanceManagerState.Idle ;
	
	// public
	public float speedWeight = 1f ;

	private string _speedWeight ;
	private float SpeedWeight {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_speedWeight = encryptString ;
		}
		get {
			if(_speedWeight == null || _speedWeight.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_speedWeight,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}


	// private
	private string _currentDistance ;
	private int CurrentDistance {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_currentDistance = encryptString ;
		}
		get {
			if(_currentDistance == null || _currentDistance.Equals("")){
				return 0 ;	
			}
			string decryptString = LoadingWindows.NextD(_currentDistance,Constant.DefalutAppName) ;
			int decryptInt = int.Parse(decryptString) ;
			return decryptInt;
		}
	}
	
	private string _currentDistanceFull ;
	private float CurrentDistanceFull {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_currentDistanceFull = encryptString ;
		}
		get {
			if(_currentDistanceFull == null || _currentDistanceFull.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_currentDistanceFull,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}

	private string _gameSpeed ;
	private float GameSpeed {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_gameSpeed = encryptString ;
		}
		get {
			if(_gameSpeed == null || _gameSpeed.Equals("")){
				return 0f ;	
			}
			string decryptString = LoadingWindows.NextD(_gameSpeed,Constant.DefalutAppName) ;
			float decryptFloat = float.Parse(decryptString) ;
			return decryptFloat;
		}
	}
	


	private void Awake() {
		
	}

	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	
	public void InitializationDistanceManager(float gameSpeed) {

		SpeedWeight = speedWeight ;
		//SpeedWeight = 2f ;

		CurrentDistance = 0 ;
		CurrentDistanceFull = 0f;
		GameSpeed = gameSpeed ;
		
		_distanceManagerState = DistanceManagerState.Idle ;
		StartCoroutine(_distanceManagerState.ToString());
		
	}
	
	//--
	public void StartDistanceManager() {
		_distanceManagerState = DistanceManagerState.GamePlay ;
	}
	
	
	public void StopDistanceManager() {
		_distanceManagerState = DistanceManagerState.Idle ;
	}
	
	
	public void PauseDistanceManager() {
		_distanceManagerState = DistanceManagerState.Idle ;
	}
	
	public void ResumeDistanceManager() {
		_distanceManagerState = DistanceManagerState.GamePlay ;
	}
	
	
	//--
	public void RestartDistanceManager(float gameSpeed) {
		StopAllCoroutines() ;
		
		InitializationDistanceManager(gameSpeed) ;
	}
	
	public void GameOverDistanceManager(){
		_distanceManagerState = DistanceManagerState.Idle ;
	}
	
	
	//--
	public void ChangeSpeedDistanceManager(float gameSpeed) {
		GameSpeed = gameSpeed ;
	}
	
	
	
	//// FSM
	//------------------------------------
	IEnumerator Idle() {
		
  		yield return null ;
		
		while(_distanceManagerState == DistanceManagerState.Idle) {  
			
			yield return null ;   
		}
   
		StartCoroutine(_distanceManagerState.ToString()) ;

	}
	
	
	IEnumerator GamePlay() {

		yield return null ;

		while(_distanceManagerState == DistanceManagerState.GamePlay) {  

			if(GameSpeed > 0f) {
				
				CurrentDistanceFull += Time.deltaTime * GameSpeed * SpeedWeight ;

				int calculationDistance = Mathf.FloorToInt(CurrentDistanceFull) ;
			
				if(CurrentDistance < calculationDistance){
				
					CurrentDistance = calculationDistance ;
					
					if (_distanceManagerDelegate != null ) {
						_distanceManagerDelegate(this, CurrentDistance, _distanceManagerState);
					}
				}
				
			}
			
			yield return null ;
		}
	  
		StartCoroutine(_distanceManagerState.ToString()) ;
		
	}
	
}
