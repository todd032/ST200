using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStageManager : MonoBehaviour{

	private static GameStageManager instance ;
	public static GameStageManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GameStageManager)) as GameStageManager;
			}
			return instance;
		}
	}
	
	void OnDestroy()
	{
		instance = null;
	}

	public Camera m_GameCamera;
	public StageData m_StageData;

	public GameStageEnemyNotifierManager m_GameStageEnemyNotifier;

	public float m_Timer = 0f;

	public List<Transform> m_EnemyEndTransformList = new List<Transform>();

	public List<GameStageEnemyObject> m_ActiveEnemyList = new List<GameStageEnemyObject>();
	public List<GameStageEnemyObject> m_InActiveEnemyList = new List<GameStageEnemyObject>();

	public List<GameStageEnemyObject> m_EnemyObjectList = new List<GameStageEnemyObject>();

	public int CurStageNumb = 0;
	public int CurStageRemainTarget = 0;
	public int CurSpawnShipNumb = 0;

	public int CurTargetDestroyed = 0;
	public int TotalTarget = 0;
	public void InitStageData(StageData _stagedata)
	{
		m_StageData = _stagedata;

		for(int i = 0; i < _stagedata.WaveIndexList.Length; i++)
		{
			StageWaveData wavedata = Managers.GameBalanceData.GetStageWaveData(_stagedata.WaveIndexList[i]);
			TotalTarget += wavedata.EnemyIndexList.Length;
		}
	}

	/// <summary>
	/// resume the stage.
	/// used for lastboost or something
	/// </summary>
	public void ResumeStage(float _delay)
	{

	}

	public void PauseStage(bool _flag, int _value)
	{

	}

	public void ChangeGameSpeed(float _speed)
	{

	}

	public void Process(float _timer)
	{
		m_Timer += _timer;

		ProcessSpawnShip(_timer);
		ProcessWave(_timer);
		ProcessItemShipSpawn(_timer);

		for(int i = 0; i < m_ActiveEnemyList.Count; i++)
		{
			GameStageEnemyObject enemy = m_ActiveEnemyList[i];
			enemy.Process(_timer);
		}

		m_GameStageEnemyNotifier.UpdateTargetUI(m_ActiveEnemyList);
		m_GameStageEnemyNotifier.UpdateItemShipTargetUI(m_ActiveEnemyList);
	}

	float SpawnShipTimer = 0f;
	protected void ProcessSpawnShip(float _timer)
	{
		if(CurSpawnShipNumb < m_StageData.SpawnShipMinNumb)
		{
			SpawnEnemy(GetStageEnemyData(GetRandomSpawnShipIndex()), false);
			CurSpawnShipNumb++;
			//Debug.Log("spawn min ?");
		}else if(CurSpawnShipNumb < m_StageData.SpawnShipMaxNumb)
		{
			SpawnShipTimer += _timer;
			if(SpawnShipTimer > m_StageData.SpawnTimer)
			{
				SpawnShipTimer = 0f;
				SpawnEnemy(GetStageEnemyData(GetRandomSpawnShipIndex()), false);
				
				CurSpawnShipNumb++;
				//Debug.Log("spawn max ?");
			}
		}
	}

	float WaveTimer = 0f;
	protected void ProcessWave(float _timer)
	{
		if(CurStageRemainTarget == 0 && CurStageNumb < m_StageData.WaveIndexList.Length)
		{
			WaveTimer += _timer;
			if(WaveTimer > m_StageData.WaveRestTime)
			{
				WaveTimer = 0f;
				//spawn next wave
				CurStageNumb++;
				StageWaveData stagewavedata = Managers.GameBalanceData.GetStageWaveData(m_StageData.WaveIndexList[CurStageNumb - 1]);
				for(int i = 0 ; i < stagewavedata.EnemyIndexList.Length; i++)
				{
					SpawnEnemy(Managers.GameBalanceData.GetStageEnemyData(stagewavedata.EnemyIndexList[i]), true);
				}
				CurStageRemainTarget = stagewavedata.EnemyIndexList.Length;

				GameManager.Instance.GUIManager.PlayCutInFxAnimation_Incoming();
			}
		}
	}

	float ItemShipSpawnPeriodTimer = 0f;
	int ItemShipSpawnCount = 0;
	int CurItemShipCount = 0;
	protected void ProcessItemShipSpawn(float _timer)
	{
		ItemShipSpawnPeriodTimer += _timer;
		if(ItemShipSpawnPeriodTimer > 1f)
		{
			ItemShipSpawnPeriodTimer = 0f;
			if(m_StageData.m_ItemShipIndexList != null && m_StageData.m_ItemShipIndexList.Length != 0)
			{
				if(CurItemShipCount == 0 && ItemShipSpawnCount < m_StageData.ItemShipMaxSpawnNumb)
				{
					float spawnrandomval = Random.Range(0f, 100f);
					if(spawnrandomval < m_StageData.ItemShipSpawnRatio)
					{
						CurItemShipCount++;
						ItemShipSpawnCount++;
						CurSpawnShipNumb++;
						int selecteditemshipindex = m_StageData.m_ItemShipIndexList[0];
						float maxratio = 0f;
						for(int i = 0; i < m_StageData.m_ItemShipRatioList.Length; i++)
						{
							maxratio += m_StageData.m_ItemShipRatioList[i];
						}
						
						float randomval = Random.Range(0f, maxratio);
						float curval = 0f;
						for(int i = 0; i < m_StageData.m_ItemShipRatioList.Length; i++)
						{
							curval += m_StageData.m_ItemShipRatioList[i];
							if(curval > randomval)
							{
								selecteditemshipindex = m_StageData.m_ItemShipIndexList[i];
								break;
							}
						}

						SpawnEnemy(GetStageEnemyData(selecteditemshipindex), false);

						GameManager.Instance.GUIManager.PlayItemShipIncomingAnimation();
					}
				}
			}
		}
	}

	protected int GetRandomSpawnShipIndex()
	{
		float maxratio = 0f;
		for(int i = 0; i < m_StageData.SpawnShipRatioList.Length; i++)
		{
			maxratio += m_StageData.SpawnShipRatioList[i];
		}

		float randomval = Random.Range(0f, maxratio);
		float curval = 0f;
		for(int i = 0; i < m_StageData.SpawnShipRatioList.Length; i++)
		{
			curval += m_StageData.SpawnShipRatioList[i];
			if(curval > randomval)
			{
				return m_StageData.SpawnShipIndexList[i];
			}
		}
		return m_StageData.SpawnShipIndexList[0];
	}

	public bool StageIsDone()
	{
		if(CurStageNumb == m_StageData.WaveIndexList.Length && CurStageRemainTarget == 0)
		{
			return true;
		}
		return false;
	}

	public delegate void SpawnEnemyDelegate(StageEnemyData _stageenemydata);
	protected SpawnEnemyDelegate m_SpawnEnemyDelegate;
	public event SpawnEnemyDelegate SpawnEnemyEvent
	{
		add
		{
			m_SpawnEnemyDelegate += value;
		}remove
		{
			m_SpawnEnemyDelegate -= value;
		}
	}

	public void SpawnEnemy(StageEnemyData _stageenemydata, bool _marked)
	{
		//Debug.Log("SPAWN: " + _stageenemydata.EnemyType);
		//Debug.Log("Spawn");
		if(m_SpawnEnemyDelegate != null)
		{
			m_SpawnEnemyDelegate(_stageenemydata);
		}

		GameStageEnemyObject selectedenemyobject = null;
		for(int i = 0; i < m_InActiveEnemyList.Count; i++)
		{
			if(m_InActiveEnemyList[i].m_Type == _stageenemydata.EnemyType)			
			{
				selectedenemyobject = m_InActiveEnemyList[i];
				m_InActiveEnemyList.Remove(selectedenemyobject);
				break;
			}
		}

		if(selectedenemyobject == null)
		{
			//if unalbe to find from pool create
			for(int i = 0; i < m_EnemyObjectList.Count; i++)
			{
				if(m_EnemyObjectList[i].m_Type == _stageenemydata.EnemyType)
				{
					//Debug.Log("FOUND index: " + i);
					GameObject go = Instantiate(m_EnemyObjectList[i].gameObject) as GameObject;
					GameStageEnemyObject enemyobject = go.GetComponent<GameStageEnemyObject>();
					selectedenemyobject = enemyobject;

					selectedenemyobject.DamageEvent 		+= F_EnemyDamagedEvent;
					selectedenemyobject.DeadEvent 			+= F_EnemyDeadEvent;
					selectedenemyobject.DefendLinePassEvent += F_EnemyDefendLinePassEvent;
					selectedenemyobject.ShootEvent 			+= F_EnemyShootEvent;
					//selectedenemyobject.DamageEvent += null;
					break;
				}
			}
		}

		selectedenemyobject.gameObject.SetActive (true);

		//set random position  out of player's screen and inside of region
		Vector3 spawnpos = Vector3.zero;
		float screenheight = m_GameCamera.orthographicSize + 4f;

		bool found = false;
		while(!found)
		{
			Vector3 randompos = new Vector3(Random.Range(-1f,1f), Random.Range (0f,1f), 0f) * 20f;
			if(Vector3.Distance(GameManager.Instance.m_Player.transform.position, randompos) > screenheight)
			{
				found = true;
				spawnpos = randompos;
			}
		}

		selectedenemyobject.transform.position = spawnpos;
		selectedenemyobject.Init(GameManager.Instance.m_Player, _stageenemydata, _marked);
		selectedenemyobject.SetSubShipList(GamePlayerManager.Instance.m_SubShipList);

		m_ActiveEnemyList.Add(selectedenemyobject);
	}

	public StageEnemyData GetStageEnemyData(int _index)
	{
		//Debug.Log("GET ENEMY DAT AINDEX:" + _index);
		return Managers.GameBalanceData.GetStageEnemyData(_index);
	}

	protected GameStageEnemyObjectDelegate m_EnemyDeadEvent;
	public event GameStageEnemyObjectDelegate EnemyDeadEvent
	{
		add
		{
			m_EnemyDeadEvent += value;
		}
		remove
		{
			m_EnemyDeadEvent -= value;
		}
	}
	public void F_EnemyDeadEvent(GameStageEnemyObject _enemyobject)
	{
		//Debug.Log("?: " + _enemyobject.m_Marked);
		if(_enemyobject.m_Marked)
		{
			CurStageRemainTarget--;
			CurTargetDestroyed++;
		}else
		{
			CurSpawnShipNumb--;
			//Debug.Log("DECREASE:" + CurSpawnShipNumb);
		}

		if(_enemyobject.m_Type == 101)
		{
			CurItemShipCount--;
		}

		_enemyobject.gameObject.SetActive(false);
		m_ActiveEnemyList.Remove (_enemyobject);
		m_InActiveEnemyList.Add(_enemyobject);

		if(m_EnemyDeadEvent != null)
		{
			m_EnemyDeadEvent(_enemyobject);
		}
	}

	public delegate void GameStageEnemyObjectDelegate(GameStageEnemyObject _enemy);


	protected GameStageEnemyObjectDelegate m_DefendLinePassDelegate;
	public event GameStageEnemyObjectDelegate DefendLinePassEvent
	{
		add
		{
			m_DefendLinePassDelegate += value;
		}
		remove
		{
			m_DefendLinePassDelegate -= value;
		}
	}
	public void F_EnemyDefendLinePassEvent(GameStageEnemyObject _enemyobject)
	{
		if(m_DefendLinePassDelegate != null)
		{
			m_DefendLinePassDelegate(_enemyobject);
		}
	}

	public void F_EnemyDamagedEvent(GameStageEnemyObject _enemyobject, float _value)
	{

	}


	protected GameStageEnemyObjectDelegate m_EnemyShootDelegate;
	public event GameStageEnemyObjectDelegate EnemyShootEvent
	{
		add
		{
			m_EnemyShootDelegate += value;
		}
		remove
		{
			m_EnemyShootDelegate -= value;
		}
	}
	protected void F_EnemyShootEvent(GameStageEnemyObject _enemy)
	{
		if(m_EnemyShootDelegate != null)
		{
			m_EnemyShootDelegate(_enemy);
		}
	}
}

public class GameStageTimeTableInfo
{
	public float m_SpawnTime;
	public int EnemyIndex;
}