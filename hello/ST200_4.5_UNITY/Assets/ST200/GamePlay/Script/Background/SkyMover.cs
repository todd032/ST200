using UnityEngine;
using System.Collections;

public class SkyMover : MonoBehaviour {

	public Camera m_GameCamera;
	public tk2dSprite m_Sprite;
	public float m_MoveSpeed;
	// Use this for initialization
	void Start () {
		m_MoveSpeed = Random.Range(1f,3f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newpos  = transform.position;
		newpos.z = Constant.ST200_GameObjectLayer_Foreground;
		newpos -= Vector3.right * m_MoveSpeed * Time.deltaTime;
		if(transform.position.x < m_GameCamera.transform.position.x - m_GameCamera.orthographicSize * 2f * m_GameCamera.aspect - m_Sprite.GetBounds().size.x / 2f)
		{
			newpos.x = m_GameCamera.transform.position.x + m_GameCamera.orthographicSize * 2f * m_GameCamera.aspect + m_Sprite.GetBounds().size.x / 2f;
		}
		transform.position = newpos;
	}
}
