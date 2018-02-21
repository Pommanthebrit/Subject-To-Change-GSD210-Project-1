using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	#region Enemy Variables
	public GameObject[] myEnemy;
	float minSpawnRate, maxSpawnRate; //Min and max amount of time between spawning new enemies
	#endregion

	#region Player Variables
	public int myScore;
	public int myHealth;
	public GameObject player;
	private Player playerCtrl;
	#endregion

	#region Scoring
	bool paused;
	public GameObject scoreBoard, nameInputBox, submitButton, quitToMenuButton, pauseMenu; //UI objects that can be enabled or disabled as required
	public InputField playerName; //Player name input on scoreboard
	#endregion

	void Start () {
		paused = false;
		//Ensures all menus and timescale are reset for game start
		Time.timeScale = 1f;

		//Runs a repeating function to spawn enemies at whatever the spawn rate currently is
		minSpawnRate = 1f;
		maxSpawnRate = 1.8f;
		InvokeRepeating ("SpawnEnemy", 4f, Random.Range(minSpawnRate, maxSpawnRate));
		InvokeRepeating ("IncreaseSpawn", 20f, 12f);

		//Gets reference to player
		player = GameObject.FindGameObjectWithTag("Player");
		playerCtrl = player.GetComponent<Player>();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			Pause ();
		}

		//Prevents spawnrate from becoming too fast to keep up with
		minSpawnRate = Mathf.Clamp (minSpawnRate, 0.4f, 1f);
		maxSpawnRate = Mathf.Clamp (maxSpawnRate, 0.8f, 1.8f);

		//Game end
		if (myHealth <= 0) {
			GameOver ();
		}
	}

	void SpawnEnemy () {
		//Defines the top left and top right edges of where the game camera can see
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0.05f));
		Vector2 maxMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0.95f, 1));

		//Spawns enemies at random points at the top of the screen, within camera bounds
		GameObject spawnedEnemy = (GameObject)Instantiate (myEnemy [Random.Range (0, myEnemy.Length)]);
		EnemyController spawnedEnemyCtrl = spawnedEnemy.GetComponent<EnemyController>();
		spawnedEnemyCtrl._player = player;
		spawnedEnemyCtrl._gc = this;
		spawnedEnemyCtrl._playerCtrl = playerCtrl;
		spawnedEnemy.transform.position = new Vector2 (Random.Range (minMoveLimit.x, maxMoveLimit.x), maxMoveLimit.y);
	}

	void IncreaseSpawn () {
		//Spawnrate becomes progressively faster in small increments
		minSpawnRate = minSpawnRate - 0.04f;
		maxSpawnRate = maxSpawnRate - 0.04f;
		//Debug.Log (minSpawnRate + " rate increased!");
		//Debug.Log (maxSpawnRate + " rate increased!");
	}

	public void GameOver() { //function for game ending
		Pause(); //calls pause function
		scoreBoard.SetActive (true); //Enables the scoreboard game object
	}

	public void Scoreboard(){ //function for entering name on scoreboard. This function will be called by clicking the "Submit" button on the scoreboar (after the player has entered their name)
		GetComponent<ScoreBoardController> ().CheckForHighScore (myScore, playerName.text); //calls CheckForHighScore function from ScoreboardController script
		nameInputBox.SetActive (false); //Disables name input box
		submitButton.SetActive (false); //Disables submit button
		quitToMenuButton.SetActive (true); //Enables the Quit to main menu button
	}

	public void Pause () {
		if (paused == false) {
			pauseMenu.SetActive (true); //enables pause menu
			paused = true; //sets pause variable to true
			Time.timeScale = 0f; //sets timescale to 0 (paused)
			GameObject playerObject = GameObject.FindWithTag("Player"); //finds player
			playerObject.GetComponent<Shoot>().enabled = false; //disables shoot script
		} else {
			pauseMenu.SetActive (false); //enables pause menu
			paused = false; //sets pause variable to true
			Time.timeScale = 1f; //sets timescale to 0 (paused)
			GameObject playerObject = GameObject.FindWithTag("Player"); //finds player
			playerObject.GetComponent<Shoot>().enabled = true; //enables shoot script
		}
	}
}