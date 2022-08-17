using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameScreen : Screen, IDragHandler
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI currentLevelText;
    [SerializeField] private TextMeshProUGUI NextLevelText;
    [SerializeField] private GameObject allPlatforms;
    [SerializeField] private GameObject backGround;
    [SerializeField] private Slider levelProgress;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void FindRotatingGameObjects()
    {
        allPlatforms = GameObject.Find("All Platforms");
        backGround = GameObject.Find("BackGround");
    }

    private void SetProgressBarMax()
    {
        levelProgress.maxValue = allPlatforms.transform.childCount - 1;
    }

    private void SetLevelNumbers()
    {
        currentLevelText.text = "" + (SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            NextLevelText.text = "" + (SceneManager.GetActiveScene().buildIndex + 2);
        else
            NextLevelText.text = "";
    }

    public void StartingProcedures()
    {
        FindRotatingGameObjects();
        SetProgressBarMax();
        SetLevelNumbers();
    }

    public void AddLevelProgress() 
    {
        levelProgress.SetValueWithoutNotify(levelProgress.value + 1);
    }

    public void SetScore(int score, int bestScore)
    {
        scoreText.text = "" + score;
        bestScoreText.text = "BEST: " + bestScore;
    }

    public void ResetScore()
    {
        scoreText.text = "0";
        levelProgress.SetValueWithoutNotify(0);
    }

    public float GetLevelProgress()
    {
        return levelProgress.value / levelProgress.maxValue;
    }
    
    // public void SetPanelStatus(bool status)
    // {
    //     panel.SetActive(status);
    // }
    
    public void OnDrag(PointerEventData eventData)
    {
        allPlatforms.transform.Rotate(Vector3.down / 3 * eventData.delta.x);
        backGround.transform.Rotate(Vector3.down / 3 * eventData.delta.x);
    }
}
