using UnityEngine;
using System.Collections;

public class ClanBattleViewMyRankPlayerView : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanBattleViewMyRankPlayerViewDelegate(ClanBattleViewMyRankPlayerView ClanBattleViewMyRankPlayerView, int state);
	protected ClanBattleViewMyRankPlayerViewDelegate _clanBattleViewMyRankPlayerViewDelegate ;
	public event ClanBattleViewMyRankPlayerViewDelegate ClanBattleViewMyRankPlayerViewEvent {
		add{
			
			_clanBattleViewMyRankPlayerViewDelegate = null ;
			
			if (_clanBattleViewMyRankPlayerViewDelegate == null)
				_clanBattleViewMyRankPlayerViewDelegate += value;
		}
		
		remove{
			_clanBattleViewMyRankPlayerViewDelegate -= value;
		}
	}
	
	
	private Transform _thisTransform ;
	
	
	public UISprite _clanBattleViewRankViewBgSprite ;
	public UILabel _clanBattleViewRankViewClanNameLabel ;
	public UITexture _clanBattleViewRankViewTexture ;
	public UILabel _clanBattleViewRankViewScoreLabel ;
	public UISprite _clanBattleImgTopRankSprite ;


	public zneGifComponent _gifComponent ;

	private void Awake(){
		
		_thisTransform = transform ;
		
	}
	
	private void Start() {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
	
	
	public void InitLoadClanBattleViewMyRankPlayerView(ClanBattlePopupView.ClanBattleRankingPlayer clanBattleRankingPlayer,  float baseLinePositionX, float baseLineWidth, long distancePointBaseScore, long distancePointEndScore){
		
		float calculationClanBattleViewRankPlayerDistance = Mathf.Floor((baseLineWidth * clanBattleRankingPlayer.ClanScore) / distancePointEndScore) ;
		_thisTransform.localPosition = new Vector3(baseLinePositionX+calculationClanBattleViewRankPlayerDistance,  20f,  -4f) ;
		
		_clanBattleViewRankViewClanNameLabel.text = clanBattleRankingPlayer.ClanName ;


		if(clanBattleRankingPlayer.ClanScore > 0 ){
			_clanBattleViewRankViewScoreLabel.text = clanBattleRankingPlayer.ClanScore.ToString("#,#") ;
		}else{
			_clanBattleViewRankViewScoreLabel.text = clanBattleRankingPlayer.ClanScore.ToString() ;
		}

		StartCoroutine(ProfileDownloadURLImage(clanBattleRankingPlayer.ClanProfileURL)) ;

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
				_clanBattleViewRankViewTexture.mainTexture = www.texture ;

				www.Dispose() ;
				www = null ;

			}else{
				
				Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
				_clanBattleViewRankViewTexture.mainTexture = basicTexture;
			}

		}
		
	}

	public void SetClanBattleImgTopRankSprite(bool isActiveSprite){
		NGUITools.SetActive(_clanBattleImgTopRankSprite.gameObject, isActiveSprite) ;
	}

}
