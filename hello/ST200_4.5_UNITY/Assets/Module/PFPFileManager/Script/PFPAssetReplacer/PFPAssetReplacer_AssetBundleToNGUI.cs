using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PFPAssetReplacer_AssetBundleToNGUI : PFPAssetReplacer {

	public AssetBundle m_AssetBundle;
	public UIAtlas m_UIAtlas;
	public UIAtlas m_OriginAtlas;
	public List<UISprite> m_PixelPerfectList = new List<UISprite>();
	public override void ReplaceAssetObject ()
	{
		m_AssetBundle = PFPFileObjectHolder.Instance.GetAssetBundleAsset(m_AssetName);

		if(m_AssetBundle != null)
		{
			Object[] loadedobject = m_AssetBundle.LoadAll(typeof(UIAtlas));
			if(loadedobject.Length != 0)
			{
				UIAtlas replaceatlas = loadedobject[0] as UIAtlas;

				m_OriginAtlas = m_UIAtlas.replacement;
				m_UIAtlas.replacement = replaceatlas;
				m_UIAtlas.MarkAsChanged();

#if !UNITY_EDITOR
				//UISprite[] effectedsprites = Resources.FindObjectsOfTypeAll<UISprite>();
				//
				//foreach(UISprite sprite in effectedsprites)
				//{
				//	if(sprite.atlas == m_UIAtlas 
				//	   //&& sprite.type == UIBasicSprite.Type.Simple
				//	   )
				//	{
				//		sprite.MakePixelPerfect();
				//	}
				//}
#endif
			}else
			{
				Debug.LogError("NO Type found in assetbundle please check");
			}
		}else
		{
			Debug.LogError("NO ASSSETS FOUND PLZ CHECK Asset name: " + m_AssetName);
		}

		for(int i = 0; i < m_PixelPerfectList.Count; i++)
		{
			//m_PixelPerfectList[i].MarkAsChanged();
			m_PixelPerfectList[i].MakePixelPerfect();
			//m_PixelPerfectList[i].Update();
			//m_PixelPerfectList[i].atlas = m_UIAtlas.replacement;
			//m_PixelPerfectList[i].spriteName = m_PixelPerfectList[i].spriteName;
			//m_PixelPerfectList[i].
			//Debug.Log(m_PixelPerfectList[i].name , m_PixelPerfectList[i].gameObject);
		}
	}

	public override void UnloadAssetObject ()
	{
		m_UIAtlas.replacement = m_OriginAtlas;
		m_AssetBundle.Unload(true);
		Debug.Log("UNLOAD ASSET: " + m_AssetName + " ASSET BUNDLE IS NULL?: " + (m_AssetBundle == null));
	}
}
