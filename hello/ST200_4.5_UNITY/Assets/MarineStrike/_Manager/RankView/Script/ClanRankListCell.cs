using UnityEngine;
using System.Collections;

public class ClanRankListCell : MonoBehaviour {
	
	[HideInInspector]
	public delegate void ClanRankListCellDelegate(ClanRankListCell clanRankListCell, int state);
	protected ClanRankListCellDelegate _clanRankListCellDelegate ;
	public event ClanRankListCellDelegate ClanRankListCellEvent {
		add{
			
			_clanRankListCellDelegate = null ;
			
			if (_clanRankListCellDelegate == null)
        		_clanRankListCellDelegate += value;
        }
		
		remove{
            _clanRankListCellDelegate -= value;
		}
	}
	
	private AfreecaTvData.ClanRankingPlayer _clanRankingPlayerInfo ;
	public AfreecaTvData.ClanRankingPlayer ClanRankingPlayerInfo {
		get { return _clanRankingPlayerInfo ; }
	}


	//public UILabel _cellTop3RankInfoLabel ;
	public UISprite _cellTop3RankingSprite ;
	public UILabel _cellRankInfoLabel ;
	public UILabel _cellNameLabel ;
	public UILabel _cellScoreLabel ;
	public UITexture _profileImgTexture ;
	public UIButton _sendTorpedoButton ;
	public UISprite _cellButtonEffectSprite ;
	
	public zneGifComponent _gifComponent ;

	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	
	//public void InitLoadClanRankListCell(int userRank, string userId, string userName, string userScore, string profileURL, string clanId, string clanName, string clanProfileURL){
	public void InitLoadClanRankListCell(int userRank, AfreecaTvData.ClanRankingPlayer clanRankingPlayer){
		
		_clanRankingPlayerInfo = clanRankingPlayer ;
		
		if(userRank >= 1 && userRank <= 3){
			//NGUITools.SetActive(_cellTop3RankInfoLabel.gameObject, true) ;	
			NGUITools.SetActive(_cellTop3RankingSprite.gameObject, true) ;	
			
			NGUITools.SetActive(_cellRankInfoLabel.gameObject, false) ;
			
			//_cellTop3RankInfoLabel.text = userRank.ToString() ;
			if(userRank == 1){
				_cellTop3RankingSprite.spriteName = "Img_FirstRank" ;
			}else if(userRank == 2){
				_cellTop3RankingSprite.spriteName = "Img_SecondRank" ;
			}else if(userRank == 3){
				_cellTop3RankingSprite.spriteName = "Img_ThirdRank" ;
			}
			
			
			
		}else{
			//NGUITools.SetActive(_cellTop3RankInfoLabel.gameObject, false) ;	
			NGUITools.SetActive(_cellTop3RankingSprite.gameObject, false) ;	
			
			NGUITools.SetActive(_cellRankInfoLabel.gameObject, true) ;
			
			_cellRankInfoLabel.text = userRank.ToString() ;
			
		}
		
		_cellNameLabel.text = clanRankingPlayer.nickname ;
		
		
		int userScore = int.Parse(clanRankingPlayer.score) ;
		if(userScore == 0){
			_cellScoreLabel.text = userScore.ToString() ;
		}else{
			_cellScoreLabel.text = userScore.ToString("#,#") ;
		}
		
		
		if(clanRankingPlayer.user_id == AfreecaTvData.Instance.userInfo.user_id){
			NGUITools.SetActive(_sendTorpedoButton.gameObject, false) ;
			NGUITools.SetActive(_cellButtonEffectSprite.gameObject, false) ;
		}else{
			NGUITools.SetActive(_sendTorpedoButton.gameObject, true) ;
			NGUITools.SetActive(_cellButtonEffectSprite.gameObject, true) ;
		}


		StartCoroutine(ProfileDownloadURLImage(clanRankingPlayer.profile_url)) ;

	}
	
	/*
	public void LoadClanRankListCell(int userRank, string userName, int userScore, string profileURL){	
	}
	*/
	
	
	public void SetSendTorpedoButtonEnable(bool setEnableValue){
	
		_sendTorpedoButton.isEnabled = setEnableValue ;
		
	}
	
	private void OnClickSendTorpedoButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		if(_clanRankListCellDelegate != null){
			_clanRankListCellDelegate(this, 503) ;	
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


	public void CellChildDestory(){
		
		_profileImgTexture.mainTexture = null ;
		NGUITools.Destroy(_profileImgTexture.gameObject) ;
		_profileImgTexture = null ;

		Resources.UnloadUnusedAssets() ;

	}

}
