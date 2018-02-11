using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script written by Chris & Aston Olsen

public class EnemyA : MonoBehaviour {

	GameController myGameController;
	GameObject player;
	float mySpeed;

	void Start () {
		mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
		player = GameObject.Find ("Player"); //Locate player position
	}

	void Update () {
		if (player != null) {
			
		}

		//Destroy enemy if goes out of camera bounds (at bottom of screen)
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if(transform.position.y < minMoveLimit.y) {

			myGameController.myScore += -10;
			myGameController.myHealth += -1;

			Debug.Log ("Score: " + myGameController.myScore);
			Debug.Log ("Player health: " + myGameController.myHealth);

			Destroy (gameObject);
		}
	}
}