using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Net;

public class TXTReader : MonoBehaviour {

	public GUIText m_Text;

	// Use this for initialization
	void Start () {
		Log(Application.systemLanguage.ToString());
		TestLog();
		GetIP();
	}

	void GetIP()
	{
		string hostname = System.Net.Dns.GetHostName();
		IPHostEntry ipentry = System.Net.Dns.GetHostEntry(hostname);
		IPAddress[] ip = ipentry.AddressList;
		string ipaddress = ip[ip.Length - 1].ToString();

		Log(ipaddress);
	}

	void TestLog()
	{
		if (Application.platform == RuntimePlatform.Android) {
			#if UNITY_ANDROID && !UNITY_EDITOR
			using (AndroidJavaClass cls = new AndroidJavaClass ("com.test.localtiontest.LocationTestScript")) {
				Log(cls.CallStatic<string>("getUserCountry"));
			}

			//using (AndroidJavaClass cls = new AndroidJavaClass ("com.example.locationtest.LocationTestScript")) {
			//	Log(cls.CallStatic<string>("GetLocation"));
			//}
			#endif
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		float width = Screen.width;
		float height = Screen.height/5f;
		
		float curheight = 0f;
		
		
		if(GUI.Button(new Rect(width/2f,curheight, width/2f, height), "Load"))
		{
			LoadTXT();
		}
	}

	void LoadTXT()
	{
		PFPFileSaveLoader.Instance.LoadFromAppData("CSVTest.csv",
		                                        "Text",
		                                        LoadTXTDelegate);
	}

	void LoadTXTDelegate(string _name, int _state, WWW _www)
	{
		if(_state == PFPFileSaveLoader.LOAD_STATE_LOADED)
		{
			Log("Text file loaded complete");
			ParseCSV(_www.text);
		}else if(_state == PFPFileSaveLoader.LOAD_STATE_LOADFAILED)
		{
			Log("text file loading failed path: " + _www.url);
		}
	}

	void ParseCSV(string _csvstring)
	{
		//Log(_csvstring);
		//List<List<string>> parsedstrings = new List<List<string>>();
		foreach(string parsedstring in _csvstring.Split(new char[]{'\n'}))
		{
			string[] datastring = parsedstring.Split(new char[]{','});
			int index = int.Parse(datastring[0]);
			string data = datastring[1];

			Log ("index: " + index + " data: " + data);
		}

	}

	void ParseXMLFile(string _string)
	{
		Log("try parse string: " + _string);


		byte[] stringtobyte =  System.Text.ASCIIEncoding.ASCII.GetBytes(_string);
		Log("Byte converted lenght: " + stringtobyte.Length);

		Stream stream = new MemoryStream(stringtobyte);

		int latestindex = 0;
		string lateststring = "";
		using (XmlReader reader = XmlReader.Create(stream))
		{
			while (reader.Read())
			{
				// Only detect start elements.
				if (reader.IsStartElement())
				{
					// Get element name and switch on it.
					//Log("reader name: " + reader.Name);
					switch (reader.Name)
					{
					case "Data":
						//Log(reader.Name + ": " +  reader.ReadElementString() + "  type: " + reader[0]);

						string readstring = reader.ReadString();
						int readint = 0;

						if(int.TryParse(readstring, out readint))
						{
							latestindex = readint;
						}else
						{
							lateststring = readstring;
							byte[] convertedbytes = System.Text.Encoding.UTF8.GetBytes(readstring);
							string convertedstring = System.Text.Encoding.ASCII.GetString(convertedbytes);
							Log("index: " + latestindex + " string: " + lateststring + " converted: " + convertedstring);
						}


						// = reader.ReadContentAsBase64
						//Console.WriteLine("Start <perls> element.");
						break;
					case "article":
						// Detect this article element.
						//Console.WriteLine("Start <article> element.");
						// Search for the attribute name on this current node.
						string attribute = reader["name"];
						if (attribute != null)
						{
							//Console.WriteLine("  Has attribute name: " + attribute);
						}
						// Next read will contain text.
						if (reader.Read())
						{
							//Console.WriteLine("  Text node: " + reader.Value.Trim());
						}
						break;
					}
				}
			}
		}
	}

	public void Log(string _text)
	{
		m_Text.text += "\n" + _text;
		Debug.Log(_text);
	}
}
