using UnityEngine;
using System.Collections;

public class nguitestscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UISprite sprite = GetComponent<UISprite>();
		sprite.spriteName = sprite.spriteName;
		sprite.MakePixelPerfect();
		Debug.Log("it is calleD");
	}
	
	// Update is called once per frame
	void Update () {

	}
}
