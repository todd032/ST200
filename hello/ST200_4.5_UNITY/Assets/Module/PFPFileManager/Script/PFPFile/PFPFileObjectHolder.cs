using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PFPFileObjectHolder : MonoBehaviour {

	private static PFPFileObjectHolder instance;
	public static PFPFileObjectHolder Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(PFPFileObjectHolder)) as PFPFileObjectHolder;
			}

			if(instance == null)
			{
				GameObject gameobject = new GameObject("PFPFileObjectHolder");
				instance = gameobject.GetComponent<PFPFileObjectHolder>();
			}

			return instance;
		}
	}
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if(instance == null)
		{
			instance = this;
		}
	}

	protected Dictionary<string, byte[]> AssetBundleBytesDictionary = new Dictionary<string, byte[]>();
	protected Dictionary<string, AssetBundle> AssetBundleDictionary = new Dictionary<string, AssetBundle>();
	protected Dictionary<string, string> AssetTextDictionary = new Dictionary<string, string>();

	public void AddTextAsset(string _assetname, string _content)
	{
		if(!AssetTextDictionary.ContainsKey(_assetname))
		{
			AssetTextDictionary.Add(_assetname, _content);
		}else
		{
			AssetTextDictionary[_assetname] = _content;
		}
	}
	
	public void AddAssetBundle(string _assetname, AssetBundle _content)
	{
		if(!AssetBundleDictionary.ContainsKey(_assetname))
		{
			AssetBundleDictionary.Add(_assetname, _content);
		}else
		{
			AssetBundleDictionary[_assetname] = _content;
		}
	}

	public void AddAssetBundle(string _assetname, byte[] _content)
	{
		if(!AssetBundleBytesDictionary.ContainsKey(_assetname))
		{
			AssetBundleBytesDictionary.Add(_assetname, _content);
		}else
		{
			AssetBundleBytesDictionary[_assetname] = _content;
		}
	}
	
	public string GetTextAsset(string _assetname)
	{
		if(AssetTextDictionary.ContainsKey(_assetname))
		{
			return AssetTextDictionary[_assetname];
		}
		Debug.Log("NO CSV ASSET WITH: " + _assetname);
		return null;
	}
	
	public AssetBundle GetAssetBundleAsset(string _assetname)
	{
		//if(AssetBundleDictionary.ContainsKey(_assetname))
		//{
		//	return AssetBundleDictionary[_assetname];
		//}
		//
		//return null;
		if(AssetBundleBytesDictionary.ContainsKey(_assetname))
		{
			return AssetBundle.CreateFromMemoryImmediate(AssetBundleBytesDictionary[_assetname]);
		}
		return null;
	}
}
