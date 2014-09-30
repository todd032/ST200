using UnityEngine;
using System.Collections;

public class enemyforcecreator : MonoBehaviour {

	public GameStageEnemyObject m_Enemy;
	public Camera m_Camera;

	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 worldpos = m_Camera.ScreenToWorldPoint(Input.mousePosition);
			Vector3 force = (-worldpos + m_Enemy.transform.position).normalized;// Vector3.up * 1f;
			m_Enemy.AddHitForce(worldpos, force);
		}
	}
}
