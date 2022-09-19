using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> bodyParts = new List<Transform>();
    [SerializeField] private List<MarkerManager> bodyPartsMarkers = new List<MarkerManager>();
    [SerializeField] private float shiftSpeed = 5;
    [SerializeField] private float forwardSpeed = 1;
    private Vector3 previousHeadPosition;
    [SerializeField] private float distancePassed = 0;
    float MousePositionX = 0;
    private float shiftLerpT = 0;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponentsInChildren<Transform>(bodyParts);
        previousHeadPosition = bodyParts[0].position;
        bodyParts.RemoveAt(0);
        GetComponentsInChildren<MarkerManager>(bodyPartsMarkers);
    }  
    private void Update()
    {
        bodyParts[0].Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        MousePositionX = (Input.mousePosition.x - Screen.width / 2) / Screen.width * 20;
        MousePositionX = MousePositionX < -9.5f ? -9.5f : MousePositionX;
        MousePositionX = MousePositionX > 9.5f ? 9.5f : MousePositionX;
        ShiftHead();
        RotateHead();
        distancePassed = (bodyParts[0].position - previousHeadPosition).magnitude;
        previousHeadPosition = bodyParts[0].position;
        if (bodyParts.Count > 1) 
        {
            for (int i = 1; i < bodyParts.Count; i++)
            {
                if ((bodyParts[i-1].transform.position - bodyParts[i].transform.position).magnitude > 1)
                {
                    MoveBodyPart(i);
                }
            }
        }
    }

    private void ShiftHead()
    {
        if (MousePositionX == bodyParts[0].position.x)
        {
            return;
        }
        float distance = Mathf.Abs(bodyParts[0].position.x - MousePositionX);
        shiftLerpT = shiftSpeed / distance;

        float interpolatedX = Mathf.Lerp(bodyParts[0].position.x, MousePositionX, shiftLerpT * Time.deltaTime);
        bodyParts[0].position = new Vector3(interpolatedX, bodyParts[0].position.y, bodyParts[0].position.z);
    }
    private void RotateHead()
    {
        Vector3 destination = new Vector3 (MousePositionX, bodyParts[0].position.y, bodyParts[0].position.z + 3);
        bodyParts[0].rotation = Quaternion.LookRotation(destination - bodyParts[0].position, Vector3.up);
    }

    private void MoveBodyPart(int index)
    {
        float distanceToMove = distancePassed;
        while (distanceToMove > 0) 
        {
            MarkerManager.Marker marker = bodyPartsMarkers[index-1].PeekMarker();
            if (distanceToMove > (marker.position - bodyParts[index].position).magnitude)
            {
                marker = bodyPartsMarkers[index-1].GetMarker();
                distanceToMove -= (marker.position - bodyParts[index].position).magnitude;
                bodyParts[index].position = marker.position;
                bodyParts[index].rotation = marker.rotation;
            }
            else
            {
                bodyParts[index].rotation = Quaternion.LookRotation(marker.position - bodyParts[index].position, Vector3.up);
                bodyParts[index].position = Vector3.MoveTowards(bodyParts[index].position, marker.position, distanceToMove);
                distanceToMove = 0;
            }
        }
        
    }
}
