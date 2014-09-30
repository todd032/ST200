using UnityEngine;
using System.Collections;

public class movefolow : MonoBehaviour {

	public Transform m_Target;
	public Vector3 m_Direction;

	// Use this for initialization
	void Start () {
		StartCoroutine(FollowTarget());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator FollowTarget()
	{
		while(true)
		{
			if(m_Target != null)
			{
				m_Direction = Vector3.Slerp(m_Direction, m_Target.position - transform.position, 0.2f);
			}else
			{
				m_Direction = Vector3.zero;
			}
			transform.right = -m_Direction;
			transform.position += m_Direction * Time.deltaTime * 3f;
			yield return null;
		}
		yield break;
	}
}
