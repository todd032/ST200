using UnityEngine;
using System.Collections;

public class ShipSelectUI_StatDisplay : MonoBehaviour {

	public UILabel m_TitleText;
	public UILabel m_ValueLabel;
	public UISprite m_GaugeSprite;

	public void Init(string _title)
	{
		m_TitleText.text = _title;
	}


	public void UpdateUI(float _curgauge, float _maxgauge)
	{
		m_ValueLabel.text = Constant.COLOR_MAIN_SHIP_INFO + ((int)_curgauge).ToString();
		m_GaugeSprite.fillAmount = _curgauge / _maxgauge;

		//m_ValueLabel.transform.localPosition = m_GaugeSprite.transform.localPosition + 
		//	Vector3.right * (_curgauge / _maxgauge) * (m_GaugeSprite.width + 10f);
			//Vector3.right * (m_GaugeSprite.width + 10f);
		//Debug.Log("WFWFW: " + m_GaugeSprite.width);
	}
}
