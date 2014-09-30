using UnityEngine;
using System.Collections;

public class GamePlayAttackFX : MonoBehaviour {

	public tk2dSpriteAnimator m_AnimatedSprite;
	public GamePlayAttackFX_Type m_ExplosionType;

	public void Init(GamePlayAttackFX_Type _type)
	{
		m_ExplosionType = _type;
		m_AnimatedSprite.Play(m_ExplosionType.ToString());
	}

	public void SetPosition(Vector3 _worldpos)
	{
		Vector3 newpos = _worldpos;
		newpos.z = Constant.ST200_GameObjectLayer_FX;
		transform.position = newpos;
	}

	public void Play(GamePlayAttackFX_Type _type)
	{
		Init (_type);
		StartCoroutine(StartAnimation());
	}

	public void Done()
	{
		GamePlayFXManager.Instance.ReturnAttackFX(this);
	}
	
	private IEnumerator StartAnimation()
	{
		while(m_AnimatedSprite.IsPlaying(m_ExplosionType.ToString()))
		{
			yield return null;
		}
		
		GamePlayFXManager.Instance.ReturnAttackFX(this);
		yield break;
	}
}

public enum GamePlayAttackFX_Type
{
	FX_Attack_Miss,
	FX_Attack_Smoke,
	FX_Boss_Shoot,
	FX_Player_Shoot,
	FX_Attack_Target,
}
