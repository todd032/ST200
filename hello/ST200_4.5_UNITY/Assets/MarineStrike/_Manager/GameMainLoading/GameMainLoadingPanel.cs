using UnityEngine;
using System.Collections;

public class GameMainLoadingPanel : MonoBehaviour {

		
	public UISprite _loadingBarGauge ;
	public UISprite m_LoadingTipSprite;

	float loadtimer = 0f;
	float loadmaxtimer = 2f;
	//private bool isLoading = false;	

	
		
	private void Awake(){
		
		if ( Managers.Audio != null) Managers.Audio.PlayBGMSound(AudioManager.BGM_SOUND.BGM_Main,true);
		m_LoadingTipSprite.spriteName = ImageResourceManager.Instance.GetRandomLoadingTipSpriteName();
		SetSubmarineInfo() ;
		
	}
	
	 // Use this for initialization
	private void Start () {
		
		StartCoroutine(StartLoad("GameMain")) ;
		
	}
	
	// Update is called once per frame
	private void Update () {	
		/*
		if (Application.platform == RuntimePlatform.Android){
		        if (Input.GetKeyUp(KeyCode.Escape)){
		            Application.LoadLevel("SubMarineSelect");
		            return;
		        }
		}
		*/
	}
	

	//----------------------
	IEnumerator StartLoad(string strSceneName){
	
		if(Managers.UserData != null && Managers.GameBalanceData != null) {
			
			string languageCode = Managers.UserData.LanguageCode ;
			
			string tipString = Managers.GameBalanceData.GetRandomGameTipInfoMessage(languageCode) ;
						
		}

		while(loadtimer < loadmaxtimer )
		{
			loadtimer += Time.deltaTime;
			if(_loadingBarGauge != null){
				_loadingBarGauge.fillAmount = loadtimer / loadmaxtimer / 2f ;
			}
			yield return null;
		}

		yield return null;

		AsyncOperation asyncSceneLoad = Application.LoadLevelAsync(strSceneName) ;
		
		yield return null ;
		
		while(!asyncSceneLoad.isDone){
			
			float currentLoadSceneProgressFull = asyncSceneLoad.progress / 2f + 0.5f;
			int currentLoadSceneProgress = Mathf.RoundToInt(currentLoadSceneProgressFull * 100f ) ;
			
			if(_loadingBarGauge != null){
				_loadingBarGauge.fillAmount = currentLoadSceneProgressFull ;
			}
				
			yield return null ;				
		}		
	}

	private void SetSubmarineInfo(){
		
		if ( Managers.UserData != null && Managers.GameBalanceData != null)  {
		}
	}
	
	
}