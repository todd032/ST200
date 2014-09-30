using UnityEngine;
using System.Collections;

public class FriendMessageCell : MonoBehaviour {

	[HideInInspector] 
	public delegate void FriendMessageCellButtonDelegate(FriendMessageCell _cell);
	protected FriendMessageCellButtonDelegate m_ButtonDelegate;
	public event FriendMessageCellButtonDelegate ButtonDelegate
	{
		add
		{
			m_ButtonDelegate = null;
			m_ButtonDelegate += value;
		}
		remove
		{
			m_ButtonDelegate -= value;
		}
	}
	
	public UITexture m_PlayerImage;
	public UILabel m_TextLabel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//public KakaoLeaderBoard.ReciveGameMessage m_RecieveMessage;
	//public void Init(KakaoLeaderBoard.ReciveGameMessage _recieveMessage)
	//{
	//	m_RecieveMessage = _recieveMessage;
	//
	//	m_PlayerImage.mainTexture = null;
	//	m_TextLabel.text = m_RecieveMessage.message;
	//	StartCoroutine(Network_DownloadImage_Profile(m_RecieveMessage.sender_profile_image_url));
	//}

	public void OnClickReceiveButton()
	{
		if(m_ButtonDelegate != null)
		{
			m_ButtonDelegate(this);
		}
	}

	IEnumerator Network_DownloadImage_Profile(string strImageUrl_Input){
		
		//if (strImageUrl_Input != null && !strImageUrl_Input.Equals("")){
		//	
		//	WWW www = new WWW(strImageUrl_Input);
		//	yield return www;
		//	
		//	Texture2D m_Tex2DProfile = www.texture;
		//	
		//	if (m_Tex2DProfile != null){
		//		
		//		m_PlayerImage.mainTexture = m_Tex2DProfile;
		//	}
		//	
		//	www.Dispose();
		//}
		ImageResourceManager.Instance.AddQueue(strImageUrl_Input, m_PlayerImage);
		yield break;
	}
}
