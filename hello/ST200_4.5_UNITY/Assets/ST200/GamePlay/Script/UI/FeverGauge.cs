using UnityEngine;
using System.Collections;

public class FeverGauge : MonoBehaviour {

	public UISprite m_GaugeSprite;
	public GameObject m_FullEffect;

	protected float curdisplayval = 0f;
	void Awake()
	{
		m_GaugeSprite.fillAmount = 0f;
		curdisplayval = 0f;
		NGUITools.SetActive(m_FullEffect.gameObject, false);
	}

	public void UpdateUI(float _curgauge, float _maxgauge)
	{
		float dest = _curgauge / _maxgauge;
		curdisplayval += (dest - curdisplayval) * 0.5f;

		if(dest >= 1f && curdisplayval > 0.95f)
		{
			curdisplayval = 1f;
		}

		m_GaugeSprite.fillAmount = curdisplayval;

		if(dest >= 1f)
		{
			NGUITools.SetActive(m_FullEffect.gameObject, true);
		}else
		{
			NGUITools.SetActive(m_FullEffect.gameObject, false);
		}
	}
}
