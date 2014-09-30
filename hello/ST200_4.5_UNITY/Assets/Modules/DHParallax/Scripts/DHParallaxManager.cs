using UnityEngine;
using System.Collections;

public class DHParallaxManager : MonoBehaviour { //: MonoSingleton<DHParallaxManager>{
    
	/*
	// Public
	public delegate void StageLayerActionDelegate(DHParallaxStageLayer parallaxStageLayer, int parallaxStageLayerTag);
	public StageLayerActionDelegate stageLayerChangeStartDelegate, stageLayerChangeStartEndDelegate, 
									stageLayerStartAllActionDoneDelegate, stageLayerStopAllActionDoneDelegate,
									currentStageLayerStartActionDoneDelegate;
	
	//--
	*/
	
	[HideInInspector]
	public delegate void ParallaxManagerDelegate(string stateString, int state);
	protected ParallaxManagerDelegate _parallaxManagerDelegate ;
	public event ParallaxManagerDelegate ParallaxManagerEvent {
		add{
			
			_parallaxManagerDelegate = null ;
			
			if (_parallaxManagerDelegate == null)
        		_parallaxManagerDelegate += value;
        }
		
		remove{
            _parallaxManagerDelegate -= value;
		}
	}
	
	
	//---
	
	public Transform[] parallaxStageLayerMains ;
	private Transform parallaxStageLayerMain ;
	public Transform parallaxStageLayerFever ;
	
	public Transform feverChangeBg ;
	
	
	//--- Like CookieRun Style.. Don't Implement yet!!
	public bool isStageLayerMode = false ;
	public Transform[] parallaxStageLayers ;
	public Transform stageChangeBg ;
	
	
	public float stageLayerSpeed = 1f ;
	public float feverStageLayerSpeed = 0.5f ;
	//
	
	// Private
	/*private bool isReadyParallaxLayer = false ;*/
	
	private DHParallaxStageLayer currentParallaxStageLayer ;
	private DHParallaxStageLayer.CurrentStageLayerMode currentParallaxStageLayerMode ;
	
	private DHParallaxStageLayer mainParallaxStageLayer ;
	private DHParallaxStageLayer feverParallaxStageLayer ;
	
	private tk2dSprite feverChangeBgSprite ;
	private tk2dSprite stageChangeBgSprite ;
	
	private bool isChangeStageState = false ;
	
	//
	
	/*
	public bool IsReadyParallaxLayer {
		get { return isReadyParallaxLayer ; }
	}
	*/
	
	public DHParallaxStageLayer.CurrentStageLayerMode CurrentParallaxStageLayerMode {
		get { return currentParallaxStageLayer.StageLayerMode ; }
	}
	
	/*
    public override void Init(){
		
		
	}
	*/
	
	/*
	public IEnumerator InitParallaxStageLayer() {
		
		isReadyParallaxLayer = false ;
		
		if(parallaxStageLayerMain != null) {
			Transform selectStageLayerObject = Instantiate(parallaxStageLayerMain) as Transform ;
			mainParallaxStageLayer = selectStageLayerObject.GetComponent<DHParallaxStageLayer>() as DHParallaxStageLayer ;
			currentParallaxStageLayer = mainParallaxStageLayer ;
			currentParallaxStageLayerMode = currentParallaxStageLayer.StageLayerMode ;
		}
		
		if(parallaxStageLayerTop != null) {
			Transform selectStageLayerObject = Instantiate(parallaxStageLayerTop) as Transform ;
			topParallaxStageLayer = selectStageLayerObject.GetComponent<DHParallaxStageLayer>() as DHParallaxStageLayer ;
		}
		
		if(parallaxStageLayerBottom != null) {
			Transform selectStageLayerObject = Instantiate(parallaxStageLayerBottom) as Transform ;
			bottomParallaxStageLayer = selectStageLayerObject.GetComponent<DHParallaxStageLayer>() as DHParallaxStageLayer ;
		}
		
		if(parallaxStageLayerFever != null) {
			Transform selectStageLayerObject = Instantiate(parallaxStageLayerFever) as Transform ;
			feverParallaxStageLayer = selectStageLayerObject.GetComponent<DHParallaxStageLayer>() as DHParallaxStageLayer ;
		}
		
		//--
		if(feverChangeBg != null) {
			Transform selectChangeBgObject = Instantiate(feverChangeBg) as Transform ;
			feverChangeBgSprite = selectChangeBgObject.GetComponent<tk2dSprite>() as tk2dSprite ;
			feverChangeBgSprite.gameObject.SetActive(false) ;
			
		}
		
		if(stageChangeBg != null) {
			Transform selectChangeBgObject = Instantiate(stageChangeBg) as Transform ;
			stageChangeBgSprite = selectChangeBgObject.GetComponent<tk2dSprite>() as tk2dSprite ;
			stageChangeBgSprite.gameObject.SetActive(false) ;
		}
		
		
		yield return null ;
		
		isReadyParallaxLayer = true ;
		
	}
	*/
	
