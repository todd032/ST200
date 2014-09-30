using UnityEngine;
using System.Collections;

public class GamePlaySceneTutorialView : MonoBehaviour {

	[HideInInspector]
	public delegate void GamePlaySceneTutorialViewDelegate(GamePlaySceneTutorialView gamePlaySceneTutorialView, int state);
	protected GamePlaySceneTutorialViewDelegate _gamePlaySceneTutorialViewDelegate ;
	public event GamePlaySceneTutorialViewDelegate GamePlaySceneTutorialViewEvent {
		add{
			
			_gamePlaySceneTutorialViewDelegate = null ;
			
			if (_gamePlaySceneTutorialViewDelegate == null)
        		_gamePlaySceneTutorialViewDelegate += value;
        }
		
		remove{
            _gamePlaySceneTutorialViewDelegate -= value;
		}
	}
	
	public UIButtonMessage _tutorialNextButtonMessage ;
	
	
	public TutorialChildView _gamePlaySceneTutorial1 ;
	public TutorialChildView _gamePlaySceneTutorial2 ;
	public TutorialChildView _gamePlaySceneTutorial3 ;
	
	
	private int _tutorialIndexNubmer = 1 ;
	private bool _isNextTutorialAble = false ;
	
	private void Awake(){
		
		_tutorialNextButtonMessage.enabled = false ;
		
		_gamePlaySceneTutorial1.TutorialChildViewEvent += TutorialChildViewDelegate ;
		_gamePlaySceneTutorial2.TutorialChildViewEvent += TutorialChildViewDelegate ;
		_gamePlaySceneTutorial3.TutorialChildViewEvent += TutorialChildViewDelegate ;
		
	}
	
	private void Start() {
	}
	
	
	//---- Delegate
	private void TutorialChildViewDelegate(int whereTutorialNumber, int state) {
		if(whereTutorialNumber == 1){ //State 1:false , 2:true , 3:Tutorial Done..
			if(state == 1){ 
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = false ;
			}else if(state == 2){
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = true ;
			}else if(state == 3){
				_isNextTutorialAble = true ;
				_tutorialNextButtonMessage.enabled = true ;
			}
		}else if(whereTutorialNumber == 2){
			if(state == 1){ 
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = false ;
			}else if(state == 2){
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = true ;
			}else if(state == 3){
				_isNextTutorialAble = true ;
				_tutorialNextButtonMessage.enabled = true ;
			}
		}else if(whereTutorialNumber == 3){
			if(state == 1){ 
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = false ;
			}else if(state == 2){
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = true ;
			}else if(state == 3){
				_isNextTutorialAble = true ;
				_tutorialNextButtonMessage.enabled = true ;
			}
		}else if(whereTutorialNumber == 4){
			if(state == 1){ 
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = false ;
			}else if(state == 2){
				_isNextTutorialAble = false ;
				_tutorialNextButtonMessage.enabled = true ;
			}else if(state == 3){
				_isNextTutorialAble = true ;
				_tutorialNextButtonMessage.enabled = true ;
			}
		}
		
	}
	
	
	
	public void InitLoadShopSceneTutorialView(){
		
		NGUITools.SetActive(gameObject, false) ;
		
		_gamePlaySceneTutorial1.InitLoadTutorialChildView() ;
		_gamePlaySceneTutorial2.InitLoadTutorialChildView() ;
		_gamePlaySceneTutorial3.InitLoadTutorialChildView() ;
	}
	
	public void LoadShopSceneTutorialView() {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetShopSceneTutorialView(_tutorialIndexNubmer) ;
		
	}
	
	public void RemoveShopSceneTutorialView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetShopSceneTutorialView(int tutorialIndexNubmer){
		
		if(tutorialIndexNubmer == 1){
			_isNextTutorialAble = false ;
			_gamePlaySceneTutorial1.LoadTutorialChildView() ;
		}else if(tutorialIndexNubmer == 2){
			_isNextTutorialAble = false ;
			_gamePlaySceneTutorial2.LoadTutorialChildView() ;
		}else if(tutorialIndexNubmer == 3){
			_isNextTutorialAble = false ;
			_gamePlaySceneTutorial3.LoadTutorialChildView() ;	
		}
		
	}
	
	
	private void OnClickTutorialViewNextButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_isNextTutorialAble){
			
			_tutorialIndexNubmer++ ;
			
			if(_tutorialIndexNubmer >= 4){
				_tutorialIndexNubmer = 4 ;	
			}
			
			if(_tutorialIndexNubmer == 1){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 2){
				_gamePlaySceneTutorial1.RemoveTutorialChildView() ;
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 3){
				_gamePlaySceneTutorial2.RemoveTutorialChildView() ;
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 4){
				_gamePlaySceneTutorial3.RemoveTutorialChildView() ;
				
				if(_gamePlaySceneTutorialViewDelegate != null){
					_gamePlaySceneTutorialViewDelegate(this,1) ;	
				}
				
			}
			
		}else{
			
			if(_tutorialIndexNubmer == 1){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 2){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 3){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}
			
		}
		
	}
	
}
