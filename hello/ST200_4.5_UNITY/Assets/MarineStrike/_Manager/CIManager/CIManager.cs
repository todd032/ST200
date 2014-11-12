using UnityEngine;
using System.Collections;

public class CIManager : MonoBehaviour {
	
	public float _ciLogoDuration = 1f ;
	
	private string _nextLevel  ;

	public UITexture _polycubeCI_Texture;


	private void Awake(){
		//Screen.orientation = ScreenOrientation.Landscape;
	}
	
	// Use this for initialization
	private void Start () {

		setImage_BI ();

		string getIntroSceneState = PlayerPrefs.GetString("GoIntro") ;
		
//if(getIntroSceneState == null || getIntroSceneState.Equals("") || getIntroSceneState.Equals("False")){
//
//	_nextLevel = "Intro" ;
//
//	// 테스트용 - 인트로 동영상 막기.
//	//_nextLevel = "Main" ;
//
//}else if(getIntroSceneState.Equals("True")){
//
			_nextLevel = "Main" ;
//}
		
		
		StartCoroutine("CILogoAction") ;
	}
	
	// Update is called once per frame
	private void Update () {
	
	}
	
	private IEnumerator CILogoAction(){
		float t = 0f ;
		bool isDone = false ;
		
		yield return null ;
		
		while(!isDone){
		
			t += Time.deltaTime ;
			
			if(t > _ciLogoDuration){
				isDone = true ;
			}
			
			yield return null ;
			
		}

        
		
		/*
        string originalString = "1";
		
		string encryptString = LoadingWindows.NextE(originalString,Constant.DefalutAppName) ;
		//Debug.Log("encryptString   : " + encryptString) ;
		
		string decryptString = LoadingWindows.NextD(encryptString,Constant.DefalutAppName) ;
		int decryptInt = int.Parse(decryptString) ;
		//Debug.Log("decryptString   : " + decryptInt) ;
		*/
		

		yield return null ;
		

		//
		Application.LoadLevel(_nextLevel);
		
	}

	private void setImage_BI(){

		//if (Constant.CURRENT_MARKET.Equals ("4")) {
		//
		//	Texture basicTexture = Resources.Load("Image/PolycubeCISplashImage_Naver") as Texture ;
		//	_polycubeCI_Texture.mainTexture = basicTexture;
		//
		//} else {
		//
		//	Texture basicTexture = Resources.Load("Image/PolycubeCISplashImage") as Texture ;
		//	_polycubeCI_Texture.mainTexture = basicTexture;
		//}
	}

	
}
