using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		//Destroy bullet if goes out of camera bounds (at top of screen)
		Vector2 maxMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		if(transform.position.y > maxMoveLimit.y) {
			Destroy (gameObject);
		}
	}
}
