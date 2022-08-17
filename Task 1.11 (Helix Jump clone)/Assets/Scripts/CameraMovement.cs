using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 resultingPosition;
    [SerializeField] private float timeToMove = 0;
     

    void Awake()
    {
        resultingPosition = transform.position;
    }

    void Start()
    {
        GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = gameObject.GetComponent<Camera>();
    }
    public void MoveCameraDown(float scale, float time) {
        resultingPosition += Vector3.down * scale;
        timeToMove = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToMove > 0) {
            Vector3 distanceToMove = (resultingPosition - transform.position) / timeToMove * Time.deltaTime;
            transform.position += distanceToMove;
            timeToMove -= Time.deltaTime;
            if (timeToMove <= 0) {
                timeToMove = 0;
                transform.position = resultingPosition;
            }
        }
    }
}
