using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Input.GetAxis("Movement") * speed * Time.deltaTime);
        transform.Translate(Input.GetAxis("Strafe") * speed * Time.deltaTime, 0, 0);
        
    }
}
