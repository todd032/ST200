using UnityEngine;
using System.Collections;

public class PVPUI_Detail_OppUI : MonoBehaviour {

	public PVPUI_ShipDisplayerOpp m_ShipDisplayer;
	public UISprite m_CharacterSprite;
	public UILabel m_CharacterLabel;
	public UISprite m_CharacterSpecialSprite;
	public UILabel m_PlayerNickNameLabel;
	public UILabel m_CountLabel;

	public void InitUI(UserInfoData _userinfodata)
	{
		m_PlayerNickNameLabel.text = _userinfodata.UserNickName;
		m_ShipDisplayer.Init(_userinfodata);

		GameCharacterInfoMessageData characterdescription = Managers.GameBalanceData.GetGameCharacterInfoMessage(_userinfodata.CharacterIndex);
		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetPVPCharacterImageName(_userinfodata.CharacterIndex);
		m_CharacterSprite.MakePixelPerfect();
		m_CharacterLabel.text = characterdescription.GameCharacterNameKo;
		m_CharacterSpecialSprite.spriteName = ImageResourceManager.Instance.GetMainUICharacterAbilityImageName(_userinfodata.CharacterIndex);
	}
}
