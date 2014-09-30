using UnityEngine;
using System.Collections;

public class hello : MonoBehaviour {

	public tk2dAnimatedSprite m_SpriteAnim;
	public tk2dClippedSprite m_SpriteRURU;
	// Use this for initialization
	void Start () {
		Debug.Log(m_SpriteAnim.GetUntrimmedBounds().size.x);

	}
	
	// Update is called once per frame
	void Update () {
		m_SpriteRURU.SetSprite(m_SpriteAnim.GetSpriteIdByName(m_SpriteAnim.CurrentSprite.name));
	}
}
