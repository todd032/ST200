using UnityEngine;
using System.Collections;
using SimpleJSON ;
using System.Collections.Generic;

public class AttendPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void Delegate_AttendPopupView_NetworkResult(int intNetworkResult_Input);
	protected Delegate_AttendPopupView_NetworkResult _delegate_AttendPopupView_NetworkResult ;
	public event Delegate_AttendPopupView_NetworkResult Event_AttendPopupView_NetworkResult {
		
		add{
			_delegate_AttendPopupView_NetworkResult = null ;
			if (_delegate_AttendPopupView_NetworkResult == null) _delegate_AttendPopupView_NetworkResult += value;
		}
		
		remove{
			_delegate_AttendPopupView_NetworkResult -= value;
		}
	}

	string strSet_index;
	string strDay;
	string strIs_init;
	string [] array_Stritem_code;
	string [] array_Stritem_count;

	public UILabel m_TitleLabel;

	int intDay;

	public List<AttendPopupViewObject> AttendObjectList = new List<AttendPopupViewObject>();
	// Use this for initialization
	void Start () {
		m_TitleLabel.text = Constant.COLOR_ATTEND_TITLE + TextManager.Instance.GetString(42);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show_AttendPopupView(string strExtendJson_Input){

		//		Debug.Log("AttendPopupView.Show_AttendPopupView.strExtendJson_Input = " + strExtendJson_Input);

		NGUITools.SetActive(gameObject, true);

		JSONNode jsonExtend_Root = JSON.Parse(strExtendJson_Input);
		
		strSet_index = jsonExtend_Root ["attend"]["set_index"];
		strDay = jsonExtend_Root ["attend"]["day"];
		strIs_init = jsonExtend_Root ["attend"]["is_init"];

		intDay = int.Parse(strDay);
		
		// 테스트용.
//		intDay = 4;

		array_Stritem_code = new string[7];
		array_Stritem_count = new string[7];
		//Debug.Log("RESU: " + jsonExtend_Root.Value);
		for (int i = 0; i < 7; i++){

			array_Stritem_code[i] = jsonExtend_Root ["attend"]["items"][i]["item_code"];
			array_Stritem_count[i] = jsonExtend_Root ["attend"]["items"][i]["count"];

			int checkstate = 0;
			if(i > intDay)
			{

			}else if(i == intDay)
			{
				checkstate = 1;
			}else
			{
				checkstate = 2;
			}

			AttendObjectList[i].Init(i + 1, 
			                         int.Parse(array_Stritem_code[i]),
			                         int.Parse(array_Stritem_count[i]), 
			                         checkstate);
//			Debug.Log("AttendPopupView.Show_AttendPopupView.array_Stritem_code[" + i + "] = " + array_Stritem_code[i]);
//			Debug.Log("AttendPopupView.Show_AttendPopupView.array_Stritem_count[" + i + "] = " + array_Stritem_count[i]);
		}

	}

	public void Hide_AttendPopupView(){
		
		NGUITools.SetActive(gameObject, false);

	}

	public void OnClickButton_Close(){
		
		Hide_AttendPopupView ();

		_delegate_AttendPopupView_NetworkResult(Constant.NETWORK_RESULTCODE_OK);
	}
	
	public void OnClickButton_Confirm(){

		SetUserData_AttendReward();
		Managers.UserData.UpdateSequence++;
		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
		// 이벤트 정의 - SaveUserData 통신이 끝난 후 할 일.
		Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += (intResult_Code_Input, strResult_Extend_Input) => {
			
			if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_OK){

				_delegate_AttendPopupView_NetworkResult(Constant.NETWORK_RESULTCODE_OK);
			
			} else if (intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_Network){
				_delegate_AttendPopupView_NetworkResult(Constant.NETWORK_RESULTCODE_Error_Network);
			} else if(intResult_Code_Input == Constant.NETWORK_RESULTCODE_Error_UserSequence)
			{
				_delegate_AttendPopupView_NetworkResult(Constant.NETWORK_RESULTCODE_Error_UserSequence);
			} else {
				_delegate_AttendPopupView_NetworkResult(Constant.NETWORK_RESULTCODE_Error_UserData);
			}

			GameUIManager.Instance.LoadGameGoldAndGameJewelInfo();
			Hide_AttendPopupView ();

			if(!Managers.UserData.TutorialFlagV119)
			{
				GameUIManager.Instance.m_MainTutorial.StartTutorial();
			}
			Managers.DataStream.Event_Delegate_DataStreamManager_SaveUserData += null;
		};

		Managers.DataStream.Network_SaveUserData_Input_3(Managers.UserData.GetUserDataStruct(), 0, true);
		// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
		//Debug.Log("?");
	}

	private void SetUserData_AttendReward(){

		int intItemCode = int.Parse(array_Stritem_code[intDay]);
		int intItemCount = int.Parse(array_Stritem_count[intDay]);

//		Debug.Log("ST110k AttendPopupView.SetUserData_AttendReward().intItemCode = " + intItemCode);
//		Debug.Log("ST110k AttendPopupView.SetUserData_AttendReward().intItemCount = " + intItemCount);

		if (intItemCode == Constant.ST200_ITEM_HEART){

			Managers.Torpedo.AddTorpedo(intItemCount);

		} else if (intItemCode == Constant.ST200_ITEM_COIN){
			
			Managers.UserData.SetPurchaseGold(intItemCount);
			
		} else if (intItemCode == Constant.ST200_ITEM_JEWEL){
			
			Managers.UserData.SetGainJewel(intItemCount);
			
		} else if( intItemCode == Constant.ST200_ITEM_SHOUT 
		          || intItemCode == Constant.ST200_ITEM_SINGIJEON 
		          || intItemCode == Constant.ST200_ITEM_REVIVE)
		{
			Managers.UserData.SetPurchaseGameItem(intItemCode, intItemCount) ;
		}

		UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct();
		Managers.UserData.SetUserDataStruct(userDataStruct);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			OnClickButton_Confirm();
			return true;
		}
		
		return false;
	}
}
