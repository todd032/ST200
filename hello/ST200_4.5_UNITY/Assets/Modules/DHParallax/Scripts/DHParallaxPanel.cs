using UnityEngine;
using System.Collections;

public class DHParallaxPanel : MonoBehaviour {
	
	[HideInInspector]
	public delegate void PanelMoveStateDelegate(DHParallaxPanel parallaxPanel, int panelTag);
	[HideInInspector]
	protected PanelMoveStateDelegate _panelMoveScreenOut, _panelMoveScreenEnd;
	
	public event PanelMoveStateDelegate PanelMoveScreenOut {
		add{
			
			_panelMoveScreenOut = null ;
			
			if (_panelMoveScreenOut == null)
        		_panelMoveScreenOut += value;
        }
		remove{
            _panelMoveScreenOut -= value;
		}
	}
	
	public event PanelMoveStateDelegate PanelMoveScreenEnd {
		add{
			
			_panelMoveScreenEnd = null ;
			
			if (_panelMoveScreenEnd == null)
        		_panelMoveScreenEnd += value;
        }
		remove{
            _panelMoveScreenEnd -= value;
		}
	}

	
	//
	protected GameObject thisGameObject ;
	protected Transform thisTransform ;
	protected float screenSizeWidth ;
	protected float screenSizeHeight ;
	protected Vector2 baseOffsetTransform ;
	
	protected Vector2 panelSize ;
	protected bool isMove = false ;
	//
	
	[HideInInspector]
	public DHParallaxPanel linkFrontPanel ;
	
	[HideInInspector]
	public float layerBetweenGap ;
	
	[HideInInspector]
	public enum PanelState {IDLE, START, END} ;
	[HideInInspector]
	public PanelState panelState = PanelState.IDLE ;
	
	
	
	// Property
	public Transform PanelTransform //// caching this object Transfrom component.
	{
		get { return thisTransform ; }
	}
	
	
	public Vector2 PanelSize
    {
        get { return panelSize ; }
    }
	
	
	public bool IsMove
    {
        get { return isMove ; }
		set { isMove = value ; } 
    }
	
	//
	
	protected virtual void Awake() {
		
		thisGameObject = gameObject ;
		thisTransform = transform ; // caching this object Transfrom component.
		
		screenSizeHeight = 2f * Camera.main.orthographicSize;
		screenSizeWidth = screenSizeHeight * Camera.main.aspect;
		
		baseOffsetTransform = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y) ;
		//baseOffsetTransform = new Vector2((screenSizeWidth * 0.5f), (screenSizeHeight * 0.5f)) ;
		
		
	}
	
	protected virtual void createPanelObject() {
		//Use Override..	
	}
	
	
	protected virtual void ParallaxPanelMoveModule() {
		
		if(isMove) {
			if(linkFrontPanel != null) {
				thisTransform.localPosition = new Vector3((linkFrontPanel.PanelTransform.localPosition.x + linkFrontPanel.PanelSize.x + layerBetweenGap),linkFrontPanel.PanelTransform.localPosition.y,linkFrontPanel.PanelTransform.localPosition.z) ;
			}
		}
		
	}
	
	public virtual void TranslateParallaxPanel(float moveSpeed) {
		
		if(isMove) {
			if(linkFrontPanel == null) {
				float amtMove = moveSpeed * Time.deltaTime ;
				thisTransform.Translate(-Vector3.right * amtMove, Space.World) ;				
			}
		}
	}
	
	protected virtual void CheckPanelState() {
		
		if(linkFrontPanel == null) {
			if(thisTransform.localPosition.x < -(panelSize.x) + baseOffsetTransform.x) {
				if(_panelMoveScreenOut != null) {
					_panelMoveScreenOut(this,1) ;
				}
			}
			
			if(thisTransform.localPosition.x < -(panelSize.x) + screenSizeWidth + baseOffsetTransform.x) {
				if(_panelMoveScreenEnd != null) {
					_panelMoveScreenEnd(this,1) ;
				}
			}
		}
		
	}
	
	
	//public virtual void MovePanel() {
	public virtual void MovePanel(float panelBetweenGap) {	
		
		layerBetweenGap = panelBetweenGap ;
		
		isMove = true ;
		
	}
	
	public virtual void resetParallaxPanel() {
		
		linkFrontPanel = null ;
		panelState = PanelState.IDLE ;
		
	}
	
	public void SetActivePanel(bool isActive) {
		thisGameObject.SetActive(isActive) ;	
	}
	
}
