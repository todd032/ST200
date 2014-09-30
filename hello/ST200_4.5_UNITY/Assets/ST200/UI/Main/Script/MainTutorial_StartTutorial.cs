using UnityEngine;
using System.Collections;

public class MainTutorial_StartTutorial : MonoBehaviour {

	public Collider m_Collider;
	public UILabel m_Label;
	void Awake()
	{
		m_Collider.enabled = false;
		m_Label.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(215);
	}

	protected float timer = 0f;
	void Update()
	{
		timer += Time.deltaTime;
		if(timer > 2f)
		{
			m_Collider.enabled = true;
		}
	}
}
