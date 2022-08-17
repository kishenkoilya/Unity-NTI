using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : Screen
{
    [SerializeField] TextMeshProUGUI levelCompletedText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        levelCompletedText.text = SceneManager.GetActiveScene().name + " COMPLETED!!";
    }
}
