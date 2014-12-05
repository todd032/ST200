using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_ShipDisplayerOpp : MonoBehaviour {

	public UILabel m_TacticLabel;
	public UISprite m_PlayerShipSprite;
	public List<UISprite> m_SubShipUIDisplayObject = new List<UISprite>();

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Init(UserInfoData _userinfodata)
	{
		//for(int i = 0; i < m_SubShipUIDisplayObject.Count; i++)
		//{
		//	m_SubShipUIDisplayObject[i].Init(i + 1);
		//}
		m_PlayerShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(_userinfodata.ShipIndex);
		m_PlayerShipSprite.MakePixelPerfect();
		
		for(int i = 0; i < _userinfodata.SubShipIndexList.Length; i++)
		{
			int cursubshipindex = _userinfodata.SubShipIndexList[i];
			if(cursubshipindex != 0)
			{
				NGUITools.SetActive (m_SubShipUIDisplayObject[i].gameObject, true);
				m_SubShipUIDisplayObject[i].spriteName = ImageResourceManager.Instance.GetMainUISubShipImageName(cursubshipindex);
				m_SubShipUIDisplayObject[i].MakePixelPerfect();
			}else
			{
				NGUITools.SetActive (m_SubShipUIDisplayObject[i].gameObject, false);
			}
		}
		
		SubShipTacTic subshiptactic = Managers.GameBalanceData.GetSubShipTactic(_userinfodata.TacticIndex);
		List<Vector3> subshipposition = new List<Vector3>();
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX1, subshiptactic.ShipPosY1, 0f) / 10f);
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX2, subshiptactic.ShipPosY2, 0f) / 10f);
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX3, subshiptactic.ShipPosY3, 0f) / 10f);
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX4, subshiptactic.ShipPosY4, 0f) / 10f);
		
		for(int i = 0; i < subshipposition.Count; i++)
		{
			Vector3 newpos = m_PlayerShipSprite.transform.position;
			newpos += subshipposition[i] * 0.5f;
			
			m_SubShipUIDisplayObject[i].transform.position = newpos;
		}
		m_TacticLabel.text = "<" + TextManager.Instance.GetString(subshiptactic.TacticNameTextIndex) + ">";
	}
}