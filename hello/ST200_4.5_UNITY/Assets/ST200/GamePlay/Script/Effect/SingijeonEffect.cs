using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingijeonEffect : MonoBehaviour {

	public Camera m_GamePlayCamera;

	public bool IsPlaying = false;

	public List<ColliderNotifier> m_ColliderList = new List<ColliderNotifier>();
	public List<SingijeonBullet> m_Missiles = new List<SingijeonBullet>();
	public List<Transform> m_HitObjects = new List<Transform>();
	public float AttackDamage;

	// Use this for initialization
	void Start () {

	}

	public void Init(float _damage)
	{
		AttackDamage = _damage;

		foreach(ColliderNotifier notifier in GetComponentsInChildren<ColliderNotifier>())
		{
			m_ColliderList.Add(notifier);
		}
		
		foreach(SingijeonBullet bullet in GetComponentsInChildren<SingijeonBullet>())
		{
			m_Missiles.Add(bullet);
		}
		
		for(int i = 0; i < m_ColliderList.Count; i++)
		{
			m_ColliderList[i].ColliderEnterEvent += OnEnemyEnter;
		}

		foreach(SingijeonBullet bullet in m_Missiles)
		{
			bullet.gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetMouseButtonDown(0))
		//{
		//	for(int i = 0; i < m_Missiles.Count; i++)
		//	{
		//		m_Missiles[i].ResetObejct(0.15f * (float)(i + 1f));
		//	}
		//
		//	PlaySpecialAttack(0f);
		//}
	}
	
	public float GetDamage (Transform _object)
	{
		if(m_HitObjects.Contains(_object))
		{
			return 0f;
		}else
		{
			m_HitObjects.Add(_object);
		}
		
		return AttackDamage;
	}
	
	public void Play(float delaytime)
	{
		gameObject.SetActive(true);
		m_HitObjects.Clear();
		StopAllCoroutines();

		foreach(SingijeonBullet bullet in m_Missiles)
		{
			bullet.gameObject.SetActive(true);
		}

		List<Vector3> DestPositions = new List<Vector3>();
		List<Vector3> StartPositions = new List<Vector3>();
		for(int i = 0; i < m_Missiles.Count; i++)
		{
			Vector3 newpos = m_GamePlayCamera.transform.position;
			newpos.z = Constant.ST200_GameObjectLayer_FX;
			//newpos.x += Random.Range(-1f,1f) * m_GamePlayCamera.orthographicSize / 2f * m_GamePlayCamera.aspect;
			//newpos.y += Random.Range(-1f,1f) * m_GamePlayCamera.orthographicSize / 2f;

			float angle = 360f / (float)m_Missiles.Count * (float)i;
			float radius = m_GamePlayCamera.orthographicSize/2f;
			newpos.x += radius * Mathf.Sin(angle * Mathf.Deg2Rad);
			newpos.y += radius * Mathf.Cos(angle * Mathf.Deg2Rad);

			DestPositions.Add(newpos);

			Vector3 startpos = newpos;
			startpos.y = -m_GamePlayCamera.orthographicSize * 2f;
			StartPositions.Add(startpos);
		}

		for(int i = 0; i < m_Missiles.Count; i++)
		{
			m_Missiles[i].ShootBullet(0.15f * (float)(i + 1f), StartPositions[i], DestPositions[i]);
		}

		StopCoroutine("ProcessSpecialAttack");
		StartCoroutine(ProcessSpecialAttack(delaytime));
	}
	
	protected IEnumerator ProcessSpecialAttack (float delaytime)
	{
		IsPlaying = true;
		while(true)
		{
			for(int i = 0; i < m_Missiles.Count; i++)
			{
				m_Missiles[i].Process();
			}
			
			bool finished = true;
			for(int i = 0; i < m_Missiles.Count; i++)
			{
				if(m_Missiles[i].isPlaying)
				{
					finished = false;
					break;
				}
			}
			
			if(finished)
			{
				break;
			}
			yield return new WaitForFixedUpdate();
		}
		IsPlaying = false;
		foreach(SingijeonBullet bullet in m_Missiles)
		{
			bullet.gameObject.SetActive(false);
		}
		yield break;
	}

	protected void OnEnemyEnter(Collider2D _col)
	{
		//Debug.Log("DETECTED");
		if(_col != null && _col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			GameStageEnemyObject enemy = _col.gameObject.GetComponent<GameStageEnemyObject>();
			enemy.DoDamage(GetDamage(_col.transform));
			//Debug.Log("DETECTED2");
		}
	}
}
