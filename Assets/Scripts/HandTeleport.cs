using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTeleport : MonoBehaviour {

    public RaycastHit hit;
    public GameObject rightHandPalm;
    public Material originalWaypoint;
    public Material highlightedWaypoint;
    private bool isHighlighted = false;
    public GameObject cylinder;
    public Transform[] teleportPoints;
    private GameObject hObject;
    private float shortestDistanceToPoint = 2000f;
    public Transform closestPoint;

    private void Update () {
        shortestDistanceToPoint = 2000f;
        foreach (Transform point in teleportPoints) {
            float dis = Vector3.Distance (transform.position, point.position);
            if (dis < shortestDistanceToPoint && dis > 1f) {
                shortestDistanceToPoint = dis;
                closestPoint = point;
            }
        }
        if (Vector3.Angle (rightHandPalm.transform.forward, (closestPoint.position - transform.position).normalized) <= 30f) {
            cylinder.SetActive (true);
        } else {
            cylinder.SetActive (false);
        }
        //Debug.DrawRay (rightHandPalm.transform.position, rightHandPalm.transform.forward * 1000.0f, Color.blue);
        if (Physics.Raycast (rightHandPalm.transform.position, rightHandPalm.transform.forward, out hit, 1000.0f)) {
            Debug.Log (hit.collider.gameObject);
            if (hit.collider.gameObject.tag == "TeleportPoint") {
                if (hit.collider.gameObject == closestPoint.gameObject) {
                    isHighlighted = true;
                    closestPoint.gameObject.transform.GetChild (1).GetComponent<Renderer> ().material = highlightedWaypoint;
                    StartCoroutine (tpToPoint ());
                }
            } else {
                isHighlighted = false;
                StopCoroutine (tpToPoint ());
                closestPoint.gameObject.transform.GetChild (1).GetComponent<Renderer> ().material = originalWaypoint;
            }
        }
    }

    IEnumerator tpToPoint () {
        yield return new WaitForSeconds (2f);
        if (isHighlighted) {
            transform.position = closestPoint.position;
            closestPoint.position = Vector3.zero;
        }
    }

}