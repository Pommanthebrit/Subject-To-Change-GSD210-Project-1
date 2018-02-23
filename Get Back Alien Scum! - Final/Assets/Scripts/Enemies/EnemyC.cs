using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyC : EnemyController {

	float mySpeed;

	void Start () {
		mySpeed = Random.Range (1.6f, 2.6f); //Slightly differs speed of each enemy that spawns
	}

	void Update () {
		if (_player != null) {
			//Rotates and moves enemy towards player position
			transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, mySpeed * Time.deltaTime);
			transform.up = _player.transform.position - transform.position;
		}
	}
}