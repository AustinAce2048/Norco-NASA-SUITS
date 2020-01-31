using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor_howard : MonoBehaviour {

    public GameObject worldUIRoot;
    public GameObject cameraRoot;
    private Transform pinkyBonePosition;
    private Transform wristBonePosition;
    private Transform palmBonePosition;

    void Start () {
        pinkyBonePosition = GetComponent<OVRSkeleton> ().Bones[16].Transform;
        wristBonePosition = GetComponent<OVRSkeleton> ().Bones[1].Transform;
        palmBonePosition = GetComponent<OVRSkeleton> ().Bones[0].Transform;
    }

    void Update () {
        worldUIRoot.transform.position = new Vector3 (palmBonePosition.position.x - 0.1f, palmBonePosition.position.y, palmBonePosition.position.z);
        //worldUIRoot.transform.rotation = Quaternion.Euler (palmBonePosition.rotation.x, palmBonePosition.rotation.y, palmBonePosition.rotation.z);
        //Rotation seems to be absolute
    }

}