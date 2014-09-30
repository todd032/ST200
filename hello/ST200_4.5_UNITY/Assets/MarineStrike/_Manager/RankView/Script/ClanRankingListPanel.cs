using UnityEngine;
using System.Collections;

public class ClanRankingListPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void ClanRankingListPanelDelegate(ClanRankingListPanel clanRankingListPanel, ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state);
	protected ClanRankingListPanelDelegate _clanRankingListPanelDelegate ;
	public event ClanRankingListPanelDelegate ClanRankingListPanelEvent {
		add{
			
			_clanRankingListPanelDelegate = null ;
			
			if (_clanRankingListPanelDelegate == null)
        		_clanRankingListPanelDelegate += value;
        }
		
		remove{
            _clanRankingListPanelDelegate -= value;
		}
	}
	
	public ClanRankingListGrid _clanRankingListGrid ;
	
	
	private void Awake() {
		_clanRankingListGrid.ClanRankingListGridEvent += ClanRankingListGridDelegate ;
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	//Delegate
	private void ClanRankingListGridDelegate(ClanRankingListGrid clanRankingListGrid, ClanRankListCell clanRankListCell, int state) {
		
		if(state ==1){
			
			//GetComponent<UIDraggablePanel>().ResetPosition() ;
			
		}else if(state == 100001){ //Scroll Able
			
			//GetComponent<UIDraggablePanel>().enabled = true ;
			
		}else if(state == 100002){ //Scroll Disable
			
			//GetComponent<UIDraggablePanel>().enabled = false ;
			
		}else{
		
			if(_clanRankingListPanelDelegate != null){
				_clanRankingListPanelDelegate(this, clanRankingListGrid, clanRankListCell, state) ;
			}
			
		}
		
	}
	
	public void LoadClanRankingListPanel(){
		_clanRankingListGrid.InitLoadClanRankingListGrid() ;
	}
	
	
}
