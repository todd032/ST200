using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrossShockPopupView : MonoBehaviour {

	//public UIDraggablePanel m_DraggablePanel;
	public UIGrid m_UIGrid;
	public Object m_CrossShockAppInfoObject;

	public List<CrossShockAppInfo> m_CrossShockAppInfoList = new List<CrossShockAppInfo>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool CheckPopupView()
	{
		//check crossshock and decide to show or not.
		if(CrossShockManager.Instance.AppInfoList.Count != 0)
		{
			NGUITools.SetActive(gameObject, true);
			Init ();

			return true;
		}else
		{
			NGUITools.SetActive(gameObject, false);

			return false;
		}
	}

	protected void Init()
	{
		List<CrossShockAppInfo> infolist = CrossShockManager.Instance.AppInfoList;
		for(int i = 0; i < infolist.Count; i++)
		{
			GameObject go = Instantiate(m_CrossShockAppInfoObject) as GameObject;
			CrossShockInfo appinfo = go.GetComponent<CrossShockInfo>();
			appinfo.Init(infolist[i]);

			appinfo.transform.parent = m_UIGrid.transform;
			appinfo.transform.localScale = Vector3.one;
		}

		m_UIGrid.Reposition();
	}

	public void OnClickCloseButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		NGUITools.SetActive (gameObject, false);
		CrossShockManager.Instance.CheckReward(0);
	}
}
