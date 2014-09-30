using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MobileMovieTexture))]
public class IntroManager : MonoBehaviour {
	
	public UITexture _skipImageTexture ;

	public float m_VideoFixedWidth = 960;
	public float m_VideoFixedHeight = 643;
	private float m_VideoFixedRatio = 1f;
	public UITexture m_VideoTexture;

	private bool _initIntro = false ;
	private bool _skipAble = false ;
	
	private MobileMovieTexture m_movieTexture;

	private void Awake() {
		m_VideoFixedRatio = m_VideoFixedHeight / m_VideoFixedWidth;

		if ( Managers.Audio != null) {
			Managers.Audio.StopBGMSound() ;
		}
		
		string getIntroSceneState = PlayerPrefs.GetString("GoIntro") ;
		if(getIntroSceneState == null || getIntroSceneState.Equals("") || getIntroSceneState.Equals("False")){
			_initIntro = true ;
		}
		
		NGUITools.SetActive(_skipImageTexture.gameObject , false) ;
		
		m_movieTexture = GetComponent<MobileMovieTexture>();
        m_movieTexture.onFinished += OnFinished;

		//float targettoscreenratio = (float)Screen.width / m_VideoFixedWidth;
		//m_VideoTexture.transform.localScale = new Vector3(Screen.width, targettoscreenratio * m_VideoFixedHeight, 1f);
	}
	
	// Use this for initialization
	private void Start () {
		
		if ( Managers.Audio != null) {
			Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_Intro,true);	
		}
		
		m_movieTexture.Play();	
		
		
		if(!_initIntro){
			StartCoroutine("SkipTimmer") ;
		}
		
	}
	
	// Update is called once per frame
	private void Update () {
	
		if(_skipAble && !_initIntro){
			if (Application.platform == RuntimePlatform.Android){
				if (Input.GetKeyUp(KeyCode.Escape)){
					
					string getIntroSceneState = PlayerPrefs.GetString("GoIntro") ;
					if(getIntroSceneState == null || getIntroSceneState.Equals("") || getIntroSceneState.Equals("False")){
						PlayerPrefs.SetString("GoIntro", "True") ;
					}
					
					//Application.LoadLevel("Ranking");
					if(!Managers.UserData.ReturnToRanking)
					{
						Application.LoadLevel("Main");
					}else
					{
						Managers.UserData.ReturnToRanking = false;
						Application.LoadLevel("Ranking");
					}
					return ;
           		}
			}
			
			if(Input.GetMouseButton(0)){
				
				string getIntroSceneState = PlayerPrefs.GetString("GoIntro") ;
				if(getIntroSceneState == null || getIntroSceneState.Equals("") || getIntroSceneState.Equals("False")){
					PlayerPrefs.SetString("GoIntro", "True") ;
				}
				
				//Application.LoadLevel("Ranking");
				if(!Managers.UserData.ReturnToRanking)
				{
					Application.LoadLevel("Main");
				}else
				{
					Managers.UserData.ReturnToRanking = false;
					Application.LoadLevel("Ranking");
				}
				return ;
			}
			
		}
	}
	
	void OnFinished(MobileMovieTexture sender){
		string getIntroSceneState = PlayerPrefs.GetString("GoIntro") ;
		if(getIntroSceneState == null || getIntroSceneState.Equals("") || getIntroSceneState.Equals("False")){
			PlayerPrefs.SetString("GoIntro", "True") ;
			if(!Managers.UserData.ReturnToRanking)
			{
				Application.LoadLevel("Main");
			}else
			{
				Managers.UserData.ReturnToRanking = false;
				Application.LoadLevel("Ranking");
			}
		}else if(getIntroSceneState.Equals("True")){
			//Application.LoadLevel("Ranking");
			if(!Managers.UserData.ReturnToRanking)
			{
				Application.LoadLevel("Main");
			}else
			{
				Managers.UserData.ReturnToRanking = false;
				Application.LoadLevel("Ranking");
			}
		}
    }
	
	IEnumerator SkipTimmer(){
		yield return new WaitForSeconds(3f);
		_skipAble = true;
		NGUITools.SetActive(_skipImageTexture.gameObject , true) ;
		
	}
	
}
