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
        Gizmos.color = Color.cyan;
        DrawVector(transform.position, V1.position);
        Gizmos.color = Color.magenta;
        DrawVector(transform.position, V2.position);
        Gizmos.color = Color.yellow;
        DrawVector(transform.position, V1.position - V2.position);
        Gizmos.color = Color.black;
        DrawVector(V2.position, V1.position - V2.position);
    }

    void DrawVector(Vector3 start, Vector3 destination) 
    {
        Gizmos.DrawRay(start, destination);
        Gizmos.DrawWireSphere(destination, 0.1f);
    }
}
