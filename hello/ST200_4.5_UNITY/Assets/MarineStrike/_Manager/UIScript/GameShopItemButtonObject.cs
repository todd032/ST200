using UnityEngine;
using System.Collections;

public class GameShopItemButtonObject : MonoBehaviour {

	public UISprite m_SelectedSprite;
	public UISprite _itemButtonImageSprite ;
	public UISprite m_ActiveSprite;
	public UISprite m_InActiveSprite;
	public UILabel _itemNumberLabel ;
	
	private Transform _thisTransform ;
	public Transform ThisTransform {
		get { return _thisTransform ; }
	}
	
	private void Awake() {
		
		_thisTransform = transform ;
		
	}

	public void UpdateUI(bool _selected, bool _active, int _itemcount)
	{
		SetSelected(_selected);
		if(_active)
		{
			SetItemNumberLabel(_itemcount - 1);
			NGUITools.SetActive(m_ActiveSprite.gameObject, true);
			NGUITools.SetActive(m_InActiveSprite.gameObject, false);
		}else
		{
			SetItemNumberLabel(_itemcount);
			NGUITools.SetActive(m_ActiveSprite.gameObject, false);
			NGUITools.SetActive(m_InActiveSprite.gameObject, true);
		}
	}

	protected void SetItemNumberLabel(int itemNumber){
		if(_itemNumberLabel != null){
			if(itemNumber > 0)
			{
				NGUITools.SetActive (_itemNumberLabel.gameObject, true);
				_itemNumberLabel.text = itemNumber.ToString() ;	
			}else
			{
				NGUITools.SetActive (_itemNumberLabel.gameObject, false);
			}
		}
	}

	public void SetSelected(bool _selected)
	{
		NGUITools.SetActive(m_SelectedSprite.gameObject, _selected);
	}
}
