using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows access to UI elemenmts

//script written by Aston Olsen

public class MusicController : MonoBehaviour {

	public Slider Volume; //UI slide for music volume
	public AudioSource myMusic; //music audio source

	void Start () { // Use this for initialization
		Volume.value = PlayerPrefs.GetFloat("Volume"); //sets volume to value stored in player prefs at Start
	}

	void Update () { // Update is called once per frame
		myMusic.volume = Volume.value; //sets music volume to value from volume slider 
		PlayerPrefs.SetFloat("Volume",Volume.value); //stores volume level in player prefs
	}

}
