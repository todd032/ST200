using UnityEngine;
using System.Collections;

public class GamePlayParticleFX : MonoBehaviour {

	public GamePlayParticleFX_Type m_Type;
	public ParticleSystem[] m_ParticleSystemList;
	
	public void SetPosition(Vector3 _worldpos)
	{
		Vector3 newpos = _worldpos;
		newpos.z = Constant.ST200_GameObjectLayer_FX_Particle;
		transform.position = newpos;
	}
	
	public void Play()
	{
		StartCoroutine(StartAnimation());
	}
	
	public void Done()
	{
		GamePlayFXManager.Instance.ReturnParticleFX(this);
	}
	
	private IEnumerator StartAnimation()
	{
		for(int i = 0; i < m_ParticleSystemList.Length;	i++)
		{
			m_ParticleSystemList[i].Play();
		}

		while(true)
		{
			bool isdone = true;
			for(int i = 0; i < m_ParticleSystemList.Length;	i++)
			{
				if(m_ParticleSystemList[i].isPlaying)
				{
					isdone = false;
				}
			}

			if(isdone)
			{
				break;
			}
			yield return null;
		}
		
		GamePlayFXManager.Instance.ReturnParticleFX(this);
		yield break;
	}
}

public enum GamePlayParticleFX_Type
{
	HEAL_FX,
	SHOUT_FX,
	INVINCIBLE_FX,
	ARROW_HIT_FX,
	ARROW_MISS_FX,
}
