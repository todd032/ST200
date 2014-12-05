using UnityEngine;
using System.Collections;

public class PFPAssetReplacer : MonoBehaviour {

	public string m_AssetName = "AssetName";

	void Awake()
	{
		ReplaceAssetObject();
	}

	void OnDestroy()
	{
		UnloadAssetObject();
	}

	public virtual void ReplaceAssetObject()
	{

	}

	public virtual void UnloadAssetObject()
	{

	}
}
