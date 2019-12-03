using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlook : MonoBehaviour
{
    public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public float lookSens = 10;
    public RotationAxis axis = RotationAxis.MouseX;
    public float axisClamp = 0;

    public short canRotate = 1;


    // Update is called once per frame
    void Update()
    {


        if (axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * lookSens, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
            
            canRotate = 1;
            if (axisClamp > 90)
            {
                canRotate = 0;
                axisClamp = 90;
                transform.localRotation = Quaternion.Euler(-90, 0, 0);
            }
            else if (axisClamp < -90)
            {
                canRotate = 0;
                axisClamp = -90;
                transform.localRotation = Quaternion.Euler(90, 0, 0);
            }

            transform.Rotate(-Input.GetAxis("Mouse Y") * lookSens * canRotate, 0, 0);
            axisClamp += Input.GetAxis("Mouse Y") * lookSens;
        }
    }
}




