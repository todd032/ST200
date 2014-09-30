using UnityEngine;
using System.Collections;

public class EnglishCouponPopupView : MonoBehaviour {

	public void ShowPopupView()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public void HidePopupView()
	{
		NGUITools.SetActive(gameObject, false);
	}
}
