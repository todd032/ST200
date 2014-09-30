using UnityEngine;
using System.Collections;

public class MainTutorial_Character : MonoBehaviour {

	public UILabel m_CharacterLabel;

	void Awake()
	{
		m_CharacterLabel.text = Constant.COLOR_WHITE + TextManager.Instance.GetString(200);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
