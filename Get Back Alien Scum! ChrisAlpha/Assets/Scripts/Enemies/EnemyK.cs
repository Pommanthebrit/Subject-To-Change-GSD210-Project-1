using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyK : EnemyController {

	// Can be "[SerializeField] Transform[] waypoints;" if you put ("waypoints[num].position" instead of "waypoints[num].transform.position")
	public GameObject [] waypoints;

	public int num = 0;

	//Private float available in the editor
	[SerializeField] float demonstration;

	public float minDist;
	public float speed;
	public bool rand = false ;
	public bool go = true ;

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
					} else {
						num = Random.Range (0, waypoints.Length);
					}
				}
			}
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