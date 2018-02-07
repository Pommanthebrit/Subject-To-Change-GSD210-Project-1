using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	#region Enemy Variables
	public GameObject[] myEnemy;
	float minSpawnRate, maxSpawnRate;
	#endregion

	#region Player Variables
	public int myScore;
	public int myHealth;
	#endregion

	void Start () {
		minSpawnRate = 1.2f;
		maxSpawnRate = 1.8f;
		InvokeRepeating ("SpawnEnemy", 6f, Random.Range(minSpawnRate, maxSpawnRate));
		InvokeRepeating ("IncreaseSpawn", 20f, 12f);
	}
	
	void Update () {
		//Prevents spawnrate from getting TOO fast
		minSpawnRate = Mathf.Clamp (minSpawnRate, 0.4f, 1f);
		maxSpawnRate = Mathf.Clamp (maxSpawnRate, 1f, 2f);
	}

	void SpawnEnemy () {
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.05f));
		Vector2 maxMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0.95f, 1));

		GameObject spawnEnemy = (GameObject)Instantiate (myEnemy [Random.Range (0, myEnemy.Length)]);
		spawnEnemy.transform.position = new Vector2 (Random.Range (minMoveLimit.x, maxMoveLimit.x), maxMoveLimit.y);
	}

	void IncreaseSpawn () {
		//Spawnrate gets progressively faster in 0.1sec increments
		minSpawnRate = minSpawnRate - 0.05f;
		maxSpawnRate = maxSpawnRate - 0.05f;
		//Debug.Log (minSpawnRate + " rate increased!");
		//Debug.Log (maxSpawnRate + " rate increased!");
	}
}