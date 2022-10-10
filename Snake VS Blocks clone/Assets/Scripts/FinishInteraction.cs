using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishInteraction : MonoBehaviour
{
    [SerializeField] private ScreenManager screenManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        SnakeMovement snake = other.GetComponent<SnakeMovement>();
        if (snake)
        {
            screenManager.Win();
        }
    }
}
