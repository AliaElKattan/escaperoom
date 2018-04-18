using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon; //we need to add that line to use Photon-specific methods

// here, we change MonoBehaviour to Photon.PunBehaviour
// so that we can override some methods offered by Photon (lines 27-48)
public class MyNetwork : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
		//this line allows us to connect to the network. The only argument is the version of the application.
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}

	// Update is called once per frame
	void Update () {

	}

    string room_name = "Atrium";
    RoomInfo[] all_rooms;
    string networkedObject_name = "Being";

    void OnGUI()
    {   //This is called to easily display GUI elements
        if (!PhotonNetwork.connected)
        {   //if the player isn't currently connected to the Photon Cloud
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString()); //display log messages
        }
        else if (PhotonNetwork.room == null)
        { //else, if you're connected and not yet in a room
            if (GUI.Button(new Rect(100, 100, 250, 100), "Create a Room")){ //display a clickable button to create a room
                PhotonNetwork.CreateRoom(room_name, new RoomOptions()
                {
                    MaxPlayers = 2,
                    PublishUserId = true,
                    IsVisible = true,
                    PlayerTtl = 0,
                    EmptyRoomTtl = 0
                }, null);
            }
        }

        if (all_rooms != null)
        { //if we have some rooms to display
            for (int i = 0; i < all_rooms.Length; i++)
            {
                if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + all_rooms[i].name)) //create buttons for each available room
                    PhotonNetwork.JoinRoom(all_rooms[i].name); //join the room that the user clicked on!
            }
        }
    }

    void OnReceivedRoomListUpdate()
    { //this function is automatically called when you get new rooms (e.g. when a room is created or removed
        all_rooms = PhotonNetwork.GetRoomList();
    }

    void OnJoinedRoom()
    { //this is automatically called when you join a room
        Debug.Log("Joined new room!");
                PhotonNetwork.Instantiate(networkedObject_name, Vector3.zero, Quaternion.identity, 0); //this is where you want to create your avatar
    }
}
