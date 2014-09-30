using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InvitationButtonAnimation : MonoBehaviour {

	public UISprite m_ButtonSprite;
	public List<GameObject> m_TwinkleObject = new List<GameObject>();

	// Use this for initialization
	void Start () {
		//StartCoroutine(ButtonSpriteAnimation(m_ButtonSprite, 1f));
		//StartCoroutine(ButtonSpriteAnimation(m_ButtonSprite.gameObject, 1.0f));
		//StartCoroutine(TwinkleAnimation(m_TwinkleObject[0], 1.3f));
		//StartCoroutine(TwinkleAnimation(m_TwinkleObject[1], 2.7f));
		//StartCoroutine(TwinkleAnimation(m_TwinkleObject[2], 3.3f));
		//StartCoroutine(TwinkleAnimation(m_TwinkleObject[3], 4.7f));
	}

	void OnEnable()
	{
		StartCoroutine(ButtonSpriteAnimation(m_ButtonSprite.gameObject, 1.0f));
		StartCoroutine(TwinkleAnimation(m_TwinkleObject[0], 1.3f));
		StartCoroutine(TwinkleAnimation(m_TwinkleObject[1], 2.7f));
		StartCoroutine(TwinkleAnimation(m_TwinkleObject[2], 3.3f));
		StartCoroutine(TwinkleAnimation(m_TwinkleObject[3], 4.7f));
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ButtonSpriteAnimation(GameObject _sprite, float _timer)
	{
		_sprite.SetActive(false);
		while(true)
		{
			_sprite.SetActive(!_sprite.activeSelf);
			yield return new WaitForSeconds(_timer);
		}
		yield break;
	}

	IEnumerator TwinkleAnimation(GameObject _gameobj, float _timer)
	{
		_gameobj.SetActive(false);
		while(true)
		{
			yield return new WaitForSeconds(_timer);

			_gameobj.SetActive(true);
			yield return new WaitForSeconds(0.1f);
			_gameobj.SetActive(false);
		}

		yield break;
	}
}
