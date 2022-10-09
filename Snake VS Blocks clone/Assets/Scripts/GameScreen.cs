using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreen : ScreenScript
{
    [SerializeField] TextMeshProUGUI currentLevelText; 
    [SerializeField] TextMeshProUGUI nextLevelText; 
    [SerializeField] Slider levelProgress;

    public void SetLevelTexts(int Level)
    {
        currentLevelText.text = "" + Level;
        nextLevelText.text = "" + (Level + 1);
    }

    public void SetLevelProgress(float progress)
    {
        levelProgress.value = progress;
    }
}
