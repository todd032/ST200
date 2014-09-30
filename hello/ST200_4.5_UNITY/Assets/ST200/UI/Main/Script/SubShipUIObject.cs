using UnityEngine;
using System.Collections;

public class SubShipUIObject : MonoBehaviour {

	public UILabel m_NameLabel;
	public UILabel m_SelectLabel;
	public UILabel m_SelectedLabel;
	public UISprite m_ShipSprite;

	public GameObject m_SelectButton;
	public GameObject m_SelectedButton;

	public SubShipSelectUI m_SubShipSelectUI;
	protected int CurSubShipIndex;

	public void Init(SubShipSelectUI _selectui)
	{
		m_SubShipSelectUI = _selectui;
		m_SelectLabel.text = Constant.COLOR_SUBSHIP_SELECT + TextManager.Instance.GetString(96);
		m_SelectedLabel.text = Constant.COLOR_SUBSHIP_SELECTED + TextManager.Instance.GetString(97);
	}

	public void UpdateUI(int _index)
	{
		CurSubShipIndex = _index;
		UserSubShipData usersubshipdata = Managers.UserData.GetUserSubShipData(CurSubShipIndex);
		SubShipDescriptionInfo description = Managers.GameBalanceData.GetSubShipDescriptionInfo(CurSubShipIndex);

		m_NameLabel.text = Constant.COLOR_SUBSHIP_SHIPNAME + description.ShipName;

		if(usersubshipdata.IsSelect == 0)
		{
			NGUITools.SetActive(m_SelectButton.gameObject, true);
			NGUITools.SetActive(m_SelectedButton.gameObject, false);
		}else
		{
			NGUITools.SetActive(m_SelectButton.gameObject, false);
			NGUITools.SetActive(m_SelectedButton.gameObject, true);
		}
		m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUISubShipImageName(CurSubShipIndex);
		m_ShipSprite.MakePixelPerfect();
	}

	public void OnClickSelectButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//try to equip the ship
		bool isopen = true;
		bool equipedflag = false;
		for(int i = 1; i <= Managers.GameBalanceData.SubShipEquipAvailableMaxCount; i++)
		{
			if(Managers.UserData.SubShipEquipAvailableSlotCount < i)
			{
				//if not open byebye
				isopen = false;
				if(Managers.UserData.SubShipEquipAvailableSlotCount == 1)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT2);
				}else if(Managers.UserData.SubShipEquipAvailableSlotCount == 2)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT3);
				}else if(Managers.UserData.SubShipEquipAvailableSlotCount == 3)
				{
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_OPEN_SLOT4);
				}
				break;
			}
			if(Managers.UserData.GetEquipedSubShipIndex(i) == 0)
			{
				equipedflag = true;
				//equip it
				UserSubShipData usersubshipdata = Managers.UserData.GetUserSubShipData(CurSubShipIndex);
				usersubshipdata.IsSelect = i;
				Managers.UserData.SetUserSubShipData(usersubshipdata);
				break;
			}
		}

		//if can't equip show pop up to unlock or unequip previous ship
		if(isopen && !equipedflag)
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNALBLE_TO_EQUIP);
		}

		m_SubShipSelectUI.UpdateUI();
	}

	public void OnClickShowInfo()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		//m_SubShipSelectUI.m_SubShipUpgradePopup.ShowUI(CurSubShipIndex);
	}
}
