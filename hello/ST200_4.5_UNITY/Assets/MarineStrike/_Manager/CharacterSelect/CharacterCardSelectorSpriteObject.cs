using UnityEngine;
using System.Collections;

public class CharacterCardSelectorSpriteObject : MonoBehaviour {
	
	private Transform _thisTransform ;
	public Transform ThisTransform {
		get { return _thisTransform ; }
	}
	
	private void Awake(){
		
		_thisTransform = transform ;
		
	}
	
	
	// Use this for initialization
	private void Start () {
	
	}

	public void SetCharacterChardSelectorSpritePosition(Vector3 selectPosition) {
		_thisTransform.position = selectPosition ;
	}
	
}
