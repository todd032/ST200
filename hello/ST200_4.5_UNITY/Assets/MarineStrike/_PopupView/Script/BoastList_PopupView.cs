using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoastList_PopupView : MonoBehaviour {

	// ==================== Layout 변수 선언 - Start ====================
	public UIPanel FriendList_Panel;
	public UIGrid FriendList_Grid;
	public UILabel NoFriends_Label;

	public UIPanel BoastAlert_PopupView;
	private BoastAlert_PopupView m_BoastAlert_PopupView;


	// ==================== Layout 변수 선언 - End ====================

	// ==================== Prefab 관련 변수 선언 - Start ====================
	public Object m_objPreFab_BoastList_Cell_Btn_Up;
	public Object m_objPreFab_BoastList_Cell_Btn_Down;
	public Object m_objPreFab_BoastList_Cell_Item;
	
	private GameObject m_objBoastList_Cell_Btn_Up;
	private GameObject m_objBoastList_Cell_Btn_Down;
	private GameObject[] m_array_objBoastList_Cell_Friend;
	// ==================== Prefab 관련 변수 선언 - End ====================
	
	// ==================== 리스트 아이템 정보 관련 변수 선언 - Start ====================
	InvitationList_Cell_Up m_BoastList_Cell_Up;
	InvitationList_Cell_Down m_BoastList_Cell_Down;
	
	private List<Data_InvitationList_Cell> m_array_DIC_Friend;
	private int m_intBoast_Friend_InfoList_Size;
	private int m_intBoast_Friend_InfoList_Size_Test;
	private int m_intBoast_Friend_Page_TotalNum;
	private int m_intBoast_Friend_Page_CurrentNo;
	// ==================== 리스트 아이템 정보 관련 변수 선언 - End ====================
	
	// ==================== 기타 변수 선언 - Start ====================
	protected bool m_InitObjects = false;

	private int m_intItemNum_InPage;
	private bool m_boolKakaoTest_Boast;
	
	//private UIDraggablePanel m_BoastList_DraggablePanel;

	// ==================== 기타 변수 선언 - End ====================


	public readonly int BoastListClick_Close_INT = 0;
	public readonly int BoastListClick_Boast_INT = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Init(){
		
		gameObject.SetActive (true);
		
		Init_01_Initialize_Variable();
		Init_02_Get_UserInfo();

		if(!m_InitObjects)
		{
			m_InitObjects = true;
			Init_11_GridList_Make_Cell();
		}
		
		Init_21_GridList_Set_Page_Friend();

		
	}

	private void Init_01_Initialize_Variable(){

		#if UNITY_EDITOR
		
		m_boolKakaoTest_Boast = true;
		
		#else
		
		m_boolKakaoTest_Boast = false;
		
		#endif

		m_intItemNum_InPage = 5;
		
		//m_intBoast_Friend_InfoList_Size = KakaoLeaderBoard.Instance.appGameFriends.Count - 1;
		m_intBoast_Friend_InfoList_Size_Test = 55;
		
		if (m_boolKakaoTest_Boast){
			
			if (m_intBoast_Friend_InfoList_Size%m_intItemNum_InPage > 0){
				
				m_intBoast_Friend_Page_TotalNum = m_intBoast_Friend_InfoList_Size_Test/m_intItemNum_InPage + 1;
				
			} else {
				
				m_intBoast_Friend_Page_TotalNum = m_intBoast_Friend_InfoList_Size_Test/m_intItemNum_InPage;
			}
			
		} else {
			
			if (m_intBoast_Friend_InfoList_Size%m_intItemNum_InPage > 0){
				
				m_intBoast_Friend_Page_TotalNum = m_intBoast_Friend_InfoList_Size/m_intItemNum_InPage + 1;
				
			} else {
				
				m_intBoast_Friend_Page_TotalNum = m_intBoast_Friend_InfoList_Size/m_intItemNum_InPage;
			}
		}
		
		//m_BoastList_DraggablePanel = FriendList_Panel.GetComponent<UIDraggablePanel>() as UIDraggablePanel;

		m_BoastAlert_PopupView = BoastAlert_PopupView.GetComponent<BoastAlert_PopupView>() as BoastAlert_PopupView ;
		m_BoastAlert_PopupView.Event_Delegate_BoastAlert_PopupView += Delegate_BoastAlert_PopupView;
		m_BoastAlert_PopupView.gameObject.SetActive (false);

		NoFriends_Label.gameObject.SetActive(false);
	}

	private void Init_02_Get_UserInfo(){
		
		if (m_boolKakaoTest_Boast){
			
			m_array_DIC_Friend = new List<Data_InvitationList_Cell>();//new Data_InvitationList_Cell[m_intBoast_Friend_InfoList_Size_Test];
			
			for (int i = 0; i < m_intBoast_Friend_InfoList_Size_Test; i++){
				
				Data_InvitationList_Cell _data_InvitationList_Cell = new Data_InvitationList_Cell();
				_data_InvitationList_Cell.strUserInfo_ProfileImageUrl = "";
				_data_InvitationList_Cell.strUserInfo_NickName = "FriendUser_" + (i +1).ToString();
				_data_InvitationList_Cell.strUserInfo_UserId = "000" + (i+1).ToString();
				
				m_array_DIC_Friend.Add(_data_InvitationList_Cell);
			}
			
		} else {
			
			m_array_DIC_Friend = new List<Data_InvitationList_Cell>();

			//List<KakaoLeaderBoard.AppGameFriend> appgame = KakaoLeaderBoard.Instance.appGameFriends;
			//for(int i = 0; i < appgame.Count; i++)
			//{
			//	if(appgame[i].user_id != KakaoLeaderBoard.Instance.gameMe.user_id)
			//	{
			//		Data_InvitationList_Cell _data_InvitationList_Cell = new Data_InvitationList_Cell();
			//		_data_InvitationList_Cell.strUserInfo_ProfileImageUrl = appgame[i].profile_image_url;
			//		_data_InvitationList_Cell.strUserInfo_NickName = appgame[i].nickname;
			//		_data_InvitationList_Cell.strUserInfo_UserId = appgame[i].user_id;
			//		_data_InvitationList_Cell.boolUserInfo_MessageSent = appgame[i].message_sent;
			//		m_array_DIC_Friend.Add(_data_InvitationList_Cell);
			//	}
			//}

			//for (int i = 0; i < m_intBoast_Friend_InfoList_Size; i++){
			//	
			//	Data_InvitationList_Cell _data_InvitationList_Cell = new Data_InvitationList_Cell();
			//	_data_InvitationList_Cell.strUserInfo_ProfileImageUrl = KakaoLeaderBoard.Instance.appGameFriends[i].profile_image_url;
			//	_data_InvitationList_Cell.strUserInfo_NickName = KakaoLeaderBoard.Instance.appGameFriends[i].nickname;
			//	_data_InvitationList_Cell.strUserInfo_UserId = KakaoLeaderBoard.Instance.appGameFriends[i].user_id;
			//	m_array_DIC_Friend[i] = _data_InvitationList_Cell;
			//	
			//}
		}
		
	}
	
	private void Init_11_GridList_Make_Cell(){
		
		// Grid Cell 생성 - "위로"버튼.
		m_objBoastList_Cell_Btn_Up = Instantiate(m_objPreFab_BoastList_Cell_Btn_Up) as GameObject;
		m_objBoastList_Cell_Btn_Up.transform.parent = FriendList_Grid.transform;
		m_objBoastList_Cell_Btn_Up.transform.localPosition = Vector3.zero ;
		m_objBoastList_Cell_Btn_Up.transform.localScale = new Vector3(1f, 1f, 1f);
		m_BoastList_Cell_Up = m_objBoastList_Cell_Btn_Up.GetComponent<InvitationList_Cell_Up>() as InvitationList_Cell_Up;
		m_BoastList_Cell_Up.Event_Delegate_InvitationList_Cell_Up += Delegate_InvitationList_Cell_Up;
		
		// Grid Cell 생성 - 친구 정보.
		m_array_objBoastList_Cell_Friend = new GameObject[m_intItemNum_InPage];
		for (int i = 0; i < m_intItemNum_InPage; i++){
			
			GameObject objBoastListItem_Friend = Instantiate(m_objPreFab_BoastList_Cell_Item) as GameObject;
			objBoastListItem_Friend.transform.parent = FriendList_Grid.transform;
			objBoastListItem_Friend.transform.localPosition = Vector3.zero ;
			objBoastListItem_Friend.transform.localScale = new Vector3(1f, 1f, 1f);
			m_array_objBoastList_Cell_Friend[i] = objBoastListItem_Friend;
		}
		
		// Grid Cell 생성 - "아래로"버튼.
		m_objBoastList_Cell_Btn_Down = Instantiate(m_objPreFab_BoastList_Cell_Btn_Down) as GameObject;
		m_objBoastList_Cell_Btn_Down.transform.parent = FriendList_Grid.transform;
		m_objBoastList_Cell_Btn_Down.transform.localPosition = Vector3.zero ;
		m_objBoastList_Cell_Btn_Down.transform.localScale = new Vector3(1f, 1f, 1f);
		m_BoastList_Cell_Down = m_objBoastList_Cell_Btn_Down.GetComponent<InvitationList_Cell_Down>() as InvitationList_Cell_Down;
		m_BoastList_Cell_Down.Event_Delegate_InvitationList_Cell_Down += Delegate_InvitationList_Cell_Down;
		
		FriendList_Grid.repositionNow = true;
		
	}

	private void Init_21_GridList_Set_Page_Friend(){
		
		//if (m_intInvite_Friend_Page_TotalNum == 0){
		//
		//	GridList_DestroyCell();
		//
		//} else 
		//{
		
		m_intBoast_Friend_Page_CurrentNo = 1;
		
		GridList_Set_Page(
			m_intBoast_Friend_Page_CurrentNo,
			m_array_DIC_Friend.ToArray());
		//}
	}

	// ==================== Grid 리스트 아이템정보 설정 - Start ====================
	private void GridList_Set_Page(
		int intPage_CurrentNo_Input,
		Data_InvitationList_Cell[] array_DIC_Friend_Input){
		
		//Debug.Log("ST110 BoastListPopupView.GridList_Set_Page().intPage_CurrentNo_Input = " + intPage_CurrentNo_Input);
//		//Debug.Log("ST110 BoastListPopupView.GridList_Set_Page().m_intBoast_Friend_Page_TotalNum = " + m_intBoast_Friend_Page_TotalNum);
//				//Debug.Log("ST110 BoastListPopupView.GridList_Set_Page().array_DIC_Friend_Input.Length = " + array_DIC_Friend_Input.Length);
		
		
		// 모든 셀 보이기.
		m_objBoastList_Cell_Btn_Up.SetActive(true);
		m_objBoastList_Cell_Btn_Down.SetActive(true);
		
		for (int i = 0; i < m_intItemNum_InPage; i++){
			
			m_array_objBoastList_Cell_Friend[i].SetActive(true);
		}
		
		// 현재 페이지 - 1페이지.
		if (intPage_CurrentNo_Input == 1){
			
			// '위로' 버튼 숨기기.
			m_objBoastList_Cell_Btn_Up.SetActive(false);
			
			// 친구 정보 보이기.
			if (m_intBoast_Friend_Page_TotalNum == 1){
				
				GridList_Set_Item_Friend(array_DIC_Friend_Input, 1, array_DIC_Friend_Input.Length);
				
			}  else {
				
				GridList_Set_Item_Friend(array_DIC_Friend_Input, 1, m_intItemNum_InPage);
			}
			
			// 전체 페이지 갯수가 2페이지 이상일 경우 '아래로' 버튼 보이기.
			if (m_intBoast_Friend_Page_TotalNum > 1){
				
				m_objBoastList_Cell_Btn_Down.SetActive(true);
				
			} else {
				
				m_objBoastList_Cell_Btn_Down.SetActive(false);
			}
			
			// 현재 페이지 - 2페이지 이상.
		} else if (intPage_CurrentNo_Input > 1){
			
			// '위로' 버튼 보이기.
			m_objBoastList_Cell_Btn_Up.SetActive(true);
			
			// 마지막 페이지 아닐 때.
			if (intPage_CurrentNo_Input < m_intBoast_Friend_Page_TotalNum){
				
				// 사용자 정보 보이기.
				GridList_Set_Item_Friend(array_DIC_Friend_Input, ((intPage_CurrentNo_Input - 1) * m_intItemNum_InPage) + 1, intPage_CurrentNo_Input * m_intItemNum_InPage);
				
				// '아래로' 버튼 보이기.
				m_objBoastList_Cell_Btn_Down.SetActive(true);
				
				// 마지막 페이지 일 때.
			} else {
				
				// 사용자 정보 보이기.
				GridList_Set_Item_Friend(array_DIC_Friend_Input, ((intPage_CurrentNo_Input - 1) * m_intItemNum_InPage) + 1, array_DIC_Friend_Input.Length);
				
				// '아래로' 버튼 숨기기.
				m_objBoastList_Cell_Btn_Down.SetActive(false);
				
//				m_BoastList_DraggablePanel.Scroll(5.0f);
			}
		}

		FriendList_Grid.repositionNow = true;
		FriendList_Panel.Refresh ();
		//m_BoastList_DraggablePanel.Scroll(3.0f);
		//m_BoastList_DraggablePanel.RestrictWithinBounds(true);
	}

	private void GridList_Set_Item_Friend(Data_InvitationList_Cell[] array_DIC_Friend_Input, int intIndexNo_Start_Input, int intIndexNo_End_Input){
		
		if (array_DIC_Friend_Input.Length != 0){
			
			int intIndexNum_InPage_This = (intIndexNo_End_Input - intIndexNo_Start_Input) + 1;
			
			for (int i = 0; i < intIndexNum_InPage_This; i++){
				
				BoastList_Cell_Item _boastList_Cell_Item = m_array_objBoastList_Cell_Friend[i].GetComponent<BoastList_Cell_Item>() as BoastList_Cell_Item;
				_boastList_Cell_Item = _boastList_Cell_Item;
				_boastList_Cell_Item.Init (array_DIC_Friend_Input[(intIndexNo_Start_Input - 1) + i]);
				_boastList_Cell_Item.Event_Delegate_BoastList_Cell_Item += Delegate_BoastList_Cell_Item;
			}
			
			for (int i = intIndexNum_InPage_This; i < m_intItemNum_InPage; i++){
				
				m_array_objBoastList_Cell_Friend[i].SetActive(false);
			}
			
		} else {

			NoFriends_Label.gameObject.SetActive(true);

			for (int i = 0; i < m_intItemNum_InPage; i++){
				
				m_array_objBoastList_Cell_Friend[i].SetActive(false);
			}
		}
	}
	// ==================== Grid 리스트 아이템정보 설정 - End ====================

	// ==================== EventDelegate 정의 - Start ====================
	private void Delegate_InvitationList_Cell_Up(){
		
		m_intBoast_Friend_Page_CurrentNo--;
		
		GridList_Set_Page(
			m_intBoast_Friend_Page_CurrentNo,
			m_array_DIC_Friend.ToArray());
	}
	
	private void Delegate_InvitationList_Cell_Down(){
		
		m_intBoast_Friend_Page_CurrentNo++;
		
		GridList_Set_Page(
			m_intBoast_Friend_Page_CurrentNo,
			m_array_DIC_Friend.ToArray());
	}

	private void Delegate_BoastList_Cell_Item(string strUserId_Input){

		//Debug.Log ("ST110 BoastList_PopupView.Delegate_BoastList_Cell_Item().strUserId_Input = " + strUserId_Input);

//		gameObject.SetActive (false);

		PopupView_BoastAlert_Show (strUserId_Input);

	}

	private void Delegate_BoastAlert_PopupView(string strUserId_Input){

		//Debug.Log ("ST110 BoastList_PopupView.Delegate_BoastAlert_PopupView().strUserId_Input = " + strUserId_Input);

		//for (int i = 0; i < KakaoLeaderBoard.Instance.appGameFriends.Count; i++){
		//
		//	if (KakaoLeaderBoard.Instance.appGameFriends[i].user_id.Equals(strUserId_Input)){
		//
		//		KakaoLeaderBoard.Instance.appGameFriends[i].message_sent = true;
		//	}
		//
		//	if (i < m_array_DIC_Friend.Count){
		//
		//		if (m_array_DIC_Friend[i].strUserInfo_UserId.Equals(strUserId_Input)){
		//			
		//			m_array_DIC_Friend[i].boolUserInfo_MessageSent = true;
		//		}
		//	}
		//
		//}

		GridList_Set_Page(
			m_intBoast_Friend_Page_CurrentNo,
			m_array_DIC_Friend.ToArray());

	}

	// ==================== EventDelegate 정의 - End ====================




	private void OnClick_Close(){

		gameObject.SetActive (false);

	}

	private void PopupView_BoastAlert_Show(string strUserId_Input){
		
		m_BoastAlert_PopupView.Init (strUserId_Input);
	}
	





}

