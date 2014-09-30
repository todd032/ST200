using UnityEngine;
using System.Collections;

public class RankingIndicatorView : MonoBehaviour {

	public RankingIndicatorViewIconSprite _indicatorIconSprite ;
	
	
	private void Awake() {
		
	}
	
	private void Start() {
		
	}
	
	private void Update() {
		
	}
	
	
	public void InitLoadRankingIndicatorView(){
		NGUITools.SetActive(gameObject, false) ;
		_indicatorIconSprite.InitIndicator() ;
	}
	
	public void LoadRankingIndicatorView() {
		
		NGUITools.SetActive(gameObject, true) ;
		
		SetRankingIndicatorView() ;
		
	}
	
	public void RemoveRankingIndicatorView() {
		_indicatorIconSprite.StopIndicator() ;
		NGUITools.SetActive(gameObject, false) ;
	}
	
	private void SetRankingIndicatorView(){
		_indicatorIconSprite.StartIndicator() ;
	}
	
}
