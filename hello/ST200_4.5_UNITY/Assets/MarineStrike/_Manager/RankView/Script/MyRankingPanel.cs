using UnityEngine;
using System.Collections;

public class MyRankingPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void MyRankingPanelDelegate(MyRankingPanel myRankingPanel, int state);
	protected MyRankingPanelDelegate _myRankingPanelDelegate ;
	public event MyRankingPanelDelegate MyRankingPanelEvent {
		add{
			
			_myRankingPanelDelegate = null ;
			
			if (_myRankingPanelDelegate == null)
        		_myRankingPanelDelegate += value;
        }
		
		remove{
            _myRankingPanelDelegate -= value;
		}
	}
	
	
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
	
	public void LoadMyRankingPanel(){
		
		_cellNameLabel.text = AfreecaTvData.Instance.userInfo.nickname ;
		
		int userScore = Managers.UserData.BestScore ;
		if(userScore == 0){
			_cellScoreLabel.text = userScore.ToString() ;
		}else{
			_cellScoreLabel.text = userScore.ToString("#,#") ;
		}


		StartCoroutine(ProfileDownloadURLImage(AfreecaTvData.Instance.userInfo.profile_url)) ;

		StartCoroutine(ClanProfileDownloadURLImage(AfreecaTvData.Instance.userInfo.clan_profile_url)) ;

	}
	
	public void ReloadScoreMyRankingPanel() {
		int userScore = Managers.UserData.BestScore ;
		if(userScore == 0){
			_cellScoreLabel.text = userScore.ToString() ;
		}else{
			_cellScoreLabel.text = userScore.ToString("#,#") ;
		}
	}
	
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
	
}
