using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class PFPFileSample : MonoBehaviour {

	public GUIText m_Text;
	public tk2dSprite m_Sprite;
	public tk2dSpriteCollectionData m_CollectionData;
	public tk2dSpriteCollection m_Collection;

	void Start()
	{
		PFPFileSaveLoader.Instance.Init("", "filemanager", ".fid");
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.S))
		{
			SaveText();
		}

		if(Input.GetKeyDown(KeyCode.L))
		{
			LoadText();
		}
	}

	void OnGUI()
	{
		float width = Screen.width;
		float height = Screen.height/7f;

		float curheight = 0f;
		GUI.Label(new Rect(0f,curheight, width, height), Version.ToString());

		curheight += height;
		if(GUI.Button(new Rect(0f,curheight, width/2f, height), "decrease version"))
		{
			Version -= 1;
		}
		if(GUI.Button(new Rect(width/2f,curheight, width/2f, height), "increase version"))
		{
			Version += 1;
		}

		curheight += height;
		texttosave = GUI.TextField(new Rect(0f, curheight, width, height), texttosave);

		curheight += height;

		if(GUI.Button(new Rect(0f,curheight, width/2f, height), "Save Text"))
		{
			SaveText();
		}
		if(GUI.Button(new Rect(width/2f,curheight, width/2f, height), "Load Text"))
		{
			LoadText();
		}

		curheight += height;
		if(GUI.Button(new Rect(0f,curheight, width/2f, height), "Save URL"))
		{

		}
		if(GUI.Button(new Rect(width/2f,curheight, width/2f, height), "Load Any"))
		{
			LoadURL();
		}
	}

	public int Version = 2;
	string textfile = "textfile2";
	string textfileextension = ".txt";
	string texttosave = "hello";
	void SaveText()
	{
		int result = PFPFileSaveLoader.Instance.SaveToLocal(Version, "", textfile, texttosave);

		Log("Save result: " + result);
	}

	void LoadText()
	{
		PFPFileSaveLoader.Instance.LoadFromLocal("", textfile, TextLoadDelegate);
	}

	void TextLoadDelegate(string _name, int _state, WWW _www)
	{
		Log("WWW Loading state: " + _state);
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			Log("WWW LOADED TEXT: " + _www.text);
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED)
		{
			Log("WWW LOAD FAILED: " + _www.error);
		}
	}

	public void Log(string _text)
	{
		m_Text.text += "\n" + _text;
		Debug.Log(_text);
	}

	string urlstring = "http://14.63.165.28/st200/res/MONSTER_BIGSLIME.unity3d";
	string urlfilepath = "";
	string urlfilename = "tk2dsprite";
	string urlfileextension = ".unity3d";

	string collectionname = "MONSTER_BIGSLIME";
	void LoadURL()
	{
		PFPFileSaveLoader.Instance.LoadFromURL(urlstring,		                                        
			                                     urlfilename,			                                     
			                                     URLLoadDelegate);
	}


	void URLLoadDelegate(string _name, int _state, WWW _www)
	{
		Log ("URL LOADING STATE: " + _state);
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			Log("URL LOADED: " + _www.url);

			AssetBundle asset = _www.assetBundle;
			//Object[] objectlist = asset.LoadAll();
			//
			//foreach(Object obj in objectlist)
			//{
			//	Log("Obj name: " + obj.name + " Obj Type: " + (obj.GetType()).ToString());
			//	if(obj is tk2dSpriteCollection)
			//	{
			//		tk2dSpriteCollection data	 = (tk2dSpriteCollection)obj;
			//		Log ("collection detected");
			//	}
			//
			//	if(obj.GetType() == typeof(tk2dSpriteCollectionData))
			//	{
			//		tk2dSpriteCollectionData data = (tk2dSpriteCollectionData)obj;
			//		m_Sprite.Collection = data;
			//		Log("collection data detected");
			//	}
			//}

			tk2dSpriteCollectionData collectiondata = (tk2dSpriteCollectionData)asset.Load(collectionname, typeof(tk2dSpriteCollectionData));

			m_CollectionData.spriteDefinitions = collectiondata.spriteDefinitions;
			m_CollectionData.materials[0].mainTexture = collectiondata.materials[0].mainTexture;
			m_CollectionData.materials = collectiondata.materials;
			 
			m_CollectionData.textures = collectiondata.textures;


			if(collectiondata != null)
			{
				Log("collection data detected");
				//m_Sprite.SetSprite(collectiondata, 0);
			}else
			{
				Log ("no collection data detected");
			}

			//PFPFileSaveLoader.Instance.SaveToLocal(Version, urlfilepath, urlfilename, _www.bytes);
			//tk2dSpriteCollection colldection = asset.Load(collectionname
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED)
		{
			Log ("ERROR LOADING: " + _www.error);
		}
	}
}

