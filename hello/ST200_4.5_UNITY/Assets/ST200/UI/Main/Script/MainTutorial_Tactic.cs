using UnityEngine;
using System.Collections;

public class MainTutorial_Tactic : MonoBehaviour {

	public UILabel m_TacticLabel;
	public UILabel m_PressShipLabel;

	// Use this for initialization
	void Start () {
		m_TacticLabel.text = TextManager.Instance.GetString (201);
		m_PressShipLabel.text = TextManager.Instance.GetString(195);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
