using UnityEngine;
using System.Collections;

public class ShopSceneTutorialView : MonoBehaviour {

	[HideInInspector]
	public delegate void ShopSceneTutorialViewDelegate(ShopSceneTutorialView shopSceneTutorialView, int state);
	protected ShopSceneTutorialViewDelegate _shopSceneTutorialViewDelegate ;
	public event ShopSceneTutorialViewDelegate ShopSceneTutorialViewEvent {
		add{
			
			_shopSceneTutorialViewDelegate = null ;
			
			if (_shopSceneTutorialViewDelegate == null)
        		_shopSceneTutorialViewDelegate += value;
        }
		
		remove{
            _shopSceneTutorialViewDelegate -= value;
		}
	}
	
	public UIButtonMessage _tutorialNextButtonMessage ;
	
	
	public TutorialChildView _shopSceneTutorial1 ;
	public TutorialChildView _shopSceneTutorial2 ;
	public TutorialChildView _shopSceneTutorial3 ;
	public TutorialChildView _shopSceneTutorial4 ;
	
	
	private int _tutorialIndexNubmer = 1 ;
	private bool _isNextTutorialAble = false ;
	
	private void Awake(){
		
		_tutorialNextButtonMessage.enabled = false ;
		
		_shopSceneTutorial1.TutorialChildViewEvent += TutorialChildViewDelegate ;
		_shopSceneTutorial2.TutorialChildViewEvent += TutorialChildViewDelegate ;
		_shopSceneTutorial3.TutorialChildViewEvent += TutorialChildViewDelegate ;
		_shopSceneTutorial4.TutorialChildViewEvent += TutorialChildViewDelegate ;
		
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
		
		_shopSceneTutorial1.InitLoadTutorialChildView() ;
		_shopSceneTutorial2.InitLoadTutorialChildView() ;
		_shopSceneTutorial3.InitLoadTutorialChildView() ;
		_shopSceneTutorial4.InitLoadTutorialChildView() ;
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
			_shopSceneTutorial1.LoadTutorialChildView() ;
		}else if(tutorialIndexNubmer == 2){
			_isNextTutorialAble = false ;
			_shopSceneTutorial2.LoadTutorialChildView() ;
		}else if(tutorialIndexNubmer == 3){
			_isNextTutorialAble = false ;
			_shopSceneTutorial3.LoadTutorialChildView() ;	
		}else if(tutorialIndexNubmer == 4){
			_isNextTutorialAble = false ;
			_shopSceneTutorial4.LoadTutorialChildView() ;	
		}
		
	}
	
	
	private void OnClickTutorialViewNextButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_isNextTutorialAble){
			
			_tutorialIndexNubmer++ ;
			
			if(_tutorialIndexNubmer >= 5){
				_tutorialIndexNubmer = 5 ;	
			}
			
			if(_tutorialIndexNubmer == 1){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 2){
				_shopSceneTutorial1.RemoveTutorialChildView() ;
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 3){
				_shopSceneTutorial2.RemoveTutorialChildView() ;
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 4){
				_shopSceneTutorial3.RemoveTutorialChildView() ;
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;
			}else if(_tutorialIndexNubmer == 5){
				Application.LoadLevel("GameMainLoadingScene");
			}
			
		}else{
			
			if(_tutorialIndexNubmer == 1){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 2){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 3){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}else if(_tutorialIndexNubmer == 4){
				SetShopSceneTutorialView(_tutorialIndexNubmer) ;	
			}
			
		}
		
	}
	
}
