using UnityEngine;
using System.Collections;

public class BoastAnim_PopupView : MonoBehaviour {

	// ==================== Layout 변수 선언 - Start ====================
	public GameObject UserRank_Obj;
	public UISprite UserRank_Cell_Medal_Sprite;
	public UILabel UserRank_Cell_Rank_Label;
	public UITexture UserRank_Cell_Profile_Texture;
	public UISprite UserRank_Cell_Submarine_Sprite;
	public UILabel UserRank_Cell_NickName_Label;
	public UILabel UserRank_Cell_Score_Label;
	
	public GameObject MyRank_Obj;
	public UISprite MyRank_Cell_Medal_Sprite;
	public UILabel MyRank_Cell_Rank_Label;
	public UITexture MyRank_Cell_Profile_Texture;
	public UISprite MyRank_Cell_Submarine_Sprite;
	public UILabel MyRank_Cell_NickName_Label;
	public UILabel MyRank_Cell_Score_Label;
	// ==================== Layout 변수 선언 - End ====================

	// ==================== Delegate & Event 인터페이스 선언 - Start ====================
	[HideInInspector]
	public delegate void Delegate_BoastAnim_PopupView(int intClickCode_Input, string strUserID_Input);
	protected Delegate_BoastAnim_PopupView _delegate_BoastAnim_PopupView ;
	public event Delegate_BoastAnim_PopupView Event_Delegate_BoastAnim_PopupView {
		add {
			_delegate_BoastAnim_PopupView = null;
			if (_delegate_BoastAnim_PopupView == null){
				_delegate_BoastAnim_PopupView += value;
			}
		}
		remove {
			_delegate_BoastAnim_PopupView -= value;
		}
	}
	// ==================== Delegate & Event 인터페이스 선언 - End ====================

	public readonly int BoastAnimClick_Close_INT = 0;
	public readonly int BoastAnimClick_Boast_INT = 1;

	private RankListData m_RLD_Me;
	private RankListData m_RLD_User;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void Init(){

		gameObject.SetActive (true);

		Init_01_GetAppGameFriendsData ();

		Init_11_SetLayout_Me ();
		Init_22_SetLayout_User ();

		Init_31_PlayAnim ();

	}

	private void Init_01_GetAppGameFriendsData(){

		m_RLD_Me = new RankListData ();
		m_RLD_User = new RankListData ();
		
		//for (int i = 0; i < KakaoLeaderBoard.Instance.appGameFriends.Count; i++){
		//	
		//	if (KakaoLeaderBoard.Instance.appGameFriends[i].user_id.Equals(KakaoLeaderBoard.Instance.gameMe.user_id)){
		//
		//		m_RLD_Me.userId = KakaoLeaderBoard.Instance.appGameFriends[i].user_id;
		//		m_RLD_Me.intUserInfo_RankNo = KakaoLeaderBoard.Instance.appGameFriends[i].rank;
		//		m_RLD_Me.strUserInfo_ProfileImageUrl = KakaoLeaderBoard.Instance.appGameFriends[i].profile_image_url;
		//		m_RLD_Me.strUserInfo_PublicData = KakaoLeaderBoard.Instance.appGameFriends[i].public_data;
		//		m_RLD_Me.strUserInfo_NickName = KakaoLeaderBoard.Instance.appGameFriends[i].nickname;
		//		m_RLD_Me.intUserInfo_SeasonScore = KakaoLeaderBoard.Instance.appGameFriends[i].season_score;
		//	}
		//}
		//
		//for (int i = 0; i < KakaoLeaderBoard.Instance.appGameFriends.Count; i++) {
		//
		//	if (KakaoLeaderBoard.Instance.appGameFriends[i].rank == (m_RLD_Me.intUserInfo_RankNo + 1)){
		//
		//		m_RLD_User.userId = KakaoLeaderBoard.Instance.appGameFriends[i].user_id;
		//		m_RLD_User.intUserInfo_RankNo = KakaoLeaderBoard.Instance.appGameFriends[i].rank;
		//		m_RLD_User.strUserInfo_ProfileImageUrl = KakaoLeaderBoard.Instance.appGameFriends[i].profile_image_url;
		//		m_RLD_User.strUserInfo_PublicData = KakaoLeaderBoard.Instance.appGameFriends[i].public_data;
		//		m_RLD_User.strUserInfo_NickName = KakaoLeaderBoard.Instance.appGameFriends[i].nickname;
		//		m_RLD_User.intUserInfo_SeasonScore = KakaoLeaderBoard.Instance.appGameFriends[i].season_score;
		//	}
		//}

	}


