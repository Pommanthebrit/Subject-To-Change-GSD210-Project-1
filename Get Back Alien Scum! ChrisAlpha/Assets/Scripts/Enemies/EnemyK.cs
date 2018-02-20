using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyK : EnemyController {

	public GameObject [] waypoints;

	public int num = 0;

	public float minDist;
	public float speed;
	public bool rand = false ;
	public bool go = true ;

	//Find waypoint and go to it, optional to hit waypoint early with minDist
	void Update () {
		if (_player != null) {
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
						//optional random waypoint selection
					} else {
						num = Random.Range (0, waypoints.Length);
					}
				}
			}
		}
	}

	//Getting Alien to move forward on a axis
	public void Move(){
		Vector3 vectorToTarget = waypoints[num].transform.position - this.transform.position;
		float angleToTargetDeg = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angleToTargetDeg, Vector3.forward);

		gameObject.transform.position += gameObject.transform.right * speed * Time .deltaTime;
	}
}