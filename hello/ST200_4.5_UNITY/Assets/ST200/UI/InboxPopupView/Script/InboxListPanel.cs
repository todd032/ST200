using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class InboxListPanel : MonoBehaviour {

	[HideInInspector]
	public delegate void InboxListPanelDelegate(InboxListPanel inboxListPanel, InboxListGrid inboxListGrid, InboxListCell inboxListCell, int state) ;
	protected InboxListPanelDelegate _inboxListPanelDelegate ;
	public event InboxListPanelDelegate InboxListPanelEvent {
		add{
			
			_inboxListPanelDelegate = null ;
			
			if (_inboxListPanelDelegate == null)
        		_inboxListPanelDelegate += value;
        }
		
		remove{
            _inboxListPanelDelegate -= value;
		}
	}
	
	public InboxListGrid _inboxListGrid ;
	public UIScrollView m_ScorllView;
	private void Awake() {
		
		_inboxListGrid.InboxListGridEvent += InboxListGridDelegate ;
		
	}
	
	private void Start() {
	}
	
	private void Update() {
	}
	
	//Delegate
	private void InboxListGridDelegate(InboxListGrid inboxListGrid, InboxListCell inboxListCell, int state) {
		if(_inboxListPanelDelegate != null){
			_inboxListPanelDelegate(this, inboxListGrid, inboxListCell, state) ;
		}
	}
	
	
	public void LoadInboxListPanel(List<InboxPopupView.GetMessageListDataStruct> getMessageListDataList){
		_inboxListGrid.InitLoadInboxListGrid(getMessageListDataList) ;
		m_ScorllView.ResetPosition();
	}
	
	public void DeleteInboxListCell(InboxListCell inboxListCell){
		_inboxListGrid.DeleteInboxListCell(inboxListCell) ;
	}
	
	public void DeleteAllInboxListGrid(bool _receiveall){
		_inboxListGrid.DeleteAllInboxListGrid(_receiveall) ;
	}
	
	
}
