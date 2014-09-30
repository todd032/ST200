using UnityEngine;
using System.Collections;

public class ColliderNotifier : MonoBehaviour {

	public delegate void ColliderDelegate(Collider2D _col);
	protected ColliderDelegate m_ColliderEnterDelegate;
	public event ColliderDelegate ColliderEnterEvent
	{
		add
		{
			m_ColliderEnterDelegate += value;
		}
		remove
		{
			m_ColliderEnterDelegate -= value;
		}
	}

	protected ColliderDelegate m_ColliderStayDelegate;
	public event ColliderDelegate ColliderStayEvent
	{
		add
		{
			m_ColliderStayDelegate += value;
		}
		remove
		{
			m_ColliderStayDelegate -= value;
		}
	}

	protected ColliderDelegate m_ColliderExitDelegate;
	public event ColliderDelegate ColliderExitEvent
	{
		add
		{
			m_ColliderExitDelegate += value;
		}
		remove
		{
			m_ColliderExitDelegate -= value;
		}
	}


	void OnTriggerEnter2D(Collider2D _col)
	{
		//Debug.Log("HI?");
		if(m_ColliderEnterDelegate != null)
		{
			m_ColliderEnterDelegate(_col);
		}
	}

	void OnTriggerStay2D(Collider2D _col)
	{
		if(m_ColliderStayDelegate != null)
		{
			m_ColliderStayDelegate(_col);
		}
	}

	void OnTriggerExit2D(Collider2D _col)
	{
		if(m_ColliderExitDelegate != null)
		{
			m_ColliderExitDelegate(_col);
		}
	}
}
