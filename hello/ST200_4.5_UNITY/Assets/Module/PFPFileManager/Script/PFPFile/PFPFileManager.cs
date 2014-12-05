using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using LitJson;

public class PFPFileManager : MonoBehaviour {

	public static string TEXT_CONFIG = "";
	public static string TEXT_CONFIG_KOR = "정보를 읽고있습니다";
	public static string TEXT_CONFIG_ENG = "READING CONFIG FILE";

	public static string TEXT_DOWNLOADING = "";
	public static string TEXT_DOWNLOADING_KOR = "필요한 데이터를 다운받고 있습니다";
	public static string TEXT_DOWNLOADING_ENG = "DOWNLOADING DATA";

	public static string TEXT_DOWNLOADING_NETWORK_ERROR = "";
	public static string TEXT_DOWNLOADING_NETWORK_ERROR_KOR = "다운로드중 에러가 발생했습니다 \n통신상태가 좋은 곳에서 앱을 다시 실행하여 다운로드를 진행해주세요";
	public static string TEXT_DOWNLOADING_NETWORK_ERROR_ENG = "DOWNLOAD FAILED DUE TO UNSTABLE NETWORK CONDITION \nPLEASE TRY AFTER RESTARTING THE APP";

	public static string TEXT_LOADING = "";
	public static string TEXT_LOADING_KOR = "데이터를 로딩중입니다.";
	public static string TEXT_LOADING_ENG = "LOADING DATA FROM DISK";

	public static string ASSET_TYPE_ASSETBUNDLE 		= "ASSETBUNDLE";
	public static string ASSET_TYPE_CSV					= "CSV";

	public static string LANGUAGE_KOR					= "KR";
	public static string LANGUAGE_ENG					= "ENG";

	public static string OS_TYPE_ANDROID				= "ANDROID";
	public static string OS_TYPE_IOS					= "IOS";

