using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text diamondText;
	public Text goldText;
	//public GUIText gameOverText;

	private bool gameOver;
	private bool gameWin;
	private bool restart;
	private int diamond;
	private int gold;

	private int lose = 0;



	// Use this for initialization
	void Start () {
		gameOver = false;
		gameWin = false;
		restart = false;
		//gameOverText.text = "";
		diamond = 0;
		gold = 0;
		UpdateScore ();
	}

	void Update(){
		if(restart){
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public void AddDiamond(int newScoreValue){
		diamond += newScoreValue;
		UpdateScore ();
	}

	public void AddGold(int newScoreValue){
		gold += newScoreValue;
		UpdateScore ();
	}
		
	void UpdateScore(){
		diamondText.text = "Diamond : " + diamond;
		goldText.text = "Gold : " + gold;
		print (diamond);
		print (gold);
	}

	public void GameOver(){
		//gameOverText.text = "Game Over";
		gameOver = true;	
	}

	public void GameWin(){
		//gameOverText.text = "YOU WIN !";
		gameWin = true;
	}
}
