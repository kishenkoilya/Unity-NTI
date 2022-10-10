using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreen : ScreenScript
{
    [SerializeField] private TextMeshProUGUI currentLevelText; 
    [SerializeField] private TextMeshProUGUI nextLevelText; 
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI levelCompletedText;
    private int score = 0;
    [SerializeField] Slider levelProgress;

    private void Start() {
        scoreTMP.text = "" + score;
    }
    public void SetLevelTexts(int Level)
    {
        currentLevelText.text = "" + Level;
        nextLevelText.text = "" + (Level + 1);
    }

    public void SetLevelProgress(float progress)
    {
        levelProgress.value = progress;
    }

    public void AddToScore(int points = 1)
    {
        score += points;
        scoreTMP.text = "" + score;
    }
    
    public void SetLevelCompleted(int level)
    {
        levelCompletedText.gameObject.SetActive(true);
        levelCompletedText.text = "Level " + level + " COMPLETED!";
    }

    public void DeactivateLevelCompletedText()
    {
        levelCompletedText.gameObject.SetActive(false);
    }
}
