using UnityEngine;
using System.Collections;

public class CamaraIphoneMode : MonoBehaviour {

	public Camera[] _cameraList;
	
	private void Awake() {
		#if UNITY_IPHONE
		
		if(iPhoneSettings.generation == iPhoneGeneration.iPhone3G ||
			iPhoneSettings.generation == iPhoneGeneration.iPhone3GS ||
			iPhoneSettings.generation == iPhoneGeneration.iPodTouch1Gen ||
			iPhoneSettings.generation == iPhoneGeneration.iPodTouch2Gen ||
			iPhoneSettings.generation== iPhoneGeneration.iPodTouch3Gen){

			setCameraSize(1.1f);
			
		}else if(iPhoneSettings.generation == iPhoneGeneration.iPhone4 ||
			iPhoneSettings.generation == iPhoneGeneration.iPhone4S ||
			iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen){
			
			setCameraSize(1.1f);
			
		}else if(iPhoneSettings.generation == iPhoneGeneration.iPad1Gen ||
			iPhoneSettings.generation == iPhoneGeneration.iPad2Gen  ||
			iPhoneSettings.generation == iPhoneGeneration.iPad3Gen  ||
			iPhoneSettings.generation == iPhoneGeneration.iPadMini1Gen ){
		    
			setCameraSize(1.2f);
			
		}else{
			// 4inch
			
			
		}
		
		#elif UNITY_ANDROID
		
		float aspectRatio =(float)System.Math.Round((float)((float)Screen.width/(float)Screen.height) ,2);
		
 
		if(aspectRatio == 1.33f){
			//position to a very small resolution
			// 1024 * 768
			setCameraSize(1.2f);
		}else if(aspectRatio == 1.5f){
			//position to a medium resolution	
			// 960*640
			setCameraSize(1.1f) ;
		}else if(aspectRatio == 1.66f){
			//position to a very small resolution
			// 800 * 480
		}else if(aspectRatio == 1.77f){
			//position to a very small resolution
			// 1280 * 720
		}
		
		#endif
	}
	
	// Use this for initialization
	private void Start () {
	
	}
	
	private void setCameraSize(float ratioScreen){
		foreach ( Camera ca in _cameraList){
			ca.orthographicSize = ratioScreen;
		}
	}

}
