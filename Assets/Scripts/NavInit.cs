using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavInit : MonoBehaviour
{
    [SerializeField] private Material LineMaterial;
    [SerializeField] private Material TransparentMaterial;
    public GameObject End;
    private GameObject DirectionLine;
    // Start is called before the first frame update
    void Awake()
    {
        End = GameObject.Find("End");
        End.SetActive(false);
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(1);
        DirectionLine = GameObject.Find("direction waypoint  entity");
        LineMaterial.color = TransparentMaterial.color;
    }
}
