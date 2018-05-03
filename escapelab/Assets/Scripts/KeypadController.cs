
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour {


	public KeypadLEDManager ledManager; 
	public bool hasNewInput = false;
	public string inputButton;

	string key = "2010";
	string attempt = ""; 
	int newNum;

	// initialize resetColor function (defaultColor) 
	void Start () {


	}


	void Update () { 

		if (hasNewInput) {
			hasNewInput = false;

			if (inputButton == "Keypad0") {
				attempt = attempt+"0";
				Debug.Log (attempt);
				newNum = 0;
			}
			if (inputButton == "Keypad1") {
				attempt = attempt+"1";
				Debug.Log (attempt);
				newNum = 1;
			}
			if (inputButton == "Keypad2") {
				attempt = attempt+"2";
				Debug.Log (attempt);
				newNum = 2;

			}
			if (inputButton == "Keypad3") {
				attempt = attempt+"3";
				Debug.Log (attempt);
				newNum = 3;

			}
			if (inputButton == "Keypad4") {
				attempt = attempt+"4";
				Debug.Log (attempt);
				newNum = 4;

			}
			if (inputButton == "Keypad5") {
				attempt = attempt+"5";
				Debug.Log (attempt);
				newNum = 5;

			}
			if (inputButton == "Keypad6") {
				attempt = attempt+"6";
				Debug.Log (attempt);
				newNum = 6;

			}
			if (inputButton == "Keypad7") {
				attempt = attempt+"7";
				Debug.Log (attempt);
				newNum = 7;

			}
			if (inputButton == "Keypad8") {
				attempt = attempt+"8";
				Debug.Log (attempt);
				newNum = 8;

			}
			if (inputButton == "Keypad9") {
				attempt = attempt+"9";
				Debug.Log (attempt);
				newNum = 9;

			}

			GetComponentInChildren<TextMesh> ().text = attempt;

			if (attempt.Length >= 4) { // only 6 inputs are allowed
				if (key == attempt) { // if key and attempt strings are matching
					ledManager = GetComponentInChildren<KeypadLEDManager> ();
					ledManager.changeColor = true; // change color from red to green
					GameObject[] arr = GameObject.FindGameObjectsWithTag("box1");

					for(int i=0;i<2;i++){
						arr[i].GetComponent<cardboardswitch1>().solved = true;
					}
				
				}
				else {
					attempt = ""; // else reset attempt string
				}
			}
		}
	}

}