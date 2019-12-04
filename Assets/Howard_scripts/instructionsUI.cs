using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class instructionsUI : MonoBehaviour
{
    public GameObject player;
    public GameObject ui;
    public short curStep;
    public Transform obj;
    public bool isDone = false;

    short step;
    public float distance = 0;


    //public bool inView = false;
    /*
    ============================================================================
        NOTICE:
            All instructions and markers are in pairs, the order of the instruction steps depends
            on the arrangement(order listed) of the child objects under the roverInstructions Game Object
    ============================================================================
    */


    void Start()
    {
        obj = transform.GetChild(0);
        //total steps edited in mission.cs
        step = GameObject.Find("mission").GetComponent<mission>().steps;

        //for-loop to hide all the instructions base on the number of steps
        for (int i = (int)step + 1; i >= 0; --i)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (curStep < (short)step + 2)
        {
            //measures the distance between the current UI instruction and the player
            distance = Vector3.Distance(player.transform.position, ui.transform.GetChild(curStep).position);

            //this if statement will hide the previous UI instructions, will not trigger on the first set
            if (curStep > 0) 
            { 
                gameObject.transform.GetChild(curStep - 1).gameObject.SetActive(false);
                gameObject.transform.GetChild(curStep - 2).gameObject.SetActive(false);
            }

            //this if-else statement will change between two canvas, one for the marker and the UI instructions
            if (distance < 5)
            {
                gameObject.transform.GetChild(curStep + 1).gameObject.SetActive(false);

                obj = gameObject.transform.GetChild(curStep);
                obj.gameObject.SetActive(true);
            }
            else
            {
                gameObject.transform.GetChild(curStep).gameObject.SetActive(false);

                obj = gameObject.transform.GetChild(curStep + 1);
                obj.gameObject.SetActive(true);
            }




            /*  //=== ORIGINAL IDEA ===
            if (inView)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(false);

                obj = gameObject.transform.GetChild(0);
                obj.gameObject.SetActive(true);

                //  === ORIGINAL IDEA ===
                //gameObject.transform.GetChild(1).gameObject.SetActive(false);
                //gameObject.transform.GetChild(0).gameObject.SetActive(true);
                //gameObject.transform.GetChild(0).LookAt(Camera.main.transform);
                //gameObject.transform.GetChild(0).Rotate(0, 180, 0);

            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);

                obj = gameObject.transform.GetChild(1);
                obj.gameObject.SetActive(true);
            }   //==========================================================
            */
///////////////////////////////////////////////////////////////////////////////////////////////////////

            //UI facing the player
            obj.LookAt(Camera.main.transform);
            obj.Rotate(0, 180, 0);
        }
        else
        {
            isDone = true;
        }
    }

    /*  === ORIGINAL IDEA ===
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { inView = true; }
    }

    private void OnTriggerExit()
    {
        inView = false;
    }
    */
}
