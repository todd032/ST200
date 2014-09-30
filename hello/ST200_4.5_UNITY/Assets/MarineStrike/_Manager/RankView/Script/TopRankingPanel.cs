using UnityEngine;
using System.Collections;

public class TopRankingPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void TopRankingPanelDelegate(TopRankingPanel topRankingPanel, TopRankingListPanel topRankingListPanel, TopRankingListGrid topRankingListGrid, TopRankListCell topRankListCell, int state);
	protected TopRankingPanelDelegate _topRankingPanelDelegate ;
	public event TopRankingPanelDelegate TopRankingPanelEvent {
		add{
			
			_topRankingPanelDelegate = null ;
			
			if (_topRankingPanelDelegate == null)
        		_topRankingPanelDelegate += value;
        }
		
		remove{
            _topRankingPanelDelegate -= value;
		}
	}
	
	
	
	
	public TopRankingListPanel _topRankingListPanel ;
	
	
	private bool _isOnce = false ; //Imsy
	
	
	private void Awake() {
		_topRankingListPanel.TopRankingListPanelEvent += TopRankingListPanelDelegate ;
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	
	//Delegate
	private void TopRankingListPanelDelegate(TopRankingListPanel topRankingListPanel, TopRankingListGrid topRankingListGrid, TopRankListCell topRankListCell, int state) {
		if(_topRankingPanelDelegate != null){
			_topRankingPanelDelegate(this, topRankingListPanel, topRankingListGrid, topRankListCell, state) ;
		}
	}
	
	
	public void LoadTopRankingPanel(){
		
		if(!_isOnce){ // 랭킹정보 최초 실행부.
			
			_topRankingListPanel.LoadTopRankingListPanel() ;
			_isOnce = true ;
			
		}else{
			
			_topRankingListPanel.ReloadTopRankingListPanel() ;
			
		}
		
	}
	
}
