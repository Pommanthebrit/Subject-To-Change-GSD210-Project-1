using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour {

	GameController myGameController;
	GameObject player;
	float mySpeed;

	void Start () {
		mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
		player = GameObject.Find ("Player"); //Locate player position
	}

	void Update () {
		if (player != null) {
			//Rotates and moves enemy towards player position
			transform.position = Vector2.MoveTowards (transform.position, player.transform.position, mySpeed * Time.deltaTime);
			transform.up = player.transform.position - transform.position;
		}
	}
}