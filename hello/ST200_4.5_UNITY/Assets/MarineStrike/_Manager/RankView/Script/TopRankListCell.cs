using UnityEngine;
using System.Collections;

public class TopRankListCell : MonoBehaviour {

	[HideInInspector]
	public delegate void TopRankListCellDelegate(TopRankListCell topRankListCell, int state);
	protected TopRankListCellDelegate _topRankListCellDelegate ;
	public event TopRankListCellDelegate TopRankListCellEvent {
		add{
			
			_topRankListCellDelegate = null ;
			
			if (_topRankListCellDelegate == null)
        		_topRankListCellDelegate += value;
        }
		
		remove{
            _topRankListCellDelegate -= value;
		}
	}
	
	
	private AfreecaTvData.TopRankingPlayer _topRankingPlayerInfo ;
	public AfreecaTvData.TopRankingPlayer TopRankingPlayerInfo {
		get { return _topRankingPlayerInfo ; }
	}
	
	
	public UISprite _cellTop3RankInfoSprite ;
	public UILabel _cellRankInfoLabel ;
	public UILabel _cellNameLabel ;
	public UILabel _cellScoreLabel ;
	public UITexture _profileImgTexture ;
	public UITexture _clanImgTexture ;
	
	public zneGifComponent _gifProfileComponent ;
	public zneGifComponent _gifClanComponent ;


	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	public void InitLoadTopRankListCell(int userRank, AfreecaTvData.TopRankingPlayer topRankingPlayer){
		
		_topRankingPlayerInfo = topRankingPlayer ;
		
		if(userRank >= 1 && userRank <= 3){
			NGUITools.SetActive(_cellTop3RankInfoSprite.gameObject, true) ;
			NGUITools.SetActive(_cellRankInfoLabel.gameObject, false) ;
			
			if(userRank == 1){
				_cellTop3RankInfoSprite.spriteName = "Img_FirstRank" ;
			}else if(userRank == 2){
				_cellTop3RankInfoSprite.spriteName = "Img_SecondRank" ;
			}else if(userRank == 3){
				_cellTop3RankInfoSprite.spriteName = "Img_ThirdRank" ;
			}
			
		}else{
			NGUITools.SetActive(_cellTop3RankInfoSprite.gameObject, false) ;	
			NGUITools.SetActive(_cellRankInfoLabel.gameObject, true) ;
			
			_cellRankInfoLabel.text = userRank.ToString() ;
			
		}
		
		_cellNameLabel.text = topRankingPlayer.nickname ;
		
		
		int userScore = int.Parse(topRankingPlayer.score) ;
		if(userScore == 0){
			_cellScoreLabel.text = userScore.ToString() ;
		}else{
			_cellScoreLabel.text = userScore.ToString("#,#") ;
		}
		

		StartCoroutine(ProfileDownloadURLImage(topRankingPlayer.profile_url)) ;

		StartCoroutine(ClanProfileDownloadURLImage(topRankingPlayer.clan_profile_url)) ;

	}
	
	/*
	public void LoadTopRankListCell(int userRank, string userName, int userScore, string profileURL, string clanURL){
		
		
	}
	*/
	
	private IEnumerator ProfileDownloadURLImage(string urlString){
		if ( !_gifProfileComponent.IsLoading() ){
			_gifProfileComponent.LoadGifClipByUrl(urlString);
			_gifProfileComponent.Play();
		}
		
		bool isDone = false ;
		bool isSuccess = false ;
		
		yield return null ;
		
		while(!isDone) {
			isDone = true ;
			if( _gifProfileComponent._clip != null ) {
				if (_gifProfileComponent._clip.HasError()) {
					isSuccess = false ;
					isDone = true ;
				}else if (_gifProfileComponent._clip.IsDone()) {
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
	
	private IEnumerator ClanProfileDownloadURLImage(string urlString){
		if ( !_gifClanComponent.IsLoading() ){
			_gifClanComponent.LoadGifClipByUrl(urlString);
			_gifClanComponent.Play();
		}
		
		bool isDone = false ;
		bool isSuccess = false ;
		
		yield return null ;
		
		while(!isDone) {
			isDone = true ;
			if( _gifClanComponent._clip != null ) {
				if (_gifClanComponent._clip.HasError()) {
					isSuccess = false ;
					isDone = true ;
				}else if (_gifClanComponent._clip.IsDone()) {
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
				_clanImgTexture.mainTexture = www.texture ;

				www.Dispose() ;
				www = null ;

			}else{
				
				Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
				_clanImgTexture.mainTexture = basicTexture;

			}

		}

	}

	public void CellChildDestory(){

		_profileImgTexture.mainTexture = null ;
		NGUITools.Destroy(_profileImgTexture.gameObject) ;
		_profileImgTexture = null ;

		_clanImgTexture.mainTexture = null ;
		NGUITools.Destroy(_clanImgTexture.gameObject) ;
		_clanImgTexture = null ;

		Resources.UnloadUnusedAssets() ;

	}

}
