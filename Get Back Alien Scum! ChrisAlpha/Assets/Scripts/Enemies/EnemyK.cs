using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyK : MonoBehaviour {

	GameController myGameController; //Speak to GC to increases score
	GameObject player; //Locate player position
	bool scoreGiven = false;

	// Can be "[SerializeField] Transform[] waypoints;" if you put ("waypoints[num].position" instead of "waypoints[num].transform.position")
	public GameObject [] waypoints;

	public int num = 0;

	//Private float available in the editor
	[SerializeField] float demonstration;

	public float minDist;
	public float speed;
	public bool rand = false ;
	public bool go = true ;

	void Start () {
		myGameController = FindObjectOfType <GameController> ();

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
	}

//EDIT
//	//Destroys enemy if shot by player bullet, increases score
//	void OnCollisionEnter2D(Collision2D collider) {
//		//Debug.Log (gameObject + " hit by " + collider.gameObject.name);
//		if (scoreGiven == false) {
//			if (collider.gameObject.tag == "Bullet") {
//				myGameController.myScore += 10;
//				Debug.Log ("Score " + myGameController.myScore);
//				Destroy (gameObject);
//			}
//			scoreGiven = true; //Uses bool to ensure score is not given twice (for each player bullet)
//		}
//	}
//END OF EDIT

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