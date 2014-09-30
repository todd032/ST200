using UnityEngine;
using System.Collections;

public class EventPopupView : MonoBehaviour {

	// ========== Delegate & Event 인터페이스  Start ==========
	[HideInInspector]
	public delegate void Delegate_EventPopupView(int intPopupType_Input, int intState_Input);
	protected Delegate_EventPopupView _delegate_EventPopupView;
	public event Delegate_EventPopupView Event_Delegate_EventPopupView{
		add{
			_delegate_EventPopupView = null ;
			if (_delegate_EventPopupView == null) _delegate_EventPopupView += value;
		}
		remove{
			_delegate_EventPopupView -= value;
		}
	}
	// ========== Delegate & Event 인터페이스  End ==========

	// ========== Layout 관련 변수 선언 Start ==========
	public NoticeNEventIndicatorView _noticeNEventIndicatorView ;
	public UIGrid _noticeScrollPanelGrid ;
	public UITexture _noticeTexture ;
	public UISprite _checkImage_Sprite;
	public UISprite _checkButtonSprite ;
	
	private Texture2D m_Texture2D;
	// ========== Layout 관련 변수 선언 End ==========
	
	// ========== 기타 변수 선언 Start ==========
	private int m_intIndex ;
	private string m_strImageURL ;
	private string m_strLink ;
	
	private bool m_boolTodayHide_Check = false ;

	private int m_intPopupType;
	// ========== 기타 변수 선언 End ==========

	// ========== 상수 선언 Start ==========
	private readonly int PopupWindow_Size_Width_INT = 684;
	private readonly int PopupWindow_Size_Height_INT = 450;
	// ========== 상수 선언 End ==========
	
	
	// ========== Override 함수 정의 Start ==========
	private void Awake() {
		
	}
	
	private void Start() {
		
		m_Texture2D = new Texture2D(PopupWindow_Size_Width_INT, PopupWindow_Size_Height_INT);
	}
	
	private void Update() {
		
	}
	// ========== Override 함수 정의 End ==========
	
	public void PopupView_Initialize(){
		
		_noticeNEventIndicatorView.InitLoadNoticeNEventIndicatorView() ;
		
		NGUITools.SetActive(gameObject, false) ;
		
	}
	
	public IEnumerator PopupView_Show(
		int intPopupType_Input,
		int intIndex_Input,
		string strImageURL_Input,
		string strLink_Input) {

		yield return new WaitForSeconds(0.1f);

		NGUITools.SetActive(gameObject, true) ;
		_checkImage_Sprite.gameObject.SetActive (false);
		
		m_intPopupType = intPopupType_Input;
		m_intIndex = intIndex_Input ;
		m_strImageURL = strImageURL_Input ;
		m_strLink = strLink_Input ;

		m_boolTodayHide_Check = false;

		//Debug.Log ("ST110 EventPopupView.PopupView_Show().m_intPopupType = " + m_intPopupType);
		//Debug.Log ("ST110 EventPopupView.PopupView_Show().m_intIndex = " + m_intIndex);
		//Debug.Log ("ST110 EventPopupView.PopupView_Show().m_strImageURL = " + m_strImageURL);
		//Debug.Log ("ST110 EventPopupView.PopupView_Show().m_strLink = " + m_strLink);

		if (m_strImageURL != null
		    && !m_strImageURL.Equals("")){

			StartCoroutine(DownloadURLImage(m_strImageURL)) ;
		}

	}
	
	public void PopupView_Remove() {

		_noticeTexture.mainTexture = null;
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private IEnumerator DownloadURLImage(string urlString){
		
		_noticeNEventIndicatorView.LoadNoticeNEventIndicatorView() ;
		
		WWW www = new WWW(urlString);
		
		yield return www;
		
		m_Texture2D = www.texture;
		
		//		//Debug.Log ("ST110 EventPopupView.DownloadURLImage()._mTex.width = " + m_Texture2D.width.ToString());
		//		//Debug.Log ("ST110 EventPopupView.DownloadURLImage()._mTex.height = " + m_Texture2D.height.ToString());
		
		//_noticeTexture.transform.localScale = new Vector3 (PopupWindow_Size_Width_INT , PopupWindow_Size_Height_INT , 1 );
		_noticeTexture.mainTexture = m_Texture2D ;
		_noticeTexture.MakePixelPerfect();
		www.Dispose() ;
		www = null ;
		
		_noticeNEventIndicatorView.RemoveNoticeNEventIndicatorView() ;
		
	}
	
	// ===========  버튼 클릭 관련 함수 Start =========== 
	private void OnClick_Close() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if (m_boolTodayHide_Check){
			
			if (_delegate_EventPopupView != null) {
				_delegate_EventPopupView(m_intPopupType, Constant.HIDETODAY_Yes_INT);
			}
			
		} else {
			
			if (_delegate_EventPopupView != null) {
				_delegate_EventPopupView(m_intPopupType, Constant.HIDETODAY_No_INT);
			}
		}

		PopupView_Remove() ;
	}
	
	private void OnClick_ViewCheck(){
		
		if (m_boolTodayHide_Check){
			
			_checkImage_Sprite.gameObject.SetActive(false);
			m_boolTodayHide_Check = false ;
			
		}else{
			
			_checkImage_Sprite.gameObject.SetActive(true);
			m_boolTodayHide_Check = true ;
			
		}
		
//		//Debug.Log("ST110 EventPopupView.OnClick_ViewCheck()._isCheck = " + m_boolTodayHide_Check.ToString());
		
	}
	
	public void OnTouch_Image(){
		
		Debug.Log("ST110 EventPopupView.OnTouch_Image() Run !!!: " + m_strLink);

		if (m_strLink != null
		    && !m_strLink.Equals("")){

			if(m_strLink == Constant.POPUPEVENT_TO_CHARACTER)
			{
				Managers.UserData.ToShopIndex = 2;
				OnClick_Close();
			}else if(m_strLink == Constant.POPUPEVENT_TO_SUBMARINE)
			{
				Managers.UserData.ToShopIndex = 1;
				OnClick_Close();
			}else if(m_strLink == Constant.POPUPEVENT_TO_CASH)
			{
				Managers.UserData.ToShopIndex = 3;
				OnClick_Close();
			}else
			{
				if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
				Application.OpenURL(m_strLink);
			}

			ST200KLogManager.Instance.SaveEventBannerClick();
		}

	}
	// ===========  버튼 클릭 관련 함수 End =========== 
	
	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClick_Close();
			return true;
		}
		
		return false;
	}
}

