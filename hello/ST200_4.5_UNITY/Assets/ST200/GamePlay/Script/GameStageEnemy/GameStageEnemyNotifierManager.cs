using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStageEnemyNotifierManager : MonoBehaviour {

	public Camera m_GameCamera;
	public Camera m_UICamera;

	public Object m_MarkUIObject;
	public List<GameObject> m_MarkUIList = new List<GameObject>();

	public Object m_ItemShipMarkUIObject;
	public List<GameObject> m_ItemShipMarkUIList = new List<GameObject>();
	public void UpdateItemShipTargetUI(List<GameStageEnemyObject> _enemylist)
	{
		for(int i = 0; i < m_ItemShipMarkUIList.Count; i++)
		{
			NGUITools.SetActive(m_ItemShipMarkUIList[i].gameObject, false);
		}
		
		int curmarkcount = 0;
		for(int i = 0; i < _enemylist.Count; i++)
		{
			if(_enemylist[i].m_Type == 101)
			{
				Vector3 screenpos = m_GameCamera.WorldToScreenPoint(_enemylist[i].transform.position);
				
				bool exceeded = false;
				if(screenpos.x < 0f || screenpos.x > Screen.width || 
				   screenpos.y < 0f || screenpos.y > Screen.height)
				{
					exceeded = true;
				}
				if(exceeded)
				{
					GameObject selectedgameobject;
					if(curmarkcount < m_ItemShipMarkUIList.Count)
					{
						selectedgameobject = m_ItemShipMarkUIList[curmarkcount].gameObject;
					}else
					{
						GameObject go = Instantiate(m_ItemShipMarkUIObject) as GameObject;
						go.transform.parent = transform;
						go.transform.localScale = Vector3.one;
						selectedgameobject = go;
						m_ItemShipMarkUIList.Add(go);
					}
					
					curmarkcount++;
					
					screenpos.x = Mathf.Clamp(screenpos.x, 50, Screen.width - 50);
					screenpos.y = Mathf.Clamp(screenpos.y, Screen.height / 5, Screen.height - Screen.height/ 7);
					screenpos.z = 0f;
					float angle = Vector3.Angle(Vector3.right, new Vector3(screenpos.x - Screen.width / 2,
					                                                       screenpos.y - Screen.height / 2,
					                                                       0f));
					if(screenpos.y < Screen.height / 2)
					{
						angle = 360f - angle;
					}
					
					
					Vector3 newworldpos = m_UICamera.ScreenToWorldPoint(screenpos);
					selectedgameobject.transform.position = newworldpos;
					selectedgameobject.transform.eulerAngles = new Vector3(0f, 0f, angle);
					NGUITools.SetActive(selectedgameobject, true);
				}
			}
		}
	}

	public void UpdateTargetUI(List<GameStageEnemyObject> _enemylist)
	{
		for(int i = 0; i < m_MarkUIList.Count; i++)
		{
			NGUITools.SetActive(m_MarkUIList[i].gameObject, false);
		}

		int curmarkcount = 0;
		for(int i = 0; i < _enemylist.Count; i++)
		{
			if(_enemylist[i].m_Marked)
			{
				Vector3 screenpos = m_GameCamera.WorldToScreenPoint(_enemylist[i].transform.position);
				
				bool exceeded = false;
				if(screenpos.x < 0f || screenpos.x > Screen.width || 
				   screenpos.y < 0f || screenpos.y > Screen.height)
				{
					exceeded = true;
				}
				if(exceeded)
				{
					GameObject selectedgameobject;
					if(curmarkcount < m_MarkUIList.Count)
					{
						selectedgameobject = m_MarkUIList[curmarkcount].gameObject;
					}else
					{
						GameObject go = Instantiate(m_MarkUIObject) as GameObject;
						go.transform.parent = transform;
						go.transform.localScale = Vector3.one;
						selectedgameobject = go;
						m_MarkUIList.Add(go);
					}

					curmarkcount++;

					screenpos.x = Mathf.Clamp(screenpos.x, 50, Screen.width - 50);
					screenpos.y = Mathf.Clamp(screenpos.y, Screen.height / 5, Screen.height - Screen.height/ 7);
					screenpos.z = 0f;
					float angle = Vector3.Angle(Vector3.right, new Vector3(screenpos.x - Screen.width / 2,
					                                                       screenpos.y - Screen.height / 2,
					                                                       0f));
					if(screenpos.y < Screen.height / 2)
					{
						angle = 360f - angle;
					}


					Vector3 newworldpos = m_UICamera.ScreenToWorldPoint(screenpos);
					selectedgameobject.transform.position = newworldpos;
					selectedgameobject.transform.eulerAngles = new Vector3(0f, 0f, angle);
					NGUITools.SetActive(selectedgameobject, true);
				}
			}
		}
	}
}
