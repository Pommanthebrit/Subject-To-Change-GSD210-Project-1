using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : EnemyController {


	float mySpeed;

	void Start () {
	//	mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
	//	player = GameObject.Find ("Player"); //Locate player position
	}

	void Update () {
		if (_player != null) {

		}

		//Destroy enemy if goes out of camera bounds (at bottom of screen)
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if(transform.position.y < minMoveLimit.y) {

			_gc.myHealth += -1;

			Debug.Log ("Score: " + _gc.myScore);
			Debug.Log ("Player health: " + _gc.myHealth);

			Destroy (gameObject);
		}
	}
}