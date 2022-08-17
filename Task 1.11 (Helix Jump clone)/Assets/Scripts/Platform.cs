using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private CameraMovement Camera;
    [SerializeField] private GameObject Sphere;
    [SerializeField] public bool isFinish = false;

    private float platformDespawnTimer = 0;
    // Update is called once per frame
    void Update()
    {
        if (platformDespawnTimer > 0)
            platformDespawnTimer -= Time.deltaTime;
        if (platformDespawnTimer < 0)
            GameObject.Destroy(gameObject);
    }

    public void ExplodePlatform() 
    {
        gameObject.transform.parent = null;
        GetComponent<BoxCollider>().enabled = false;
        Rigidbody[] sectors = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody body in sectors) {
            body.isKinematic = false;
            body.freezeRotation = false;
            body.AddExplosionForce(500, transform.position + (Vector3.down / 2), 3);
        }
        platformDespawnTimer = 2;
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Sphere) return;

        if (!isFinish) {
            Sphere.GetComponent<JumpingSphere>().PlatformPassed();
            ExplodePlatform();
        }
        else {
            Sphere.GetComponent<JumpingSphere>().Win();
        }
        //add score
    }
}
