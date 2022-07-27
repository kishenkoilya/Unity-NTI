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
        DrawVector(transform.position, V1.position);
        Gizmos.color = Color.red;
        DrawVector(transform.position, V2.position);
        Gizmos.color = Color.green;
        result = V1.position + V2.position;
        DrawVector(transform.position, result);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Gizmos.DrawRay(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
