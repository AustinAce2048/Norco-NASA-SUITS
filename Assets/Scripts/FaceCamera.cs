using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

    public Transform target;

    void Update () {
        if (target != null) {
            transform.LookAt (target);
       }
    }

}