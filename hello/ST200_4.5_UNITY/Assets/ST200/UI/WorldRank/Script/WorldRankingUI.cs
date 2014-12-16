using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldRankingUI : MonoBehaviour {

	public int RankMaxPeoplePerPage = 50;
	protected int RankCurPage = 0;

	public UILabel m_TitleLabel;
	public UIScrollView m_ScrollView;
	public UIGrid m_Grid;

	public Object m_WorldRankUIObject;
	public List<WorldRankUIObject> m_WorldRankUIObjectList = new List<WorldRankUIObject>();

	public GameObject m_NextButton;
	public GameObject m_PrevButton;
	void Awake()
	{		
		for(int i = 0; i < RankMaxPeoplePerPage; i++)
		{
			CreateWorldRankUIObject();
		}
		NGUITools.SetActive(m_NextButton.gameObject, false);
		NGUITools.SetActive(m_PrevButton.gameObject, false);
		m_NextButton.transform.parent = null;
		m_Grid.Reposition();
		m_NextButton.transform.parent = m_Grid.transform;
		m_Grid.Reposition();
	}

	void Update()
	{
#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			OnClickNextButton();
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			OnClickPrevButton();
		}
#endif

		UpdateLoadingImage();
	}


	public UISprite m_LoadingSprite;
	public int m_LoadingCurFrame = 0;
	public int m_LoadingUpdateframe = 3;
	public void UpdateLoadingImage()
	{
		m_LoadingCurFrame++;
		if(m_LoadingCurFrame % m_LoadingUpdateframe == 0)
		{
			m_LoadingSprite.transform.Rotate(Vector3.forward, -24f);
		}
	}
	
	public void ShowLoadingUI()
	{
		NGUITools.SetActive(m_LoadingSprite.gameObject, true);
	}
	
	public void HideLoadingUI()
	{
		NGUITools.SetActive(m_LoadingSprite.gameObject, false);
	}

	public void ShowUI()
	{
		//Debug.Log("SHOW UI");
		NGUITools.SetActive (gameObject, true);
		InitWorldRankList();
		SaveCurrent();
	}

	public void CloseUI()
	{
		NGUITools.SetActive (gameObject, false);
	}

	public void InitWorldRankList()
	{
		m_TitleLabel.text = Constant.COLOR_RANKING_TITLE + TextManager.Instance.GetString(73);
		RankCurPage = 0;
	}

	protected void SaveCurrent()
	{
		
		int totalscore = 0;
		for(int i = 0; i < Managers.UserData.m_UserStageDataList.Count; i++)
		{
			UserStageData data = Managers.UserData.m_UserStageDataList[i];
			totalscore += data.MaxScore;
		}
		//if(totalscore == 0)
		//{
		//	totalscore = 1;
		//}
		//Debug.Log("SAVE SCORE: " + totalscore);
		HideLoadingUI();
		WorldRankManager.Instance.SaveWorldRankingEvent += (int _result) => 
		{
			WorldRankManager.Instance.GetWorldRankingEvent += GetWorldRankData;
			WorldRankManager.Instance.GetWorldRanking(Managers.UserData.UserID);
			ShowLoadingUI();
		};

		int maxstageopenindex = 0;
		for(int i = 0; i < Managers.UserData.m_UserStageDataList.Count; i++)
		{
			UserStageData stagedata = Managers.UserData.m_UserStageDataList[i];
			if(stagedata.IsOpen)
			{
				if(stagedata.IndexNumber > maxstageopenindex)
				{
					maxstageopenindex = stagedata.IndexNumber;
				}
			}
		}
		WorldRankManager.Instance.SaveWorldRanking(Managers.UserData.UserID,
		                                           Managers.UserData.UserNickName,
		                                           totalscore,
		                                           maxstageopenindex,
		                                           Managers.UserData.GetCurrentGameCharacter().IndexNumber.ToString());
	}

	protected void UpdateWorldRank()
	{
		//turn off all the world rankuiobject
		NGUITools.SetActive(m_PrevButton.gameObject, false);
		NGUITools.SetActive(m_NextButton.gameObject, false);
		for(int i = 0; i < 50; i++)
		{
			
			NGUITools.SetActive(m_WorldRankUIObjectList[i].gameObject, false);
		}
		
		StartCoroutine(IEGetWorldRank());
	}

	protected void GetWorldRankData(int _result)
	{
		//Debug.Log("HA: " + _result);
		if(_result == Constant.NETWORK_RESULTCODE_OK)
		{
			//turn off all the world rankuiobject
			for(int i = 0; i < 50; i++)
			{

				NGUITools.SetActive(m_WorldRankUIObjectList[i].gameObject, false);
			}

			StartCoroutine(IEGetWorldRank());
		}else
		{

		}

		HideLoadingUI();
	}

	protected IEnumerator IEGetWorldRank()
	{
		yield return null;

		if(RankCurPage == 0)
		{
			NGUITools.SetActive(m_PrevButton.gameObject, false);
		}else
		{
			NGUITools.SetActive(m_PrevButton.gameObject, true);
		}
		
		if(WorldRankManager.Instance.m_WorldRankingData.Count > (RankCurPage + 1) * RankMaxPeoplePerPage)
		{
			NGUITools.SetActive(m_NextButton.gameObject, true);
		}else
		{
			NGUITools.SetActive(m_NextButton.gameObject, false);
		}

		//BetterList<Transform> betterlist = m_Grid.GetChildList();
		////betterlist.Release();
		//m_Grid.GetChildList().Remove(m_PrevButton.transform);
		//m_Grid.GetChildList().Insert(0, m_PrevButton.transform);
		int currankpeoplenumb = RankCurPage * RankMaxPeoplePerPage;
		for(int i = 0; i < RankMaxPeoplePerPage; i++)
		{
			if(i + currankpeoplenumb < WorldRankManager.Instance.m_WorldRankingData.Count)
			{
				WorldRankData worldrankdata = WorldRankManager.Instance.m_WorldRankingData[currankpeoplenumb + i];
				NGUITools.SetActive(m_WorldRankUIObjectList[i].gameObject, true);
				
				WorldRankUIObject curuiobject = m_WorldRankUIObjectList[i];
				curuiobject.Init(worldrankdata.UserNickName, worldrankdata.UserRank, worldrankdata.UserScore, worldrankdata.UserStage, worldrankdata.UserCharacter,
				                 (i + currankpeoplenumb) == 0,
				                 worldrankdata.Country);
				//m_Grid.GetChildList().Remove(curuiobject.transform);
				//m_Grid.GetChildList().Insert(i + 1, curuiobject.transform);
			}
			//yield return new WaitForSeconds(0.1f);
		}
		//m_Grid.GetChildList().Remove(m_NextButton.transform);
		//m_Grid.GetChildList().Insert(99, m_NextButton.transform);
		//Debug.Log(m_Grid.GetIndex(m_PrevButton.transform));
		//Debug.Log(m_Grid.GetIndex(m_NextButton.transform));
		m_NextButton.transform.localPosition = Vector3.up * -9999f;
		m_Grid.Reposition();

		m_ScrollView.ResetPosition();

		yield break;
	}

	protected void CreateWorldRankUIObject()
	{
		GameObject go = Instantiate(m_WorldRankUIObject) as GameObject;
		WorldRankUIObject uiobject = go.GetComponent<WorldRankUIObject>();
		go.transform.parent = m_Grid.transform;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = Vector3.zero;
		m_Grid.AddChild(go.transform, m_WorldRankUIObjectList.Count + 1);
		NGUITools.SetActive(go, false);

		m_WorldRankUIObjectList.Add(uiobject);
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		CloseUI();
	}

	public void OnClickNextButton()
	{
		if(WorldRankManager.Instance.m_WorldRankingData.Count > (RankCurPage + 1) * RankMaxPeoplePerPage)
		{
			RankCurPage += 1;
			UpdateWorldRank();
		}
	}

	public void OnClickPrevButton()
	{
		if(RankCurPage > 0)
		{
			RankCurPage -= 1;
			UpdateWorldRank();
		}
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			CloseUI();
			return true;
		}
		
		return false;
	}
}