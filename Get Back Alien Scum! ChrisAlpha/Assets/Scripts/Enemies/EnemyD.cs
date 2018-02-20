using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyD : EnemyController {

	float mySpeed;

	void Start () {
		mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
	}

	void Update () 
	{
	}
}