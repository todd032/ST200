using UnityEngine;
using System.Collections;

public class MyMasterRankingPanel : MonoBehaviour {
	
	[HideInInspector]
	public delegate void MyMasterRankingPanelDelegate(MyMasterRankingPanel myMasterRankingPanel, int state);
	protected MyMasterRankingPanelDelegate _myMasterRankingPanelDelegate ;
	public event MyMasterRankingPanelDelegate MyMasterRankingPanelEvent {
		add{
			
			_myMasterRankingPanelDelegate = null ;
			
			if (_myMasterRankingPanelDelegate == null)
        		_myMasterRankingPanelDelegate += value;
        }
		
		remove{
            _myMasterRankingPanelDelegate -= value;
		}
	}
	
	
	public UILabel _cellNameLabel ;
	public UILabel _cellScoreLabel ;
	public UITexture _profileImgTexture ;
	
	public UIButton _presentAllSendButton ;
	public UIButton _inviteAllSendButton ;

	public zneGifComponent _gifComponent ;

	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	public void LoadMyMasterRankingPanel(){ // string userName, string userScore, string profileURL
		
		
		//CLAN_MASTER_YN 클랜장 여부 Check..
		if(AfreecaTvData.Instance.userInfo.clan_master_yn.Equals("Y")){
			NGUITools.SetActive(_presentAllSendButton.gameObject, true) ;
			NGUITools.SetActive(_inviteAllSendButton.gameObject, true) ;
		}else{
			NGUITools.SetActive(_presentAllSendButton.gameObject, false) ;
			NGUITools.SetActive(_inviteAllSendButton.gameObject, false) ;
		}
		
		
		_cellNameLabel.text = AfreecaTvData.Instance.userInfo.nickname ;
		
		int userScore = Managers.UserData.BestScore ;
		if(userScore == 0){
			_cellScoreLabel.text = userScore.ToString() ;
		}else{
			_cellScoreLabel.text = userScore.ToString("#,#") ;
		}

		StartCoroutine(ProfileDownloadURLImage(AfreecaTvData.Instance.userInfo.profile_url)) ;

	}
	
	public void ReloadScoreMyMasterRankingPanel() {
		int userScore = Managers.UserData.BestScore ;
		if(userScore == 0){
			_cellScoreLabel.text = userScore.ToString() ;
		}else{
			_cellScoreLabel.text = userScore.ToString("#,#") ;
		}
	}
	
	
	public void SetPresentAllSendButtonEnable(bool setEnableValue){
		_presentAllSendButton.isEnabled = setEnableValue ;
	}
	
	public void SetInviteAllSendButtonEnable(bool setEnableValue){
		_inviteAllSendButton.isEnabled = setEnableValue ;
	}
	
	
	private void OnClickInviteAllSendButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		if(_myMasterRankingPanelDelegate != null){
			_myMasterRankingPanelDelegate(this, 501) ; // 클랜원 초대 전송 팝업
		}
		
	}
	
	
	private void OnClickPresentAllSendButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		if(_myMasterRankingPanelDelegate != null){
			_myMasterRankingPanelDelegate(this, 502) ; // 전체에게 선물 전송 팝업
		}
		
	}
	
	
	private IEnumerator ProfileDownloadURLImage(string urlString){
		if ( !_gifComponent.IsLoading() ){
			_gifComponent.LoadGifClipByUrl(urlString);
			_gifComponent.Play();
		}
		
		bool isDone = false ;
		bool isSuccess = false ;
		
		yield return null ;
		
		while(!isDone) {
			isDone = true ;
			if( _gifComponent._clip != null ) {
				if (_gifComponent._clip.HasError()) {
					isSuccess = false ;
					isDone = true ;
				}else if (_gifComponent._clip.IsDone()) {
					isSuccess = true ;
					isDone = true ;
				}
			}
			
			yield return null ;
			
		}
		
		if(!isSuccess){

			if(urlString != null && !urlString.Equals("")){
				WWW www = new WWW(urlString);
				yield return www;
				_profileImgTexture.mainTexture = www.texture ;

				www.Dispose() ;
				www = null ;

			}else{
				
				Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
				_profileImgTexture.mainTexture = basicTexture;
			}

		}

	}
	
	
}
