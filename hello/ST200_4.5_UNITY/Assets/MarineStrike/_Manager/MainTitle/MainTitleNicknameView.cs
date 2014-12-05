using UnityEngine;
using System.Collections;

public class MainTitleNicknameView : MonoBehaviour {

	[HideInInspector]
	public delegate void Delegate_NicknameView(int intState_Input);
	protected Delegate_NicknameView _delegate_NicknameView;
	public event Delegate_NicknameView Event_Delegate_NicknameView{
		add{
			_delegate_NicknameView = null ;
			if (_delegate_NicknameView == null) _delegate_NicknameView += value;
		}
		remove{
			_delegate_NicknameView -= value;
		}
	}

	public UILabel m_TitleLabel;
	public UILabel m_NicknameLabel;
	private string m_NickName;

	public UILabel m_InfoLabel;
	public UILabel m_OkLabel;
	public UIInput m_UIInput;
	public GameObject m_OKButton;
	// Use this for initialization
	void Start () {
		m_TitleLabel.text = Constant.COLOR_POPUP_NICKNAME_TITLE + TextManager.Instance.GetString (20);
		m_InfoLabel.text = Constant.COLOR_POPUP_NICKNAME_CONTENT + TextManager.Instance.GetString(21);
		m_OkLabel.text = Constant.COLOR_POPUP_BUTTON + TextManager.Instance.GetString(147);

		NGUITools.SetActive (m_OKButton.gameObject, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowView()
	{
		//m_NickName = m_NicknameLabel.text;
		NGUITools.SetActive(gameObject, true);
		//TouchScreenKeyboard.Open(m_NickName, TouchScreenKeyboardType.Default, false, false, true);
	}

	public void HideView()
	{
		NGUITools.SetActive(gameObject, false);
	}

	public void OnClickOk()
	{
		if(m_NickName == "")
		{
			m_NickName = m_NicknameLabel.text;
		}else
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
			Managers.DataStream.SetNickNameEvent += (int _type, int _result, string _errormsg) => 
			{
				if(_result == 0)
				{
					Managers.UserData.UserNickName = m_NickName;
					HideView();
					if(_delegate_NicknameView != null)
					{
						_delegate_NicknameView(Constant.ST200_POPUP_NICKNAME_SUCCESS);
					}
				}else if(_result == 1)
				{
					if(_delegate_NicknameView != null)
					{
						_delegate_NicknameView(Constant.ST200_POPUP_NICKNAME_ALREADY_EXIST);
					}
				}else if(_result < 0)
				{
					if(_delegate_NicknameView != null)
					{
						_delegate_NicknameView(Constant.ST200_POPUP_NICKNAME_INAPPROPRIATE_NAME);
					}
				}
			};

			Managers.DataStream.SetNickName(Managers.UserData.UserID, m_NickName);
		}
	}

	public void OnSubmitNickName()
	{
		//Debug.Log("??");
		//if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_Button_Common,false);
		if(m_NicknameLabel.text.Length > 1)
		{
			m_NickName = m_NicknameLabel.text.Substring(0,Mathf.Min(10, m_NicknameLabel.text.Length));
			m_UIInput.value = m_NickName;
		}else
		{
			m_UIInput.value = "";
			m_NickName = "";
		}
		if(m_NickName != "")
		{
			NGUITools.SetActive (m_OKButton.gameObject, true);
		}else
		{
			NGUITools.SetActive (m_OKButton.gameObject, false);
		}
	}
}
