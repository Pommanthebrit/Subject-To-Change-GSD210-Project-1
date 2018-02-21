using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : EnemyController {

	// Private Variables
	private float mySpeed;
	private Vector3 moveDir;
	private int movement = 1;
	private float startHealth;
	[SerializeField] private float directionChangeTime; // time betweenwhen the 

	void Start ()
	{
		startHealth = _health;


		mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
		_player = GameObject.Find ("Player"); //Locate player position
		StartCoroutine("ChangeDir"); // Starts the Coroutine that makes sure that the Enemy go left and right


	}
	// change the number so that the direction that the Enemy will go is updated
	IEnumerator ChangeDir() {
		while(true)
		{
			movement = 1;
			yield return new WaitForSeconds(directionChangeTime);
			movement = 2;
			yield return new WaitForSeconds(directionChangeTime);

		}
	}



	void Update () {
		if (_player != null) {
			// calls the switch statement that checks if the way the Enemy should move has changed
			PerformMove();


			// checks to see if the 
			if(_health < startHealth)
			{
				movement = 3;
			}
		}
	}
		
	// makes the Enemy move and look at the player
		void PerformMove (){

		switch (movement) {
		case 1:
			transform.position = Vector2.MoveTowards (transform.position, Vector2.left, mySpeed * Time.deltaTime);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, transform.position - _player.transform.position);
			break;
		case 2:
			transform.position = Vector2.MoveTowards (transform.position, Vector2.right, mySpeed * Time.deltaTime);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, transform.position - _player.transform.position);
			break;
		case 3:
			transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, mySpeed * Time.deltaTime);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, transform.position - _player.transform.position);
			break;
		default:
			transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, mySpeed * Time.deltaTime);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, transform.position - _player.transform.position);
			break;
		}
	}
}