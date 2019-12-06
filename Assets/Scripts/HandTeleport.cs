using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTeleport : MonoBehaviour {

    public RaycastHit hit;
    public GameObject rightHandPalm;
    public Material originalWaypoint;
    public Material highlightedWaypoint;
    private bool isHighlighted = false;
    private GameObject hObject;

    private void Update () {
        Debug.DrawRay(rightHandPalm.transform.position, rightHandPalm.transform.forward * 1000.0f, Color.blue);
        if (Physics.Raycast (rightHandPalm.transform.position, rightHandPalm.transform.forward, out hit, 1000.0f)) {
            Debug.Log(hit.collider.gameObject);
            if (hit.collider.gameObject.tag == "TeleportPoint") {
                //Teleport
                isHighlighted = true;
                hObject = hit.collider.gameObject;
                hit.collider.gameObject.transform.GetChild (1).GetComponent<Renderer>().material = highlightedWaypoint;
                StartCoroutine(tpToPoint ());
                Debug.Log("wee");
            } else {
                isHighlighted = false;
            }
        }
    }

    IEnumerator tpToPoint () {
        yield return new WaitForSeconds (2f);
        transform.position = hObject.transform.position;
    }

}