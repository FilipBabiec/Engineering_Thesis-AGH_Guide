using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraToggler : MonoBehaviour
{

    public GameObject[] Cameras;
    public Button CameraButton;
    public Sprite Image;
    public Sprite ImageAlt;
    public GameObject ARmarker;
    public GameObject GameMarker;
    public Button NavButt;

    int currentCam;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = 0;
        setCam(currentCam);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setCam(int idx)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == idx)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    public void toggleCam()
    {
        currentCam++;
        if (currentCam > Cameras.Length - 1)
            currentCam = 0;
        setCam(currentCam);
        if(currentCam == 1)
        {
            CameraButton.image.sprite = ImageAlt;
            if (NavButt.GetComponentInChildren<Text>().text == "Stop navigating")
            {
                ARmarker.SetActive(true);
                GameMarker.SetActive(false);
            } 
        }
        else
        {
            CameraButton.image.sprite = Image;
            if (NavButt.GetComponentInChildren<Text>().text == "Stop navigating")
            {
                ARmarker.SetActive(false);
                GameMarker.SetActive(true);
            }
        }
    }
}