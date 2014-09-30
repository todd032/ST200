using UnityEngine;
using System.Collections;

public class DropNormalItemObject : DropItemObject {

	protected override void Awake (){
		base.Awake ();
	}
	
	// Use this for initialization
	protected override void Start () {
		base.Start () ;
	}
	
	
	//-------
	public override void DropItemStartAction(Vector3 createPosition, float directionMoveInitMinPower, float directionMoveInitMaxPower, Vector2 directionMoveMinPower, Vector2 directionMoveMaxPower) {
		base.DropItemStartAction(createPosition, directionMoveInitMinPower, directionMoveInitMaxPower, directionMoveMinPower, directionMoveMaxPower) ;
	}
	//--------
	
	
	//---- Animation Controller
	public override void EffectPlay(){		
		base.EffectPlay() ;
	}
	
	public override void EffectStop(){
		base.EffectStop() ;
	}
	
	public override void EffectResume(){
		base.EffectResume() ;
	}
	
	public override void EffectPause(){
		base.EffectPause() ;
	}
	
}
