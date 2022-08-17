using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreen : Screen
{
    [SerializeField] private ScreenManager sm;
    [SerializeField] private TextMeshProUGUI completedText;
    [SerializeField] private TextMeshProUGUI newRecordText;
    [SerializeField] private int bestScore = 0;
    public void LoseGame(float completed, int score)
    {
        completedText.text = "" + Mathf.Round(completed * 100) + "% COMPLETED";
        if (score > bestScore) {
            newRecordText.text = "NEW RECORD:\n" + score;
        }
        else 
        {
            newRecordText.text = "";
        }
    }
}
