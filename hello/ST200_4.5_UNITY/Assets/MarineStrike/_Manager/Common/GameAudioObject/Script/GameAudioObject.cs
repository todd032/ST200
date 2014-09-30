using UnityEngine;
using System.Collections;

public class GameAudioObject : MonoBehaviour {
	
	[HideInInspector]
	public delegate void GameAudioObjectDelegate(GameAudioObject gameAudioObject, int state);
	protected GameAudioObjectDelegate _gameAudioObjectDelegate ;
	public event GameAudioObjectDelegate GameAudioObjectEvent {
		add{
			
			_gameAudioObjectDelegate = null ;
			
			if (_gameAudioObjectDelegate == null)
        		_gameAudioObjectDelegate += value;
        }
		
		remove{
            _gameAudioObjectDelegate -= value;
		}
	}
	
	
	private GameObject _thisGameObject ;
	private AudioSource _audioSource ;
	
	private int _audioClipIndex ;
	public int AudioClipIndex {
		get { return _audioClipIndex ; }
	}
	
	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		
		//_audioSource = GetComponent<AudioSource>() as AudioSource ;
		_audioSource = audio ;
		
	}
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
		if(!_audioSource.isPlaying){
			
			_thisGameObject.SetActive(false) ;
			
			if(_gameAudioObjectDelegate != null){
				_gameAudioObjectDelegate(this,0) ;	
			}
		}
		
	}
	
	public void InitSetGameAudioObject(){
		_thisGameObject.SetActive(false) ;
	}
	
	
	public void SetGameAudioObject(int audioClipIndex,  AudioClip audioClip, float soundVolume, bool isLoop) {
		
		if(!_thisGameObject.activeSelf){
			_thisGameObject.SetActive(true) ;
		}else{
			return ;
		}
		
		//if(!_audioSource.isPlaying){
			
			_audioClipIndex = audioClipIndex ;
		
			_audioSource.clip = audioClip ;
			_audioSource.loop = isLoop ;
			_audioSource.volume = soundVolume ;
			_audioSource.Play() ;
			
		//}
		
	}
	
	public void SetOnlyOneGameAudioObject(int audioClipIndex,  AudioClip audioClip, float soundVolume, bool isLoop) {
		
		if(!_thisGameObject.activeSelf){
			
			_thisGameObject.SetActive(true) ;
			
			_audioClipIndex = audioClipIndex ;
		
			_audioSource.clip = audioClip ;
			_audioSource.loop = isLoop ;
			_audioSource.volume = soundVolume ;
			_audioSource.Play() ;
			
		}else{
			
			if(_audioSource.isPlaying){
				_audioSource.time = 0f ;	
			}else{
				_audioClipIndex = audioClipIndex ;
		
				_audioSource.clip = audioClip ;
				_audioSource.loop = isLoop ;
				_audioSource.volume = soundVolume ;
				_audioSource.Play() ;
			}
			
		}
		
	}
	
	public void StopGameAudioObject(){ 
		_audioSource.Stop();
	}
	
	public void PauseGameAudioObject()	{
		if(!_audioSource.isPlaying){
			_audioSource.Pause();	
		}
	}
	
	public void ResumeGameAudioObject(){ 
		if(!_audioSource.isPlaying){
			_audioSource.Play();	
		}
	}
	
	public void ChangeGameAudioObjectVolume(float soundVolume) {
		if(_audioSource.isPlaying){
			_audioSource.volume = soundVolume ;	
		}
	}
	
	public bool CheckGameAudioObjectActive(){
		return _thisGameObject.activeSelf ;
	}
	
}
