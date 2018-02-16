using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyK : MonoBehaviour {

	GameController myGameController; //Speak to GC to increases score
	GameObject player; //Locate player position
	float mySpeed;
	bool scoreGiven = false;

	// Can be "[SerializeField] Transform[] waypoints;" if you did simply put ("waypoints[num].position" instead of "waypoints[num].transform.position")
	public GameObject [] waypoints;

	public int num = 0;

	// Private float availible in the editor
	[SerializeField] float demonstration;

	public float minDist;
	public float speed;
	public bool rand = false ;
	public bool go = true ;

	void Start () {
		myGameController = FindObjectOfType <GameController> ();

		mySpeed = Random.Range (1.4f, 2.2f); //Slightly differs speed of each enemy that spawns
		player = GameObject.Find ("Player"); //Locate player position
	}

	void Update () {
		if (player != null) {
			float dist = Vector3.Distance (gameObject.transform.position, waypoints [num].transform.position);
			if (go) {
				if (dist > minDist) {
					Move ();
				} else {
					if (!rand) {
						if (num + 1 == waypoints.Length) {
							num = 0;
						} else {
							num++;
						}
					} else {
						num = Random.Range (0, waypoints.Length);
					}
				}
			}
		}

		//Destroy enemy if goes out of camera bounds (at bottom of screen)
		Vector2 minMoveLimit = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if (transform.position.y < minMoveLimit.y) {

			myGameController.myHealth += -1;

			Debug.Log ("Score: " + myGameController.myScore);
			Debug.Log ("Player health: " + myGameController.myHealth);

			Destroy (gameObject);
		}
	}

	//Destroys enemy if shot by player bullet, increases score
	void OnCollisionEnter2D(Collision2D collider) {
		//Debug.Log (gameObject + " hit by " + collider.gameObject.name);
		if (scoreGiven == false) {
			if (collider.gameObject.tag == "Bullet") {
				myGameController.myScore += 10;
				Debug.Log ("Score " + myGameController.myScore);
				Destroy (gameObject);
			}
			scoreGiven = true; //Uses bool to ensure score is not given twice (for each player bullet)
		}
	}

	public void Move(){

		//Change made here
		Vector3 vectorToTarget = waypoints[num].transform.position - this.transform.position;
		//print(vectorToTarget);
		float angleToTargetDeg = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angleToTargetDeg, Vector3.forward);

		//Change made here
		gameObject.transform.position += gameObject.transform.right * speed * Time .deltaTime;
	}
}