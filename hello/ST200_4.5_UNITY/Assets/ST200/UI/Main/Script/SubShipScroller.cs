using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubShipScroller : MonoBehaviour {

	public List<SubShipScrollObject> m_SubShipScrollObjectList = new List<SubShipScrollObject>();

	public float m_Width = 200f;
	/// <summary>
	/// 0 - first item should be localpos.x = 0f;
	/// </summary>
	public float m_DestScrollPointer;
	protected float m_CurScrollPointer;

	protected bool m_PressedBG = false;
	void Update()
	{
		UpdateScrollInput();
		UpdateScrollPointer();
	}

	protected Vector3 prevpos;
	protected void UpdateScrollInput()
	{
		if(m_PressedBG)
		{
			if(Input.GetMouseButton(0))
			{
#if UNITY_EDITOR
				m_DestScrollPointer += (-Input.mousePosition.x + prevpos.x) / 200f;
				m_DestScrollPointer = Mathf.Clamp(m_DestScrollPointer, 0f, m_SubShipScrollObjectList.Count - 1);
				prevpos = Input.mousePosition;
#else
				m_DestScrollPointer -= Input.GetTouch(0).deltaPosition.x / 100f;
				m_DestScrollPointer = Mathf.Clamp(m_DestScrollPointer, 0f, m_SubShipScrollObjectList.Count - 1);
#endif
			}
		}
	}

	public void ResetPosition()
	{
		m_DestScrollPointer = 0f;
	}

	public void AddScrollObject(SubShipScrollObject _scrollobject)
	{
		m_SubShipScrollObjectList.Add(_scrollobject);
		_scrollobject.transform.parent = transform;
		_scrollobject.transform.localScale = Vector3.one;
		_scrollobject.transform.localPosition = Vector3.zero;
		UpdateScrollPointer();
	}

	public void UpdateScrollPointer()
	{
		m_CurScrollPointer = m_CurScrollPointer + (m_DestScrollPointer - m_CurScrollPointer) * 0.1f;

		for(int i = 0; i < m_SubShipScrollObjectList.Count; i++)
		{
			m_SubShipScrollObjectList[i].transform.localPosition = new Vector3(m_Width * ((float)i - m_CurScrollPointer),
			                                                                   0f, 0f);
		}
	}

	public void SetScrollPointer(float _val)
	{
		m_DestScrollPointer = _val;
	}

	public void OnPressBG()
	{
		m_PressedBG = true;
		prevpos = Input.mousePosition;
	}

	public void OnReleaseBG()
	{
		m_PressedBG = false;

		m_DestScrollPointer = Mathf.RoundToInt( m_DestScrollPointer);
	}
}
