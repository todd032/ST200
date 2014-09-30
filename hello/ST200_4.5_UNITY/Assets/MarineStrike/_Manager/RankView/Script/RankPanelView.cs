using UnityEngine;
using System.Collections;

public class RankPanelView : MonoBehaviour {

	[HideInInspector]
	public delegate void RankPanelViewDelegate(RankPanelView rankPanelView, int state);
	protected RankPanelViewDelegate _rankPanelViewDelegate ;
	public event RankPanelViewDelegate RankPanelViewEvent {
		add{
			
			_rankPanelViewDelegate = null ;
			
			if (_rankPanelViewDelegate == null)
        		_rankPanelViewDelegate += value;
        }
		
		remove{
            _rankPanelViewDelegate -= value;
		}
	}
	
	
	//public RankClanPanel _rankClanPanel ;
	public RankTopPanel _rankTopPanel ;
	
	public RankingIndicatorView _rankingIndicatorView ;
	
	private int _currentViewState ;
	
	private bool _isAfreecaTVLogin = false ;
	
	private float m_DraggablePanelYPos_Start = 0f;

	public UILabel m_GuestModeRequireLoginLabel;
	private void Awake() {

//		//Debug.Log("ST110 RankPanelView.Awake() Run!!!!!");

//		_rankClanPanel.RankClanPanelEvent += RankClanPanelEvent ;
//		_rankTopPanel.RankTopPanelEvent += RankTopPanelEvent ;
//		
//		_rankingIndicatorView.InitLoadRankingIndicatorView() ;
	}
	
	private void Start() {
		if(Managers.UserData.IsGuestMode)
		{
			m_GuestModeRequireLoginLabel.gameObject.SetActive(true);
			m_GuestModeRequireLoginLabel.text = TextManager.Instance.GetString(187);
		}else
		{
			m_GuestModeRequireLoginLabel.gameObject.SetActive(false);
		}
	}
	
	private void Update() {
	
	}
	
	//-- Delegate
	private void RankClanPanelEvent(RankClanPanel rankClanPanel, int state) {
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		if(state == 1001) { // 1001 : Ranking Indicator Start!!
			_rankingIndicatorView.LoadRankingIndicatorView() ;
		}else if(state == 1002) { // 1002 : Ranking Indicator Stop!!
			_rankingIndicatorView.RemoveRankingIndicatorView() ;
		}else if(state == 1101) { // 1101 : RankingManager Indicator Start!!
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 1102) { // 1102 : RankingManager Indicator Stop!!
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 2101) { // 2101 : 선물을 보냈습니다.
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 2102) { // 2102 : 선물을 보내실 수 없습니다.
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 5001) { // 5001 : 클랜장 기능으로 사용하실 수 없습니다.
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}
	}
	
