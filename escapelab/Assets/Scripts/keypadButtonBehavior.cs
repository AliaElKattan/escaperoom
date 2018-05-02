
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypadButtonBehavior : MonoBehaviour {
	AudioSource sound;
	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	public bool runClickEffect = false;
	public bool hasInput = false;

	// Use this for initialization
	void Start () {
		resetColor ();
	}

	// initialize audio source
	void Awake() { 
		sound = GetComponent<AudioSource> ();
	}




	// Update is called once per frame
	void Update () {

		if (hasInput) {
			hasInput = false;

			this.GetComponentInParent<TransformManager> ().hasNewInput = true;
			this.GetComponentInParent<TransformManager> ().inputButton = this.name;

		}

		if (runClickEffect) {
			runClickEffect = false;
			clickEffect ();
		}

	}


	/* when mouse is clicked, plays audio, changes color to 
	 * highlightColor and resets to defaultColor */

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


