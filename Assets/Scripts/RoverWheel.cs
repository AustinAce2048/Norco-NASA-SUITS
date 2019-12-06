using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverWheel : MonoBehaviour {

    public GameObject animRover;

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.name == "wheel_02_L") {
            //You win
            Debug.Log ("win");
            Instantiate (animRover, transform.position, transform.rotation);
            Destroy (gameObject);
        }
    }

}