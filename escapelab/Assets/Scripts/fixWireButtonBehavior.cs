using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixWireButtonBehavior : MonoBehaviour {
	public bool hasInput = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hasInput) {
			hasInput = false;

			this.GetComponentInParent<TransformManager> ().hasNewInput = true;
			this.GetComponentInParent<TransformManager> ().inputButton = this.name;
		}
	}
}
