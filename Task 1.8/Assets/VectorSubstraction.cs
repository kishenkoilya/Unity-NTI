using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSubstraction : MonoBehaviour
{
    public Transform V1, V2;
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
        DrawVector(transform.position, transform.position + V1.position - V2.position);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Debug.Log("Substraction: " + start + "    " + destination);
        Gizmos.DrawLine(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
