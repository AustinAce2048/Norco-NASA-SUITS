using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks {

    public string gameVersion = "1";
    public GameObject leapRig;

    void Awake () {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start () {
        Connect ();
    }

    public void Connect () {
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.JoinRandomRoom ();
        } else {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings ();
        }
    }

    public override void OnConnectedToMaster () {
        Debug.Log ("Connected to Master");
        PhotonNetwork.JoinRandomRoom ();
    }

    public override void OnJoinRandomFailed (short returnCode, string message) {
        Debug.Log ("No room available, making one...");
        PhotonNetwork.CreateRoom (null, new RoomOptions ());
    }

    public override void OnJoinedRoom () {
        Debug.Log ("Client joined room");
        PhotonNetwork.Instantiate ("Leap Rig", new Vector3 (0f, 1.6f, 0f), Quaternion.identity, 0);
    }

    public override void OnDisconnected (DisconnectCause cause) {
        Debug.LogWarningFormat ("Disconnected called with reason {0}", cause);
    }

}