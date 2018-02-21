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
	void OnCollisionEnter2D(Collision2D other) {
		//Debug.Log ("Player hit by " + collider.gameObject.name);

		if (other.gameObject.tag == "Enemy") {
			TakeDamage ();
			Destroy (other.gameObject);
		}
	}

	public void TakeDamage() {
		StartCoroutine(DamageBlink());

		myGameController.myHealth += -1;
		Debug.Log ("Player health " + myGameController.myHealth);
		Debug.Log ("Score " + myGameController.myScore);
	}

	IEnumerator DamageBlink() { //coroutine for making the player ship flash when taking damage
		GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0); //changes ship colour to red
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1); //changes ship back to previous colour
	}
}