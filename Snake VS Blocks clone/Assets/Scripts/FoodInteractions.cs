using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class FoodInteractions : MonoBehaviour
{
    private TextMeshProUGUI foodCountText;
    private AudioSource sound;
    [SerializeField] private ObjectsPool foodPool;
    [SerializeField] private int foodCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        foodCountText = GetComponentInChildren<TextMeshProUGUI>(true);
        foodCountText.text = "" + foodCount;
        foodPool = GameObject.Find("FoodPool").GetComponent<ObjectsPool>();
        sound = GetComponent<AudioSource>();
    }

    private void Update() {
        foodCountText.text = "" + foodCount;
    }
    void OnTriggerEnter(Collider other)
    {
        SnakeMovement snake = other.GetComponentInParent<SnakeMovement>();
        if (snake) 
        {
            sound.Play();
            for (int i = 0; i < foodCount; i++)
            {
                snake.GrowBodyPart();
            }
        }
        foodPool.ReturnObject(gameObject);
    }
}
