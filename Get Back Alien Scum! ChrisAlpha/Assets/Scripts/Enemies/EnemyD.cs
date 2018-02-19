using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD : MonoBehaviour {

	GameController myGameController; //Speak to GC to increases score
	GameObject player; //Locate player position
	float mySpeed;
	bool scoreGiven = false;

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
			
			myGameController.myHealth += -1;

			Debug.Log ("Score: " + myGameController.myScore);
			Debug.Log ("Player health: " + myGameController.myHealth);

			Destroy (gameObject);
		}
	}

	//EDIT
	//	//Destroys enemy if shot by player bullet, increases score
	//	void OnCollisionEnter2D(Collision2D collider) {
	//		//Debug.Log (gameObject + " hit by " + collider.gameObject.name);
	//		if (scoreGiven == false) {
	//			if (collider.gameObject.tag == "Bullet") {
	//				myGameController.myScore += 10;
	//				Debug.Log ("Score " + myGameController.myScore);
	//				Destroy (gameObject);
	//			}
	//			scoreGiven = true; //Uses bool to ensure score is not given twice (for each player bullet)
	//		}
	//	}
	//END OF EDIT
}