using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputTest : MonoBehaviour
{
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            mat.color = Color.red;
        }
        if (OVRInput.GetDown(OVRInput.Touch.PrimaryIndexTrigger, 
            OVRInput.Controller.RTouch))
        {
            mat.color = Color.blue;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
        {
            transform.position -= transform.right;
        }

        Vector2 v = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        if(v.magnitude > 0)
        {
            print(v.x + ", " + v.y);
            
        }


    }
}
