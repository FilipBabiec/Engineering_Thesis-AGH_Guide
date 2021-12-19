using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationMarkerPositionScript : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50;
    [SerializeField] private float floatAmplitude = 2.0f;
    [SerializeField] private float floatFrequency = 0.5f;
    
    public GameObject End;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency) * floatAmplitude;
        this.gameObject.transform.position = new Vector3(End.transform.position.x, tempPos.y, End.transform.position.z);
        this.gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}