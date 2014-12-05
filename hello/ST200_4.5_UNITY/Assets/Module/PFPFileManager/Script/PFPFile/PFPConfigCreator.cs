using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PFPConfigCreator : MonoBehaviour {

	public int CreatorVersion = 132;
	public int Version = 1;
	public List<string> AssetBundleAssetList = new List<string>();
	public List<int> AssetBundleVersionList = new List<int>();
	public List<string> AssetBundleLocalPath = new List<string>();
	public List<string> AssetBundleURLPath = new List<string>();

	public List<string> CSVAssetList = new List<string>();
	public List<int> CSVAssetVersionList = new List<int>();
	public List<string> CSVAssetLocalPath = new List<string>();
	public List<string> CSVURLPath = new List<string>();
}
