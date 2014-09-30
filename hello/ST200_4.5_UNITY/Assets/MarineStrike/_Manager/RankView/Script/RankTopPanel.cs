using UnityEngine;
using System.Collections;

public class RankTopPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void RankTopPanelDelegate(RankTopPanel rankTopPanel, int state);
	protected RankTopPanelDelegate _rankTopPanelDelegate ;
	public event RankTopPanelDelegate RankTopPanelEvent {
		add{
			
			_rankTopPanelDelegate = null ;
			
			if (_rankTopPanelDelegate == null)
        		_rankTopPanelDelegate += value;
        }
		
		remove{
            _rankTopPanelDelegate -= value;
		}
	}
	
	public TopRankingPanel _topRankingPanel ;
	
	private void Awake() {
		_topRankingPanel.TopRankingPanelEvent += TopRankingPanelDelegate ;
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	
	//Delegate
	private void TopRankingPanelDelegate(TopRankingPanel topRankingPanel, TopRankingListPanel topRankingListPanel, TopRankingListGrid topRankingListGrid, TopRankListCell topRankListCell, int state){
		 if(state == 1001) { // 1001 : Ranking Indicator Start!!
			if(_rankTopPanelDelegate != null){
				_rankTopPanelDelegate(this, state) ;
			}
		}else if(state == 1002) { // 1002 : Ranking Indicator Stop!!
			if(_rankTopPanelDelegate != null){
				_rankTopPanelDelegate(this, state) ;
			}
		}
	}
	
	
	public void LoadRankTopPanel(){
		_topRankingPanel.LoadTopRankingPanel() ;
	}
	
}
