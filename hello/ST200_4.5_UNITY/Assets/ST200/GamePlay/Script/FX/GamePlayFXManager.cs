using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayFXManager : MonoBehaviour {

	private static GamePlayFXManager instance ;
	public static GamePlayFXManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(GamePlayFXManager)) as GamePlayFXManager;
			}
			return instance;
		}
	}

	void OnDestroy()
	{
		instance = null;
	}


	#region ExplosionFX
	public Camera m_ExplosionGamePlayCamera;
	public Camera m_ExplosionFXCamera;
	public Object m_ExplosionFXObject;

	protected List<GamePlayExplosionFX> m_ExplosionFX_Unused = new List<GamePlayExplosionFX>();
	public GamePlayExplosionFX StartExplosionFX(GamePlayExplosionFX_Type _type, Vector3 _worldpos)
	{
		GamePlayExplosionFX fx = null;
		if(m_ExplosionFX_Unused.Count != 0)
		{
			fx = m_ExplosionFX_Unused[0];
			m_ExplosionFX_Unused.RemoveAt(0);
		}

		if(fx == null)
		{
			GameObject go = Instantiate(m_ExplosionFXObject) as GameObject;
			fx = go.GetComponent<GamePlayExplosionFX>();
		}

		//place and play
		Vector3 screenpos = m_ExplosionGamePlayCamera.WorldToScreenPoint(_worldpos);
		Vector3 newworldpos = m_ExplosionFXCamera.ScreenToWorldPoint(screenpos);
		newworldpos.z = -10f;

		fx.transform.position = newworldpos;
		fx.gameObject.SetActive(true);
		fx.Play(_type);

		return fx;
	}

	public void ReturnExplosionFX(GamePlayExplosionFX _fx)
	{
		_fx.gameObject.SetActive(false);
		m_ExplosionFX_Unused.Add(_fx);
	}
	#endregion

	#region Attack FX
	public Camera m_AttackGamePlayCamera;
	public Camera m_AttackFXCamera;
	public Object m_AttackFXObject;

	protected List<GamePlayAttackFX> m_AttackFX_Unused = new List<GamePlayAttackFX>();
	public GamePlayAttackFX StartAttackFX(GamePlayAttackFX_Type _type, Vector3 _worldpos)
	{
		GamePlayAttackFX fx = null;
		if(m_AttackFX_Unused.Count != 0)
		{
			fx = m_AttackFX_Unused[0];
			m_AttackFX_Unused.RemoveAt(0);
		}
		
		if(fx == null)
		{
			GameObject go = Instantiate(m_AttackFXObject) as GameObject;
			fx = go.GetComponent<GamePlayAttackFX>();
		}
		
		//place and play
		Vector3 screenpos = m_ExplosionGamePlayCamera.WorldToScreenPoint(_worldpos);
		Vector3 newworldpos = m_ExplosionFXCamera.ScreenToWorldPoint(screenpos);
		newworldpos.z = -10f;
		
		fx.transform.position = newworldpos;
		fx.gameObject.SetActive(true);
		fx.Play(_type);

		return fx;
	}

	public GamePlayAttackFX GetAttackFX(GamePlayAttackFX_Type _type)
	{
		GamePlayAttackFX fx = null;
		if(m_AttackFX_Unused.Count != 0)
		{
			fx = m_AttackFX_Unused[0];
			m_AttackFX_Unused.RemoveAt(0);
		}
		
		if(fx == null)
		{
			GameObject go = Instantiate(m_AttackFXObject) as GameObject;
			fx = go.GetComponent<GamePlayAttackFX>();
		}
		fx.gameObject.SetActive(true);
		fx.Init (_type);
		return fx;
	}

	public void ReturnAttackFX(GamePlayAttackFX _fx)
	{
		_fx.gameObject.SetActive(false);
		m_AttackFX_Unused.Add(_fx);
	}
	#endregion

	#region Particle FX
	public Camera m_ParticleGamePlayCamera;
	public Camera m_ParticleFXCamera;
	public List<GamePlayParticleFX> m_ParticleFXObjectList = new List<GamePlayParticleFX>();
	
	protected List<GamePlayParticleFX> m_ParticleFX_Unused = new List<GamePlayParticleFX>();
	public GamePlayParticleFX StartParticleFX(GamePlayParticleFX_Type _type, Vector3 _worldpos)
	{
		GamePlayParticleFX fx = GetParticleFX(_type, _worldpos);

		fx.gameObject.SetActive(true);
		fx.Play();
		
		return fx;
	}
	
	public GamePlayParticleFX GetParticleFX(GamePlayParticleFX_Type _type, Vector3 _worldpos)
	{
		GamePlayParticleFX fx = null;
		for(int i = 0 ; i < m_ParticleFX_Unused.Count; i++)
		{
			GamePlayParticleFX curfx = m_ParticleFX_Unused[i];
			if(curfx.m_Type == _type)
			{
				fx = curfx;
				m_ParticleFX_Unused.RemoveAt(i);
				break;
			}
		}
		
		if(fx == null)
		{
			for(int i = 0; i < m_ParticleFXObjectList.Count; i++)
			{
				if(m_ParticleFXObjectList[i].m_Type == _type)
				{
					GameObject go = Instantiate(m_ParticleFXObjectList[i].gameObject) as GameObject;
					fx = go.GetComponent<GamePlayParticleFX>();
					break;
				}
			}
		}

		//place and play
		Vector3 screenpos = m_ExplosionGamePlayCamera.WorldToScreenPoint(_worldpos);
		Vector3 newworldpos = m_ExplosionFXCamera.ScreenToWorldPoint(screenpos);
		
		fx.SetPosition(newworldpos);
		//fx.gameObject.SetActive(true);
		return fx;
	}
	
	public void ReturnParticleFX(GamePlayParticleFX _fx)
	{
		_fx.gameObject.SetActive(false);
		m_ParticleFX_Unused.Add(_fx);
	}
	#endregion

	#region font FX
	public Camera m_FontGamePlayCamera;
	public Camera m_FontFXCamera;
	public Object m_FontFXObject;
	
	protected List<GamePlayFontFX> m_FontFX_Unused = new List<GamePlayFontFX>();
	public GamePlayFontFX StartFontFX(Color _color, Vector3 _worldpos, string _value)
	{
		GamePlayFontFX fx = null;
		if(m_FontFX_Unused.Count != 0)
		{
			fx = m_FontFX_Unused[0];
			m_FontFX_Unused.RemoveAt(0);
		}
		
		if(fx == null)
		{
			GameObject go = Instantiate(m_FontFXObject) as GameObject;
			fx = go.GetComponent<GamePlayFontFX>();
		}
		
		//place and play
		Vector3 screenpos = m_ExplosionGamePlayCamera.WorldToScreenPoint(_worldpos);
		Vector3 newworldpos = m_ExplosionFXCamera.ScreenToWorldPoint(screenpos);
		newworldpos.z = -10f;
		
		fx.transform.position = newworldpos;
		fx.gameObject.SetActive(true);
		fx.Play(_color, _worldpos, _value);
		
		return fx;
	}
	
	public GamePlayFontFX GetAttackFX()
	{
		GamePlayFontFX fx = null;
		if(m_FontFX_Unused.Count != 0)
		{
			fx = m_FontFX_Unused[0];
			m_FontFX_Unused.RemoveAt(0);
		}
		
		if(fx == null)
		{
			GameObject go = Instantiate(m_FontFXObject) as GameObject;
			fx = go.GetComponent<GamePlayFontFX>();
		}
		fx.gameObject.SetActive(true);
		return fx;
	}
	
	public void ReturnFontFX(GamePlayFontFX _fx)
	{
		_fx.gameObject.SetActive(false);
		m_FontFX_Unused.Add(_fx);
	}
	#endregion

	#region FX
	public Camera m_GamePlayCamera;
	public Camera m_FXCamera;
	public List<GamePlayFXObject> m_FXObjectList = new List<GamePlayFXObject>();	
	protected List<GamePlayFXObject> m_FX_Unused = new List<GamePlayFXObject>();
	public GamePlayFXObject StartFX(GamePlayFXObject_Type _type, Vector3 _worldpos)
	{
		GamePlayFXObject fx = GetFX(_type, _worldpos);
		
		fx.gameObject.SetActive(true);
		fx.Play(_worldpos);
		
		return fx;
	}
	
	public GamePlayFXObject GetFX(GamePlayFXObject_Type _type, Vector3 _worldpos)
	{
		GamePlayFXObject fx = null;
		for(int i = 0 ; i < m_FX_Unused.Count; i++)
		{
			GamePlayFXObject curfx = m_FX_Unused[i];
			if(curfx.m_Type == _type)
			{
				fx = curfx;
				m_FX_Unused.RemoveAt(i);
				break;
			}
		}
		
		if(fx == null)
		{
			for(int i = 0; i < m_FXObjectList.Count; i++)
			{
				if(m_FXObjectList[i].m_Type == _type)
				{
					GameObject go = Instantiate(m_FXObjectList[i].gameObject) as GameObject;
					fx = go.GetComponent<GamePlayFXObject>();
					break;
				}
			}
		}
		
		//place and play
		Vector3 screenpos = m_GamePlayCamera.WorldToScreenPoint(_worldpos);
		Vector3 newworldpos = m_FXCamera.ScreenToWorldPoint(screenpos);
		
		fx.SetPosition(newworldpos);
		//fx.gameObject.SetActive(true);
		return fx;
	}
	
	public void ReturnFX(GamePlayFXObject _fx)
	{
		_fx.gameObject.SetActive(false);
		m_FX_Unused.Add(_fx);
	}
	#endregion
}
