using UnityEngine;
using System.Collections;

public class DHParallaxBackgroundPanel : DHParallaxPanel {
	
	//Public ----------
	//------ Start
	public GameObject[] startBackgroundObejct ; //Sequence
	//------
	
	//------ Middle
	public GameObject[] middleBackgroundObejct ;
	public int numberOfCreateObject ; // Number of create rolling Object.
	
	public bool isMakeRandomSprite = true ; // if(currentPanelModeType == CurrentPanelModeType.BACKGROUND_SCROLL) isMakeRandomSprite = false ;
	
	//------ End
	public GameObject[] endBackgroundObejct ; //Sequence
	//------
	
	public float betweenGap ; 
	
	//public enum PaddingType {TOP, CENTER, BOTTOM, LEFT_TOP, LEFT_BOTTOM} ;
	//public PaddingType paddingType = PaddingType.LEFT_BOTTOM;
	//public float paddingTopValue ; // Don't Use yet!!
	public float paddingBottomValue ; // Don't Use yet!!
	public float paddingLeftValue ; // Don't Use yet!!
	//public float paddingRightValue ; // Don't Use yet!!
	//------
	
	
	// private ----------
	private float nextSelectObjectPositionValue ;
	
	
	protected override void Awake() {
		
		base.Awake() ;
		createPanelObject() ;
		
	}
	
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
	
