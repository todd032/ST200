using UnityEngine;
using System.Collections;

public class GamePlayExplosionFX : MonoBehaviour {

	public tk2dSpriteAnimator m_AnimatedSprite;
	public GamePlayExplosionFX_Type m_ExplosionType;

	public void Play(GamePlayExplosionFX_Type _type)
	{
		m_ExplosionType = _type;
		StartCoroutine(StartAnimation());
	}


	private IEnumerator StartAnimation()
	{
		m_AnimatedSprite.Play(m_ExplosionType.ToString());
		while(m_AnimatedSprite.IsPlaying(m_ExplosionType.ToString()))
		{
			yield return null;
		}

		GamePlayFXManager.Instance.ReturnExplosionFX(this);
		yield break;
	}
}

public enum GamePlayExplosionFX_Type
{
	Explosion1,
	Explosion2,
	Explosion3,
}