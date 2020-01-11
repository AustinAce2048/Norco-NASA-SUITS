using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PUNPlayer : MonoBehaviour {

    void Start () {
        if (PhotonNetwork.IsMasterClient == true) {
            //Enable components
            transform.GetChild (0).GetComponent<OVRCameraRig> ().enabled = true;
            transform.GetChild (0).GetComponent<OVRManager> ().enabled = true;
        }
    }

}