	private void RankTopPanelEvent(RankTopPanel rankTopPanel, int state) {
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}
		if(state == 1001) { // 1001 : Ranking Indicator Start!!
			_rankingIndicatorView.LoadRankingIndicatorView() ;
		}else if(state == 1002) { // 1002 : Ranking Indicator Stop!!
			_rankingIndicatorView.RemoveRankingIndicatorView() ;
		}else if(state == 1101) { // 1101 : RankingManager Indicator Start!!
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 1102) { // 1102 : RankingManager Indicator Stop!!
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 2101) { // 2101 : 선물을 보냈습니다.
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}else if(state == 2102) { // 2102 : 선물을 보내실 수 없습니다.
			if(_rankPanelViewDelegate != null){
				_rankPanelViewDelegate(this, state) ;
			}
		}
	}
	
	
	
	public void InitRankPanelView(){
		
		
#if UNITY_EDITOR
		
#else

		

#endif

	}
	
	public void LoadRankPanelView(int currentViewState) {


#if UNITY_EDITOR
		
#else

#endif		
		
	}
	
	public void ReloadRankPanelView() {
		
#if UNITY_EDITOR
		
#else

#endif
		
	}
	
	
	private void SetRankPanelView(int currentViewState){
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		if(currentViewState == 1){ // 1: ClanRank   2: TopRank

			DisplayClanRankingPanel() ;
			
		}else if(currentViewState == 2){ // 1: Membership   2: Facebook

			DisplayTopRankingPanel() ;
			
		}
		
	}
	
	
	private void DisplayClanRankingPanel(){

		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		//NGUITools.SetActive(_rankClanPanel.gameObject, true) ;
		NGUITools.SetActive(_rankTopPanel.gameObject, false) ;
		
		//_rankClanPanel.LoadRankClanPanel() ;

	}
	
	private void DisplayTopRankingPanel (){
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		//NGUITools.SetActive(_rankClanPanel.gameObject, false) ;
		NGUITools.SetActive(_rankTopPanel.gameObject, true) ;
		
		_rankTopPanel.LoadRankTopPanel() ;
		
	}
	
	
	public void ClosePopupView(){
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		//if(_rankClanPanel.gameObject.activeSelf == true){
		//	_rankClanPanel.ClosePopupView() ;
		//}

	}	
	
	private void OnClickRankClanButton() {
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		if(_currentViewState == 2) {
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			_currentViewState = 1 ;
			SetRankPanelView(_currentViewState) ;
		}
	}
	
	private void OnClickRankTopButton() {
		if(Managers.UserData.IsGuestMode)
		{
			return;
		}

		if(_currentViewState == 1) {
			
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			
			_currentViewState = 2 ;
			SetRankPanelView(_currentViewState) ;
		}
	}



	/* Remove !!!!!
	private void OnClickRankClanBattleButton(){

		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		if(_rankPanelViewDelegate != null){
			_rankPanelViewDelegate(this, 10001) ; // Open ClanBattle Panel
		}
	}
	*/ // End Remove !!!!!


	// ==================== Layout 관련 변수 선언 - Start ====================
	public UIButton m_RankTop_Friend_Button;
	public UISprite m_RankTop_Friend_BG_Sprite;
	public UIButton m_RankTop_World_Button;
	public UISprite m_RankTop_World_BG_Sprite;

	public UIPanel m_RankList_Panel;
	public UIGrid m_RankList_Grid;
	// ==================== Layout 관련 변수 선언 - End ====================

	// ==================== Prefab 관련 변수 선언 - Start ====================
	public Object m_objPreFab_RankList_Btn_Up;
	public Object m_objPreFab_RankList_Btn_Down;
	public Object m_objPreFab_RankList_Cell;

	private GameObject m_objRankList_Cell_Btn_Up;
	private GameObject m_objRankList_Cell_Btn_Down;
	private GameObject m_objRankList_Cell_Me;
	private GameObject[] m_array_objRankList_Cell_User;
	// ==================== Prefab 관련 변수 선언 - End ====================

	// ==================== 리스트 아이템 정보 관련 변수 선언 - Start ====================
	RankList_Btn_Up m_RankItemBtn_Up_Up;
	RankList_Btn_Down m_RankItemBtn_Down;

	private RankListData m_RLData_Rank_Friend_Me;
	private RankListData [] m_array_RLData_Rank_Friend_User;
	private int m_intRank_Friend_InfoList_Size;
	private int m_intRank_Friend_InfoList_Size_Test;
	private int m_intRank_Friend_Page_TotalNum;
	private int m_intRank_Friend_Page_CurrentNo;

	private RankListData m_RLData_Rank_World_Me;
	private RankListData [] m_array_RLData_Rank_World_User;
	private int m_intRank_World_InfoList_Size;
	private int m_intRank_World_InfoList_Size_Test;
	private int m_intRank_World_Page_TotalNum;
	private int m_intRank_World_Page_CurrentNo;
	// ==================== 리스트 아이템 정보 관련 변수 선언 - End ====================

	// ==================== 기타 변수 선언 - Start ====================
	private bool m_boolKakaoTest_Friend;
	private bool m_boolKakaoTest_World;
	private int m_intItemNum_InPage;

	//private UIDraggablePanel m_RankList_DraggablePanel;

	[HideInInspector]
	public enum eRankType {Rank_Friend, Rank_World};
	protected eRankType m_CurRankType = eRankType.Rank_Friend;
	// ==================== 기타 변수 선언 - End ====================


	public void Init(){

		if(Managers.UserData.IsGuestMode)
		{
			return;
		}
	}
}
