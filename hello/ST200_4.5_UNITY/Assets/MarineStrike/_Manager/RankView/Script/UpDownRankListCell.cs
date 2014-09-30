using UnityEngine;
using System.Collections;

public class UpDownRankListCell : MonoBehaviour {
	
	[HideInInspector]
	public delegate void UpDownRankListCellDelegate(UpDownRankListCell upDownRankListCell, int upDownState);
	protected UpDownRankListCellDelegate _upDownRankListCellDelegate ;
	public event UpDownRankListCellDelegate UpDownRankListCellEvent {
		add{
			
			_upDownRankListCellDelegate = null ;
			
			if (_upDownRankListCellDelegate == null)
        		_upDownRankListCellDelegate += value;
        }
		
		remove{
            _upDownRankListCellDelegate -= value;
		}
	}
	
	
	public UILabel _cellInfoLabel ;
	public UISprite _upDownRankListCellBackground ;
	
	private int _upDownState ; // 1: UP   2:Down
	
	
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	
	public void InitLoadUpDownRankListCell(int upDownState){
		
		_upDownState = upDownState ;
		
		if(upDownState == 1){ // 1: UP 
			
			_cellInfoLabel.text = Managers.GameBalanceData.ClanRankingListPageLimit + "개씩 이동합니다." ;
			_upDownRankListCellBackground.spriteName = "Btn_RankList_Up10" ;
			
		}else if(upDownState == 2){ // 2:Down
			_cellInfoLabel.text = Managers.GameBalanceData.ClanRankingListPageLimit + "개씩 이동합니다." ;
			_upDownRankListCellBackground.spriteName = "Btn_RankList_Down10" ;
			
		}else if(upDownState == 3){ // 1: UP 
			
			_cellInfoLabel.text = Managers.GameBalanceData.TopRankingListPageLimit + "개씩 이동합니다." ;
			_upDownRankListCellBackground.spriteName = "Btn_RankList_Up10" ;
			
		}else if(upDownState == 4){ // 2:Down
			_cellInfoLabel.text = Managers.GameBalanceData.TopRankingListPageLimit + "개씩 이동합니다." ;
			_upDownRankListCellBackground.spriteName = "Btn_RankList_Down10" ;
			
		}
		
	}
	
	private void OnClickUpDownButton(){
		if(_upDownRankListCellDelegate != null){
			_upDownRankListCellDelegate(this, 	_upDownState) ;
		}
	}
	
}
