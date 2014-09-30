using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TorpedoDisplayer : MonoBehaviour {

	public List<UISprite> m_HeartList = new List<UISprite>();
	public UILabel m_TimerLabel;
	public GameObject m_PlusButton;
	public void UpdateUI(int _curheart, string _timer)
	{
		for(int i = 0; i < m_HeartList.Count ;i++)
		{
			if(i < _curheart)
			{
				m_HeartList[i].spriteName = "main_flag_icon";
			}else
			{
				m_HeartList[i].spriteName = "main_flag_icon_empty";
			}
		}
		if(_timer != "")
		{
			m_TimerLabel.text = _timer;
		}else
		{
			m_TimerLabel.text = "MAX";
		}

		if(_curheart == 0)
		{
			NGUITools.SetActive (m_PlusButton.gameObject, true);
		}else
		{
			NGUITools.SetActive (m_PlusButton.gameObject, false);
		}
	}
}
