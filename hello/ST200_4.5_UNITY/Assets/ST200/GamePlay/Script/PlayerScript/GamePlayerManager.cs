using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerManager : MonoBehaviour {

	private static GamePlayerManager instance ;
	public static GamePlayerManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GamePlayerManager)) as GamePlayerManager;
			}
			return instance;
		}
	}
	
	void OnDestroy()
	{
		instance = null;
	}

	public List<Transform> SpawnTransformList = new List<Transform>(); 
	public List<PlayerShip> m_PlayerShipObjectList = new List<PlayerShip>();
	public List<PlayerSubShip> m_PlayerSubShipObjectList = new List<PlayerSubShip>();

	public PlayerShip m_CurrentPlayerShip;
	public CameraFollower m_GamePlayCamera;

	public List<PlayerSubShip> m_SubShipList = new List<PlayerSubShip>();

	public List<Transform> OppSpawnTransformList = new List<Transform>(); 
	public PlayerShip m_OppPlayerShip;
	public List<PlayerSubShip> m_OppSubShipList = new List<PlayerSubShip>();
	public void SpawnPlayer(UserShipData _info)
	{
		PlayerShip selectedObject = null;
		for(int i = 0; i < m_PlayerShipObjectList.Count; i++)
		{
			if((int)m_PlayerShipObjectList[i].m_ShipType == _info.IndexNumber)
			{
				selectedObject = m_PlayerShipObjectList[i];
				break;
			}
		}

		GameObject go = Instantiate(selectedObject.gameObject) as GameObject;
		m_CurrentPlayerShip = go.GetComponent<PlayerShip>();
		m_CurrentPlayerShip.Init(Managers.GameBalanceData.GetShipStatInfo(_info.IndexNumber, _info.Level), 1);
		Vector3 spawnpos = SpawnTransformList[0].transform.position;
		spawnpos.z = Constant.ST200_GameObjectLayer_PlayerShip;

		go.transform.position = spawnpos;	

		m_GamePlayCamera.m_TargetTransform = m_CurrentPlayerShip.transform;
	}

	public void OppSpawnPlayer(int _index, int _level)
	{
		PlayerShip selectedObject = null;
		for(int i = 0; i < m_PlayerShipObjectList.Count; i++)
		{
			if((int)m_PlayerShipObjectList[i].m_ShipType == _index)
			{
				selectedObject = m_PlayerShipObjectList[i];
				break;
			}
		}
		
		GameObject go = Instantiate(selectedObject.gameObject) as GameObject;
		m_OppPlayerShip = go.GetComponent<PlayerShip>();
		m_OppPlayerShip.Init(Managers.GameBalanceData.GetShipStatInfo(_index, _level), 2);
		Vector3 spawnpos = OppSpawnTransformList[0].transform.position;
		spawnpos.z = Constant.ST200_GameObjectLayer_PlayerShip;
		
		go.transform.position = spawnpos;
	}

	public void SpawnSubShip(UserSubShipData _info)
	{
		//Debug.Log("SPAWN SUBSHIP: " + _info.IndexNumber);
		PlayerSubShip selectedObject = null;
		for(int i = 0; i < m_PlayerSubShipObjectList.Count; i++)
		{
			if((int)m_PlayerSubShipObjectList[i].m_ShipType == _info.IndexNumber)
			{
				selectedObject = m_PlayerSubShipObjectList[i];
				break;
			}
		}

		GameObject go = Instantiate(selectedObject.gameObject) as GameObject;
		PlayerSubShip subship = go.GetComponent<PlayerSubShip>();
		subship.Init(Managers.GameBalanceData.GetSubShipStatInfo(_info.IndexNumber, _info.Level), _info.IsSelect, 1, m_CurrentPlayerShip);
		m_SubShipList.Add(subship);

		Vector3 spawnpos = subship.transform.position;
		spawnpos.z = Constant.ST200_GameObjectLayer_PlayerShip;
		
		go.transform.position = spawnpos;

		GameManager.Instance.PlayerSubShipSpawnEvent(subship);
	}

	public void OppSpawnSubShip(int _index, int _level, int _selectindex)
	{
		//Debug.Log("SPAWN SUBSHIP: " + _info.IndexNumber);
		PlayerSubShip selectedObject = null;
		for(int i = 0; i < m_PlayerSubShipObjectList.Count; i++)
		{
			if((int)m_PlayerSubShipObjectList[i].m_ShipType == _index)
			{
				selectedObject = m_PlayerSubShipObjectList[i];
				break;
			}
		}
		
		GameObject go = Instantiate(selectedObject.gameObject) as GameObject;
		PlayerSubShip subship = go.GetComponent<PlayerSubShip>();
		subship.Init(Managers.GameBalanceData.GetSubShipStatInfo(_index, _level), _selectindex, 2, m_OppPlayerShip);
		m_OppSubShipList.Add(subship);
		
		Vector3 spawnpos = subship.transform.position;
		spawnpos.z = Constant.ST200_GameObjectLayer_PlayerShip;
		
		go.transform.position = spawnpos;
		
		//GameManager.Instance.PlayerSubShipSpawnEvent(subship);
	}

	public void Process(float _timer)
	{
		m_CurrentPlayerShip.Process(_timer);
		for(int i = 0; i < m_SubShipList.Count; i++)
		{
			m_SubShipList[i].Process(_timer);
		}
	}

	public void ProcessOpp(float _timer)
	{
		m_OppPlayerShip.Process(_timer);
		for(int i = 0; i < m_OppSubShipList.Count; i++)
		{
			m_OppSubShipList[i].Process(_timer);
		}
	}

	public void ReviveAll()
	{
		GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX, m_CurrentPlayerShip.transform.position);
		m_CurrentPlayerShip.Revive();
		for(int i = 0; i < m_SubShipList.Count; i++)
	    {
			PlayerSubShip subship = m_SubShipList[i];
			subship.Revive();
			GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.HEAL_FX, subship.transform.position);
		}
	}

	public bool m_IsUsingTactic = false;
	public void ToggleTactic()
	{
		m_IsUsingTactic = !m_IsUsingTactic;
		for(int i = 0; i < m_SubShipList.Count; i++)
		{
			m_SubShipList[i].SetUseTactic(m_IsUsingTactic);
		}
	}

	public bool IsSubShipAlive()
	{
		for(int i = 0; i < m_SubShipList.Count; i++)
		{
			if(m_SubShipList[i].m_CurHealth > 0f)
			{
				return true;
			}
		}
		return false;
	}

	public int GetOpponentAlive()
	{
		int alivecount = 0;
		for(int i = 0; i < m_OppSubShipList.Count; i++)
		{
			if(m_OppSubShipList[i].m_CurHealth > 0f)
			{
				alivecount++;
			}
		}

		if(m_OppPlayerShip.m_CurHealth > 0f)
		{
			alivecount++;
		}

		return alivecount;
	}
	public int GetOpponentTotal()
	{
		int count = 1 + m_OppSubShipList.Count;
		
		return count;
	}
}

