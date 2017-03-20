using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void Play(){
		Debug.Log ("Play pressed");
		SceneManager.LoadScene (1);
	}

	public void Quit(){
		Debug.Log ("Quit pressed");
		Application.Quit ();
	}

}
