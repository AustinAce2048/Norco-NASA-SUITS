using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor_howard : MonoBehaviour {

    public GameObject worldUIRoot;
    public GameObject cameraRoot;
    private Transform pinkyBonePosition;
    //private Transform wristBonePosition;
    private Transform palmBonePosition;

    void Start () {
        pinkyBonePosition = GetComponent<OVRSkeleton> ().Bones[16].Transform;
        //wristBonePosition = GetComponent<OVRSkeleton> ().Bones[1].Transform;
        palmBonePosition = GetComponent<OVRSkeleton> ().Bones[0].Transform;

    }

    void Update () {
        worldUIRoot.transform.position = new Vector3 (pinkyBonePosition.position.x - 0.1f, pinkyBonePosition.position.y, pinkyBonePosition.position.z);

        Vector3 targetDir = new Vector3 (cameraRoot.transform.position.x, cameraRoot.transform.position.y + 10000f, cameraRoot.transform.position.z) - cameraRoot.transform.position;
        float angle = Vector3.Angle (targetDir, -palmBonePosition.up);
        if (angle <= 30f) {
            worldUIRoot.SetActive (true);
        } else {
            worldUIRoot.SetActive (false);
        }
    }

}