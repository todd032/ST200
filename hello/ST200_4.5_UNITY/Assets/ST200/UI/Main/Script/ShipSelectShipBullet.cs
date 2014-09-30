using UnityEngine;
using System.Collections;

public class ShipSelectShipBullet : MonoBehaviour {

	protected Vector3 m_StartLocalVector;
	public float m_DisplayTime = 1f;
	public float m_Speed = 1f;

	protected float DisplayTimer = 0f;

	void Awake()
	{
		m_StartLocalVector = transform.localPosition;
	}

	void Update()
	{
		DisplayTimer += Time.deltaTime;
		transform.localPosition += transform.up * m_Speed * Time.deltaTime;
		if(DisplayTimer > m_DisplayTime)
		{
			DisplayTimer = 0f;
			NGUITools.SetActive(gameObject, false);
		}
	}

	public void Shoot()
	{
		DisplayTimer = 0f;
		NGUITools.SetActive(gameObject, true);
		transform.localPosition = m_StartLocalVector;
	}
}
