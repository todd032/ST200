using UnityEngine;
using System.Collections;

public class TextObject : MonoBehaviour {

	public UILabel m_Label;
	public int TextIndex;
	void OnEnable()
	{
		if(TextManager.Instance != null)
		{
			m_Label.text = TextManager.Instance.GetString(TextIndex);
		}
	}
}
