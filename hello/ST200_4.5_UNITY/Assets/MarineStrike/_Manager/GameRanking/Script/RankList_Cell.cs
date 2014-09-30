using UnityEngine;
using System.Collections;

public class RankList_Cell : MonoBehaviour {

	// ==================== Layout 관련 변수 선언 - Start ====================
	public UISprite m_Background_Sprite;
	public UISprite m_Background_WorldMyInfoSprite;
	public UISprite[] m_DotSprite;
	public UISprite m_RankBG_Sprite;
	public UILabel m_RankText_Label;
	public UITexture m_Pforile_Texture;
	public UISprite m_Submarine_Sprite;
	public UILabel m_NickName_Label;
	public UILabel m_Score_Label;
	public UIButton m_Torpedo_Send_Button;
	public UISprite m_Torpedo_Send_BG_Sprite;
	// ==================== Layout 관련 변수 선언 - End ====================

	// ==================== 기타 변수 선언 - Start ====================
	//private Texture2D m_Tex2DProfile;
	public RankListData m_rankPanalData;
	private bool m_boolMe;
	private bool m_WorldMyInfo = false;
	private bool m_CanSendTorpedo = true;
	//private KakaoLeaderBoard.AppGameFriend m_AppGameFriend;

	// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
	private RankPanelView.eRankType m_eRankType;
	// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

	// ==================== 기타 변수 선언 - End ====================

	// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
	public void Init(RankPanelView.eRankType eRankType_Input, bool boolMe_Input, RankListData _rankPanalData_Input, bool _worldRankMyInfo){

		Init_01_Initialize_Variable(eRankType_Input, boolMe_Input, _rankPanalData_Input,_worldRankMyInfo);
		Init_02_Set_UserInfo();

	}

	private void Init_01_Initialize_Variable(RankPanelView.eRankType eRankType_Input, bool boolMe_Input, RankListData _rankPanalData_Input,  bool _worldRankMyInfo){

		m_eRankType = eRankType_Input;
		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

		m_rankPanalData = _rankPanalData_Input;
		m_boolMe = boolMe_Input;
		m_WorldMyInfo = _worldRankMyInfo;

		if(m_boolMe)
		{
			//if(KakaoLeaderBoard.Instance.gameMe.message_blocked)
			//{
			//	m_Torpedo_Send_BG_Sprite.spriteName = "btn_missile_off";
			//}else
			//{
			//	m_Torpedo_Send_BG_Sprite.spriteName = "btn_missile_on";
			//}
		}else
		{
			//KakaoLeaderBoard.AppGameFriend friend = KakaoLeaderBoard.Instance.GetAppGameFriend(m_rankPanalData.userId);
			//m_AppGameFriend = friend;
			//if(friend == null)
			//{
			//	//error
			//	////Debug.LogError("NO FRIEND WITH: " + m_rankPanalData.userId);
			//}else
			//{
			//	//Debug.Log("LAST SENT MESSAGE: " + friend.last_message_sent_at + " SERVERTIME: " + KakaoLeaderBoard.Instance.gameMe.server_time);
			//	if(friend.last_message_sent_at + KakaoLeaderBoard.Instance.gameInfo.game_message_interval < 
			//	    Managers.UserData.GetSyncServerTime() && !friend.message_blocked)
			//	{
			//		m_Torpedo_Send_BG_Sprite.spriteName = "btn_sendmissile";
			//		m_CanSendTorpedo = true;
			//	}else
			//	{
			//		m_Torpedo_Send_BG_Sprite.spriteName = "btn_sendmissile_x";
			//		m_CanSendTorpedo = false;
			//	}
			//}
		}

		if(eRankType_Input == RankPanelView.eRankType.Rank_World)
		{
			m_Torpedo_Send_Button.gameObject.SetActive(false);
		}else if(eRankType_Input == RankPanelView.eRankType.Rank_Friend)
		{
			m_Torpedo_Send_Button.gameObject.SetActive(true);
		}
		//m_Tex2DProfile = new Texture2D(55 , 55);

	}

