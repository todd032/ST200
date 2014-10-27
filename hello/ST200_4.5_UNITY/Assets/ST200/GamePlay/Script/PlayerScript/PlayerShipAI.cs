using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShipAI : MonoBehaviour {

	protected int ATTACKSTATE = 0;
	protected int DEFENDSTATE = 0;
	protected int RUNSTATE = 0;
	protected int AVOIDSTATE = 0;
	protected int RETURNTOBATTLESTATE = 0;

	protected int m_CurState;

	protected PlayerShip m_PlayerShip;
	protected PlayerShip m_AIShip;
	// Use this for initialization
	void Start () {
	}

	public virtual void Init(PlayerShip _aiship,
	                         PlayerShip _playership)
	{
		m_AIShip = _aiship;
		m_PlayerShip = _playership;

		//ATTACKSTATE = Random.Range((int)PlayerShipAIState.ATTACK_EASY,(int)PlayerShipAIState.ATTACK_HARD + 1);
		//DEFENDSTATE = Random.Range((int)PlayerShipAIState.DEFEND_EASY, (int)PlayerShipAIState.DEFEND_HARD + 1);
		//RUNSTATE = Random.Range((int)PlayerShipAIState.RUN_EASY, (int)PlayerShipAIState.RUN_HARD + 1);
		//AVOIDSTATE = Random.Range((int)PlayerShipAIState.AVOID_EASY, (int)PlayerShipAIState.AVOID_HARD + 1);
		ATTACKSTATE = (int)PlayerShipAIState.ATTACK_HARD;
		DEFENDSTATE = (int)PlayerShipAIState.DEFEND_HARD;
		RUNSTATE = (int)PlayerShipAIState.RUN_HARD;
		AVOIDSTATE = (int)PlayerShipAIState.AVOID_HARD;

		RETURNTOBATTLESTATE = (int)PlayerShipAIState.RETURN_TO_BATTLE;
		ChangeState(ATTACKSTATE);
	}

	public virtual void Process(float _deltatime)
	{
		ProcessStateCheckEvent(_deltatime);
	}

	protected float m_StateCheckTimer = 0f;
	protected float m_StateCheckTime = 1f;
	protected void ProcessStateCheckEvent(float _deltatime)
	{
		m_StateCheckTimer += _deltatime;
		if(m_StateCheckTimer > m_StateCheckTime)
		{
			m_StateCheckTimer = 0f;
			CheckState();
		}
	}

	public void ChangeState(int _state)
	{
		StopAllCoroutines();
		m_CurState = _state;
		StartCoroutine(((PlayerShipAIState)m_CurState).ToString());
	}

	protected virtual void CheckState()
	{
		int newstate = m_CurState;
		if(Vector3.Distance(m_AIShip.transform.position, Vector3.zero) > Managers.GameBalanceData.GamePlayReturnToBattleMaxDistance)
		{
			newstate = RETURNTOBATTLESTATE;
		}else if(GamePathManager2.Instance.CollideWithLine(m_AIShip.transform.position, m_PlayerShip.transform.position))
		{
			newstate = DEFENDSTATE;
		}else if(m_PlayerShip.m_CurHealth < m_AIShip.m_CurHealth * 0.8f)
		{
			newstate = ATTACKSTATE;
		}else if(m_AIShip.m_CurHealth < m_AIShip.MaxHealth * 0.5f && m_PlayerShip.m_CurHealth > m_AIShip.m_CurHealth * 1.5f)
		{
			if(Random.Range(0f, 100f) < 20f)
			{
				newstate = RUNSTATE;
			}else
			{
				newstate = DEFENDSTATE;
			}
		}else
		{
			if(m_PlayerShip.IsInAttackAngle(m_AIShip.transform.position))
			{
				if(Random.Range(0f, 100f) < 20f)
				{
					newstate = RUNSTATE;
				}else
				{
					newstate = DEFENDSTATE;
				}
			}else
			{
				newstate = ATTACKSTATE;
			}
		}

		ChangeState(newstate);
	}

	protected virtual IEnumerator ATTACK_EASY()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			float distance = Vector2.Distance(m_AIShip.transform.position, m_PlayerShip.transform.position);
			if(distance > m_AIShip.m_ShipStatInfo.BulletSpeed)
			{
				Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
				Vector3 curdir = m_AIShip.m_LookingVector;

				float angle = Vector2.Angle(curdir, deltadirection);
				if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
				{
					m_AIShip.SetRotationInput(-1f);
				}else if(angle > 5f)
				{
					m_AIShip.SetRotationInput(1f);
				}else
				{
					m_AIShip.SetRotationInput(0f);
				}
			}else
			{
				Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
				deltadirection.z = 0f;
				
				int selectedattackdirectionindex = 0;
				float leastangle = 180f;
				
				for(int i = 0; i < attackdirection.Count; i++)
				{
					Vector3 curattackdirection = attackdirection[i];
					curattackdirection = m_AIShip.transform.localToWorldMatrix.MultiplyVector(curattackdirection);
					float curangle = Vector2.Angle(curattackdirection, deltadirection);
					if(curangle < leastangle)
					{
						leastangle = curangle;
						selectedattackdirectionindex = i;
					}
				}
				
				//decide where to rotate
				//Debug.Log ("??? selectedattackdirectionindex: " + selectedattackdirectionindex + " ANGLE: " +leastangle);
				Vector3 selectedattackdir = attackdirection[selectedattackdirectionindex];
				selectedattackdir = m_AIShip.transform.localToWorldMatrix.MultiplyVector(selectedattackdir);
				if(leastangle > 5f && Vector3.Cross(selectedattackdir, deltadirection).z < 0f)
				{
					m_AIShip.SetRotationInput(-1f);
				}else if(leastangle > 5f)
				{
					m_AIShip.SetRotationInput(1f);
				}else
				{
					m_AIShip.SetRotationInput(0f);
				}
			}

			//just move forward
			m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);

			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
	protected virtual IEnumerator ATTACK_MID()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			float distance = Vector2.Distance(m_AIShip.transform.position, m_PlayerShip.transform.position);
			if(distance > m_AIShip.m_ShipStatInfo.BulletSpeed * 0.9f)
			{
				Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
				Vector3 curdir = m_AIShip.m_LookingVector;
				
				float angle = Vector2.Angle(curdir, deltadirection);
				if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
				{
					m_AIShip.SetRotationInput(-1f);
				}else if(angle > 5f)
				{
					m_AIShip.SetRotationInput(1f);
				}else
				{
					m_AIShip.SetRotationInput(0f);
				}
				
				//just move forward
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			}else
			{
				Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
				deltadirection.z = 0f;
				
				int selectedattackdirectionindex = 0;
				float leastangle = 180f;
				
				for(int i = 0; i < attackdirection.Count; i++)
				{
					Vector3 curattackdirection = attackdirection[i];
					curattackdirection = m_AIShip.transform.localToWorldMatrix.MultiplyVector(curattackdirection);
					float curangle = Vector2.Angle(curattackdirection, deltadirection);
					if(curangle < leastangle)
					{
						leastangle = curangle;
						selectedattackdirectionindex = i;
					}
				}
				
				//decide where to rotate
				//Debug.Log ("??? selectedattackdirectionindex: " + selectedattackdirectionindex + " ANGLE: " +leastangle);
				Vector3 selectedattackdir = attackdirection[selectedattackdirectionindex];
				selectedattackdir = m_AIShip.transform.localToWorldMatrix.MultiplyVector(selectedattackdir);
				if(leastangle > 5f && Vector3.Cross(selectedattackdir, deltadirection).z < 0f)
				{
					m_AIShip.SetRotationInput(-1f);
				}else if(leastangle > 5f)
				{
					m_AIShip.SetRotationInput(1f);
				}else
				{
					m_AIShip.SetRotationInput(0f);
				}
				
				//just move forward
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			}
			
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
	protected virtual IEnumerator ATTACK_HARD()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			float distance = Vector2.Distance(m_AIShip.transform.position, m_PlayerShip.transform.position);
			if(distance > m_AIShip.m_ShipStatInfo.BulletSpeed * 1.1f)
			{
				Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
				Vector3 curdir = m_AIShip.m_LookingVector;
				
				float angle = Vector2.Angle(curdir, deltadirection);
				if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
				{
					m_AIShip.SetRotationInput(-1f);
				}else if(angle > 5f)
				{
					m_AIShip.SetRotationInput(1f);
				}else
				{
					m_AIShip.SetRotationInput(0f);
				}
				//just move forward
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			}else
			{
				Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
				deltadirection.z = 0f;
				
				int selectedattackdirectionindex = 0;
				float leastangle = 180f;
				
				for(int i = 0; i < attackdirection.Count; i++)
				{
					Vector3 curattackdirection = attackdirection[i];
					curattackdirection = m_AIShip.transform.localToWorldMatrix.MultiplyVector(curattackdirection);
					float curangle = Vector2.Angle(curattackdirection, deltadirection);
					if(curangle < leastangle)
					{
						leastangle = curangle;
						selectedattackdirectionindex = i;
					}
				}
				
				//decide where to rotate
				//Debug.Log ("??? selectedattackdirectionindex: " + selectedattackdirectionindex + " ANGLE: " +leastangle);
				Vector3 selectedattackdir = attackdirection[selectedattackdirectionindex];
				selectedattackdir = m_AIShip.transform.localToWorldMatrix.MultiplyVector(selectedattackdir);
				if(leastangle > 5f && Vector3.Cross(selectedattackdir, deltadirection).z < 0f)
				{
					m_AIShip.SetRotationInput(-1f);
				}else if(leastangle > 5f)
				{
					m_AIShip.SetRotationInput(1f);
				}else
				{
					m_AIShip.SetRotationInput(0f);
				}
			}
						
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}

	protected virtual IEnumerator DEFEND_EASY()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
			deltadirection.z = 0f;

			int selectedattackdirectionindex = 0;
			float leastangle = 180f;

			for(int i = 0; i < attackdirection.Count; i++)
			{
				Vector3 curattackdirection = attackdirection[i];
				curattackdirection = m_AIShip.transform.localToWorldMatrix.MultiplyVector(curattackdirection);
				float curangle = Vector2.Angle(curattackdirection, deltadirection);
				if(curangle < leastangle)
				{
					leastangle = curangle;
					selectedattackdirectionindex = i;
				}
			}

			//decide where to rotate
			//Debug.Log ("??? selectedattackdirectionindex: " + selectedattackdirectionindex + " ANGLE: " +leastangle);
			Vector3 selectedattackdir = attackdirection[selectedattackdirectionindex];
			selectedattackdir = m_AIShip.transform.localToWorldMatrix.MultiplyVector(selectedattackdir);
			if(leastangle > 5f && Vector3.Cross(selectedattackdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(leastangle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}

			yield return new WaitForFixedUpdate();
		}

		yield break;
	}
	protected virtual IEnumerator DEFEND_MID()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
			deltadirection.z = 0f;
			
			int selectedattackdirectionindex = 0;
			float leastangle = 180f;
			
			for(int i = 0; i < attackdirection.Count; i++)
			{
				Vector3 curattackdirection = attackdirection[i];
				curattackdirection = m_AIShip.transform.localToWorldMatrix.MultiplyVector(curattackdirection);
				float curangle = Vector2.Angle(curattackdirection, deltadirection);
				if(curangle < leastangle)
				{
					leastangle = curangle;
					selectedattackdirectionindex = i;
				}
			}
			
			//decide where to rotate
			//Debug.Log ("??? selectedattackdirectionindex: " + selectedattackdirectionindex + " ANGLE: " +leastangle);
			Vector3 selectedattackdir = attackdirection[selectedattackdirectionindex];
			selectedattackdir = m_AIShip.transform.localToWorldMatrix.MultiplyVector(selectedattackdir);
			if(leastangle > 5f && Vector3.Cross(selectedattackdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(leastangle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}

			if(m_PlayerShip.IsInAttackAngle(m_AIShip.transform.position))
			{
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			}
			
			yield return new WaitForFixedUpdate();
		}
		
		yield break;
	}
	protected virtual IEnumerator DEFEND_HARD()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = m_PlayerShip.transform.position - m_AIShip.transform.position;
			deltadirection.z = 0f;
			
			int selectedattackdirectionindex = 0;
			float leastangle = 180f;
			
			for(int i = 0; i < attackdirection.Count; i++)
			{
				Vector3 curattackdirection = attackdirection[i];
				curattackdirection = m_AIShip.transform.localToWorldMatrix.MultiplyVector(curattackdirection);
				float curangle = Vector2.Angle(curattackdirection, deltadirection);
				if(curangle < leastangle)
				{
					leastangle = curangle;
					selectedattackdirectionindex = i;
				}
			}
			
			//decide where to rotate
			//Debug.Log ("??? selectedattackdirectionindex: " + selectedattackdirectionindex + " ANGLE: " +leastangle);
			Vector3 selectedattackdir = attackdirection[selectedattackdirectionindex];
			selectedattackdir = m_AIShip.transform.localToWorldMatrix.MultiplyVector(selectedattackdir);
			if(leastangle > 5f && Vector3.Cross(selectedattackdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(leastangle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}

			if(m_PlayerShip.IsInAttackAngle(m_AIShip.transform.position))
			{
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			}

			yield return new WaitForFixedUpdate();
		}
		
		yield break;
	}

	protected virtual IEnumerator RUN_EASY()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = -(m_PlayerShip.transform.position - m_AIShip.transform.position);
			Vector3 curdir = m_AIShip.m_LookingVector;
			
			float angle = Vector2.Angle(curdir, deltadirection);
			if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(angle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}

			m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
	protected virtual IEnumerator RUN_MID()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = -(m_PlayerShip.transform.position - m_AIShip.transform.position);
			Vector3 curdir = m_AIShip.m_LookingVector;
			
			float angle = Vector2.Angle(curdir, deltadirection);
			if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(angle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}
			
			m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
	protected virtual IEnumerator RUN_HARD()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = -(m_PlayerShip.transform.position - m_AIShip.transform.position);
			Vector3 curdir = m_AIShip.m_LookingVector;
			
			float angle = Vector2.Angle(curdir, deltadirection);
			if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(angle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}
			
			m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}

	protected virtual IEnumerator AVOID_EASY()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 0);
			m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 0);

			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
	protected virtual IEnumerator AVOID_MID()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			if(m_PlayerShip.IsInAttackAngle(m_AIShip.transform.position))
			{
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			}
			
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
	protected virtual IEnumerator AVOID_HARD()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			if(m_PlayerShip.IsInAttackAngle(m_AIShip.transform.position))
			{
				m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
				m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			}
			yield return new WaitForFixedUpdate();
		}
		yield break;
	}

	protected virtual IEnumerator RETURN_TO_BATTLE()
	{
		List<Vector3> attackdirection = m_AIShip.GetAttackDirectionList();
		//check angle and find closest rotation
		while(true)
		{
			Vector3 deltadirection = -m_AIShip.transform.position;
			Vector3 curdir = m_AIShip.m_LookingVector;
			
			float angle = Vector2.Angle(curdir, deltadirection);
			if(angle > 5f && Vector3.Cross(curdir, deltadirection).z < 0f)
			{
				m_AIShip.SetRotationInput(-1f);
			}else if(angle > 5f)
			{
				m_AIShip.SetRotationInput(1f);
			}else
			{
				m_AIShip.SetRotationInput(0f);
			}
			
			m_AIShip.AddRowGauge(true, Managers.GameBalanceData.GamePlayRowPressAmount, 1);
			m_AIShip.AddRowGauge(false, Managers.GameBalanceData.GamePlayRowPressAmount, 1);

			yield return new WaitForFixedUpdate();
		}
		yield break;
	}
}

public enum PlayerShipAIState
{
	ATTACK_EASY 		= 0,
	ATTACK_MID			= 1,
	ATTACK_HARD			= 2,

	DEFEND_EASY			= 10,
	DEFEND_MID			= 11,
	DEFEND_HARD			= 12,

	RUN_EASY			= 20,
	RUN_MID				= 21,
	RUN_HARD			= 22,

	AVOID_EASY			= 30,
	AVOID_MID			= 31,
	AVOID_HARD			= 32,

	RETURN_TO_BATTLE	= 41,
}