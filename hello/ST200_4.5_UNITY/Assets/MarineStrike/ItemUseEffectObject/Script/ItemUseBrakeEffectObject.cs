using UnityEngine;
using System.Collections;

public class ItemUseBrakeEffectObject : DHEffectObject {
	
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
	
	//********
	public override void ResetEffectObject(Vector3 createPosition) {
		base.ResetEffectObject(createPosition) ;
	}

	//--
	public override void DestroyEffectObject(int destroyType) {
		base.DestroyEffectObject(destroyType) ;
	}
}
