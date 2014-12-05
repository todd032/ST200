using UnityEngine;
using System.Collections;

public class PVPUI_Detail_PlayerUI : MonoBehaviour {

	public PVPUI_ShipDisplayer m_ShipDisplayer;
	public UISprite m_CharacterSprite;
	public UILabel m_CharacterLabel;
	public UISprite m_CharacterSpecialSprite;
	public UILabel m_PlayerNickNameLabel;
	public UILabel m_CountLabel;
	
	public void InitUI()
	{
		m_PlayerNickNameLabel.text = Managers.UserData.UserNickName;
		m_ShipDisplayer.Init();
		
		GameCharacterInfoMessageData characterdescription = Managers.GameBalanceData.GetGameCharacterInfoMessage(Managers.UserData.GetCurrentGameCharacter().IndexNumber);
		m_CharacterSprite.spriteName = ImageResourceManager.Instance.GetPVPCharacterImageName(Managers.UserData.GetCurrentGameCharacter().IndexNumber);
		m_CharacterSprite.MakePixelPerfect();
		
		m_CharacterLabel.text = TextManager.Instance.GetString(characterdescription.GameCharacterName2Index);
		m_CharacterSpecialSprite.spriteName = ImageResourceManager.Instance.GetMainUICharacterAbilityImageName(Managers.UserData.GetCurrentGameCharacter().IndexNumber);
	}
}
