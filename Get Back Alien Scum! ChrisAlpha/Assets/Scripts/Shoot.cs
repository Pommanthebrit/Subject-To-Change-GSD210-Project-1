using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour {

	public GameObject myProjectile, LeftBarrel, RightBarrel;
	public float bulletSpeed;

		void Update () {

//			if (Input.GetTouch (0).phase == TouchPhase.Began) {
			if (Input.GetButtonDown("Fire1")) {
//				Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//				Vector2 dir = touchPos - (new Vector2(transform.position.x, transform.position.y));

				Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);	
				transform.rotation = Quaternion.LookRotation(Vector3.forward, worldMousePos- transform.position);
				Vector2 dir = (Vector2)((worldMousePos - transform.position));
				dir.Normalize ();

				GameObject bullet = Instantiate (myProjectile, LeftBarrel.transform.position, Quaternion.identity)as GameObject;
				GameObject bullet2 = Instantiate (myProjectile, RightBarrel.transform.position, Quaternion.identity)as GameObject;

				bullet.GetComponent<Rigidbody2D> ().velocity = dir * bulletSpeed; 
				bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, worldMousePos- transform.position);

				bullet2.GetComponent<Rigidbody2D> ().velocity = dir * bulletSpeed; 
				bullet2.transform.rotation = Quaternion.LookRotation(Vector3.forward, worldMousePos- transform.position);
			}			
	}
}