using UnityEngine;
using System.Collections;

public class ItemButtonSelectorSpriteObject : MonoBehaviour {
	
	private Transform _thisTransform ;
	public Transform ThisTransform {
		get { return _thisTransform ; }
	}

	public UITweener m_Tweener;

	private void Awake(){
		
		_thisTransform = transform ;
		
	}
	
	
	// Use this for initialization
	private void Start () {
	
	}

	public void SetItemButtonSelectorSpritePosition(Vector3 selectPosition) {
		if(selectPosition != null && _thisTransform != null)
		{
			_thisTransform.position = selectPosition ;
			if(m_Tweener != null)
			{
				//m_Tweener.Reset();
				m_Tweener.Play(true);
			}
		}
	}
	
}
