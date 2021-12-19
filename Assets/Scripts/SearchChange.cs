using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SearchChange : MonoBehaviour
{
    [SerializeField] private Material LineMaterial;
    [SerializeField] private Material TransparentMaterial;
    public GameObject End;
    public Button NavButt;
    public TextMeshProUGUI navigateText;
    public GameObject Buildings;
    public GameObject Offices;
    public GameObject Other;

    public void HandleInputDataMenu(int val)
    {
        End.transform.position = new Vector3(0, 0, 0);
        End.SetActive(false);
        LineMaterial.color = TransparentMaterial.color;
        NavButt.GetComponentInChildren<Text>().text = "Navigate";

        switch (val)
        {
            case 0:
                {
                    Buildings.SetActive(true);
                    Offices.SetActive(false);
                    Other.SetActive(false);
                    break;
                }
            case 1:
                {
                    Buildings.SetActive(false);
                    Offices.SetActive(true);
                    Other.SetActive(false);
                    break;
                }
            case 2:
                {
                    Buildings.SetActive(false);
                    Offices.SetActive(false);
                    Other.SetActive(true);
                    break;
                }
        }
    }
}
