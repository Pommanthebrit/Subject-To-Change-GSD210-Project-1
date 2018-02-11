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

	public GameObject scoreBoard, nameInputBox, submitButton, quitToMenuButton; //UI objects that can be enabled or disabled as required
	public InputField playerName; //Player name input on scorebaord

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


	public void GameOver(){ //function for GameOver
		Time.timeScale = 0f; //Sets time scale to 0 (paused)
		scoreBoard.SetActive (true); //Enables the scoreboard game object
	}

	public void Scoreboard(){ //function for entering name on scoreboard. This function will be called by clicking the "Submit" button on the scoreboard.
		GetComponent<ScoreBoardController> ().CheckForHighScore (myScore, playerName.text); //calls CheckForHighScore function from ScoreboardController script
		nameInputBox.SetActive (false); //Disables name input box
		submitButton.SetActive (false); //Disables submit button
		quitToMenuButton.SetActive (true); //enables the Quit to main menu button
	}

}