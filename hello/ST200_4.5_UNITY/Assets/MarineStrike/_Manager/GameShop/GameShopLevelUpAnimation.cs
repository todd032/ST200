using UnityEngine;
using System.Collections;

public class GameShopLevelUpAnimation : MonoBehaviour {

	public UILabel m_TextLabel;
	public TweenScale m_ScaleAnim;

	public void PlayAnim(int _type, int _submarinenumb, int _level)
	{
		gameObject.SetActive(true);
		//type 1 - bullet, 2 - type
		if(_type == 1)
		{			
			GameBalanceDataManager.GameSubmarineBulletInfoBalance bulletcur = Managers.GameBalanceData.GetGameSubmarineBulletInfoBalance( _submarinenumb, _level);
			GameBalanceDataManager.GameSubmarineBulletInfoBalance bulletnext = Managers.GameBalanceData.GetGameSubmarineBulletInfoBalance( _submarinenumb, _level + 1);
			
			m_TextLabel.text = TextManager.Instance.GetReplaceString(166, Mathf.CeilToInt(bulletnext.BulletDamage - bulletcur.BulletDamage).ToString());

		}else if(_type == 2)
		{
			GameBalanceDataManager.GameSubmarineEnergyInfoBalance energybalancecur = Managers.GameBalanceData.GetGameSubmarineEnergyInfoBalance( _submarinenumb, _level);
			GameBalanceDataManager.GameSubmarineEnergyInfoBalance energybalancenext = Managers.GameBalanceData.GetGameSubmarineEnergyInfoBalance( _submarinenumb, _level + 1);
			m_TextLabel.text = TextManager.Instance.GetReplaceString(165, Mathf.CeilToInt(energybalancenext.EnergyAmount/energybalancecur.EnergyAmount * 100f - 100f).ToString());
		}

		StartCoroutine(PlayAnim());
	}

	IEnumerator PlayAnim()
	{
		//m_ScaleAnim.Reset();
		m_ScaleAnim.Play(true);

		float timer = 2f;
		while(timer > 0f)
		{
			timer -= Time.deltaTime;
			yield return null;
		}

		gameObject.SetActive(false);
		yield break;
	}
	                    
}
