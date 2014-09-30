using UnityEngine;
using System.Collections;

public class AllKillEffectObject : DHPoolGameObject {

	public float DestoryTime= 1.0f;
	
	//private float detaTime ;
	public ParticleSystem m_Particle;
	protected override void Awake ()
	{
		base.Awake ();
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	void OnEnable() {	
		StartCoroutine("DestroyEffect") ;
		m_Particle.gameObject.SetActive(true);
		m_Particle.Play();
	}
	
	
	IEnumerator DestroyEffect() {
		yield return new WaitForSeconds(DestoryTime) ;	
		PoolManager.Despawn(_thisGameObject) ;
	}
	
	
	/*
	void Update(){
		
		detaTime += Time.deltaTime ;
		
		if(detaTime > DestoryTime) {
			detaTime = 0 ;
			PoolManager.Despawn(_thisGameObject) ;
		}
		
	}
	*/
}
