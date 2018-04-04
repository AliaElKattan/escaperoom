using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLockBehavior : MonoBehaviour {

	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	AudioSource sound;

	// initialize resetColor function (defaultColor) 
	void Start () {
		resetColor ();
	}

	// initialize audio source
	void Awake() { 
		sound = GetComponent<AudioSource> ();
	}

	/* when mouse is clicked, plays audio, changes color to 
	 * highlightColor and resets to defaultColor */
	void OnMouseDown() {
		//Debug.Log("clicked");
		sound.Play ();
		GetComponent<MeshRenderer> ().material.color = highlightColor;
		Invoke ("resetColor", resetDelay);
	}

	void resetColor() {
		GetComponent<MeshRenderer> ().material.color = defaultColor;
	}

}
