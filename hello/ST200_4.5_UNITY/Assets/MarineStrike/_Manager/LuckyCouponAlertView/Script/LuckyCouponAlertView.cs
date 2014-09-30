using UnityEngine;
using System.Collections;

public class LuckyCouponAlertView : MonoBehaviour {

	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
	[HideInInspector]
	public delegate void Delegate_LuckyCouponAlertView(int intResultCode_Input);
	protected Delegate_LuckyCouponAlertView delegate_LuckyCouponAlertView ;
	public event Delegate_LuckyCouponAlertView Event_Delegate_LuckyCouponAlertView {
		add{
			delegate_LuckyCouponAlertView = null ;
			if (delegate_LuckyCouponAlertView == null)
				delegate_LuckyCouponAlertView += value;
		}
		remove{
			delegate_LuckyCouponAlertView -= value;
		}
	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.


	public void ShowPopupView(){

		gameObject.SetActive(true)	;
	}

	public void HidePopupView(){

		gameObject.SetActive(false);
	}

	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= Start.
	public void OnClickOkButton(){

		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);

		HidePopupView();

		if (delegate_LuckyCouponAlertView != null){
			delegate_LuckyCouponAlertView(Constant.NETWORK_RESULTCODE_OK);
		}

	}
	// 영어학원 쿠폰 주기 기능 추가 (by 최원석 14.05.27) ========= End.
}
