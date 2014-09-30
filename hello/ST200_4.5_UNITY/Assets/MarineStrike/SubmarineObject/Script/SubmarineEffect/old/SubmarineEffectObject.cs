using UnityEngine;
using System.Collections;

public class SubmarineEffectObject : MonoBehaviour {
	
	protected GameObject _thisGameObject ;
	protected Transform _thisTransform ;
	
	public GameObject ThisGameObject 
	{
        get { return _thisGameObject ; }
    }
	
	public Transform ThisTransform
    {
        get { return _thisTransform ; }
    }
	
	protected virtual void Awake() {
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
	}
	
	// Use this for initialization
	protected virtual void Start () {
	}
	
	protected virtual void Update () {
	}
	
	
	public virtual void InitializeEffectObject() {
		if(_thisGameObject.activeSelf){
			_thisGameObject.SetActive(false) ;	
		}
	}
	
	public virtual void InitializeEffectObject(Vector3 createPosition) {
		if(_thisGameObject.activeSelf){
			_thisGameObject.SetActive(false) ;	
		}
		_thisTransform.position = createPosition ;
	}
	
	public virtual void StartEffectObject(){
		if(!_thisGameObject.activeSelf){
			_thisGameObject.SetActive(true) ;	
		}
		EffectPlay() ;
	}
	
	//--
	public virtual void StopEffectObject() {
		EffectStop() ;
		
		if(_thisGameObject.activeSelf){
			_thisGameObject.SetActive(false) ;	
		}
		
	}
	
	//--
	public virtual void EffectPlay(){
	}
	
	public virtual void EffectStop(){
	}
	
	public virtual void EffectResume(){
	}
	
	public virtual void EffectPause(){
	}
	
	
	protected virtual bool IsActiveEffectObject() {
		return _thisGameObject.activeSelf ;
	}
	
}
