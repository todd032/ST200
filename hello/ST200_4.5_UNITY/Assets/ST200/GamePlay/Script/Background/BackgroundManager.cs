using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour {

	public tk2dTiledSprite m_BackgroundSprite;
	public tk2dSprite m_RegionCircle;
	public Object ObstacleLineObject;

	public List<SkyMover> m_SkyMoverList = new List<SkyMover>();
	public List<GameObject> m_BackgroundObjectList = new List<GameObject>();

	void Awake()
	{
		int selectedindex = 1;
		if(Random.Range(0, 10f) < 9f)
		{
			selectedindex = 1;
		}else
		{
			selectedindex = 2;
		}
		InitBackground(selectedindex);
	}

	public void SetBackgroundColor(Color _color)
	{
		m_BackgroundSprite.color = _color;
	}

	public void SetBackgroundObject(int _type)
	{
		m_BackgroundObjectList[_type].gameObject.SetActive(true);
	}

	public void SetRandomBackgroundObject()
	{
		m_BackgroundObjectList[Random.Range(0, m_BackgroundObjectList.Count)].gameObject.SetActive(true);
	}

	public void InitBackground(int _type)
	{
		if(_type == 1)
		{
			m_BackgroundSprite.SetSprite("sea_patt");
			for(int i = 0; i < m_SkyMoverList.Count; i++)
			{
				m_SkyMoverList[i].gameObject.SetActive(false);
			}
		}else if(_type == 2)
		{
			m_BackgroundSprite.SetSprite("sea_patt_2");
			for(int i = 0; i < m_SkyMoverList.Count; i++)
			{
				m_SkyMoverList[i].gameObject.SetActive(false);
			}
		}
	}

	public void InitLineObstacle(float _radius)
	{
		int createnumb = 10;
		float deltaangle = 360f / (float)createnumb;
		for(int i = 0; i < createnumb; i++)
		{
			float curangle = deltaangle * i;
			GameObject go = Instantiate(ObstacleLineObject) as GameObject;
		
			Vector3 directionvec = new Vector3(Mathf.Sin(curangle * Mathf.Deg2Rad),
			                                   Mathf.Cos(curangle * Mathf.Deg2Rad),
			                                   0f);//Constant.ST200_GameObjectLayer_BackgroundObstacles);
			Vector3 pos = directionvec * _radius;
			pos.z = Constant.ST200_GameObjectLayer_BackgroundObstacles;
		
			go.transform.position = pos;
			go.transform.up = directionvec;
		}

		float imageradius = m_RegionCircle.GetCurrentSpriteDef().GetBounds().size.x / 2f;
		float multiplyfactor = _radius / imageradius;
		
		m_RegionCircle.scale = Vector3.one * multiplyfactor;
	}
}
