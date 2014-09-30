using UnityEngine;
using System.Collections;

public class NoticeNEventIndicatorView : MonoBehaviour {

	public NoticeNEventIndicatorViewIconSprite _indicatorIconSprite ;
	
	
	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	public void InitLoadNoticeNEventIndicatorView(){
		NGUITools.SetActive(gameObject, false) ;
		_indicatorIconSprite.InitIndicator() ;
	}
	
	public void LoadNoticeNEventIndicatorView() {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetNoticeNEventIndicatorView() ;
		
	}
	
	public void RemoveNoticeNEventIndicatorView() {
		_indicatorIconSprite.StopIndicator() ;
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetNoticeNEventIndicatorView(){
		_indicatorIconSprite.StartIndicator() ;
	}
	
	
}
