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
    private GameObject ARCamera;
    public GameObject Text;

    void Awake()
    {
        ARCamera = GameObject.Find("AR Camera");
    }

    void Update()
    {
        var _map = LocationProviderFactory.Instance.mapManager;
        this.transform.position = Conversions.GeoToWorldPosition(Lat, Lon, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        this.gameObject.transform.LookAt(ARCamera.transform);

        if ((Player.transform.position.x < this.transform.position.x + 15 && Player.transform.position.x > this.transform.position.x - 15) && (Player.transform.position.z < this.transform.position.z + 15 && Player.transform.position.z > this.transform.position.z - 15))
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
}
