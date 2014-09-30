using UnityEngine;
using System.Collections;

public class GamePlayRangeDisplayer : MonoBehaviour {

	public tk2dSprite m_CircleSprite;
		
	public void Init(float _range)
	{
		float imageradius = m_CircleSprite.GetCurrentSpriteDef().GetBounds().size.x / 2f;
		float multiplyfactor = _range / imageradius;

		m_CircleSprite.scale = Vector3.one * multiplyfactor;
	}

	// Update is called once per frame
	void UpdateUI(bool _showui) {
		m_CircleSprite.gameObject.SetActive(_showui);
	}
}
