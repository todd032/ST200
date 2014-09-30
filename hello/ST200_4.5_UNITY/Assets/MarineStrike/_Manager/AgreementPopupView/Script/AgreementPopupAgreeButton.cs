using UnityEngine;
using System.Collections;

public class AgreementPopupAgreeButton : MonoBehaviour {
	
	public UISprite _agreementCheckImage ;
	
	private UIButton _thisButton ;
	
	private void Awake() {
		_thisButton = GetComponent<UIButton>() as UIButton ;
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	public void SetAgreementPopupAgreeButton(bool checkState){
		
		_thisButton.isEnabled = !checkState ;
		NGUITools.SetActive(_agreementCheckImage.gameObject, checkState) ;
		
	}
	
}
