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
    public float RaycastHitDistance = 2.0f;
    bool isPointingAtPuzzle = false;
    bool isHandlingPuzzle = false;
    private GameObject puzzleObject;

    void Raycasting() {


        Vector3 fwd = transform.TransformDirection(Vector3.forward); //what is the direction in front of us
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(transform.position, fwd, out hit, RaycastHitDistance, puzzleButtonLayer)) {

            isPointingAtPuzzle = true;
           

        }
        else {

            isPointingAtPuzzle = false;
            isHandlingPuzzle = false;

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
		
		// Getting the Touchpad Axis
		if (Controller.GetAxis() != Vector2.zero)
		{
			Debug.Log(gameObject.name + Controller.GetAxis());
		}

		// Getting the Trigger press
		if (Controller.GetHairTriggerDown() ) //&& is) 
		{

            if (go == null) {
                go = GameObject.Find("Cube");
            }


            //This line is the one that changes the value of photonView.isMine on the specified GameObject
            go.GetComponent<PhotonView> ().RequestOwnership ();
			go.GetComponent<TransformManager> ().SetNewParent (this.transform);

		}

		// Getting the Trigger Release
		if (Controller.GetHairTriggerUp())
		{

            if (go == null) {
                go = GameObject.Find("Cube");
            }

            // Make sure we have ownership before we do anything the the objects
            go.GetComponent<PhotonView> ().RequestOwnership ();
			go.GetComponent<TransformManager>().DetachParent ();
		}




		// Getting the Grip Press
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			Debug.Log(gameObject.name + " Grip Press");

			PhotonNetwork.Instantiate(spherePrefab.name, new Vector3(0,3,0), Quaternion.identity, 0);
		}

		// Getting the Grip Release
		if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			Debug.Log(gameObject.name + " Grip Release");
		}
	}
}
