using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMarkerScript : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50;
    [SerializeField] private float floatAmplitude = 2.0f;
    [SerializeField] private float floatFrequency = 0.5f;

    private GameObject Directions;
    private GameObject End;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Directions = GameObject.Find("Directions");
        End = GetChildWithName(Directions, "End");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency) * floatAmplitude;
        this.gameObject.transform.position = new Vector3(End.transform.position.x, tempPos.y, End.transform.position.z);
        this.gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
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
