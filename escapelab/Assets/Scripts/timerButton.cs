﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerButton : MonoBehaviour
{
	public bool hasNewInput = false;
	public string inputButton;

    float timer = 1;
    bool hasPressed = false;
    bool gameSolved = false;
    bool onePressed = false;
    bool twoPressed = false;
    float start_time = 0;
    public TimerLockLEDManager ledManager; 
    public TimerLockLEDManager ledManager2; 


    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.Find("KeypadLED");
        ledManager = g.GetComponent<TimerLockLEDManager>();
        GameObject g2 = GameObject.Find("KeypadLED2");
        ledManager2 = g2.GetComponent<TimerLockLEDManager>();

    }

    // Update is called once per frame
    void Update()
    {
		if (hasNewInput)
        {
			hasNewInput = false;
            
			if (inputButton == "Keypad2" && onePressed == true)
            {
                hasPressed = true;
                //twoPressed = true;
            }

			if (inputButton == "Keypad1")
            {
				
                onePressed = true;

                StartCoroutine(CountdownTo((2)));
            	//send out a signal to the other button that this has been signaled.


			}
            
        }
    }

        IEnumerator CountdownTo(float sec)
        {
            Debug.Log("countdown started for " + sec + "seconds");
            yield return new WaitForSeconds(sec);

        if (hasPressed && gameSolved == false)
            {
                gameSolved = true;
                Debug.Log("Puzzle Solved!!!!!");
                ledManager.changeColor = true;
                ledManager2.changeColor = true;
            }
            else
            {
                Debug.Log("Not on time! Try again! Or you already solved");
                hasPressed = false;
                onePressed = false;
                twoPressed = false;
            }
        }

 
    }
