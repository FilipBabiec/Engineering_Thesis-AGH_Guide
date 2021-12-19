using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMarkers : MonoBehaviour
{
    public GameObject Camera;
    private GameObject ARCamera;

    void Update()
    {
        Camera = GameObject.Find("Main Camera");
        ARCamera = GameObject.Find("AR Camera");

        if (Camera.activeSelf == true)
        {
            this.transform.rotation = Camera.transform.rotation;
        }
        else if (ARCamera.activeSelf == true)
        {
            this.gameObject.transform.LookAt(ARCamera.transform);
        }
    }
}