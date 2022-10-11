using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishInteraction : MonoBehaviour
{
    [SerializeField] private ScreenManager screenManager;
    [SerializeField] private ParticleSystem winPS;
    private void Start() {
        screenManager = GameObject.Find("PlayerUI").GetComponent<ScreenManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        SnakeMovement snake = other.transform.parent.GetComponent<SnakeMovement>();
        if (snake)
        {
            Debug.Log("1");
            winPS.Play();
            screenManager.Win();
            snake.Finish();
        }
    }
}