	private void Init_11_SetLayout_Me (){

		int intMyRank_Before = PlayerPrefs.GetInt (Constant.PREFKEY_MyRank_Before_INT);
		//Debug.Log ("ST110 BoastAnim_PopupView.Init_11_SetLayout_Me().intMyRank_Before = " + intMyRank_Before);

		// 랭킹 이미지 & 텍스트 & BG.
		if (intMyRank_Before < 4) {

			MyRank_Cell_Medal_Sprite.gameObject.SetActive(true);

			if (intMyRank_Before == 1){

				MyRank_Cell_Medal_Sprite.spriteName = "img_medal_1";

			} else if (intMyRank_Before == 2){

				MyRank_Cell_Medal_Sprite.spriteName = "img_medal_2";

			} else if (intMyRank_Before == 3){

				MyRank_Cell_Medal_Sprite.spriteName = "img_medal_3";
			}

			MyRank_Cell_Rank_Label.gameObject.SetActive(false);
				
		} else {

			MyRank_Cell_Medal_Sprite.gameObject.SetActive(false);
		
			MyRank_Cell_Rank_Label.gameObject.SetActive(true);
			MyRank_Cell_Rank_Label.text = intMyRank_Before.ToString();
		}

		// 프로필 이미지.
		if (m_RLD_Me.strUserInfo_ProfileImageUrl == null ||
		    m_RLD_Me.strUserInfo_ProfileImageUrl.Equals("")){
			
			Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
			MyRank_Cell_Profile_Texture.mainTexture = basicTexture;
			
		} else {
			
			StartCoroutine(Network_DownloadImage_Profile(m_RLD_Me.strUserInfo_ProfileImageUrl, MyRank_Cell_Profile_Texture));
		}

		// 잠수함 이미지.
		if (m_RLD_Me.strUserInfo_PublicData == null ||
		    m_RLD_Me.strUserInfo_PublicData.Equals("")){
			
			MyRank_Cell_Submarine_Sprite.gameObject.SetActive(false);
			
		} else {
			
			MyRank_Cell_Submarine_Sprite.gameObject.SetActive(true);

			if (int.Parse(m_RLD_Me.strUserInfo_PublicData) == 0){

				MyRank_Cell_Submarine_Sprite.spriteName = "img_submarine1";

			} else if (int.Parse(m_RLD_Me.strUserInfo_PublicData) == 1){

				MyRank_Cell_Submarine_Sprite.spriteName = "img_submarine4";

			} else if (int.Parse(m_RLD_Me.strUserInfo_PublicData) == 2){

				MyRank_Cell_Submarine_Sprite.spriteName = "img_submarine2";

			} else if (int.Parse(m_RLD_Me.strUserInfo_PublicData) == 3){

				MyRank_Cell_Submarine_Sprite.spriteName = "img_submarine3";
			}

		}
		
		// 닉네임.
		MyRank_Cell_NickName_Label.text = m_RLD_Me.strUserInfo_NickName;
		
		// 점수.
		if(m_RLD_Me.intUserInfo_SeasonScore != 0)
		{
			MyRank_Cell_Score_Label.text = m_RLD_Me.intUserInfo_SeasonScore.ToString("#,#");
		}else
		{
			MyRank_Cell_Score_Label.text = m_RLD_Me.intUserInfo_SeasonScore.ToString();
		}
	}

