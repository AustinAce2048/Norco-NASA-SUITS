using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor_howard : MonoBehaviour {

    public GameObject worldUIRoot;
    public GameObject cameraRoot;
    private Transform pinkyBonePosition;
    //private Transform wristBonePosition;
    private Transform palmBonePosition;

    //Ray ray;

    void Start () {
        pinkyBonePosition = GetComponent<OVRSkeleton> ().Bones[16].Transform;
        //wristBonePosition = GetComponent<OVRSkeleton> ().Bones[1].Transform;
        palmBonePosition = GetComponent<OVRSkeleton> ().Bones[0].Transform;

    }

    void Update () {
        //worldUIRoot.transform.parent = palmBonePosition; //ignore

        worldUIRoot.transform.position = new Vector3 (pinkyBonePosition.position.x - 0.1f, pinkyBonePosition.position.y, pinkyBonePosition.position.z);
        //worldUIRoot.transform.rotation = Quaternion.Euler (palmBonePosition.rotation.x, palmBonePosition.rotation.y, palmBonePosition.rotation.z);
        //Rotation seems to be absolute

        //Disable UI if palm is not pointed upward
        Vector3 targetDir = new Vector3 (0f, 10000f, 0f) - transform.position;
        float angle = Vector3.Angle (targetDir, transform.up);
        if (angle <= 30f) {
            worldUIRoot.SetActive (false);
        } else {
            worldUIRoot.SetActive (true);
        }

        //ray = new Ray(transform.position, Vector3.down);
        //Debug.DrawLine(palmBonePosition.position, palmBonePosition.position + Vector3.down,Color.red);
    }

}