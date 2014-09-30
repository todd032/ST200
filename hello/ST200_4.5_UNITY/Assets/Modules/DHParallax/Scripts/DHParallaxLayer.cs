using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DHParallaxLayer : MonoBehaviour {
	
	//public enum CurrentLayerMode {SEQUENTIAL, RANDOM} ;
	//public CurrentLayerMode currentLayerMode = CurrentLayerMode.RANDOM ;
	
	public float currentLayerMoveSpeed ;
	
	//------ Start Panel Option
	public Transform[] parallaxStartPanels ; //Sequence
	//------
	
	//------ Rolling Panel Option
	public Transform[] parallaxRollingPanels ;
	
	public int numberOfParallaxRollingPanel ;
	public bool isRollingPanelRandom = false ;
	
	//------
	
	//------ End Panel Option
	public Transform[] parallaxEndPanels ; //Sequence
	//------
	
	public float panelBetweenGap ;
	
	public int numberOfInitPanel = 3;
	
	public Vector2 paddingPosition ;
	
	
	// Private
	private Transform thisTransform ;
	
	private Vector2 screenSize ;
	private Vector2 baseOffsetTransform ;
	
	
	private Queue<DHParallaxPanel> startPanelsQueue ;
	
	private Queue<DHParallaxPanel> rollingPanelQueue ; 
	private int rollingPanelQueueCount ;
	
	private Queue<DHParallaxPanel> endPanelsQueue ; 
	
	private DHParallaxPanel scrollLastPanel ;
	
	private Queue<DHParallaxPanel> parallaxLayerQueue ; 
	//private List<DHParallaxPanel> parallaxLayerList ;
	
	//--
	private List<DHParallaxPanel> startPanelsList ;
	private List<DHParallaxPanel> rollingPanelList ;
	private List<DHParallaxPanel> endPanelsList ; 
	
	
	private bool isMove = false ;
	private DHParallaxPanel scrollfirstPanel ;
	
	//
	
	public bool IsMove {
		get { return isMove ; }
		set { isMove = value ; }	
	}
	
	public float CurrentLayerMoveSpeed {
		get { return currentLayerMoveSpeed ; }
		set { currentLayerMoveSpeed = value ; }
	}
	
	void Awake() {
		
		thisTransform = transform ; // caching this object Transfrom component.
		
		float screenSizeHeight = 2f * Camera.main.orthographicSize;
		float screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		
		screenSize = new Vector2(screenSizeWidth, screenSizeHeight) ;
		
		baseOffsetTransform = new Vector2(Camera.main.transform.position.x + paddingPosition.x, Camera.main.transform.position.y + paddingPosition.y) ;
		//baseOffsetTransform = new Vector2(paddingPosition.x, paddingPosition.y) ;
		
		
		if(parallaxRollingPanels.Length <= numberOfParallaxRollingPanel) {
			rollingPanelQueueCount = numberOfParallaxRollingPanel ;
		}else{
			rollingPanelQueueCount = parallaxRollingPanels.Length ;
		}
		startPanelsQueue = new Queue<DHParallaxPanel>(parallaxStartPanels.Length) ;
		rollingPanelQueue = new Queue<DHParallaxPanel>(rollingPanelQueueCount) ; // Rolling Panel Queue!!
		endPanelsQueue = new Queue<DHParallaxPanel>(parallaxEndPanels.Length) ;
		
		parallaxLayerQueue = new Queue<DHParallaxPanel>(numberOfInitPanel) ; /////// parallaxLayerQueue
		
		
		startPanelsList = new List<DHParallaxPanel>(parallaxStartPanels.Length) ;
		rollingPanelList = new List<DHParallaxPanel>(rollingPanelQueueCount) ; // Rolling Panel Queue!!
		endPanelsList = new List<DHParallaxPanel>(parallaxEndPanels.Length) ;
		
		//
		
		CreateParallaxPanel() ;
		ReadyMovePanel() ;
		
	}
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	void ReadyMovePanel() {
		
		if((startPanelsQueue.Count + rollingPanelQueue.Count) >= numberOfInitPanel) {
			
			for (int i = 0 ; i < numberOfInitPanel ; i++) {
			
				DHParallaxPanel selectParallaxPanel = null ;
			
				if(startPanelsQueue.Count > 0) {
					selectParallaxPanel = startPanelsQueue.Dequeue() as DHParallaxPanel;
				}else{
					if(rollingPanelQueue.Count > 0) {
						selectParallaxPanel = rollingPanelQueue.Dequeue() as DHParallaxPanel;
						rollingPanelQueue.Enqueue(selectParallaxPanel) ;
					}
					/*else{
						if(endPanelsQueue.Count > 0){
							selectParallaxPanel = endPanelsQueue.Dequeue() as Transform;
						}
					}*/
				}
			
				if(selectParallaxPanel != null) {
					
					if(scrollLastPanel != null) {
					
						Vector3 selectPanelRepositon = Vector3.zero ;
						
						selectPanelRepositon = new Vector3((scrollLastPanel.PanelTransform.localPosition.x + (scrollLastPanel.PanelSize.x*0.5f)), selectParallaxPanel.PanelTransform.localPosition.y, selectParallaxPanel.PanelTransform.localPosition.z) ;
						
						selectParallaxPanel.PanelTransform.localPosition = selectPanelRepositon ;
						
						selectParallaxPanel.linkFrontPanel = scrollLastPanel ;
						
					}
					
					selectParallaxPanel.SetActivePanel(true) ; ///
					
					scrollLastPanel = selectParallaxPanel ; // Setting last Panel ;
					
					selectParallaxPanel.PanelMoveScreenOut += PanelMoveScreenOut ; //////
					selectParallaxPanel.PanelMoveScreenEnd += PanelMoveScreenEnd ; //////
					
					selectParallaxPanel.MovePanel(panelBetweenGap) ;
					
					parallaxLayerQueue.Enqueue(selectParallaxPanel) ; /////// parallaxLayerQueue
					
				}
			}
			
			scrollfirstPanel = parallaxLayerQueue.Peek() as DHParallaxPanel; /////// parallaxLayerQueu
			scrollfirstPanel.panelState = DHParallaxPanel.PanelState.START ;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isMove) {
			//scrollfirstPanel = parallaxLayerQueue.Peek() as DHParallaxPanel; /////// parallaxLayerQueu
			if(scrollfirstPanel != null) {
				scrollfirstPanel.TranslateParallaxPanel(currentLayerMoveSpeed) ;
			}
			
			/*
			foreach(DHParallaxPanel dh in parallaxLayerList){
				dh.TranslateParallaxPanel() ;
			}
			*/
		}
		
		
	}
	
	
	//----------------------------------------------
	void PanelMoveScreenOut(DHParallaxPanel parallaxPanel, int panelTag) {
		
		if(!parallaxPanel.Equals(scrollfirstPanel)) {
			return ;
		}
		
		parallaxPanel.IsMove = false ;
		parallaxPanel.SetActivePanel(false) ; ////
		//isMove = false ;
		
		
		parallaxLayerQueue.Dequeue() ; // first Object Dequeue...
		
		DHParallaxPanel firstParallaxPanel = parallaxLayerQueue.Peek() as DHParallaxPanel;
		
		if(firstParallaxPanel != null) {
			firstParallaxPanel.linkFrontPanel = null ;
			firstParallaxPanel.panelState = DHParallaxPanel.PanelState.START ;
			scrollfirstPanel = firstParallaxPanel ;
		}
		
		
		/*
		if(parallaxLayerList.Count > 0) {
			
			parallaxLayerList.RemoveAt(0) ;
			DHParallaxPanel firstParallaxPanel = parallaxLayerList[1] as DHParallaxPanel;
			if(firstParallaxPanel != null) {
				firstParallaxPanel.linkFrontPanel = null ;
			}
			
		}
		*/
		
		
		
		DHParallaxPanel selectParallaxPanel = null ;
		
		if(startPanelsQueue.Count > 0) {
			selectParallaxPanel = startPanelsQueue.Dequeue() as DHParallaxPanel;
		}else{
			if(rollingPanelQueue.Count > 0) {
				selectParallaxPanel = rollingPanelQueue.Dequeue() as DHParallaxPanel;
				rollingPanelQueue.Enqueue(selectParallaxPanel) ;
			}
			/*else{
				if(endPanelsQueue.Count > 0){
					selectParallaxPanel = endPanelsQueue.Dequeue() as Transform;
				}
			}*/
		}
		
		if(selectParallaxPanel != null) {
			
			if(scrollLastPanel != null) {
				
				selectParallaxPanel.linkFrontPanel = scrollLastPanel ;
				
			}
					
			selectParallaxPanel.SetActivePanel(true) ; ////
			
			scrollLastPanel = selectParallaxPanel ; // Setting last Panel ;
			
			selectParallaxPanel.PanelMoveScreenOut += PanelMoveScreenOut ; //////
			selectParallaxPanel.PanelMoveScreenEnd += PanelMoveScreenEnd ; //////
			
			selectParallaxPanel.MovePanel(panelBetweenGap) ;
			
			parallaxLayerQueue.Enqueue(selectParallaxPanel) ; /////// parallaxLayerQueue
		}
		
	}
	
	
	void PanelMoveScreenEnd (DHParallaxPanel parallaxPanel, int panelTag) {
		
		/*
		if(!parallaxPanel.Equals(scrollfirstPanel)) {
			return ;
		}
		*/
		
		if(parallaxPanel.panelState == DHParallaxPanel.PanelState.START) {
			parallaxPanel.panelState = DHParallaxPanel.PanelState.END ;
			//Debug.Log("PanelMoveScreenEnd") ;
		}
		
		
		
		
	}
	
	
	// Coroutine Module
	//IEnumerator CreateParallaxPanel() {
	void CreateParallaxPanel() {
		
		Vector2 nextParallaxPanelSize = Vector2.zero ;
		
		//------- StartParallaxPanels Setting.
		for(int i = 0 ; i < parallaxStartPanels.Length ; i++) {
		
			Transform selectPanelObject = Instantiate(parallaxStartPanels[i]) as Transform ;
			
			
			if(selectPanelObject != null) {
			
				DHParallaxPanel selectPanel = selectPanelObject.GetComponent<DHParallaxPanel>() as DHParallaxPanel ;
				
				Vector3 selectPanelRepositon = Vector3.zero ;
							
				selectPanelRepositon = new Vector3((baseOffsetTransform.x + nextParallaxPanelSize.x), baseOffsetTransform.y, (0.01f*i)) ;
				
				
				selectPanelObject.parent = thisTransform ;
				selectPanelObject.localPosition = selectPanelRepositon ;
				
				startPanelsQueue.Enqueue(selectPanel) ;
				startPanelsList.Add (selectPanel); ///
				
				/*
				yield return null ;
			
				DHParallaxPanel selectParallaxPanelComponent = selectPanel.GetComponent<DHParallaxPanel>() as DHParallaxPanel;
				
				if(nextParallaxPanelSize == Vector2.zero) {
					nextParallaxPanelSize += selectParallaxPanelComponent.PanelSize ;
				}
				*/
				
				if(nextParallaxPanelSize == Vector2.zero) {
					nextParallaxPanelSize = screenSize ;
				}
				
			}
			
		}
		
		
		//------- RollParallaxPanels Setting.
		for(int i = 0 ; i < rollingPanelQueueCount ; i++) {
		
			int randomSelectParallaxPanelIndex = 0 ;
			if(isRollingPanelRandom) {
				randomSelectParallaxPanelIndex = Random.Range(0,parallaxRollingPanels.Length) ;
			}else {
				randomSelectParallaxPanelIndex = (i % parallaxRollingPanels.Length);
			}
			
			
			Transform selectPanelObject = Instantiate(parallaxRollingPanels[randomSelectParallaxPanelIndex]) as Transform;
			
			
			if(selectPanelObject != null) {
			
				DHParallaxPanel selectPanel = selectPanelObject.GetComponent<DHParallaxPanel>() as DHParallaxPanel ;
				
				Vector3 selectPanelRepositon = Vector3.zero ;
							
				selectPanelRepositon = new Vector3((baseOffsetTransform.x + nextParallaxPanelSize.x), baseOffsetTransform.y, (0.01f*i)) ;
				
				selectPanel.SetActivePanel(false) ; ////
				selectPanelObject.parent = thisTransform ;
				selectPanelObject.localPosition = selectPanelRepositon ;
				
				rollingPanelQueue.Enqueue(selectPanel) ;
				rollingPanelList.Add (selectPanel); ///
				
				if(nextParallaxPanelSize == Vector2.zero) {
					nextParallaxPanelSize = screenSize ;
				}
				
			}
			
		}
		
		
		//------- EndParallaxPanels Setting.
		for(int i = 0 ; i < parallaxEndPanels.Length ; i++) {
		
			Transform selectPanelObject = Instantiate(parallaxEndPanels[i]) as Transform ;
			
			if(selectPanelObject != null) {
			
				DHParallaxPanel selectPanel = selectPanelObject.GetComponent<DHParallaxPanel>() as DHParallaxPanel ;
				
				Vector3 selectPanelRepositon = Vector3.zero ;
							
				selectPanelRepositon = new Vector3((baseOffsetTransform.x + nextParallaxPanelSize.x), baseOffsetTransform.y, (0.01f*i)) ;
				
				selectPanelObject.parent = thisTransform ;
				selectPanelObject.localPosition = selectPanelRepositon ;
				
				endPanelsQueue.Enqueue(selectPanel) ;
				endPanelsList.Add (selectPanel); ///
				
				
				if(nextParallaxPanelSize == Vector2.zero) {
					nextParallaxPanelSize = screenSize ;
				}
				
			}
			
		}
		
		//yield return null ;
		
	}
	
	
	//public IEnumerator ResetParallaxLayer() {
	public void ResetParallaxLayer() {
		
		// Queue Clear
		startPanelsQueue.Clear() ;
		rollingPanelQueue.Clear() ;
		endPanelsQueue.Clear() ;
		
		parallaxLayerQueue.Clear() ;
		
		scrollLastPanel = null ;
		
		
		Vector2 nextParallaxPanelSize = Vector2.zero ;
		
		//------- StartParallaxPanels Setting.
		for(int i = 0 ; i < startPanelsList.Count ; i++) {
		
			DHParallaxPanel selectPanel = startPanelsList[i] as DHParallaxPanel ;
			
			Vector3 selectPanelRepositon = Vector3.zero ;
							
			selectPanelRepositon = new Vector3((baseOffsetTransform.x + nextParallaxPanelSize.x), baseOffsetTransform.y, (0.01f*i)) ;
			
			selectPanel.PanelTransform.localPosition = selectPanelRepositon ;
			selectPanel.resetParallaxPanel();
			
			startPanelsQueue.Enqueue(selectPanel) ;
			
			if(nextParallaxPanelSize == Vector2.zero) {
				nextParallaxPanelSize = screenSize ;
			}
			
		}
		
		
		//------- RollParallaxPanels Setting.
		for(int i = 0 ; i < rollingPanelQueueCount ; i++) {
		
			DHParallaxPanel selectPanel = rollingPanelList[i] as DHParallaxPanel ;
			
			Vector3 selectPanelRepositon = Vector3.zero ;
							
			selectPanelRepositon = new Vector3((baseOffsetTransform.x + nextParallaxPanelSize.x), baseOffsetTransform.y, (0.01f*i)) ;
				
			selectPanel.PanelTransform.localPosition = selectPanelRepositon ;
			selectPanel.resetParallaxPanel();
			
			rollingPanelQueue.Enqueue(selectPanel) ;
			
			if(nextParallaxPanelSize == Vector2.zero) {
				nextParallaxPanelSize = screenSize ;
			}
			
		}
			
		//------- EndParallaxPanels Setting.
		for(int i = 0 ; i < endPanelsList.Count ; i++) {
		
			DHParallaxPanel selectPanel = endPanelsList[i] as DHParallaxPanel ;
			
			Vector3 selectPanelRepositon = Vector3.zero ;
							
			selectPanelRepositon = new Vector3((baseOffsetTransform.x + nextParallaxPanelSize.x), baseOffsetTransform.y, (0.01f*i)) ;
				
			selectPanel.PanelTransform.localPosition = selectPanelRepositon ;
			selectPanel.resetParallaxPanel();
			
			endPanelsQueue.Enqueue(selectPanel) ;
				
			if(nextParallaxPanelSize == Vector2.zero) {
				nextParallaxPanelSize = screenSize ;
			}
			
		}

		//yield return StartCoroutine(ReadyMovePanel()) ;
		ReadyMovePanel() ;
	}
	
}
