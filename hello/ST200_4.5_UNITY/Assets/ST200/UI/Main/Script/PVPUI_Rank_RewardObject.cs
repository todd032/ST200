using UnityEngine;
using System.Collections;

public class PVPUI_Rank_RewardObject : MonoBehaviour {

	public UILabel m_WinLabel;

	public UISprite m_RewardSprite;
	public UILabel m_RewardLabel;


	public void InitUI(string _wintext, int _imageindex, string _rewardtext)
	{
		m_WinLabel.text = _wintext;
		m_RewardSprite.spriteName = ImageResourceManager.Instance.GetPVPRankRewardImage(_imageindex);
		m_RewardSprite.MakePixelPerfect();
		m_RewardLabel.text = _rewardtext;
	}
}
