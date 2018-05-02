using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLockController : MonoBehaviour {
	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	AudioSource sound;
    float timer;
	public bool hasInput = false;
	public bool runClickEffect = false;


	public TimerLockLEDManager ledManager; 

	//string attempt = "";
    //float count = 0;

	// initialize resetColor function (defaultColor) 
	void Start () {
		resetColor ();
		GameObject g = GameObject.Find("KeypadLED");
		ledManager = g.GetComponent<TimerLockLEDManager> ();
	}

    //void OnGUI()
    //{
    //    if (timer<10){
    //        GUI.Label(new Rect(100,100,200,200), "timer = " + timer);
    //    }
    //    else{
    //        GUI.Label(new Rect(100, 100, 200, 200), "over ");
    //    }
    //}

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


		/*(
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); 
			RaycastHit hit; 

			if (Physics.Raycast (ray, out hit, 100)) {
				//Debug.Log (hit.transform.gameObject.name); 
			}
			if (hit.transform.gameObject.name == "Keypad1") {
				//attempt = attempt+"Button Pressed";
                //Debug.Log ("Button 1 Pressed");
                timer += Time.deltaTime;
			}
            if (hit.transform.gameObject.name == "Keypad2")
            {
                //attempt = attempt+"Button Pressed";
                //Debug.Log("Button 2 Pressed");
            }

		}
		//if (attempt.Length == 4) { // only 6 inputs are allowed
		//	if (key == attempt) { // if key and attempt strings are matching
		//		ledManager.changeColor = true; // change color from red to green
		//	}
		//	else {
		//		attempt = ""; // else reset attempt string
		//	}
		//}
		*/
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