using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CubeInteractions : MonoBehaviour
{
    [SerializeField] ObjectsPool cubesPool;
    [SerializeField] ScreenManager screenManager;
    [SerializeField] int cubeCount = 0;
    private TextMeshProUGUI cubeCountText;
    private Material cubeMaterial;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        cubeCountText = GetComponentInChildren<TextMeshProUGUI>(true);
        cubeMaterial = GetComponent<Renderer>().material;
        SetCounter();
        cubesPool = GameObject.Find("CubesPool").GetComponent<ObjectsPool>();
        sound = GetComponent<AudioSource>();
        screenManager = GameObject.Find("PlayerUI").GetComponent<ScreenManager>();
    }
    private void SetCounter()
    {
        cubeCountText.text = "" + cubeCount;
        cubeMaterial.SetFloat("_Count", cubeCount);
    }
    void OnCollisionEnter(Collision other)
    {
        SnakeMovement sm = other.collider.GetComponentInParent<SnakeMovement>();
        if (sm)
        {
            screenManager.AddToScore();
            sound.Play();
            sm.PlayParticleSystem();
            sm.CollisionTimer = 0.3f;
            sm.pushHeadBack();
            sm.DestroyBodyPart();
        }
        cubeCount--;
        SetCounter();
        if (cubeCount == 0)
        {
            cubesPool.ReturnObject(gameObject);
        }
    }
}
