using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class AudioManager : MonoBehaviour
{
	
	//BGM 타입. 
	public enum BGM_SOUND{
		BGM_Title,
		BGM_Main,
		BGM_GAMEPLAY1,
		BGM_GAMEPLAY2,
		BGM_Intro
	}

	//FX 타입. 
	public enum FX_SOUND{
		FX_Button_Common,
		FX_Button_GameReady,
		FX_Button_GameStart,
		FX_Button_Purchase,
		FX_Etc_Gain,
		FX_Etc_Alert,
		FX_Item_Select,
		FX_Submarine_Select,
		
		FX_Submarine_Damaged,
		FX_Submarine_Dead,
		FX_Submarine_Item_Booster,
		FX_Submarine_Item_DoubleScore,
		FX_Submarine_Item_Magnet,
		FX_Submarine_Item_PowerShot,
		FX_Use_Item_Brake,
		FX_Use_Item_EMP,
		FX_Gain_Gold,
		FX_Gain_Item,
		FX_Enemy_Damaged,
		FX_Enemy_Dead,
		FX_Boss_Alert,
		FX_Boss_PartsBroken,
		FX_Boss_Dead,
		FX_Boss_LaserReady,
		FX_Boss_Laser,
		FX_Boss_Missile,

		FX_Energy_Heal,
		FX_Explosion,
		FX_Laser,

		FX_LuckyPresent_Open,
		FX_Boss_Dragon,

		FX_BULLET_SHOOT_PLAYER,
		FX_BULLET_SHOOT_ENEMY,
		FX_BULLET_HIT_SOUND,

		FX_ARROW_SHOOT,
		FX_ARROW_HIT,

		FX_START_GAME,

		FX_BULLET_SHOOT_GUN,
	}


	private Transform _thisTransform ;
	
	public Transform _gameAudioObject ;
	public int _numberOfGameAudioObject ;
	
	private List<GameAudioObject> _gameAudioObjectList ;
	

	private void Awake(){
	
		_thisTransform = transform ;
		
		_gameAudioObjectList = new List<GameAudioObject>() ;
		
		for(int i = 0 ; i < _numberOfGameAudioObject ; i++) {
			
			Transform _goTransform = Instantiate(_gameAudioObject) as Transform;
			_goTransform.parent = _thisTransform;
			
			GameAudioObject _gameAudioObjectComponent = _goTransform.GetComponent<GameAudioObject>() as GameAudioObject;
			_gameAudioObjectComponent.GameAudioObjectEvent += GameAudioObjectDelegate ;
			_gameAudioObjectComponent.InitSetGameAudioObject() ;
			
			_gameAudioObjectList.Add(_gameAudioObjectComponent) ;
			
		}
		
	}
	
	private void Start(){
		
	}
	
	
	//--Delegate
	private void GameAudioObjectDelegate(GameAudioObject gameAudioObject, int state) {
		
		
	}
	
	
	
	//BGM 사운드로 사용할 리스트 인스펙터 창에서 등록.
	public AudioClip[] _bgmClipList;	
	public AudioSource _bgmSource; 
	
	public void PlayBGMSound( BGM_SOUND soundType, bool isLoop )	{ 
		
		if(_bgmSource.clip != _bgmClipList[(int)soundType]){
		//if(!_bgmSource.clip.Equals(_bgmClipList[(int)soundType])){
			
			float bgmSoundVolume = 1f ;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					bgmSoundVolume = 0f;
				}
			}
			
			_bgmSource.clip = _bgmClipList[(int)soundType];
			_bgmSource.volume = bgmSoundVolume ;
			_bgmSource.loop = isLoop;
			_bgmSource.Play();
		}
		
	}
	
	public void StopBGMSound(){ 
		_bgmSource.Stop();
		_bgmSource.clip = null ;
	}
	
	public void PauseBGMSound()	{ 
		if(!_bgmSource.isPlaying){
			_bgmSource.Pause();	
		}
	}
	
	public void ResumeBGMSound(){ 
		if(!_bgmSource.isPlaying){
			_bgmSource.Play();	
		}
	}
	
	public void ChangeBGMSoundVolume() {
		if(_bgmSource.isPlaying){
			
			float bgmSoundVolume = 1f ;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					bgmSoundVolume = 0f;
				}
			}
			
			_bgmSource.volume = bgmSoundVolume ;	
			
		}
	}
	
	
	//---------------------------------------------
	//FX 사운드로 사용할 리스트 인스펙터 창에서 등록.
	public AudioClip[] _fxClipList;

	public GameAudioObject PlayFXSound( FX_SOUND soundType, bool isLoop )	{ 
		
		GameAudioObject searchGameAudioObject = null ;
		
		foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
			if(!gameAudioObject.CheckGameAudioObjectActive()){
				searchGameAudioObject = gameAudioObject ;
				break ;
			}
			
		}
		
		if(searchGameAudioObject == null){
			Transform _goTransform = Instantiate(_gameAudioObject) as Transform;
			_goTransform.parent = _thisTransform;
			
			GameAudioObject _gameAudioObjectComponent = _goTransform.GetComponent<GameAudioObject>() as GameAudioObject;
			_gameAudioObjectComponent.GameAudioObjectEvent += GameAudioObjectDelegate ;
			_gameAudioObjectComponent.InitSetGameAudioObject() ;
			
			_gameAudioObjectList.Add(_gameAudioObjectComponent) ;
			
			searchGameAudioObject = _gameAudioObjectComponent ;
		}
		
		
		if(searchGameAudioObject != null){
			
			float fxSoundVolume = 1f ;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					fxSoundVolume = 0f;
				}
			}
			
			searchGameAudioObject.SetGameAudioObject((int)soundType, _fxClipList[(int)soundType], fxSoundVolume, isLoop) ;
			
		}
		
		return searchGameAudioObject ;
		
	}

	public GameAudioObject PlayFXSound( FX_SOUND soundType, bool isLoop, float _soundratio )	{ 
		
		GameAudioObject searchGameAudioObject = null ;
		
		foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
			if(!gameAudioObject.CheckGameAudioObjectActive()){
				searchGameAudioObject = gameAudioObject ;
				break ;
			}
			
		}
		
		if(searchGameAudioObject == null){
			Transform _goTransform = Instantiate(_gameAudioObject) as Transform;
			_goTransform.parent = _thisTransform;
			
			GameAudioObject _gameAudioObjectComponent = _goTransform.GetComponent<GameAudioObject>() as GameAudioObject;
			_gameAudioObjectComponent.GameAudioObjectEvent += GameAudioObjectDelegate ;
			_gameAudioObjectComponent.InitSetGameAudioObject() ;
			
			_gameAudioObjectList.Add(_gameAudioObjectComponent) ;
			
			searchGameAudioObject = _gameAudioObjectComponent ;
		}
		
		
		if(searchGameAudioObject != null){
			
			float fxSoundVolume = 1f ;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					fxSoundVolume = 0f;
				}
			}
			fxSoundVolume *= _soundratio;
			searchGameAudioObject.SetGameAudioObject((int)soundType, _fxClipList[(int)soundType], fxSoundVolume, isLoop) ;
			
		}
		
		return searchGameAudioObject ;
		
	}
	
	
	public GameAudioObject PlayOnlyOneFXSound( FX_SOUND soundType, bool isLoop )	{ 
		
		GameAudioObject searchGameAudioObject = null ;
		
		foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
			if(gameAudioObject.CheckGameAudioObjectActive() && (gameAudioObject.AudioClipIndex == (int)soundType)){
				searchGameAudioObject = gameAudioObject ;
				break ;
			}
		}
		
		
		if(searchGameAudioObject == null){
			
			foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
				if(!gameAudioObject.CheckGameAudioObjectActive()){
					searchGameAudioObject = gameAudioObject ;
					break ;
				}
			}
		
			if(searchGameAudioObject == null){
				Transform _goTransform = Instantiate(_gameAudioObject) as Transform;
				_goTransform.parent = _thisTransform;
			
				GameAudioObject _gameAudioObjectComponent = _goTransform.GetComponent<GameAudioObject>() as GameAudioObject;
				_gameAudioObjectComponent.GameAudioObjectEvent += GameAudioObjectDelegate ;
				_gameAudioObjectComponent.InitSetGameAudioObject() ;
			
				_gameAudioObjectList.Add(_gameAudioObjectComponent) ;
			
				searchGameAudioObject = _gameAudioObjectComponent ;
			}
			
		}
		
		if(searchGameAudioObject != null){
			
			float fxSoundVolume = 1f ;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					fxSoundVolume = 0f;
				}
			}
			
			searchGameAudioObject.SetOnlyOneGameAudioObject((int)soundType, _fxClipList[(int)soundType], fxSoundVolume, isLoop) ;
			
		}
		
		return searchGameAudioObject ;
		
	}

	public GameAudioObject PlayMultiFXSound( FX_SOUND soundType, bool isLoop, int _maxnumb )	{ 

		List<GameAudioObject> playingList = new List<GameAudioObject>();
		GameAudioObject searchGameAudioObject = null ;
		
		foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
			if(gameAudioObject.CheckGameAudioObjectActive() && (gameAudioObject.AudioClipIndex == (int)soundType)){
				//searchGameAudioObject = gameAudioObject ;
				//break ;
				playingList.Add(gameAudioObject);
			}
		}
		

		if(playingList.Count < _maxnumb)
		//if(searchGameAudioObject == null)
		{
			
			foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
				if(!gameAudioObject.CheckGameAudioObjectActive()){
					searchGameAudioObject = gameAudioObject ;
					break ;
				}
			}
			
			if(searchGameAudioObject == null){
				Transform _goTransform = Instantiate(_gameAudioObject) as Transform;
				_goTransform.parent = _thisTransform;
				
				GameAudioObject _gameAudioObjectComponent = _goTransform.GetComponent<GameAudioObject>() as GameAudioObject;
				_gameAudioObjectComponent.GameAudioObjectEvent += GameAudioObjectDelegate ;
				_gameAudioObjectComponent.InitSetGameAudioObject() ;
				
				_gameAudioObjectList.Add(_gameAudioObjectComponent) ;
				
				searchGameAudioObject = _gameAudioObjectComponent ;
			}
			playingList.Add(searchGameAudioObject);
		}

		if(playingList.Count >= _maxnumb)
		//if(searchGameAudioObject != null)
		{
			
			float fxSoundVolume = 1f;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					fxSoundVolume = 0f;
				}

			}
			fxSoundVolume = fxSoundVolume / Mathf.Sqrt(playingList.Count);

			GameAudioObject oldestsound = playingList[0];
			for(int i = 1; i < playingList.Count; i++)
			{
				if(oldestsound.audio.time < playingList[i].audio.time)
				{
					oldestsound = playingList[i];
				}
			}
			oldestsound.SetOnlyOneGameAudioObject((int)soundType, _fxClipList[(int)soundType], fxSoundVolume, isLoop) ;
			searchGameAudioObject = oldestsound;
		}else
		{
			float fxSoundVolume = 1f;
			if(Managers.UserData != null){
				if(!Managers.UserData.SoundFlag)
				{
					fxSoundVolume = 0f;
				}
			}
			fxSoundVolume = fxSoundVolume / Mathf.Sqrt(playingList.Count);

			searchGameAudioObject.SetOnlyOneGameAudioObject((int)soundType, _fxClipList[(int)soundType], fxSoundVolume, isLoop) ;
		}
		
		return searchGameAudioObject ;
		
	}
	
	public void PlayAllFXSoundStop(){
		
		foreach(GameAudioObject gameAudioObject in _gameAudioObjectList) {
			if(gameAudioObject.CheckGameAudioObjectActive()){
				gameAudioObject.StopGameAudioObject() ;
			}
		}
		
	}
	
}

