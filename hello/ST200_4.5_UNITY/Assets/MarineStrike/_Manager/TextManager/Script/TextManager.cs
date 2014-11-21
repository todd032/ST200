using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class manages everything about text.
/// grade, special text replacings and etc..
/// </summary>
public class TextManager : MonoBehaviour {

	private static TextManager instance;
	public static TextManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(TextManager)) as TextManager;
			}

			return instance;
		}
	}

	private List<string> m_TextList = new List<string>();

	void Start()
	{
		//m_TextList.Add("HI: &mark");
		//m_TextList.Add("HI: &mark &mark");
		//m_TextList.Add("HI: &mark and and &mark");
		//
		//Debug.Log(GetReplaceString(0,new string[]{"1"}));
		//Debug.Log(GetReplaceString(1,new string[]{"1" , "2"}));
	 	//Debug.Log(GetReplaceString(2,new string[]{"1", "2", "3"}));
		//Debug.Log(GetReplaceString(2,"1"));
	}

	public void SetTextList(List<string> _list)
	{
		m_TextList = _list;
	}

	public List<string> TextList()
	{
		return m_TextList;
	}

	public string GetString(int _index)
	{
		if(_index >= m_TextList.Count)
		{
			return "null " + _index;
		}

		return GetEnterReplaced(m_TextList[_index]);
	}

	public string GetReplaceString(int _index, string value)
	{
		//special replacing texts will be marked with &mark
		if(_index >= m_TextList.Count)
		{
			return "null " + _index;
		}
		
		string stringtoreplace = m_TextList[_index];
		stringtoreplace = stringtoreplace.Replace("&mark", value);
		int valuesindex = 0;
		//int index = stringtoreplace.Replace("&mark", value);
		//while(index != -1)
		//{
		//	stringtoreplace.Remove(index,5);
		//	stringtoreplace.Insert(index, values[valuesindex++]);
		//}

		return GetEnterReplaced(stringtoreplace);
	}

	public string GetReplaceString(int _index, string[] values)
	{
		//special replacing texts will be marked with &mark
		if(_index >= m_TextList.Count)
		{
			return "null " + _index;
		}

		string stringtoreplace = m_TextList[_index];

		int valuesindex = 0;
		int index = stringtoreplace.IndexOf("&mark");
		//Debug.Log(stringtoreplace);
		while(index != -1)
		{
			stringtoreplace = stringtoreplace.Remove(index,5);
			//Debug.Log("STring: " + stringtoreplace + " LENGTH: " + stringtoreplace.Length);
			if(stringtoreplace.Length > index)
			{
				stringtoreplace = stringtoreplace.Insert(index, values[valuesindex]);
			}else
			{
				stringtoreplace += values[valuesindex];
			}

			index = stringtoreplace.IndexOf("&mark");
			valuesindex++;
		}

		return GetEnterReplaced(stringtoreplace);
	}

	protected string GetEnterReplaced(string _input)
	{
		string output = _input.Replace("&enter","\n");
		return output;
	}

	public string GetRankString(int _int)
	{
		//set rankimage
		string rankname = "";
		if(_int == 0)
		{
			rankname += "S";
		}else if(_int == 1)
		{
			rankname += "A";
		}else if(_int == 2)
		{
			rankname += "B";
		}else if(_int == 3)
		{
			rankname += "C";
		}

		return rankname;
	}

	public string GetReplacedString(string _input)
	{
		string stringtoreplace = _input;
		stringtoreplace = GetEnterReplaced(stringtoreplace);
		return stringtoreplace;
	}

	public string GetReplaceString(string _input, string value)
	{		
		string stringtoreplace = _input;
		stringtoreplace = stringtoreplace.Replace("&mark", value);
		int valuesindex = 0;
		//int index = stringtoreplace.Replace("&mark", value);
		//while(index != -1)
		//{
		//	stringtoreplace.Remove(index,5);
		//	stringtoreplace.Insert(index, values[valuesindex++]);
		//}
		
		return GetEnterReplaced(stringtoreplace);
	}

	public string GetReplaceString(string _input, string[] values)
	{
		//special replacing texts will be marked with &mark		
		string stringtoreplace = _input;
		
		int valuesindex = 0;
		int index = stringtoreplace.IndexOf("&mark");
		//Debug.Log(stringtoreplace);
		while(index != -1)
		{
			stringtoreplace = stringtoreplace.Remove(index,5);
			//Debug.Log("STring: " + stringtoreplace + " LENGTH: " + stringtoreplace.Length);
			if(stringtoreplace.Length > index)
			{
				stringtoreplace = stringtoreplace.Insert(index, values[valuesindex]);
			}else
			{
				stringtoreplace += values[valuesindex];
			}
			
			index = stringtoreplace.IndexOf("&mark");
			valuesindex++;
		}
		
		return GetEnterReplaced(stringtoreplace);
	}

	
	
	public static string CreateJsonData(Dictionary<string, string> _value)
	{
		string returnstring = "";
		int count = 0;
		foreach(string _key in _value.Keys)
		{
			string value = "\"" + _key + "\":"+_value[_key];
			if(count != 0)
			{
				returnstring += "," + value;
			}else
			{
				returnstring += value;
			}
			count++;
		}
		return "{" + returnstring + "}";
	}

	public static string CreateJsonData(Dictionary<string, object> _value)
	{
		string returnstring = "";
		int count = 0;
		foreach(string _key in _value.Keys)
		{
			string value = "\"" + _key + "\":"+_value[_key]+"";
			if(count != 0)
			{
				returnstring += "," + value;
			}else
			{
				returnstring += value;
			}
			count++;
		}
		return "{" + returnstring + "}";
	}

	/// <summary>
	/// return [XXday, XXmin, XXsec]
	/// </summary>
	public static string[] GetDHM(int _second)
	{
		string daystring = "00";
		string hourstring = "00";
		string minstring = "00";

		int min = _second / 60 % 60;
		int hour = (_second / 60 / 60) % 24;
		int day = (_second / 60 / 60) / 24;

		if(min < 10)
		{
			minstring = "0" + min.ToString();
		}else
		{
			minstring = min.ToString();
		}

		if(hour < 10)
		{
			hourstring = "0" + hour.ToString();
		}else
		{
			hourstring = hour.ToString();
		}

		if(day < 10)
		{
			daystring = "0" + day.ToString();
		}else
		{
			daystring = day.ToString();
		}
		return new string[]{daystring, hourstring, minstring};
	}

	/// <summary>
	/// returns XX:XX
	/// </summary>
	public static string GetHM(int _second)
	{
		string hourstring = "";
		string minstring = "";

		int totalsecond = _second;

		int min = (_second / 60) % 60;
		int hour = (_second / 60) / 60;

		if(hour < 10)
		{
			hourstring = "0" + hour.ToString();
		}else
		{
			hourstring = hour.ToString();
		}

		if(min == 0)
		{
			minstring = "01";
		}else if(min < 10)
		{
			minstring = "0" + min.ToString();
		}else
		{
			minstring = min.ToString();
		}
		return hourstring + ":" + minstring;
	}
}
