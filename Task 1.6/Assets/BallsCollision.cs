using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsCollision : MonoBehaviour
{
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<BallsCollision>()) {
            Debug.Log(gameObject.name + " collided with " + other.gameObject.name);
        }
    }
}
