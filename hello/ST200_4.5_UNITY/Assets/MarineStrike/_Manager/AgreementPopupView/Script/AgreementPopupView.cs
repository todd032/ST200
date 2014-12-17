using UnityEngine;
using System.Collections;

public class AgreementPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void AgreementPopupViewDelegate(AgreementPopupView agreementPopupView, int state);
	protected AgreementPopupViewDelegate _agreementPopupViewDelegate ;
	public event AgreementPopupViewDelegate AgreementPopupViewEvent {
		add{
			
			_agreementPopupViewDelegate = null ;
			
			if (_agreementPopupViewDelegate == null)
        		_agreementPopupViewDelegate += value;
        }
		
		remove{
            _agreementPopupViewDelegate -= value;
		}
	}

	public GameObject m_SmallWindow;
	public GameObject m_LargeWindow1;
	public GameObject m_LargeWindow2;

	public AgreementPopupAgreeButton _serviceTermsOkButton ;
	public AgreementPopupAgreeButton _individualTermsOkButton ;
	
	private bool _individualTermsOk = false ;
	private bool _serviceTermsOk = false ;
	
	
	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	
	
	public void InitAgreementPopupView(){
		NGUITools.SetActive(gameObject, false) ;
	}
	
	public void LoadAgreementPopupView() {
		NGUITools.SetActive(gameObject, true) ;
		NGUITools.SetActive(m_SmallWindow.gameObject, true);
		NGUITools.SetActive(m_LargeWindow1.gameObject, false);
		NGUITools.SetActive(m_LargeWindow2.gameObject, false);
		SetAgreementPopupView() ;
	}
	
	public void RemoveAgreementPopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetAgreementPopupView(){
		_serviceTermsOkButton.SetAgreementPopupAgreeButton(_serviceTermsOk) ;
		_individualTermsOkButton.SetAgreementPopupAgreeButton(_individualTermsOk) ;
	}
	
	
	public void OnClickIndividualTermsOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		_individualTermsOk = true ;
		
		_individualTermsOkButton.SetAgreementPopupAgreeButton(_individualTermsOk) ;
		
		
		if(_individualTermsOk && _serviceTermsOk){

			int intAgreement = PlayerPrefs.GetInt(Constant.PREFKEY_Agreement_INT);

			if (intAgreement == Constant.INT_False){
				
				PlayerPrefs.SetInt(Constant.PREFKEY_Agreement_INT, Constant.INT_True);
			}

			RemoveAgreementPopupView() ;
			
			if(_agreementPopupViewDelegate != null) {
				_agreementPopupViewDelegate(this, 100) ;	
			}
			
		}
		
			
		
	}
	
	public void OnClickServiceTermsOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		_serviceTermsOk = true ;
		
		_serviceTermsOkButton.SetAgreementPopupAgreeButton(_serviceTermsOk) ;
		
		
		if(_individualTermsOk && _serviceTermsOk){

			int intAgreement = PlayerPrefs.GetInt(Constant.PREFKEY_Agreement_INT);
			
			if (intAgreement == Constant.INT_False){
				
				PlayerPrefs.SetInt(Constant.PREFKEY_Agreement_INT, Constant.INT_True);
			}

			RemoveAgreementPopupView() ;
			
			if(_agreementPopupViewDelegate != null) {
				_agreementPopupViewDelegate(this, 100) ;	
			}
			
		}
		
	}

	public void OnClickLargeWindowShow1()
	{
		NGUITools.SetActive(m_SmallWindow.gameObject, false);
		NGUITools.SetActive(m_LargeWindow1.gameObject, true);
		NGUITools.SetActive(m_LargeWindow2.gameObject, false);
	}

	public void OnClickLargeWindowShow2()
	{
		NGUITools.SetActive(m_SmallWindow.gameObject, false);
		NGUITools.SetActive(m_LargeWindow1.gameObject, false);
		NGUITools.SetActive(m_LargeWindow2.gameObject, true);
	}

	public void OnClickLargeWindowAgree1()
	{
		NGUITools.SetActive(m_SmallWindow.gameObject, true);
		NGUITools.SetActive(m_LargeWindow1.gameObject, false);
		NGUITools.SetActive(m_LargeWindow2.gameObject, false);
		OnClickServiceTermsOkButton();
	}

	public void OnClickLargeWindowClose1()
	{
		NGUITools.SetActive(m_SmallWindow.gameObject, true);
		NGUITools.SetActive(m_LargeWindow1.gameObject, false);
		NGUITools.SetActive(m_LargeWindow2.gameObject, false);
	}

	public void OnClickLargeWindowAgree2()
	{
		NGUITools.SetActive(m_SmallWindow.gameObject, true);
		NGUITools.SetActive(m_LargeWindow1.gameObject, false);
		NGUITools.SetActive(m_LargeWindow2.gameObject, false);
		OnClickIndividualTermsOkButton();
	}

	public void OnClickLargeWindowClose2()
	{
		NGUITools.SetActive(m_SmallWindow.gameObject, true);
		NGUITools.SetActive(m_LargeWindow1.gameObject, false);
		NGUITools.SetActive(m_LargeWindow2.gameObject, false);
	}
}
