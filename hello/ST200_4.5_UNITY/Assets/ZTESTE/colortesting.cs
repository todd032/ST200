using UnityEngine;
using System.Collections;

public class colortesting : MonoBehaviour {

	public float a;
	public float r;
	public float g;
	public float b;

	public UISprite m_Sprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		m_Sprite.color = new Color(r,g,b,a);
	}
}
