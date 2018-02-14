using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : MonoBehaviour {

	GameController myGameController; //Speak to GC to increases score
	GameObject player; //Locate player position
	float mySpeed;
	bool scoreGiven = false;

	void Start () {
		myGameController = FindObjectOfType <GameController> ();

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

	//Destroys enemy if shot by player bullet, increases score
	void OnCollisionEnter2D(Collision2D collider) {
		//Debug.Log (gameObject + " hit by " + collider.gameObject.name);
		if (scoreGiven == false) {
			if (collider.gameObject.tag == "Bullet") {
				myGameController.myScore += 10;
				Debug.Log ("Score " + myGameController.myScore);
				Destroy (gameObject);
			}
			scoreGiven = true; //Uses bool to ensure score is not given twice (for each player bullet)
		}
	}
}