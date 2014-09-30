using UnityEngine;
using System.Collections;

public class ShoutEffect : MonoBehaviour {

	public Collider2D m_Collider;
	public tk2dSprite m_Sprite;

	public float PushForce;
	public float MaxRadius = 40f;

	public void Init(float _pushforce)
	{
		PushForce = _pushforce;
		m_Sprite.gameObject.SetActive(false);
		m_Collider.enabled = false;
	}

	public void PlayEffect(Vector3 _position)
	{
		gameObject.SetActive(true);
		Vector3 newpos = _position;
		newpos.z = Constant.ST200_GameObjectLayer_FX;
		transform.position = newpos;

		StartCoroutine(PlayerFX());
	}

	protected IEnumerator PlayerFX()
	{
		//m_Sprite.gameObject.SetActive(true);
		GamePlayFXManager.Instance.StartParticleFX(GamePlayParticleFX_Type.SHOUT_FX,
		                                           transform.position);
		m_Collider.enabled = true;
		m_Sprite.scale = Vector3.zero;
		float timer = 0f;
		float maxtimer = 0.5f;
		while(timer < maxtimer)
		{
			timer += Time.fixedDeltaTime;
			//m_Sprite.scale = Vector3.Lerp(m_Sprite.scale, Vector3.one * MaxRadius, timer / maxtimer);
			yield return new WaitForFixedUpdate();
		}

		m_Collider.enabled = false;
		m_Sprite.gameObject.SetActive(false);
		yield break;
	}

	void OnTriggerEnter2D(Collider2D _col)
	{
		if(_col != null && _col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			GameStageEnemyObject enemy = _col.gameObject.GetComponent<GameStageEnemyObject>();
			enemy.AddHitForce(transform.position, (_col.transform.position - transform.position) * PushForce);
		}
	}
}