	private void Init_02_Set_UserInfo(){

		// 랭킹 이미지 & 텍스트 & BG.
		int intRankingNo = m_rankPanalData.intUserInfo_RankNo;

		//if (m_boolMe){
		//
		//	m_Background_Sprite.spriteName = "bg_list_mine";
		//	NGUITools.SetActive(m_RankText_Label.gameObject, false) ;
		//	m_RankBG_Sprite.gameObject.SetActive(false);
		//
		//} else 
		{
			m_Background_WorldMyInfoSprite.gameObject.SetActive(false);
			if(m_WorldMyInfo)
			{
				m_Background_Sprite.spriteName = "rank_MyInfo_Cover";
				m_Background_WorldMyInfoSprite.gameObject.SetActive (true);
				for(int i = 0; i < m_DotSprite.Length; i++)
			    {
					m_DotSprite[i].spriteName = "rank_MyInfo_dot";
				}
			}else if (m_boolMe)
			{
				m_Background_Sprite.spriteName = "bg_list_mine";
				for(int i = 0; i < m_DotSprite.Length; i++)
				{
					m_DotSprite[i].spriteName = "img_screw_mine";
				}
			}else
			{
				m_Background_Sprite.spriteName = "bg_list";
				for(int i = 0; i < m_DotSprite.Length; i++)
				{
					m_DotSprite[i].spriteName = "img_screw_list";
				}
			}

			if(intRankingNo == 0)
			{
				NGUITools.SetActive(m_RankText_Label.gameObject, true) ;
				m_RankText_Label.text = "N/A";
				m_RankBG_Sprite.gameObject.SetActive(false);
			}else if (intRankingNo == 1){
				
				NGUITools.SetActive(m_RankText_Label.gameObject, true) ;
				m_RankText_Label.text = "";
				m_RankBG_Sprite.gameObject.SetActive(true);
				m_RankBG_Sprite.spriteName = "img_medal_1";
				
			} else if (intRankingNo == 2){
				
				NGUITools.SetActive(m_RankText_Label.gameObject, true) ;
				m_RankText_Label.text = "";
				m_RankBG_Sprite.gameObject.SetActive(true);
				m_RankBG_Sprite.spriteName = "img_medal_2";
				
			} else if (intRankingNo == 3){
				
				NGUITools.SetActive(m_RankText_Label.gameObject, true) ;
				m_RankText_Label.text = "";
				m_RankBG_Sprite.gameObject.SetActive(true);
				m_RankBG_Sprite.spriteName = "img_medal_3";
				
			} else {
				
				NGUITools.SetActive(m_RankText_Label.gameObject, true) ;
				m_RankText_Label.text = m_rankPanalData.intUserInfo_RankNo.ToString();
				m_RankBG_Sprite.gameObject.SetActive(false);
			}
		}


		// 프로필 이미지.
		if (m_rankPanalData.strUserInfo_ProfileImageUrl == null ||
		    m_rankPanalData.strUserInfo_ProfileImageUrl.Equals("")){

			Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
			m_Pforile_Texture.mainTexture = basicTexture;

		} else {

			StartCoroutine(Network_DownloadImage_Profile(m_rankPanalData.strUserInfo_ProfileImageUrl));
		}

		// 잠수함 이미지.
		if (m_rankPanalData.strUserInfo_PublicData == null ||
		    m_rankPanalData.strUserInfo_PublicData.Equals("")){

			m_Submarine_Sprite.gameObject.SetActive(false);

		} else {

			m_Submarine_Sprite.gameObject.SetActive(true);

			//if (int.Parse(m_rankPanalData.strUserInfo_PublicData) == 0){
			//	
			//	m_Submarine_Sprite.spriteName = "img_submarine1";
			//	
			//} else if (int.Parse(m_rankPanalData.strUserInfo_PublicData) == 1){
			//	
			//	m_Submarine_Sprite.spriteName = "img_submarine4";
			//	
			//} else if (int.Parse(m_rankPanalData.strUserInfo_PublicData) == 2){
			//	
			//	m_Submarine_Sprite.spriteName = "img_submarine2";
			//
			//} else if (int.Parse(m_rankPanalData.strUserInfo_PublicData) == 3){
			//	
			//	m_Submarine_Sprite.spriteName = "img_submarine3";
			//}
			m_Submarine_Sprite.spriteName = "img_submarine" + m_rankPanalData.strUserInfo_PublicData;
		}

		// 닉네임.
		m_NickName_Label.text = m_rankPanalData.strUserInfo_NickName;

		// 점수.
		if(m_rankPanalData.intUserInfo_SeasonScore != 0)
		{
			m_Score_Label.text = m_rankPanalData.intUserInfo_SeasonScore.ToString("#,#");
		}else
		{
			m_Score_Label.text = "0";
		}

		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
		// 어뢰 버튼.
		if (m_eRankType == RankPanelView.eRankType.Rank_World) {

			m_Torpedo_Send_Button.gameObject.SetActive(false);
				
		} else {

			m_Torpedo_Send_Button.gameObject.SetActive(true);
		}
		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

	}

