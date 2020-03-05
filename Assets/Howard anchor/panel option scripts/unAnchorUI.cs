using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unAnchorUI : MonoBehaviour
{
    public bool isAnchored = true;
    public GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        AnchorUi();
    }


    public void AnchorUi()
    {
        if (isAnchored)
        {
            isAnchored = false;
            panel.transform.parent = null;
            panel.transform.position += new Vector3(0, 0, 0.05f);
        }
        else
        {
            isAnchored = true;
            panel.transform.parent = GameObject.Find("UI Right Hand").transform;
        }
    }
}
