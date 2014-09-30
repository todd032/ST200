using UnityEngine;
using System.Collections;

public class GamePlayFXObject : MonoBehaviour {

	public GamePlayFXObject_Type m_Type;
	
	public void Init()
	{

	}

	public void SetPosition(Vector3 _startposition)
	{
		Vector3 newpos = _startposition;
		newpos.z = Constant.ST200_GameObjectLayer_FX;
		transform.position = newpos;
	}

	public void Play(Vector3 _startposition)
	{
		Init ();
		SetPosition(_startposition);
		StartCoroutine(StartAnimation());
	}
	
	private IEnumerator StartAnimation()
	{
		float timer = 0f;
		float maxtime = 1f;
		while(timer < maxtime)
		{
			timer += Time.deltaTime;			
			transform.position += Vector3.up * 0.5f * Time.deltaTime;
			
			yield return null;
		}
		
		GamePlayFXManager.Instance.ReturnFX(this);
		yield break;
	}
}
public enum GamePlayFXObject_Type
{
	GAIN_ATTACK = 1,
	GAIN_HEALTH = 2,
	GAIN_COIN = 3,
	GAIN_GOLD = 4,
}