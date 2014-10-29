using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class dijkstra_test_code : MonoBehaviour {

	public int StartIndex = 1;
	public int EndIndex = 2;

	protected DijkstraGraphManager graphmanager;

	void Awake()
	{
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			PrintHAHA();
		}
	}

	public void Init()
	{
		graphmanager = new DijkstraGraphManager();
		graphmanager.AddPoint(0);
		graphmanager.AddPoint(1);
		graphmanager.AddPoint(2);
		graphmanager.AddPoint(3);
		graphmanager.AddPoint(4);
		graphmanager.AddPoint(5);
		graphmanager.AddPoint(6);

		graphmanager.AddEdge(0,1,10f);
		graphmanager.AddEdge(1,2,10f);
		graphmanager.AddEdge(1,3,30f);
		graphmanager.AddEdge(1,4,15f);
		graphmanager.AddEdge(2,5,20f);
		graphmanager.AddEdge(3,6,5f);
		graphmanager.AddEdge(4,3,5f);
		graphmanager.AddEdge(4,6,20f);
		graphmanager.AddEdge(5,6,20f);
		graphmanager.AddEdge(6,4,20f);
	}

	public void PrintHAHA()
	{
		string printpath = "start: ";
		foreach(int index in graphmanager.GetPath(StartIndex, EndIndex))
		{
			printpath += index + " to ";
		}

		Debug.Log(printpath);
	}
}
