using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameController _gc;

	//Collision detection for player turret where applicable
	void OnCollisionEnter2D(Collision2D other) {
		//Debug.Log ("Player hit by " + collider.gameObject.name);

		if (other.gameObject.tag == "Enemy") {
			TakeDamage ();
			Destroy (other.gameObject);
		}
	}

	//Red tint to indicate player is being damaged
	public void TakeDamage() {
		StartCoroutine(DamageBlink());

		//Reduce health in GC script when damaged
		_gc.myHealth += -1;
		Debug.Log ("Player health " + _gc.myHealth);
	}

	IEnumerator DamageBlink() { //coroutine for making the player ship flash when taking damage
		GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0); //changes ship colour to red
		yield return new WaitForSeconds (0.1f);
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1); //changes ship back to previous colour
	}
}