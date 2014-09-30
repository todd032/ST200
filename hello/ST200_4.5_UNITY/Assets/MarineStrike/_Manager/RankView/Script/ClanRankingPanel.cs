using UnityEngine;
using System.Collections;

public class ClanRankingPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanRankingPanelDelegate(ClanRankingPanel clanRankingPanel, ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state);
	protected ClanRankingPanelDelegate _clanRankingPanelDelegate ;
	public event ClanRankingPanelDelegate ClanRankingPanelEvent {
		add{
			
			_clanRankingPanelDelegate = null ;
			
			if (_clanRankingPanelDelegate == null)
        		_clanRankingPanelDelegate += value;
        }
		
		remove{
            _clanRankingPanelDelegate -= value;
		}
	}
	
	
	
	
	public ClanRankingListPanel _clanRankingListPanel ;
	public MyRankingPanel _myRankingPanel ;
	
	private bool _isOnce = false ; //Imsy
	
	private void Awake() {
		
		_clanRankingListPanel.ClanRankingListPanelEvent += ClanRankingListPanelDelegate ;
		_myRankingPanel.MyRankingPanelEvent += MyRankingPanelDelegate ;
		
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	
	//Delegate
	private void ClanRankingListPanelDelegate(ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state) {
		if(_clanRankingPanelDelegate != null){
			_clanRankingPanelDelegate(this, clanRankingListPanel, clanRankingListGrid, clanRankListCell, state) ;
		}
	}
	
	private void MyRankingPanelDelegate(MyRankingPanel myRankingPanel, int state) {
		if(_clanRankingPanelDelegate != null){
			_clanRankingPanelDelegate(this, null, null, null, state) ;
		}
	}
	
	
	public void LoadClanRankingPanel(){
		
		if(!_isOnce){ // 랭킹정보 최초 실행부.
			
			_myRankingPanel.LoadMyRankingPanel() ;
			
			_clanRankingListPanel.LoadClanRankingListPanel() ;	
			_isOnce = true ;
			
		}else{
			// 내 정보 부분은 최초 실행 후 최고점수 부분만 갱신해 준다.
			//_myRankingPanel.ReloadScoreMyRankingPanel() ;
			
		}
		
	}

	
}
