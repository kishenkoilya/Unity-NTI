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
    [SerializeField] public List<Vector3> positions = new List<Vector3>();
    private Vector3 lastAddedMarkerPosition;
    public float totalDistance;
    // Start is called before the first frame update
    private void Start()
    {
        Markers.Enqueue(new Marker(transform.position, transform.rotation, 0));
        lastAddedMarkerPosition = transform.position;
        positions.Add(transform.position);
        totalDistance = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        AddMarker();
    }

    private void AddMarker()
    {
        float dist = (lastAddedMarkerPosition - transform.position).magnitude;
        Markers.Enqueue(new Marker(transform.position, transform.rotation, dist));
        positions.Add(transform.position);
        lastAddedMarkerPosition = transform.position;
        totalDistance += dist;
    }

    public void ClearMarkers()
    {
        Markers.Clear();
        Markers.Enqueue(new Marker(transform.position, transform.rotation, 0));
        positions.Clear();
        positions.Add(transform.position);
        lastAddedMarkerPosition = transform.position;
        totalDistance = 0;
    }

    public Marker GetMarker()
    {
        totalDistance -= Markers.Peek().distance;
        positions.RemoveAt(0);
        return Markers.Dequeue();
    }

    public Marker PeekMarker()
    {
        return Markers.Peek();
    }

    public int GetCount()
    {
        return Markers.Count;
    }

    public void UpdateDistance(float distanceDelta)
    {
        // Markers.Peek().distance -= distanceDelta;
        totalDistance -= distanceDelta;
    }
}
