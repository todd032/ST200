using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipSelectUI : MonoBehaviour {

	#region Ship Region
	protected int m_CurShipIndex;
	protected int m_CurShipDisplayIndex;

	public ShipSelectUI_UpgradeConfirm_PopUp m_UpgradeConfirmPopUp;

	public SubShipScroller m_SubShipScroller;

	public Object m_ShipUIObject;
	public List<ShipSelectUI_Object> m_ShipUIObjectList = new List<ShipSelectUI_Object>();
	#endregion
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	bool m_InitFlag = false;
	public void InitUI()
	{		
		m_CurShipIndex = Managers.UserData.GetCurrentUserShipData().IndexNumber;
		m_CurShipDisplayIndex = Managers.GameBalanceData.GetShipDescriptionInfo(m_CurShipIndex).ShipDisplayIndex;

		if(!m_InitFlag)
		{
			m_InitFlag = true;
			LinkedList<ShipDescriptionInfo> shipdescriptionbyinfo = new LinkedList<ShipDescriptionInfo>();
			for(int i = 0; i < Managers.GameBalanceData._shipDescriptionInfoList.Count; i++)
			{
				ShipDescriptionInfo curshipdescriptioninfo = Managers.GameBalanceData._shipDescriptionInfoList[i];
				if(shipdescriptionbyinfo.Count == 0)
				{
					shipdescriptionbyinfo.AddLast(curshipdescriptioninfo);
				}else
				{
					LinkedListNode<ShipDescriptionInfo> curnode = shipdescriptionbyinfo.First;
					while(curnode != null)
					{
						if(curnode.Value.ShipDisplayIndex > curshipdescriptioninfo.ShipDisplayIndex)
						{
							shipdescriptionbyinfo.AddBefore(curnode, curshipdescriptioninfo);
							//Debug.Log ("ADD " + curshipdescriptioninfo.ShipDisplayIndex + " BEFOR: " + curnode.Value.ShipDisplayIndex);
							break;
						}
						curnode = curnode.Next;
						if(curnode == null)
						{
							//Debug.Log ("ADD " + curshipdescriptioninfo.ShipDisplayIndex + " at las");
							shipdescriptionbyinfo.AddLast(curshipdescriptioninfo);
							break;
						}				
					}
				}
			}

			//create 
			foreach(ShipDescriptionInfo info in shipdescriptionbyinfo)
			{
				GameObject go = Instantiate(m_ShipUIObject) as GameObject;
				m_SubShipScroller.AddScrollObject(go.GetComponent<SubShipScrollObject>());

				ShipSelectUI_Object shipselectuiobject = go.GetComponent<ShipSelectUI_Object>();
				shipselectuiobject.InitUI(info.ShipIndex);

				m_ShipUIObjectList.Add(shipselectuiobject);
			}
		}
		m_SubShipScroller.SetScrollPointer((float)m_CurShipDisplayIndex - 1f);
		UpdateUI();
	}
	
	public void UpdateUI()
	{
		for(int i = 0; i < m_ShipUIObjectList.Count; i++)
		{
			m_ShipUIObjectList[i].UpdateUI();
		}
	}


	public bool OnEscapePress()
	{
		if(m_UpgradeConfirmPopUp.OnEscapePress())
		{
			return true;
		}
		return false;
	}

	public void DisplayUpgradeEffect(int _index)
	{
		for(int i = 0; i < m_ShipUIObjectList.Count; i++)
		{
			if(m_ShipUIObjectList[i].m_CurShipIndex == _index)
			{
				m_ShipUIObjectList[i].DisplayUpgradeEffect();
			}
		}
	}

	public void OnClickClose()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		GameUIManager.Instance.m_MainUI.ChangePanel(1);
	}
}
