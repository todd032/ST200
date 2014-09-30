using UnityEngine;
using System.Collections;

public class BoastList_Cell_Item : MonoBehaviour {

	// ==================== Layout 관련 변수 선언 - Start ====================
	public UITexture m_Boast_Pforile_Texture;
	public UILabel m_Boast_NickName_Label;
	public UIButton m_Boast_Button;
	public UISprite m_Boast_Btn_BG_Sprite;
	// ==================== Layout 관련 변수 선언 - End ====================

	// ==================== 기타 변수 선언 - Start ====================
	private Data_InvitationList_Cell m_data_BoastList_Cell;

	// ==================== 기타 변수 선언 - End ====================
	
	// ==================== Delegate & Event 인터페이스 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_BoastList_Cell_Item(string strUserId_Input);
	protected Delegate_BoastList_Cell_Item _delegate_BoastList_Cell_Item ;
	public event Delegate_BoastList_Cell_Item Event_Delegate_BoastList_Cell_Item {
		add {
			_delegate_BoastList_Cell_Item = null;
			if (_delegate_BoastList_Cell_Item == null){
				_delegate_BoastList_Cell_Item += value;
			}
		}
		remove {
			_delegate_BoastList_Cell_Item -= value;
		}
	}
	// ==================== Delegate & Event 인터페이스 선언 - End ====================

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	public void Init(Data_InvitationList_Cell _data_InvitationList_Cell_Input){
		
		Init_01_Initialize_Variable(_data_InvitationList_Cell_Input);
		Init_02_Set_UserInfo();
		
	}
	
	private void Init_01_Initialize_Variable(Data_InvitationList_Cell _data_InvitationList_Cell_Input){
		
		m_data_BoastList_Cell = _data_InvitationList_Cell_Input;

//		Debug.Log ("ST110 BoastList_Cell_Item.Init_01_Initialize_Variable().m_data_BoastList_Cell.strUserInfo_UserId = " + m_data_BoastList_Cell.strUserInfo_UserId);

	}
	
	private void Init_02_Set_UserInfo(){
		
		// 프로필 이미지.
		if (m_data_BoastList_Cell.strUserInfo_ProfileImageUrl == null ||
		    m_data_BoastList_Cell.strUserInfo_ProfileImageUrl.Equals("")){
			
			Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
			m_Boast_Pforile_Texture.mainTexture = basicTexture;
			
		} else {
			
			StartCoroutine(Network_DownloadImage_Profile(m_data_BoastList_Cell.strUserInfo_ProfileImageUrl));
		}
		
		// 닉네임.
		m_Boast_NickName_Label.text = m_data_BoastList_Cell.strUserInfo_NickName;

		// 초대버튼.
		if (m_data_BoastList_Cell.boolUserInfo_MessageSent) {

			m_Boast_Button.isEnabled = false;
			m_Boast_Btn_BG_Sprite.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
				
		} else {

			m_Boast_Button.isEnabled = true;
			m_Boast_Btn_BG_Sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
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
		//		m_Boast_Pforile_Texture.mainTexture = m_Tex2DProfile;
		//	}
		//	
		//	www.Dispose();
		//}
		ImageResourceManager.Instance.AddQueue(strImageUrl_Input, m_Boast_Pforile_Texture);
		yield break;
	}
	
	
	
	private void OnClick_Boast(){
		
		if (_delegate_BoastList_Cell_Item != null){
			_delegate_BoastList_Cell_Item(m_data_BoastList_Cell.strUserInfo_UserId);
		}
		
	}
}
