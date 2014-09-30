using UnityEngine;
using System.Collections;
using SimpleJSON ;

public class BannerView : MonoBehaviour {

	[HideInInspector]
	public delegate void BannerViewDelegate(BannerView bannerView, string messageText,  int state);
	protected BannerViewDelegate _bannerViewDelegate ;
	public event BannerViewDelegate BannerViewEvent {
		add{
			
			_bannerViewDelegate = null ;
			
			if (_bannerViewDelegate == null)
        		_bannerViewDelegate += value;
        }
		
		remove{
            _bannerViewDelegate -= value;
		}
	}
	
	
	//public UIButton _noticeButton ;
	
	
	public UITexture _bannerViewContentsTexture ;
	
	public UISprite _bannerControlButtonArrow ;
	
	
	private Texture2D _mTex;
	
	
	private string _imageBannerURL ;
	private string _imageBannerLink ;
	private bool _imageBannerLinkEnable = false ;
	private int _imageBannerType ;
	private string _imageBannerEventIndex ;
	
	
	private Animation _thisAnimation ;
	private bool _isOpen = false ;
	private bool _isTouchControlButton = false ;

	private float _screenSizeHeight;
	private float _screenSizeWidth;
	public Camera m_CurCam;
	private void Awake() {

		_screenSizeHeight = 2f * m_CurCam.orthographicSize;
		_screenSizeWidth = _screenSizeHeight * m_CurCam.aspect;
		Vector3 position = m_CurCam.transform.position;
		//position.x += -_screenSizeWidth/2f;
		position.x = 0f;
		position.y = _screenSizeHeight/2f;
		position.z = transform.position.z;
		
		transform.position = position;

		Vector3 localpos = transform.localPosition;
		localpos.y += 110f;
		transform.localPosition = localpos;

		_thisAnimation = animation ;

		//transform.localPosition = new Vector3(0f, Screen.height/2f + 55f, transform.localPosition.z);
	}
	
	private void Start() {
		_mTex = new Texture2D(640 , 100);
	}
	
