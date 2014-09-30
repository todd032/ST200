using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class TopRankingListGrid : MonoBehaviour {

	[HideInInspector]
	public delegate void TopRankingListGridDelegate(TopRankingListGrid topRankingListGrid, TopRankListCell topRankListCell, int state);
	protected TopRankingListGridDelegate _topRankingListGridDelegate ;
	public event TopRankingListGridDelegate TopRankingListGridEvent {
		add{
			
			_topRankingListGridDelegate = null ;
			
			if (_topRankingListGridDelegate == null)
        		_topRankingListGridDelegate += value;
        }
		
		remove{
            _topRankingListGridDelegate -= value;
		}
	}
	
	
	///
	public GameObject _topRankListCellObject ;
	private List<TopRankListCell> _topRankListCellList ;
	
	public GameObject _upDownRankListCellObject ;
	private UpDownRankListCell _upRankingListCell ;
	private UpDownRankListCell _downRankingListCell ;
	///
	
	
	private int _listPageNumber = 1 ;
	
	public int _visibleCellNumber = 5 ;
	
	private void Awake() {
		_topRankListCellList = new List<TopRankListCell>() ;
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	
	//Delegate
	private void TopRankListCellDelegate(TopRankListCell topRankListCell, int state) {
		if(_topRankingListGridDelegate != null){
			_topRankingListGridDelegate(this, topRankListCell, state) ; 
		}
	}
	
	private void UpDownRankListCellDelegate(UpDownRankListCell upDownRankListCell, int upDownState){
		if(upDownState == 1){ //Up Click
			
			if(_listPageNumber > 1){
				
				DeleteAllClanRankingListGrid() ;
				
				_listPageNumber -= 1 ;	
				
				ConnectRankingList() ;	
				
			}
			
		}else if(upDownState == 2){ //Down Click
			
			if(AfreecaTvData.Instance.topRanking.more_yn.Equals("Y")){
			
				DeleteAllClanRankingListGrid() ;
				
				_listPageNumber += 1 ;	
				
				ConnectRankingList() ;
				
			}
			
		}if(upDownState == 3){ //Up Click
			
			if(_listPageNumber > 1){
				
				DeleteAllClanRankingListGrid() ;
				
				_listPageNumber -= 1 ;	
				
				ConnectRankingList() ;	
				
			}
			
		}else if(upDownState == 4){ //Down Click
			
			if(AfreecaTvData.Instance.topRanking.more_yn.Equals("Y")){
			
				DeleteAllClanRankingListGrid() ;
				
				_listPageNumber += 1 ;	
				
				ConnectRankingList() ;
				
			}
			
		}
	}
	
	
	public void InitLoadTopRankingListGrid(){ // input List?? ,  MORE_YN :다음 페이지 존재의 여부
		ConnectRankingList() ;
	}
	
	public void ReloadTopRankingListGrid(){
		DeleteAllClanRankingListGrid() ;
		ConnectRankingList() ;
	}
	
	private void ConnectRankingList() {
		
		// Connect Indicator Start..
		if(_topRankingListGridDelegate != null){
			_topRankingListGridDelegate(this, null, 1001) ;  // 1001 : Ranking Indicator Start!!
		}
		
		
		NativeHelper_Afreeca.Instance.AfreecaTVConnectCompleteEvent += (returnAction) => {
			if(returnAction.Equals("GetTopRanking")){
			
				MakeTopRankingListGrid() ;
				
				// Connect Indicator Stop..
				if(_topRankingListGridDelegate != null){
					_topRankingListGridDelegate(this, null, 1002) ;  // 1002 : Ranking Indicator Stop!!
				}
			}
		} ;
		
		NativeHelper_Afreeca.Instance.AfreecaTVConnectErrorEvent += (returnAction, errorCode, errorMessage) => {
			if(returnAction.Equals("GetTopRanking")){
			
				//Error..
				
				// Connect Indicator Stop..
				if(_topRankingListGridDelegate != null){
					_topRankingListGridDelegate(this, null, 1002) ;  // 1002 : Ranking Indicator Stop!!
				}
			}	
		} ;
		
		
		
		NativeHelper_Afreeca.Instance.paramPageNumber = _listPageNumber ;
		NativeHelper_Afreeca.Instance.paramPageLimit = Managers.GameBalanceData.TopRankingListPageLimit ;
		NativeHelper_Afreeca.Instance.Request("GetTopRanking");
		
	}
	
	private void MakeTopRankingListGrid() {
		
		int cellCount = 0 ;
		
		//UP
		if(_listPageNumber > 1){
		
			GameObject _go = Instantiate(_upDownRankListCellObject) as GameObject;
        	_go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			_upRankingListCell = _go.GetComponent<UpDownRankListCell>() as UpDownRankListCell ;
			_upRankingListCell.UpDownRankListCellEvent += UpDownRankListCellDelegate ;
		
			_upRankingListCell.InitLoadUpDownRankListCell(3) ; //up
			
			cellCount++ ;
			
		}else{
			if(_upRankingListCell != null){
				_upRankingListCell.UpDownRankListCellEvent += null ;
				_upRankingListCell = null ;
			}
			
		}
		
		
		for(int i = 0 ; i < AfreecaTvData.Instance.topRanking.user_list.Count ; i++) {
			
			GameObject _go = Instantiate(_topRankListCellObject) as GameObject;
            _go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			TopRankListCell topRankListCell = _go.GetComponent<TopRankListCell>() as TopRankListCell ;
			topRankListCell.TopRankListCellEvent += TopRankListCellDelegate ;
			
			_topRankListCellList.Add(topRankListCell) ;
			
			AfreecaTvData.TopRankingPlayer topRankingPlayer = AfreecaTvData.Instance.topRanking.user_list[i] ;
			
			topRankListCell.InitLoadTopRankListCell(  (((_listPageNumber - 1) * Managers.GameBalanceData.TopRankingListPageLimit ) + (i+1))  , topRankingPlayer) ;
			
			cellCount++ ;
			
		}
		
		
		//Down
		if(AfreecaTvData.Instance.topRanking.more_yn.Equals("Y")){
			GameObject _go = Instantiate(_upDownRankListCellObject) as GameObject;
        	_go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			_downRankingListCell = _go.GetComponent<UpDownRankListCell>() as UpDownRankListCell ;
			_downRankingListCell.UpDownRankListCellEvent += UpDownRankListCellDelegate ;
		
			_downRankingListCell.InitLoadUpDownRankListCell(4) ;	
			
			cellCount++ ;
			
		}else{
			if(_downRankingListCell != null){
				_downRankingListCell.UpDownRankListCellEvent += null ;
				_downRankingListCell = null ;
			}
		}
		
		
		GetComponent<UIGrid>().Reposition();
		
		if(_topRankingListGridDelegate != null){
			_topRankingListGridDelegate(this, null, 1) ; 
			
			if(cellCount > _visibleCellNumber){
				_topRankingListGridDelegate(this, null, 100001) ; //Scroll Able
			}else{
				_topRankingListGridDelegate(this, null, 100002) ; //Scroll Disable
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
		foreach(TopRankListCell topRankListCell in _topRankListCellList){
			topRankListCell.CellChildDestory() ;
			NGUITools.Destroy(topRankListCell.gameObject) ;
			//topRankListCell = null ;
		}
		_topRankListCellList.Clear() ;
		//
		
		/*
		if(_topRankingListGridDelegate != null){
			_topRankingListGridDelegate(this, null, 1) ; 
		}
		
		GetComponent<UIGrid>().Reposition();
		*/

		//System.GC.Collect() ;

		System.GC.Collect(0,System.GCCollectionMode.Forced) ;

	}
	
}
