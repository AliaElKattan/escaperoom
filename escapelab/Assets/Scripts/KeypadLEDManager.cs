using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadLEDManager : MonoBehaviour {

	public int lightFactor = 0;

	public GameObject LED1;
	public GameObject LED2;
	Light first;
	Light two;

	public bool changeColor = false; 

	// Use this for initialization
	void Start () {
		first = LED1.GetComponent<Light>();
		two = LED2.GetComponent<Light>();


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
		if (first!= null && two!=null) { // If we have a light as a field
			
			Color c = new Color ();
			c.r = 1f - lightFactor / 100f;
			c.g = lightFactor / 100f;
			//c.b= lightFactor / 100f;
			c.a = 1f;
			first.color = c;
			two.color = c;
		}
	}

	void colorGreen() {
		if (first != null && two !=null) { // If we have a light as a field
			Color c = new Color ();
			c.g = 1f - lightFactor / 100f;
			c.r = lightFactor / 100f;
			//c.b= lightFactor / 100f;
			c.a = 1f;
			first.color = c;
			two.color = c;
		}
	}
}
