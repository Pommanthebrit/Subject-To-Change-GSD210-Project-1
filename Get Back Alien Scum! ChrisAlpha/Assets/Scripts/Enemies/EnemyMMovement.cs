using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMMovement : MonoBehaviour {

	// Public Variables
	public float rollDir;

	// Private Variables
	public GameObject[] enemyLines;
	public bool moveLeft = true;
	float speed = 100.0f;
	private Vector3 moveDir;


	void Awake ()
	{
		//enemyLines = ;
	}

	void Start ()
	{

	}

	void Update()
	{
		PerformMove();
	}

	void PerformMove()                                                                         // Moves the line of enemies left / right
	{
		if (moveLeft)
		{
			moveDir = new Vector3(1.0f, -1.0f, 0.0f);
			rollDir = moveDir.x;

			foreach (GameObject enemyLine in enemyLines)
			{
				enemyLine.transform.Translate(moveDir * Time.deltaTime * speed, Space.World);
			}
		}
		else
		{
			moveDir = new Vector3(-1.0f, -1.0f, 0.0f);
			rollDir = moveDir.x;

			foreach (GameObject enemyLine in enemyLines)
			{
				enemyLine.transform.Translate(moveDir * Time.deltaTime * speed, Space.World);
			}
		}
	}

/*	void CheckBoundary()                        
	{
		if (transform.position.x < boundaryLeft)
			enemyMovement.ChangeDir(false);
		else if (transform.position.x > boundaryRight)
			enemyMovement.ChangeDir(true);
	}*/
}
