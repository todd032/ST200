using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FeverEffect : MonoBehaviour {

	protected List<GameStageEnemyObject> m_EnemyList = new List<GameStageEnemyObject>();
	public Camera m_GamePlayCamera;
	public ParticleSystem m_ParticleSystem;
	public Collider2D m_Collider;

	public bool m_IsPlaying = false;
	public float m_FeverTime = 0f;
	public float FeverDurationTime = 5f;

	void Start()
	{
		Init(5f);
	}

	public void Init(float _durationtime)
	{
		FeverDurationTime = _durationtime;
		m_ParticleSystem.Stop();
		m_Collider.enabled = false;
		m_IsPlaying = false;
		m_FeverTime = 0f;
	}

	public void PlayFever(Vector3 _worldpos)
	{
		m_EnemyList.Clear();
		Vector3 newpos = _worldpos;
		newpos.z = Constant.ST200_GameObjectLayer_BackgroundFX;
		transform.position = newpos;

		m_IsPlaying = true;
		m_Collider.enabled = true;
		m_FeverTime = 0f;
		m_ParticleSystem.Play();
	}

	public void Process(float _timer)
	{
		if(m_IsPlaying)
		{
			m_FeverTime += _timer;
			if(m_FeverTime >= FeverDurationTime)
			{
				m_Collider.enabled = false;
				m_IsPlaying = false;
				m_ParticleSystem.Stop();
			}
			for(int i = 0; i < m_EnemyList.Count; i++)
			{
				m_EnemyList[i].OnSwirlStay(transform.position);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D _collider)
	{
		if(_collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			GameStageEnemyObject enemy = _collider.GetComponent<GameStageEnemyObject>();
			if(!m_EnemyList.Contains(enemy))
			{
				m_EnemyList.Add(enemy);
			}
		}
	}

	void OnTriggerExit2D(Collider2D _collider)
	{
		if(_collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			GameStageEnemyObject enemy = _collider.GetComponent<GameStageEnemyObject>();
			if(m_EnemyList.Contains(enemy))
			{
				m_EnemyList.Remove(enemy);
			}
		}
	}
}
