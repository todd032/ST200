using UnityEngine;
using System.Collections;

public class SubMarineDeadBubEffectObject : SubmarineParticleEffectObject {
	
	protected override void Awake ()
	{
		base.Awake ();
	}
	
	protected override void Start() {
		base.Start() ;	
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update() ;
	}
	
	public virtual void ChangeStateSubmarineDeadBubEffect(bool deadMode){
		
		if(deadMode){
			StartEffectObject() ;
		}else{
			StopEffectObject() ;
		}
		
	}
}
