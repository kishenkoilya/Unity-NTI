using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSum : MonoBehaviour
{

    public Transform V1, V2;
    public Vector3 result;
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        DrawVector(transform.position, transform.position + V1.localPosition);
        Gizmos.color = Color.red;
        DrawVector(transform.position, transform.position + V2.localPosition);
        Gizmos.color = Color.green;
        result = transform.position + V1.localPosition + V2.localPosition;
        DrawVector(transform.position, result);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Debug.Log(start + "    " + destination);
        Gizmos.DrawLine(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
