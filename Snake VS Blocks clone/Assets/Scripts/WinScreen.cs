using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : ScreenScript
{
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public void SetScores(int score, int highScore)
    {
        currentScoreText.text = "" + score;
        highScoreText.text = "high score:\n" + highScore;
    }
}
