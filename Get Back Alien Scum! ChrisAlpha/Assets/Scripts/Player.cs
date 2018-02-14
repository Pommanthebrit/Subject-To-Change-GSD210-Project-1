using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	GameController myGameController;

	void Start () {
		myGameController = FindObjectOfType<GameController> ();
	}
	
	void Update () {
		
	}

	//Collision detection for player turret where applicable
	void OnCollisionEnter2D(Collision2D collider) {
		Debug.Log ("Player hit by " + collider.gameObject.name);

		if (collider.gameObject.tag == "Enemy") {
			myGameController.myHealth += -1;
			Debug.Log ("Player health " + myGameController.myHealth);
			Destroy (collider.gameObject);
			Debug.Log ("Score " + myGameController.myScore);
		}
	}
}