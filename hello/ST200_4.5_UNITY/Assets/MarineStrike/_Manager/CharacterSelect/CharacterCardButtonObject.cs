using UnityEngine;
using System.Collections;

public class CharacterCardButtonObject : MonoBehaviour {
	
	public UILabel _characterCardNameLabel ;
	
	
	private Transform _thisTransform ;
	public Transform ThisTransform {
		get { return _thisTransform ; }
	}
	
	private void Awake() {
		
		_thisTransform = transform ;
		
	}
	
	public void SetICharacterCardNameLabel(string characterName, string languageCode){
		
		_characterCardNameLabel.text = characterName ;
		
	}
	
}
