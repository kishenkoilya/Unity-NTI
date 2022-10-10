using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishInteraction : MonoBehaviour
{
    [SerializeField] private ScreenManager screenManager;
    [SerializeField] private ParticleSystem winPS;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        SnakeMovement snake = other.transform.parent.GetComponent<SnakeMovement>();
            Debug.Log("1");
        if (snake)
        {
            Debug.Log("1");
            winPS.Play();
            screenManager.Win();
            snake.Finish();
        }
    }
}
