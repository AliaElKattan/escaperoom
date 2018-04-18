using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {
	private SteamVR_TrackedController device;
	private SteamVR_TrackedObject trackedObject;

	// Use this for initialization
	void Start () {
		device = GetComponent<SteamVR_TrackedController> (); 
		device.TriggerClicked += Trigger;
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}

	void Trigger (object sender, ClickedEventArgs e) {
		Debug.Log ("Trigger has been pressed");
	}
	// Update is called once per frame
	void Update () {
		device = SteamVR_Controller.Input ((int)trackedObject.index);

		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Trigger Pressed");
		}
	}
}
