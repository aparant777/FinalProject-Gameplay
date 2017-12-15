using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DisplayTime : MonoBehaviour {


	public float timeRemaining;
	public Image scoreTextImg;
	public Text scoreText;
	public Image gameOverImg;
	public Text gameOver;
	public Text displayRemainingTime;
	public Text LeftObjects;
	public Text restartText;
	public String timeLeft;
	public GameObject ejector1;
	public GameObject ejector2;
	public GameObject[] remainingObjects;
	public bool runOnlyOnce;
	public DestroyScript ds;
	
	void Awake(){
		gameOverImg.enabled = false;
		gameOver.enabled = false;
		//restartText.enabled = false;
		scoreTextImg.enabled = false;
	}

	void Start(){
		runOnlyOnce = true;
	}
		
	void Update(){
		//ds = new DestroyScript();
		timeRemaining -= Time.deltaTime;
		if(timeRemaining >=0)
			displayRemainingTime.text = " "+(int)timeRemaining;

		if(timeRemaining < 0){
			Destroy(ejector1);
			Destroy(ejector2);
			//displayRemainingTime.text = "Remaining Time is 0";

			if(runOnlyOnce){
				remainingObjects = GameObject.FindGameObjectsWithTag("Blocks");
			}

			runOnlyOnce = false;	//so as not to again count the objects.
			gameOverImg.enabled = true;
			gameOver.enabled = true;
			scoreTextImg.enabled = true;
			scoreText.text = "You caught "+remainingObjects.Length+ " objects";
			//LeftObjects.text = "You lost "+ds.destroyedObjects+" objects";
		}
	}
}
