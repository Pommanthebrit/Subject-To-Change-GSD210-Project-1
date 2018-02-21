using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//script written by Aston Olsen

public class Shoot : MonoBehaviour {

	Animator myAnimator;
	AudioSource myAudioSource;
	public AudioClip[] shoot;

	public GameObject myProjectile, LeftBarrel, RightBarrel;
	public float bulletSpeed;

	void Start () { // Use this for initialization
		myAnimator = GetComponent<Animator> ();
		myAudioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		//if (Input.GetTouch (0).phase == TouchPhase.Began) {
		if (Input.GetButtonDown ("Fire1")) { //checks if fire button is being pressed

			myAnimator.SetTrigger ("Shoot");
			myAudioSource.PlayOneShot (shoot[Random.Range (0, shoot.Length)]);

			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition); //Gets the mouse postion.
			//Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, worldMousePos - transform.position); //Rotations the projectile towards the mouse position
			//transform.rotation = Quaternion.LookRotation (Vector3.forward, touchPos - new Vector2(transform.position.x,transform.position.y));
			Vector2 dir = (Vector2)((worldMousePos - transform.position)); //sets the vector from current position towards the mouse position.
			//Vector2 dir = touchPos - (new Vector2(transform.position.x, transform.position.y));

			dir.Normalize (); //normalizes the vector
			GameObject bullet = Instantiate (myProjectile, LeftBarrel.transform.position, Quaternion.identity)as GameObject; //spawns a projectile from the left turret barrell
			GameObject bullet2 = Instantiate (myProjectile, RightBarrel.transform.position, Quaternion.identity)as GameObject; //spawns a projectile from the right turret barrell
			bullet.GetComponent<Rigidbody2D> ().velocity = dir * bulletSpeed; //Sets projectile speed.
			bullet.transform.rotation = Quaternion.LookRotation (Vector3.forward, worldMousePos - transform.position); //Rotates the projectile to face the direction of travel
			//bullet.transform.rotation = Quaternion.LookRotation (Vector3.forward, touchPos - new Vector2(transform.position.x,transform.position.y));
			bullet2.GetComponent<Rigidbody2D> ().velocity = dir * bulletSpeed; //Sets projectile speed.
			bullet2.transform.rotation = Quaternion.LookRotation (Vector3.forward, worldMousePos - transform.position); //Rotates the projectile to face the direction of travel
			//bullet2.transform.rotation = Quaternion.LookRotation (Vector3.forward, touchPos - new Vector2(transform.position.x,transform.position.y));
		}
	}
}