using UnityEngine;
using System.Collections;

public class PaymentPopupGoldInfoView : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentPopupGoldInfoViewDelegate(PaymentGoldBuyButton paymentGoldBuyButton, int paymentBuyButtonIndexNumber);
	protected PaymentPopupGoldInfoViewDelegate _paymentPopupInfoViewDelegate ;
	public event PaymentPopupGoldInfoViewDelegate PaymentPopupGoldInfoViewEvent {
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
	public delegate void PaymentPopupGoldInfoViewButtonDelegate(PaymentPopupGoldInfoView paymentPopupGoldInfoView, int state);
	protected PaymentPopupGoldInfoViewButtonDelegate _paymentPopupGoldInfoViewButtonDelegate ;
	public event PaymentPopupGoldInfoViewButtonDelegate PaymentPopupGoldInfoViewButtonEvent {
		add{
			
			_paymentPopupGoldInfoViewButtonDelegate = null ;
			
			if (_paymentPopupGoldInfoViewButtonDelegate == null)
        		_paymentPopupGoldInfoViewButtonDelegate += value;
        }
		
		remove{
            _paymentPopupGoldInfoViewButtonDelegate -= value;
		}
	}
	
	
	
	
	///
	public GameObject _paymentGoldBuyButtonGameObject ;

	//public UIDraggablePanel m_DraggablePanel;
	public UIGrid m_Grid;
	//private List<PaymentGoldBuyButton> _paymentGoldBuyButtonList ;
	///
	
	
	private void Awake(){
		
		//_paymentGoldBuyButtonList = new List<PaymentGoldBuyButton>() ;
		
	}
	
	private void Start() {
		InitLoadPaymentPopupGoldInfoView() ;
	}
	
	
	//Delegate
	private void PaymentGoldBuyButtonDelegate(PaymentGoldBuyButton paymentGoldBuyButton, int paymentBuyButtonIndexNumber) {
		if(_paymentPopupInfoViewDelegate != null) {
			_paymentPopupInfoViewDelegate(paymentGoldBuyButton, paymentBuyButtonIndexNumber) ;
		}
	}
	
	
	public void InitLoadPaymentPopupGoldInfoView(){
		
		
		for(int i = 1 ; i <= 6 ; i++) {
			
            GameObject _go = Instantiate(_paymentGoldBuyButtonGameObject) as GameObject;
            _go.transform.parent = m_Grid.transform;
			_go.transform.localScale = Vector3.one;
			
			PaymentGoldBuyButton paymentGoldBuyButton = _go.GetComponent<PaymentGoldBuyButton>() as PaymentGoldBuyButton ;
			paymentGoldBuyButton.PaymentGoldBuyButtonEvent += PaymentGoldBuyButtonDelegate ;

			//UIDragPanelContents panelcontent = _go.GetComponentInChildren<UIDragPanelContents>() as UIDragPanelContents;
			//panelcontent.draggablePanel = m_DraggablePanel;

			//_paymentGoldBuyButtonList.Add(paymentGoldBuyButton) ;
			
			paymentGoldBuyButton.InitLoadPaymentBuyButton(i) ;			
		}
		m_Grid.Reposition();
		//m_DraggablePanel.UpdateScrollbars(true);
		//m_DraggablePanel.ResetPosition();
	}
	
	public void LoadPaymentPopupGoldInfoView() {
		NGUITools.SetActive(gameObject, true) ;
	}
	
	public void RemovePaymentPopupGoldInfoView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	
	private void OnClickGoldInfoViewButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupGoldInfoViewButtonDelegate != null){
			_paymentPopupGoldInfoViewButtonDelegate(this,1) ;	
		}
	}
	
	private void OnClickJewelInfoViewButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupGoldInfoViewButtonDelegate != null){
			_paymentPopupGoldInfoViewButtonDelegate(this,2) ;	
		}
	}
	
	private void OnClickTorpedoInfoViewButton(){
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupGoldInfoViewButtonDelegate != null){
			_paymentPopupGoldInfoViewButtonDelegate(this,3) ;	
		}
	}
	
}
