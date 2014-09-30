using UnityEngine;
using System.Collections;

public class TopRankingListPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void TopRankingListPanelDelegate(TopRankingListPanel topRankingListPanel, TopRankingListGrid topRankingListGrid, TopRankListCell topRankListCell, int state);
	protected TopRankingListPanelDelegate _topRankingListPanelDelegate ;
	public event TopRankingListPanelDelegate TopRankingListPanelEvent {
		add{
			
			_topRankingListPanelDelegate = null ;
			
			if (_topRankingListPanelDelegate == null)
        		_topRankingListPanelDelegate += value;
        }
		
		remove{
            _topRankingListPanelDelegate -= value;
		}
	}
	
	public TopRankingListGrid _topRankingListGrid ;
	
	private void Awake() {
		
		_topRankingListGrid.TopRankingListGridEvent += TopRankingListGridDelegate ;
		
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	//Delegate
	private void TopRankingListGridDelegate(TopRankingListGrid topRankingListGrid, TopRankListCell topRankListCell, int state){
		
		if(state == 1){
			//GetComponent<UIDraggablePanel>().ResetPosition() ;
		}else if(state == 100001){ //Scroll Able
			
			//GetComponent<UIDraggablePanel>().enabled = true ;
			
		}else if(state == 100002){ //Scroll Disable
			
			//GetComponent<UIDraggablePanel>().enabled = false ;
			
		}else{
			if(_topRankingListPanelDelegate != null){
				_topRankingListPanelDelegate(this, topRankingListGrid, topRankListCell, state) ;
			}
		}
		
	}
	
	public void LoadTopRankingListPanel(){
		_topRankingListGrid.InitLoadTopRankingListGrid() ;
	}
	
	public void ReloadTopRankingListPanel(){
		_topRankingListGrid.ReloadTopRankingListGrid() ;
	}
	
}
