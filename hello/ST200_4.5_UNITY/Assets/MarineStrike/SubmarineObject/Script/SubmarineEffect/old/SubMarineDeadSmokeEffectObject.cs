using UnityEngine;
using System.Collections;

public class SubMarineDeadSmokeEffectObject : MonoBehaviour {

	private GameObject _thisGameObject ;
	private Transform _thisTransform ;
	
	public GameObject ThisGameObject 
	{
        get { return _thisGameObject ; }
    }
	public Transform ThisTransform
    {
        get { return _thisTransform ; }
    }
	
	
	private ParticleSystem _particleSystem ;
	
	private float _currentGameSpeed ;
	
	
	private void Awake ()
	{
		
		_thisGameObject = gameObject ;
		_thisTransform = transform ;
		
		_particleSystem = _thisGameObject.particleSystem ;
		
	}
	
	private void Start() {
		
	}
	
	private void Update () {
	
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
	
	
	//--Control
	public void EffectPlay(){
		if(_particleSystem.isStopped){
			_particleSystem.Play() ;
			StartCoroutine("ChangeEffectSpeed") ;
		}
	}
	
	public void EffectStop(){
		if(_particleSystem.isPlaying){
			StopCoroutine("ChangeEffectSpeed") ;
			_particleSystem.Stop() ;
		}
	}
	
	public void ChangeEffectPerSpeed(float gameSpeed) {
		
		if(gameSpeed < 1.5f){
			_currentGameSpeed = gameSpeed ;	
		}else{
			_currentGameSpeed = 1.5f ;
		}
		
	}
	
	private IEnumerator ChangeEffectSpeed() {
		
		while(_particleSystem.isPlaying){
			
			ParticleSystem.Particle[] particles = new ParticleSystem.Particle[_particleSystem.particleCount+1];
			int alive = _particleSystem.GetParticles(particles);
		
			for(int i = 0 ; i < alive ; i++){
				particles[i].velocity = new Vector3(-_currentGameSpeed, 0.5f, -1f);
        	}
 
			_particleSystem.SetParticles(particles, alive);
		
			yield return null ;
			
		}
		
	}
}