	IEnumerator Network_DownloadImage_Profile(string strImageUrl_Input){

		/*
		if (strImageUrl_Input != null && !strImageUrl_Input.Equals("")){

			WWW www = new WWW(strImageUrl_Input);
			yield return www;
			
			Texture2D m_Tex2DProfile = www.texture;
			
			if (m_Tex2DProfile != null){
				
				m_Pforile_Texture.mainTexture = m_Tex2DProfile;
			}
			
			www.Dispose();
		}*/
		ImageResourceManager.Instance.AddQueue(strImageUrl_Input, m_Pforile_Texture);
		yield break;
	}

	private void OnClick_Torpedo_Send(){

		//if(!m_boolMe)
		//{
		//	if(!m_AppGameFriend.message_blocked && m_CanSendTorpedo)
		//	{
		//		//show window
		//		GameUIManager.Instance.m_UIRootAlertView.UIRootAlertViewEvent += (UIRootAlertView uiRootAlertView, int alertType) => 
		//		{
		//			if(alertType == 1008)
		//			{
		//				//Debug.Log("RankList_Cell.OnClick_Torpedo_Send().m_rankPanalData.intUserInfo_RankNo = " + m_rankPanalData.intUserInfo_RankNo.ToString());
		//				Managers.KaKao.Event_Delegate_KakaoManager_SendGameMessage += (int intResultCode_Input) => {
		//					if(intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess)
		//					{
		//						m_AppGameFriend.last_message_sent_at = KakaoLeaderBoard.Instance.gameMe.server_time;
		//						m_Torpedo_Send_BG_Sprite.spriteName = "btn_sendmissile_x";
		//						m_CanSendTorpedo = false;
		//
		//						// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
		//						Managers.DataStream.Network_SaveUserData_Input_1(Managers.UserData.GetUserDataStruct());
		//						// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
		//
		//						GameUIManager.Instance.LoadUIRootAlertView(1007);
		//					}else
		//					{
		//						GameUIManager.Instance.LoadUIRootAlertView(1006);
		//					}
		//				};
		//				
		//				string[] names = new string[]{
		//					KakaoLeaderBoard.Instance.gameMe.nickname,
		//					m_AppGameFriend.nickname,
		//				};
		//				string kakaomessage = TextManager.Instance.GetReplaceString(109, names);
		//				string gamemessage = TextManager.Instance.GetReplaceString(110, KakaoLeaderBoard.Instance.gameMe.nickname);
		//				Managers.KaKao.ActionSendGameMessage(m_rankPanalData.userId, kakaomessage,
		//				                                     gamemessage);
		//			}
		//		};
		//		GameUIManager.Instance.m_UIRootAlertView.SetSendGameMessageTargetName(m_AppGameFriend.nickname);
		//		GameUIManager.Instance.LoadUIRootAlertView(1008);
		//	}else
		//	{
		//		//show pop up??? that he is blocked
		//		if(m_AppGameFriend.message_blocked)
		//		{
		//			GameUIManager.Instance.LoadUIRootAlertView(1006);
		//		}else
		//		{
		//			GameUIManager.Instance.LoadUIRootAlertView(1001);
		//		}
		//	}
		//}else
		//{
		//	Managers.KaKao.Event_Delegate_KakaoManager_MessageBlock += (int intResultCode_Input) => {
		//		if(intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess)
		//		{
		//			KakaoLeaderBoard.Instance.gameMe.message_blocked = !KakaoLeaderBoard.Instance.gameMe.message_blocked;
		//			if(KakaoLeaderBoard.Instance.gameMe.message_blocked)
		//			{
		//				m_Torpedo_Send_BG_Sprite.spriteName = "btn_missile_off";
		//			}else
		//			{
		//				m_Torpedo_Send_BG_Sprite.spriteName = "btn_missile_on";
		//			}
		//		}else
		//		{
		//			GameUIManager.Instance.LoadUIRootAlertView(1002);
		//		}
		//	};
		//	Managers.KaKao.ActionMessageBlock();
		//}
	}





}
