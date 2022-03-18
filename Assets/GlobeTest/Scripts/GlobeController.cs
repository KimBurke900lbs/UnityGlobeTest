using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeController : MonoBehaviour
{
    public GameObject globe;
    public GameObject markerPrefab;

    [Range(1,5)]
    public float radius = 5.0f;
    public List<PointOfInterest> pois = new List<PointOfInterest>();

    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        globe.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
        foreach(PointOfInterest poi in pois)
        {
            SetMarker(poi);
        }
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            globe.transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) * Time.deltaTime * rotationSpeed);
        }
    }

    private void SetMarker(PointOfInterest poi)
    {
        float lat_rad = poi.Latitude * Mathf.Deg2Rad;
        float long_rad = poi.Longitude * Mathf.Deg2Rad;
        float x = -radius * Mathf.Cos(lat_rad) * Mathf.Sin(long_rad);
        float y = Mathf.Sin(lat_rad) * radius;
        float z = radius * Mathf.Cos(lat_rad) * Mathf.Cos(long_rad);

        GameObject markerObj = Instantiate(markerPrefab);
        markerObj.transform.position = new Vector3(x, y, z);
        markerObj.transform.localScale = markerObj.transform.localScale * radius * 2;
        markerObj.transform.LookAt(globe.transform);
        markerObj.transform.parent = globe.transform;

        markerObj.GetComponent<MarkerView>().SetLabel(poi.LocationName);
    }
}
