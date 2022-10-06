using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> bodyParts = new List<Rigidbody>();
    [SerializeField] private List<MarkerManager> bodyPartsMarkers = new List<MarkerManager>();
    [SerializeField] private float shiftSpeed = 5;
    [SerializeField] private float forwardSpeed = 1;
    [SerializeField] private ObjectsPool snakeBodiesPool;
    [SerializeField] private TextMeshProUGUI snakeLengthText;
    [SerializeField] private float distanceBetweenParts = 2;
    [SerializeField] private int beginningPartsCount = 5;
    private Vector3 previousHeadPosition;
    public float CollisionTimer = 0;
    [SerializeField] private GameObject Camera;
    float MousePositionX = 0;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponentsInChildren<Rigidbody>(bodyParts);
        previousHeadPosition = bodyParts[0].position;
        GetComponentsInChildren<MarkerManager>(bodyPartsMarkers);
        snakeLengthText.text = "" + bodyParts.Count;
        foreach (MarkerManager mm in bodyPartsMarkers)
            mm.ClearMarkers();
        for (int i = 0; i < beginningPartsCount - 1; i++)
        {
            GrowBodyPart();
        }
    }  
    private void FixedUpdate()
    {
        if (bodyParts.Count > 0)
        {
            if (CollisionTimer > 0)
            {
                CollisionTimer -= Time.deltaTime;
            }
            MousePositionX = (Input.mousePosition.x - Screen.width / 2) / Screen.width * 20;
            MousePositionX = MousePositionX < -9.5f ? -9.5f : MousePositionX;
            MousePositionX = MousePositionX > 9.5f ? 9.5f : MousePositionX;
            ShiftHead();
            RotateHead();
            Camera.transform.position += new Vector3(0, 0, (bodyParts[0].position - previousHeadPosition).z);
            previousHeadPosition = bodyParts[0].position;
            if (bodyParts.Count > 1) 
            {
                for (int i = 1; i < bodyParts.Count; i++)
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
        bodyParts[0].velocity = new Vector3((MousePositionX - bodyParts[0].position.x) * shiftSpeed, 0, 
                                            CollisionTimer > 0 ? 0 : forwardSpeed);
    }
    private void RotateHead()
    {
        Vector3 destination = new Vector3 (MousePositionX, bodyParts[0].position.y, bodyParts[0].position.z + 1);
        bodyParts[0].rotation = Quaternion.LookRotation(destination - bodyParts[0].position, Vector3.up);
    }

    private void MoveBodyPart(int index)
    {
        while (bodyPartsMarkers[index - 1].totalDistance > distanceBetweenParts)
        {
            MarkerManager.Marker marker = bodyPartsMarkers[index - 1].GetMarker();
            bodyParts[index].position = marker.position;
            bodyParts[index].rotation = marker.rotation;
        }
    }

    public void pushHeadBack()
    {
        bodyParts[0].velocity = Vector3.zero;
        bodyParts[0].position -= new Vector3(0, 0, 0.3f);
    }
    public void DestroyBodyPart()
    {
        int lastIndex = bodyParts.Count - 1;
        snakeBodiesPool.ReturnObject(bodyParts[lastIndex].gameObject);
        bodyParts.RemoveAt(lastIndex);
        bodyPartsMarkers.RemoveAt(lastIndex);
        snakeLengthText.text = "" + bodyParts.Count;
    }

    public void GrowBodyPart()
    {
        GameObject bodyPart = snakeBodiesPool.GetObject();
        bodyPart.transform.parent = bodyParts[0].transform.parent;
        bodyPart.transform.position = bodyParts[bodyParts.Count - 1].gameObject.transform.position;
        Rigidbody bodyPartRB = bodyPart.GetComponent<Rigidbody>();
        bodyParts.Add(bodyPartRB);
        bodyPartsMarkers.Add(bodyPart.gameObject.GetComponent<MarkerManager>());
        snakeLengthText.text = "" + bodyParts.Count;
    }
}
