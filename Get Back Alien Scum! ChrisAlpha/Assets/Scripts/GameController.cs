using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	#region Enemy Variables
	public GameObject[] myEnemy;
	float minSpawnRate, maxSpawnRate;
	#endregion

	void Start () {
		minSpawnRate = 0.8f;
		maxSpawnRate = 1.6f;
		InvokeRepeating ("SpawnEnemy", 6f, Random.Range(minSpawnRate, maxSpawnRate));
	}
	
	void Update () {
		
	}

	void SpawnEnemy () {
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.05f));
		Vector2 maxMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0.95f, 1));

		GameObject spawnEnemy = (GameObject)Instantiate (myEnemy [Random.Range (0, myEnemy.Length)]);
		spawnEnemy.transform.position = new Vector2 (Random.Range (minMoveLimit.x, maxMoveLimit.x), maxMoveLimit.y);
	}
}
