using UnityEngine;
using System.Collections;

public class AttendPopupViewObject : MonoBehaviour {

	public UILabel m_DayLabel;
	public UILabel m_DayLabel2;
	public UISprite m_ItemSprite;
	public UILabel m_AmountLabel;
	public GameObject m_CheckSprite;
	public UITweener m_CheckAnimation;

	void Awake()
	{

	}

	/// <summary>
	/// [showstate]
	/// 0 - no check
	/// 1 - check play ani
	/// 2 - check don't play ani
	/// </summary>
	public void Init(int _day, int _itemcode, int _amount, int _showstate)
	{
		m_DayLabel.text = Constant.COLOR_ATTEND_DAYNUMBLABEL + _day.ToString();
		m_DayLabel2.text = Constant.COLOR_ATTEND_DAYLABEL + TextManager.Instance.GetString(27);
		m_ItemSprite.spriteName = ImageResourceManager.Instance.GetAttendPresentImageName(_itemcode);
		m_ItemSprite.MakePixelPerfect();
		m_AmountLabel.text = Constant.COLOR_ATTEND_ITEMNAMELABEL + _amount.ToString("#,#");
		if(_showstate == 0)
		{
			NGUITools.SetActive(m_CheckSprite.gameObject, false);
		}else if(_showstate == 1)
		{
			m_CheckAnimation.Play();
		}else
		{

		}
	}
}
