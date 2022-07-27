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
        Gizmos.color = Color.white;
        DrawVector(transform.position, V1.position);

        Gizmos.color = Color.gray;
        DrawVector(transform.position, V1.position * modifier);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Gizmos.DrawRay(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