	private static PFPFileManager instance;
	public static PFPFileManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(PFPFileManager)) as PFPFileManager;
			}
			
			return instance;
		}
	}

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	void Start()
	{
		GetLangaugeSelect();
	}

	void OnDestroy()
	{
		instance = null;
	}

	public int m_Version = 132;
	public string m_ServerURL = "https://14.63.165.28/";

	public string ConfigData_URL = "";
	public string ConfigData_Local = "";
	public string ConfigData_AppData = "";
	public string ConfigData_Name = "";

	public ConfigFile m_LatestConfigFile;
	public ConfigFile m_NewConfigFile;

	private string LanguageSelect = "LanguageSelect";
	public string m_SelectedLanguage = "En";
	public virtual void InitConfigFile(string _serverurl)
	{
		m_ServerURL = _serverurl;
		PFPFileSaveLoader.Instance.LoadFromAppData(ConfigData_AppData,
		                                           ConfigData_Name,
		                                           ConfigFileAppDataDelegate);
		ShowLoadingUI();
		m_LoadingUI.SetDownLoadPercent(0f);
		m_LoadingUI.SetDescriptionLabel(TEXT_CONFIG);
		m_LoadingUI.SetTotalCountLabel(1,3);
	}

	protected virtual void ConfigFileAppDataDelegate(string _name, int _state, WWW _www)
	{
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			Debug.Log("LOADED FROM APP");
			ConfigFile newconfigfile = ConvertToConfigFile(_www.text);
			m_LatestConfigFile = newconfigfile;
			m_NewConfigFile = newconfigfile;
			PFPFileSaveLoader.Instance.LoadFromLocal(ConfigData_Local,
			                                           ConfigData_Name,
			                                           ConfigFileLocalDelegate);

			m_LoadingUI.SetTotalCountLabel(2,3);

		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED)
		{
			//show error message
			Debug.LogWarning(_www.error);

			PFPFileSaveLoader.Instance.LoadFromLocal(ConfigData_Local,
			                                         ConfigData_Name,
			                                         ConfigFileLocalDelegate);
			
			m_LoadingUI.SetTotalCountLabel(2,3);

		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADING)
		{
			m_LoadingUI.SetDownLoadPercent(_www.progress);
		}
	}

	protected virtual void ConfigFileLocalDelegate(string _name, int _state, WWW _www)
	{
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			Debug.Log("CONFIG FILE IN LOCAL LOADED");
			ConfigFile newconfigfile = ConvertToConfigFile(_www.text);
			CompareConfigFile(newconfigfile);
			PFPFileSaveLoader.Instance.LoadFromURL(m_ServerURL + ConfigData_URL + m_Version.ToString() + ".st200",
			                                           ConfigData_Name,
			                                           ConfigFileURLDelegate);
			m_LoadingUI.SetTotalCountLabel(3,3);
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED_NOFILE)
		{
			Debug.Log("NO CONFIG FILE IN LOCAL");
			PFPFileSaveLoader.Instance.LoadFromURL(m_ServerURL + ConfigData_URL + m_Version.ToString() + ".st200",
			                                           ConfigData_Name,
			                                           ConfigFileURLDelegate);
			m_LoadingUI.SetTotalCountLabel(3,3);
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED)
		{
			//show error message
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADING)
		{
			m_LoadingUI.SetDownLoadPercent(_www.progress);
		}
	}

	protected virtual void ConfigFileURLDelegate(string _name, int _state, WWW _www)
	{
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{

			ConfigFile newconfigfile = ConvertToConfigFile(_www.text);
			Debug.Log("LOADED CONFIG FROM URL VERSION: " + newconfigfile.Version);
			CompareConfigFile(newconfigfile);
			LoadAssetsFromConfigFile();
			PFPFileSaveLoader.Instance.RemoveDelegate(_name);
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED)
		{
			//show error message
			Debug.LogWarning("ERROR LOADING CONFIG FROM URL: " + _www.error);
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADING)
		{
			//Debug.Log("??: " + _www.progress);
			m_LoadingUI.SetDownLoadPercent(_www.progress);
		}
	}

	protected ConfigFile ConvertToConfigFile(string _text)
	{
		ConfigFile newconfigfile = JsonMapper.ToObject<ConfigFile>(_text);
		return newconfigfile;
	}

	protected void CompareConfigFile(ConfigFile _newconfigfile)
	{
		Debug.Log("COMPARE LATEST VERSION: " + m_LatestConfigFile.Version + " NEW: " + _newconfigfile.Version);
		if(m_NewConfigFile.Version < _newconfigfile.Version)
		{
			m_LatestConfigFile = m_NewConfigFile;
			m_NewConfigFile = _newconfigfile;
			if(m_LatestConfigFile.Version == 0)
			{
				m_LatestConfigFile = m_NewConfigFile;
			}

			PFPFileSaveLoader.Instance.SaveToLocal(m_NewConfigFile.Version,
			                                       ConfigData_Local,
			                                       ConfigData_Name,
			                                       JsonMapper.ToJson((object)m_NewConfigFile));
		}
	}

	public void GetLangaugeSelect()
	{
		if(PlayerPrefs.HasKey(LanguageSelect))
		{
			SetLanguage(PlayerPrefs.GetString(LanguageSelect));
		}else
		{
			ShowLanguageSelectUI();
		}
	}

	public void SetLanguage(string _string)
	{
		m_SelectedLanguage = _string;		
		PlayerPrefs.SetString(LanguageSelect, m_SelectedLanguage);

		if(m_SelectedLanguage == LANGUAGE_KOR)
		{
			TEXT_LOADING = TEXT_LOADING_KOR;
			TEXT_DOWNLOADING = TEXT_DOWNLOADING_KOR;
			TEXT_DOWNLOADING_NETWORK_ERROR = TEXT_DOWNLOADING_NETWORK_ERROR_KOR;
			TEXT_LOADING = TEXT_LOADING_KOR;
		}else if(m_SelectedLanguage == LANGUAGE_ENG)
		{
			TEXT_LOADING = TEXT_LOADING_ENG;
			TEXT_DOWNLOADING = TEXT_DOWNLOADING_ENG;
			TEXT_DOWNLOADING_NETWORK_ERROR = TEXT_DOWNLOADING_NETWORK_ERROR_ENG;
			TEXT_LOADING = TEXT_LOADING_ENG;			
		}

		InitConfigFile(m_ServerURL);
	}

	protected int TotalDownLoadCount = 0;
	protected List<FileDataStruct> DownLoadFiles = new List<FileDataStruct>();
	protected int TotalLoadCount = 0;
	protected List<FileDataStruct> LoadFiles = new List<FileDataStruct>();
	protected void LoadAssetsFromConfigFile()
	{
		string OSType = OS_TYPE_ANDROID;
#if UNITY_ANDROID
		OSType = OS_TYPE_ANDROID;
#elif UNITY_IOS
		OSType = OS_TYPE_IOS;
#endif

		//compare latest file and download from it.
		ConfigDataStruct newconfigdata = new ConfigDataStruct();
		ConfigDataStruct currentconfigdata = new ConfigDataStruct();

		for(int i = 0; i < m_NewConfigFile.ConfigDataList.Count; i++)
		{
			ConfigDataStruct curconfigdata = m_NewConfigFile.ConfigDataList[i];
			if(curconfigdata.OS == OSType && curconfigdata.Country == m_SelectedLanguage)
			{
				newconfigdata = curconfigdata;
			}
		}

		for(int i = 0; i < m_LatestConfigFile.ConfigDataList.Count; i++)
		{
			ConfigDataStruct curconfigdata = m_LatestConfigFile.ConfigDataList[i];
			if(curconfigdata.OS == OSType && curconfigdata.Country == m_SelectedLanguage)
			{
				currentconfigdata = curconfigdata;
			}
		}

		for(int i = 0; i < newconfigdata.FileList.Count; i++)
		{
			FileDataStruct newfiledata = newconfigdata.FileList[i];
			FileDataStruct curfiledata = currentconfigdata.FileList[i];

			if(newfiledata.Version > curfiledata.Version)
			{
				DownLoadFiles.Add(newfiledata);
			}else
			{
				if(!PFPFileSaveLoader.Instance.ExistInLocal(curfiledata.LocalFileLocaltion))
				{
					DownLoadFiles.Add(newfiledata);
				}
			}
		}

		LoadFiles = newconfigdata.FileList;

		TotalDownLoadCount = DownLoadFiles.Count;
		TotalLoadCount = LoadFiles.Count;

		StartDownLoadAsset();
	}

	protected void StartDownLoadAsset()
	{		
		m_LoadingUI.SetDownLoadPercent(0f);
		m_LoadingUI.SetDescriptionLabel(TEXT_DOWNLOADING);
		m_LoadingUI.SetTotalCountLabel((TotalDownLoadCount - DownLoadFiles.Count), TotalDownLoadCount);

		if(DownLoadFiles.Count > 0)
		{
			FileDataStruct datastruct = DownLoadFiles[0];
			PFPFileSaveLoader.Instance.LoadFromURL(m_ServerURL + datastruct.DownloadURL, datastruct.AssetName, DownLoadAssetDelegate);
		}else
		{
			StartLoadAsset();
		}
	}

	protected void DownLoadAssetDelegate(string _name, int _state, WWW _www)
	{
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			FileDataStruct datastruct = DownLoadFiles[0];
			PFPFileSaveLoader.Instance.SaveToLocal(datastruct.Version, datastruct.LocalFileLocaltion,
			                                       datastruct.AssetName, _www.bytes);
			DownLoadFiles.RemoveAt(0);

			StartDownLoadAsset();
			
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADING)
		{
			//Debug.Log("HIHI: " + _www.progress);
			m_LoadingUI.SetDownLoadPercent(_www.progress);
		}
	}

	protected void StartLoadAsset()
	{
		m_LoadingUI.SetDownLoadPercent(0f);
		m_LoadingUI.SetDescriptionLabel(TEXT_LOADING);
		m_LoadingUI.SetTotalCountLabel((TotalLoadCount - LoadFiles.Count), TotalLoadCount);

		if(LoadFiles.Count > 0)
		{
			FileDataStruct datastruct = LoadFiles[0];
			PFPFileSaveLoader.Instance.LoadFromLocal(datastruct.LocalFileLocaltion, datastruct.AssetName, LoadAssetDelegate);
		}else
		{
			MoveToNextScene();
		}
	}

	protected void LoadAssetDelegate(string _name, int _state, WWW _www)
	{
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			FileDataStruct datastruct = LoadFiles[0];
			if(datastruct.AssetType == ASSET_TYPE_CSV)
			{
				PFPFileObjectHolder.Instance.AddTextAsset(_name, _www.text);
			}else if(datastruct.AssetType == ASSET_TYPE_ASSETBUNDLE)
			{
				PFPFileObjectHolder.Instance.AddAssetBundle(_name, _www.bytes);
			}

			LoadFiles.RemoveAt(0);
			
			StartLoadAsset();
			
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADING)
		{
			m_LoadingUI.SetDownLoadPercent(_www.progress);
		}
	}

	protected void MoveToNextScene()
	{
		Application.LoadLevel(2);
	}

	#region UI functions 
	public GameObject m_LanguageSelectUI;
	public PFPFileLoadingUI m_LoadingUI;
	public UILabel m_NetworkErrorLabel;

	public void OnClickEnglishButton()
	{
		SetLanguage(LANGUAGE_ENG);
	}

	public void OnClickKoreanButton()
	{
		SetLanguage(LANGUAGE_KOR);
	}

	public void ShowLanguageSelectUI()
	{
		NGUITools.SetActive(m_LanguageSelectUI.gameObject, true);
		NGUITools.SetActive(m_LoadingUI.gameObject, false);
		NGUITools.SetActive(m_NetworkErrorLabel.gameObject, false);
	}

	public void ShowLoadingUI()
	{
		NGUITools.SetActive(m_LanguageSelectUI.gameObject, false);
		NGUITools.SetActive(m_LoadingUI.gameObject, true);
		NGUITools.SetActive(m_NetworkErrorLabel.gameObject, false);
	}

	public void ShowNetworkErrorUI()
	{
		NGUITools.SetActive(m_LanguageSelectUI.gameObject, false);
		NGUITools.SetActive(m_LoadingUI.gameObject, false);
		NGUITools.SetActive(m_NetworkErrorLabel.gameObject, true);
		m_NetworkErrorLabel.text = TEXT_DOWNLOADING_NETWORK_ERROR;
	}
	#endregion
}

public struct ConfigFile
{	
	public int ClientVersion;
	public int Version;
	public List<ConfigDataStruct> ConfigDataList;
}

public struct ConfigDataStruct
{
	/// <summary>
	/// EN
	/// KR
	/// </summary>
	public string Country;
	/// <summary>
	/// ANDROID
	/// IOS
	/// </summary>
	public string OS;
	public List<FileDataStruct> FileList;
}

public struct FileDataStruct
{
	public string AssetName;
	/// <summary>
	/// AssetBundle
	/// CSV
	/// </summary>
	public string AssetType;
	public string LocalFileLocaltion;
	public string DownloadURL;
	public int Version;
}