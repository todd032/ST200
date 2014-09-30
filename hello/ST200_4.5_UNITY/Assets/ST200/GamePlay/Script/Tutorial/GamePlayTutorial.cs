using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayTutorial : MonoBehaviour {

	public List<GameObject> TutorialObjectList = new List<GameObject>();
	public GamePlayArrowAni m_ArrowAni1;
	public GamePlayArrowAni m_ArrowAni2;
	protected int TutorialIndex = 0;
	protected bool m_TutorialPlaying = false;

	public Camera PlayerCamera;
	public BackgroundManager m_BackgroundManager;
	void Awake()
	{
		HideTutorial();
		PlayerCamera.gameObject.SetActive(false);
	}

	void Update()
	{
		if(m_TutorialPlaying)
		{
			if(Input.GetMouseButtonDown(0))
			{
				TutorialIndex++;
				SetTutorial(TutorialIndex);
				if(TutorialIndex == TutorialObjectList.Count)
				{
					HideTutorial();
					m_TutorialPlaying = false;
				}
			}
		}
	}

	public void HideTutorial()
	{
		m_BackgroundManager.SetBackgroundColor(Color.white);
		for(int i = 0 ; i < TutorialObjectList.Count; i++)
		{
			NGUITools.SetActive(TutorialObjectList[i], false);
		}
		PlayerCamera.gameObject.SetActive(false);
	}

	public void SetTutorial(int _index)
	{
		if(TutorialObjectList.Count > _index)
		{
			m_BackgroundManager.SetBackgroundColor(Color.grey);
			if(_index > 0)
			{
				NGUITools.SetActive(TutorialObjectList[_index - 1].gameObject, false);
				//PlayerCamera.gameObject.SetActive(false);
			}
			NGUITools.SetActive(TutorialObjectList[_index].gameObject, true);
			m_ArrowAni1.StartAnimation();
			m_ArrowAni2.StartAnimation();
		}
	}

	public void StartTutorial()
	{
		PlayerCamera.gameObject.SetActive(true);
		m_TutorialPlaying = true;
		TutorialIndex = 0;
		SetTutorial(TutorialIndex);
	}

	public bool IsPlaying()
	{
		return m_TutorialPlaying;
	}
}
