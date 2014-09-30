using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendMessagePanel : MonoBehaviour {

	private InboxPopupView m_InboxPopupView;

	public Object m_FriendMessageObject;
	//public UIDraggablePanel m_DraggablePanel;
	public UIButton m_ReceiveMessageButton;
	public UILabel m_NoMessageText;
	public UIGrid m_Grid;

	protected List<FriendMessageCell> m_FriendMessageCellList = new List<FriendMessageCell>();

	public void Init(InboxPopupView _view)
	{
//		m_InboxPopupView = _view;
//
//		Managers.UserData.SaveFriendMessageCheckTime();
//		//destroy current messages
//		for(int i = 0; i < m_FriendMessageCellList.Count; i++)
//		{
//			NGUITools.Destroy(m_FriendMessageCellList[i].gameObject);
//		}
//		m_FriendMessageCellList.Clear();
//
//		//make
//		List<KakaoLeaderBoard.ReciveGameMessage> receivedmessagelist = KakaoLeaderBoard.Instance.reciveGameMessages;
//#if UNITY_EDITOR
//		receivedmessagelist = new List<KakaoLeaderBoard.ReciveGameMessage>();
//#endif
//		for(int i = 0; i < receivedmessagelist.Count; i++)
//		{
//			KakaoLeaderBoard.ReciveGameMessage message = receivedmessagelist[i];
//			FriendMessageCell cell = (Instantiate(m_FriendMessageObject) as GameObject).GetComponent<FriendMessageCell>();
//			cell.transform.parent = m_Grid.transform;
//			cell.transform.localPosition = Vector3.forward * -10f;
//			cell.transform.localScale = Vector3.one;
//			cell.Init(message);
//			cell.ButtonDelegate += FriendMessageCellDelegate;
//			m_FriendMessageCellList.Add(cell);
//		}
//
//		m_Grid.Reposition();
//
//		if(receivedmessagelist.Count == 0)
//		{
//			m_NoMessageText.gameObject.SetActive(true);
//			m_ReceiveMessageButton.isEnabled = false;
//		}else
//		{
//			m_NoMessageText.gameObject.SetActive(false);
//			m_ReceiveMessageButton.isEnabled = true;
//		}
	}

	public void FriendMessageCellDelegate(FriendMessageCell _cell)
	{
		//Debug.Log("WTF?" + Managers.UserData.TorpedoCount);
		//if(Managers.UserData.TorpedoCount < 5)
		//{
		//Managers.KaKao.Event_Delegate_KakaoManager_AcceptMessage += (intNetworkResultCode_Input) => {
		//	//accept heart and remove from list
		//	if(intNetworkResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess)
		//	{
		//		//Managers.UserData.TorpedoCount += _cell.m_RecieveMessage.heart;
		//		//Managers.Torpedo.AddTorpedo(_cell.m_RecieveMessage.heart);
		//		NGUITools.Destroy(_cell.gameObject);
		//		m_Grid.Reposition();
		//		GameUIManager.Instance.LoadUIRootAlertView(1004);
		//
		//		Managers.KaKao.Event_Delegate_KakaoManager_ActionLoadGameMe += (int intResultCode_Input2) => 
		//		{
		//			if(intResultCode_Input2 == Constant.KAKAO_RESPONSE_CODE_Sucess)
		//			{
		//				GameUIManager.Instance.UpdateTorpedoUI();
		//			}
		//		};
		//		UpdatePanel();
		//		Managers.KaKao.ActionLoadGameMe();
		//		//Debug.Log("SUCCESS GETTING");
		//	}else
		//	{
		//		GameUIManager.Instance.LoadUIRootAlertView(1003);
		//		//Debug.Log("FAILED GETTING MESSAGE");
		//	}
		//};
		//
		//Managers.KaKao.ActionAcceptMessage(_cell.m_RecieveMessage.message_id);
		//}else
		//{
		//	GameUIManager.Instance.LoadUIRootAlertView(1005);
		//}
		m_InboxPopupView.UpdateNewMessage();
	}

	public void OnClickReceiveAllMessageButton()
	{
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//if(m_FriendMessageCellList.Count == 0)
		//{
		//	return;
		//}
		//
		//int TotalTorpedo = 0;
		//for(int i = 0; i < m_FriendMessageCellList.Count; i++)
		//{
		//	TotalTorpedo += m_FriendMessageCellList[i].m_RecieveMessage.heart;
		//}
		//if(KakaoLeaderBoard.Instance.gameMe.heart == KakaoLeaderBoard.Instance.gameInfo.max_heart)
		//{
		//	GameUIManager.Instance.LoadUIRootAlertView(1004);
		//}
		//
		//
		//Managers.KaKao.Event_Delegate_KakaoManager_AcceptAllMessage += (int intResultCode_Input) => 
		//{
		//	if(intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess)
		//	{
		//		//Managers.Torpedo.AddTorpedo(TotalTorpedo);
		//		for(int i = 0; i < m_FriendMessageCellList.Count; i++)
		//		{
		//			NGUITools.Destroy(m_FriendMessageCellList[i].gameObject);
		//		}
		//		m_Grid.Reposition();
		//		GameUIManager.Instance.LoadUIRootAlertView(1004);
		//
		//		Managers.KaKao.Event_Delegate_KakaoManager_ActionLoadGameMe += (int intResultCode_Input2) => 
		//		{
		//			if(intResultCode_Input2 == Constant.KAKAO_RESPONSE_CODE_Sucess)
		//			{
		//				GameUIManager.Instance.UpdateTorpedoUI();
		//			}
		//		};
		//		UpdatePanel();
		//		Managers.KaKao.ActionLoadGameMe();
		//		//Debug.Log("SUCCESS GETTING");
		//	}else
		//	{
		//		GameUIManager.Instance.LoadUIRootAlertView(1003);
		//		//Debug.Log("FAILED GETTING MESSAGE");
		//	}
		//};
		//
		//Managers.KaKao.ActionAcceptAllMessages();
		m_InboxPopupView.UpdateNewMessage();
	}

	public void UpdatePanel()
	{
		//do not load kakao, just updata views
		if(m_FriendMessageCellList.Count == 0)
		{
			m_NoMessageText.gameObject.SetActive(true);
			m_ReceiveMessageButton.isEnabled = false;
		}else
		{
			m_NoMessageText.gameObject.SetActive(false);
			m_ReceiveMessageButton.isEnabled = true;
		}
	}
}
