using UnityEngine;
using System.Collections;

public class InvitationList_Cell_Item : MonoBehaviour {

	// ==================== Layout 관련 변수 선언 - Start ====================
	public UISprite m_Invite_BG_Sprite;
	public UITexture m_Invite_Pforile_Texture;
	public UILabel m_Invite_NickName_Label;

	public UIButton m_Invite_Button;
	public UISprite m_Invite_BtnBG_Sprite;
	// ==================== Layout 관련 변수 선언 - End ====================

	// ==================== 기타 변수 선언 - Start ====================
	//private Texture2D m_Tex2DProfile;
	private Data_InvitationList_Cell m_data_InvitationList_Cell;

	private int m_intListNo;


	// ==================== 기타 변수 선언 - End ====================

	[HideInInspector]
	public delegate void Delegate_InvitationList_Cell_Item(string strUserID_Input, string strUserNickName_Input, int intListNo_Input);
	protected Delegate_InvitationList_Cell_Item _delegate_InvitationList_Cell_Item;
	public event Delegate_InvitationList_Cell_Item Event_Delegate_InvitationList_Cell_Item{
		add {
			_delegate_InvitationList_Cell_Item = null;
			if (_delegate_InvitationList_Cell_Item == null){
				_delegate_InvitationList_Cell_Item += value;
			}
		}
		remove {
			_delegate_InvitationList_Cell_Item -= value;
		}
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Init(Data_InvitationList_Cell _data_InvitationList_Cell_Input, int intListNo_Input){

		Init_01_Initialize_Variable(_data_InvitationList_Cell_Input, intListNo_Input);
		Init_02_Set_UserInfo();

	}

	private void Init_01_Initialize_Variable(Data_InvitationList_Cell _data_InvitationList_Cell_Input, int intListNo_Input){

		m_data_InvitationList_Cell = _data_InvitationList_Cell_Input;
		m_intListNo = intListNo_Input;
		//m_Tex2DProfile = new Texture2D(50 , 50);
	}

	private void Init_02_Set_UserInfo(){

		// 프로필 이미지.
		if (m_data_InvitationList_Cell.strUserInfo_ProfileImageUrl == null ||
		    m_data_InvitationList_Cell.strUserInfo_ProfileImageUrl.Equals("")){
			
			Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
			m_Invite_Pforile_Texture.mainTexture = basicTexture;
			
		} else {
			
			StartCoroutine(Network_DownloadImage_Profile(m_data_InvitationList_Cell.strUserInfo_ProfileImageUrl));
		}

		// 닉네임.
		m_Invite_NickName_Label.text = m_data_InvitationList_Cell.strUserInfo_NickName;

		// 초대버튼 활성화 여부.
		if (!m_data_InvitationList_Cell.boolUserInfo_SupportedDevice
		    || m_data_InvitationList_Cell.boolUserInfo_MessageBlocked) {

			m_Invite_Button.isEnabled = false;
			m_Invite_BtnBG_Sprite.spriteName = "invitation_invitebutton_dark";

		} else {

			m_Invite_Button.isEnabled = true;
			m_Invite_BtnBG_Sprite.spriteName = "invitation_invitebutton";
		}

//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.strUserInfo_UserId = " + m_data_InvitationList_Cell.strUserInfo_UserId);
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.strUserInfo_NickName = " + m_data_InvitationList_Cell.strUserInfo_NickName);
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.strUserInfo_ProfileImageUrl = " + m_data_InvitationList_Cell.strUserInfo_ProfileImageUrl);
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.strUserInfo_FriendNickname = " + m_data_InvitationList_Cell.strUserInfo_FriendNickname);
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.boolUserInfo_MessageBlocked = " + m_data_InvitationList_Cell.boolUserInfo_MessageBlocked.ToString());
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.boolUserInfo_SupportedDevice = " + m_data_InvitationList_Cell.boolUserInfo_SupportedDevice.ToString());
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.intUserInfo_LastMessageSentAt = " + m_data_InvitationList_Cell.intUserInfo_LastMessageSentAt.ToString());
//		Debug.Log ("ST110 InvitationList_Cell_Item.Init_02_Set_UserInfo().m_data_InvitationList_Cell.boolUserInfo_MessageSent = " + m_data_InvitationList_Cell.boolUserInfo_MessageSent);

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
		//		m_Invite_Pforile_Texture.mainTexture = m_Tex2DProfile;
		//	}
		//	
		//	www.Dispose();
		//}
		ImageResourceManager.Instance.AddQueue(strImageUrl_Input, m_Invite_Pforile_Texture);
		yield break;
	}
	


	private void OnClick_Invite(){

//		Debug.Log ("InvitationList_Cell_Item.OnClick_Invite() Run!!!!!");
		if (_delegate_InvitationList_Cell_Item != null){
			_delegate_InvitationList_Cell_Item(m_data_InvitationList_Cell.strUserInfo_UserId, m_data_InvitationList_Cell.strUserInfo_NickName, m_intListNo);
		}
	}


}
