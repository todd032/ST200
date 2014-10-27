using UnityEngine;
using System.Collections;

public class PVPUI_Menu_Button : MonoBehaviour {

	public GameObject m_SelectedFrameSprite;

	public void SetSelected(bool _selected)
	{
		NGUITools.SetActive(m_SelectedFrameSprite.gameObject ,_selected);
	}
}
