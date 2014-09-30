using UnityEngine;
using System.Collections;

public class InvitationPopupView : MonoBehaviour {

	// ==================== Layout 관련 변수 선언 - Start ====================
	public UILabel m_InviteInfo_Num_Label;
	public UIPanel m_InvitationList_Panel;
	public UIGrid m_InvitationList_Grid;
	public UIPanel m_InvitationAlert_Panel;
	public UILabel m_InfoText_Label;
	public UIButton m_InviteAlert_OK_Button;
	public UIButton m_InviteAlert_Cancle_Button;
	public UIButton m_InviteAlert_Confirm_Button;
	public UIPanel _uiRootAlertViewObject;
	public IndicatorPopupView _indicatorPopupView ;
	public UISprite m_10_Reward_Stamp;
	public UISprite m_20_Reward_Stamp;
	public UISprite m_30_Reward_Stamp;
	public UISprite m_40_Reward_Stamp;

	private UIRootAlertView _uiRootAlertView;

	// ==================== Layout 관련 변수 선언 - End ====================

	// ==================== Prefab 관련 변수 선언 - Start ====================
	public Object m_objPreFab_InviteList_Cell_Btn_Up;
	public Object m_objPreFab_InviteList_Cell_Btn_Down;
	public Object m_objPreFab_InviteList_Cell_Item;
	
	private GameObject m_objInviteList_Cell_Btn_Up;
	private GameObject m_objInviteList_Cell_Btn_Down;
	private GameObject[] m_array_objInviteList_Cell_Friend;
	// ==================== Prefab 관련 변수 선언 - End ====================

	// ==================== 리스트 아이템 정보 관련 변수 선언 - Start ====================
	InvitationList_Cell_Up m_InvitationList_Cell_Up;
	InvitationList_Cell_Down m_InvitationList_Cell_Down;

	private Data_InvitationList_Cell [] m_array_DIC_Friend;
	private int m_intInvite_Friend_InfoList_Size;
	private int m_intInvite_Friend_InfoList_Size_Test;
	private int m_intInvite_Friend_Page_TotalNum;
	private int m_intInvite_Friend_Page_CurrentNo;
	// ==================== 리스트 아이템 정보 관련 변수 선언 - End ====================

	// ==================== 초대 확인 팝업 관련 변수 선언 - Start ====================
	private string m_strInviteUser_ID;
	private string m_strInviteUser_NickName;
	private bool m_boolKakaoInvite_Done;
	private int m_intInviteTotalNum;
	// ==================== 초대 확인 팝업 관련 변수 선언 - End ====================

	// ==================== 기타 변수 선언 - Start ====================
	private bool m_boolKakaoTest_Invite;
	private int m_intItemNum_InPage;

	//private UIDraggablePanel m_InviteList_DraggablePanel;

	// ==================== 기타 변수 선언 - End ====================


