using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private WinScreen winScreen;
    [SerializeField] private LoseScreen loseScreen;
    [SerializeField] private int score = 0;
    [SerializeField] private List<int> bestScore;
    static private GameObject instance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (!instance) 
        {
            instance = gameObject;
            bestScore = new List<int>(SceneManager.sceneCountInBuildSettings);
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                bestScore.Add(0);
            }
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        startScreen.ActivateScreen();
        gameScreen.DeactivateScreen();
        winScreen.DeactivateScreen();
        loseScreen.DeactivateScreen();
    }

    public void StartingProcedures()
    {
        gameScreen.StartingProcedures();
    }

    public void StartGame() 
    {
        startScreen.DeactivateScreen();
        gameScreen.ActivateScreen();
        gameScreen.ResetScore();
    }

    public void AddScore(int value)
    {
        gameScreen.AddLevelProgress();
        int index = SceneManager.GetActiveScene().buildIndex;
        score += value;
        if (bestScore[index] < score) 
        {
            bestScore[index] = score;
        }
        gameScreen.SetScore(score, bestScore[index]);
    }

    public void LoseGame()
    {
        loseScreen.ActivateScreen();
        // gameScreen.SetPanelStatus(false);
        loseScreen.LoseGame(gameScreen.GetLevelProgress(), score);
    }

    private void ResetScore()
    {
        score = 0;
        gameScreen.ResetScore();
    }
    public void RestartLevel()
    {
        loseScreen.DeactivateScreen();
        // gameScreen.SetPanelStatus(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetScore();
    }

    public void WinLevel()
    {
        winScreen.ActivateScreen();
        // gameScreen.SetPanelStatus(false);
    }

    public void NextLevel()
    {
        // gameScreen.SetPanelStatus(true);
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            RestartLevel();
        }
        winScreen.DeactivateScreen();
    }
}
