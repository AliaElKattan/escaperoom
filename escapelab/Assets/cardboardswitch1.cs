using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardboardswitch1 : MonoBehaviour {

	public KeypadLEDManager ledControl; 
    public GameObject openBox;
    public GameObject closedBox;
    public GameObject light;
    public GameObject audio;
//	public GameObject led;

	// Use this for initialization
	void Start () {
        audio.SetActive(false);
        openBox.SetActive(false);
        light.SetActive(false);

		GameObject led = GameObject.Find("KeypadLED");
		ledControl = led.GetComponent<KeypadLEDManager> ();

    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown("space"))

		if (ledControl.changeColor == true)
		{
            Debug.Log("space pressed");
            audio.SetActive(true);
            closedBox.SetActive(false);
            openBox.SetActive(true);
            light.SetActive(true);  
        }

    }
}
