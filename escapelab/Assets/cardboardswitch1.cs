using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardboardswitch1 : MonoBehaviour {

    public GameObject openBox;
    public GameObject closedBox;
    public GameObject light;
    public GameObject audio;

	// Use this for initialization
	void Start () {
        audio.SetActive(false);
        openBox.SetActive(false);
        light.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {

            //AudioSource achievement_audio = audio.GetComponent<AudioSource>();

            Debug.Log("space pressed");
            audio.SetActive(true);
             //achievement_audio.Play();
            closedBox.SetActive(false);
            openBox.SetActive(true);
            light.SetActive(true);  
        }

    }
}
