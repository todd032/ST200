using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class ClanBattleScrollContentsPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanBattleScrollContentsPanelDelegate(ClanBattleScrollContentsPanel clanBattleScrollContentsPanel, int state);
	protected ClanBattleScrollContentsPanelDelegate _clanBattleScrollContentsPanelDelegate ;
	public event ClanBattleScrollContentsPanelDelegate ClanBattleScrollContentsPanelEvent {
		add{
			
			_clanBattleScrollContentsPanelDelegate = null ;
			
			if (_clanBattleScrollContentsPanelDelegate == null)
				_clanBattleScrollContentsPanelDelegate += value;
		}
		
		remove{
			_clanBattleScrollContentsPanelDelegate -= value;
		}
	}

	public UISprite _baseLineSprite ;
	private Transform _baseLineSpriteTransform ;


	public GameObject _clanBattleRewardItemView ;
	private List<ClanBattleRewardItemView> _clanBattleRewardItemViewList ;


	public GameObject _clanBattleViewMyRankPlayerView ;
	ClanBattleViewMyRankPlayerView _clanBattleViewMyRankPlayer ;

	public GameObject _clanBattleViewTopRankPlayerView ;
	ClanBattleViewTopRankPlayerView _clanBattleViewTopRankPlayer ;


	public GameObject _clanBattleViewRankPlayerView ;
	private List<ClanBattleViewRankPlayerView> _clanBattleViewRankPlayerViewList ;


	public UILabel _distancePointStartLabel ;
	public UILabel _distancePoint1Label ;
	public UILabel _distancePoint2Label ;
	public UILabel _distancePoint3Label ;
	public UILabel _distancePointEndLabel ;


	private void Awake(){

		_clanBattleRewardItemViewList = new List<ClanBattleRewardItemView>() ;
		_clanBattleViewRankPlayerViewList = new List<ClanBattleViewRankPlayerView>() ;

	}
	
	private void Start() {
		
	}
	
	// Update is called once per frame
	private void Update () {
	
	}


	public void InitLoadClanBattleScrollContentsPanel(){
		_baseLineSpriteTransform = _baseLineSprite.transform ;
	}


	public void ClearClanBattleScrollContentsPanel() {
		
		// Delete ClanBattleRewardItemView!!
		foreach(ClanBattleRewardItemView clanBattleRewardItemView in _clanBattleRewardItemViewList){
			NGUITools.Destroy(clanBattleRewardItemView.gameObject) ;
		}
		_clanBattleRewardItemViewList.Clear() ;
		//

		// Delete ClanBattleViewRankPlayerView!!
		foreach(ClanBattleViewRankPlayerView clanBattleViewRankPlayerView in _clanBattleViewRankPlayerViewList){
			NGUITools.Destroy(clanBattleViewRankPlayerView.gameObject) ;
		}
		_clanBattleViewRankPlayerViewList.Clear() ;
		//


		// Delete ClanBattleViewTopRankPlayerView!!
		if(_clanBattleViewTopRankPlayer != null){
			NGUITools.Destroy(_clanBattleViewTopRankPlayer.gameObject) ;
			_clanBattleViewTopRankPlayer = null ;
		}

		// Delete ClanBattleViewMyRankPlayerView!!
		if(_clanBattleViewMyRankPlayer != null){
			NGUITools.Destroy(_clanBattleViewMyRankPlayer.gameObject) ;
			_clanBattleViewMyRankPlayer = null ;
		}




		NGUITools.SetActive(_distancePointStartLabel.gameObject, false);
		NGUITools.SetActive(_distancePoint1Label.gameObject, false);
		NGUITools.SetActive(_distancePoint2Label.gameObject, false);
		NGUITools.SetActive(_distancePoint3Label.gameObject, false);
		NGUITools.SetActive(_distancePointEndLabel.gameObject, false);
		
	}


	public void LoadClanBattleScrollContentsPanel(ClanBattlePopupView.ClanBattleRankingPlayer myClanBattleInfo, 
	                                              List<ClanBattlePopupView.ClanBattleRankingPlayer> clanBattleRankingList, List<ClanBattlePopupView.ClanBattleRewardItem> clanBattleRewardItemList, 
	                                              long distancePointBaseScore, long distancePointEndScore,
	                                              string distancePointString1, string distancePointString2, string distancePointString3, string distancePointString4) {

		SetClanBattleScrollContentsPanel(myClanBattleInfo, clanBattleRankingList, clanBattleRewardItemList, distancePointBaseScore, distancePointEndScore, distancePointString1, distancePointString2, distancePointString3, distancePointString4) ;

	}
	


	private void SetClanBattleScrollContentsPanel(ClanBattlePopupView.ClanBattleRankingPlayer myClanBattleInfo, 
	                                              List<ClanBattlePopupView.ClanBattleRankingPlayer> clanBattleRankingList, List<ClanBattlePopupView.ClanBattleRewardItem> clanBattleRewardItemList, 
	                                              long distancePointBaseScore, long distancePointEndScore,
	                                              string distancePointString1, string distancePointString2, string distancePointString3, string distancePointString4){

		SetClanBattleDistancePoint(distancePointBaseScore, distancePointEndScore, distancePointString1, distancePointString2, distancePointString3, distancePointString4) ;


		for(int i = 0 ; i < clanBattleRewardItemList.Count ; i++) {

			ClanBattlePopupView.ClanBattleRewardItem clanBattleRewardItem = clanBattleRewardItemList[i] ;

			if(distancePointEndScore < clanBattleRewardItem.RewardItemDistance){
				continue ;
			}

			GameObject _go = Instantiate(_clanBattleRewardItemView) as GameObject;
			_go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			ClanBattleRewardItemView clanBattleRewardItemView = _go.GetComponent<ClanBattleRewardItemView>() as ClanBattleRewardItemView ;
			clanBattleRewardItemView.ClanBattleRewardItemViewEvent += null ;

			_clanBattleRewardItemViewList.Add(clanBattleRewardItemView) ;
			

			clanBattleRewardItemView.InitLoadClanBattleRewardItemView(i, clanBattleRewardItem, _baseLineSpriteTransform.localPosition.x, _baseLineSpriteTransform.localScale.x, distancePointBaseScore, distancePointEndScore) ;

		}


		///////
		GameObject _goMyRankPlayerView = Instantiate(_clanBattleViewMyRankPlayerView) as GameObject;
		_goMyRankPlayerView.transform.parent = this.transform;
		_goMyRankPlayerView.transform.localPosition = Vector3.zero ;
		_goMyRankPlayerView.transform.localScale = new Vector3(1f, 1f, 1f);
		
		_clanBattleViewMyRankPlayer = _goMyRankPlayerView.GetComponent<ClanBattleViewMyRankPlayerView>() as ClanBattleViewMyRankPlayerView ;
		_clanBattleViewMyRankPlayer.ClanBattleViewMyRankPlayerViewEvent += null ;
		
		_clanBattleViewMyRankPlayer.InitLoadClanBattleViewMyRankPlayerView(myClanBattleInfo, _baseLineSpriteTransform.localPosition.x, _baseLineSpriteTransform.localScale.x, distancePointBaseScore, distancePointEndScore) ;
		///////


		for(int i = 0 ; i < clanBattleRankingList.Count ; i++) {

			ClanBattlePopupView.ClanBattleRankingPlayer clanBattleRankingPlayer = clanBattleRankingList[i] ;
			
			if(clanBattleRankingPlayer.ClanId.Equals(myClanBattleInfo.ClanId)){
				continue ;
			}

			if(clanBattleRankingPlayer.RankNubmer == 1){
				continue ;
			}

			GameObject _go = Instantiate(_clanBattleViewRankPlayerView) as GameObject;
			_go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			ClanBattleViewRankPlayerView clanBattleViewRankPlayerView = _go.GetComponent<ClanBattleViewRankPlayerView>() as ClanBattleViewRankPlayerView ;
			clanBattleViewRankPlayerView.ClanBattleViewRankPlayerViewEvent += null ;
			
			_clanBattleViewRankPlayerViewList.Add(clanBattleViewRankPlayerView) ;
			
			
			clanBattleViewRankPlayerView.InitLoadClanBattleViewRankPlayerView(i, clanBattleRankingPlayer, _baseLineSpriteTransform.localPosition.x, _baseLineSpriteTransform.localScale.x, distancePointBaseScore, distancePointEndScore) ;
			
		}

		for(int i = 0 ; i < clanBattleRankingList.Count ; i++) {
			
			ClanBattlePopupView.ClanBattleRankingPlayer clanBattleRankingPlayer = clanBattleRankingList[i] ;


			if(clanBattleRankingPlayer.RankNubmer == 1 && !clanBattleRankingPlayer.ClanId.Equals(myClanBattleInfo.ClanId)){

				_clanBattleViewMyRankPlayer.SetClanBattleImgTopRankSprite(false) ;

				GameObject _go = Instantiate(_clanBattleViewTopRankPlayerView) as GameObject;
				_go.transform.parent = this.transform;
				_go.transform.localPosition = Vector3.zero ;
				_go.transform.localScale = new Vector3(1f, 1f, 1f);

				_clanBattleViewTopRankPlayer = _go.GetComponent<ClanBattleViewTopRankPlayerView>() as ClanBattleViewTopRankPlayerView ;
				_clanBattleViewTopRankPlayer.ClanBattleViewTopRankPlayerViewEvent += null ;

				_clanBattleViewTopRankPlayer.InitLoadClanBattleViewTopRankPlayerView(clanBattleRankingPlayer, _baseLineSpriteTransform.localPosition.x, _baseLineSpriteTransform.localScale.x, distancePointBaseScore, distancePointEndScore) ;

				break ;

			}else if(clanBattleRankingPlayer.RankNubmer == 1 && clanBattleRankingPlayer.ClanId.Equals(myClanBattleInfo.ClanId)){

				_clanBattleViewMyRankPlayer.SetClanBattleImgTopRankSprite(true) ;

				_clanBattleViewTopRankPlayer = null ;

				break ;

			}

		}



	}

	
	private void SetClanBattleDistancePoint(long distancePointBaseScore, long distancePointEndScore, string distancePointString1, string distancePointString2, string distancePointString3, string distancePointString4){

		/*
		long distancePoint1Value = (long)( ((long)distancePointEndScore * 0.25f) / (long)distancePointBaseScore ) ;
		long distancePoint2Value = (long)( ((long)distancePointEndScore * 0.5f) / (long)distancePointBaseScore ) ;
		long distancePoint3Value = (long)( ((long)distancePointEndScore * 0.75f) / (long)distancePointBaseScore ) ;
		long distancePoint4Value = (long)( ((long)distancePointEndScore * 1f) / (long)distancePointBaseScore ) ;


		string baseDistanceString = "" ;
		if(distancePointBaseScore == 10000){
			baseDistanceString = "만" ;
		}else if(distancePointBaseScore == 100000){
			baseDistanceString = "십만" ;
		}else if(distancePointBaseScore == 1000000){
			baseDistanceString = "백만" ;
		}else if(distancePointBaseScore == 10000000){
			baseDistanceString = "천만" ;
		}else if(distancePointBaseScore == 100000000){
			baseDistanceString = "억" ;
		}else if(distancePointBaseScore == 1000000000){
			baseDistanceString = "십억" ;
		}else if(distancePointBaseScore == 10000000000){
			baseDistanceString = "백억" ;
		}else if(distancePointBaseScore == 100000000000){
			baseDistanceString = "천억" ;
		}


		_distancePointStartLabel.text = "Start" ;
		_distancePoint1Label.text = distancePoint1Value.ToString("#,#") + baseDistanceString ;
		_distancePoint2Label.text = distancePoint2Value.ToString("#,#") + baseDistanceString ;
		_distancePoint3Label.text = distancePoint3Value.ToString("#,#") + baseDistanceString ;
		_distancePointEndLabel.text = distancePoint4Value.ToString("#,#") + baseDistanceString ;
		//_distancePointEndLabel.text = distancePointEndScore.ToString("#,#") + baseDistanceString ;
		*/


		_distancePointStartLabel.text = "Start" ;
		_distancePoint1Label.text = distancePointString1 ;
		_distancePoint2Label.text = distancePointString2 ;
		_distancePoint3Label.text = distancePointString3 ;
		_distancePointEndLabel.text = distancePointString4 ;


		NGUITools.SetActive(_distancePointStartLabel.gameObject, true);
		NGUITools.SetActive(_distancePoint1Label.gameObject, true);
		NGUITools.SetActive(_distancePoint2Label.gameObject, true);
		NGUITools.SetActive(_distancePoint3Label.gameObject, true);
		NGUITools.SetActive(_distancePointEndLabel.gameObject, true);
		
	}


}
