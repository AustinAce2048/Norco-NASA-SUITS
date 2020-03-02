using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel1_slider : MonoBehaviour
{ 
    public GameObject slider;
    public GameObject sideMenu;

    private bool isTouching = false;
    private GameObject objInZone;
    private float position;

    
    void Start()
    { 
        sideMenu.SetActive(false);
        objInZone = null;
    }



    void Update()
    {
        if (isTouching) // tracks how far the left or right the finger in on the pad is
        {
            slider.transform.position = new Vector3(objInZone.transform.position.x, 0, 0);
            position = slider.gameObject.transform.position.x;

        }
        else
        {
            slider.transform.position = new Vector3(0, 0, 0);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (objInZone == null) //locks the first object to touch the pad. Stops other gameObjects(other bones) from interfering
        {
            other.tag = "slider";
            objInZone = other.gameObject;
            isTouching = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "slider")
        {
            if (position > 0) { sideMenu.SetActive(true); }
            else if (position < 0) { sideMenu.SetActive(false); }

            other.tag = "Untagged";
            objInZone = null;
            isTouching = false;
        }
    }
}
