using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodInteractions : MonoBehaviour
{
    private TextMeshProUGUI foodCountText;
    [SerializeField] private ObjectsPool foodPool;
    [SerializeField] private int foodCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        foodCountText = GetComponentInChildren<TextMeshProUGUI>(true);
        foodCountText.text = "" + foodCount;
        foodPool = GameObject.Find("FoodPool").GetComponent<ObjectsPool>();
    }

    void OnTriggerEnter(Collider other)
    {
        SnakeMovement snake = other.GetComponentInParent<SnakeMovement>();
        if (snake) 
        {
            for (int i = 0; i < foodCount; i++)
            {
                snake.GrowBodyPart();
            }
        }
        foodPool.ReturnObject(gameObject);
    }
}
