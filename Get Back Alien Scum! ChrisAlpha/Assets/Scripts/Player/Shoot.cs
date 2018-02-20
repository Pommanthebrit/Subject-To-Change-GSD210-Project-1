﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//script written by Aston Olsen

public class Shoot : MonoBehaviour {

	Animator myAnimator;
	AudioSource myAudioSource;
	public AudioClip[] shoot;

	public GameObject myProjectile, LeftBarrel, RightBarrel;
	public float bulletSpeed;

	void Start () {
		myAnimator = GetComponent<Animator> ();
		myAudioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		//if (Input.GetTouch (0).phase == TouchPhase.Began) {
		if (Input.GetButtonDown ("Fire1")) {

			myAnimator.SetTrigger ("Shoot");
			myAudioSource.PlayOneShot (shoot[Random.Range (0, shoot.Length)]);

			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);	
			//Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			transform.rotation = Quaternion.LookRotation (Vector3.forward, worldMousePos - transform.position);
			//transform.rotation = Quaternion.LookRotation (Vector3.forward, touchPos - new Vector2(transform.position.x,transform.position.y));

			Vector2 dir = (Vector2)((worldMousePos - transform.position));
			//Vector2 dir = touchPos - (new Vector2(transform.position.x, transform.position.y));

			dir.Normalize ();
			GameObject bullet = Instantiate (myProjectile, LeftBarrel.transform.position, Quaternion.identity)as GameObject;
			GameObject bullet2 = Instantiate (myProjectile, RightBarrel.transform.position, Quaternion.identity)as GameObject;
			bullet.GetComponent<Rigidbody2D> ().velocity = dir * bulletSpeed; 

			bullet.transform.rotation = Quaternion.LookRotation (Vector3.forward, worldMousePos - transform.position);
			//bullet.transform.rotation = Quaternion.LookRotation (Vector3.forward, touchPos - new Vector2(transform.position.x,transform.position.y));

			bullet2.GetComponent<Rigidbody2D> ().velocity = dir * bulletSpeed; 

			bullet2.transform.rotation = Quaternion.LookRotation (Vector3.forward, worldMousePos - transform.position);
			//bullet2.transform.rotation = Quaternion.LookRotation (Vector3.forward, touchPos - new Vector2(transform.position.x,transform.position.y));
		}
	}
}