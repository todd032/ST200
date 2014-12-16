using UnityEngine;
using System.Collections;

public class WorldRankUIObject : MonoBehaviour {

	public UILabel m_RankLabel;
	public UISprite m_RankSprite;
	public UISprite m_CharacterSprite;
	public UILabel m_NameLabel;
	public UILabel m_ScoreLabel;
	public UILabel m_StageNameLabel;
	public UISprite m_MyFrameSprite;
	public UISprite m_FlagSprite;

	public void Init(string _username, int _rank, int _userscore, int _stage, string _characterindex, bool _checkasmine, string _country)
	{
		NGUITools.SetActive(m_MyFrameSprite.gameObject, _checkasmine);

		if(_rank < 0)
		{
			NGUITools.SetActive(m_RankSprite.gameObject, false);
			NGUITools.SetActive(m_RankLabel.gameObject, true);
			m_RankLabel.text = Constant.COLOR_RANKING_RANKNUMB + "999+";
		}else if(_rank < 4)
		{
			NGUITools.SetActive(m_RankSprite.gameObject, true);
			NGUITools.SetActive(m_RankLabel.gameObject, false);
			
			m_RankSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingRankImage(_rank);
			m_RankSprite.MakePixelPerfect();
		}else
		{
			NGUITools.SetActive(m_RankSprite.gameObject, false);
			NGUITools.SetActive(m_RankLabel.gameObject, true);
			m_RankLabel.text = Constant.COLOR_RANKING_RANKNUMB + _rank.ToString();
		}
		m_NameLabel.text = Constant.COLOR_RANKING_INFOLABEL + _username;
		string scorestring = "0";
		if(_userscore != 0)
		{
			scorestring = _userscore.ToString("#,#");
		}

		m_ScoreLabel.text = Constant.COLOR_RANKING_INFOLABEL + scorestring;
		m_StageNameLabel.text = Constant.COLOR_RANKING_INFOLABEL + TextManager.Instance.GetReplaceString(309, Managers.GameBalanceData.GetStageData(_stage).Index.ToString());
		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetWorldRankingCharacterImage (_characterindex);
		m_CharacterSprite.MakePixelPerfect();
		m_FlagSprite.spriteName = ImageResourceManager.Instance.GetFlagSpriteName(_country);
	}
}
