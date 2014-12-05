using UnityEngine;
using System.Collections;

public class PFPAssetReplacer_AssetBundleToCSV : PFPAssetReplacer {

	public override void ReplaceAssetObject ()
	{
		TextManager.Instance.SetTextWithCSV(PFPFileObjectHolder.Instance.GetTextAsset(m_AssetName));
	}
	
	public override void UnloadAssetObject ()
	{

	}
}