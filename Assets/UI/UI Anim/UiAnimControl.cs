using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimControl : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator animControl;
    private float distValue;
    
    void Start()
    {
        animControl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distValue = GameObject.Find("roverInstruction").GetComponent<instructionsUI>().distance;
        animControl.SetFloat("myDistance", distValue);
    }
}
