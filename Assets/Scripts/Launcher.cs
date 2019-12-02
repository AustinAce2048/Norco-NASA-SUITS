using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks {

    public string gameVersion = "1";
    public Transform leftHand;
    public Transform rightHand;
    public GameObject leftSphere;
    public GameObject rightSphere;

    void Awake () {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start () {
        Connect ();
    }

    void Update () {
        if (GameObject.Find ("Leap Rig(Clone)") != null) {
            leftHand = GameObject.Find ("Leap Rig(Clone)").transform.GetChild (1).transform.GetChild (0);
            rightHand = GameObject.Find ("Leap Rig(Clone)").transform.GetChild (1).transform.GetChild (1);
            leftSphere.transform.position = new Vector3 (leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z);
            rightSphere.transform.position = new Vector3 (rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z);
        }
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
        if (PhotonNetwork.IsMasterClient) {
            StartCoroutine (leapSpawn ());
        }
    }

    IEnumerator leapSpawn () {
        yield return new WaitForSeconds (15f);
        PhotonNetwork.InstantiateSceneObject ("Leap Rig", new Vector3 (0f, 1.6f, 0f), Quaternion.identity, 0);
    }

    public void OnPhotonPlayerConnected () {
        Debug.Log ("Connected");
    }

    public override void OnDisconnected (DisconnectCause cause) {
        Debug.LogWarningFormat ("Disconnected called with reason {0}", cause);
    }

}