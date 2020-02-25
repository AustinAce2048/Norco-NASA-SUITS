using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor_howard : MonoBehaviour {
    //UI attachments
    public GameObject worldUIRoot;
    public GameObject panel1;
    public GameObject wristSlot;
    public GameObject palmSlot;
    public GameObject cameraRoot;

    //Bones
    private Transform pinkyBonePosition;
    private Transform wristBonePosition;
    private Transform palmBonePosition;


    void Start() {
        pinkyBonePosition = GetComponent<OVRSkeleton> ().Bones[16].Transform;
        wristBonePosition = GetComponent<OVRSkeleton> ().Bones[1].Transform;
        palmBonePosition = GetComponent<OVRSkeleton> ().Bones[0].Transform;

        worldUIRoot = GameObject.Find("UI Right Hand");

        //==== making the UI element for palmSlot as a child of palm bone. Comment out and uncomment palmSlot.transform.position for position method =============================
        palmSlot.transform.parent = palmBonePosition;
        palmSlot.transform.position = new Vector3(palmBonePosition.position.x, palmBonePosition.position.y, palmBonePosition.position.z);
        //========================================================================================================================================================================
    }

    void Update() {
        if (panel1.transform.parent != null) { panel1.transform.position = new Vector3(pinkyBonePosition.position.x - 0.1f, pinkyBonePosition.position.y, pinkyBonePosition.position.z); }
        wristSlot.transform.position = new Vector3(wristBonePosition.position.x, wristBonePosition.position.y + 5000f, wristBonePosition.position.z - 1000f);
        //uncomment for position method use
        //palmSlot.transform.position = new Vector3(palmBonePosition.position.x, palmBonePosition.position.y, palmBonePosition.position.z);

        Vector3 targetDir = new Vector3(cameraRoot.transform.position.x, cameraRoot.transform.position.y + 10000f, cameraRoot.transform.position.z) - cameraRoot.transform.position;
        float angle = Vector3.Angle(targetDir, -palmBonePosition.up);
        if (angle <= 30f) {
            worldUIRoot.SetActive(true);
        } else {
            worldUIRoot.SetActive(false);
        }

    }

}