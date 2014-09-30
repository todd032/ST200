using UnityEngine;
using System.Collections;

public class ClanBattleViewTopRankPlayerView : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanBattleViewTopRankPlayerViewDelegate(ClanBattleViewTopRankPlayerView clanBattleViewTopRankPlayerView, int state);
	protected ClanBattleViewTopRankPlayerViewDelegate _clanBattleViewTopRankPlayerViewDelegate ;
	public event ClanBattleViewTopRankPlayerViewDelegate ClanBattleViewTopRankPlayerViewEvent {
		add{
			
			_clanBattleViewTopRankPlayerViewDelegate = null ;
			
			if (_clanBattleViewTopRankPlayerViewDelegate == null)
				_clanBattleViewTopRankPlayerViewDelegate += value;
		}
		
		remove{
			_clanBattleViewTopRankPlayerViewDelegate -= value;
		}
	}
	
	
	private Transform _thisTransform ;
	
	
	public UISprite _clanBattleViewRankViewBgSprite ;
	public UILabel _clanBattleViewRankViewClanNameLabel ;
	public UITexture _clanBattleViewRankViewTexture ;

	public zneGifComponent _gifComponent ;

	private void Awake(){
		
		_thisTransform = transform ;
		
	}
	
	private void Start() {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
	
	
	public void InitLoadClanBattleViewTopRankPlayerView(ClanBattlePopupView.ClanBattleRankingPlayer clanBattleRankingPlayer,  float baseLinePositionX, float baseLineWidth, long distancePointBaseScore, long distancePointEndScore){
		
		float calculationClanBattleViewRankPlayerDistance = Mathf.Floor((baseLineWidth * clanBattleRankingPlayer.ClanScore) / distancePointEndScore) ;
		_thisTransform.localPosition = new Vector3(baseLinePositionX+calculationClanBattleViewRankPlayerDistance,  20f,  -3f) ;
		
		_clanBattleViewRankViewClanNameLabel.text = clanBattleRankingPlayer.ClanName ;

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
}
