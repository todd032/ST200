using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
using SimpleJSON ;

public class ClanRankingListGrid : MonoBehaviour {
	
	[HideInInspector]
	public delegate void ClanRankingListGridDelegate(ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state);
	protected ClanRankingListGridDelegate _clanRankingListGridDelegate ;
	public event ClanRankingListGridDelegate ClanRankingListGridEvent {
		add{
			
			_clanRankingListGridDelegate = null ;
			
			if (_clanRankingListGridDelegate == null)
        		_clanRankingListGridDelegate += value;
        }
		
		remove{
            _clanRankingListGridDelegate -= value;
		}
	}
	
	
	
	///
	public GameObject _clanRankListCellObject ;
	private List<ClanRankListCell> _clanRankListCellList ;
	
	public GameObject _upDownRankListCellObject ;
	private UpDownRankListCell _upRankingListCell ;
	private UpDownRankListCell _downRankingListCell ;
	///
	
	
	private List<string> _getMessageBlockUserList ;
	
	
	private int _listPageNumber = 1 ;
	
	public int _visibleCellNumber = 3 ;
	
	private void Awake() {
		
		_getMessageBlockUserList = new List<string>() ;
		
		_clanRankListCellList = new List<ClanRankListCell>() ;
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	
	//Delegate
	private void ClanRankListCellDelegate(ClanRankListCell clanRankListCell, int state) {
		if(_clanRankingListGridDelegate != null){
			_clanRankingListGridDelegate(this, clanRankListCell, state) ;  // 503 : 어뢰선물보내기 버튼 클릭!!
		}
	}
	
	private void UpDownRankListCellDelegate(UpDownRankListCell upDownRankListCell, int upDownState){
		if(upDownState == 1){ //Up Click
			
			if(_listPageNumber > 1){
				
				DeleteAllClanRankingListGrid() ;
				
				_listPageNumber -= 1 ;	
				
				ConnectMessageBlockUserList() ;	
				
			}
			
		}else if(upDownState == 2){ //Down Click
			
			if(AfreecaTvData.Instance.clanRanking.more_yn.Equals("Y")){
			
				DeleteAllClanRankingListGrid() ;
				
				_listPageNumber += 1 ;	
				
				ConnectMessageBlockUserList() ;
				
			}
			
		}
	}
	
	
	public void InitLoadClanRankingListGrid(){ // input List?? ,  MORE_YN :다음 페이지 존재의 여부
		
		ConnectMessageBlockUserList() ;
		
	}
	
	private void ConnectMessageBlockUserList() {
	
		// Connect Indicator Start..
		if(_clanRankingListGridDelegate != null){
			_clanRankingListGridDelegate(this, null, 1001) ;  // 1001 : Ranking Indicator Start!!
		}
		
		Managers.DataStream.Event_Delegate_DataStreamManager_MessageBlockUserList += (strResultExtendJson_Input, intNetworkResultCode_Input) => {

			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){
				
				_getMessageBlockUserList.Clear() ;
				
				JSONNode root = JSON.Parse(strResultExtendJson_Input);

				for( int i=0; i<root.Count; ++i ) {

					JSONNode data = root[i];
					
					_getMessageBlockUserList.Add(data["reciver_id"]) ;
				}

				ConnectRankingList() ;

			}else{ //Fail
				
				ConnectRankingList() ;
			}
		};
		
		StartCoroutine(Managers.DataStream.Network_MessageBlockUserList()) ;
	}
	
