using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PongManager : MonoBehaviour {

    public GameObject paddle;

    void Start () {
        if (GameObject.FindGameObjectsWithTag ("paddle").Length > 0) {
            PhotonNetwork.Instantiate (this.paddle.name, new Vector3 (0f, 1.8f, -4f), Quaternion.identity, 0);
        } else {
            GameObject pad = PhotonNetwork.Instantiate (this.paddle.name, new Vector3 (0f, 1.8f, 4f), Quaternion.identity, 0);
            pad.transform.eulerAngles = new Vector3 (0f, 180f, 0f);
        }
    }

}