	private void Init_22_SetLayout_User (){

		int intUserRank_Before = m_RLD_User.intUserInfo_RankNo - 1;
		//Debug.Log ("ST110 BoastAnim_PopupView.Init_22_SetLayout_User().intUserRank_Before = " + intUserRank_Before);

		// 랭킹 이미지 & 텍스트 & BG.
		if (intUserRank_Before < 4) {
			
			UserRank_Cell_Medal_Sprite.gameObject.SetActive(true);
			
			if (intUserRank_Before == 1){
				
				UserRank_Cell_Medal_Sprite.spriteName = "img_medal_1";
				
			} else if (intUserRank_Before == 2){
				
				UserRank_Cell_Medal_Sprite.spriteName = "img_medal_2";
				
			} else if (intUserRank_Before == 3){
				
				UserRank_Cell_Medal_Sprite.spriteName = "img_medal_3";
			}
			
			UserRank_Cell_Rank_Label.gameObject.SetActive(false);
			
		} else {
			
			UserRank_Cell_Medal_Sprite.gameObject.SetActive(false);
			
			UserRank_Cell_Rank_Label.gameObject.SetActive(true);
			UserRank_Cell_Rank_Label.text = intUserRank_Before.ToString();
		}
		
		// 프로필 이미지.
		if (m_RLD_User.strUserInfo_ProfileImageUrl == null ||
		    m_RLD_User.strUserInfo_ProfileImageUrl.Equals("")){
			
			Texture basicTexture = Resources.Load("Image/BasicProfile") as Texture ;
			UserRank_Cell_Profile_Texture.mainTexture = basicTexture;
			
		} else {
			
			StartCoroutine(Network_DownloadImage_Profile(m_RLD_User.strUserInfo_ProfileImageUrl, UserRank_Cell_Profile_Texture));
		}
		
		// 잠수함 이미지.
		if (m_RLD_User.strUserInfo_PublicData == null ||
		    m_RLD_User.strUserInfo_PublicData.Equals("")){
			
			UserRank_Cell_Submarine_Sprite.gameObject.SetActive(false);
			
		} else {
			
			UserRank_Cell_Submarine_Sprite.gameObject.SetActive(true);

			if (int.Parse(m_RLD_User.strUserInfo_PublicData) == 0){
				
				UserRank_Cell_Submarine_Sprite.spriteName = "img_submarine1";
				
			} else if (int.Parse(m_RLD_User.strUserInfo_PublicData) == 1){
				
				UserRank_Cell_Submarine_Sprite.spriteName = "img_submarine4";
				
			} else if (int.Parse(m_RLD_User.strUserInfo_PublicData) == 2){
				
				UserRank_Cell_Submarine_Sprite.spriteName = "img_submarine2";
				
			} else if (int.Parse(m_RLD_User.strUserInfo_PublicData) == 3){
				
				UserRank_Cell_Submarine_Sprite.spriteName = "img_submarine3";
			}
		}
		
		// 닉네임.
		UserRank_Cell_NickName_Label.text = m_RLD_User.strUserInfo_NickName;
		
		// 점수.
		if(m_RLD_User.intUserInfo_SeasonScore != 0)
		{
			UserRank_Cell_Score_Label.text = m_RLD_User.intUserInfo_SeasonScore.ToString("#,#");
		}else
		{
			UserRank_Cell_Score_Label.text = m_RLD_User.intUserInfo_SeasonScore.ToString();
		}
	}


	private void Init_31_PlayAnim (){

		StartCoroutine(PlayUserRankSwithAnim());
		StartCoroutine(PlayMyRankSwithAnim());

	}

	private IEnumerator PlayUserRankSwithAnim()
	{
		Transform userranktransform = UserRank_Obj.transform;
		userranktransform.transform.localPosition = new Vector3(0f,40f, -5f);

		yield return new WaitForSeconds(1f);

		Vector3 startposition = userranktransform.transform.localPosition;
		Vector3 endposition = startposition;
		endposition.y = -startposition.y;
		
		float TotalTime = 0.5f;
		float DX = 30f;
		float VX = 0f;
		float AX = 0f;
		float VY = (endposition.y - startposition.y) / TotalTime;
		AX = -8f * DX / (TotalTime * TotalTime);
		VX = -AX * TotalTime / 2f;
		
		
		float timer = 0f;
		while(timer < TotalTime)
		{
			timer += Time.deltaTime;
			timer = Mathf.Min(timer, TotalTime);
			Vector3 position = startposition + new Vector3(VX * timer + AX * timer * timer / 2f, VY * timer, 0f);
			userranktransform.localPosition = position;
			yield return null;
		}
		userranktransform.localPosition = endposition;
		yield break;
	}

