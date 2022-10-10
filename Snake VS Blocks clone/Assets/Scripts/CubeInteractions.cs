using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CubeInteractions : MonoBehaviour
{
    private TextMeshProUGUI cubeCountText;
    private Material cubeMaterial;
    private AudioSource sound;
    [SerializeField] ObjectsPool cubesPool;
    [SerializeField] int cubeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        cubeCountText = GetComponentInChildren<TextMeshProUGUI>(true);
        cubeMaterial = GetComponent<Renderer>().material;
        SetCounter();
        cubesPool = GameObject.Find("CubesPool").GetComponent<ObjectsPool>();
        sound = GetComponent<AudioSource>();
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
