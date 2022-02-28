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
    public GameObject LocationDescCanvas;

    int currentCamId;

    // Start is called before the first frame update
    void Start()
    {
        currentCamId = 0;
        SetCamera(currentCamId);
    }


    public void SetCamera(int id)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == id)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }

    public void ToggleCamera()
    {
        currentCamId++;
        if (currentCamId > Cameras.Length - 1)
        {
            currentCamId = 0;
        }
        SetCamera(currentCamId);

        
        if(currentCamId == 1)
        {
            CameraButton.image.sprite = ImageAlt;
            if (NavButt.GetComponentInChildren<Text>().text == "Stop navigating")
            {
                LocationDescCanvas.SetActive(false);
                ARmarker.SetActive(true);
                //GameMarker.SetActive(false);
            } 
        }
        else
        {
            CameraButton.image.sprite = Image;
            if (NavButt.GetComponentInChildren<Text>().text == "Stop navigating")
            {
                LocationDescCanvas.SetActive(true);
                ARmarker.SetActive(false);
                //GameMarker.SetActive(true);
            }
        }
    }
}