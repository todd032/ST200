using UnityEngine;
using System.Collections;

public class animationtest : MonoBehaviour {
	public GameObject object1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(PlayUserRankSwithAnim());
		}
	}

	private IEnumerator PlayUserRankSwithAnim()
	{
		Transform userranktransform = object1.transform;
		Vector3 startposition = userranktransform.transform.localPosition;
		Vector3 endposition = startposition;
		endposition.y = -startposition.y;
		
		float TotalTime = 0.5f;
		float DX = 30f;
		float VX = 0f;
		float AX = 0f;
		float VY = (endposition.y - startposition.y) / TotalTime;
		AX = -8f * DX / (TotalTime * TotalTime);
		VX = -AX * TotalTime / 2f;


		float timer = 0f;
		while(timer < TotalTime)
		{
			timer += Time.deltaTime;
			Vector3 position = startposition + new Vector3(VX * timer + AX * timer * timer / 2f, VY * timer, 0f);
			userranktransform.localPosition = position;
			yield return null;
		}
		userranktransform.localPosition = endposition;
		yield break;
	}
}
