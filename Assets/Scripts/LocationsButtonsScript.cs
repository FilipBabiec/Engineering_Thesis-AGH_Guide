using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationsButtonsScript : MonoBehaviour
{
    private GameObject desc;
    public GameObject Canvas;

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (desc != null)
                {
                    if (desc.activeSelf == false)
                    {
                        string name = raycastHit.collider.name + "desc";
                        desc = GetChildWithName(Canvas, name);
                        desc.SetActive(true);
                    }
                }
                else
                {
                    string name = raycastHit.collider.name + "desc";
                    desc = GetChildWithName(Canvas, name);
                    desc.SetActive(true);
                }
            }
        }
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
}
