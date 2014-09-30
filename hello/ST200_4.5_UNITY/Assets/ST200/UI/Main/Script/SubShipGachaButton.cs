using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubShipGachaButton : MonoBehaviour {

	public SubShipSelectUI m_SubShipSelectUI;
	public UILabel m_PremiumCostLabel;
	public UILabel m_NormalCostLabel;

	// Use this for initialization
	void Start () {
		string normalcost = "0";
		if(Managers.GameBalanceData.GetSubShipGachaData(1).CostValue != 0)
		{
			normalcost = Managers.GameBalanceData.GetSubShipGachaData(1).CostValue.ToString("#,#");
		}
		m_NormalCostLabel.text = normalcost;

		string premiumcost = "0";
		if(Managers.GameBalanceData.GetSubShipGachaData(2).CostValue != 0)
		{
			premiumcost = Managers.GameBalanceData.GetSubShipGachaData(2).CostValue.ToString("#,#");
		}
		m_PremiumCostLabel.text = premiumcost;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickNormalGacha()
	{
		RunGacha(1);
	}

	public void OnClickPremiumGacha()
	{
		RunGacha(2);
	}

	protected void RunGacha(int _gacha)
	{
		int gachaselectedindex = GetGachaShipIndex(_gacha);
		//Debug.Log("RUN GACHA: " + gachaselectedindex);
		if(gachaselectedindex == 0)
		{
			GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_MESSAGE_SUBSHIP_UNABLETO_GACHA);
			return;
		}

		if(Managers.UserData != null && Managers.GameBalanceData != null){
			
			SubShipGachaData gachadata = Managers.GameBalanceData.GetSubShipGachaData(_gacha) ;
							
			int valueType = gachadata.CostType ;
			int characterValue = gachadata.CostValue ;
			
			/// Money Process..
			if(valueType == 1){
				
				int spendState = Managers.UserData.SetSpendGold(characterValue) ;
				
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					ST200KLogManager.Instance.SaveGacha(_gacha, gachaselectedindex, valueType, characterValue);					
					
					bool isupgrade = false;
					UserSubShipData subshipuserdata = Managers.UserData.GetUserSubShipData(gachaselectedindex);
					if(subshipuserdata.IsPurchase)
					{
						isupgrade = true;
						subshipuserdata.Level++;
						Managers.UserData.SetUserSubShipData(subshipuserdata);
					}else
					{
						subshipuserdata.IsPurchase = true;
						Managers.UserData.SetUserSubShipData(subshipuserdata);
						isupgrade = false;
					}
					m_SubShipSelectUI.m_GachaAnimation.PlayAnimation(gachaselectedindex, isupgrade);
					GameUIManager.Instance.m_MainUI.UpdateUI();

					if(Managers.DataStream != null){
						if(Managers.UserData != null){
							
							Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
							
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
						}
					}
					
					// ReLoad...Cash..
					GameUIManager.Instance.LoadGameGoldAndGameJewelInfo() ;
				}else{
					// Pop Up Payment Window...
					//Debug.Log("Pop Up Payment Window... Gold") ;
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_COIN) ;
				}
				
			}else if(valueType == 2){
				
				int spendState = Managers.UserData.SetSpendJewel(characterValue) ;
				
				if(spendState == 1) {
					
					if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Purchase,false);
					
					ST200KLogManager.Instance.SaveGacha(_gacha, gachaselectedindex, valueType, characterValue);
										
					bool isupgrade = false;
					UserSubShipData subshipuserdata = Managers.UserData.GetUserSubShipData(gachaselectedindex);
					if(subshipuserdata.IsPurchase)
					{
						isupgrade = true;
						subshipuserdata.Level++;
						Managers.UserData.SetUserSubShipData(subshipuserdata);
					}else
					{
						subshipuserdata.IsPurchase = true;
						Managers.UserData.SetUserSubShipData(subshipuserdata);
						isupgrade = false;
					}
					m_SubShipSelectUI.m_GachaAnimation.PlayAnimation(gachaselectedindex, isupgrade);
					GameUIManager.Instance.m_MainUI.UpdateUI();

					if(Managers.DataStream != null){
						if(Managers.UserData != null){
							
							Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null ;
							UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
							
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
							Managers.DataStream.Network_SaveUserData_Input_1(userDataStruct);
							// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
						}
					}
					// ReLoad...Cash..
					GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
				}else{
					// Pop Up Payment Window...	
					//Debug.Log("Pop Up Payment Window... Jewel") ;
					GameUIManager.Instance.LoadUIRootAlertView(Constant.ST200_POPUP_RECHARGE_JEWEL) ;
				}
				
			}
		}

	}

	protected bool CanRunGacha(int _gachaindex)
	{
		return GetGachaShipIndex(_gachaindex) != 0;
	}

	protected int GetGachaShipIndex(int _gachaindex)
	{
		int selectedindex = 0;

		SubShipGachaData shipgachadata = Managers.GameBalanceData.GetSubShipGachaData(_gachaindex);
		List<int> ShipMatchingGradeList = new List<int>();
		List<float> ShipMatchingRatioList = new List<float>();
		List<int> ShipMatchingIndexList = new List<int>();

		for(int i = 0; i < shipgachadata.GradeList.Length; i++)
		{
			int curgrade = shipgachadata.GradeList[i];
			float ratio = shipgachadata.GradeRatioList[i];
			for(int j = 0; j < Managers.GameBalanceData.m_SubShipDescriptionInfoList.Count; j++)
			{
				SubShipDescriptionInfo descriptioninfo = Managers.GameBalanceData.m_SubShipDescriptionInfoList[j];
				UserSubShipData curusershipdata = Managers.UserData.GetUserSubShipData(descriptioninfo.ShipIndex);
				//check grade
				if(descriptioninfo.Grade == curgrade)
				{
					//check level
					SubShipStatInfo nextleveldata = Managers.GameBalanceData.GetSubShipStatInfo(curusershipdata.IndexNumber,	
					                                                                            curusershipdata.Level + 1);
					if(nextleveldata.ShipIndex != 0)
					{
						if(!ShipMatchingGradeList.Contains(curgrade))
						{
							ShipMatchingGradeList.Add(curgrade);
							ShipMatchingRatioList.Add(ratio);
						}
						//if(!ShipMatchingIndexList.Contains(curusershipdata.IndexNumber))
						//{
						//	ShipMatchingIndexList.Add(curusershipdata.IndexNumber);
						//}
					}
				}
			}
		}

		int selectedgrade = 0;
		if(ShipMatchingGradeList.Count != 0)
		{
			float maxratio = 0f;
			for(int i = 0; i < ShipMatchingRatioList.Count; i++)
			{
				maxratio += ShipMatchingRatioList[i];
			}

			float curratio = 0f;
			float randomval = Random.Range(0f, maxratio);

			for(int i = 0; i < ShipMatchingRatioList.Count; i++)
			{
				curratio += ShipMatchingRatioList[i];
				if(randomval < curratio)
				{
					selectedgrade = ShipMatchingGradeList[i];
					break;
				}
			}
		}

		if(selectedgrade != 0)
		{
			for(int j = 0; j < Managers.GameBalanceData.m_SubShipDescriptionInfoList.Count; j++)
			{
				SubShipDescriptionInfo descriptioninfo = Managers.GameBalanceData.m_SubShipDescriptionInfoList[j];
				UserSubShipData curusershipdata = Managers.UserData.GetUserSubShipData(descriptioninfo.ShipIndex);
				//check grade
				if(descriptioninfo.Grade == selectedgrade)
				{
					//check level
					SubShipStatInfo nextleveldata = Managers.GameBalanceData.GetSubShipStatInfo(curusershipdata.IndexNumber,	
					                                                                            curusershipdata.Level + 1);
					if(nextleveldata.ShipIndex != 0)
					{
						if(!ShipMatchingIndexList.Contains(curusershipdata.IndexNumber))
						{
							ShipMatchingIndexList.Add(curusershipdata.IndexNumber);
						}
					}
				}
			}

			selectedindex = ShipMatchingIndexList[Random.Range(0, ShipMatchingIndexList.Count)];
		}

		return selectedindex;
	}
}
