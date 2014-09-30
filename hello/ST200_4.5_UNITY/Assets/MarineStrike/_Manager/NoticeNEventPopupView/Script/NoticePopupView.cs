using UnityEngine;
using System.Collections;

public class NoticePopupView : MonoBehaviour {
	
	
	[HideInInspector]
	public delegate void NoticePopupViewDelegate(NoticePopupView noticePopupView, int state);
	protected NoticePopupViewDelegate _noticePopupViewDelegate ;
	public event NoticePopupViewDelegate NoticePopupViewEvent {
		add{
			
			_noticePopupViewDelegate = null ;
			
			if (_noticePopupViewDelegate == null)
        		_noticePopupViewDelegate += value;
        }
		
		remove{
            _noticePopupViewDelegate -= value;
		}
	}
	
	public NoticeNEventIndicatorView _noticeNEventIndicatorView ;
	public UIGrid _noticeScrollPanelGrid ;
	public UIButton _noticeButton ;
	public UITexture _noticeTexture ;
	
	private Texture2D _mTex;
	
	private int _noticeIndex ;
	private string _noticeImageURL ;
	private bool _noticeMoreButtonEnable = false ;
	private string _noticeMoreButtonPosition ;
	private string _noticeLink ;
	
	
	private bool _isCheck = false ;
	public UISprite _checkButtonSprite ;
	
	private void Awake() {
		
	}
	
	private void Start() {
		_mTex = new Texture2D(492 , 262);
	}
	
	private void Update() {

	}
	
	
	
	
	public void InitLoadNoticePopupView(){
		
		_noticeNEventIndicatorView.InitLoadNoticeNEventIndicatorView() ;
		
		NGUITools.SetActive(_noticeButton.gameObject, false) ;
		NGUITools.SetActive(gameObject, false) ;
		
	}
	
	public void LoadNoticePopupViewView(int noticeIndex, string noticeImageURL, bool noticeMoreButtonEnable, string noticeMoreButtonPosition, string noticeLink) {
		
		NGUITools.SetActive(gameObject, true) ;
		
		_noticeIndex = noticeIndex ;
		_noticeImageURL = noticeImageURL ;
		_noticeMoreButtonEnable = noticeMoreButtonEnable ;
		_noticeMoreButtonPosition = noticeMoreButtonPosition ;
		_noticeLink = noticeLink ;
		
		
		SetNoticePopupView(noticeIndex, noticeImageURL, noticeMoreButtonEnable, noticeMoreButtonPosition, noticeLink) ;
		
	}
	
	public void RemoveNoticePopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetNoticePopupView(int noticeIndex, string noticeImageURL, bool noticeMoreButtonEnable, string noticeMoreButtonPosition, string noticeLink){
		
		if(noticeMoreButtonEnable){
			//Button Positon...	
			
		}
		
		NGUITools.SetActive(_noticeButton.gameObject, noticeMoreButtonEnable) ;
		
		
		StartCoroutine(DownloadURLImage(noticeImageURL)) ;
		
	}
	
	
	private void OnClickNoticePopupViewOkButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_isCheck){
			Managers.UserData.SaveNoticeNumberInfo(_noticeIndex.ToString()) ;
		}
		
		if(_noticePopupViewDelegate != null) {
			_noticePopupViewDelegate(this, 100) ;	
		}	
		
		RemoveNoticePopupView() ;
		
	}
	
	private void OnClickNoticePopupViewCheckButton(){
		
		if(_isCheck){
			
			_checkButtonSprite.spriteName = "Btn_Notice_Uncheck" ;
			_isCheck = false ;
			
		}else{
			
			_checkButtonSprite.spriteName = "Btn_Notice_Checked" ;
			_isCheck = true ;
			
		}
		
	}
	
	private void OnClickNoticeButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		Application.OpenURL(_noticeLink);
		
	}
	
	
	private IEnumerator DownloadURLImage(string urlString){
		
		_noticeNEventIndicatorView.LoadNoticeNEventIndicatorView() ;
		
		WWW www = new WWW(urlString);
		
        yield return www;
		
		_mTex = www.texture;
		
		_noticeTexture.transform.localScale = new Vector3 (_mTex.width , _mTex.height , 1 );
		
		_noticeTexture.mainTexture = _mTex ;
		
		
		_noticeScrollPanelGrid.Reposition() ;

		www.Dispose() ;
		www = null ;

		_noticeNEventIndicatorView.RemoveNoticeNEventIndicatorView() ;
		
	}
	
	
}
