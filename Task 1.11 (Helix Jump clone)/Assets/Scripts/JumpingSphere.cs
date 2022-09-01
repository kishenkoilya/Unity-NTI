using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSphere : MonoBehaviour
{
    [SerializeField] private ScreenManager screenManager;
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private int platformsPassedWithoutCollision;
    [SerializeField] private Material SphereMaterial;
    [SerializeField] private ParticleSystem rockets;
    [SerializeField] private ParticleSystem deathPS;
    private float timeTilDeath = 0;

    void Start()
    {
        screenManager = GameObject.Find("Canvas").GetComponent<ScreenManager>();
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        rockets = GameObject.Find("WinPS").GetComponent<ParticleSystem>();
        deathPS = GameObject.Find("LosePS").GetComponent<ParticleSystem>();
        SphereMaterial.SetFloat("_StepEdge", 0);
        SphereMaterial.SetFloat("_EmissionThickness", 0);
        screenManager.StartingProcedures();
    }
    void OnCollisionEnter(Collision other)
    {
        if (platformsPassedWithoutCollision >= 3) {
            Platform p = other.collider.gameObject.GetComponentInParent<Platform>();
            if (p && !p.isFinish) {
                PlatformPassed();
                p.ExplodePlatform();
            }
        }

        sphereRigidBody.Sleep();
        sphereRigidBody.WakeUp();
        sphereRigidBody.AddRelativeForce(Vector3.up * 5, ForceMode.VelocityChange);
        platformsPassedWithoutCollision = 0;
    }

    public void PlatformPassed() {
        screenManager.AddScore(1 + platformsPassedWithoutCollision);
        cameraMovement.MoveCameraDown(2, 0.3f - (platformsPassedWithoutCollision * 0.02f));
        platformsPassedWithoutCollision++;
    }

    public void Death()
    {
        // sphereRigidBody.Sleep();
        Debug.Log(deathPS);
        deathPS.Play();
        timeTilDeath = 1f;
        sphereRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        SphereMaterial.SetFloat("_EmissionThickness", 0.05f);
        // AudioSource explosionSound = GetComponent<AudioSource>();
        // explosionSound.PlayDelayed(0.8f);
    }

    public void Win()
    {
        sphereRigidBody.Sleep();
        sphereRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        rockets.Play();
        screenManager.WinLevel();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timeTilDeath > 0)
        {
            // gameObject.transform.localScale += Vector3.one * Time.deltaTime;
            timeTilDeath -= Time.deltaTime;
            SphereMaterial.SetFloat("_StepEdge", 1 - timeTilDeath);
            // if (timeTilDeath < 0.5f)
            // {
            //     sphereRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            // }
            if (timeTilDeath <= 0)
            {
                screenManager.LoseGame();
                GameObject.Destroy(gameObject);
            }
        }
    }
}