	private IEnumerator PlayMyRankSwithAnim()
	{
		Transform userranktransform = MyRank_Obj.transform;
		userranktransform.transform.localPosition = new Vector3(0f,-40f, -5f);

		yield return new WaitForSeconds(1f);
		Vector3 startposition = userranktransform.transform.localPosition;
		Vector3 endposition = startposition;
		endposition.y = -startposition.y;
		
		float TotalTime = 0.5f;
		float DX = -30f;
		float VX = 0f;
		float AX = 0f;
		float VY = (endposition.y - startposition.y) / TotalTime;
		AX = -8f * DX / (TotalTime * TotalTime);
		VX = -AX * TotalTime / 2f;
		
		
		float timer = 0f;
		while(timer < TotalTime)
		{
			timer += Time.deltaTime;
			timer = Mathf.Min(timer, TotalTime);
			Vector3 position = startposition + new Vector3(VX * timer + AX * timer * timer / 2f, VY * timer, 0f);
			userranktransform.localPosition = position;
			yield return null;
		}
		userranktransform.localPosition = endposition;

		yield return new WaitForSeconds(0.2f);
		Refresh_Ranks();
		yield break;
	}

	private void OnClick_Close(){

		gameObject.SetActive (false);

		if (_delegate_BoastAnim_PopupView != null){
			_delegate_BoastAnim_PopupView(BoastAnimClick_Close_INT, m_RLD_User.userId);
		}
	}

	private void OnClick_Boast(){

		gameObject.SetActive (false);

		if (_delegate_BoastAnim_PopupView != null){
			_delegate_BoastAnim_PopupView(BoastAnimClick_Boast_INT, m_RLD_User.userId);
		}
	}

	IEnumerator Network_DownloadImage_Profile(string strImageUrl_Input, UITexture uiTexture_Input){
		
		//if (strImageUrl_Input != null && !strImageUrl_Input.Equals("")){
		//	
		//	WWW www = new WWW(strImageUrl_Input);
		//	yield return www;
		//	
		//	Texture2D m_Tex2DProfile = www.texture;
		//	
		//	if (m_Tex2DProfile != null){
		//		
		//		uiTexture_Input.mainTexture = m_Tex2DProfile;
		//	}
		//	
		//	www.Dispose();
		//}

		ImageResourceManager.Instance.AddQueue(strImageUrl_Input, uiTexture_Input);
		yield break;
	}
	
	private void Refresh_Ranks(){
		
		int intMyRank_Before = m_RLD_Me.intUserInfo_RankNo;
		
		// 랭킹 이미지 & 텍스트 & BG.
		if (intMyRank_Before < 4) {
			
			MyRank_Cell_Medal_Sprite.gameObject.SetActive(true);
			
			if (intMyRank_Before == 1){
				
				MyRank_Cell_Medal_Sprite.spriteName = "img_medal_1";
				
			} else if (intMyRank_Before == 2){
				
				MyRank_Cell_Medal_Sprite.spriteName = "img_medal_2";
				
			} else if (intMyRank_Before == 3){
				
				MyRank_Cell_Medal_Sprite.spriteName = "img_medal_3";
			}
			
			MyRank_Cell_Rank_Label.gameObject.SetActive(false);
			
		} else {
			
			MyRank_Cell_Medal_Sprite.gameObject.SetActive(false);
			
			MyRank_Cell_Rank_Label.gameObject.SetActive(true);
			MyRank_Cell_Rank_Label.text = intMyRank_Before.ToString();
		}

		int intUserRank_Before = m_RLD_User.intUserInfo_RankNo;
		// 랭킹 이미지 & 텍스트 & BG.
		if (intUserRank_Before < 4) {
			
			UserRank_Cell_Medal_Sprite.gameObject.SetActive(true);
			
			if (intUserRank_Before == 1){
				
				UserRank_Cell_Medal_Sprite.spriteName = "img_medal_1";
				
			} else if (intUserRank_Before == 2){
				
				UserRank_Cell_Medal_Sprite.spriteName = "img_medal_2";
				
			} else if (intUserRank_Before == 3){
				
				UserRank_Cell_Medal_Sprite.spriteName = "img_medal_3";
			}
			
			UserRank_Cell_Rank_Label.gameObject.SetActive(false);
			
		} else {
			
			UserRank_Cell_Medal_Sprite.gameObject.SetActive(false);
			
			UserRank_Cell_Rank_Label.gameObject.SetActive(true);
			UserRank_Cell_Rank_Label.text = intUserRank_Before.ToString();
		}

	}
}
