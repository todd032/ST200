using UnityEngine;
using System.Collections;

public class CutInFXAnimation_GO : MonoBehaviour {

	public Camera m_UICamera;

	public UISprite m_Sprite;
	public UISprite m_Sprite2;

	protected Vector3 m_StartVector;
	protected Vector3 m_EndVector;

	protected bool m_IsPlaying = false;
	void Awake()
	{
		NGUITools.SetActive(m_Sprite.gameObject, false);
		NGUITools.SetActive(m_Sprite2.gameObject, false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnimation(int _character)
	{
		StopAllCoroutines();
		NGUITools.SetActive(m_Sprite.gameObject, true);
		NGUITools.SetActive(m_Sprite2.gameObject, true);
		m_Sprite.spriteName = ImageResourceManager.Instance.GetCutInFX_GOImageName(_character);
		m_Sprite.MakePixelPerfect();
		m_Sprite2.MakePixelPerfect();

		m_IsPlaying = true;
		StartCoroutine(IEPlayAnimation());

	}

	protected IEnumerator IEPlayAnimation()
	{
		//Vector3 startposition = new Vector3(-(float)Screen.width/2f - (float)m_Sprite.width - 20f, 0f, 0f);
		//Vector3 endposition = Vector3.zero;
		Color curcolor = Color.white;
		curcolor.a = 0f;
		m_Sprite.color = curcolor;

		float timer = 0f;
		float fadein = 0.25f;

		//transform.localPosition = startposition;
		while(timer < fadein)
		{
			timer += Time.fixedDeltaTime;
			//transform.localPosition = Vector3.Lerp(transform.localPosition, endposition, timer / movetimer);
			curcolor.a = 1f * timer / fadein;
			m_Sprite.color = curcolor;
			m_Sprite2.color = curcolor;
			yield return new WaitForFixedUpdate();
		}

		timer = 0f;
		float staytimer = 1f;
		while(timer < staytimer)
		{
			timer += Time.fixedDeltaTime;
			
			yield return new WaitForFixedUpdate();
		}


		timer = 0f;
		float fadeout = 0.25f;
		
		//transform.localPosition = startposition;
		while(timer < fadeout)
		{
			timer += Time.fixedDeltaTime;
			//transform.localPosition = Vector3.Lerp(transform.localPosition, endposition, timer / movetimer);
			curcolor.a = 1f - 1f * timer / fadeout;
			m_Sprite.color = curcolor;
			m_Sprite2.color = curcolor;
			yield return new WaitForFixedUpdate();
		}

		NGUITools.SetActive(m_Sprite.gameObject, false);
		NGUITools.SetActive(m_Sprite2.gameObject, false);

		m_IsPlaying = false;
		yield break;
	}

	public bool IsPlaying()
	{
		return m_IsPlaying;
	}
}
