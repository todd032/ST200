using UnityEngine;
using System;
using System.Collections;

public class ActionTest : MonoBehaviour {

	protected System.Action<string> actiondelegate = null;

	void Start()
	{
		InitActiondelegate();
		SetAction("HI");
	}

	void SetAction(string _value)
	{
		actiondelegate(_value);
	}

	void InitActiondelegate()
	{
		System.Action<string> hi = this.hmm;
		actiondelegate = hi;
	}

	void hmm(string _value)
	{
		Debug.Log("Wtf..." + _value);
	}

}
