using UnityEngine;
using System.Collections;

public class TutorialChildView : MonoBehaviour {

	[HideInInspector]
	public delegate void TutorialChildViewDelegate(int whereTutorialNumber, int state);
	protected TutorialChildViewDelegate _tutorialChildViewDelegate ;
	public event TutorialChildViewDelegate TutorialChildViewEvent {
		add{
			
			_tutorialChildViewDelegate = null ;
			
			if (_tutorialChildViewDelegate == null)
        		_tutorialChildViewDelegate += value;
        }
		
		remove{
            _tutorialChildViewDelegate -= value;
		}
	}
	
	
	public UISprite _tutorialIntroducerCharacterSprite ;
	
	public UISprite _tutorialMessageBalloonSprite ;
	public UILabel _tutorialMessageBalloonTitleLabel ;
	public UILabel _tutorialMessageBalloonContentsLabel ;
	
	public UISprite _tutorialTouchSprite ;
	
	protected virtual void Awake(){
		
	}
	
	protected virtual void Start() {
		
	}
	
	public virtual void InitLoadTutorialChildView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public virtual void LoadTutorialChildView() {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetSetTutorialChildView() ;
		
	}
	
	public virtual void RemoveTutorialChildView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	protected virtual void SetSetTutorialChildView(){
		//Override.....
	}
	
}
