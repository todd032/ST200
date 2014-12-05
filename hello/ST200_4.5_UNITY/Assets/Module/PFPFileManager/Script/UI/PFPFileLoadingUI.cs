using UnityEngine;
using System.Collections;

public class PFPFileLoadingUI : MonoBehaviour {

	public UISprite m_GaugeBarSprite;
	public UILabel m_DownLoadLabel;
	public UILabel m_DescriptionLabel;

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
}
