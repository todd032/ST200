using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class extractTextDAta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CreateCSV();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateCSV()
	{
		string content = "";
		for(int i = 0; i < TextManager.Instance.TextList().Count; i++)
		{
			string text = TextManager.Instance.TextList()[i];
			if(text == "")
			{
				text = "empty";
			}else
			{
				//text = text.Replace("\n", "&enter");
			}
			content += i.ToString() + "," + text + "\n";
		}

		string path = Application.dataPath + "/Extracted.txt";
		FileStream file = new FileStream (path, FileMode.Create, FileAccess.Write);
		
		StreamWriter sw = new StreamWriter( file );
		sw.WriteLine( content );
		
		sw.Close();
		file.Close();
		
		Debug.Log ("SAVE DONE: " + path);
	}
}
