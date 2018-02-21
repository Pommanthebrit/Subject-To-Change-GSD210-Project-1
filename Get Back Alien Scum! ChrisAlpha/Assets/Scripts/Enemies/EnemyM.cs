using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : EnemyController {

	// Private Variables
	private float bankAngle = 45.0f;  // what angle the ship will rotate to on the z axis when moving
	private float rollDir;
	private float mySpeed;
	private bool moveLeft = true;
	private Vector3 moveDir;
	private float smooth = 2.0f; 
	private int movement = 1;
	private float startHealth;

	[SerializeField] private float directionChangeTime;

	private EnemyController _ec;
	// smooths angel rotation


	// How far right can the enemy ship go
	//private ss_Shoot ssShoot;

	void Start ()
	{
		startHealth = _health;
		_ec = GetComponent<EnemyController> ();

		//ssShoot = transform.GetComponent<ss_Shoot>();
		mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
		_player = GameObject.Find ("Player"); //Locate player position
		StartCoroutine("ChangeDir");


	}
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

		}

		if(_health < startHealth)
		{
			movement = 3;
		}

		//Destroy enemy if goes out of camera bounds (at bottom of screen)
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if(transform.position.y < minMoveLimit.y) {

			_gc.myHealth += -1;

			Debug.Log ("Score: " + _gc.myScore);
			Debug.Log ("Player health: " + _gc.myHealth);

			Destroy (gameObject);
		}
	}

	void FixedUpdate ()
	{
		UpdateOrientation(rollDir);
		PerformMove();
	}

	private void UpdateOrientation(float moveBy)                                                            // Tilts the enemy ship in the correct direction
	{
		Quaternion target;

		if (moveBy == 0.0f)
		{
			target = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * smooth);
		}
		else if (moveBy == 1.0f)
		{
			target = Quaternion.Euler(0.0f, 0f, bankAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		}
		else if (moveBy == -1.0f)
		{
			target = Quaternion.Euler(0.0f, 0f, -bankAngle);
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		}
	}


	/*void CheckBoundary()                                                                                    // Tells the movement script an enemy has reached the boundaries, change direction
	{
		if ((transform.position.x < boundaryLeft) || (transform.position.x > boundaryRight))
		{
			enemyMMovement.ChangeDir();

		}
	}*/




	public void EnemyFire ()
	{
		//ssShoot.EnemyShoot();
	}


	void PerformMove (){

		switch (movement) {
		case 1:
			transform.position = Vector2.MoveTowards (transform.position, Vector2.left, mySpeed * Time.deltaTime);
			break;
		case 2:
			transform.position = Vector2.MoveTowards (transform.position, Vector2.right, mySpeed * Time.deltaTime);
			break;
		case 3:
			transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, mySpeed * Time.deltaTime);
			break;
		default:
			transform.position = Vector2.MoveTowards (transform.position, _player.transform.position, mySpeed * Time.deltaTime);
			break;
		}
	}
}