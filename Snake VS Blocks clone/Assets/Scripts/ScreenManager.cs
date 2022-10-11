using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private LoseScreen loseScreen;
    [SerializeField] private WinScreen winScreen;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private SnakeMovement snake;
    [SerializeField] private FinishInteraction finish;
    [SerializeField] private int levelNumber;
    [SerializeField] private int score = 0;
    [SerializeField] private int defaultSnakeLength = 4;
    private float levelLength = 0;

    // Start is called before the first frame update
    private void Awake() {
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        if (levelNumber != 0)
        {
            currentLevel = GameObject.Find("Level");
            snake = currentLevel.GetComponentInChildren<SnakeMovement>();
            finish = currentLevel.GetComponentInChildren<FinishInteraction>();
            snake.SetSnakeLength(PlayerPrefs.GetInt("Snake length", defaultSnakeLength));
        }
        else
        {
            PlayerPrefs.SetInt("Snake length", defaultSnakeLength);
        }
    }
    void Start()
    {
        if (levelNumber == 0)
        {
            gameScreen.DeactivateScreen();
            loseScreen.DeactivateScreen();
            winScreen.DeactivateScreen();
            startScreen.ActivateScreen();
        }
        else 
        {
            gameScreen.ActivateScreen();
            gameScreen.SetLevelTexts(levelNumber);
            CalculateLevelLength();
            startScreen.DeactivateScreen();
            loseScreen.DeactivateScreen();
            winScreen.DeactivateScreen();
        }
    }

    private void CalculateLevelLength()
    {
        levelLength = finish.transform.position.z - snake.transform.position.z;
    }

    public void SetLevelProgress(float headPositionZ)
    {
        float distanceToFinish = finish.transform.position.z - headPositionZ;
        float progress = (levelLength - distanceToFinish) / levelLength;
        gameScreen.SetLevelProgress(progress);
    }
    public void AddToScore()
    {
        score++;
        gameScreen.AddToScore();
    }

    public void StartLevel()
    {
        startScreen.DeactivateScreen();
        loseScreen.DeactivateScreen();
        winScreen.DeactivateScreen();
        gameScreen.ActivateScreen();
        startScreen.StartLevel();
    }
    public void Win()
    {
        startScreen.DeactivateScreen();
        loseScreen.DeactivateScreen();
        gameScreen.ActivateScreen();
        winScreen.ActivateScreen();
        winScreen.ChangeLevelCompletedText(levelNumber);
        SetHighScore();
        PlayerPrefs.SetInt("Snake length", snake.GetSnakeLength());
    }

    public void Lose()
    {
        startScreen.DeactivateScreen();
        loseScreen.ActivateScreen();
        gameScreen.ActivateScreen();
        winScreen.DeactivateScreen();
        SetHighScore();
        loseScreen.SetScoreTexts(score, PlayerPrefs.GetInt("HighScore" + levelNumber, 0));
    }

    private void SetHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore" + levelNumber, 0) < score)
        {
            PlayerPrefs.SetInt("HighScore" + levelNumber, score);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(levelNumber);
    }
    public void StartNextLevel()
    {
        if (levelNumber < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(levelNumber + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
