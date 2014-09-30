using UnityEngine;
using System.Collections;

public class ReadyGoAlertObject : MonoBehaviour {
	
	[HideInInspector]
	public delegate void ReadyGoAlertObjectDelegate();
	protected ReadyGoAlertObjectDelegate _readyGoAlertObjectDelegate ;
	public event ReadyGoAlertObjectDelegate ReadyGoAlertObjectEvent {
		add{
			_readyGoAlertObjectDelegate = null ;
			if (_readyGoAlertObjectDelegate == null) {
        		_readyGoAlertObjectDelegate += value;
			}
        }
		remove{
            _readyGoAlertObjectDelegate -= value;
		}
	}
	
	
	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ;
	protected Animation _thisAnimation ;
	public GameObject ThisGameObject {
        get { return _thisGameObject ; }
    }
	
	public Transform ThisTransform {
        get { return _thisTransform ; }
    }
	
	
	private void Awake(){
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_thisGameObject.SetActive(false) ;
		
	}
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	public void AnimationDone(){
		
		if(_readyGoAlertObjectDelegate != null){
			_readyGoAlertObjectDelegate() ;	
		}
		
		_thisGameObject.SetActive(false) ;
		
	}
	
	public void InitReadyGoAction() {
		_thisGameObject.SetActive(false) ;
	}
	
	public void StartReadyGoAction(){
		
		_thisGameObject.SetActive(true) ;


		//BJ Sound
		GameCharacter _characterInfo = Managers.UserData.GetCurrentGameCharacter() ;


		_thisGameObject.animation.Play("ReadyGoAlertObjectAni") ;
		
	}
	
	
}