	void Awake() {
		
		//if(parallaxStageLayerMain != null) {
		if(parallaxStageLayerMains.Length > 0) {
			int randomSelectStageLayerMainIndex = Random.Range(0,parallaxStageLayerMains.Length) ;

			// 테스트용 - BG 를 고정.
//			randomSelectStageLayerMainIndex = 2;

			Transform selectStageLayerObject = Instantiate(parallaxStageLayerMains[randomSelectStageLayerMainIndex]) as Transform ;
			//Transform selectStageLayerObject = Instantiate(parallaxStageLayerMain) as Transform ;
			mainParallaxStageLayer = selectStageLayerObject.GetComponent<DHParallaxStageLayer>() as DHParallaxStageLayer ;
			currentParallaxStageLayer = mainParallaxStageLayer ;
			currentParallaxStageLayerMode = currentParallaxStageLayer.StageLayerMode ;
		}
		
		if(parallaxStageLayerFever != null) {
			Transform selectStageLayerObject = Instantiate(parallaxStageLayerFever) as Transform ;
			feverParallaxStageLayer = selectStageLayerObject.GetComponent<DHParallaxStageLayer>() as DHParallaxStageLayer ;
			feverParallaxStageLayer.SetActiveStageLayer(false) ;
		}
		
		//--
		if(feverChangeBg != null) {
			Transform selectChangeBgObject = Instantiate(feverChangeBg) as Transform ;
			feverChangeBgSprite = selectChangeBgObject.GetComponent<tk2dSprite>() as tk2dSprite ;
			feverChangeBgSprite.gameObject.SetActive(false) ;
			
		}
		
		if(stageChangeBg != null) {
			Transform selectChangeBgObject = Instantiate(stageChangeBg) as Transform ;
			stageChangeBgSprite = selectChangeBgObject.GetComponent<tk2dSprite>() as tk2dSprite ;
			stageChangeBgSprite.gameObject.SetActive(false) ;
		}

	}
	
	
	//--- Init
	public void InitSettingMainStageLayer(float layerSpeed){
		if(mainParallaxStageLayer != null) {
			mainParallaxStageLayer.ChangeSpeedStageLayer(layerSpeed) ;
		}
	}
	
	//--- Move Stage Control
	public void StartCurrentStageLayer() {
		
		currentParallaxStageLayer.StartStageLayer() ;
		
		/*
		if(currentStageLayerStartActionDoneDelegate != null){
			currentStageLayerStartActionDoneDelegate(currentParallaxStageLayer, 1) ;
		}
		*/
		
	}
	
	public void StopCurrentStageLayer() {
		
		currentParallaxStageLayer.StopStageLayer() ;
		
		/*
		if(currentStageLayerStartActionDoneDelegate != null) {
			currentStageLayerStartActionDoneDelegate(currentParallaxStageLayer, 1) ;
		}
		*/
		
	}
	
