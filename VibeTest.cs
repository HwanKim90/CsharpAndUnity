using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeTest : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            StartCoroutine(VibeRate(0.5f));
        }
    }

    IEnumerator VibeRate(float sec)
    {
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        yield return new WaitForSeconds(sec);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
