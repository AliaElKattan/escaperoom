using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour {
	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	AudioSource sound;

	public KeypadLEDManager ledManager; 
	public bool hasNewInput = false;
	public GameObject touchedButton;

	string key = "2010";
	string attempt = ""; 
	int newNum;

	// initialize resetColor function (defaultColor) 
	void Start () {
		resetColor ();
		GameObject g = GameObject.Find("KeypadLED");
		ledManager = g.GetComponent<KeypadLEDManager> ();
	}


	void Update () { 
       
		if (hasNewInput) {
			
			hasNewInput = false;

			if (touchedButton.name == "Keypad0") {
				attempt = attempt+"0";
				Debug.Log (attempt);
				newNum = 0;
			}
			if (touchedButton.name == "Keypad1") {
				attempt = attempt+"1";
				Debug.Log (attempt);
				newNum = 1;
			}
			if (touchedButton.name == "Keypad2") {
				attempt = attempt+"2";
				Debug.Log (attempt);
				newNum = 2;

			}
			if (touchedButton.name == "Keypad3") {
				attempt = attempt+"3";
				Debug.Log (attempt);
				newNum = 3;

			}
			if (touchedButton.name == "Keypad4") {
				attempt = attempt+"4";
				Debug.Log (attempt);
				newNum = 4;

			}
			if (touchedButton.name == "Keypad5") {
				attempt = attempt+"5";
				Debug.Log (attempt);
				newNum = 5;

			}
			if (touchedButton.name == "Keypad6") {
				attempt = attempt+"6";
				Debug.Log (attempt);
				newNum = 6;

			}
			if (touchedButton.name == "Keypad7") {
				attempt = attempt+"7";
				Debug.Log (attempt);
				newNum = 7;

			}
			if (touchedButton.name == "Keypad8") {
				attempt = attempt+"8";
				Debug.Log (attempt);
				newNum = 8;

			}
			if (touchedButton.name == "Keypad9") {
				attempt = attempt+"9";
				Debug.Log (attempt);
				newNum = 9;

			}


			PhotonView.RPC ("buttonInput", PhotonTargets.OthersBuffered, attempt);

		}
	}

	// initialize audio source
	void Awake() { 
		sound = GetComponent<AudioSource> ();
	}



	void clickEffect() { 
		//Debug.Log("clicked");
		sound.Play ();
		GetComponent<MeshRenderer> ().material.color = highlightColor;
		Invoke ("resetColor", resetDelay);
	}

	void resetColor() {
		GetComponent<MeshRenderer> ().material.color = defaultColor;

	}

	//handle keypad input from a user.
	[PunRPC] public void buttonInput(string attempt){


		clickEffect ();

		if (attempt.Length == 4) { // only 6 inputs are allowed
			if (key == attempt) { // if key and attempt strings are matching
				ledManager.changeColor = true; // change color from red to green
			}
			else {
				attempt = ""; // else reset attempt string
			}
		}

		if (PhotonView.isMine)
			PhotonView.RPC("buttonInput", PhotonTargets.OthersBuffered, attempt);
		
	}


}