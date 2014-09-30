using UnityEngine;
using System.Collections;

public class GameStageEnemyHealthDisplayer : MonoBehaviour {

	public tk2dSprite m_BackSprite;
	public tk2dSprite m_FrontSprite;
	public tk2dClippedSprite m_HealthSprite;

	// Use this for initialization
	void Start () {
		Vector3 newpos = transform.position;
		newpos.z = Constant.ST200_GameObjectLayer_EnemyEnergy;
		transform.position = newpos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateHealth(float _curhealth, float _maxhealth)
	{
		if(_curhealth <= 0f)
		{
			m_BackSprite.gameObject.SetActive(false);
			m_FrontSprite.gameObject.SetActive(false);
			m_HealthSprite.gameObject.SetActive(false);
		}else
		{
			m_BackSprite.gameObject.SetActive(true);
			m_FrontSprite.gameObject.SetActive(true);
			m_HealthSprite.gameObject.SetActive(true);

			Rect currect = m_HealthSprite.ClipRect;
			currect.width = _curhealth / _maxhealth;
			m_HealthSprite.ClipRect = currect;
		}
		//m_HealthSprite
	}
}
