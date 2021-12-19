using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NavigateButton : MonoBehaviour
{
    [SerializeField] private Material LineMaterial;
    [SerializeField] private Material LineMaterialColor;
    [SerializeField] private Material TransparentMaterial;
    public TextMeshProUGUI navigateText;
    public TextMeshProUGUI finishText;
    public GameObject End;
    private GameObject Destination;
    public Button NavButt;
    public GameObject Buildingsdropdown;
    public GameObject Officesdropdown;
    public GameObject Otherdropdown;
    public GameObject FinishPanel;
    public InputField InputRoom;
    public GameObject Player;
    public GameObject ARCamera;
    int i;
    int room;
    string classroom;

    void Awake()
    {
        int i = 0;
    }

    public void SetI()
    {
        i = 0;
    }

    public void OnClickNavigate()
    {
        bool isActive = End.activeSelf;
        Destination = GameObject.Find(navigateText.text);
        End.transform.position = Destination.transform.position;
        End.SetActive(!isActive);

        if (End.activeSelf == true)
        {
            LineMaterial.color =LineMaterialColor.color;
            NavButt.GetComponentInChildren<Text>().text = "Stop navigating";
        }
        else
        {
            LineMaterial.color = TransparentMaterial.color;
            NavButt.GetComponentInChildren<Text>().text = "Navigate";
        }
    }

    public void OnFinishTextChange()
    {
        if (Buildingsdropdown.activeSelf == true)
        {
            int.TryParse(InputRoom.text, out int room);
            if (room < 100)
            {
                classroom = "ground";
            }
            else if (room >= 100 && room < 200)
            {
                classroom = "first";
            }
            else if (room >= 200 && room < 300)
            {
                classroom = "second";
            }
            else if (room >= 300 && room < 400)
            {
                classroom = "third";
            }
            else
            {
                classroom = "(You did not provide a valid classroom!)";
            }
            finishText.text = "You have arrived at Your destination. Your classroom should be on the " + classroom + " floor.";
        }
        else if (Officesdropdown.activeSelf == true)
        {
            switch (navigateText.text)
            {
                case "WIMIR":
                    room = 20;
                    break;
                case "WEAIIIB":
                    room = 26;
                    break;
                case "WGGIOŒ":
                    room = 19;
                    break;
                default:
                    room = 1;
                    break;
            }

            if (room < 100)
            {
                classroom = "ground";
            }
            else if (room >= 100 && room < 200)
            {
                classroom = "first";
            }
            else if (room >= 200 && room < 300)
            {
                classroom = "second";
            }
            else if (room >= 300 && room < 400)
            {
                classroom = "third";
            }
            finishText.text = "You have arrived at Your destination. The dean's office is in the room " + room.ToString() + ", on the " + classroom + " floor";
        }
        else if (Otherdropdown.activeSelf == true)
        {
            finishText.text = "You have arrived at Your destination.";
        }
    }

    void Update()
    {
        if (End.activeSelf == true)
        {
            //switching off navigation line while in AR mode
            if (ARCamera.activeSelf == false)
            {
                LineMaterial.color = LineMaterialColor.color;
            }
            else if (ARCamera.activeSelf == true)
            {
                LineMaterial.color = TransparentMaterial.color;
            }

            //arriving at destiantion
            if (i == 0)
            {
                if ((Player.transform.position.x < End.transform.position.x + 7 && Player.transform.position.x > End.transform.position.x - 7) && (Player.transform.position.z < End.transform.position.z + 7 && Player.transform.position.z > End.transform.position.z - 7))
                {
                    i = 1;
                    FinishPanel.SetActive(true);
                }
            }
        }
    }
}