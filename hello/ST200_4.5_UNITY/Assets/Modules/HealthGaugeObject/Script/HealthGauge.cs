using UnityEngine;
using System.Collections;

public class HealthGauge : MonoBehaviour {
	
	/**
	 * 1.페이드인  시간    public float f_FadeIn
2.페이드 아웃 시간 public float f_FadeOut
3.체력 감소 시간. public float f_DecreaseTime / 디폴트 0

옵션 - 위치 설정  ( TOP , BOTTOM)   view_position
	패딩         (     m)
	예비) 배경 대비 체력바의 위치 (Top ,bottom , left , right)
	 * 
	 * 
	 * */
	
	public Transform FrameSprite;
	public Transform GaugeClippedSprite;
	
	public float fadeInSeconds = 2.0f;
	public float fadeOutSeconds = 2.0f;
	public float changeVisibleSeconds = 2.0f;
	public float changeSeconds = 0.0f;
	
	public enum view_position {Above , Below};
	public view_position viewPosition = view_position.Below;
	public view_position  ViewPosition{
		set {
			
			if (value == view_position.Above){
				if (frameTransform != null){
					frameTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y , thisTransform.localPosition.z - 0.1f);
				
				}
				if (GaugeTransform != null){
					GaugeTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y ,  thisTransform.localPosition.z - 0.2f);
				}	
			}else {
				if (frameTransform != null){
					frameTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y , thisTransform.localPosition.z + 0.2f);

				}
				if (GaugeTransform != null){
					GaugeTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y ,  thisTransform.localPosition.z + 0.1f);
				
				}		
			}
			
			viewPosition = value;

		}
		
		
	}
		
				
			
	
	//public enum ENUM_POSITION { TOP , BOTTOM }  ;
	//public ENUM_POSITION view_position = ENUM_POSITION.TOP;

//	public Vector2 padding;
	//public enum ENUM_GAUGE_POSITION {CENTER ,TOP , BOTTOM , LEFT , RIGHT};
	//public ENUM_GAUGE_POSITION gauge_position = ENUM_GAUGE_POSITION.CENTER;
	
	
	public enum State  {
		Idle ,
		FadeIn ,
		FadeOut ,
		Damage ,
		Recovery, 
		Change
	};
	
	
	private float maxHealth ;
	private float currentHealth;
	private float changePercent;
	
	private tk2dSprite frameSprite;
	private tk2dClippedSprite gaugeSprite;
	private Transform frameTransform;
	private Transform GaugeTransform;
	
	private float originalGaugeWidth;
	private float originalGaugeHeight;
	
	
	[HideInInspector]
	public State state = State.Idle;
	
	
	public delegate void Delegate();
	
	public event Delegate OnChangeDelegate ,OnCompleteDelegate;
	
	
	private Transform thisTransform ;
	
	void Awake(){
		thisTransform =  transform ;
		
		
		if ( FrameSprite != null)  {
			
			frameTransform = Instantiate(FrameSprite) as Transform;
			frameTransform.parent = thisTransform ;
			
			if ( viewPosition  == view_position.Below){
				frameTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y , thisTransform.localPosition.z + 0.2f);
			}else {
				frameTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y , thisTransform.localPosition.z - 0.1f);
			}
			frameSprite =  frameTransform.GetComponent<tk2dSprite>() as tk2dSprite;
			
		}
			
		
		
		if ( GaugeClippedSprite != null) {
			
		 	GaugeTransform =Instantiate(GaugeClippedSprite) as Transform;
			GaugeTransform.parent = thisTransform;
			
			if ( viewPosition  == view_position.Below){
				GaugeTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y ,  thisTransform.localPosition.z + 0.1f);
			}else {
				GaugeTransform.localPosition = new Vector3 ( thisTransform.localPosition.x , thisTransform.localPosition.y ,  thisTransform.localPosition.z - 0.2f);
				
			}
			
			gaugeSprite = GaugeTransform.GetComponent<tk2dClippedSprite>() as tk2dClippedSprite;
			
		} 
		
		
		initColor();
		
		
		/**
		 *  sprite  original size 
		 */
		Rect gaugeRect =gaugeSprite.ClipRect;
		
		originalGaugeWidth = gaugeRect.width;
		originalGaugeHeight = gaugeRect.height;
		/*
		print ("aa.x :"+gaugeRect.x);
		print ("aa.y :"+gaugeRect.y);
		print ("aa.w :"+gaugeRect.width);
		print ("aa.h :"+gaugeRect.height);
		*/
		//originalGaugeWidth = gaugeSprite.GetBounds().extents.x * 2;
		//originalGaugeHeight = gaugeSprite.GetBounds().extents.y * 2;
	

		state = State.Idle;
		
		StartCoroutine(state.ToString());
		
	}

	// Use this for initialization
	void Start () {
	
		
		
	}
	
	public void initColor(){
		/**
		 *  sprite transparent
		 */
		
		Color tempcolor =	new Color(1,1,1,0);
		//tempcolor.a = 0.0f; //transparent
		
		frameSprite.color = tempcolor;
		gaugeSprite.color = tempcolor;
		
	}
	

	// Update is called once per frame
	void Update () {
		
		/*
		if (Input.GetMouseButtonDown(0)){
			
				//state = State.FadeIn;
			
			HeathDamage( 200 , testcurrenthp , testdamage);
			testcurrenthp = testcurrenthp - testdamage ;
		}
		
		if (Input.GetMouseButtonDown(1)){
				
				//state = State.FadeIn;
				testcurrenthp = testcurrenthp + testdamage ;
			HealthRecovery( 200 , testcurrenthp , testdamage);
			
		}
	*/
	}
	
	/* HealthDamage : 게이지에서 깎는다.

_maxHealth :  내 최대 체력.
_currentHealth : 깎여지기 전 체력.
_damage : 데미지.

*/
	
	public void HealthDamage(float _maxHealth , float _currentHealth , float _damage ){
	//	Debug.Log(_maxHealth + " :" + _currentHealth + ":" +  _damage);
		/*
		
		//effect section 
		
		*/
		gameObject.SetActive(true);
		base.enabled = true;
		

		maxHealth = _maxHealth;
		currentHealth = _currentHealth;
		changePercent = - _damage / maxHealth ;
		//gaugeSprite.c
		
		if (state == State.Idle){
			state = State.FadeIn;
			StartCoroutine(state.ToString());
		}else {
			StopCoroutine(state.ToString());
			state = State.Change;
			StartCoroutine("Change");
			
		}
		
	
		//this.enabled = true;
	//	transform.renderer.enabled= true;
		
	}
	
	
