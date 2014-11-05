using UnityEngine;
using System.Collections;

public class TorpedoManager : MonoBehaviour {
	
	private string _isRechargeAble ;
	public bool IsRechargeAble {
		set { 
			string encryptString = LoadingWindows.NextE(value.ToString(),Constant.DefalutAppName) ;
			_isRechargeAble = encryptString ;
		}
		get { 
			if(_isRechargeAble == null || _isRechargeAble.Equals("")){
				return false ;	
			}
			string decryptString = LoadingWindows.NextD(_isRechargeAble,Constant.DefalutAppName) ;
			
			bool decryptBool = false ;
			if(decryptString.Equals("True")){
				decryptBool = true ;
			}else if(decryptString.Equals("False")){
				decryptBool = false ;
			}
			return decryptBool;
		}
	}
	
	
	
	private void Awake(){
		
	}
	
	private void Start () {
	
	}
	
	private void Update () {
	
	}
	
	public void RechargeInitTorpedo(){
		
		bool isDone = false ;
		
		int syncRealServerTime = Managers.UserData.GetSyncServerTime() ;
		
		while(!isDone){
			
			if(Managers.UserData.TorpedoRechargeNextTime <= syncRealServerTime){
				
				
				if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
					
					Managers.UserData.TorpedoCount += 1 ;	
					
					if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
						Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.TorpedoRechargeNextTime + Managers.GameBalanceData.NextRechargeTorpedoBaseTime ;
					}else{
						Managers.UserData.TorpedoRechargeNextTime = syncRealServerTime ;
						IsRechargeAble = false ;
					}
					
				}else{
					Managers.UserData.TorpedoRechargeNextTime = syncRealServerTime ;
					isDone = true ;	
				}
				
			}else {
				isDone = true ;	
			}
			
		}
		
	}
	
	
	public void RechargeAllTorpedo(){
		
		if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
			IsRechargeAble = false ;
			
			Managers.UserData.TorpedoCount = Managers.GameBalanceData.TorpedoMaxValue ;
			Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() ;
			
		}else{
			IsRechargeAble = false ;
			Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() ;
		}
		
	}
	
	
	public void RechargeTorpedo(int rechargeCount) {
		
		Managers.UserData.TorpedoCount += rechargeCount ;
		
		if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
			IsRechargeAble = true ;
		}else{
			IsRechargeAble = false ;
			Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() ;
		}
		
	}

	public bool HaveTorpedo()
	{
		if(Managers.UserData.TorpedoCount <= 0) return false ;
		return true;
	}

	public bool ConsumeTorpedo() {
		
		if(Managers.UserData.TorpedoCount <= 0) return false ;
		
		
		Managers.UserData.TorpedoCount -= 1 ;	
		
		if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
			if(!IsRechargeAble){
				Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() + Managers.GameBalanceData.NextRechargeTorpedoBaseTime ;
			}
			IsRechargeAble = true ;
		}else{
			IsRechargeAble = false ;
			Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() ;
		}
		
		return true ;
		
	}
	
	public void StartCheckTorpedo(){
		
		RechargeInitTorpedo() ;
		
		StopCoroutine("CheckTorpedo") ;
		StartCoroutine("CheckTorpedo") ;
		
	}
	
	private IEnumerator CheckTorpedo(){
		
		if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
			IsRechargeAble = true ;
		}else{
			IsRechargeAble = false ;
		}
		
		
		yield return null ;
		
		while(true){
			
			if(IsRechargeAble){
				
				int syncRealServerTime = Managers.UserData.GetSyncServerTime() ;
				if(Managers.UserData.TorpedoRechargeNextTime <= syncRealServerTime){ //
					
					if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
						
						Managers.UserData.TorpedoCount += 1 ;	
						
						if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
							Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() + Managers.GameBalanceData.NextRechargeTorpedoBaseTime ;
						}else{
							Managers.UserData.TorpedoRechargeNextTime = syncRealServerTime ;
							IsRechargeAble = false ;
						}
						
						
						//Save User Data...
						//if(Managers.DataStream != null){
						//	if(Managers.UserData != null){
						//		Managers.DataStream.DataStreamManagerEvent += null ;
						//		UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
						//		///Connect
						//		StartCoroutine(Managers.DataStream.putUserData(userDataStruct,0)) ;
						//		///
						//	}
						//}
						
						
					}else {
						Managers.UserData.TorpedoRechargeNextTime = syncRealServerTime ;
						IsRechargeAble = false ;
					}
					
					
				}
				
			}
			
			yield return new WaitForSeconds(1f);
			
		}
		
	}

	private void OnApplicationPause(bool pause) {
		
		if (pause == false) {
			RechargeInitTorpedo() ;

			//lalal
			GCM.ClearAlarmNotification(Constant.FLAG_RECHARGE_PUSH);
		}else
		{

			//set notification
			if(Managers.UserData.PushFlag)
			{
				int ServerTime = Managers.UserData.GetSyncServerTime() ;
				int rechargetime = Managers.UserData.TorpedoRechargeNextTime + 
					Mathf.Max(0, Managers.GameBalanceData.NextRechargeTorpedoBaseTime * (Managers.GameBalanceData.TorpedoMaxValue - 1 - Managers.UserData.TorpedoCount));
				
				if(rechargetime > ServerTime)
				{
					int aftersecond = rechargetime - ServerTime;
					double delay = aftersecond * 1000f;
					//Debug.Log("set push noti: " + aftersecond);
					GCM.SetAlarmNotificationMessage(Constant.FLAG_RECHARGE_PUSH, 
					                                TextManager.Instance.GetString(286),
					                                TextManager.Instance.GetString(287),
					                                TextManager.Instance.GetString(288),
					                                delay);
				}
			}
		}
		
	}


	public void AddTorpedo(int _heart)
	{
		Managers.UserData.TorpedoCount = Mathf.Min(Managers.UserData.TorpedoCount + _heart, Managers.GameBalanceData.TorpedoMaxValue) ;
		
		if(Managers.UserData.TorpedoCount < Managers.GameBalanceData.TorpedoMaxValue){
			IsRechargeAble = true ;
		}else{
			IsRechargeAble = false ;
			Managers.UserData.TorpedoRechargeNextTime = Managers.UserData.GetSyncServerTime() ;
		}
	}

	public int GetTorpedoCount()
	{
		return Managers.UserData.TorpedoCount;
	}

	public int GetRegenInterval()
	{
		return Managers.GameBalanceData.NextRechargeTorpedoBaseTime;
	}
}
