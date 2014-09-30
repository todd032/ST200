using UnityEngine;
using System.Collections;

public class ST200AdmobManager : MonoBehaviour {

	private static ST200AdmobManager instance;
	public static ST200AdmobManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(ST200AdmobManager)) as ST200AdmobManager;
			}
			
			if(instance == null)
			{
				GameObject newobject = new GameObject();
				newobject.name = "ST200AdmobManager";
				newobject.AddComponent<ST200AdmobManager>();
				instance = newobject.GetComponent<ST200AdmobManager>();
			}
			
			return instance;
		}
	}


	protected int ShowInertialCalled = 0;
	public void ShowInterstitial()
	{
		if(Managers.GameBalanceData.ShowAdmob == 1)
		{
			//Debug.Log("SHow inertial called");
			ShowInertialCalled++;
			if(ShowInertialCalled % Managers.GameBalanceData.ShowAdmobAmount == 0)
			{
				PFP_AdmobManager.Instance.ShowInterstitial();
			}
		}		
	}
}
