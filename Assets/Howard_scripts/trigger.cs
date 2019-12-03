using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    short count = 0;
    GameObject obj;
    
    private void OnTriggerEnter(Collider other)
    {
        obj = GameObject.Find("roverInstruction");
        
        if (other.tag == "Player")
        {
            obj.GetComponent<instructionsUI>().curStep += (short)(count == 0 ? ++count + 1 : 0);
        }
    }
    
}
