using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManagerScript : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject End;
    private Renderer _renderARLine;
    private GameObject Line;
    public Texture2D texAR;
    int i = 1;

    public void DirectionsLineARChange()
    {
        
        if (End.activeSelf == true)
        {
            
            //changing color of navigation line while in AR mode
            if (/*ARCamera.activeSelf == true*/ i == 1)
            {
                i = 0;
                Line = GameObject.Find("direction waypoint  entity");
                _renderARLine = Line.GetComponent<Renderer>();
                _renderARLine.material.SetColor("_Color", new Color32(255, 255, 255, 255));
                _renderARLine.material.SetTexture("_MainTex", texAR);
            }
            else if (/*ARCamera.activeSelf == false*/ i == 0)
            {
                 i = 1;
                Line = GameObject.Find("direction waypoint  entity");
                _renderARLine = Line.GetComponent<Renderer>();
                _renderARLine.material.SetColor("_Color", new Color32(0, 206, 201, 255));
                _renderARLine.material.SetTexture("_MainTex", null);
            }
        }
    }
}