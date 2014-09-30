using UnityEngine;
using System.Collections;

public class PaymentPopupTorpedoInfoView : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentPopupTorpedoInfoViewDelegate(PaymentTorpedoBuyButton paymentTorpedoBuyButton, int paymentBuyButtonIndexNumber);
	protected PaymentPopupTorpedoInfoViewDelegate _paymentPopupInfoViewDelegate ;
	public event PaymentPopupTorpedoInfoViewDelegate PaymentPopupTorpedoInfoViewEvent {
		add{
			
			_paymentPopupInfoViewDelegate = null ;
			
			if (_paymentPopupInfoViewDelegate == null)
        		_paymentPopupInfoViewDelegate += value;
        }
		
		remove{
            _paymentPopupInfoViewDelegate -= value;
		}
	}
	
	
	[HideInInspector]
	public delegate void PaymentPopupTorpedoInfoViewButtonDelegate(PaymentPopupTorpedoInfoView paymentPopupTorpedoInfoView, int state);
	protected PaymentPopupTorpedoInfoViewButtonDelegate _paymentPopupTorpedoInfoViewButtonDelegate ;
	public event PaymentPopupTorpedoInfoViewButtonDelegate PaymentPopupTorpedoInfoViewButtonEvent {
		add{
			
			_paymentPopupTorpedoInfoViewButtonDelegate = null ;
			
			if (_paymentPopupTorpedoInfoViewButtonDelegate == null)
        		_paymentPopupTorpedoInfoViewButtonDelegate += value;
        }
		
		remove{
            _paymentPopupTorpedoInfoViewButtonDelegate -= value;
		}
	}
	
	
	///
	public GameObject _paymentTorpedoBuyButtonGameObject ;
	//public UIDraggablePanel m_DraggablePanel;
	public UIGrid m_Grid;
	///
	
	
	private void Awake(){
		
	}
	
	private void Start() {
		InitLoadPaymentPopupTorpedoInfoView() ;
	}
	
	
	//Delegate
	private void PaymentTorpedoBuyButtonDelegate(PaymentTorpedoBuyButton paymentTorpedoBuyButton, int paymentBuyButtonIndexNumber) {
		if(_paymentPopupInfoViewDelegate != null) {
			_paymentPopupInfoViewDelegate(paymentTorpedoBuyButton, paymentBuyButtonIndexNumber) ;
		}
	}
	
	
	public void InitLoadPaymentPopupTorpedoInfoView(){
		
		
		for(int i = 1 ; i <= 6 ; i++) {
			
            GameObject _go = Instantiate(_paymentTorpedoBuyButtonGameObject) as GameObject;
			_go.transform.parent = m_Grid.transform;
			_go.transform.localScale = Vector3.one;
			
			
			PaymentTorpedoBuyButton paymentTorpedoBuyButton = _go.GetComponent<PaymentTorpedoBuyButton>() as PaymentTorpedoBuyButton ;
			paymentTorpedoBuyButton.PaymentTorpedoBuyButtonEvent += PaymentTorpedoBuyButtonDelegate ;
			//UIDragPanelContents panelcontent = _go.GetComponentInChildren<UIDragPanelContents>() as UIDragPanelContents;
			//panelcontent.draggablePanel = m_DraggablePanel;
			
			paymentTorpedoBuyButton.InitLoadPaymentBuyButton(i) ;
			
		}
		m_Grid.Reposition();
		//m_DraggablePanel.ResetPosition();
	}
	
	public void LoadPaymentPopupTorpedoInfoView() {
		NGUITools.SetActive(gameObject, true) ;
	}
	
	public void RemovePaymentPopupTorpedoInfoView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	
	private void OnClickGoldInfoViewButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupTorpedoInfoViewButtonDelegate != null){
			_paymentPopupTorpedoInfoViewButtonDelegate(this,1) ;	
		}
	}
	
	private void OnClickJewelInfoViewButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupTorpedoInfoViewButtonDelegate != null){
			_paymentPopupTorpedoInfoViewButtonDelegate(this,2) ;	
		}
	}
	
	private void OnClickTorpedoInfoViewButton(){
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupTorpedoInfoViewButtonDelegate != null){
			_paymentPopupTorpedoInfoViewButtonDelegate(this,3) ;	
		}
	}
}
