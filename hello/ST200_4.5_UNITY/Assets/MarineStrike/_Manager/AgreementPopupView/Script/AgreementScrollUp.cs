using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgreementScrollUp : MonoBehaviour {

	public float m_ObjectHeight = 100f;
	public List<AgreementScrollItem> m_ObjectList = new List<AgreementScrollItem>();

	// Use this for initialization
	void Start () {
		InitObjects();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInput();
	}

	protected void InitObjects()
	{
		float acummulatedy = 0f;
		for(int i = 0; i < m_ObjectList.Count; i++)
		{
			Vector3 newpos = m_ObjectList[i].transform.localPosition;
			newpos.y = -acummulatedy;
			m_ObjectList[i].transform.localPosition = newpos;

			acummulatedy += m_ObjectList[i].m_Label.height;
		}
	}

	protected bool m_Pressed = false;
	protected Vector3 m_PrevInput;
	protected void UpdateInput()
	{
		if(m_Pressed)
		{
			if(Input.GetMouseButtonUp(0))
			{
				m_Pressed = false;
			}else
			{
				float deltay = Input.mousePosition.y - m_PrevInput.y;
				ScrollPosition(deltay / Screen.height / 4f * 3f);

				m_PrevInput = Input.mousePosition;
			}
		}
	}

	public void OnPressField()
	{
		if(!m_Pressed)
		{
			m_Pressed = true;
			m_PrevInput = Input.mousePosition;
		}
	}

	protected float m_CurScrollPosition = 0;
	public void ScrollPosition(float _y)
	{
		bool cangoup = false;
		bool cangodown = false;
		for(int i = 0; i < m_ObjectList.Count; i++)
		{
			if(m_ObjectList[i].CanGoUp())
			{
				cangoup = true;
			}

			if(m_ObjectList[i].CanGoDown())
			{
				cangodown = true;
			}
		}

		if(_y > 0f && cangoup)
		{
			for(int i = 0; i < m_ObjectList.Count; i++)
			{
				Vector3 newpos = m_ObjectList[i].transform.localPosition;
				newpos.y += _y * m_ObjectHeight;
				m_ObjectList[i].transform.localPosition = newpos;
			}
		}

		if(_y < 0f && cangodown)
		{
			for(int i = 0; i < m_ObjectList.Count; i++)
			{
				Vector3 newpos = m_ObjectList[i].transform.localPosition;
				newpos.y += _y * m_ObjectHeight;
				m_ObjectList[i].transform.localPosition = newpos;
			}
		}

		for(int i = 0; i < m_ObjectList.Count; i++)
		{
			m_ObjectList[i].CheckShowUI();
		}
		//m_CurScrollPosition += _y;
		//m_CurScrollPosition = Mathf.Clamp(m_CurScrollPosition, 0f, m_ObjectList.Count);

		//for(int i = 0; i < m_ObjectList.Count; i++)
		//{
		//	Transform curtransform = m_ObjectList[i];
		//	Vector3 newpos = curtransform.localPosition;
		//	newpos.y = (m_CurScrollPosition - i)* m_ObjectHeight;
		//	curtransform.localPosition = newpos;
		//	if(newpos.y > m_ObjectHeight)
		//	{
		//		curtransform.gameObject.SetActive(false);
		//	}else if(newpos.y < -m_ObjectHeight * 3f)
		//	{
		//		curtransform.gameObject.SetActive(false);
		//	}else
		//	{
		//		curtransform.gameObject.SetActive(true);
		//	}
		//}


	}
}
