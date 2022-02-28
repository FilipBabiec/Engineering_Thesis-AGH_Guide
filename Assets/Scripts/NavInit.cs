using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavInit : MonoBehaviour
{
    public GameObject End;
    // Start is called before the first frame update
    void Awake()
    {
        End = GameObject.Find("End");
        End.SetActive(false);
    }
}
