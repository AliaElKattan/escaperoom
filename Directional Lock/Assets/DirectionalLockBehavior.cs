using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLockBehavior : MonoBehaviour {

	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	AudioSource sound;

	public LEDManager ledManager; 


	string key = "cdabba"; 
	string attempt = ""; 

	// initialize resetColor function (defaultColor) 
	void Start () {
		resetColor ();
		GameObject g = GameObject.Find("LED");
		ledManager = g.GetComponent<LEDManager> ();
	}

	void Update () { 
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hit; 

			if (Physics.Raycast (ray, out hit, 100)) {
				Debug.Log (hit.transform.gameObject.name); 
			}
			if (hit.transform.gameObject.name == "Up") {
				attempt = attempt+"a";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Down") {
				attempt = attempt+"b";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Left") {
				attempt = attempt+"c";
				Debug.Log (attempt);
			}
			if (hit.transform.gameObject.name == "Right") {
				attempt = attempt+"d";
				Debug.Log (attempt);
			}
		}
		if (attempt.Length == 6) { // only 6 inputs are allowed
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
