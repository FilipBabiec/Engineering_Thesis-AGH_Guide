using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using UnityEngine;
using Mapbox.Unity.Utilities;

public class LocationScriptPOI : MonoBehaviour
{
    //public Vector2d(50.065927, 19.918732);
    //public Location = new Mapbox.Utils.Vector2d(50.065927, 19.918732);

    // Update is called once per frame

    public double Lat;
    public double Lon;

    void Update()
    {
        var _map = LocationProviderFactory.Instance.mapManager;
        this.transform.position = Conversions.GeoToWorldPosition(Lat, Lon, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
    }
}
