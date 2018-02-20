using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	public GameObject bulletDeath;

	void Update () {
		//Destroy enemy if goes out of camera bounds (at bottom and left of screen)
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if(transform.position.y < minMoveLimit.y || transform.position.x < minMoveLimit.x) {
			Destroy (gameObject);
		}

		//Destroy bullet if goes out of camera bounds (at top and right of screen)
		Vector2 maxMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if(transform.position.y > maxMoveLimit.y || transform.position.x > maxMoveLimit.x) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collider) {
		//Instantiate (bulletDeath, gameObject.transform.position, gameObject.transform.rotation);
		Destroy (gameObject);
	}
}