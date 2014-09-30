using UnityEngine;
using System.Collections;

public class DHParallaxObjectPanel : DHParallaxPanel {
	
	
	public bool useFullScreen = true ; // if(currentPanelModeType == CurrentPanelModeType.USER_CUSTOM_SCROLL) useFullScreen = true false!!
	public bool isOverScreenSizeOnce = true ;
	
	public GameObject[] spriteObejct ; // if(currentPanelModeType == CurrentPanelModeType.BACKGROUND_SCROLL) spriteObejct is one.
	public int numberOfCreateObject ; // Number of create rolling Object.  // if(currentPanelModeType == CurrentPanelModeType.BACKGROUND_SCROLL) numberOfCreateObject = 1 ;
	
	
	//------ CurrentPanelModeType OBJECT_SCROLL
	public bool isMakeRandomSprite = true ; // if(currentPanelModeType == CurrentPanelModeType.BACKGROUND_SCROLL) isMakeRandomSprite = false ;
	public bool isRandomPosition = false ; // Create rolling object random position. // Required useFullScreen==true. if (userFullScreen == false) isRandomPosition = false force!!.. 
	
	public Vector3 minGap , maxGap; // if(currentPanelModeType == CurrentPanelModeType.OBJECT_SCROLL) Work...
	
	public enum PaddingType {TOP, CENTER, BOTTOM, LEFT_TOP, LEFT_BOTTOM} ;
	public PaddingType paddingType = PaddingType.LEFT_BOTTOM;
	public float paddingTopValue ; // Don't Use yet!!
	public float paddingBottomValue ; // Don't Use yet!!
	public float paddingLeftValue ; // Don't Use yet!!
	public float paddingRightValue ; // Don't Use yet!!
	//------

	private float nextSelectObjectPositionValue ;

	//
	
	protected override void Awake() {
		
		base.Awake() ;
		
		if(useFullScreen) { // check auto full screen option.
			
			panelSize.x = screenSizeWidth ;
			panelSize.y = screenSizeHeight ;
			
		}else {
			
			isOverScreenSizeOnce = false ; //Don't use isOverScreenSizeOnce Option if useFullScreen is false ..
			
			if(isRandomPosition) {
				// Do Init currentPanelCreateMode value and minGap, maxGap, paddingType if isRandomPosition is false
				minGap = Vector3.zero ;
				maxGap = Vector3.zero ;
				paddingType = PaddingType.LEFT_BOTTOM ;
			}
			
			// Don't use sprite random position if useFullScreen is false ..
			isRandomPosition = false ;
			
		}
		
		//
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
		if(spriteObejct.Length > 0) {
			
			if(numberOfCreateObject == 0) {
				//numberOfCreateObject = spriteObejct.Length ;
				numberOfCreateObject = 1 ;
			}
			
			for(int i = 0 ; i < numberOfCreateObject ; i++) {
				
				int selectObejctIndex = 0 ;
				
				if(isMakeRandomSprite) { // isMakeRandomSprite Option!!
					selectObejctIndex = Random.Range(0,spriteObejct.Length) ;
				}else {
					selectObejctIndex = i % spriteObejct.Length ;
				}
				
				GameObject randomSelectObejct = Instantiate(spriteObejct[selectObejctIndex]) as GameObject;
				randomSelectObejct.renderer.enabled = false;
				
				tk2dSprite randomSelectObejctSprite = randomSelectObejct.GetComponent<tk2dSprite>() as tk2dSprite;
				
				float randomSelectObejctSpriteWidth = randomSelectObejctSprite.GetBounds().extents.x ;//(randomSelectObejctSprite.GetBounds().center.x + randomSelectObejctSprite.GetBounds().extents.x) ;
				float randomSelectObejctSpriteHeight = randomSelectObejctSprite.GetBounds().extents.y ; //(randomSelectObejctSprite.GetBounds().center.y + randomSelectObejctSprite.GetBounds().extents.y) ;
				float randomSelectObejctSpriteCenterX = randomSelectObejctSprite.GetBounds().center.x ;
				float randomSelectObejctSpriteCenterY = randomSelectObejctSprite.GetBounds().center.y ;
				
				//GameObject randomSelectObejct = null;	
				if(isRandomPosition) {
					//
					if(randomSelectObejctSprite != null) {
						
						Vector3 randomSelectObjectRepositon = new Vector3(Random.Range(-(screenSizeWidth*0.5f),(screenSizeWidth*0.5f)) , 
						                                                  Random.Range(-(screenSizeHeight*0.5f),(screenSizeHeight*0.5f)) ,
						                                                  (0.01f*i)) ;
						
						randomSelectObejct.transform.parent = thisTransform ;
						randomSelectObejct.transform.localPosition = randomSelectObjectRepositon ;
					}
					//
					
				}else{
					
					Vector3 randomSelectObjectRepositon = Vector3.zero; //new Vector3(0f,0f,0f);
					
					//
					if(randomSelectObejctSprite != null) {
						
						if(paddingType == PaddingType.LEFT_BOTTOM) {
							
							float betweenGapX = Random.Range(minGap.x,maxGap.x) ;
							float betweenGapY = Random.Range(minGap.y,maxGap.y) ;
							
							randomSelectObjectRepositon = new Vector3(nextSelectObjectPositionValue + randomSelectObejctSpriteWidth - randomSelectObejctSpriteCenterX - (screenSizeWidth*0.5f) + betweenGapX, 
								                                      randomSelectObejctSpriteHeight - randomSelectObejctSpriteCenterY - (screenSizeHeight*0.5f) + betweenGapY , 
								                                      (0.001f*i)) ;
								
								
							nextSelectObjectPositionValue += ((randomSelectObejctSpriteWidth * 2) + betweenGapX) ;
								
							if(useFullScreen) { // check auto full screen option.
									
								if(nextSelectObjectPositionValue > screenSizeWidth) {
										
									if(isOverScreenSizeOnce) {
											
										panelSize.x = nextSelectObjectPositionValue ;
										randomSelectObejct.transform.parent = thisTransform ;
										randomSelectObejct.transform.localPosition = randomSelectObjectRepositon ;
										randomSelectObejct.renderer.enabled = true;
											
									}else{
										DestroyObject(randomSelectObejct) ;
									}
										
									break ;
								}
									
							}else{
								panelSize.x = nextSelectObjectPositionValue ;
							}
							
						}else if(paddingType == PaddingType.TOP) {
							
						}else if(paddingType == PaddingType.CENTER) {
							
						}else if(paddingType == PaddingType.BOTTOM) {
							
						}else if(paddingType == PaddingType.LEFT_TOP) {
							
						}
						
						randomSelectObejct.transform.parent = thisTransform ;
						randomSelectObejct.transform.localPosition = randomSelectObjectRepositon ;
						randomSelectObejct.renderer.enabled = true;
					}
					//
				}	
			}
		}
	}
	
	
}