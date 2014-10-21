using UnityEngine;
using System.Collections;

public class PVPUI_Rank_RewardObject : MonoBehaviour {

	public UILabel m_WinLabel;

	public UISprite m_RewardSprite;
	public UILabel m_RewardLabel;


	public void InitUI(int _wincount, int _imageindex, int _rewardtype, int _rewardamount)
	{
		m_WinLabel.text = _wincount.ToString();
		m_RewardSprite.spriteName = ImageResourceManager.Instance.GetPVPRankRewardImage(_imageindex);
		m_RewardSprite.MakePixelPerfect();
		m_RewardLabel.text = _rewardtype.ToString () + " F: " + _rewardamount.ToString();
	}
}
