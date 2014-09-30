using UnityEngine;
using System.Collections;

public class CutIn : MonoBehaviour {

	public tk2dSprite spCutInBgStar;
	public tk2dSprite spImage;
	public GameObject m_CutInTextBackground;
	public GameObject m_CutInText;
	public tk2dSprite m_CutInTextSprite;

	// Use this for initialization
	void Start () {
	
		//animation["BoosterAni"].speed = 2f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int m_BoosterType = 0;
	/// <summary>
	/// [type] 
	/// 0 - booster
	/// 1 - lastattack
	/// 2 - continue
	/// </summary>
	public void Play(int index, int _type)
	{
		animation.Play("BoosterAni");
		m_CutInTextBackground.animation.Play();
		m_CutInText.animation.Play();
		m_BoosterType = _type;

		//if(normalbooster)
		//{
		spImage.spriteId = spImage.GetSpriteIdByName("cutin_character" + (index).ToString() + "_booster");
		//}else
		//{
		//	spImage.spriteName = "CutIn" + (index).ToString() + "_LastAttack";
		//}
		spCutInBgStar.animation.Play("CutInBackgroundFXAnim");

		if(m_BoosterType == 0)
		{
			m_CutInTextSprite.SetSprite(m_CutInTextSprite.GetSpriteIdByName("cutin_booster_text"));
		}else if(m_BoosterType == 1)
		{
			m_CutInTextSprite.SetSprite(m_CutInTextSprite.GetSpriteIdByName("cutin_lastattack_text"));
		}else if(m_BoosterType == 2)
		{
			m_CutInTextSprite.SetSprite(m_CutInTextSprite.GetSpriteIdByName("cutin_continue_text"));
		}
	}

	// 말풑선 보이기.
	public void AnimBooster_TextBalloon_Show(){

	}
	
	// 말풑선 숨기기.
	public void AnimBooster_TextBalloon_Hide(){


	}

	// 말풑선 보이기.
	public void AnimLastAttack_TextBalloon_Show(){
		
		//NGUITools.SetActive (spCutInLastAttackText.gameObject, true);
		//spCutInLastAttackText.animation ["CutInText_LastAttack"].wrapMode = WrapMode.Once;
		//spCutInLastAttackText.gameObject.animation.Play ("CutInText_LastAttack");
	}
	
	// 말풑선 숨기기.
	public void AnimLastAttack_TextBalloon_Hide(){
		
		// 말풑선 숨기기.
		//NGUITools.SetActive (spCutInLastAttackText.gameObject, false);
	}

	// 배경 빛터짐 효과 보이기.
	public void AnimBooster_BgStar_Show(){

//		NGUITools.SetActive (spCutInBgStar.gameObject, true);
//		animation ["CutInBgStarAni"].wrapMode = WrapMode.Once;
//		spCutInTextBallon.gameObject.animation.Play ("CutInBgStarAni");
	}

	// 배경 빛터짐 효과 숨기기.
	public void AnimBooster_BgStar_Hide(){

//		NGUITools.SetActive (spCutInBgStar.gameObject, false);
	}





}
