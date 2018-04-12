using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour {
	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	AudioSource sound;

	public KeypadLEDManager ledManager; 


	string key = "2010"; 
	string attempt = ""; 

	// initialize resetColor function (defaultColor) 
	void Start () {
		resetColor ();
		GameObject g = GameObject.Find("KeypadLED");
		ledManager = g.GetComponent<KeypadLEDManager> ();
	}

	void Update () { 
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hit; 

			if (Physics.Raycast (ray, out hit, 100)) {
				Debug.Log (hit.transform.gameObject.name); 
			}
			if (hit.transform.gameObject.name == "Keypad0") {
				attempt = attempt+"0";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad1") {
				attempt = attempt+"1";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad2") {
				attempt = attempt+"2";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad3") {
				attempt = attempt+"3";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad4") {
				attempt = attempt+"4";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad5") {
				attempt = attempt+"5";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad6") {
				attempt = attempt+"6";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad7") {
				attempt = attempt+"7";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad8") {
				attempt = attempt+"8";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Keypad9") {
				attempt = attempt+"9";
				Debug.Log (attempt);
			}

		}
		if (attempt.Length == 4) { // only 6 inputs are allowed
			if (key == attempt) { // if key and attempt strings are matching
				ledManager.changeColor = true; // change color from red to green
			}
			else {
				attempt = ""; // else reset attempt string
			}
		}
	}

	// initialize audio source
	void Awake() { 
		sound = GetComponent<AudioSource> ();
	}

	/* when mouse is clicked, plays audio, changes color to 
	 * highlightColor and resets to defaultColor */
	void OnMouseDown() {
		clickEffect ();

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

}