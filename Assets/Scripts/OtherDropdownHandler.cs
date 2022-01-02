using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OtherDropdownHandler : MonoBehaviour
{
    [SerializeField] private Material LineMaterial;
    [SerializeField] private Material TransparentMaterial;
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
        items.Add("Studio Club");
        items.Add("Recruiting Center");
        items.Add("Main Library");
        items.Add("TestLocation");

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
        LineMaterial.color = TransparentMaterial.color;
        NavButt.GetComponentInChildren<Text>().text = "Navigate";
    }
}
