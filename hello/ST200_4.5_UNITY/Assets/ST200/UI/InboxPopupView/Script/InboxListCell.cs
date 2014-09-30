using UnityEngine;
using System.Collections;

public class InboxListCell : MonoBehaviour {

	[HideInInspector]
	public delegate void InboxListCellDelegate(InboxListCell inboxListCell, int state);
	protected InboxListCellDelegate _inboxListCellDelegate ;
	public event InboxListCellDelegate InboxListCellEvent {
		add{
			
			_inboxListCellDelegate = null ;
			
			if (_inboxListCellDelegate == null)
        		_inboxListCellDelegate += value;
        }
		
		remove{
            _inboxListCellDelegate -= value;
		}
	}
	
	
	
	public UILabel _inboxListCellMessageLabel ;
	public GameObject _presentReceiveButton ;
	public UILabel m_ReceiveLabel;
	
	private InboxPopupView.GetMessageListDataStruct _getMessageListDataStruct ;
	public  InboxPopupView.GetMessageListDataStruct GetMessageListData {
		get { return _getMessageListDataStruct ; } 
	}

	
	private void Awake() {
		m_ReceiveLabel.text = Constant.COLOR_MAIL_RECEIVE + TextManager.Instance.GetString(81);
	}
	
	private void Start() {
		
	}
	
	private void Update() {
	
	}
	
	public void InitLoadInboxListCell(InboxPopupView.GetMessageListDataStruct getMessageListDataStruct){
		
		_getMessageListDataStruct = getMessageListDataStruct ;
		
		_inboxListCellMessageLabel.text = Constant.COLOR_MAIL_ITEMINFO + getMessageListDataStruct.MessageTitle ;

		if(int.Parse(getMessageListDataStruct.ItemCode) == 0)
		{
			_presentReceiveButton.gameObject.SetActive(false);
		}else
		{
			_presentReceiveButton.gameObject.SetActive(true	);
		}

		/*
		string itemCode = "" ;
		if(getMessageListDataStruct.ItemCode.Equals("1")){
			itemCode = "어뢰" ;
		}
		
		_inboxListCellMessageLabel.text = getMessageListDataStruct.SenderNickname + "님께서 " + itemCode + "를 보내셨습니다." ;
		*/
		
	}
	
	public void OnClickPresentReceiveButton(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common, false);
		
		if(_inboxListCellDelegate != null){
			_inboxListCellDelegate(this, 100) ;	
		}
		
	}


}
