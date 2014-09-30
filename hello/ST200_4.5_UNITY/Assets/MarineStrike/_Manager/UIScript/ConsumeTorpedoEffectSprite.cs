using UnityEngine;
using System.Collections;

public class ConsumeTorpedoEffectSprite : MonoBehaviour {
	
	[HideInInspector]
	public delegate void ConsumeTorpedoEffectSpriteDelegate();
	protected ConsumeTorpedoEffectSpriteDelegate _consumeTorpedoEffectSpriteDelegate ;
	public event ConsumeTorpedoEffectSpriteDelegate ConsumeTorpedoEffectSpriteEvent {
		add{
			
			_consumeTorpedoEffectSpriteDelegate = null ;
			
			if (_consumeTorpedoEffectSpriteDelegate == null)
        		_consumeTorpedoEffectSpriteDelegate += value;
			
        }
		
		remove{
            _consumeTorpedoEffectSpriteDelegate -= value;
		}
	}
	
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	private void AnimationDone(){
		if(_consumeTorpedoEffectSpriteDelegate != null){
			_consumeTorpedoEffectSpriteDelegate() ;	
		}
	}
	
}
