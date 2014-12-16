using UnityEngine;
using System.Collections;

public class AgreementScrollItem : MonoBehaviour {

	public UILabel m_Label;

	public bool CanGoUp()
	{
		if(transform.localPosition.y > m_Label.height)
		{
			return false;
		}
		return true;
	}

	public bool CanGoDown()
	{
		if(transform.localPosition.y < 0f)
		{
			return false;
		}
		return true;
	}

	public void CheckShowUI()
	{
		if(transform.localPosition.y > m_Label.height)
		{
			gameObject.SetActive (false);
		}else if(transform.localPosition.y < -m_Label.height)
		{
			gameObject.SetActive (false);
		}else
		{
			gameObject.SetActive(true);
		}
	}
}