	public void ChangeSpeedStageLayer(float layerSpeed) {
	
		layerSpeed = layerSpeed + 1f; // 테스트용으로 BG 스크롤 속도 강제 조절.

//		Debug.Log ("DHParallaxManager.ChangeSpeedStageLayer.layerSpeed = " + layerSpeed);

		if(mainParallaxStageLayer != null) {
			mainParallaxStageLayer.ChangeSpeedStageLayer(layerSpeed) ;
		}
		
		/*
		if(feverParallaxStageLayer != null) {
			feverParallaxStageLayer.ChangeSpeedStageLayer(layerSpeed+2f) ;
		}
		*/
		
		/*
		if(currentStageLayerStartActionDoneDelegate != null){
			currentStageLayerStartActionDoneDelegate(currentParallaxStageLayer, 1) ;
		}
		*/
		
	}
	
	public void ChangeSpeedFeverStageLayer(float layerSpeed) {
		
		if(feverParallaxStageLayer != null) {
			feverParallaxStageLayer.ChangeSpeedStageLayer(layerSpeed) ;
		}
		
	}
	
	public void StartAllStageLayer() {
		
		if(mainParallaxStageLayer != null) {
			mainParallaxStageLayer.StartStageLayer() ;
		}
		
		if(feverParallaxStageLayer != null) {
			feverParallaxStageLayer.StartStageLayer() ;
		}
		
		/*
		if(stageLayerStartAllActionDoneDelegate != null) {
			stageLayerStartAllActionDoneDelegate(currentParallaxStageLayer, 1) ;
		}
		*/
		
	}
	
	public void StopAllStageLayer() {
		
		if(mainParallaxStageLayer != null) {
			mainParallaxStageLayer.StopStageLayer() ;
		}
		
		if(feverParallaxStageLayer != null) {
			feverParallaxStageLayer.StopStageLayer() ;
		}
		
		/*
		if(stageLayerStopAllActionDoneDelegate != null) {
			stageLayerStopAllActionDoneDelegate(currentParallaxStageLayer, 1) ;
		}
		*/
		
	}
	
	
	
	//--- Change Stage Control
	//-------------------
	public IEnumerator ChangeStageFromMainToFever(float changeFadeInSec, float changeDelaySec, float changeFadeOutSec) {
		// FadeIn/FadeOut
		
		//---
		if((currentParallaxStageLayerMode != DHParallaxStageLayer.CurrentStageLayerMode.MAIN) || isChangeStageState ) {
			yield break ;	
		}
		
			
		//---
		feverChangeBgSprite.gameObject.SetActive(true) ;
		isChangeStageState = true ;
		
		yield return null ;
		
		// Start Fade In
		bool isFadeInDone = false ;
		float remainSeconds = 0.0f;
		
		while(!isFadeInDone) {
			
			remainSeconds += Time.deltaTime; 
	
			Color changeAlphaColor = feverChangeBgSprite.color;
			changeAlphaColor.a  = remainSeconds / changeFadeInSec;
	
			if(changeAlphaColor.a >= 1f) {
				changeAlphaColor.a = 1f ;
				isFadeInDone = true ;
			}
			
			feverChangeBgSprite.color  = changeAlphaColor;
			
			yield return null ;
		}
		
		// Delay
		yield return new WaitForSeconds(changeDelaySec * 0.5f);
		
		// Change Stage..
		if(mainParallaxStageLayer != null && feverParallaxStageLayer != null) {
			
			//feverParallaxStageLayer.gameObject.SetActive(true) ;
			feverParallaxStageLayer.SetActiveStageLayer(true) ;
			feverParallaxStageLayer.StartStageLayer() ;
			currentParallaxStageLayer = feverParallaxStageLayer ;
			currentParallaxStageLayerMode = currentParallaxStageLayer.StageLayerMode ;
		
			mainParallaxStageLayer.StopStageLayer() ;
			//yield return null ;
			//mainParallaxStageLayer.gameObject.SetActive(false) ;
			mainParallaxStageLayer.SetActiveStageLayer(false) ;
			
		}
		
		yield return new WaitForSeconds(changeDelaySec * 0.5f);
		
		// Start Fade Out
		bool isFadeOutDone = false ;
		remainSeconds = 0.0f ;
		
		while(!isFadeOutDone) {
			
			remainSeconds += Time.deltaTime; 
			
			Color changeAlphaColor = feverChangeBgSprite.color;
			changeAlphaColor.a  = 1.0f - (remainSeconds / changeFadeOutSec) ;
	
			if(changeAlphaColor.a <= 0f) {
				changeAlphaColor.a = 0f ;
				isFadeOutDone = true ;
			}
			
			feverChangeBgSprite.color  = changeAlphaColor;
			
			yield return null ;
		}
		
		yield return null ;
		
		if(_parallaxManagerDelegate != null){
			_parallaxManagerDelegate("StartFeverMode",1) ;
		}
		
		isChangeStageState = false ;
		feverChangeBgSprite.gameObject.SetActive(false) ;
		
	}
	