	private void Update() {

	}
	
	
	
	
	public void InitLoadBannerView(){
		
		_bannerControlButtonArrow.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 180f)) ; 
		
		NGUITools.SetActive(gameObject, false) ;
		
	}
	
	public void LoadBannerView(string imageBannerURL, string imageBannerLink, bool imageBannerLinkEnable, int imageBannerType, string imageBannerEventIndex) {
		
		NGUITools.SetActive(gameObject, true) ;
		
		_imageBannerURL = imageBannerURL ;
		_imageBannerLink = imageBannerLink ;
		_imageBannerLinkEnable = imageBannerLinkEnable ;
		_imageBannerType = imageBannerType ;
		_imageBannerEventIndex = imageBannerEventIndex ;
		
		SetBannerView(imageBannerURL, imageBannerLink, imageBannerLinkEnable, imageBannerType, imageBannerEventIndex) ;
		
	}
	
	public void RemoveBannerView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetBannerView(string imageBannerURL, string imageBannerLink, bool imageBannerLinkEnable, int imageBannerType, string imageBannerEventIndex) {
		
		StartCoroutine(DownloadURLImage(imageBannerURL)) ;
		
	}
	
	
	public void OnClickBannerViewControlButton(){
		
		if(!_isTouchControlButton) return ;
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		
		if(_isOpen){
			_isTouchControlButton = false ;
			BannerViewCloseAni();
			_bannerControlButtonArrow.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)) ; 
		}else{
			_isTouchControlButton = false ;
			BannerViewOpenAni();
			_bannerControlButtonArrow.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 180f)) ; 
		}
		
	}


	public void OnClickBannerViewContentsButton(){
		
		if(_imageBannerLinkEnable)
		{

			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

			if (_imageBannerType == 1){
				
				if (_imageBannerLink != null && !_imageBannerLink.Equals("")){
				
					Application.OpenURL(_imageBannerLink);	
				}
				
			} else if (_imageBannerType == 2){ //Server To Banner Click Info..
				
				if (_bannerViewDelegate != null){

					_bannerViewDelegate(this, null, 1001) ; // Connect Icon Start!!!!
				}

				if (Managers.DataStream != null){

					if (Managers.UserData != null){
						
						Managers.DataStream.Event_Delegate_DataStreamManager_CheckAndUpdateUser += (strResultExtendJson_Input, intNetworkResultCode_Input) => {

							if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
								
								bool specialRewardFlag = false ;
								string specialRewardMessage = "" ;
								
								if (strResultExtendJson_Input != null && !strResultExtendJson_Input.Equals("")) {

									JSONNode root = JSON.Parse(strResultExtendJson_Input);
									JSONNode data = root["Reward"];
									
									specialRewardFlag = data["SpecialReward_flag"].AsBool ;
									specialRewardMessage = data["SpecialRewardMessage"] ;
									
								}
								
								
								if(_bannerViewDelegate != null){
									
									if(specialRewardFlag && !specialRewardMessage.Equals("")){
										_bannerViewDelegate(this, specialRewardMessage, 2001) ; // Popup Message Alert!!
									}
									
									_bannerViewDelegate(this, null, 1002) ; // Connect Icon End!!!!
									
								}
								
								
								if(_imageBannerLink != null && !_imageBannerLink.Equals("")){
									Application.OpenURL(_imageBannerLink);	
								}
								
								
							} else if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Result_False){ //이미 지급된 보상이거나 크로스 배너등으로 나중에 지급될 경우임, user_data 업데이트 필요없음, 팝업 없음.
								
								if(_bannerViewDelegate != null){

									_bannerViewDelegate(this, null, 1002) ; // Connect Icon End!!!!
								}
								
								if(_imageBannerLink != null && !_imageBannerLink.Equals("")){

									Application.OpenURL(_imageBannerLink);	
								}
								
							} else { //Fail
								
								if(_bannerViewDelegate != null){

									_bannerViewDelegate(this, null, 1002) ; // Connect Icon End!!!!
								}
							}
						};
						
						UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
						///Connect
						StartCoroutine(Managers.DataStream.Network_CheckAndUpdateUser(userDataStruct, _imageBannerEventIndex)) ;
						///
					}
				}
				
			}
			
		}
		_isTouchControlButton = false ;
		BannerViewCloseAni();
		_bannerControlButtonArrow.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)) ; 
	}
	
	private IEnumerator DownloadURLImage(string urlString){
		
		WWW www = new WWW(urlString);
		
        yield return www;
		
		_mTex = www.texture;
		
		//_bannerViewContentsTexture.transform.localScale = new Vector3 (_mTex.width , _mTex.height , 1 );
		
		_bannerViewContentsTexture.mainTexture = _mTex ;
		_bannerViewContentsTexture.MakePixelPerfect();
		
		
		BannerViewOpenAni();

		www.Dispose() ;
		www = null ;

	}
	
	
	private void BannerViewOpenAniDone() {
		
		_isOpen = true ;
		_isTouchControlButton = true ;
		
	}
	
	private void BannerViewCloseAniDone() {
		
		_isOpen = false ;
		_isTouchControlButton = true ;
		
	}
	
	public void BannerViewOpenAni()
	{
		StartCoroutine(IEBannerViewOpenAni());
	}

	private IEnumerator IEBannerViewOpenAni()
	{
		Vector3 startposition = transform.localPosition;
		Vector3 endposition = Vector3.up * 425f;

		float timer = 0f;
		float speed = 4f;
		while(true)
		{
			timer += Time.deltaTime * speed;
			transform.localPosition = Vector3.Lerp(startposition, endposition, timer);

			if(timer > 1f)
			{
				break;
			}
			yield return null;
		}
		BannerViewOpenAniDone();
		yield break;
	}

	public void BannerViewCloseAni()
	{
		StartCoroutine(IEBannerViewCloseAni());
	}

	private IEnumerator IEBannerViewCloseAni()
	{
		Vector3 endposition = Vector3.up * 515f;
		Vector3 startposition = transform.localPosition;
		
		float timer = 0f;
		float speed = 4f;
		while(true)
		{
			timer += Time.deltaTime * speed;
			transform.localPosition = Vector3.Lerp(startposition, endposition, timer);
			
			if(timer > 1f)
			{
				break;
			}
			yield return null;
		}
		BannerViewCloseAniDone();
		yield break;
	}
}