	private void ConnectRankingList() {
		
		NativeHelper_Afreeca.Instance.AfreecaTVConnectCompleteEvent += (returnAction) => {
			if(returnAction.Equals("GetClanRanking")){
				//AfreecaTvData참조하여 클랜랭킹 보여주기..
				
				MakeClanRankingListGrid() ;
				
				// Connect Indicator Stop..
				if(_clanRankingListGridDelegate != null){
					_clanRankingListGridDelegate(this, null, 1002) ;  // 1002 : Ranking Indicator Stop!!
				}
				
			}
		} ;
		
		NativeHelper_Afreeca.Instance.AfreecaTVConnectErrorEvent += (returnAction, errorCode, errorMessage) => {
			if(returnAction.Equals("GetClanRanking")){
				//Error..
				
				
				// Connect Indicator Stop..
				if(_clanRankingListGridDelegate != null){
					_clanRankingListGridDelegate(this, null, 1002) ;  // 1002 : Ranking Indicator Stop!!
				}
				
			}
		};
		
		
		NativeHelper_Afreeca.Instance.paramPageNumber = _listPageNumber ;
		NativeHelper_Afreeca.Instance.paramPageLimit = Managers.GameBalanceData.ClanRankingListPageLimit ;
		NativeHelper_Afreeca.Instance.Request("GetClanRanking");
		
	}
	
	
	private void MakeClanRankingListGrid() {
		
		int cellCount = 0 ;
		
		//UP
		if(_listPageNumber > 1){
		
			GameObject _go = Instantiate(_upDownRankListCellObject) as GameObject;
        	_go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			_upRankingListCell = _go.GetComponent<UpDownRankListCell>() as UpDownRankListCell ;
			_upRankingListCell.UpDownRankListCellEvent += UpDownRankListCellDelegate ;
		
			_upRankingListCell.InitLoadUpDownRankListCell(1) ; //up
			
			cellCount++ ;
			
		}else{
			if(_upRankingListCell != null){
				_upRankingListCell.UpDownRankListCellEvent += null ;
				_upRankingListCell = null ;
			}
			
		}
		
		
		
		for(int i = 0 ; i < AfreecaTvData.Instance.clanRanking.user_list.Count ; i++) {
			
			GameObject _go = Instantiate(_clanRankListCellObject) as GameObject;
            _go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			ClanRankListCell clanRankListCell = _go.GetComponent<ClanRankListCell>() as ClanRankListCell ;
			clanRankListCell.ClanRankListCellEvent += ClanRankListCellDelegate ;
			
			_clanRankListCellList.Add(clanRankListCell) ;
			
			
			AfreecaTvData.ClanRankingPlayer clanRankingPlayer = AfreecaTvData.Instance.clanRanking.user_list[i] ;
			
			clanRankListCell.InitLoadClanRankListCell(  (((_listPageNumber - 1) * Managers.GameBalanceData.ClanRankingListPageLimit) + (i+1))  , clanRankingPlayer) ;
			
			
			bool isExistID = false ;
			for(int j = 0 ; j < _getMessageBlockUserList.Count ; j++){
				if(clanRankingPlayer.user_id.Equals(_getMessageBlockUserList[j])){
					isExistID = true ;
					break ;
				}
			}
			
			
			if(isExistID){
				clanRankListCell.SetSendTorpedoButtonEnable(false);	
			}else{
				clanRankListCell.SetSendTorpedoButtonEnable(true);	
			}
			
			cellCount++ ;
			
		}
		
		
		//Down
		if(AfreecaTvData.Instance.clanRanking.more_yn.Equals("Y")){
			GameObject _go = Instantiate(_upDownRankListCellObject) as GameObject;
        	_go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			_downRankingListCell = _go.GetComponent<UpDownRankListCell>() as UpDownRankListCell ;
			_downRankingListCell.UpDownRankListCellEvent += UpDownRankListCellDelegate ;
		
			_downRankingListCell.InitLoadUpDownRankListCell(2) ; //up	
			
			cellCount++ ;
			
		}else{
			if(_downRankingListCell != null){
				_downRankingListCell.UpDownRankListCellEvent += null ;
				_downRankingListCell = null ;
			}
		}
		
		
		GetComponent<UIGrid>().Reposition();
		
		if(_clanRankingListGridDelegate != null){
			_clanRankingListGridDelegate(this, null, 1) ; 
			
			if(cellCount > _visibleCellNumber){
				_clanRankingListGridDelegate(this, null, 100001) ; //Scroll Able
			}else{
				_clanRankingListGridDelegate(this, null, 100002) ; //Scroll Disable
			}
			
		}
		
	}
	
	
	
	public void DeleteAllClanRankingListGrid(){
		
		if(_upRankingListCell != null){
			NGUITools.Destroy(_upRankingListCell.gameObject) ;
			_upRankingListCell = null ;	
		}
		
		if(_downRankingListCell != null){
			NGUITools.Destroy(_downRankingListCell.gameObject) ;
			_downRankingListCell = null ;
		}
		
		
		
		// Delete ClanRankListCell!!
		foreach(ClanRankListCell clanRankListCell in _clanRankListCellList){

			clanRankListCell.CellChildDestory() ;
			NGUITools.Destroy(clanRankListCell.gameObject) ;
			//clanRankListCell = null ;

		}
		_clanRankListCellList.Clear() ;
		//
		
		//GetComponent<UIGrid>().Reposition();
		
		//GetComponent<UIGrid>().repositionNow = true ;
		
		
		/*
		if(_clanRankingListGridDelegate != null){
			_clanRankingListGridDelegate(this, null, 1) ; 
		}
		*/

		//System.GC.Collect() ;

		System.GC.Collect(0,System.GCCollectionMode.Forced) ;

	}
	
	
}
