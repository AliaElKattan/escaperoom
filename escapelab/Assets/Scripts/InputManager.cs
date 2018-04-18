using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script manages controller input. Here we use trigger or press to move a game object.
// Attach this script to each controller (Controller Left or Controller Right)
public class InputManager : Photon.MonoBehaviour {
	// Getting a reference to the controller GameObject
	private SteamVR_TrackedObject trackedObj;
	// Getting a reference to the controller Interface
	private SteamVR_Controller.Device Controller;
    public LayerMask puzzleButtonLayer;
	public GameObject spherePrefab;
	public GameObject go;
    public float RaycastHitDistance = 4.0f;
    bool isPointingAtPuzzle = false;
    private GameObject puzzleObject;

    void Raycasting() {


        Vector3 fwd = transform.TransformDirection(Vector3.forward); //what is the direction in front of us
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, fwd, out hit, RaycastHitDistance, puzzleButtonLayer)) {

			//get the puzzle object that we're raycasting on
			puzzleObject = hit.collider.gameObject;

			if (!puzzleObject.GetPhotonView ().isMine) {

				puzzleObject.GetComponent<PhotonView> ().RequestOwnership ();

			}

            isPointingAtPuzzle = true;

        }
        else {

            isPointingAtPuzzle = false;

        }

    }



    void Start(){
	}

	void Awake()
	{
		// initialize the trackedObj to the component of the controller to which the script is attached
		trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
        puzzleButtonLayer = LayerMask.GetMask("puzzleButtonLayer");

    }

    // Update is called once per frame
    void Update () {



        Raycasting();
        Controller = SteamVR_Controller.Input((int)trackedObj.index);


		// trigger pressed while interacting with a puzzle element. this will signify a button press (either in direction or number pad)
		if (Controller.GetHairTriggerDown() && isPointingAtPuzzle ) 
		{
			
			if (puzzleObject.GetComponentsInParent<KeypadController> ()) {
			//this is keypad lock.
				puzzleObject.GetComponentInParent<KeypadController>().hasNewInput = true;
				puzzleObject.GetComponentInParent<KeypadController> ().touchedButton = puzzleObject;

			
			} else if (puzzleObject.GetComponentsInParent<DirectionalLockBehavior> ()) {

				Debug.Log ("Not yet implemented");
			
			
			}


		}
			



	
	}
}
