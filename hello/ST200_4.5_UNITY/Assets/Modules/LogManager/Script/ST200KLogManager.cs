using UnityEngine;
using System.Collections;

public class  ST200KLogManager: MonoBehaviour {
	private static ST200KLogManager instance;
	public static ST200KLogManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(ST200KLogManager)) as ST200KLogManager;
			}
			
			return instance;
		}
	}

	void Start()
	{
		LoadFromLocal();
	}

	void Update()
	{
		//if(Input.GetKeyDown(KeyCode.Space))
		//{
		//	SaveToLocal();
		//}
	}

	void OnApplicationPause(bool _pause)
	{
		if(_pause)
		{
			SaveToLocal();
			LogManager.Instance.SendToServer();
		}
	}

	void OnApplicationQuit()
	{
		SaveToLocal();
	}

	public void Init(string loginid, string ver, string _ostype, string _service, string _mtype, string _codename) 
	{
		LogManager.Instance.SetInitDataStream(loginid,
		                                      ver,
		                                      _ostype,
		                                      _service,
		                                      _mtype,
		                                      _codename);
	}

	void SetLog(TAG _tag)
	{
		LogManager.Instance.SetLog(_tag.ToString ());
		LogManager.Instance.AddParam("TIME", Managers.UserData.GetSyncServerTime());
	}

	void AddParam(object _key, object _val)
	{
		LogManager.Instance.AddParam(_key, _val);
	}

	public void SaveToLocal()
	{
		LogManager.Instance.SaveToLocal();
	}

	public void LoadFromLocal()
	{
		LogManager.Instance.LoadLocal();
	}

	public void SendToServer()
	{
		//Debug.Log("LOG TRY SEND TO SERVER");
		LogManager.Instance.SendToServer();
	}

	public void SaveTutorialStartLog()
	{
		SetLog(TAG.TUTORIALSTART);
	}

	//public void SaveTutorial

	public void SaveLogin()
	{
		SetLog(TAG.LOGIN);
	}

	public void SaveEventBannerClick()
	{
		SetLog(TAG.EVENT_BANNER_CLICK);
	}

	public void SaveExperienceStart()
	{
		SetLog(TAG.EXPERIENCE_START);
	}

	public void SaveMissionClick()
	{
		SetLog(TAG.MISSION_CLICK);
	}

	public void SaveFriendInvite(bool _success, int _curinvitedfriendcount)
	{
		SetLog(TAG.FRIEND_INVITE);
		AddParam("Success", _success);
		AddParam("INVITED_FRIEND", _curinvitedfriendcount);
	}

	public void SaveGameStart()
	{
		SetLog(TAG.GAME_START);
	}

	public void SaveGameEnd(int _gamestage, 
	                        int _shipindex, int _shiplevel, 
	                        int _subshipindex1, int _subshiplevel1,
	                        int _subshipindex2, int _subshiplevel2,
	                        int _subshipindex3, int _subshiplevel3,
	                        int _subshipindex4, int _subshiplevel4,
	                        int _character,
	                        int _hitcount, int _enemykillcount, int _crashcount)
	{
		SetLog(TAG.GAME_END);
		AddParam("GAMESTAGE", _gamestage);
		AddParam("SHIPINDEX", _shipindex);
		AddParam("SHIPLEVEL", _shiplevel);

		AddParam("SUBSHIPINDEX1", _subshipindex1);
		AddParam("SUBSHIPLEVEL1", _subshiplevel1);
		AddParam("SUBSHIPINDEX2", _subshipindex2);
		AddParam("SUBSHIPLEVEL2", _subshiplevel2);
		AddParam("SUBSHIPINDEX3", _subshipindex3);
		AddParam("SUBSHIPLEVEL3", _subshiplevel3);
		AddParam("SUBSHIPINDEX4", _subshipindex4);
		AddParam("SUBSHIPLEVEL4", _subshiplevel4);

		AddParam("CHARACTER", _character);

		AddParam("HITCOUNT", _hitcount);
		AddParam("CRASHCOUNT", _crashcount);
		AddParam("ENEMYKILLCOUNT", _enemykillcount);
	}

	public void SaveGameItemUse(int _itemid)
	{
		SetLog(TAG.GAME_ITEM_USE);
		AddParam("ITEMID", _itemid);
	}

	public void SaveGameItemPurchaseMid(int _itemid, int _amount)
	{
		SaveShopSpendGold("GAME_ITEM_PURCHASE_MID", _amount);
		SetLog(TAG.GAME_ITEM_PURCHASE_MID);
		AddParam("ITEM_CODE", _itemid);
	}

	public void SaveGameBoast(string _sendto)
	{
		SetLog(TAG.GAME_BOAST);
		AddParam("RECEIVER_ID", _sendto);
	}

	public void SaveShopJewelBuy(int _jewelamount)
	{
		SetLog(TAG.SHOP_JEWEL_BUY);
		AddParam("JEWELAMOUNT", _jewelamount);
	}

	public void SaveShopSpendCrystal(string _type, int _spend)
	{
		SetLog(TAG.SHOP_SPEND_CRYSTAL);
		AddParam("TYPE", _type);
		AddParam("AMOUNT", _spend);
	}

	public void SaveShopSpendGold(string _type, int _amount)
	{
		SetLog(TAG.SHOP_SPEND_GOLD);
		AddParam("TYPE", _type);
		AddParam("AMOUNT", _amount);
	}

	public void SaveShopSubmarineClick()
	{
		SetLog(TAG.SHOP_SUBMARINE_CLICK);
	}

	public void SaveShopCharacterClick()
	{
		SetLog(TAG.SHOP_CHARACTER_CLICK);
	}

	public void SaveShopPetClick()
	{
		SetLog(TAG.SHOP_PET_CLICK);
	}

	public void SaveShopBulletUpgrade(int _submarineindex, int _level, int _amount)
	{
		SaveShopSpendGold("BULLET_UPGRADE", _amount);
		SetLog(TAG.SHOP_BULLET_UPGRADE);
		AddParam("SUBMARINE_INDEX", _submarineindex);
		AddParam("BULLET_LEVEL", _level);
	}

	public void SaveShopEnergyUpgrade(int _submarineindex, int _level, int _amount)
	{
		SaveShopSpendGold("ENERGY_UPGRADE", _amount);
		SetLog(TAG.SHOP_ENERGY_UPGRADE);
		AddParam("SUBMARINE_INDEX", _submarineindex);
		AddParam("ENERGY_LEVEL", _level);
	}

	public void SaveShopItemPurchase(int _itemcode, int _amount)
	{
		SaveShopSpendGold("ITEM_PURCHASE", _amount);
		SetLog(TAG.SHOP_ITEM_PURCHASE);
		AddParam("ITEM_CODE", _itemcode);
	}

	public void SaveShopSubmarinePurchase(int _submarineindex, int _type, int _amount)
	{
		if(_type == 1)
		{
			SaveShopSpendGold("SUBMARINE_PURCHASE", _amount);
		}else
		{
			SaveShopSpendCrystal("SUBMARINE_PURCHASE", _amount);
		}

		SetLog(TAG.SHOP_SUBMARINE_PURCHASE);
		AddParam("SUBMARINE_INDEX", _submarineindex);
	}

	public void SaveShopCharacterPurchase(int _characterindex, int _type, int _amount)
	{
		if(_type == 1)
		{
			SaveShopSpendGold("CHARACTER_PURCHASE", _amount);
		}else
		{
			SaveShopSpendCrystal("CHARACTER_PURCHASE", _amount);
		}
		SetLog(TAG.SHOP_CHARACTER_PURCHASE);
		AddParam("CHARACTER_INDEX", _characterindex);
	}

	public void SaveGacha(int _gachaindex, int _index, int _type, int _amount)
	{
		if(_type == 1)
		{
			SaveShopSpendGold("GACHA_PURCHASE", _amount);
		}else
		{
			SaveShopSpendCrystal("GACHA_PURCHASE", _amount);
		}
		SetLog(TAG.SHOP_GACHA_PURCHASE);
		AddParam("GACHA_INDEX", _gachaindex);
		AddParam("SHIP_INDEX", _index);
	}

	public void SaveShopPetPurchase(int _amount, int _petindex)
	{
		SaveShopSpendCrystal("PET_SUMMON", _amount);
		SetLog(TAG.SHOP_PET_PURCHASE);
		AddParam("PET_INDEX", _petindex);
	}

	#region CLASS ENUM STRUCTS	
	public enum TAG
	{
		LOGIN,
		TUTORIALSTART,
		EVENT_BANNER_CLICK,
		EXPERIENCE_START,
		MISSION_CLICK,
		FRIEND_INVITE,
		GAME_START,//WITH TOTAL START WITHIN ONE GAME
		GAME_END,
		GAME_ITEM_USE,
		GAME_ITEM_PURCHASE_MID,
		GAME_BOAST,
		SHOP_SUBMARINE_CLICK,
		SHOP_CHARACTER_CLICK,
		SHOP_PET_CLICK,
		SHOP_JEWEL_BUY,
		SHOP_SPEND_CRYSTAL,
		SHOP_SPEND_GOLD,
		SHOP_BULLET_UPGRADE,
		SHOP_ENERGY_UPGRADE,
		SHOP_ITEM_PURCHASE,
		SHOP_CHARACTER_PURCHASE,
		SHOP_SUBMARINE_PURCHASE,
		SHOP_GACHA_PURCHASE,
		SHOP_PET_PURCHASE,
	};
	#endregion
}
