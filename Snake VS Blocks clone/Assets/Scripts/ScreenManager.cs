using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private LoseScreen loseScreen;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private SnakeMovement snake;
    [SerializeField] private int levelNumber;
    [SerializeField] private int score = 0;

    // Start is called before the first frame update
    private void Awake() {
        levelNumber = PlayerPrefs.GetInt("currentLevel", 0);
        if (levelNumber != 0)
        {
            currentLevel = GameObject.Find("Level");
            snake = currentLevel.GetComponentInChildren<SnakeMovement>();
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            gameScreen.DeactivateScreen();
            loseScreen.DeactivateScreen();
            startScreen.ActivateScreen();
        }
    }

    public void Win()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