/* HealthDamage : 게이지에서 채운다.

_maxHealth :  내 최대 체력.
_currentHealth : 채워지기 전 체력.
_recovery : 회복량.

*/
	public void HealthRecovery(float _maxHealth , float _currentHealth , float _recovery){
		/*
		
		//effect section 
		
		*/
		gameObject.SetActive(true);
		this.enabled = true;
		
		maxHealth = _maxHealth;
		currentHealth = _currentHealth;
		changePercent = _recovery / maxHealth ;
		
		if (state == State.Idle){
			state = State.FadeIn;
			StartCoroutine(state.ToString());
		}else {
			StopCoroutine(state.ToString());
			state = State.Change;
			StartCoroutine("Change");
			
		}
	
	
		//this.enabled = true;
		//transform.renderer.enabled= true;
		
	}
	
	IEnumerator Idle(){
		
		// Function Start;
		
		yield return null ;
		
		
		while(state == State.Idle) {
		
				// Excute
			yield return null ;	
			
		}
		
		// Function End;
		StartCoroutine(state.ToString()) ;
	
		
	}
	
	
	IEnumerator FadeIn(){
		
		// Function Start;
		
		yield return null ;
		
		float remainSeconds = 0.0f;
		
		
		Color tempColor;
	
				
		while(state == State.FadeIn && remainSeconds < fadeInSeconds) {
				
			remainSeconds += Time.deltaTime; 

		//	gaugeSprite.color = Color.Lerp(Color(1, 1, 1,  1) , Color(1,1,1,0) ,  remainSeconds/ f_visibleSeconds);
			
			tempColor = gaugeSprite.color;
			tempColor.a  = remainSeconds / fadeInSeconds;
	
			gaugeSprite.color  = tempColor;
			frameSprite.color = tempColor;
			yield return null ;
		}
		
		
		
		
		state = State.Change;
		
		// Function End;
		StartCoroutine(state.ToString()) ;
	
		
	}
	
	
	
	IEnumerator Change(){
		
		
	
		yield return null ;
		
		Color newColor = new Color(1 ,1,1,1);
		frameSprite.color = newColor;
		gaugeSprite.color = newColor;
		
		//gauge init width
		float currentHealthPercent = currentHealth /maxHealth;
		if( currentHealthPercent > 1.0f)
			currentHealthPercent= 1.0f;
				
		if ( currentHealthPercent < 0.0f)
				currentHealthPercent= 0.0f;
						
		 Vector2 initSize = new Vector2( currentHealth /maxHealth   , originalGaugeHeight);
		 gaugeSprite.clipTopRight = initSize;
		
		
		float waitSeconds;
		if ( changeVisibleSeconds > 0) waitSeconds = (changeVisibleSeconds - changeSeconds)/2.0f; 
		else waitSeconds = 0.00f;
			
			
		yield return new WaitForSeconds(waitSeconds) ;
		
		float  changeLength = originalGaugeWidth * changePercent;
		
		float remainSeconds = 0.0f; 
		
		Vector2 changeSize;
		
		//if  f_ChangeVisibleSeconds  > f_ChangeSeconds 
		float fNewChangeSeconds = changeSeconds;
		if (changeVisibleSeconds  < changeSeconds )
				fNewChangeSeconds = changeVisibleSeconds;
		
		while(state == State.Change && remainSeconds <= changeVisibleSeconds ) {
			
					//change delegate 
				if ( OnChangeDelegate != null)
					OnChangeDelegate();
			
				changeSize = initSize;
				remainSeconds += Time.deltaTime;
				
				// animation time  > 0
				if (fNewChangeSeconds > 0.0f) {
				
				
				
					float timePecent = remainSeconds  / fNewChangeSeconds ;
			
					if ( timePecent > 1.0f)
						changeSize.x += changeLength ;
					else 
						changeSize.x += changeLength * timePecent ;
					
					
			
				} else {
					// animation time  < 0
					changeSize.x += changeLength ;
				}
			
				gaugeSprite.clipTopRight = changeSize;
			
				yield return null ;
			
		}
		
		yield return new WaitForSeconds(waitSeconds) ;
		
		state = State.FadeOut;
		// Function End;
		StartCoroutine(state.ToString()) ;
	
		
	}
	
	IEnumerator FadeOut(){

		yield return null ;
		
		float remainSeconds = 0.0f;
		
		
		Color tempColor;
			
		while(state == State.FadeOut && remainSeconds < fadeOutSeconds) {
				
			remainSeconds += Time.deltaTime; 

		//	gaugeSprite.color = Color.Lerp(Color(1, 1, 1,  1) , Color(1,1,1,0) ,  remainSeconds/ f_visibleSeconds);
			
			tempColor = gaugeSprite.color;
			tempColor.a  =1.0f - remainSeconds / fadeOutSeconds;
	
			gaugeSprite.color  = tempColor;
			frameSprite.color = tempColor;
			yield return null ;
		}
		//complete delegate 
		if ( OnCompleteDelegate != null) {
			OnCompleteDelegate();
			
		}
		
		state = State.Idle;
		
		// Function End;
		StartCoroutine(state.ToString()) ;
		
		yield return null;
		gameObject.SetActive(false);
		this.enabled = false;
	}
	
	
	
	
	IEnumerator Damage(){
	yield return null ;
		
	}
	
	IEnumerator Recovery(){
	yield return null ;
		
	}

}


