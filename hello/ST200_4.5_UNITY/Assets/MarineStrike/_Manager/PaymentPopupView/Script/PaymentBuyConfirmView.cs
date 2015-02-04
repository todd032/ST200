using UnityEngine;
using System.Collections;

public class PaymentBuyConfirmView : MonoBehaviour {

	public UILabel m_DescriptionLabel;

	public PaymentPopupView m_PopUpView;

	protected PaymentGoldBuyButton m_PaymentGoldButton;
	protected PaymentJewelBuyButton m_PaymentJewelButton;
	protected PaymentTorpedoBuyButton m_PaymentTorpedoButton;
	protected int m_PaymentButtonIndex;

	public void LoadView(PaymentGoldBuyButton paymentGoldBuyButton, PaymentJewelBuyButton paymentJewelBuyButton, 
	                     PaymentTorpedoBuyButton paymentTorpedoBuyButton, int paymentBuyButtonIndexNumber, bool _show = true)
	{
		m_PaymentGoldButton = paymentGoldBuyButton;
		m_PaymentJewelButton = paymentJewelBuyButton;
		m_PaymentTorpedoButton = paymentTorpedoBuyButton;
		m_PaymentButtonIndex = paymentBuyButtonIndexNumber;

		if(paymentGoldBuyButton != null)
		{
			//show gold description;
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentGoldBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			string[] strings = new string[]{paymentBuyInfoBalance.ProductValue.ToString(), paymentBuyInfoBalance.PaymentItemValue.ToString()};
			m_DescriptionLabel.text = TextManager.Instance.GetReplaceString(175, strings);
		}

		if(paymentJewelBuyButton != null)
		{
			//show jewel description;
			//show gold description;
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentJewelBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			int productvalue = paymentBuyInfoBalance.ProductValue;
#if UNITY_ANDROID 
			//if(Constant.CURRENT_MARKET == "2" && Managers.UserData.FirstInAppPurchaseFlag == 0)
			//{
			//	productvalue = Mathf.CeilToInt(productvalue * 1.5f);
			//}
#endif
			string[] strings = new string[]{productvalue.ToString()};
			m_DescriptionLabel.text = TextManager.Instance.GetReplaceString(177, strings);
		}

		if(paymentTorpedoBuyButton != null)
		{
			//show torpedo
			//show gold description;
			GameBalanceDataManager.PaymentBuyInfoBalance paymentBuyInfoBalance = Managers.GameBalanceData.GetPaymentTorpedoBuyInfoBalance(paymentBuyButtonIndexNumber) ;
			int productvalue = paymentBuyInfoBalance.ProductValue;
			string[] strings = new string[]{productvalue.ToString(), paymentBuyInfoBalance.PaymentItemValue.ToString()};
			m_DescriptionLabel.text = TextManager.Instance.GetReplaceString(174, strings);
		}

		if(_show)
		{
			ShowView();
		}else
		{
			OnClickOkButton();
		}
	}

	public void OnClickOkButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(m_PaymentGoldButton != null)
		{
			m_PopUpView.PaymentPopupGoldInfoViewDelegate(m_PaymentGoldButton, m_PaymentButtonIndex);
		}

		if(m_PaymentJewelButton != null)
		{
			m_PopUpView.PaymentPopupJewelInfoViewDelegate(m_PaymentJewelButton, m_PaymentButtonIndex);
		}

		if(m_PaymentTorpedoButton != null)
		{
			m_PopUpView.PaymentPopupTorpedoInfoViewDelegate(m_PaymentTorpedoButton, m_PaymentButtonIndex);
		}

		RemoveView();
	}

	public void OnClickNoButton()
	{
		if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		RemoveView();
	}

	public void RemoveView()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void ShowView()
	{
		NGUITools.SetActive(gameObject, true);
	}

	public bool OnEscapePress()
	{
		if(gameObject.activeSelf)
		{
			RemoveView();
			return true;
		}
		
		return false;
	}
}
