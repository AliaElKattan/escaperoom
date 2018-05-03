using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLockBehavior : MonoBehaviour {



	public bool hasNewInput = false;
	public string inputButton;

	public LEDManager ledManager; 
	string solution;

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
				solution += "R ";
				Debug.Log (attempt);
			}
			if (inputButton == "Down") {
				attempt = attempt+"b";
				Debug.Log (attempt);
				solution += "Y ";

			}
			if (inputButton == "Left") {
				attempt = attempt+"c";
				Debug.Log (attempt);
				solution += "B ";
			}
			if (inputButton == "Right") {
				attempt = attempt+"d";
				Debug.Log (attempt);
				solution += "G ";
			}
			GetComponentInChildren<TextMesh> ().text = solution;

		}


		if (attempt.Length >= 6) { // only 6 inputs are allowed
			if (key == attempt) { // if key and attempt strings are matching
				ledManager.changeColor = true; // change color from red to green
				GameObject[] arr = GameObject.FindGameObjectsWithTag("box3");

				for(int i=0;i<2;i++){
					arr[i].GetComponent<cardboardswitch1>().solved = true;
				}
			}
			else {
				attempt = ""; // else reset attempt string
				solution = "";
			}
		}

	}



}
