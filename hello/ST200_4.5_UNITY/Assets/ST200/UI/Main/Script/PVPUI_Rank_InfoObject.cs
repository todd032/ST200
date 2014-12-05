using UnityEngine;
using System.Collections;

public class PVPUI_Rank_InfoObject : MonoBehaviour {

	public UISprite m_BackgroundSprite;
	public UISprite m_CharacterSprite;
	public UISprite m_FlagSprite;

	public UISprite m_RankSprite;
	public UILabel m_RankLabel;
	public UILabel m_NickNameLabel;
	public UILabel m_ShipLabel;
	public UILabel m_RateLabel;

	public void InitUI(bool _ismine, int _rank, string _nickname, int _characterindex, int _shipindex, int _shiplevel, int _win, int _lose)
	{
		if(_ismine)
		{
			m_BackgroundSprite.spriteName = "pvp_rank_myranking_list_bg";
			Debug.Log("MY RANK: " + _rank);
		}else
		{
			m_BackgroundSprite.spriteName = "pvp_list_bg";
		}

		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage(_characterindex.ToString());
		//m_CharacterSprite.MakePixelPerfect();
		m_NickNameLabel.text = _nickname;

		if(_rank <= 3 && _rank > 0)
		{
			NGUITools.SetActive (m_RankSprite.gameObject, true);
			NGUITools.SetActive(m_RankLabel.gameObject, false);

			m_RankSprite.spriteName = ImageResourceManager.Instance.GetPVPRankImage(_rank);
			m_RankLabel.MakePixelPerfect();
		}else 
		{
			NGUITools.SetActive (m_RankSprite.gameObject, false);
			NGUITools.SetActive(m_RankLabel.gameObject, true);

			if(_rank < 1000)
			{
				m_RankLabel.text = _rank.ToString();
			}else
			{
				m_RankLabel.text = "999+";
			}
		}

		string winstring = "0";
		string losestring = "0";
		if(_win != 0)
		{
			winstring = _win.ToString("#,#");
		}

		if(_lose != 0)
		{
			losestring = _lose.ToString("#,#");
		}

		ShipDescriptionInfo shipdescription = Managers.GameBalanceData.GetShipDescriptionInfo(_shipindex);
		m_ShipLabel.text = "[f8c751]" +  TextManager.Instance.GetString(shipdescription.ShipNameTextIndex) + " LV. " + _shiplevel.ToString();
		m_RateLabel.text = winstring + TextManager.Instance.GetString(248) + 
			losestring + TextManager.Instance.GetString(249);
	}
}
