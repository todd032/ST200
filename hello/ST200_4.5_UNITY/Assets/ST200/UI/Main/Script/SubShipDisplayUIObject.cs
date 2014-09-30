using UnityEngine;
using System.Collections;

public class SubShipDisplayUIObject : MonoBehaviour {


	public GameObject m_LockedUISprite;
	public GameObject m_NotEquipedUISprite;
	public UISprite m_ShipSprite;

	protected int SlotIndex;
	protected bool m_LockedFlag;
	protected bool m_EquipFlag;
	protected SubShipSelectUI m_SubShipSelectUI;
	protected int CurSelectedSubShipIndex;
	public void Init(int _slotindex)
	{
		SlotIndex = _slotindex;
	}

	public void UpdateUI(bool _locked, bool _equiped, int _shipindex)
	{
		m_LockedFlag = _locked;
		m_EquipFlag = _equiped;
		CurSelectedSubShipIndex = _shipindex;

		if(m_LockedFlag)
		{
			NGUITools.SetActive(m_LockedUISprite.gameObject, true);
			NGUITools.SetActive(m_ShipSprite.gameObject, false);
		}else
		{
			NGUITools.SetActive(m_LockedUISprite.gameObject, false);
			NGUITools.SetActive(m_ShipSprite.gameObject, true);
		}

		if(m_EquipFlag)
		{
			NGUITools.SetActive(m_NotEquipedUISprite.gameObject, false);
			NGUITools.SetActive(m_ShipSprite.gameObject, true);
			m_ShipSprite.spriteName = ImageResourceManager.Instance.GetMainUISubShipImageName(_shipindex);
			m_ShipSprite.MakePixelPerfect();
		}else
		{
			NGUITools.SetActive(m_ShipSprite.gameObject, false);
			NGUITools.SetActive(m_NotEquipedUISprite.gameObject, true);
		}
	}

	public void OnClickShip()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);


		if(m_LockedFlag)
		{
			//show popup to open
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
		}else if(GameUIManager.Instance.m_MainUI.CurMode != 2)
		{
			GameUIManager.Instance.m_MainUI.ChangePanel(2);
		}else if(!m_EquipFlag)
		{
			//if not equiped
		}else
		{
			//if not locked and equiped => unequip it
			UserSubShipData data = Managers.UserData.GetUserSubShipData(CurSelectedSubShipIndex);
			data.IsSelect = 0;
			Managers.UserData.SetUserSubShipData(data);
		}

		GameUIManager.Instance.m_MainUI.UpdateUI();
	}
}
