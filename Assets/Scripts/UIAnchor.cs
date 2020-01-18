using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor : MonoBehaviour {

    public GameObject worldUIRoot;
    public GameObject anchorPoint;

    void Update () {
        worldUIRoot.transform.position = anchorPoint.transform.position;
    }

}