using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class scrolltest : MonoBehaviour {

	public float m_ViewHeight;
	public float m_ItemHeight;
	public List<GameObject> m_ItemList = new List<GameObject>();

	public List<MonoBehaviour> HI = new List<MonoBehaviour>();
	protected float m_CurScrollpointer = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow))
		{
			m_CurScrollpointer += 1f * Time.deltaTime;
		}else if(Input.GetKey(KeyCode.DownArrow))
		{
			m_CurScrollpointer -= 1f * Time.deltaTime;
		}

		for(int i = 0; i < m_ItemList.Count; i++)
		{
			GameObject curgameobject = m_ItemList[i];

			Vector3 newpos = curgameobject.transform.localPosition;
			newpos.x = 0f;
			newpos.y = (m_CurScrollpointer + (float)i) * m_ItemHeight;
			//if(newpos.y > m_ViewHeight / 2f + m_ItemHeight / 2f)
			curgameobject.transform.localPosition = newpos;
		}
	}
}
