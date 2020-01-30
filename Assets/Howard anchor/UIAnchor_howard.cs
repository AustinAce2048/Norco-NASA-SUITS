using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor_howard : MonoBehaviour
{

    public GameObject worldUIRoot;
    private Transform thumbBonePosition;
    private Transform palm;

    void Start(){
        thumbBonePosition = GetComponent<OVRSkeleton> ().Bones[3].Transform;
        palm = GetComponent<OVRSkeleton> ().Bones[0].Transform;
    }

    void Update () {
        if (Physics.Raycast(new Vector3(palm.position.x, palm.position.y, palm.position.z),new Vector3(0, 0, 1), 30f, 0, ddefault)){
            worldUIRoot.SetActive(true);
            worldUIRoot.transform.position = new Vector3 (thumbBonePosition.position.x, thumbBonePosition.position.y + 0.05f, thumbBonePosition.position.z);
        }
        else { worldUIRoot.SetActive(false); }
    }

}