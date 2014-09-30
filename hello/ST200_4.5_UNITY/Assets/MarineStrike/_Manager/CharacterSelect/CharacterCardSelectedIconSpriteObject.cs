using UnityEngine;
using System.Collections;

public class CharacterCardSelectedIconSpriteObject : MonoBehaviour {
	
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

	public void SetCharacterCardSelectedIconSpritePosition(Vector3 selectPosition) {
		
		Vector3 createPosition = new Vector3(selectPosition.x + 0.16f , selectPosition.y - 0.3f, selectPosition.z) ;
		_thisTransform.position = createPosition ;
	}
	
}