	public IEnumerator ChangeStageFromFeverToMain(float changeFadeInSec, float changeDelaySec, float changeFadeOutSec) {
		// FadeIn/FadeOut
		
		if((currentParallaxStageLayerMode != DHParallaxStageLayer.CurrentStageLayerMode.FEVER) || isChangeStageState) {
			yield break ;	
		}
		
		//---
		feverChangeBgSprite.gameObject.SetActive(true) ;
		isChangeStageState = true ;
		
		yield return null ;
		
		// Start Fade In
		bool isFadeInDone = false ;
		float remainSeconds = 0.0f;
		
		while(!isFadeInDone) {
			
			remainSeconds += Time.deltaTime; 
	
			Color changeAlphaColor = feverChangeBgSprite.color;
			changeAlphaColor.a = remainSeconds / changeFadeInSec;
	
			if(changeAlphaColor.a >= 1f) {
				changeAlphaColor.a = 1f ;
				isFadeInDone = true ;
			}
			
			feverChangeBgSprite.color  = changeAlphaColor;
			
			yield return null ;
		}
		
		
		// Delay
		yield return new WaitForSeconds(changeDelaySec * 0.5f);
		
		// Change Stage..
		if(mainParallaxStageLayer != null && feverParallaxStageLayer != null) {
			
			//mainParallaxStageLayer.gameObject.SetActive(true) ;
			mainParallaxStageLayer.SetActiveStageLayer(true) ;
			mainParallaxStageLayer.StartStageLayer() ;
			currentParallaxStageLayer = mainParallaxStageLayer ;
			currentParallaxStageLayerMode = currentParallaxStageLayer.StageLayerMode ;
			
			feverParallaxStageLayer.StopStageLayer() ;
			//yield return StartCoroutine(feverParallaxStageLayer.ResetStageLayer()) ;
			feverParallaxStageLayer.ResetStageLayer() ;
			//feverParallaxStageLayer.gameObject.SetActive(false) ;
			feverParallaxStageLayer.SetActiveStageLayer(false) ;
			
		}
		
		yield return new WaitForSeconds(changeDelaySec * 0.5f);

		// Start Fade Out
		bool isFadeOutDone = false ;
		remainSeconds = 0.0f ;
		
		while(!isFadeOutDone) {
			
			remainSeconds += Time.deltaTime;
			
			Color changeAlphaColor = feverChangeBgSprite.color;
			changeAlphaColor.a  = 1.0f - (remainSeconds / changeFadeOutSec);
	
			if(changeAlphaColor.a <= 0f) {
				changeAlphaColor.a = 0f ;
				isFadeOutDone = true ;
			}
			
			feverChangeBgSprite.color  = changeAlphaColor;
			
			yield return null ;
		}
		
		yield return null ;
		
		if(_parallaxManagerDelegate != null){
			_parallaxManagerDelegate("StartMainMode",2) ;	
		}
		
		isChangeStageState = false ;
		feverChangeBgSprite.gameObject.SetActive(false) ;
	}
	
}
