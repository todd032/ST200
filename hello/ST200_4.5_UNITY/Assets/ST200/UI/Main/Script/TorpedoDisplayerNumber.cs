using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TorpedoDisplayerNumber : MonoBehaviour {

	public UILabel m_FlagCountLabel;
	public UILabel m_TimerLabel;
	public GameObject m_PlusButton;
	public void UpdateUI(int _curheart, string _timer)
	{
		m_FlagCountLabel.text = "X" + _curheart.ToString();
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
