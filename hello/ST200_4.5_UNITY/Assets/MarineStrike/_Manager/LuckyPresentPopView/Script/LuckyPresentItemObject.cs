using UnityEngine;
using System.Collections;

public class LuckyPresentItemObject : MonoBehaviour {

	public GameObject m_ItemGameObject;
	public UISprite m_ItemImage;
	public UILabel m_ItemLabel;
	public TweenScale m_EffectSprite;
	public GameObject m_EffectSprite2;
	public ParticleSystem m_EffectParticle;

	public TweenAlpha m_PresentAlphaAnim;
	public UISprite m_PresentImage;

	private bool m_ClickedFlag = false;
	private LuckyPresentPopupView m_PopUpView;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset(LuckyPresentPopupView _view)
	{
		m_PopUpView = _view;
		m_ClickedFlag = false;
		m_ItemGameObject.gameObject.SetActive(false);
		m_EffectSprite.gameObject.SetActive(false);
		m_EffectSprite2.gameObject.SetActive (false);
		//m_PresentAlphaAnim.Reset();
	}

	public void StartShowAnim(int _itemtype, int _amount, bool _chosen)
	{
		m_ClickedFlag = true;
		StartCoroutine(IEStartShowAnim(_itemtype, _amount, _chosen));
	}

	private IEnumerator IEStartShowAnim(int _itemtype, int _amount, bool _chosen)
	{
		m_ItemImage.spriteName = Managers.GameBalanceData.GetItemImageName(_itemtype);
		m_ItemImage.MakePixelPerfect();

		m_ItemLabel.text = Managers.GameBalanceData.GetItemAmount(_itemtype, _amount);

		//m_PresentAlphaAnim.Reset();
		m_PresentAlphaAnim.Play (true);

		if(_chosen)
		{
			//m_EffectSprite.Reset();
			m_EffectSprite.gameObject.SetActive(true);
			m_EffectSprite2.gameObject.SetActive(true);

			m_EffectSprite.Play(true);

			m_EffectParticle.playOnAwake = true;
			//m_EffectParticle.Emit(25);
			m_EffectParticle.Play(true);
		}

		while(m_PresentAlphaAnim.tweenFactor < 0.8f)
		{
			yield return null;
		}

		m_ItemGameObject.SetActive(true);
		m_EffectParticle.playOnAwake = false;
		yield break;
	}

	public void OnClickPresent()
	{
		if(!m_ClickedFlag)
		{
			if ( Managers.Audio != null) Managers.Audio.PlayFXSound(AudioManager.FX_SOUND.FX_LuckyPresent_Open,false);
			m_ClickedFlag = true;
			m_PopUpView.OnClickPresentItem(this);
		}
	}
}
