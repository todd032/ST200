using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using LitJson;

public class PFPFileSaveLoader : MonoBehaviour {

	public static bool LogEnable = true;
	
	public static readonly int SAVE_FAIL_EXCEPTION = -2;
	public static readonly int SAVE_FAIL_LOWVERSION = -1;
	public static readonly int SAVE_SUCCESS = 1;
	
	public static readonly int LOAD_STATE_LOADING 	= 1;
	public static readonly int LOAD_STATE_LOADED 	= 2;
	public static readonly int LOAD_STATE_LOADFAILED= 3;
	public static readonly int LOAD_STATE_LOADFAILED_NOFILE = 4;
	///[_state]
	/// 1 - loading
	/// 2 - finished
	/// 3 - error
	public delegate void WWWDelegate(string _name, int _state, WWW _www);
	
	public Dictionary<string, WWWDelegate> LoadingDelegates = new Dictionary<string, WWWDelegate>();
	public void RemoveDelegate(string _name)
	{
		if(LoadingDelegates.ContainsKey(_name))
		{
			LoadingDelegates.Remove(_name);
		}
	}	                      
	//public Dictionary<string, WWWDelegate> SavingDelegates = new Dictionary<string, WWWDelegate>();
	
	private static PFPFileSaveLoader instance;
	public static PFPFileSaveLoader Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(PFPFileSaveLoader)) as PFPFileSaveLoader;
			}
			
			return instance;
		}
	}
	
	void Awake()
	{
		//PrintContentsInFolder(GetAppPath());	
		//Load(null, "Monster_Dragon.unity3d");
		DontDestroyOnLoad(gameObject);
	}
	
	public void Init(string _path, string _name, string _extension)
	{
		FileInfoDataPath = _path;
		FileInfoDataName = _name;
		FileInfoDataExtension = _extension;
		
		LoadInfoDictionary();
	}
	
	#region File Info Data
	protected string FileInfoDataPath = "FileInfoData.fid";
	protected string FileInfoDataName = "FileInfoData";
	protected string FileInfoDataExtension = ".fid";
	public Dictionary<string, PFPFileInfoData> FileInfoDataDictionary = new Dictionary<string, PFPFileInfoData>();
	
	public PFPFileInfoData GetFileInfo(string _filename)
	{
		if(FileInfoDataDictionary.ContainsKey(_filename))
		{
			return FileInfoDataDictionary[_filename];
		}
		
		PFPFileInfoData data = new PFPFileInfoData();
		return data;
	}
	
	public void SaveFileInfo(string _filename, int _version)
	{
		PFPFileInfoData data = GetFileInfo(_filename);
		data.FileName = _filename;
		data.FileVersion = _version;
		FileInfoDataDictionary[_filename] = data;
		
		SaveInfoDictionary();
	}
	
	protected void SaveInfoDictionary()
	{
		string body = JsonMapper.ToJson((object)FileInfoDataDictionary);
		SaveToLocal(FileInfoDataPath, body);
	}
	
	protected void LoadInfoDictionary()
	{
		LoadFromLocal(FileInfoDataPath, FileInfoDataName, LoadInfoDictionaryDelegate);
	}
	
	protected void LoadInfoDictionaryDelegate(string _name, int _state, WWW _www)
	{
		if(_state == LOAD_STATE_LOADED)
		{
			string data = _www.text;
			FileInfoDataDictionary = JsonMapper.ToObject<Dictionary<string, PFPFileInfoData>>(data);
			Debug.Log("Load complete: " + data);
		}
	}
	
	#endregion
	
	#region Save / Load
	/// <summary>
	/// Saves the asset in bytes to local
	/// the total path will be "default/" + _filepath;
	/// set _version 0 to override or higher value than current saved version
	/// </summary>
	/// <returns> 
	/// SAVE_FAIL_EXCEPTION		-	fail by exception
	/// SAVE_FAIL_LOWVERSION	-	fail by version save
	/// SAVE_SUCCESS 			-	success
	/// 
	/// </returns>
	/// <param name="_version"> [0] - override,  [1 or higher] - check version and save </param>
	/// <param name="_filename">ex) "monsterimage" </param>
	/// <param name="_filepath">"Assetbundle/monsterassets/lalal.unity3d"</param>
	/// <param name="_data">_data.</param>
	public int SaveToLocal(int _version, string _filepath, string _filename, byte[] _data)
	{
		try
		{
			PFPFileInfoData fileinfodata = GetFileInfo(_filename);
			if(true)//_version == 0 || (fileinfodata.FileVersion < _version))
			{
				SaveToLocal(_filepath, _data);
				SaveFileInfo(_filename, _version);
				return SAVE_SUCCESS;
			}else
			{
				//show error
				Debug.LogWarning("Version Check error save");
				return SAVE_FAIL_LOWVERSION;
			}
		}catch(IOException e)
		{
			Debug.LogWarning("Save Incomplete due to exception: " + e);
			return SAVE_FAIL_EXCEPTION;
		}
	}
	
	/// <summary>
	/// Save the text to local
	/// the total path will be "default/" + _filepath
	/// set _version 0 to override or higher value than current saved version
	/// </summary>
	/// <returns> 
	/// SAVE_FAIL_EXCEPTION		-	fail by exception
	/// SAVE_FAIL_LOWVERSION	-	fail by version save
	/// SAVE_SUCCESS 			-	success
	/// 
	/// </returns>
	/// <param name="_version"> [0] - override,  [1 or higher] - check version and save </param>
	/// <param name="_filename">ex) "monsterimage" </param>
	/// <param name="_filepath">"Assetbundle/monsterassets/lalal.unity3d"</param>
	/// <param name="_data">_data.</param>
	public int SaveToLocal(int _version, string _filepath, string _filename, string _data)
	{
		try
		{
			PFPFileInfoData fileinfodata = GetFileInfo(_filename);
			if(true)//_version == 0 || (fileinfodata.FileVersion < _version))
			{				
				SaveToLocal(_filepath, _data);
				SaveFileInfo(_filename, _version);
				return SAVE_SUCCESS;
			}else
			{
				//show error
				Debug.LogWarning("Version Check error save");
				return SAVE_FAIL_LOWVERSION;
			}
		}catch(IOException e)
		{
			Debug.LogWarning("Save Incomplete due to exception: " + e);
			return SAVE_FAIL_EXCEPTION;
		}
	}
	
	
	protected void SaveToLocal(string _filepath, byte[] _data)
	{
		//Directory.CreateDirectory(_filepath);

		File.WriteAllBytes(GetLocalPath() + _filepath, _data);
	}
	
	protected void SaveToLocal(string _filepath, string _data)
	{
		#if !WEB_BUILD
		//Directory.CreateDirectory(_filepath);

		string path = GetLocalPath() + _filepath;
		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
		
		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine( _data );
		
		sw.Close();
		file.Close();
		
		Debug.Log ("SAVE DONE");
		#endif
	}
	
	public void LoadFromAppData(string _path, string _filename, WWWDelegate _delegate)
	{
		if(!LoadingDelegates.ContainsKey(_filename))
		{
			LoadingDelegates.Add(_filename, _delegate);
		}else
		{
			LoadingDelegates[_filename] = _delegate;
		}

		StartCoroutine(IELoadAppData(_path, _filename));
	}
	
	public void LoadFromLocal(string _path, string _filename, WWWDelegate _delegate)
	{
		if(!LoadingDelegates.ContainsKey(_filename))
		{
			LoadingDelegates.Add(_filename, _delegate);
		}else
		{
			LoadingDelegates[_filename] = _delegate;
		}
		StartCoroutine(IELoadLocal(_path, _filename));
	}
	
	public void LoadFromURL(string _url, string _filename, WWWDelegate _delegate)
	{
		if(!LoadingDelegates.ContainsKey(_filename))
		{
			LoadingDelegates.Add(_filename, _delegate);
		}else
		{
			LoadingDelegates[_filename] = _delegate;
		}
		StartCoroutine(IELoadURL(_url, _filename));
	}
	
	public void LoadFromAnySpace(string _url, string _path, string _filename, WWWDelegate _delegate)
	{
		if(!LoadingDelegates.ContainsKey(_filename))
		{
			LoadingDelegates.Add(_filename, _delegate);
		}else
		{
			LoadingDelegates[_filename] = _delegate;
		}
		StartCoroutine(IELoadAny(_url, _path, _filename));
	}
	
	protected string readStringFromFile( string filename, string _extension)//, int lineIndex )
	{
		#if !WEB_BUILD
		string path = GetLocalPath() + filename + _extension;
		if (File.Exists(path))
		{
			FileStream file = new FileStream (path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader( file );
			
			string str = null;
			str = sr.ReadLine ();
			
			sr.Close();
			file.Close();
			
			return str;
		}
		
		else
		{
			return null;
		}
		#else
		return null;
		#endif 
	}
	
	protected IEnumerator IELoadAppData(string _localpath, string _name)
	{
		string path = GetAppPath() + _localpath;


		#if UNITY_EDITOR
		path = "file://c://" + path;
		#elif UNITY_ANDROID
		path = "jar:file://" + path;
		#elif UNITY_IPHONE
		path = "file://" + path;
		#endif

		WWW www = new WWW(path);
		//Debug.Log("TRY LOAD AT: " + path + " EXIST?: " + File.Exists(GetAppPath() + _localpath));
		//if(File.Exists(GetAppPath() + _localpath))
		{

			while(!www.isDone)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADING, www);
				yield return null;
			}
			yield return  null;

			if(www.error != null)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED, www);
			}else
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADED, www);
			}
		}
		www.Dispose();
		www = null;
		//else
		//{
		//	LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED_NOFILE, www);
		//}
			
		//LoadingDelegates.Remove(_name);
		yield break;
	}
	
	protected IEnumerator IELoadLocal(string _localpath, string _name)
	{
		string path = GetLocalPath() + _localpath;
		#if UNITY_EDITOR
		path = "file://c://" + path;
		#else
		path = "file://" + path;
		#endif
		
		WWW www = new WWW(path);
		//Debug.Log("TRY LOAD AT: " + path + " EXIST?: " + File.Exists(GetLocalPath() + _localpath));
		if(File.Exists(GetLocalPath() + _localpath))
		{		
			while(!www.isDone)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADING, www);
				yield return null;
			}
			yield return  null;
			
			if(www.error != null)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED, www);
			}else
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADED, www);
			}
		}else
		{
			LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED_NOFILE, www);
		}
		www.Dispose();
		www = null;
		//LoadingDelegates.Remove(_name);
		yield break;
	}
	
	
	protected IEnumerator IELoadURL(string _url, string _name)
	{
		string path = _url;
		Debug.Log("TRY LOAD FROM URL: " + _url);
		WWW www = new WWW(path);
		yield return  null;
		
		while(!www.isDone)
		{
			LoadingDelegates[_name](_name, LOAD_STATE_LOADING, www);
			yield return null;
		}
		yield return null;
		
		if(www.error != null)
		{
			LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED, www);
		}else
		{
			LoadingDelegates[_name](_name, LOAD_STATE_LOADED, www);
		}
		www.Dispose();
		www = null;
		
		//LoadingDelegates.Remove(_name);
		yield break;
	}
	
	protected IEnumerator IELoadAny(string _url, string _localpath, string _name)
	{
		//try load from local first and load from webs
		string path = GetLocalPath() + _localpath;
		#if UNITY_EDITOR
		path = "file://c://" + path;
		#else
		path = "file://" + path;
		#endif
		
		
		Debug.Log("TRY LOAD AT: " + path + " EXIST?: " + File.Exists(GetLocalPath() + _localpath));
		
		if(File.Exists(GetLocalPath() + _localpath))
		{
			Debug.Log("Load from Local");
			WWW www = new WWW(path);
			while(!www.isDone)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADING, www);
				yield return null;
			}
			yield return  null;
			
			Debug.Log("TRY LOAD AT: " + path);
			while(!www.isDone)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADING, www);
				yield return null;
			}
			yield return null;
			
			if(www.error != null)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED, www);
			}else
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADED, www);
			}
			www.Dispose();
			www = null;
		}else
		{
			Debug.Log("Load from Url");
			path = _url;
			
			WWW www = new WWW(path);
			yield return  null;
			
			while(!www.isDone)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADING, www);
				yield return null;
			}
			yield return null;
			
			if(www.error != null)
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADFAILED, www);
			}else
			{
				LoadingDelegates[_name](_name, LOAD_STATE_LOADED, www);
			}
			www.Dispose();
			www = null;
			//LoadingDelegates.Remove(_name);
		}

		//LoadingDelegates.Remove(_name);
		yield break;
	}

	public bool ExistInLocal(string _path)
	{		
		return File.Exists(GetLocalPath() + _path);
	}

	public bool ExistInAppData(string _path)
	{
		return File.Exists(GetAppPath() + _path);
	}

	public string GetAppPath()
	{
		string path = "";
		#if UNITY_EDITOR
		path = Application.streamingAssetsPath + "/";
		#elif UNITY_ANDROID
		path = Application.dataPath + "!/assets/";
		#elif UNITY_IPHONE
		path = Application.dataPath + "/Raw/";
		#endif
		
		//Debug.Log("APP: " + path);
		return path;
	}
	
	public string GetLocalPath()
	{
		string path = "";
		#if UNITY_EDITOR
		path = Application.persistentDataPath + "/";
		#elif UNITY_ANDROID
		path = Application.persistentDataPath + "/";
		#elif UNITY_IPHONE
		path = Application.persistentDataPath + "/";
		#endif
		//Debug.Log("LOCAL: " + path);
		//path = "file://" + Application.persistentDataPath + "/";
		return path;
	}
	
	public string[] PrintContentsInFolder(string _path)
	{
		string[] files = Directory.GetFiles(_path);
		
		Debug.Log("FOLDER: " + _path);
		for(int i = 0; i < files.Length; i++)
		{
			Debug.Log("FILE NAME: " + files[i]);
		}
		
		return files;
	}
	#endregion
}

public struct PFPFileInfoData
{
	public string FileName;
	public int FileVersion;
}