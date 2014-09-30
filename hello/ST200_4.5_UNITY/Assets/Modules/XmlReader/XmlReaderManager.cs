using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class XmlReaderManager : MonoBehaviour {

	private static XmlReaderManager instance;
	public static XmlReaderManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = (FindObjectOfType(typeof(XmlReaderManager))) as XmlReaderManager;
			}

			return instance;
		}
	}

	private string DataPath = "StreamingAssets/Xml/TextXml.xml";
	private Dictionary<int, string> TextDictionary = new Dictionary<int, string>();

	void OnDestroy()
	{
		instance = null;
	}

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		Init();
	}

	void Init()
	{
		#if UNITY_EDITOR
		DataPath =  Application.dataPath + "/StreamingAssets/Xml/TextXml.xml";
		#elif UNITY_ANDROID
		DataPath =  Application.dataPath + "/Xml/TextXml.xml";
		#endif
		long _offset;
		long _length;
		//AssetStream.GetZipFileOffsetLength(Application.dataPath, DataPath,  out _offset, out _length);

		FileStream mem = File.Open(DataPath,FileMode.Open);
		XmlTextReader reader = new XmlTextReader(mem);
		while(reader.Read())
		{
			switch(reader.NodeType)
			{
			case XmlNodeType.Element:
				int index = 0;
				//Debug.Log("start name: " + reader.Name);
				if(reader.Name == "Data")
				{
					reader.Read ();
					index = int.Parse(reader.Value);
					do
					{
						reader.Read();
						//Debug.Log("WwhiLE NAMe: " + reader.Name);
					}while(reader.NodeType != XmlNodeType.Element || reader.Name != "Data");

					reader.Read();
					string value = reader.Value;
					TextDictionary.Add(index, value);
					Debug.Log("INDeX: " + index + " VALUE: " +value);
				}
				break;
			}
		}

		reader.Close();
	}
}