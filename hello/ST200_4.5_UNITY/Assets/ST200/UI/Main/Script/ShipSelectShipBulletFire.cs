using UnityEngine;
using System.Collections;

public class ShipSelectShipBulletFire : MonoBehaviour {

	protected Vector3 m_StartLocalVector;
	public float m_DisplayTime = 1f;
	public float m_DelayTime = 0f;
	public float m_Speed = 1f;
	public float m_TotalTime = 2f;
	protected float DisplayTimer = 0f;
	public UISprite m_Sprite;
	void Awake()
	{
		m_StartLocalVector = transform.localPosition;
	}
	
	void Update()
	{
		DisplayTimer += Time.deltaTime;
		if(DisplayTimer > m_DelayTime)
		{
			//NGUITools.SetActive(gameObject, true);
			m_Sprite.enabled = true;
			transform.localPosition += transform.up * m_Speed * Time.deltaTime;
		}else
		{
			//NGUITools.SetActive(gameObject, false);
			//transform.localPosition = m_StartLocalVector;
			m_Sprite.enabled = false;
		}

		if(DisplayTimer > m_DelayTime + m_DisplayTime)
		{
			m_Sprite.enabled = false;
		}

		if(DisplayTimer > m_TotalTime)
		{
			//DisplayTimer = 0f;
			Shoot();
			//NGUITools.SetActive(gameObject, false);
		}
	}
	
	public void Shoot()
	{
		DisplayTimer = 0f;
		//NGUITools.SetActive(gameObject, true);
		transform.localPosition = m_StartLocalVector;
		//m_Sprite.enabled = true;
	}
}
