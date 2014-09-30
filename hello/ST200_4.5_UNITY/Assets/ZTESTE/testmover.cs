using UnityEngine;
using System.Collections;

public class testmover : MonoBehaviour {

	GameStageEnemyObject enemyobject;

	// Use this for initialization
	void Start () {
		enemyobject = GetComponent<GameStageEnemyObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		enemyobject.Process(Time.fixedDeltaTime);
	}
}
