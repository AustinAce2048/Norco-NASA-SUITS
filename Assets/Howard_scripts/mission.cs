using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class mission : MonoBehaviour
{
    public GameObject rovRepair;
    public short steps = 5;
    bool win = false;

    void Start()
    {
        rovRepair = GameObject.Find("roverInstruction");
    }
  

    // Update is called once per frame
    void Update()
    {
        //gets the bool from the instructionsUI script
        win = rovRepair.GetComponent<instructionsUI>().isDone;
        if (win)
        {
           Text winTxt = GameObject.Find("player").transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
           winTxt.color = Color.Lerp(winTxt.color, Color.green, 10 * Time.deltaTime);
        }
    }
}
