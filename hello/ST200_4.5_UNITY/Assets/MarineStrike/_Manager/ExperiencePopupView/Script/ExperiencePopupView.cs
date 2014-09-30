using UnityEngine;
using System.Collections;

public class ExperiencePopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void Delegate_ExperiencePopupView_NetworkResult(int intNetworkResult_Input);
	protected Delegate_ExperiencePopupView_NetworkResult _delegate_ExperiencePopupView_NetworkResult ;
	public event Delegate_ExperiencePopupView_NetworkResult Event_ExperiencePopupView_NetworkResult {
		
		add{
			_delegate_ExperiencePopupView_NetworkResult = null ;
			if (_delegate_ExperiencePopupView_NetworkResult == null) _delegate_ExperiencePopupView_NetworkResult += value;
		}
		
		remove{
			_delegate_ExperiencePopupView_NetworkResult -= value;
		}
	}

	// Layout
	public UITexture _ExperienceTexture ;
	private Texture2D _tex2D;


	private string strExperienceIndex;


	private void Awake(){

	}

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	

	}


	public void Show_ExperiencePopupView(string strExperienceIndex_Input, string strExperienceURL_Input){

		NGUITools.SetActive(gameObject, true);

		strExperienceIndex = strExperienceIndex_Input;

		StartCoroutine(DownloadURLImage(strExperienceURL_Input)) ;

	}


	public void Hide_ExperiencePopupView(){

		NGUITools.SetActive(gameObject, false);
	}

	private IEnumerator DownloadURLImage(string strExperienceURL_Input){

		WWW www = new WWW(strExperienceURL_Input);
		yield return www;

		_tex2D = www.texture;
		
		_ExperienceTexture.mainTexture = _tex2D ;
		
		www.Dispose() ;
		www = null ;

	}

	public void OnClickButton_Close(){

		UserDataManager.UserDataStruct userDataStruct = Managers.UserData.GetUserDataStruct() ;
		userDataStruct.ExperienceIndex = 0;
		Managers.UserData.SetUserDataStruct(userDataStruct) ;

		PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_False);

		Hide_ExperiencePopupView ();

	}

	public void OnClickButton_Confirm(){

		// 이벤트 정의 - ReadUserDataExp 통신이 끝난 후 할 일.
		Managers.DataStream.Event_Delegate_DataStreamManager_ReadUserDataExp += (intNetworkResultCode_Input) => {

			Hide_ExperiencePopupView ();

			if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_OK){

				_delegate_ExperiencePopupView_NetworkResult(Constant.NETWORK_RESULTCODE_OK);
			
			} else if (intNetworkResultCode_Input == Constant.NETWORK_RESULTCODE_Error_Network){

				_delegate_ExperiencePopupView_NetworkResult(Constant.NETWORK_RESULTCODE_Error_Network);

			} else {

				_delegate_ExperiencePopupView_NetworkResult(Constant.NETWORK_RESULTCODE_Error_UserData);
			}
		};

		PlayerPrefs.SetInt(Constant.PREFKEY_ExperiencePopup_Mode_INT, Constant.INT_True);

		StartCoroutine(Managers.DataStream.Network_ReadUserDataExp(strExperienceIndex));

	}

}

