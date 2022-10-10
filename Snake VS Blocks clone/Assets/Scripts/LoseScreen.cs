using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreen : ScreenScript
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highestScoreText;

    public void SetScoreTexts(int currentScore, int highestScore)
    {
        currentScoreText.text = "" + currentScore;
        highestScoreText.text = "High score:\n" + highestScore;
    }
}
