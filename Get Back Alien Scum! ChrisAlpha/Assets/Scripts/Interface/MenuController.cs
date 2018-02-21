using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //allows loading of scenes

//script written by Aston Olsen

public class MenuController : MonoBehaviour {

//	public void OpenSceneDelayed(string sceneName){ 
//		Invoke ("OpenScene", 1f); //Quits the application (Built game only, doesn't work within Unity editor)
//	}

	public void OpenScene(string sceneName){ //function for loading scnees
		SceneManager.LoadScene (sceneName); //Loads the assigned scene when this function is run
	}

	public void QuitDelayed(){ 
		Invoke ("Quit", 1f); //Quits the application (Built game only, doesn't work within Unity editor)
	}

	public void Quit(){ //function for quitting the game when Quit button is clicked
		print("Quitting game"); //"Displays "Quitting game" to console
		Application.Quit(); //Quits the application (Built game only, doesn't work within Unity editor)
	}

}