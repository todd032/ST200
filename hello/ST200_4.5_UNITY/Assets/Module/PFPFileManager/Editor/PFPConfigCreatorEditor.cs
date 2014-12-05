using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using LitJson;

public class PFPConfigCreatorEditor{
	static string AssetPath = "/Test/Resourcelala/";
	[MenuItem("PFPConfig/CreateConfigData")]
	static void ExportConfigData () {
		PFPConfigCreator creatorinfo = GameObject.FindObjectOfType(typeof(PFPConfigCreator)) as PFPConfigCreator;

		ConfigFile configfile = new ConfigFile();
		configfile.ClientVersion = creatorinfo.CreatorVersion;
		configfile.Version = creatorinfo.Version;

		configfile.ConfigDataList = new List<ConfigDataStruct>();
		for(int i = 0; i < 2; i++)
		{
			string osstring = "";		
			if(i == 0)
			{
				osstring = PFPFileManager.OS_TYPE_ANDROID;
			}else if(i == 1)
			{
				osstring = PFPFileManager.OS_TYPE_IOS;
			}

			for(int j = 0; j < 2; j++)
			{
				string languagestring = "";
				if(j == 0)
				{
					languagestring = PFPFileManager.LANGUAGE_KOR;
				}
				else if(j == 1)
				{
					languagestring = PFPFileManager.LANGUAGE_ENG;
				}

				ConfigDataStruct configdatastruct = new ConfigDataStruct();
				configdatastruct.OS = osstring;
				configdatastruct.Country = languagestring;
				configdatastruct.FileList = new List<FileDataStruct>();

				for(int assetbundleindex = 0; assetbundleindex < creatorinfo.AssetBundleAssetList.Count; assetbundleindex++)
				{
					FileDataStruct filedatastruct = new FileDataStruct();
					filedatastruct.Version = creatorinfo.AssetBundleVersionList[assetbundleindex];
					filedatastruct.AssetName = creatorinfo.AssetBundleAssetList[assetbundleindex];
					filedatastruct.AssetType = PFPFileManager.ASSET_TYPE_ASSETBUNDLE;
					filedatastruct.DownloadURL = osstring + "/" + creatorinfo.AssetBundleURLPath[assetbundleindex] + "_" + languagestring + "_" + osstring + ".unity3d";
					filedatastruct.LocalFileLocaltion = creatorinfo.AssetBundleLocalPath[assetbundleindex] + "_" + languagestring + "_" + osstring + ".unity3d";
					configdatastruct.FileList.Add(filedatastruct);
				}

				for(int assetbundleindex = 0; assetbundleindex < creatorinfo.CSVAssetList.Count; assetbundleindex++)
				{
					FileDataStruct filedatastruct = new FileDataStruct();
					filedatastruct.Version = creatorinfo.CSVAssetVersionList[assetbundleindex];
					filedatastruct.AssetName = creatorinfo.CSVAssetList[assetbundleindex];
					filedatastruct.AssetType = PFPFileManager.ASSET_TYPE_CSV;
					filedatastruct.DownloadURL = osstring + "/" + creatorinfo.CSVURLPath[assetbundleindex] + "_" + languagestring + ".csv";
					filedatastruct.LocalFileLocaltion = creatorinfo.CSVAssetLocalPath[assetbundleindex] + "_" + languagestring + ".csv";
					configdatastruct.FileList.Add(filedatastruct);
				}
				configfile.ConfigDataList.Add(configdatastruct);
			}
		}

		string assetcreatepath = Application.dataPath + "/Module/PFPFileManager/Generated/Config" + configfile.ClientVersion + ".st200";
		string configdata = JsonMapper.ToJson((object)configfile);

		FileStream file = new FileStream (assetcreatepath, FileMode.Create, FileAccess.Write);		
		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine(configdata);
		
		sw.Close();
		file.Close();

		Debug.Log("Create Configdata done");
	}

}
