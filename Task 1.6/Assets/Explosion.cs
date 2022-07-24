using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Explosion!!!!");
        GameObject[] Objs = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in Objs) {
            Rigidbody rigid = obj.GetComponent<Rigidbody>();
            Transform transform = obj.GetComponent<Transform>();
            Vector3 distance = transform.position - gameObject.transform.position;
            Vector3 direction = Vector3.Normalize(distance);
            if (rigid) {
                rigid.AddForce(direction * (2000 / Mathf.Pow(Vector3.Magnitude(distance), 2)), ForceMode.Force);
            }
        }
        GameObject.Destroy(gameObject);
    }
}
