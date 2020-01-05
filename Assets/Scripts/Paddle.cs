using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Paddle : MonoBehaviourPun {

    void Update () {
        if (photonView.IsMine && PhotonNetwork.IsConnected) {
            //I am the player

        }
    }

}