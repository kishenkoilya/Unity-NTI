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
        Gizmos.color = new Color(0.6f, 0, 0.6f, 1f);
        result.position = new Vector3(0, Vector3.Distance(V1.position, V2.position), 0);
        DrawVector(transform.position, result.position);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Gizmos.DrawRay(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