	/*
	void Awake () {
		
	}

	void Start () {
	
	}

	void Update () {
#if UNITY_EDITOR
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	if(!Managers.UserData.GetGameSubmarine(1).IsPurchase)
		//	{
		//		Managers.UserData.SetPurchaseGameSubmarine(1);
		//	}
		//}
#endif

	}

	protected bool m_InitObjects = false;
	public void Init(){

		Init_01_Initialize_Variable();
		Init_02_SetLayout_Default();
		Init_03_SetVariable_Default();

		Init_11_Get_UserInfo();

		if(!m_InitObjects)
		{
			m_InitObjects = true;
			Init_11_GridList_Make_Cell();
		}
		
		Init_21_GridList_Set_Page_Friend();
		Init_22_Set_Layout();

	}

	private void Init_01_Initialize_Variable(){

		_uiRootAlertView = _uiRootAlertViewObject.GetComponent<UIRootAlertView>() as UIRootAlertView ;

		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
		_uiRootAlertView.Event_Delegate_UIRootAlertView_Kakao += Delegate_UIRootAlertView_Kakao;
		// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.

		_uiRootAlertView.InitLoadUIRootAlertView ();

		_indicatorPopupView.InitLoadIndicatorPopupView() ;

		m_InviteList_DraggablePanel = m_InvitationList_Panel.GetComponent<UIDraggablePanel>() as UIDraggablePanel;

		m_intInviteTotalNum = Managers.UserData.GetUserDataStruct().InviteFriend_Num;
	}

	private void Init_02_SetLayout_Default(){

		SetPopupView_Show();
		
		m_InvitationAlert_Panel.gameObject.SetActive (false);

		SetLayout_RewardStamp (m_intInviteTotalNum);

	}

	private void Init_03_SetVariable_Default(){

		#if UNITY_EDITOR
		
		m_boolKakaoTest_Invite = true;
		
		#else
		
		m_boolKakaoTest_Invite = false;
		
		#endif

		//Debug.Log ("ST110 InvitationPopupView.Init_11_Get_UserInfo().m_boolKakaoTest_Invite = " + m_boolKakaoTest_Invite);
		
		m_intItemNum_InPage = 20;
		
		m_intInvite_Friend_InfoList_Size = KakaoLeaderBoard.Instance.gameFriends.Count;
		m_intInvite_Friend_InfoList_Size_Test = 55;
		
		if (m_boolKakaoTest_Invite){
			
			if (m_intInvite_Friend_InfoList_Size_Test%m_intItemNum_InPage > 0){
				
				m_intInvite_Friend_Page_TotalNum = m_intInvite_Friend_InfoList_Size_Test/m_intItemNum_InPage + 1;
				
			} else {
				
				m_intInvite_Friend_Page_TotalNum = m_intInvite_Friend_InfoList_Size_Test/m_intItemNum_InPage;
			}
			
		} else {
			
			if (m_intInvite_Friend_InfoList_Size%m_intItemNum_InPage > 0){
				
				m_intInvite_Friend_Page_TotalNum = m_intInvite_Friend_InfoList_Size/m_intItemNum_InPage + 1;
				
			} else {
				
				m_intInvite_Friend_Page_TotalNum = m_intInvite_Friend_InfoList_Size/m_intItemNum_InPage;
			}
		}

	}

	private void Init_11_Get_UserInfo(){

		if (m_boolKakaoTest_Invite){
			
			m_array_DIC_Friend = new Data_InvitationList_Cell[m_intInvite_Friend_InfoList_Size_Test];
			
			for (int i = 0; i < m_intInvite_Friend_InfoList_Size_Test; i++){
				
				Data_InvitationList_Cell _data_InvitationList_Cell = new Data_InvitationList_Cell();
				_data_InvitationList_Cell.strUserInfo_ProfileImageUrl = "";
				_data_InvitationList_Cell.strUserInfo_NickName = "FriendUser_" + (i +1).ToString();
				_data_InvitationList_Cell.strUserInfo_UserId = "";
				
				m_array_DIC_Friend[i] = _data_InvitationList_Cell;
			}

		} else {

			//Debug.Log ("ST110 InvitationPopupView.Init_11_Get_UserInfo().m_intInvite_Friend_InfoList_Size = " + m_intInvite_Friend_InfoList_Size);

			m_array_DIC_Friend = new Data_InvitationList_Cell[m_intInvite_Friend_InfoList_Size];
			
			for (int i = 0; i < m_intInvite_Friend_InfoList_Size; i++){
				
				Data_InvitationList_Cell _data_InvitationList_Cell = new Data_InvitationList_Cell();

				_data_InvitationList_Cell.strUserInfo_UserId = KakaoLeaderBoard.Instance.gameFriends[i].user_id;
				_data_InvitationList_Cell.strUserInfo_NickName = KakaoLeaderBoard.Instance.gameFriends[i].nickname;
				_data_InvitationList_Cell.strUserInfo_ProfileImageUrl = KakaoLeaderBoard.Instance.gameFriends[i].profile_image_url;
				_data_InvitationList_Cell.strUserInfo_FriendNickname = KakaoLeaderBoard.Instance.gameFriends[i].friend_nickname;
				_data_InvitationList_Cell.boolUserInfo_MessageBlocked = KakaoLeaderBoard.Instance.gameFriends[i].message_blocked;
				_data_InvitationList_Cell.boolUserInfo_SupportedDevice = KakaoLeaderBoard.Instance.gameFriends[i].supported_device;
				_data_InvitationList_Cell.intUserInfo_LastMessageSentAt = KakaoLeaderBoard.Instance.gameFriends[i].last_message_sent_at;
				_data_InvitationList_Cell.boolUserInfo_MessageSent = KakaoLeaderBoard.Instance.gameFriends[i].message_sent;

				m_array_DIC_Friend[i] = _data_InvitationList_Cell;

			}
		}

	}
	
	private void Init_11_GridList_Make_Cell(){
	
		// Grid Cell 생성 - "위로"버튼.
		m_objInviteList_Cell_Btn_Up = Instantiate(m_objPreFab_InviteList_Cell_Btn_Up) as GameObject;
		m_objInviteList_Cell_Btn_Up.transform.parent = m_InvitationList_Grid.transform;
		m_objInviteList_Cell_Btn_Up.transform.localPosition = Vector3.zero ;
		m_objInviteList_Cell_Btn_Up.transform.localScale = new Vector3(1f, 1f, 1f);
		m_InvitationList_Cell_Up = m_objInviteList_Cell_Btn_Up.GetComponent<InvitationList_Cell_Up>() as InvitationList_Cell_Up;
		m_InvitationList_Cell_Up.Event_Delegate_InvitationList_Cell_Up += Delegate_InvitationList_Cell_Up;
		
		// Grid Cell 생성 - 친구 정보.
		m_array_objInviteList_Cell_Friend = new GameObject[m_intItemNum_InPage];
		for (int i = 0; i < m_intItemNum_InPage; i++){
			
			GameObject objInviteListItem_Friend = Instantiate(m_objPreFab_InviteList_Cell_Item) as GameObject;
			objInviteListItem_Friend.transform.parent = m_InvitationList_Grid.transform;
			objInviteListItem_Friend.transform.localPosition = Vector3.zero ;
			objInviteListItem_Friend.transform.localScale = new Vector3(1f, 1f, 1f);
			m_array_objInviteList_Cell_Friend[i] = objInviteListItem_Friend;
		}
		
		// Grid Cell 생성 - "아래로"버튼.
		m_objInviteList_Cell_Btn_Down = Instantiate(m_objPreFab_InviteList_Cell_Btn_Down) as GameObject;
		m_objInviteList_Cell_Btn_Down.transform.parent = m_InvitationList_Grid.transform;
		m_objInviteList_Cell_Btn_Down.transform.localPosition = Vector3.zero ;
		m_objInviteList_Cell_Btn_Down.transform.localScale = new Vector3(1f, 1f, 1f);
		m_InvitationList_Cell_Down = m_objInviteList_Cell_Btn_Down.GetComponent<InvitationList_Cell_Down>() as InvitationList_Cell_Down;
		m_InvitationList_Cell_Down.Event_Delegate_InvitationList_Cell_Down += Delegate_InvitationList_Cell_Down;

		m_InvitationList_Grid.repositionNow = true;
		m_InviteList_DraggablePanel.RestrictWithinBounds(true);
	}
	
	private void Init_21_GridList_Set_Page_Friend(){

		//if (m_intInvite_Friend_Page_TotalNum == 0){
		//
		//	GridList_DestroyCell();
		//
		//} else 
		//{

		m_intInvite_Friend_Page_CurrentNo = 1;
		
		GridList_Set_Page(
			m_intInvite_Friend_Page_CurrentNo,
			m_array_DIC_Friend);
		//}


	}

	private void Init_22_Set_Layout(){

		if (m_boolKakaoTest_Invite){

			m_InviteInfo_Num_Label.text = "Test";

		} else {

			m_InviteInfo_Num_Label.text = m_intInviteTotalNum.ToString();
		}
	}

	// ==================== Grid 리스트 아이템정보 설정 - Start ====================
	private void GridList_Set_Page(
		int intPage_CurrentNo_Input,
		Data_InvitationList_Cell[] array_DIC_Friend_Input)
	{

//		//Debug.Log("ST110 InvitationPopupView.GridList_Set_Page().intPage_CurrentNo_Input = " + intPage_CurrentNo_Input);
//		//Debug.Log("ST110 InvitationPopupView.GridList_Set_Page().m_intInvite_Friend_Page_TotalNum = " + m_intInvite_Friend_Page_TotalNum);
//		//Debug.Log("ST110 InvitationPopupView.GridList_Set_Page().array_DIC_Friend_Input.Length = " + array_DIC_Friend_Input.Length);


		// 모든 셀 보이기.
		m_objInviteList_Cell_Btn_Up.SetActive(true);
		m_objInviteList_Cell_Btn_Down.SetActive(true);

		for (int i = 0; i < m_intItemNum_InPage; i++){
			
			m_array_objInviteList_Cell_Friend[i].SetActive(true);
		}

		if (m_intInvite_Friend_Page_TotalNum > 0){

			// 현재 페이지 - 1페이지.
			if (intPage_CurrentNo_Input == 1){
				
				// '위로' 버튼 숨기기.
				m_objInviteList_Cell_Btn_Up.SetActive(false);
				
				// 친구 정보 보이기.
				if (m_intInvite_Friend_Page_TotalNum == 1){
					
					GridList_Set_Item_Friend(array_DIC_Friend_Input, 1, array_DIC_Friend_Input.Length);
					
				}  else {
					
					GridList_Set_Item_Friend(array_DIC_Friend_Input, 1, m_intItemNum_InPage);
				}
				
				// 전체 페이지 갯수가 2페이지 이상일 경우 '아래로' 버튼 보이기.
				if (m_intInvite_Friend_Page_TotalNum > 1){
					
					m_objInviteList_Cell_Btn_Down.SetActive(true);
					
				} else {
					
					m_objInviteList_Cell_Btn_Down.SetActive(false);
				}
				
				// 현재 페이지 - 2페이지 이상.
			} else if (intPage_CurrentNo_Input > 1){
				
				// '위로' 버튼 보이기.
				m_objInviteList_Cell_Btn_Up.SetActive(true);
				
				// 마지막 페이지 아닐 때.
				if (intPage_CurrentNo_Input < m_intInvite_Friend_Page_TotalNum){
					
					// 사용자 정보 보이기.
					GridList_Set_Item_Friend(array_DIC_Friend_Input, ((intPage_CurrentNo_Input - 1) * m_intItemNum_InPage) + 1, intPage_CurrentNo_Input * m_intItemNum_InPage);
					
					// '아래로' 버튼 보이기.
					m_objInviteList_Cell_Btn_Down.SetActive(true);
					
					// 마지막 페이지 일 때.
				} else {
					
					// 사용자 정보 보이기.
					GridList_Set_Item_Friend(array_DIC_Friend_Input, ((intPage_CurrentNo_Input - 1) * m_intItemNum_InPage) + 1, array_DIC_Friend_Input.Length);
					
					// '아래로' 버튼 숨기기.
					m_objInviteList_Cell_Btn_Down.SetActive(false);
					
					m_InviteList_DraggablePanel.Scroll(-1.0f);
				}
			}
			
			m_InvitationList_Grid.repositionNow = true;

		} else {

			m_objInviteList_Cell_Btn_Up.SetActive(false);
			m_objInviteList_Cell_Btn_Down.SetActive(false);

			for (int i = 0; i < m_intItemNum_InPage; i++){
				
				m_array_objInviteList_Cell_Friend[i].SetActive(false);
			}
		}

		m_InviteList_DraggablePanel.RestrictWithinBounds(true);
	}

	// 카카오 수정 (by 최원석 14.04.21) ---- Start.
	private InvitationList_Cell_Item[] m_array_InvitationList_Cell_Item;
	private int m_intListItemCell_DelegateNo;

	private void GridList_Set_Item_Friend(Data_InvitationList_Cell[] array_DIC_Friend_Input, int intIndexNo_Start_Input, int intIndexNo_End_Input){

		int intIndexNum_InPage_This = (intIndexNo_End_Input - intIndexNo_Start_Input) + 1;

		m_array_InvitationList_Cell_Item = new InvitationList_Cell_Item[intIndexNum_InPage_This];

		for (int i = 0; i < intIndexNum_InPage_This; i++){
			
			InvitationList_Cell_Item _invitationList_Cell_Item = m_array_objInviteList_Cell_Friend[i].GetComponent<InvitationList_Cell_Item>() as InvitationList_Cell_Item;

			m_array_InvitationList_Cell_Item[i] = _invitationList_Cell_Item;
			m_array_InvitationList_Cell_Item[i].Init (array_DIC_Friend_Input[(intIndexNo_Start_Input - 1) + i], i);
			m_array_InvitationList_Cell_Item[i].Event_Delegate_InvitationList_Cell_Item += Delegate_InvitationList_Cell_Item;


		}
		
		for (int i = intIndexNum_InPage_This; i < m_intItemNum_InPage; i++){
			
			m_array_objInviteList_Cell_Friend[i].SetActive(false);
		}
	}
	// 카카오 수정 (by 최원석 14.04.21) ---- End.


	// ==================== Grid 리스트 아이템정보 설정 - End ====================





	// ==================== 버튼 클릭 정의 - Start ====================
	private void OnClick_Close(){

		SetPopupView_Hide();

	}

	private void OnClick_InviteAlertPopup_OK(){

		m_InvitationAlert_Panel.gameObject.SetActive (false);
		Process_Invite_01_Kakao_ActionSendLinkInviteMessage ();
	}

	private void OnClick_InviteAlertPopup_Cancle(){
		
		m_InvitationAlert_Panel.gameObject.SetActive (false);
	}

	private void OnClick_InviteAlertPopup_Confirm(){
		
		m_InvitationAlert_Panel.gameObject.SetActive (false);




	}

	
	// ==================== 버튼 클릭 정의 - End ====================


	// ==================== EventDelegate 정의 - Start ====================
	private void Delegate_InvitationList_Cell_Up(){
		
		m_intInvite_Friend_Page_CurrentNo--;

		GridList_Set_Page(
			m_intInvite_Friend_Page_CurrentNo,
			m_array_DIC_Friend);
	}
	
	private void Delegate_InvitationList_Cell_Down(){
		
		m_intInvite_Friend_Page_CurrentNo++;

		GridList_Set_Page(
			m_intInvite_Friend_Page_CurrentNo,
			m_array_DIC_Friend);
	}

	private void Delegate_InvitationList_Cell_Item(string strUserID_Input, string strUserNickName_Input, int intListNo_Input){

		m_boolKakaoInvite_Done = false;
		m_strInviteUser_ID = strUserID_Input;
		m_strInviteUser_NickName = strUserNickName_Input;
		PopupViewShow_InviteAlert_Quest ();

		m_intListItemCell_DelegateNo = intListNo_Input;
	}

	// ==================== EventDelegate 정의 - End ====================

	private void PopupViewShow_InviteAlert_Quest(){

//		//Debug.Log ("ST110 초대 발송 유저 ID = " + KakaoLeaderBoard.Instance.gameMe.user_id);
//		//Debug.Log ("ST110 초대 수신 유저 ID = " + m_strInviteUser_ID);

		m_InvitationAlert_Panel.gameObject.SetActive (true);

		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
		string strMessage = m_strInviteUser_NickName + "님에게 \r\n 초대장을 카카오톡으로 보내시겠습니까?";
		// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

		m_InfoText_Label.text = strMessage;

		m_InviteAlert_OK_Button.gameObject.SetActive (true);
		m_InviteAlert_Cancle_Button.gameObject.SetActive (true);
		m_InviteAlert_Confirm_Button.gameObject.SetActive (false);
	}

	private void PopupViewShow_InviteAlert_Done(){

		m_InvitationAlert_Panel.gameObject.SetActive (true);

		string strMessage = m_strInviteUser_NickName + " 님을 초대했습니다.";
		
		m_InfoText_Label.text = strMessage;
		
		m_InviteAlert_OK_Button.gameObject.SetActive (false);
		m_InviteAlert_Cancle_Button.gameObject.SetActive (false);
		m_InviteAlert_Confirm_Button.gameObject.SetActive (true);
	}

	private void PopupViewShow_InviteAlert_Gift(){

		m_InvitationAlert_Panel.gameObject.SetActive (true);
		
		string strMessage = "초대보상 선물이 지급되었습니다.";

		m_InfoText_Label.text = strMessage;
		
		m_InviteAlert_OK_Button.gameObject.SetActive (false);
		m_InviteAlert_Cancle_Button.gameObject.SetActive (false);
		m_InviteAlert_Confirm_Button.gameObject.SetActive (true);

		SetLayout_RewardStamp (m_intInviteTotalNum);
	}

	private void SetPopupView_Show(){

		gameObject.SetActive(true);
	}

	private void SetPopupView_Hide(){

		GridList_DestroyCell();
		gameObject.SetActive(false);
	}

	private void GridList_DestroyCell(){

		//Destroy(m_objInviteList_Cell_Btn_Up);
		//Destroy(m_objInviteList_Cell_Btn_Down);
		//
		//for (int i = 0; i < m_intItemNum_InPage; i++){
		//	
		//	Destroy(m_array_objInviteList_Cell_Friend[i]);
		//}
		
		m_InvitationList_Grid.Reposition();
		m_InvitationList_Panel.Refresh();
		
	}

	private void Process_Invite_01_Kakao_ActionSendLinkInviteMessage(){

		//_indicatorPopupView.LoadIndicatorPopupView ();
		//
		//// EventDelegate 정의 - KakaoManager_ActionSendLinkInviteMessage.
		//Managers.KaKao.Event_Delegate_KakaoManager_ActionSendLinkInviteMessage += (intResultCode_Input) => {
		//
		//	_indicatorPopupView.RemoveIndicatorPopupView();
		//
		//	//Debug.Log("ST110 InvitationPopupView.Process_Invite_01_Kakao_ActionSendLinkInviteMessage().Event_Delegate_KakaoManager_ActionSendLinkInviteMessage.intResultCode_Input = " + intResultCode_Input.ToString());
		//
		//	if (intResultCode_Input == Constant.KAKAO_RESPONSE_CODE_Sucess){
		//
		//		m_array_InvitationList_Cell_Item[m_intListItemCell_DelegateNo].m_Invite_Button.isEnabled = false;
		//		m_array_InvitationList_Cell_Item[m_intListItemCell_DelegateNo].m_Invite_BtnBG_Sprite.spriteName = "invitation_invitebutton_dark";
		//
		//		Process_Invite_02_Network_SaveUserData();
		//		ST200KLogManager.Instance.SaveFriendInvite(true, Managers.UserData.InviteFriend_Num);
		//	} else {
		//
		//		_uiRootAlertView.LoadUIRootAlertView_Kakao(intResultCode_Input);
		//		ST200KLogManager.Instance.SaveFriendInvite(false, Managers.UserData.InviteFriend_Num);
		//	}
		//
		//	Managers.KaKao.Event_Delegate_KakaoManager_ActionSendLinkInviteMessage += null;
		//};
		//
		//Managers.KaKao.ActionSendLinkInviteMessage(
		//	m_strInviteUser_ID,
		//	"'아! 열바다' 게임으로 초대합니다.",
		//	Managers.GameBalanceData.KakaoInviteMessageID.ToString(),
		//	KakaoLeaderBoard.Instance.gameMe.nickname,
		//	KakaoLeaderBoard.Instance.gameMe.user_id);
		//
		////Debug.Log("ST110 InvitationPopupView.Process_Invite_01_Kakao_ActionSendLinkInviteMessage().KakaoLeaderBoard.Instance.gameMe.user_id = " + KakaoLeaderBoard.Instance.gameMe.user_id);
		////Debug.Log("ST110 InvitationPopupView.Process_Invite_01_Kakao_ActionSendLinkInviteMessage().m_strInviteUser_ID = " + m_strInviteUser_ID);

	}

	private void Process_Invite_02_Network_SaveUserData(){

		_indicatorPopupView.LoadIndicatorPopupView ();

		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
		// EventDelegate 정의 - SaveUserData.
		Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){
				GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
				GameUIManager.Instance.UpdateTorpedoUI();
				Process_Invite_03_Network_ReadUserData();

			} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){

				_uiRootAlertView.LoadUIRootAlertView(11) ;
				
			} else {
				
				_uiRootAlertView.LoadUIRootAlertView(21) ;
			}

			Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
		};
		
		m_intInviteTotalNum += 1;

//		m_intInviteTotalNum = 40; // 테스트;

//		//Debug.Log ("ST110 InvitationPopupView.Process_Invite_02_Network_SaveUserData().m_intInviteTotalNum = " + m_intInviteTotalNum);

		Managers.UserData.InviteFriend_Num = m_intInviteTotalNum;

		SetUserdata_InviteReward (m_intInviteTotalNum);

		Managers.DataStream.Network_SaveUserData_Input_1(Managers.UserData.GetUserDataStruct());
		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
	}

	private void Process_Invite_03_Network_ReadUserData(){

		_indicatorPopupView.LoadIndicatorPopupView ();
		
		// EventDelegate 정의 - ReadUserData.
		Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += (intNetworkReadUserDataResultCode_Input) => {
			
			_indicatorPopupView.RemoveIndicatorPopupView() ;
			
			if (intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				m_intInviteTotalNum =  Managers.UserData.GetUserDataStruct().InviteFriend_Num;

				if (m_intInviteTotalNum == 10
				    || m_intInviteTotalNum == 20
				    || m_intInviteTotalNum == 30
				    || m_intInviteTotalNum == 40){

					PopupViewShow_InviteAlert_Gift();

				} else {

//					PopupViewShow_InviteAlert_Done();
				}

				// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== Start.
				m_InviteInfo_Num_Label.text = m_intInviteTotalNum.ToString ();
				// 카카오 모듈 수정 작업. (by 최원석 14.04.19) ======== End.

			} else if (intNetworkReadUserDataResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network){
				
				_uiRootAlertView.LoadUIRootAlertView(11) ;
				
			} else {
				
				_uiRootAlertView.LoadUIRootAlertView(21) ;
			}

			Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserData += null;
		};
		
		StartCoroutine(Managers.DataStream.Network_ReadUserData()) ;
	}

	private void SetUserdata_InviteReward(int intInviteTotalNum_Input){

		//Debug.Log ("ST110 InvitationPopupView.SetUserdata_InviteReward().Managers.UserData.TorpedoCount = " + Managers.UserData.TorpedoCount.ToString());

		if (intInviteTotalNum_Input == 10) {
			
			Managers.UserData.GameCoin += 3000;

		} else if (intInviteTotalNum_Input == 20) {
			
			Managers.UserData.SetGameItem(1, 1); // 스타트 대쉬.
			Managers.UserData.SetGameItem(3, 1); // 라스트 어택.
			Managers.UserData.SetGameItem(7, 1); // 지원사격.

		} else if (intInviteTotalNum_Input == 30) {

			Managers.UserData.GameJewel += 10;

		} else if (intInviteTotalNum_Input == 40) {
	
			//int gachaindex = 8; // 보상펫 '해마아' S.
			//
			//if (Managers.UserData.HasGamePet(gachaindex)){
			//	
			//	UserDataManager.GamePet pet = Managers.UserData.GetPet(gachaindex);
			//	pet.Level++;
			//	Managers.UserData.SetGamePet(pet);
			//	
			//} else {
			//	
			//	UserDataManager.GamePet pet = new UserDataManager.GamePet();
			//	pet.IndexNumber = gachaindex;
			//	pet.Level = 1;
			//	pet.IsSelect = 0;
			//	Managers.UserData.SetGamePet(pet);
			//}

			if(!Managers.UserData.GetGameSubmarine(1).IsPurchase)
			{
				Managers.UserData.SetPurchaseGameSubmarine(1);
			}
		} else {
			
			//Managers.UserData.TorpedoCount += 1;
		}

		if(intInviteTotalNum_Input % 5 == 0)
		{
			Managers.UserData.AddLuckyCoupon(1);
			GameUIManager.Instance.ShowLuckyCouponAlert();
		}else
		{
			Managers.Torpedo.AddTorpedo(1);
		}

		//Debug.Log ("ST110 InvitationPopupView.SetUserdata_InviteReward().Managers.UserData.TorpedoCount = " + Managers.UserData.TorpedoCount.ToString());

	}

	private void SetLayout_RewardStamp(int intInviteTotalNum_Input){

		if (intInviteTotalNum_Input >= 40) {
			
			m_10_Reward_Stamp.gameObject.SetActive(true);
			m_20_Reward_Stamp.gameObject.SetActive(true);
			m_30_Reward_Stamp.gameObject.SetActive(true);
			m_40_Reward_Stamp.gameObject.SetActive(true);
			
		} else if (intInviteTotalNum_Input >= 30) {
			
			m_10_Reward_Stamp.gameObject.SetActive(true);
			m_20_Reward_Stamp.gameObject.SetActive(true);
			m_30_Reward_Stamp.gameObject.SetActive(true);
			m_40_Reward_Stamp.gameObject.SetActive(false);

		} else if (intInviteTotalNum_Input >= 20) {
			
			m_10_Reward_Stamp.gameObject.SetActive(true);
			m_20_Reward_Stamp.gameObject.SetActive(true);
			m_30_Reward_Stamp.gameObject.SetActive(false);
			m_40_Reward_Stamp.gameObject.SetActive(false);

		} else if (intInviteTotalNum_Input >= 10) {
			
			m_10_Reward_Stamp.gameObject.SetActive(true);
			m_20_Reward_Stamp.gameObject.SetActive(false);
			m_30_Reward_Stamp.gameObject.SetActive(false);
			m_40_Reward_Stamp.gameObject.SetActive(false);

		} else {

			m_10_Reward_Stamp.gameObject.SetActive(false);
			m_20_Reward_Stamp.gameObject.SetActive(false);
			m_30_Reward_Stamp.gameObject.SetActive(false);
			m_40_Reward_Stamp.gameObject.SetActive(false);
		}
	}

	// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== Start.
	private void Delegate_UIRootAlertView_Kakao (int intKakaoResponseCode_Input){
		
		if (intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Common
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_NotEffective_RefreshToken
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Invalid_Push_Token
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_Invalid_Request
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Certification
		    || intKakaoResponseCode_Input == Constant.KAKAO_RESPONSE_CODE_Error_CanNot_GetInfo_Kakao){
			
			Application.LoadLevel(Constant.SCENE_Main);
		}
	}
	// 카카오톡 에러 알림 수정(by 최원석 14.05.13) ===== End.
	*/
}
