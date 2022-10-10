using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private LoseScreen loseScreen;
    private GameObject currentLevel;
    private SnakeMovement snake;
    private int levelNumber;
    private int score = 0;

    // Start is called before the first frame update
    private void Awake() {
        levelNumber = PlayerPrefs.GetInt("currentLevel", 1);
        currentLevel = GameObject.Find("Level");
        snake = currentLevel.GetComponentInChildren<SnakeMovement>();
    }
    void Start()
    {
    }

    public void Win()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
