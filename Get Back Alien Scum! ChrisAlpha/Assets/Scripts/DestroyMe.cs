using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float destroyDelay;

	//Simple script to destroy a game object after its instantiation
	void Start () {
		Invoke ("DestroySelf", destroyDelay);
	}

	void DestroySelf () {
		Destroy (gameObject);
	}
}
