using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	private int scoreValue = 5;
	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		if(gameController == null){
			Debug.Log ("Cannot find GameController script");
		}
	}
}
