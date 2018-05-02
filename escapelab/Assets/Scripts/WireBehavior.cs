using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBehavior : MonoBehaviour {

	public bool hasNewInput = false;
	public string inputButton;

	[SerializeField]Color defaultColor; 
	[SerializeField]Color highlightColor; 
	[SerializeField]float resetDelay = 0.2f;
	AudioSource sound;
	bool solved1 = false;
	bool solved2 = false;
	bool solved3 = false;
	bool solved4 = false;
	bool solved5 = false;






	string attempt = "";

	string key1 = "18"; 
	string key2 = "20"; 
	string key3 = "36";  
	string key4 = "47";  
	string key5 = "59"; 
	string key6 = "81"; 
	string key7 = "02"; 
	string key8 = "63";  
	string key9 = "74";  
	string key0 = "95"; 

	void Start () {
		GameObject w1 = GameObject.Find ("Wire1");
		GameObject w2 = GameObject.Find ("Wire2");
		GameObject w3 = GameObject.Find ("Wire3");
		GameObject w4 = GameObject.Find ("Wire4");
		GameObject w5 = GameObject.Find ("Wire5");
		w1.GetComponent<Renderer> ().enabled = false; 
		w2.GetComponent<Renderer> ().enabled = false; 
		w3.GetComponent<Renderer> ().enabled = false; 
		w4.GetComponent<Renderer> ().enabled = false; 
		w5.GetComponent<Renderer> ().enabled = false; 

	}

	void findWires() {
		GameObject w1 = GameObject.Find ("Wire1");
		GameObject w2 = GameObject.Find ("Wire2");
		GameObject w3 = GameObject.Find ("Wire3");
		GameObject w4 = GameObject.Find ("Wire4");
		GameObject w5 = GameObject.Find ("Wire5");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject w1 = GameObject.Find ("Wire1");
		GameObject w2 = GameObject.Find ("Wire2");
		GameObject w3 = GameObject.Find ("Wire3");
		GameObject w4 = GameObject.Find ("Wire4");
		GameObject w5 = GameObject.Find ("Wire5");

		w1.GetComponent<MeshRenderer> ().material.color = Color.red;
		w2.GetComponent<MeshRenderer> ().material.color = Color.green;
		w3.GetComponent<MeshRenderer> ().material.color = Color.blue;
		w4.GetComponent<MeshRenderer> ().material.color = Color.white;
		w5.GetComponent<MeshRenderer> ().material.color = Color.yellow;


		if (hasNewInput) {



			// LEFT WIRE BASE 

			if (inputButton == "LeftWireBase1") {
				attempt = attempt + "1";
				Debug.Log (attempt); 
			}

			if (inputButton == "LeftWireBase2") {
				attempt = attempt + "2";
				Debug.Log (attempt); 
			}

			if (inputButton == "LeftWireBase3") {
				attempt = attempt + "3";
				Debug.Log (attempt); 
			}

			if (inputButton == "LeftWireBase4") {
				attempt = attempt + "4";
				Debug.Log (attempt); 
			}

			if (inputButton == "LeftWireBase5") {
				attempt = attempt + "5";
				Debug.Log (attempt); 
			}

			// RIGHT WIRE BASE

			if (inputButton == "RightWireBase1") {
				attempt = attempt + "6";
				Debug.Log (attempt); 
			}

			if (inputButton == "RightWireBase2") {
				attempt = attempt + "7";
				Debug.Log (attempt); 
			}

			if (inputButton == "RightWireBase3") {
				attempt = attempt + "8";
				Debug.Log (attempt); 
			}

			if (inputButton == "RightWireBase4") {
				attempt = attempt + "9";
				Debug.Log (attempt); 
			}

			if (inputButton == "RightWireBase5") {
				attempt = attempt + "0";
				Debug.Log (attempt); 
			}
		}
		if (attempt.Length == 2) {
			if ((attempt == key1) || (attempt == key6)) {
				w1.GetComponent<Renderer> ().enabled = true;
				attempt = "";
			}
			if ((attempt == key2) || (attempt == key7)) {
				w2.GetComponent<Renderer> ().enabled = true;
				attempt = "";
			}
			if ((attempt == key3) || (attempt == key8)) {
				w3.GetComponent<Renderer> ().enabled = true;
				attempt = "";
			}
			if ((attempt == key4) || (attempt == key9)) {
				w4.GetComponent<Renderer> ().enabled = true;
				attempt = "";
			}
			if ((attempt == key5) || (attempt == key0)) {
				w5.GetComponent<Renderer> ().enabled = true;
				attempt = "";
			}
			else {
				attempt = ""; // else reset attempt string
			}
		}

		if (solved1 && solved2 && solved3 && solved4 && solved5) {
			GameObject[] arr = GameObject.FindGameObjectsWithTag("box4");

			for(int i=0;i<2;i++){
				arr[i].GetComponent<cardboardswitch1>().solved = true;
			}
		}

	}
}