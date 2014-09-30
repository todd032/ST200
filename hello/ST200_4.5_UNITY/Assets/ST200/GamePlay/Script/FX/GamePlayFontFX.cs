using UnityEngine;
using System.Collections;

public class GamePlayFontFX : MonoBehaviour {

	public tk2dTextMesh m_TextMesh;

	public void Init(Color _color, Vector3 _startposition, string _value)
	{
		m_TextMesh.color = _color;
		m_TextMesh.text = _value;
		Vector3 newpos = _startposition;
		newpos.z = Constant.ST200_GameObjectLayer_FontFX;
		transform.position = newpos;
	}

	public void Play(Color _color, Vector3 _startposition, string _value)
	{
		Init (_color, _startposition, _value);

		StartCoroutine(StartAnimation());
	}

	private IEnumerator StartAnimation()
	{
		float timer = 0f;
		float maxtime = 1f;
		while(timer < maxtime)
		{
			timer += Time.deltaTime;
			Color newcolor = m_TextMesh.color;
			newcolor.a = (maxtime - timer) / maxtime;
			m_TextMesh.color = newcolor;

			transform.position += Vector3.up * 0.5f * Time.deltaTime;

			yield return null;
		}
		
		GamePlayFXManager.Instance.ReturnFontFX(this);
		yield break;
	}
}
