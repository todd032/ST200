using UnityEngine;
using System.Collections;

public class MainTutorial_REady : MonoBehaviour {

	public UILabel m_UILabel;

	void Awake()
	{
		m_UILabel.text = TextManager.Instance.GetString (216);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
