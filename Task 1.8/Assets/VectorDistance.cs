using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDistance : MonoBehaviour
{
    public Transform V1, V2;
    public Transform result;
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
        result.position = new Vector3(0, Vector3.Distance(V1.position, V2.position), 0);
        DrawVector(transform.position, transform.position + result.position);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Gizmos.DrawLine(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
