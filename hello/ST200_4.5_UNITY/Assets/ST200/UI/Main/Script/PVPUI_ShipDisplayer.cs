using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PVPUI_ShipDisplayer : MonoBehaviour {

	public UILabel m_TacticLabel;
	public UISprite m_PlayerShipSprite;
	public List<SubShipDisplayUIObject> m_SubShipUIDisplayObject = new List<SubShipDisplayUIObject>();
	
	protected int m_DisplayTacticIndex = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Init()
	{
		for(int i = 0; i < m_SubShipUIDisplayObject.Count; i++)
		{
			m_SubShipUIDisplayObject[i].Init(i + 1);
		}
		m_DisplayTacticIndex = Managers.UserData.GetCurrentGameCharacter().SelectedTactic;
		
		UpdateUI();
	}
	
	public void UpdateUI()
	{
		m_PlayerShipSprite.spriteName = ImageResourceManager.Instance.GetMainUIShipImageName(Managers.UserData.GetCurrentUserShipData().IndexNumber);
		m_DisplayTacticIndex = Managers.UserData.GetCurrentGameCharacter().SelectedTactic;
		GameCharacter curusercharacter = Managers.UserData.GetCurrentGameCharacter();
		GameCharacterInfoBalance characterbalance = Managers.GameBalanceData.GetGameCharacterInfoBalance(curusercharacter.IndexNumber);
		
		m_PlayerShipSprite.MakePixelPerfect();
		
		for(int i = 1; i <= Managers.GameBalanceData.SubShipEquipAvailableMaxCount; i++)
		{
			if(Managers.UserData.SubShipEquipAvailableSlotCount < i)
			{
				m_SubShipUIDisplayObject[i - 1].UpdateUI(true, false, 0);
			}else
			{
				int subshipindex = Managers.UserData.GetEquipedSubShipIndex(i);
				m_SubShipUIDisplayObject[i - 1].UpdateUI(false, subshipindex != 0, subshipindex);
			}
		}
		
		SubShipTacTic subshiptactic = Managers.GameBalanceData.GetSubShipTactic(m_DisplayTacticIndex);
		List<Vector3> subshipposition = new List<Vector3>();
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX1, subshiptactic.ShipPosY1, 0f) / 10f);
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX2, subshiptactic.ShipPosY2, 0f) / 10f);
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX3, subshiptactic.ShipPosY3, 0f) / 10f);
		subshipposition.Add(new Vector3(subshiptactic.ShipPosX4, subshiptactic.ShipPosY4, 0f) / 10f);
		
		for(int i = 0; i < subshipposition.Count; i++)
		{
			Vector3 newpos = m_PlayerShipSprite.transform.position;
			newpos += subshipposition[i] * 0.65f;
			
			m_SubShipUIDisplayObject[i].transform.position = newpos;
			if(characterbalance.AvailableTacticSlot > i)
			{
				NGUITools.SetActive(m_SubShipUIDisplayObject[i].gameObject, true);
			}else
			{
				NGUITools.SetActive(m_SubShipUIDisplayObject[i].gameObject, false);
			}
		}
		m_TacticLabel.text = "<" + TextManager.Instance.GetString(subshiptactic.TacticNameTextIndex) + ">";
	}
}