using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class InboxListGrid : MonoBehaviour {

	[HideInInspector]
	public delegate void InboxListGridDelegate(InboxListGrid inboxListGrid, InboxListCell inboxListCell, int state);
	protected InboxListGridDelegate _inboxListGridDelegate ;
	public event InboxListGridDelegate InboxListGridEvent {
		add{
			
			_inboxListGridDelegate = null ;
			
			if (_inboxListGridDelegate == null)
        		_inboxListGridDelegate += value;
        }
		
		remove{
            _inboxListGridDelegate -= value;
		}
	}

	
	///
	public GameObject _inboxListCellObject ;
	private List<InboxListCell> _inboxListCellList ;
	///
	
	
	private void Awake() {
		_inboxListCellList = new List<InboxListCell>() ;
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	
	//Delegate
	private void InboxListCellDelegate(InboxListCell inboxListCell, int state) {
		if(_inboxListGridDelegate != null){
			_inboxListGridDelegate(this, inboxListCell, state) ; // 100 : 선물 받기 버튼 클릭!!
		}
	}
	
	
	public void InitLoadInboxListGrid(List<InboxPopupView.GetMessageListDataStruct> getMessageListDataList){
		
		for(int i = 0 ; i < getMessageListDataList.Count ; i++) {
			
			GameObject _go = Instantiate(_inboxListCellObject) as GameObject;
            _go.transform.parent = this.transform;
			_go.transform.localPosition = Vector3.zero ;
			_go.transform.localScale = new Vector3(1f, 1f, 1f);
			
			
			InboxListCell inboxListCell = _go.GetComponent<InboxListCell>() as InboxListCell ;
			inboxListCell.InboxListCellEvent += InboxListCellDelegate ;
			
			_inboxListCellList.Add(inboxListCell) ;
			
			InboxPopupView.GetMessageListDataStruct getMessageListDataStruct = getMessageListDataList[i] ;
			inboxListCell.InitLoadInboxListCell(getMessageListDataStruct) ;
		}
		
		GetComponent<UIGrid>().Reposition();
		
	}
	
	public void DeleteInboxListCell(InboxListCell inboxListCell){
		
		// Delete InboxListCell!!
		_inboxListCellList.Remove(inboxListCell) ;
		NGUITools.Destroy(inboxListCell.gameObject) ;
		//
		
		GetComponent<UIGrid>().Reposition();
		
	}
	
	
	public void DeleteAllInboxListGrid(bool _receiveall){
		
		// Delete InboxListCell!!
		for(int i = 0; i < _inboxListCellList.Count;)
		{	
			InboxListCell cell = _inboxListCellList[i];
			if(int.Parse(cell.GetMessageListData.ItemCode) == 0 && _receiveall)
			{
				i++;
			}else
			{
				NGUITools.Destroy(cell.gameObject);
				_inboxListCellList.RemoveAt(i);
			}
		}
		//_inboxListCellList.Clear() ;
		//
		
		GetComponent<UIGrid>().Reposition();
		
	}
}
