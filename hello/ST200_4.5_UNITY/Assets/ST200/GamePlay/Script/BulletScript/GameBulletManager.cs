using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBulletManager : MonoBehaviour {

	private static GameBulletManager instance ;
	public static GameBulletManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GameBulletManager)) as GameBulletManager;
			}
			return instance;
		}
	}
	
	void OnDestroy()
	{
		instance = null;
	}

	public List<GameBulletObject> m_ActiveGameBulletObjectList = new List<GameBulletObject>();
	public List<GameBulletObject> m_InActiveGameBulletObjectList = new List<GameBulletObject>();

	public List<GameBulletObject> m_GameBulletObjectList = new List<GameBulletObject>();


	public void Process(float _timer)
	{
		for(int i = 0; i < m_ActiveGameBulletObjectList.Count; i++)
		{
			GameBulletObject bullet = m_ActiveGameBulletObjectList[i];
			bullet.Process(_timer);
		}
	}

	public void ShootBullet(GamePlayBulletType _type, float _damage, Vector3 _worldpos, Vector3 _speed, float _pushforce, float _sizeratio)
	{
		Vector3 newworldpos = _worldpos;
		newworldpos.z = -1f;
		GameBulletObject selectedbulletobject = null;
		for(int i = 0; i < m_InActiveGameBulletObjectList.Count; i++)
		{
			if(m_InActiveGameBulletObjectList[i].m_Type == _type)
			{
				selectedbulletobject = m_InActiveGameBulletObjectList[i];
				m_InActiveGameBulletObjectList.Remove(selectedbulletobject);
				break;
			}
		}
		
		if(selectedbulletobject == null)
		{
			//if unalbe to find from pool create
			for(int i = 0; i < m_GameBulletObjectList.Count; i++)
			{
				if(m_GameBulletObjectList[i].m_Type == _type)
				{
					//Debug.Log("FOUND index: " + i);
					GameObject go = Instantiate(m_GameBulletObjectList[i].gameObject) as GameObject;
					GameBulletObject enemyobject = go.GetComponent<GameBulletObject>();
					selectedbulletobject = enemyobject;

					selectedbulletobject.BulletGoneEvent += BulletGoneEvent;
					//selectedenemyobject.DamageEvent += null;
					break;
				}
			}
		}

		//Debug.Log("SE: " + _type + " SELECTED: " + selectedbulletobject.m_Type);
		selectedbulletobject.gameObject.SetActive (true);
		selectedbulletobject.Init(_worldpos, _damage, _speed, _pushforce, _sizeratio);
		m_ActiveGameBulletObjectList.Add(selectedbulletobject);
		//Debug.Log("? WORKING?");
	}

	public void BulletGoneEvent(GameBulletObject _bullet)
	{
		_bullet.gameObject.SetActive(false);
		m_ActiveGameBulletObjectList.Remove(_bullet);
		m_InActiveGameBulletObjectList.Add(_bullet);
	}
}

public enum GamePlayBulletType
{
	PLAYER_BULLET 				= 1,
	ENEMY_BULLET 				= 2,
	PLAYER_MINE					= 3,
	PLAYER_ARROW 				= 4,
}