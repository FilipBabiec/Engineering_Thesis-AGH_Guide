using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuidlingsDropdownHandler : MonoBehaviour
{
    public GameObject End;
    public Button NavButt;
    private GameObject Destination;
    public TextMeshProUGUI textNavigate;
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("A0");
        items.Add("A1");
        items.Add("A2");
        items.Add("A3");
        items.Add("A4");
        items.Add("B1");
        items.Add("B2");
        items.Add("B3");
        items.Add("B4");
        items.Add("B7");
        items.Add("C1");
        items.Add("C2");
        items.Add("C3");
        items.Add("C4");
        items.Add("C5");
        items.Add("C6");
        items.Add("D1");
        items.Add("D2");
        items.Add("D4");
        items.Add("U3");
        items.Add("S1");

        //fill dropdown with items
        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;

        textNavigate.text = dropdown.options[index].text;

        Destination = GameObject.Find(textNavigate.text);
        End.transform.position = Destination.transform.position;
        End.SetActive(false);
        NavButt.GetComponentInChildren<Text>().text = "Navigate";
    }
}
