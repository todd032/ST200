using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DHParallaxStageLayer : MonoBehaviour {
	
	// Public 
	public enum CurrentStageLayerMode {NONE, MAIN, CENTER, FEVER, CUSTOM} ;
	public CurrentStageLayerMode stageLayerMode = CurrentStageLayerMode.NONE ;
	public Vector3 CurrentStageLayerCustomPosition ;
	
	public Transform[] parallaxLayers ;
	public int mainParallaxLayerIndex ;
	
	public bool autoParallaxLayerMoveSpeed ;
	public bool autoParallaxLayerMoveSpeedSetting ;
	public float mainParallaxLayerMoveSpeed ; // autoParallaxLayerMoveSpeedSetting == ture working...
	
	
	// Private
	private GameObject thisGameObject ;
	private Transform mainCameraTransform ;
	private Transform thisTransform ;
//	private Vector2 screenSize ; //Warning never used..
	
	private List<DHParallaxLayer> parallaxLayersList ;
	private DHParallaxLayer mainParallaxLayer ;
	//
	
	public CurrentStageLayerMode StageLayerMode {
		get { return stageLayerMode ; }
	}
	
	void Awake() {
		
		thisGameObject = gameObject ; // caching this object GameObject component.
		
		mainCameraTransform = Camera.main.transform ;
		thisTransform = transform ; // caching this object Transfrom component.
		
		
		/* //Warning never used..
		float screenSizeHeight = 2f * Camera.main.orthographicSize;
		float screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		screenSize = new Vector2(screenSizeWidth, screenSizeHeight) ;
		*/
		
		
		parallaxLayersList = new List<DHParallaxLayer>(parallaxLayers.Length) ;
		
		if(parallaxLayers.Length >= mainParallaxLayerIndex) {
			mainParallaxLayerIndex = 0 ;
		}
	
		//
		CreateStageLayer() ;
		
	}
	
	
	// Use this for initialization
	void Start () {

	}
	
	
	void CreateStageLayer() {
		
		for(int i = 0 ; i < parallaxLayers.Length ; i++) {
			
			Transform selectLayerObject = Instantiate(parallaxLayers[i]) as Transform ;
			
			if(selectLayerObject != null) {
				
				DHParallaxLayer selectLayer = selectLayerObject.GetComponent<DHParallaxLayer>() as DHParallaxLayer ;
				
				parallaxLayersList.Add (selectLayer); ///
				
				if(mainParallaxLayerIndex == i) {
					mainParallaxLayer = selectLayer ;
				}
				
				float selectLayerObjectPositionZ = selectLayerObject.localPosition.z ; //Storing selectLayerObject Z position Before change selectLayerObject child Object..
				selectLayerObject.parent = thisTransform ;
				selectLayerObject.localPosition = new Vector3(selectLayerObject.localPosition.x, selectLayerObject.localPosition.y, thisTransform.position.z + selectLayerObjectPositionZ) ;
			}
			
		}
		
		SettingCurrentStateLayerPosition() ;
		
	}
	
	
	void SettingCurrentStateLayerPosition() {
		
		
		if(stageLayerMode == CurrentStageLayerMode.NONE) {
			
		}else if(stageLayerMode == CurrentStageLayerMode.MAIN || stageLayerMode == CurrentStageLayerMode.CENTER) {
			thisTransform.localPosition = new Vector3(mainCameraTransform.position.x, mainCameraTransform.position.y , thisTransform.localPosition.z) ;
		}else if(stageLayerMode == CurrentStageLayerMode.FEVER) {
			thisTransform.localPosition = new Vector3(mainCameraTransform.position.x, mainCameraTransform.position.y , thisTransform.localPosition.z) ;
		}
		
		if(stageLayerMode != CurrentStageLayerMode.MAIN) {
			SetActiveStageLayer(false) ;
		}
		
	}
	
	public void StartStageLayer() {
		
		for(int i = 0 ; i < parallaxLayersList.Count ; i++) {
			
			DHParallaxLayer selectLayer = parallaxLayersList[i] as DHParallaxLayer ;
			selectLayer.IsMove = true ;
			
		}
	}
	
	public void StopStageLayer() {
		
		for(int i = 0 ; i < parallaxLayersList.Count ; i++) {
			
			DHParallaxLayer selectLayer = parallaxLayersList[i] as DHParallaxLayer ;
			selectLayer.IsMove = false ;
			
		}
	}
	
	public void ChangeSpeedStageLayer(float changeSpeed) {
		
		float baseSpeed = mainParallaxLayer.CurrentLayerMoveSpeed ;
		
		for(int i = 0 ; i < parallaxLayersList.Count ; i++) {
			
			DHParallaxLayer selectLayer = parallaxLayersList[i] as DHParallaxLayer ;
			selectLayer.CurrentLayerMoveSpeed = (selectLayer.CurrentLayerMoveSpeed*changeSpeed)/baseSpeed ;

		}
	}
	
	//public IEnumerator ResetStageLayer() {
	public void ResetStageLayer() {
		
		for(int i = 0 ; i < parallaxLayersList.Count ; i++) {
			
			DHParallaxLayer selectLayer = parallaxLayersList[i] as DHParallaxLayer ;
			selectLayer.IsMove = false ;
			//yield return StartCoroutine(selectLayer.ResetParallaxLayer()) ;
			//StartCoroutine(selectLayer.ResetParallaxLayer()) ;
			selectLayer.ResetParallaxLayer() ;
			
		}
	}
	
	public void SetActiveStageLayer(bool isActive) {
		thisGameObject.SetActive(isActive) ;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	//------------------------
	public void TranslateParallaxStageLayer(Vector3 directionVector, float moveSpeed) {
		
		thisTransform.Translate(directionVector * moveSpeed, Space.World) ;
		
	}
	
}
