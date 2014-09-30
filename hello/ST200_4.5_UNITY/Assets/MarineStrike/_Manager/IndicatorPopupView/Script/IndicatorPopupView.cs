using UnityEngine;
using System.Collections;

public class IndicatorPopupView : MonoBehaviour {

	[HideInInspector]
	public delegate void IndicatorPopupViewDelegate(IndicatorPopupView indicatorPopupView, int state);
	protected IndicatorPopupViewDelegate _indicatorPopupViewDelegate ;
	public event IndicatorPopupViewDelegate IndicatorPopupViewEvent{
		add{
			
			_indicatorPopupViewDelegate = null ;
			
			if (_indicatorPopupViewDelegate == null)
        		_indicatorPopupViewDelegate += value;
        }
		
		remove{
            _indicatorPopupViewDelegate -= value;
		}
	}
	
	public IndicatorIconSprite _indicatorIconSprite ;
	
	
	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	public void InitLoadIndicatorPopupView(){
		NGUITools.SetActive(gameObject, false) ;
		_indicatorIconSprite.InitIndicator() ;
	}
	
	public void LoadIndicatorPopupView() {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetIndicatorPopupView() ;
		
	}
	
	public void RemoveIndicatorPopupView() {
		_indicatorIconSprite.StopIndicator() ;
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetIndicatorPopupView(){
		_indicatorIconSprite.StartIndicator() ;
	}
}
