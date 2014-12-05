using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class AssetCreator {
	[MenuItem("AssetCreator/Get PersistentDataPath")]
	static void PrintPersistentDataPath()
	{
		Debug.Log(Application.persistentDataPath);
	}

	static string AssetPath = "/ST200/Image/ExportResources";
	[MenuItem("AssetCreator/Export NGUIAtlas, tk2dSpriteCollectionData in selected folder")]
	static void ExportNGUIAtlas() {
		// Bring up save panel
		Debug.Log("Start Export Resource");
		string path = Application.dataPath + "/StreamingAssets/";//EditorUtility.SaveFilePanel ("Save Resource", Application.dataPath +"/StreamingAssets/AssetBundle", Selection.objects[0].name, "unity3d");

		string assetfolder = Application.dataPath + AssetPath;
		Debug.Log("Search Path: " + assetfolder);

		List<string> folderstosearch = new List<string>(Directory.GetDirectories(assetfolder));
		folderstosearch.Add(assetfolder);
		List<string> assetnames = new List<string>();
		List<Object> objectlist = new List<Object>();
		while(folderstosearch.Count != 0)
		{
			string[] newdirectories = Directory.GetDirectories(folderstosearch[0]);
			for(int i = 0; i < newdirectories.Length;	i++)
			{
				folderstosearch.Add(newdirectories[i]);
			}
		
			string[] files = Directory.GetFiles(folderstosearch[0]);
			for(int i = 0; i < files.Length; i++)
			{
				assetnames.Add(files[i]);
			}
		
			folderstosearch.RemoveAt(0);
		}
		
		for(int i = 0; i < assetnames.Count; i++)
		{
			assetnames[i] = assetnames[i].Replace(@"\","/").Replace(Application.dataPath, "Assets");
			Object curobject = AssetDatabase.LoadAssetAtPath(assetnames[i], typeof(UIAtlas));
			//Debug.Log("FILE NAME: " + assetnames[i]);
			if(curobject != null)
			{
				objectlist.Add(curobject);
				Debug.Log("CUR OBJECT: " + curobject.name);
			}
		}

//#if UNITY_ANDROID
		foreach(Object o in objectlist)
		{
			Object[] oa = new Object[]{o,};
			BuildPipeline.BuildAssetBundle(o, oa, path + o.name + "_" + PFPFileManager.OS_TYPE_ANDROID + ".unity3d",
			                               BuildAssetBundleOptions.CompleteAssets 
			                               //|BuildAssetBundleOptions.UncompressedAssetBundle,
			                               |BuildAssetBundleOptions.CollectDependencies
			                               ,
			                               BuildTarget.Android);
		}
//#elif UNITY_IOS
		foreach(Object o in objectlist)
		{
			Object[] oa = new Object[]{o,};
			BuildPipeline.BuildAssetBundle(o, oa, path + o.name + "_" + PFPFileManager.OS_TYPE_IOS + ".unity3d",
			                               BuildAssetBundleOptions.CompleteAssets 
			                               //|BuildAssetBundleOptions.UncompressedAssetBundle,
			                               |BuildAssetBundleOptions.CollectDependencies
			                               ,
			                               BuildTarget.iPhone);
		}
//#endif
	}

	/*
	[MenuItem("AssetCreator/Build Monster AssetBundle - Track dependencies")]
	static void ExportNGUIAtlas() {
		// Bring up save panel
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
		if (path.Length != 0) {
			// Build the resource file from the active selection.
			Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
			BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, 
			                               BuildAssetBundleOptions.CollectDependencies | 
			                               BuildAssetBundleOptions.CompleteAssets,
			                               BuildTarget.iPhone);
			Selection.objects = selection;
		}
	}
	[MenuItem("AssetCreator/Build Monster AssetBundle - No dependency tracking")]
	static void ExportResourceNoTrack () {
		// Bring up save panel
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
		if (path.Length != 0) {
			// Build the resource file from the active selection.
			BuildPipeline.BuildAssetBundle(Selection.activeObject, Selection.objects, path,
			                               BuildAssetBundleOptions.CompleteAssets,
			                               BuildTarget.iPhone);
		}
	}
	*/
}
