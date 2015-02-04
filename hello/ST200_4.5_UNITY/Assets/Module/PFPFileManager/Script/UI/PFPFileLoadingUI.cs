using UnityEngine;
using System.Collections;

public class PFPFileLoadingUI : MonoBehaviour {

	public UISprite m_GaugeBarSprite;
	public UILabel m_DownLoadLabel;
	public UILabel m_DescriptionLabel;

	public GameObject m_GaugeUI;
	public GameObject m_LoadingUI;

	void Awake()
	{
		NGUITools.SetActive(m_GaugeUI.gameObject, false);
		NGUITools.SetActive(m_LoadingUI.gameObject, false);
	}

	public void SetDownLoadPercent(float _curval)
	{
		int displaynumb = Mathf.Min(((int)(_curval * 100f)), 100);
		m_GaugeBarSprite.fillAmount = _curval;
		m_DownLoadLabel.text = displaynumb + "%";
	}

	protected string DescriptionString = "";
	protected string TotalCountString = "";
	public void SetDescriptionLabel(string _text)
	{
		DescriptionString = _text;
		m_DescriptionLabel.text = DescriptionString + "\n" + TotalCountString;
	}

	public void SetTotalCountLabel(int _cur, int _max)
	{
		TotalCountString = _cur.ToString() + "/" + _max.ToString();
		m_DescriptionLabel.text = DescriptionString + "\n" + TotalCountString;
	}

	protected bool showgaugeui = false;
	protected bool showloadingui = false;
	public void ShowGaugeUI()
	{
		showgaugeui = true;
		showloadingui = false;

		//NGUITools.SetActive(m_GaugeUI.gameObject, false);
		NGUITools.SetActive(m_LoadingUI.gameObject, false);
		Invoke("ShowUIDelay",0.5f);
	}

	public void ShowLoadingUI()
	{
		showgaugeui = false;
		showloadingui = true;

		NGUITools.SetActive(m_GaugeUI.gameObject, false);
		//NGUITools.SetActive(m_LoadingUI.gameObject, false);
		Invoke("ShowUIDelay",0.5f);
	}

	protected void ShowUIDelay()
	{
		NGUITools.SetActive(m_GaugeUI.gameObject, showgaugeui);
		NGUITools.SetActive(m_LoadingUI.gameObject, showloadingui);
	}
}
