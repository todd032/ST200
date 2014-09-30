using UnityEngine;
using System.Collections;

public class ClanMasterRankingPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanMasterRankingPanelDelegate(ClanMasterRankingPanel clanMasterRankingPanel, ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state);
	protected ClanMasterRankingPanelDelegate _clanMasterRankingPanelDelegate ;
	public event ClanMasterRankingPanelDelegate ClanMasterRankingPanelEvnet {
		add{
			
			_clanMasterRankingPanelDelegate = null ;
			
			if (_clanMasterRankingPanelDelegate == null)
        		_clanMasterRankingPanelDelegate += value;
        }
		
		remove{
            _clanMasterRankingPanelDelegate -= value;
		}
	}
	
	[HideInInspector]
	public delegate void ClanMyMasterRankingPanelDelegate(ClanMasterRankingPanel clanMasterRankingPanel, MyMasterRankingPanel myMasterRankingPanel, int state);
	protected ClanMyMasterRankingPanelDelegate _clanMyMasterRankingPanelDelegate ;
	public event ClanMyMasterRankingPanelDelegate ClanMyMasterRankingPanelEvent {
		add{
			
			_clanMyMasterRankingPanelDelegate = null ;
			
			if (_clanMyMasterRankingPanelDelegate == null)
        		_clanMyMasterRankingPanelDelegate += value;
        }
		
		remove{
            _clanMyMasterRankingPanelDelegate -= value;
		}
	}
	
	
	public ClanRankingListPanel _clanRankingListPanel ;
	public MyMasterRankingPanel _myMasterRankingPanel ;
	
	private bool _isOnce = false ; //Imsy
	
	private void Awake() {
		_clanRankingListPanel.ClanRankingListPanelEvent += ClanRankingListPanelDelegate ;
		_myMasterRankingPanel.MyMasterRankingPanelEvent += MyMasterRankingPanelDelegate ;
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	
	//Delegate
	private void ClanRankingListPanelDelegate(ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state) {
		if(_clanMasterRankingPanelDelegate != null){
			_clanMasterRankingPanelDelegate(this, clanRankingListPanel, clanRankingListGrid, clanRankListCell, state) ;
		}
	}
	
	private void MyMasterRankingPanelDelegate(MyMasterRankingPanel myMasterRankingPanel, int state) {
		if(_clanMyMasterRankingPanelDelegate != null){
			_clanMyMasterRankingPanelDelegate(this, myMasterRankingPanel, state) ;
		}
	}
	
	
	public void LoadClanMasterRankingPanel(){
		
		if(!_isOnce){ // 랭킹정보 최초 실행부.
			
			_myMasterRankingPanel.LoadMyMasterRankingPanel() ;
			
			_clanRankingListPanel.LoadClanRankingListPanel() ;
			_isOnce = true ;
			
		}else{
			// 내 정보 부분은 최초 실행 후 최고점수 부분만 갱신해 준다.
			//_myMasterRankingPanel.ReloadScoreMyMasterRankingPanel() ;
			
		}
	
	}

}