/*
 
 	if (bScale)
		{
			fScale_Time += Time.deltaTime;
			float lerp =  fScale_Time / fDuration_scale;
			
			if (lerp >= 1)
			{
				bScale = false;
			}
			
			transform.localScale = Vector3.Lerp (vFromScale, vToScale, lerp);
		}
		
		if( bFade )
		{
			//Debug.Log("Cube Fade");
			
			fFade_Time += Time.deltaTime;
			
			float lerp =  Mathf.Clamp01( fFade_Time / fDuration_fade );			
			Color lerpedColor = Color.Lerp( fColor_From, fColor_To, lerp);
			if( kGo_shader != null)  kGo_shader.renderer.material.SetColor(sColorProp, lerpedColor);
			
			if( lerp == 1.0f)
			{
				bFade = false;
				fFade_Time = 0.0f;
			}
		}
		
		// ------------------ Rotate Event --------------------
			
		if (bRotate)
		{
			fRotate_Time += Time.deltaTime;
			float lerp =  fRotate_Time / fDuration_rotate ;
			
			angle += (lerp * 10);
			
			this.transform.rotation = Quaternion.Euler(0, 0, angle);
						
			if (lerp >= 1)
			{
				this.transform.rotation = Quaternion.Euler(0, 0, 0);
				bRotate = false;
				fRotate_Time = 0;
			}
		}
		
		// ------------------- Move Event ----------------
			
		if (bMove)
		{
			fMove_Time += Time.deltaTime;
			float lerp =  fMove_Time / fDuration_move;
			if (lerp >= 1)
			{
				bMove = false;
			}			
			transform.position = Vector3.Lerp (vFromPos, vToPos, lerp);
		}

 
 
 */