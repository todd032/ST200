using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using SimpleJSON ;

public class ClanBattlePopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanBattlePopupViewDelegate(ClanBattlePopupView clanBattlePopupView, int state);
	protected ClanBattlePopupViewDelegate _clanBattlePopupViewDelegate ;
	public event ClanBattlePopupViewDelegate ClanBattlePopupViewEvent {
		add{
			
			_clanBattlePopupViewDelegate = null ;
			
			if (_clanBattlePopupViewDelegate == null)
				_clanBattlePopupViewDelegate += value;
		}
		
		remove{
			_clanBattlePopupViewDelegate -= value;
		}
	}

	//-- Connect Data..
	public struct ClanBattleRankingPlayer{

		private int _rankNumber ;
		public int RankNubmer {
			set { 
				_rankNumber = value ;
			}
			get {
				return _rankNumber ;
			}
		}

		private string _clanId ;
		public string ClanId {
			set { 
				_clanId = value ;
			}
			get {
				return _clanId ;
			}
		}

		private string _clanName ;
		public string ClanName {
			set { 
				_clanName = value ;
			}
			get {
				return _clanName ;
			}
		}

		private string _clanProfileURL ;
		public string ClanProfileURL {
			set { 
				_clanProfileURL = value ;
			}
			get {
				return _clanProfileURL ;
			}
		}

		private long _clanScore ;
		public long ClanScore {
			set { 
				_clanScore = value ;
			}
			get {
				return _clanScore ;
			}
		}

		public void InitData() {
			RankNubmer = 0 ;
			ClanId = null ;
			ClanName = null ;
			ClanProfileURL = null ;
			ClanScore = 0 ;
		}

	};

	public struct ClanBattleRewardItem{

		private long _rewardItemDistance ;
		public long RewardItemDistance {
			set { 
				_rewardItemDistance = value ;
			}
			get {
				return _rewardItemDistance ;
			}
		}
		
		private string _rewardItemName ;
		public string RewardItemName {
			set { 
				_rewardItemName = value ;
			}
			get {
				return _rewardItemName ;
			}
		}

		private int _rewardItemType ;
		public int RewardItemType {
			set { 
				_rewardItemType = value ;
			}
			get {
				return _rewardItemType ;
			}
		}

		private int _rewardItemCount ;
		public int RewardItemCount {
			set { 
				_rewardItemCount = value ;
			}
			get {
				return _rewardItemCount ;
			}
		}
		
	};


	private List<ClanBattleRankingPlayer> _clanBattleRankingList ;
	private List<ClanBattleRewardItem> _clanBattleRewardItemList ;
	private ClanBattleRankingPlayer _myClanBattleInfo ;
	
	private float _clanBattleAboutPopupViewBackgroundHeight ;
	private string _clanBattleAboutPopupViewAboutMessage ;

	private long _distancePointBaseScore ;
	private long _distancePointEndScore ;

	private string _distancePointString1 ;
	private string _distancePointString2 ;
	private string _distancePointString3 ;
	private string _distancePointString4 ;
	//


	public GameObject _clanBattleUI ;
	public IndicatorPopupView _clanBattlePopupViewIndicatorPopupView ;
	public ClanBattleAboutPopupView _clanBattleAboutPopupView ;
	public ClanBattleScrollContentsPanel _clanBattleScrollContentsPanel ;


	private void Awake(){

		_clanBattleRankingList = new List<ClanBattleRankingPlayer>() ;
		_clanBattleRewardItemList = new List<ClanBattleRewardItem>() ;
		_myClanBattleInfo = new ClanBattleRankingPlayer() ;


		_clanBattlePopupViewIndicatorPopupView.IndicatorPopupViewEvent += IndicatorPopupViewDelegate ;
		_clanBattleAboutPopupView.ClanBattleAboutPopupViewEvent += ClanBattleAboutPopupViewDelegate ;
		_clanBattleScrollContentsPanel.ClanBattleScrollContentsPanelEvent += ClanBattleScrollContentsPanelDelegate ;


		_clanBattlePopupViewIndicatorPopupView.InitLoadIndicatorPopupView() ;
		_clanBattleAboutPopupView.InitLoadClanBattleAboutPopupView() ;
		_clanBattleScrollContentsPanel.InitLoadClanBattleScrollContentsPanel() ;

	}
	
	private void Start() {
		
	}


	//-- Delegate
	private void IndicatorPopupViewDelegate(IndicatorPopupView indicatorPopupView, int state){
		//Nothing..
	}

	private void ClanBattleAboutPopupViewDelegate(ClanBattleAboutPopupView clanBattleAboutPopupView, int state) {
		if(state == 1){
			//Nothing...
		}
	}

	private void ClanBattleScrollContentsPanelDelegate(ClanBattleScrollContentsPanel clanBattleScrollContentsPanel, int state) {


	}




	public void InitLoadClanBattlePopupView(){

		NGUITools.SetActive(_clanBattleUI, false) ;

		NGUITools.SetActive(gameObject, false) ;
		
	}
	
	public void LoadClanBattlePopupView() {

		NGUITools.SetActive(gameObject, true) ;
		
		SetClanBattlePopupView() ;
		
	}
	
	public void RemoveClanBattlePopupView() {
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetClanBattlePopupView(){
		ConnectClanBattle() ;
	}

	private void ConnectClanBattle() {

		if(Managers.DataStream != null){
			if(Managers.UserData != null){
				
				Managers.DataStream.Event_Delegate_DataStreamManager_ReadBattleData += (strResultExtendJson_Input, intNetworkResultCode_Input) => {

					if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
						
						if (strResultExtendJson_Input != null && !strResultExtendJson_Input.Equals("")) {

							JSONNode root = JSON.Parse(strResultExtendJson_Input);

							_clanBattleAboutPopupViewBackgroundHeight = root["ClanBattleAboutPopupViewBackgroundHeight"].AsFloat ;
							_clanBattleAboutPopupViewAboutMessage = root["ClanBattleAboutPopupViewAboutMessage"] ;
							
							_distancePointBaseScore = long.Parse(root["DistancePointBaseScore"]) ;
							_distancePointEndScore =  long.Parse(root["DistancePointEndScore"]) ;
							
							_distancePointString1 = root["DistancePointString1"] ;
							_distancePointString2 = root["DistancePointString2"] ;
							_distancePointString3 = root["DistancePointString3"] ;
							_distancePointString4 = root["DistancePointString4"] ;

							JSONNode myClanBattleInfoData = root["MyClanBattleInfo"];
							_myClanBattleInfo.RankNubmer = myClanBattleInfoData["RankNubmer"].AsInt ;
							_myClanBattleInfo.ClanId = myClanBattleInfoData["ClanId"] ;
							_myClanBattleInfo.ClanName = myClanBattleInfoData["ClanName"] ;
							_myClanBattleInfo.ClanProfileURL = myClanBattleInfoData["ClanProfileURL"] ;
							_myClanBattleInfo.ClanScore = long.Parse(myClanBattleInfoData["ClanScore"]) ;

							for( int i=0; i<root["ClanBattleRankingPlayer"].Count; ++i ) {
								
								ClanBattleRankingPlayer clanBattleRankingPlayer = new ClanBattleRankingPlayer() ;
								
								JSONNode data = root["ClanBattleRankingPlayer"][i];
								clanBattleRankingPlayer.RankNubmer = data["RankNubmer"].AsInt ;
								clanBattleRankingPlayer.ClanId = data["ClanId"] ;
								clanBattleRankingPlayer.ClanName = data["ClanName"] ;
								clanBattleRankingPlayer.ClanProfileURL = data["ClanProfileURL"] ;
								clanBattleRankingPlayer.ClanScore = long.Parse(data["ClanScore"]) ;
								
								_clanBattleRankingList.Add(clanBattleRankingPlayer) ;
							}
							
							for( int i=0; i<root["ClanBattleRewardItem"].Count; ++i ) {
								
								ClanBattleRewardItem clanBattleRewardItem = new ClanBattleRewardItem() ;
								
								JSONNode data = root["ClanBattleRewardItem"][i];
								clanBattleRewardItem.RewardItemDistance = long.Parse(data["RewardItemDistance"]) ;
								clanBattleRewardItem.RewardItemName = data["RewardItemName"] ;
								clanBattleRewardItem.RewardItemType = data["RewardItemType"].AsInt ;
								clanBattleRewardItem.RewardItemCount = data["RewardItemCount"].AsInt ;
								
								_clanBattleRewardItemList.Add(clanBattleRewardItem) ;
							}
							
							// Connect End..
							_clanBattlePopupViewIndicatorPopupView.RemoveIndicatorPopupView() ;
							//
							
							NGUITools.SetActive(_clanBattleUI, true) ;
							_clanBattleScrollContentsPanel.LoadClanBattleScrollContentsPanel(_myClanBattleInfo, _clanBattleRankingList, _clanBattleRewardItemList, _distancePointBaseScore, _distancePointEndScore, _distancePointString1, _distancePointString2, _distancePointString3, _distancePointString4) ;
							
						}else{
							
							//Error....
							if(_clanBattlePopupViewDelegate != null) {
								_clanBattlePopupViewDelegate(this, 100) ; //데이터가 없음.
							}
							
							// Connect End..
							_clanBattlePopupViewIndicatorPopupView.RemoveIndicatorPopupView() ;
							//
							
							NGUITools.SetActive(_clanBattleUI, false) ;
						}
						
					}else{ //Fail
						
						//Error....
						if(_clanBattlePopupViewDelegate != null) {
							_clanBattlePopupViewDelegate(this, 200) ; //통신상태 불량..
						}
						
						// Connect End..
						_clanBattlePopupViewIndicatorPopupView.RemoveIndicatorPopupView() ;
						//
						
						NGUITools.SetActive(_clanBattleUI, false) ;
						
					}
				};

				// Connect Start..
				_clanBattlePopupViewIndicatorPopupView.LoadIndicatorPopupView() ;
				//

				///Connect
				StartCoroutine(Managers.DataStream.Network_ReadBattleData(AfreecaTvData.Instance.userInfo.clan_id)) ;
				///

			}
		}

	}


	private void OnClickClanBattlePopupViewAboutButton() {
		if(_clanBattleAboutPopupView.gameObject.activeSelf){
			_clanBattleAboutPopupView.RemoveClanBattleAboutPopupView() ;
		}else{
			_clanBattleAboutPopupView.LoadClanBattleAboutPopupView(_clanBattleAboutPopupViewBackgroundHeight, _clanBattleAboutPopupViewAboutMessage ) ;
		}
	}

	public void OnClickClanBattlePopupViewCloseButton() {
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		if(_clanBattleUI.gameObject.activeSelf){

			if(_clanBattleAboutPopupView.gameObject.activeSelf){
				_clanBattleAboutPopupView.RemoveClanBattleAboutPopupView() ;
			}
			
			//-- Clear... 
			_clanBattleRankingList.Clear() ;
			_clanBattleRewardItemList.Clear() ;
			_myClanBattleInfo.InitData() ;
			
			_clanBattleScrollContentsPanel.ClearClanBattleScrollContentsPanel() ;
			//--

			NGUITools.SetActive(_clanBattleUI, false) ;

		}


		if(_clanBattlePopupViewDelegate != null) {
			_clanBattlePopupViewDelegate(this, 1) ; //Close ClanBattlePopupView
		}
		
		RemoveClanBattlePopupView() ;
		
	}

}
