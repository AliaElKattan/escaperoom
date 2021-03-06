﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows moving any game object (when controllers trigger & release)
public class TransformManager : Photon.MonoBehaviour {

	public float speed = 10f;
	public bool hasNewInput = false;
	public string inputButton; 
	public bool hackyFix_TimerLockSolve = false;

	PhotonView photonView;


	void Start(){
		photonView = PhotonView.Get (this);
	}

	// Update is called once per frame
	void Update () {

		//there was a button input
		if (hasNewInput) {
			Debug.Log (inputButton);
			hasNewInput = false;
			buttonInput (inputButton);

		}
		if (hackyFix_TimerLockSolve) {
			hackyFix_TimerLockSolve = false;
			solvedTimerLock ();
		}

		//Update the movement
		if (!photonView.isMine) {
			SyncedMovement ();
		}
	}

	[PunRPC] public void solvedTimerLock(){
		
		if (this.gameObject.GetComponent<timerButton> ()) {

			GetComponent<timerButton> ().timerGameSolvedButNetworkBug = true;
		}

	}

	//handle keypad input from a user.
	[PunRPC] public void buttonInput(string buttonName){
		
		if (this.gameObject.GetComponent<timerButton> ()) {

			GetComponent<timerButton> ().hasNewInput = true;
			GetComponent<timerButton> ().inputButton = buttonName;
			GameObject.Find (buttonName).GetComponent<TimerLockController> ().runClickEffect = true;

		} else {

			if (this.gameObject.GetComponent<KeypadController> ()) {

				GetComponent<KeypadController> ().hasNewInput = true;
				GetComponent<KeypadController> ().inputButton = buttonName;

			} else if (this.gameObject.GetComponent<DirectionalLockBehavior> ()) {

				GetComponent<DirectionalLockBehavior> ().hasNewInput = true;
				GetComponent<DirectionalLockBehavior> ().inputButton = buttonName;
			} else if (this.gameObject.GetComponent<WireBehavior> ()) {

				GetComponent<WireBehavior> ().hasNewInput = true;
				GetComponent<WireBehavior> ().inputButton = buttonName;

			} 

			GameObject.Find (buttonName).GetComponent<keypadButtonBehavior> ().runClickEffect = true;

		}
		if (photonView.isMine)
			photonView.RPC("buttonInput", PhotonTargets.Others, buttonName);


	}


	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	//Here if we are writing to the stream we send position and velocity
	//otherwise we are reading the position and the velocity from the stream to get the update information
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		if (stream.isWriting)
		{
			stream.SendNext(rb.position);
			stream.SendNext(rb.velocity);
		}
		else
		{
			Vector3 syncPosition = (Vector3)stream.ReceiveNext();
			Vector3 syncVelocity = (Vector3)stream.ReceiveNext();

			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;

			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rb.position;
		}
	}



	private void SyncedMovement()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		syncTime += Time.deltaTime;
		rb.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
	}

	public void StartColorChange(Vector3 color){
		photonView.RPC("ChangeColorTo",PhotonTargets.All, color);
	}

	public void StartMoveTo(Vector3 direction){
		photonView.RPC("MoveTo",PhotonTargets.All, direction);
	}

	//Change the color
	[PunRPC] void ChangeColorTo(Vector3 color)
	{
		GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);
		if (photonView.isMine)
			photonView.RPC("ChangeColorTo", PhotonTargets.OthersBuffered, color);
	}

	//Move the object
	[PunRPC] void MoveTo(Vector3 direction)
	{
		GetComponent<Transform>().position = direction;
		if (photonView.isMine)
			photonView.RPC("MoveTo", PhotonTargets.OthersBuffered, direction);
	}

	//set a new parent
	[PunRPC] public void SetNewParent(Transform tr){
		transform.SetParent (tr);
		if (photonView.isMine)
			photonView.RPC("SetNewParent", PhotonTargets.OthersBuffered,tr);
	}

	//detach the parent
	[PunRPC] public void DetachParent(){
		transform.parent = null;
		Debug.Log("Detached all parents");

		if (photonView.isMine)
			photonView.RPC("DetachParent", PhotonTargets.OthersBuffered,photonView.viewID);

	}
}
