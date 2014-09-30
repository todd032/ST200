using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SubmarineBulletObject_Missile : SubmarineBulletObject {
	
	protected Transform m_TargetTransform;
	protected Vector3 m_MoveDirection;
	
	protected override void Awake (){
		base.Awake ();
	}
	
	public override void SetActiveSpriteObject(bool isActiveSpriteObject) {
		base.SetActiveSpriteObject(isActiveSpriteObject) ;
	}
	
	public override void DestroySpriteObject(int destroyType) {
		base.	DestroySpriteObject(destroyType) ;

		m_TargetTransform = null;
	}
	
	// Use this for initialization
	protected override void Start () {
		
	}	
		
	//---FSM
	protected  override IEnumerator Idle(){
		
		float timer = 0f;
		float existtime = 5f;
		yield return null;
		
		while(_fireBulletState == FireBulletState.Idle) {

			timer += Time.deltaTime;
			//float amtMove = _bulletSpeed * Time.deltaTime;		
			//_thisTransform.Translate(Vector3.right * amtMove);
			//
			//if((_thisTransform.position.x < -(_screenSizeWidth*0.5f) || _thisTransform.position.x > (_screenSizeWidth*0.5f)) ||
			//   (_thisTransform.position.y < -(_screenSizeHeight*0.5f) || _thisTransform.position.y > (_screenSizeHeight*0.5f)) ){
			//	_fireBulletState = FireBulletState.Dead ;
			//}
			//
			//yield return null;


			if(m_TargetTransform != null && m_TargetTransform.gameObject.activeSelf)
			{
				Vector3 curpos = transform.position;
				curpos.z = 0f;
				Vector3 target = m_TargetTransform.position;
				target.z = 0f;
				m_MoveDirection = Vector3.Slerp(m_MoveDirection, target - curpos, 0.2f);
				m_MoveDirection.z = 0f;
				m_MoveDirection.Normalize();
			}else
			{
				if(m_TargetTransform != null)
				{
					m_TargetTransform = null;
					m_MoveDirection = Vector3.right;
				}else
				{
					m_MoveDirection = transform.right;
				}
			}

			m_MoveDirection.z = 0f;
			transform.right = m_MoveDirection;
			transform.position += m_MoveDirection * Time.deltaTime * _bulletSpeed;

			if(timer >= existtime)
			{
				_fireBulletState = FireBulletState.Dead ;
			}
			yield return null;
		}
		
		StartCoroutine(_fireBulletState.ToString());
		
	}

	public override void FireBulletAction(Vector3 createPosition) {
		
		_thisTransform.position = createPosition ;
		_thisTransform.right = Vector3.right;
		m_TargetTransform = null;

		_fireBulletState = FireBulletState.Idle ;
		StartCoroutine(_fireBulletState.ToString());
		
	}

	public void ApplyTarget(Collider _col, int _type)
	{
		//if(m_TargetTransform != null)
		//{
		//	return;
		//}else 
		if(_type == 0)
		{
			if(_col.enabled && _col.tag == "ENEMY")
			{
				if(m_TargetTransform == null)
				{
					m_TargetTransform = _col.transform;
				}else
				{
					if(Vector3.Distance(transform.position, m_TargetTransform.position) > Vector3.Distance(transform.position, _col.transform.position) ||
					   (m_TargetTransform.position.x < transform.position.x && _col.transform.position.x > transform.position.x))
					{
						m_TargetTransform = _col.transform;
					}
				}
			}
		}else if(_type == 1)
		{
			if(m_TargetTransform != null)
			{
				return;
			}else if(_col.enabled && _col.tag == "ENEMY")
			{
				m_TargetTransform = _col.transform;				
			}
		}
	}
}
