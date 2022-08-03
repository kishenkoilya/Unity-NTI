using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMultiply : MonoBehaviour
{
    public Transform V1;
    public float modifier;
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        DrawVector(transform.position, V1.position);

        Gizmos.color = Color.green;
        DrawVector(transform.position, transform.position + V1.localPosition * modifier);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Gizmos.DrawLine(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
