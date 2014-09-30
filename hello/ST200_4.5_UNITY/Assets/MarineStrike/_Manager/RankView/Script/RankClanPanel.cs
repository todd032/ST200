using UnityEngine;
using System.Collections;
using SimpleJSON ;

public class RankClanPanel : MonoBehaviour {
	
	[HideInInspector]
	public delegate void RankClanPanelDelegate(RankClanPanel rankClanPanel, int state);
	protected RankClanPanelDelegate _rankClanPanelDelegate ;
	public event RankClanPanelDelegate RankClanPanelEvent {
		add{
			
			_rankClanPanelDelegate = null ;
			
			if (_rankClanPanelDelegate == null)
        		_rankClanPanelDelegate += value;
        }
		
		remove{
            _rankClanPanelDelegate -= value;
		}
	}
	
	
	//
	public PresentSendPopupView _presentSendPopupView ;
	public PresentSendMasterPopupView _presentSendMasterPopupView ;
	public PresentSendAlertPopupView _presentSendAlertPopupView ;
	//
	
	public ClanMasterRankingPanel _clanMasterRankingPanel ;
	public ClanRankingPanel _clanRankingPanel ;
	
	
	private void Awake() {
		
		_presentSendPopupView.PresentSendPopupViewEvent += PresentSendPopupViewDelegate ;
		_presentSendPopupView.InitLoadPresentSendPopupView() ;
		
		_presentSendMasterPopupView.PresentSendMasterPopupViewEvent += PresentSendMasterPopupViewDelegate ;
		_presentSendMasterPopupView.InitLoadPresentSendMasterPopupView() ;
		
		_presentSendAlertPopupView.PresentSendAlertPopupViewEvent += PresentSendAlertPopupViewDelegate ;
		_presentSendAlertPopupView.InitLoadPresentSendAlertPopupView() ;
		
		
		_clanMasterRankingPanel.ClanMasterRankingPanelEvnet += ClanMasterRankingPanelDelegate ;
		_clanMasterRankingPanel.ClanMyMasterRankingPanelEvent += ClanMyMasterRankingPanelDelegate ;
		_clanRankingPanel.ClanRankingPanelEvent += ClanRankingPanelDelegate ;
		
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	
	//Delegate
	private void ClanMasterRankingPanelDelegate(ClanMasterRankingPanel clanMasterRankingPanel, ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state) {
		if(state == 503){ // 1:1 어뢰선물보내기 !!
			SendTorpedoPresent(clanRankListCell) ;
		}else if(state == 1001) { // 1001 : Ranking Indicator Start!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}else if(state == 1002) { // 1002 : Ranking Indicator Stop!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}
	}
	
	private void ClanMyMasterRankingPanelDelegate(ClanMasterRankingPanel clanMasterRankingPanel, MyMasterRankingPanel myMasterRankingPanel, int state){
		if(state == 501){ // 클랜원 초대 전송 팝업
			SendToAllInviteMessage(myMasterRankingPanel) ;
		}else if(state == 502){ // 전체에게 선물 전송 팝업
			SendToAllTorpedoPresent(myMasterRankingPanel) ;
		}
	}
	
	private void ClanRankingPanelDelegate(ClanRankingPanel clanRankingPanel, ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state) {
		if(state == 503){ // 1:1 어뢰선물보내기 !!
			SendTorpedoPresent(clanRankListCell) ;
		}else if(state == 1001) { // 1001 : Ranking Indicator Start!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}else if(state == 1002) { // 1002 : Ranking Indicator Stop!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}
	}
	
	//-- Delegate
	private void PresentSendPopupViewDelegate(PresentSendPopupView presentSendPopupView, int state) {
		if(state == 1101) { // 1101 : RankingManager Indicator Start!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}else if(state == 1102) { // 1102 : RankingManager Indicator Stop!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}else if(state == 2101) { // 2101 : 선물을 보냈습니다.

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(2101) ;
			
		}else if(state == 2102) { // 2102 : 선물을 보내실 수 없습니다.

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(2102) ;
			
		}
	}
	
	private void PresentSendMasterPopupViewDelegate(PresentSendMasterPopupView presentSendMasterPopupView, int state) {
		if(state == 1101) { // 1101 : RankingManager Indicator Start!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}else if(state == 1102) { // 1102 : RankingManager Indicator Stop!!
			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, state) ;
			}
		}else if(state == 3101) { // 3101 : 모든 클랜원에게 어뢰를 선물하였습니다.

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(3101) ;
			
		}else if(state == 3102) { // 3102 : 선물을 보내실 수 없습니다.(Time Out)

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(3102) ;
			
		}else if(state == 3103) { // 3103 : 선물을 보내실 수 없습니다.

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(3103) ;
			
		}else if(state == 4101) { // 4101 : 클랜원들에게 초대장을 보냈습니다.

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(4101) ;
			
		}else if(state == 4102) { // 4102 : 클랜원들에게 초대장을 보내실 수 없습니다. (Time Out)

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(4102) ;
			
		}else if(state == 5101) { // 5101 : 네트워크 오류입니다.\n잠시 후 다시 시도해 주세요.

			CheckAlreadyPanel() ;
			_presentSendAlertPopupView.LoadPresentSendAlertPopupView(5101) ;
			
		}
	}
	
	
	private void PresentSendAlertPopupViewDelegate(PresentSendAlertPopupView presentSendAlertPopupView, int alertType) {
		
		if(_presentSendPopupView.gameObject.activeSelf == true){
			_presentSendPopupView.RemovePresentSendPopupView ();	
		}
		
		if(_presentSendMasterPopupView.gameObject.activeSelf == true){
			_presentSendMasterPopupView.RemovePresentSendMasterPopupView() ;
		}
		
	}
	
	
	
	
	// Send Present
	private void SendTorpedoPresent(ClanRankListCell clanRankListCell){
		_presentSendPopupView.LoadPresentSendPopupView(clanRankListCell) ;	
	}
	
	
	private void SendToAllInviteMessage(MyMasterRankingPanel myMasterRankingPanel){ // 클랜원 초대 전송 팝업
		// 전송전에 마스터 여부 판단 후 기능을 수행하자!!
		
		if(AfreecaTvData.Instance.userInfo.clan_master_yn.Equals("Y")){

			if(_rankClanPanelDelegate != null){
				_rankClanPanelDelegate(this, 1001) ; // 1001 : Ranking Indicator Start!!
			}

			Managers.DataStream.Event_Delegate_DataStreamManager_GetGroupMessageStatus += (strResultExtendJson_Input, intNetworkResultCode_Input) => {

				if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
					
					bool _isWorkOk = false ;

					if (strResultExtendJson_Input != null && !strResultExtendJson_Input.Equals("")) {

						JSONNode root = JSON.Parse(strResultExtendJson_Input);
						_isWorkOk = root["permit_invite"].AsBool;
					}
					
					if (_isWorkOk){

						_presentSendMasterPopupView.LoadPresentSendMasterPopupView(1) ;

					}else {

						CheckAlreadyPanel() ;
						_presentSendAlertPopupView.LoadPresentSendAlertPopupView(4102) ; // 4102 : 클랜원들에게 초대장을 보내실 수 없습니다. (Time Out)
					}

					if (_rankClanPanelDelegate != null){

						_rankClanPanelDelegate(this, 1002) ; // 1002 : Ranking Indicator Stop!!
					}

				} else {
					
					CheckAlreadyPanel() ;
					_presentSendAlertPopupView.LoadPresentSendAlertPopupView(5101) ; // 5101 : 네트워크 오류입니다.\n잠시 후 다시 시도해 주세요.
					
					if(_rankClanPanelDelegate != null){

						_rankClanPanelDelegate(this, 1002) ; // 1002 : Ranking Indicator Stop!!
					}
				}
			};

			StartCoroutine(Managers.DataStream.Network_GetGroupMessageStatus(AfreecaTvData.Instance.userInfo.clan_id)) ;

		}else{

			if(_rankClanPanelDelegate != null){

				_rankClanPanelDelegate(this, 5001) ; // 클랜장 기능으로 사용하실 수 없습니다.
			}
		}
		
	}
	
