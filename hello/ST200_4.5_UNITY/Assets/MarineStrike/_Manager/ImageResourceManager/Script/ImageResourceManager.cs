using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageResourceManager : MonoBehaviour {

	private static ImageResourceManager instance;
	public static ImageResourceManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(ImageResourceManager)) as ImageResourceManager;
			}
			return instance;
		}
	}

	private Dictionary<string, Texture> m_ImageDictionary = new Dictionary<string, Texture>();
	private Queue<string> m_StringUrlQueue = new Queue<string>();
	private Queue<Object> m_ObjectQueue = new Queue<Object>();

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}

		StartCoroutine(IEImageLoadProcess());
	}

	public void AddQueue(string _imageurl, Object _Renderer)
	{
		m_StringUrlQueue.Enqueue(_imageurl);
		m_ObjectQueue.Enqueue(_Renderer);
	}

	private void SetImage(string _imageurl, Object _renderer, Texture _texture)
	{
		if(_renderer != null)
		{
			if(_renderer is UITexture)
			{
				UITexture render = _renderer as UITexture;
				render.mainTexture = _texture;
			}else if(_renderer is Renderer)
			{
				Renderer render = _renderer as Renderer;
				render.material.mainTexture = _texture;
			}
		}
	}

	private IEnumerator IEImageLoadProcess()
	{
		while(true)
		{
			while(m_StringUrlQueue.Count == 0)
			{
				yield return null;
			}

			string curimageurl = m_StringUrlQueue.Dequeue();
			Object curobject = m_ObjectQueue.Dequeue();
			//check dictionary
			if(m_ImageDictionary.ContainsKey(curimageurl))
			{
				SetImage(curimageurl, curobject, m_ImageDictionary[curimageurl]); 
			}else
			{
				WWW www = new WWW(curimageurl);
				yield return www;
				
				Texture2D m_Tex2DProfile = www.texture;
				
				if (m_Tex2DProfile != null){
					m_ImageDictionary.Add(curimageurl, m_Tex2DProfile);
					SetImage(curimageurl, curobject, m_Tex2DProfile); 
				}
				
				www.Dispose();
			}

			yield return null;
		}

		yield break;
	}

	public string GetMainUIShipImageName(int _index)
	{
		return "playership_" + _index.ToString();
	}

	public string GetMainUISubShipImageName(int _index)
	{
		return "PlayerSubShip_" + _index.ToString();
	}

	public string GetMainUICharacterImageName(int _index)
	{
		return "Character_" + _index.ToString();
	}

	public string GetMainUICharacterAbilityImageName(int _index)
	{
		return "character_ability_mark_" + _index.ToString();
	}

	public string GetMainUIShopCoinImageName(int _index)
	{
		return "storeui_yopmoney_" + _index.ToString();
	}

	public string GetMainUIShopGoldImageName(int _index)
	{
		return "storeui_gold_" + _index.ToString();
	}

	public string GetCutInFX_GOImageName(int _character)
	{
		string name = "";
		name = "cutin_go_" + _character.ToString();
		return name;
	}

	public string GetCutInFX_SkillImageName(int _character)
	{
		string name = "";
		name = "cutin_skill_" + _character.ToString();
		return name;
	}

	public string GetCutInFX_EnemyIncomingImageName()
	{
		string name = "";
		name = "cutin_enemy";
		return name;
	}

	public string GetTacticFXImageName(int _index)
	{
		return "FX_Tactic_" + _index.ToString();
	}


	public string GetWorldRankingRankImage(int _rank)
	{
		string name = "rank_medal_" + _rank.ToString();
		return name;
	}

	public string GetPVPRankImage(int _rank)
	{
		string name = "pvp_rank_medal_" + _rank.ToString();
		return name;
	}

	public string GetWorldRankingCharacterImage(string _character)
	{
		string name = "rank_cha_" + _character; 
		return name;
	}

	public string GetFlagSpriteName(string _country)
	{
		string name = "flag_" + _country;
		if(_country == null || _country == "" || name == "flag_")
		{
			name = "flag_kr";
		}
		return name;
	}

	public string GetAttendDayImageName(int _itemcode)
	{
		string name = "";
		name = "Day_" + _itemcode.ToString();
		return name;
	}

	public string GetAttendPresentImageName(int _itemcode)
	{
		string name = "";
		name = "attend_reward_" + _itemcode.ToString();
		return name;
	}

	public string GetRandomLoadingTipSpriteName()
	{
		string name = "";
		name = "loading_tip_" + Random.Range(1, 5).ToString();
		return name;
	}

	public string GetTopBG(int _i)
	{
		if(_i == 0)
		{
			return "main_top_bottom_bg";
		}
		return "main_top_bottom_bg";
		//return "main_top_bar";
	}

	public string GetPVPCharacterImageName(int _index)
	{
		return "pvp_info_char" + _index;
	}

	public string GetPVPRankRewardImage(int _type)
	{
		string imagename = "pvp_rank_reward_" + _type.ToString();

		return imagename;
	}

	public string GetGamePlayMineSpriteName(int _teamindex)
	{
		string imagename = "bomb_red";
		if(_teamindex == 2)
		{
			imagename = "mine2";
		}
		return imagename;
	}
}
