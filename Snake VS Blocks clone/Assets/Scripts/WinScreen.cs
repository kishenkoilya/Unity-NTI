using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : ScreenScript
{
    [SerializeField] TextMeshProUGUI levelCompletedText;

    public void ChangeLevelCompletedText(int level)
    {
        levelCompletedText.text = "Level " + level + "\nCOMPLETED!";
    }
}
