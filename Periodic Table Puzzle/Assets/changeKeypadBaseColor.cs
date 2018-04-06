using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeKeypadBaseColor : MonoBehaviour {
	[SerializeField]Color baseColor; 

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().material.color = baseColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
