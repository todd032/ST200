using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayArrowAni : MonoBehaviour {

	public UISprite m_HandTouchSprite;
	public List<UISprite> m_ArrowSprite = new List<UISprite>();
	public List<UISprite> m_ShipSprite = new List<UISprite>();


	void Awake()
	{
		for(int i = 0; i < m_ArrowSprite.Count; i++)
		{
			NGUITools.SetActive(m_ArrowSprite[i].gameObject, false);
		}
		for(int i = 0; i < m_ShipSprite.Count; i++)
		{
			NGUITools.SetActive(m_ShipSprite[i].gameObject, false);
		}
	}

	public void StartAnimation()
	{
		StopAllCoroutines();

		
		for(int i = 0; i < m_ArrowSprite.Count; i++)
		{
			NGUITools.SetActive(m_ArrowSprite[i].gameObject, false);
		}
		for(int i = 0; i < m_ShipSprite.Count; i++)
		{
			NGUITools.SetActive(m_ShipSprite[i].gameObject, false);
		}
		if(gameObject.activeSelf)
		{
			StartCoroutine(ArrowAnimation());
			StartCoroutine(ShipAnimation());
			StartCoroutine(HandAnimation());
		}
	}

	protected IEnumerator ShipAnimation()
	{
		int index = 0;
		while(true)
		{
			
			for(int i = 0; i < m_ShipSprite.Count; i++)
			{
				NGUITools.SetActive(m_ShipSprite[i].gameObject, true);
				yield return new WaitForSeconds(0.5f);
			}
			
			
			for(int i = 0; i < m_ShipSprite.Count; i++)
			{
				NGUITools.SetActive(m_ShipSprite[i].gameObject, false);
			}
		}
		
		yield break;
		yield break;
	}

	protected IEnumerator HandAnimation()
	{
		int index = 0;
		while(true)
		{
			index++;
			if(index % 2 == 1)
			{
				m_HandTouchSprite.spriteName = "tutorial_hand_icon_2";
				m_HandTouchSprite.MakePixelPerfect();
			}else
			{
				m_HandTouchSprite.spriteName = "tutorial_hand_icon_1";
				m_HandTouchSprite.MakePixelPerfect();
			}
			
			yield return new WaitForSeconds(0.25f);
		}

		yield break;
	}

	protected IEnumerator ArrowAnimation()
	{

		int index = 0;
		while(true)
		{

			for(int i = 0; i < m_ArrowSprite.Count; i++)
			{
				NGUITools.SetActive(m_ArrowSprite[i].gameObject, true);
				yield return new WaitForSeconds(0.5f);
			}


			for(int i = 0; i < m_ArrowSprite.Count; i++)
			{
				NGUITools.SetActive(m_ArrowSprite[i].gameObject, false);
			}
		}

		yield break;
	}
}