	private void SendToAllTorpedoPresent(MyMasterRankingPanel myMasterRankingPanel){ // 전체에게 선물 전송 팝업
		// 전송전에 마스터 여부 판단 후 기능을 수행하자!!
		
		if(AfreecaTvData.Instance.userInfo.clan_master_yn.Equals("Y")){
			//myMasterRankingPanel.SetPresentAllSendButtonEnable(false) ;

			Managers.DataStream.Event_Delegate_DataStreamManager_GetGroupMessageStatus += (strResultExtendJson_Input, intNetworkResultCode_Input) => {

				if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
					
					bool _isWorkOk = false ;

					if (strResultExtendJson_Input != null && !strResultExtendJson_Input.Equals("")) {

						JSONNode root = JSON.Parse(strResultExtendJson_Input);
						_isWorkOk = root["permit_gift"].AsBool;
					}

					if (_isWorkOk){

						_presentSendMasterPopupView.LoadPresentSendMasterPopupView(2) ;

					}else {

						CheckAlreadyPanel() ;
						_presentSendAlertPopupView.LoadPresentSendAlertPopupView(3102) ; // 4102 : 클랜원들에게 초대장을 보내실 수 없습니다. (Time Out)
					}
					
					if (_rankClanPanelDelegate != null){

						_rankClanPanelDelegate(this, 1002) ; // 1002 : Ranking Indicator Stop!!
					}

				}else{ //Fail
					
					CheckAlreadyPanel() ;
					_presentSendAlertPopupView.LoadPresentSendAlertPopupView(5101) ; // 5101 : 네트워크 오류입니다.\n잠시 후 다시 시도해 주세요.
					
					if (_rankClanPanelDelegate != null){

						_rankClanPanelDelegate(this, 1002) ; // 1002 : Ranking Indicator Stop!!
					}
				}
			};

			StartCoroutine(Managers.DataStream.Network_GetGroupMessageStatus(AfreecaTvData.Instance.userInfo.clan_id)) ;

		}else{

			if(_rankClanPanelDelegate != null){

				_rankClanPanelDelegate(this, 5001) ; // 클랜장 기능으로 사용하실 수 없습니다.
			}
		}
	}
	
	
	
	
	
	public void LoadRankClanPanel(){
		
		//Debug.Log("LoadRankClanPanel()") ;
		
		if(AfreecaTvData.Instance.userInfo.clan_master_yn.Equals("Y")){ //
			
			NGUITools.SetActive(_clanMasterRankingPanel.gameObject, true) ;
			NGUITools.SetActive(_clanRankingPanel.gameObject, false) ;
			
			_clanMasterRankingPanel.LoadClanMasterRankingPanel() ;
			
		}else{
			
			NGUITools.SetActive(_clanMasterRankingPanel.gameObject, false) ;
			NGUITools.SetActive(_clanRankingPanel.gameObject, true) ;
			
			_clanRankingPanel.LoadClanRankingPanel() ;
			
		}
		
	}
	
	
	public void ClosePopupView(){
		
		if(_presentSendPopupView.gameObject.activeSelf == true){
			_presentSendPopupView.RemovePresentSendPopupView() ;
		}
		
	}


	private void CheckAlreadyPanel(){

		bool checkAlreadyPanel = false ;

		if(_presentSendPopupView.gameObject.activeSelf == true){
			checkAlreadyPanel = true ;
		}
		
		if(_presentSendMasterPopupView.gameObject.activeSelf == true){
			checkAlreadyPanel = true ;
		}

		if(checkAlreadyPanel){
			_presentSendAlertPopupView.SetPresentSendAlertPopupViewBlackSpriteAlpha(0f) ;
		}else{
			_presentSendAlertPopupView.SetPresentSendAlertPopupViewBlackSpriteAlpha(1f) ;
		}

	}
	
}
