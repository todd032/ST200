using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PaymentPopupJewelInfoView : MonoBehaviour {

	[HideInInspector]
	public delegate void PaymentPopupJewelInfoViewDelegate(PaymentJewelBuyButton paymentJewelBuyButton, int paymentBuyButtonIndexNumber);
	protected PaymentPopupJewelInfoViewDelegate _paymentPopupInfoViewDelegate ;
	public event PaymentPopupJewelInfoViewDelegate PaymentPopupJewelInfoViewEvent {
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
	public delegate void PaymentPopupJewelInfoViewButtonDelegate(PaymentPopupJewelInfoView paymentPopupJewelInfoView, int state);
	protected PaymentPopupJewelInfoViewButtonDelegate _paymentPopupJewelInfoViewButtonDelegate ;
	public event PaymentPopupJewelInfoViewButtonDelegate PaymentPopupJewelInfoViewButtonEvent {
		add{
			
			_paymentPopupJewelInfoViewButtonDelegate = null ;
			
			if (_paymentPopupJewelInfoViewButtonDelegate == null)
        		_paymentPopupJewelInfoViewButtonDelegate += value;
        }
		
		remove{
            _paymentPopupJewelInfoViewButtonDelegate -= value;
		}
	}
	
	
	
	
	///
	public GameObject _paymentJewelBuyButtonGameObject ;
	//public UIDraggablePanel m_DraggablePanel;
	public UIGrid m_Grid;

	protected List<PaymentJewelBuyButton> m_PaymentJewelBuyButtonList = new List<PaymentJewelBuyButton>();
	//private List<PaymentJewelBuyButton> _paymentJewelBuyButtonList ;
	///
	
	
	private void Awake(){
		
		//_paymentJewelBuyButtonList = new List<PaymentJewelBuyButton>() ;
		
	}
	
	private void Start() {
		InitLoadPaymentPopupJewelInfoView() ;
	}
	
	
	//Delegate
	private void PaymentJewelBuyButtonDelegate(PaymentJewelBuyButton paymentJewelBuyButton, int paymentBuyButtonIndexNumber) {
		if(_paymentPopupInfoViewDelegate != null) {
			_paymentPopupInfoViewDelegate(paymentJewelBuyButton, paymentBuyButtonIndexNumber) ;
		}
	}
	
	
	public void InitLoadPaymentPopupJewelInfoView(){
		
		
		for(int i = 1 ; i <= 6 ; i++) {
			
            GameObject _go = Instantiate(_paymentJewelBuyButtonGameObject) as GameObject;
			_go.transform.parent = m_Grid.transform;
			_go.transform.localScale = Vector3.one;
			
			
			PaymentJewelBuyButton paymentJewelBuyButton = _go.GetComponent<PaymentJewelBuyButton>() as PaymentJewelBuyButton ;
			paymentJewelBuyButton.PaymentJewelBuyButtonEvent += PaymentJewelBuyButtonDelegate ;
			//UIDragPanelContents panelcontent = _go.GetComponentInChildren<UIDragPanelContents>() as UIDragPanelContents;
			//panelcontent.draggablePanel = m_DraggablePanel;
			//_paymentJewelBuyButtonList.Add(paymentJewelBuyButton) ;
			
			paymentJewelBuyButton.InitLoadPaymentBuyButton(i) ;
			m_PaymentJewelBuyButtonList.Add(paymentJewelBuyButton);
		}
		m_Grid.Reposition();
		//m_DraggablePanel.ResetPosition();
	}

	public void UpdateJewelInfoView()
	{
		//Debug.Log("UPDATE VIEW");
		for(int i = 1 ; i <= m_PaymentJewelBuyButtonList.Count; i++) {
			
			m_PaymentJewelBuyButtonList[i - 1].SetPaymentBuyButton(i) ;			
		}
	}

	public void LoadPaymentPopupJewelInfoView() {
		NGUITools.SetActive(gameObject, true) ;
		UpdateJewelInfoView();
	}
	
	public void RemovePaymentPopupJewelInfoView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	
	private void OnClickGoldInfoViewButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupJewelInfoViewButtonDelegate != null){
			_paymentPopupJewelInfoViewButtonDelegate(this,1) ;	
		}
	}
	
	private void OnClickJewelInfoViewButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupJewelInfoViewButtonDelegate != null){
			_paymentPopupJewelInfoViewButtonDelegate(this,2) ;	
		}
		UpdateJewelInfoView();
	}
	
	private void OnClickTorpedoInfoViewButton(){
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_paymentPopupJewelInfoViewButtonDelegate != null){
			_paymentPopupJewelInfoViewButtonDelegate(this,3) ;	
		}
	}
	
}
