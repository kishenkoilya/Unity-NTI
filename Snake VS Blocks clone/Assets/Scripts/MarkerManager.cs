using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    public class Marker
    {
        public Vector3 position;
        public Quaternion rotation;
        public float distance;

        public Marker(Vector3 pos, Quaternion rot, float dist)
        {
            position = pos;
            rotation = rot;
            distance = dist;
        }
    }

    private Queue<Marker> Markers = new Queue<Marker>();
    private Vector3 lastAddedMarkerPosition;
    // Start is called before the first frame update
    private void Start()
    {
        Markers.Enqueue(new Marker(transform.position, transform.rotation, 0));
        lastAddedMarkerPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        AddMarker();
    }

    private void AddMarker()
    {
        float dist = (lastAddedMarkerPosition - transform.position).magnitude;
        Markers.Enqueue(new Marker(transform.position, transform.rotation, dist));
        lastAddedMarkerPosition = transform.position;
    }

    private void ClearMarkers()
    {
        Markers.Clear();
        Markers.Enqueue(new Marker(transform.position, transform.rotation, 0));
        lastAddedMarkerPosition = transform.position;
    }

    public Marker GetMarker()
    {
        return Markers.Dequeue();
    }

    public Marker PeekMarker()
    {
        return Markers.Peek();
    }
}