public enum GamePlayerShipType
{
	PANOKSEON 			= 1,
	PANOKSEON2			= 2,
	TURTLE_TYPE1 		= 3,
	TURTLE_TYPE2 		= 4,
	PANOKSEON3			= 5,
	PANOKSEON4			= 6,
	PANOKSEON5 			= 7,
	TURTLE_GOLD			= 8,
}

public enum GamePlayerSubShipType
{
	ATTACK_FRONT		= 1,
	ATTACK_SIDE			= 2,
	HEAL		 		= 3,
	FIRE_ARROW_2		= 4,

	BODY_CRASH			= 5,
	TWO_FORWARD			= 6,
	MINE				= 7,
	FIRE_ARROW_3		= 8,

	NINE				= 9,
	TEN					= 10,
	ELEVEN				= 11,
	TWELVE				= 12,
}

public enum GameShipBuffType
{
	ATTACK_DAMAGE_BUFF 			= 1,
	ATTACK_SPEED_BUFF  			= 2,
	INVINCIBLE 					= 3,
	HEAL						= 4,
	HEALTH_INCREASE				= 5,
}

public enum GameShipBuffRemainType
{
	INSTANCE					= 0,
	TIME						= 1,
	INFINITE					= 2,
}

public class GameShipBuff
{
	public GameShipBuffType BuffType;
	public GameShipBuffRemainType BuffRemainType;

	/// <summary>
	/// duration
	/// </summary>
	public float Value1;

	/// <summary>
	/// effect ratio
	/// </summary>
	public float Value2;
	public float Value3;
	public float Value4;
	public float Value5;

	protected float m_EffectTimer;
	public void Init(GameShipBuffType _bufftype, GameShipBuffRemainType _remaintype,
	                 float _val1,
	                 float _val2, 
	                 float _val3,
	                 float _val4,
	                 float _val5)
	{
		BuffType = _bufftype;
		BuffRemainType = _remaintype;
		Value1 = _val1;
		Value2 = _val2;
		Value3 = _val3;
		Value4 = _val4;
		Value5 = _val5;
		m_EffectTimer = 0f;
	}

	public void Process(float _timer)
	{
		if(BuffRemainType == GameShipBuffRemainType.TIME)
		{
			m_EffectTimer += _timer;
		}
	}

	public bool IsDone()
	{
		bool isdoneflag = false;
		if(BuffRemainType == GameShipBuffRemainType.TIME)
		{
			if(m_EffectTimer > Value1)
			{
				isdoneflag = true;
			}
		}else if(BuffRemainType == GameShipBuffRemainType.INFINITE)
		{
			isdoneflag = false;
		}
		return isdoneflag;
	}
}