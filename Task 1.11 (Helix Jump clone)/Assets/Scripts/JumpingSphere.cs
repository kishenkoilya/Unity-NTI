using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSphere : MonoBehaviour
{
    [SerializeField] private ScreenManager screenManager;
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private int platformsPassedWithoutCollision;
    [SerializeField] private AudioClip explosionClip;
    private AudioSource audioSource;
    private float timeTilDeath = 0;

    void Start()
    {
        screenManager = GameObject.Find("Canvas").GetComponent<ScreenManager>();
        cameraMovement = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        audioSource = GetComponent<AudioSource>();
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

        audioSource.volume = 0.5f;
        audioSource.Play();

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
        timeTilDeath = 1f;
        
        audioSource.clip = explosionClip;
        audioSource.volume = 4;
        audioSource.PlayDelayed(0.8f);
    }

    public void Win()
    {
        sphereRigidBody.Sleep();
        screenManager.WinLevel();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timeTilDeath > 0)
        {
            gameObject.transform.localScale += Vector3.one * Time.deltaTime;
            timeTilDeath -= Time.deltaTime;
            if (timeTilDeath < 0.5f)
            {
                sphereRigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            }
            if (timeTilDeath <= 0)
            {
                screenManager.LoseGame();
                GameObject.Destroy(gameObject);
            }
        }
    }
}
