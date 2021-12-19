using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionScript : MonoBehaviour
{
    private GameObject ARCamera;
    // Start is called before the first frame update
    void Awake()
    {
        ARCamera = GameObject.Find("AR Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(ARCamera.activeSelf == true)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        this.gameObject.transform.LookAt(ARCamera.transform);
    }
}
