using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggler : MonoBehaviour
{

    public GameObject Map;
    public GameObject Player;
    public GameObject SearchMenu;
    public GameObject SettingsMenu;
    public GameObject Camera;
    public Button CameraButton1;
    public Button CameraButton2;
    public Sprite Image;
    public Sprite ImageAlt;
    //public GameObject ARSes;

    // Start is called before the first frame update
    void Update()
    {
        if (Camera.activeSelf == false)
        {
            CameraButton1.image.sprite = ImageAlt;
            CameraButton2.image.sprite = ImageAlt;
        }
        else
        {
            CameraButton1.image.sprite = Image;
            CameraButton2.image.sprite = Image;
        }

        if (SearchMenu.activeSelf == true || SettingsMenu.activeSelf == true)
        {
            GetComponent<CameraControl>().enabled = false;
        }
        else if (SearchMenu.activeSelf == false && SettingsMenu.activeSelf == false)
        {
            GetComponent<CameraControl>().enabled = true;
        }
    }

    public void toggleMap()
    {
        bool isActive = Map.activeSelf;
        Map.SetActive(!isActive);
        Player.SetActive(!isActive);
    }

    public void toggleSearch()
    {
        bool isActive = SearchMenu.activeSelf;
        SearchMenu.SetActive(!isActive);
        SettingsMenu.SetActive(false);
    }

    public void toggleSettings()
    {
        bool isActive = SettingsMenu.activeSelf;
        SettingsMenu.SetActive(!isActive);
        SearchMenu.SetActive(false);

    }
}
