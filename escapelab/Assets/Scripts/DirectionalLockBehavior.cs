using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLockBehavior : MonoBehaviour {



	public bool hasNewInput = false;
	public string inputButton;

	public LEDManager ledManager; 


	string key = "cdabba"; 
	string attempt = ""; 

	// initialize resetColor function (defaultColor) 
	void Start () {

		GameObject g = GameObject.Find("LED");
		ledManager = g.GetComponent<LEDManager> ();
	}

	void Update () { 

		if(hasNewInput){
			hasNewInput = false;

			if (inputButton == "Up") {
				attempt = attempt+"a";
				Debug.Log (attempt);
			}
			if (inputButton == "Down") {
				attempt = attempt+"b";
				Debug.Log (attempt);
			}
			if (inputButton == "Left") {
				attempt = attempt+"c";
				Debug.Log (attempt);
			}
			if (inputButton == "Right") {
				attempt = attempt+"d";
				Debug.Log (attempt);
			}

		}


		if (attempt.Length >= 6) { // only 6 inputs are allowed
			if (key == attempt) { // if key and attempt strings are matching
				ledManager.changeColor = true; // change color from red to green
			}
			else {
				attempt = ""; // else reset attempt string
			}
		}

	}



}
