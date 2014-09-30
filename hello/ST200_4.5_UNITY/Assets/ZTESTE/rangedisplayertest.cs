using UnityEngine;
using System.Collections;

public class rangedisplayertest : MonoBehaviour {

	public GamePlayRangeDisplayer Range;
	public float m_TargetRange;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Range.Init(m_TargetRange);
	}
}
