using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using UnityEngine;
using Mapbox.Unity.Utilities;

public class ARLocationsScript : MonoBehaviour
{
    //public Vector2d(50.065927, 19.918732);
    //public Location = new Mapbox.Utils.Vector2d(50.065927, 19.918732);

    // Update is called once per frame

    public double Lat;
    public double Lon;
    public GameObject Player;
    public GameObject ARCamera;
    public GameObject Text;
    //private GameObject ARSes;

    void Start()
    {
        //ARSes = GameObject.Find("AR Session Origin");
        //ARCamera = GetChildWithName(ARSes, "AR Camera");
    }

    void Update()
    {
        var _map = LocationProviderFactory.Instance.mapManager;
        this.transform.position = Conversions.GeoToWorldPosition(Lat, Lon, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        this.gameObject.transform.LookAt(ARCamera.transform);

        if ((Player.transform.position.x < this.transform.position.x + 30 && Player.transform.position.x > this.transform.position.x - 30) && (Player.transform.position.z < this.transform.position.z + 30 && Player.transform.position.z > this.transform.position.z - 30))
        {
            //this.GetComponentInChildren<Text>().SetActive(true);
            Text.SetActive(true);
        }
        else
        {
            //this.GetComponentInChildren<Text>().SetActive(false);
            Text.SetActive(false);
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
