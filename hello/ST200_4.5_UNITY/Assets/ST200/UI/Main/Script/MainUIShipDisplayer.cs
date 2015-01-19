using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainUIShipDisplayer : MonoBehaviour {

	public UILabel m_TitleLabel;
	public UILabel m_TacticLabel;
	public UISprite m_PlayerShipSprite;
	public List<SubShipDisplayUIObject> m_SubShipUIDisplayObject = new List<SubShipDisplayUIObject>();

	protected int m_DisplayTacticIndex = 0;

	// Use this for initialization
	void Start () {
		m_TitleLabel.text = Constant.COLOR_MAIN_SUBTITLE + TextManager.Instance.GetString(227);
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
		Invoke("UpdateUI", 0.5f);
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
			newpos += subshipposition[i];

			m_SubShipUIDisplayObject[i].transform.position = newpos;
			if(characterbalance.AvailableTacticSlot > i)
			{
				NGUITools.SetActive(m_SubShipUIDisplayObject[i].gameObject, true);
			}else
			{
				NGUITools.SetActive(m_SubShipUIDisplayObject[i].gameObject, false);
			}
		}
		m_TacticLabel.text = TextManager.Instance.GetString(subshiptactic.TacticNameTextIndex);
	}
	
	public bool OnEscapePress()
	{
		return false;
	}

	public void OnClickNextTactic()
	{
		GameCharacter curcharacter = Managers.UserData.GetCurrentGameCharacter();
		GameCharacterInfoBalance characterbalance = Managers.GameBalanceData.GetGameCharacterInfoBalance(curcharacter.IndexNumber);

		int curdisplaytacticindex = 0;
		for(int i = 0; i < characterbalance.AvailableTacticList.Length; i++)
		{
			if(m_DisplayTacticIndex == characterbalance.AvailableTacticList[i])
			{
				curdisplaytacticindex = i;
			}
		}
		curdisplaytacticindex++;
		if(curdisplaytacticindex == characterbalance.AvailableTacticList.Length)
		{
			curdisplaytacticindex = 0;
		}

		m_DisplayTacticIndex = characterbalance.AvailableTacticList[curdisplaytacticindex];	
		curcharacter.SelectedTactic = m_DisplayTacticIndex;
		Managers.UserData.SetGameCharacter(curcharacter);
		UpdateUI();
	
	}

	public void OnClickPrevTactic()
	{
		GameCharacter curcharacter = Managers.UserData.GetCurrentGameCharacter();
		GameCharacterInfoBalance characterbalance = Managers.GameBalanceData.GetGameCharacterInfoBalance(curcharacter.IndexNumber);
		
		int curdisplaytacticindex = 0;
		for(int i = 0; i < characterbalance.AvailableTacticList.Length; i++)
		{
			if(m_DisplayTacticIndex == characterbalance.AvailableTacticList[i])
			{
				curdisplaytacticindex = i;
			}
		}
		curdisplaytacticindex--;
		if(curdisplaytacticindex < 0)
		{
			curdisplaytacticindex = characterbalance.AvailableTacticList.Length - 1;
		}		
		m_DisplayTacticIndex = characterbalance.AvailableTacticList[curdisplaytacticindex];

		curcharacter.SelectedTactic = m_DisplayTacticIndex;
		Managers.UserData.SetGameCharacter(curcharacter);
		UpdateUI();
	}

	public void OnClickShipImage()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(GameUIManager.Instance.m_MainUI.CurMode != 0)
		{
			GameUIManager.Instance.m_MainUI.ChangePanel(0);
			GameUIManager.Instance.m_MainUI.m_ShipSelectUI.UpdateUI();
		}else
		{
			GameUIManager.Instance.m_MainUI.ChangePanel(1);
		}
	}
}