		ParallaxPanelMoveModule() ;
		
	}
	
	void LateUpdate() {
		CheckPanelState() ;
	}
	
	//-------------------
	protected override void createPanelObject() {
	//-------- Start Background
		if(startBackgroundObejct.Length > 0) {
			
			for(int i = 0 ; i < startBackgroundObejct.Length ; i++) {
				
				int selectObejctIndex = i % startBackgroundObejct.Length ;
				
				GameObject selectObejct = Instantiate(startBackgroundObejct[selectObejctIndex]) as GameObject;
				selectObejct.renderer.enabled = false;
				
				tk2dSprite selectObejctSprite = selectObejct.GetComponent<tk2dSprite>() as tk2dSprite;
				
				float selectObejctSpriteWidth = selectObejctSprite.GetUntrimmedBounds().extents.x ;
				float selectObejctSpriteHeight = selectObejctSprite.GetUntrimmedBounds().extents.y ;
				float selectObejctSpriteCenterX = selectObejctSprite.GetUntrimmedBounds().center.x ;
				float selectObejctSpriteCenterY = selectObejctSprite.GetUntrimmedBounds().center.y ;
				
				Vector3 selectObjectReposition = Vector3.zero;
				
				if(selectObejctSprite != null) {
					
					
					selectObjectReposition = new Vector3(nextSelectObjectPositionValue + selectObejctSpriteWidth - selectObejctSpriteCenterX - (screenSizeWidth/2) + paddingLeftValue , 
								                        //selectObejctSpriteHeight - selectObejctSpriteCenterY - (screenSizeHeight/2) + paddingBottomValue, 
														selectObejctSpriteHeight - selectObejctSpriteCenterY - (screenSizeHeight/2) + paddingBottomValue + ((screenSizeHeight*0.5f) - 1f) ,
								                         (0.001f*i)) ;
						
					nextSelectObjectPositionValue += ((selectObejctSpriteWidth * 2) + betweenGap) ;
					panelSize.x = nextSelectObjectPositionValue ;
						
					if(panelSize.y < (selectObejctSpriteHeight * 2)) {
						panelSize.y = (selectObejctSpriteHeight * 2) ;
					}
					
					
					selectObejct.transform.parent = thisTransform ;
					selectObejct.transform.localPosition = selectObjectReposition ;
					selectObejct.renderer.enabled = true;
					
				}
				
			}
			
		}
		//--------
		
		
		//-------- Middle Background
		if(middleBackgroundObejct.Length > 0) {
			
			if(numberOfCreateObject == 0) {
				numberOfCreateObject = 1 ;
			}
			
			for(int i = 0 ; i < numberOfCreateObject ; i++) {
				
				int selectObejctIndex = 0 ;
				
				if(isMakeRandomSprite) { // isMakeRandomSprite Option!!
					selectObejctIndex = Random.Range(0,middleBackgroundObejct.Length) ;
				}else {
					selectObejctIndex = i % middleBackgroundObejct.Length ;
				}
				
				GameObject selectObejct = Instantiate(middleBackgroundObejct[selectObejctIndex]) as GameObject;
				selectObejct.renderer.enabled = false;
				
				tk2dSprite selectObejctSprite = selectObejct.GetComponent<tk2dSprite>() as tk2dSprite;
				
				float selectObejctSpriteWidth = selectObejctSprite.GetUntrimmedBounds().extents.x ;
				float selectObejctSpriteHeight = selectObejctSprite.GetUntrimmedBounds().extents.y ;
				float selectObejctSpriteCenterX = selectObejctSprite.GetUntrimmedBounds().center.x ;
				float selectObejctSpriteCenterY = selectObejctSprite.GetUntrimmedBounds().center.y ;
				
				Vector3 selectObjectReposition = Vector3.zero;
				
				if(selectObejctSprite != null) {
					
					selectObjectReposition = new Vector3(nextSelectObjectPositionValue + selectObejctSpriteWidth - selectObejctSpriteCenterX - (screenSizeWidth/2) + paddingLeftValue , 
								                         //selectObejctSpriteHeight - selectObejctSpriteCenterY - (screenSizeHeight/2) + paddingBottomValue ,
														selectObejctSpriteHeight - selectObejctSpriteCenterY - (screenSizeHeight/2) + paddingBottomValue + ((screenSizeHeight*0.5f) - 1f),
								                         (0.001f*i)) ;
						
					nextSelectObjectPositionValue += ((selectObejctSpriteWidth * 2) + betweenGap) ;
					panelSize.x = nextSelectObjectPositionValue ;
						
					if(panelSize.y < (selectObejctSpriteHeight * 2)) {
						panelSize.y = (selectObejctSpriteHeight * 2) ;
					}
					
					selectObejct.transform.parent = thisTransform ;
					selectObejct.transform.localPosition = selectObjectReposition ;
					selectObejct.renderer.enabled = true;
					
				}
				
			}
			
		}
		
		
		//-------- End Background
		if(endBackgroundObejct.Length > 0) {
			for(int i = 0 ; i < endBackgroundObejct.Length ; i++) {
				
				int selectObejctIndex = i % endBackgroundObejct.Length ;
				
				GameObject selectObejct = Instantiate(endBackgroundObejct[selectObejctIndex]) as GameObject;
				selectObejct.renderer.enabled = false;
				
				tk2dSprite selectObejctSprite = selectObejct.GetComponent<tk2dSprite>() as tk2dSprite;
				
				float selectObejctSpriteWidth = selectObejctSprite.GetUntrimmedBounds().extents.x ;
				float selectObejctSpriteHeight = selectObejctSprite.GetUntrimmedBounds().extents.y ;
				float selectObejctSpriteCenterX = selectObejctSprite.GetUntrimmedBounds().center.x ;
				float selectObejctSpriteCenterY = selectObejctSprite.GetUntrimmedBounds().center.y ;
				
				Vector3 selectObjectReposition = Vector3.zero;
				
				if(selectObejctSprite != null) {
					
					selectObjectReposition = new Vector3(nextSelectObjectPositionValue + selectObejctSpriteWidth - selectObejctSpriteCenterX - (screenSizeWidth/2) + paddingLeftValue , 
								                         //selectObejctSpriteHeight - selectObejctSpriteCenterY - (screenSizeHeight/2) + paddingBottomValue, 
														selectObejctSpriteHeight - selectObejctSpriteCenterY - (screenSizeHeight/2) + paddingBottomValue + ((screenSizeHeight*0.5f) - 1f) ,
								                         (0.001f*i)) ;
						
					nextSelectObjectPositionValue += ((selectObejctSpriteWidth * 2) + betweenGap) ;
					panelSize.x = nextSelectObjectPositionValue ;
						
					if(panelSize.y < (selectObejctSpriteHeight * 2)) {
						panelSize.y = (selectObejctSpriteHeight * 2) ;
					}
					
					selectObejct.transform.parent = thisTransform ;
					selectObejct.transform.localPosition = selectObjectReposition ;
					selectObejct.renderer.enabled = true;
					
				}
				
			}
			
		}
		//--------	
		
		panelSize.x -= betweenGap ;
		
	}
	
}
