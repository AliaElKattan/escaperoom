using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadLEDManager : MonoBehaviour {

	public int lightFactor = 0;

	public Light LED;


	public bool changeColor = false; 

	// Use this for initialization
	void Start () {
		LED = GetComponent<Light>();
	}

	// Update is called once per frame
	void Update () {
		if (changeColor == false) {
			colorRed ();
		} 
		else {
			colorGreen (); 
		}
	}



	void colorRed() {
		if (LED != null) { // If we have a light as a field
			Light l = LED.GetComponent<Light> (); // Get the Light component
			Color c = new Color ();
			c.r = 1f - lightFactor / 100f;
			c.g = lightFactor / 100f;
			//c.b= lightFactor / 100f;
			c.a = 1f;
			l.color = c;
		}
	}

	void colorGreen() {
		if (LED != null) { // If we have a light as a field
			Light l = LED.GetComponent<Light> (); // Get the Light component
			Color c = new Color ();
			c.g = 1f - lightFactor / 100f;
			c.r = lightFactor / 100f;
			//c.b= lightFactor / 100f;
			c.a = 1f;
			l.color = c;
		}
	}
}
