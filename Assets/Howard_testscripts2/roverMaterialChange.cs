using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roverMaterialChange : MonoBehaviour
{
    public Material og_mat;
    public Material holo_mat;
    public Material empty;
    public GameObject part;
    
    float distance = 0;
    bool isOn = false;


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(part.transform.position, gameObject.transform.position);
        //NOTICE: Programmer will need to return a true/false based on the VR hand letting go of an object (uncoment below to assign value)
        //isOn = //refernce to returning bool value from hand grabs

        if (distance < 5.0f && !isOn)
        {
            gameObject.GetComponent<MeshRenderer>().material = holo_mat;

            if (distance < 0.5f)
            {
                Destroy(part);
                gameObject.GetComponent<MeshRenderer>().material = og_mat;
                GameObject.Find("roverInstruction").gameObject.GetComponent<instructionsUI>().curStep += 2;
                Destroy(GetComponent<roverMaterialChange>());
            }
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = empty;
        }
    }
}
