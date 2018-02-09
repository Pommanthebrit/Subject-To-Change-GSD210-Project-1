using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject myBullet, myBulletSpawns;

	void Start () {
		
	}
	
	void Update () {
		//Fire bullet from its spawn positions --- modify the input for touch screen / mobile
		if(Input.GetButtonDown("Shoot")) {
			GameObject shootMyBullet = (GameObject)Instantiate (myBullet);
			shootMyBullet.transform.position = myBulletSpawns.transform.position;
		}
	}
}