using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : ScreenScript
{
    [SerializeField] int chosenLevel;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI chosenLevelText;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 1;
        slider.maxValue = SceneManager.sceneCountInBuildSettings - 1;
        chosenLevel = (int)slider.value;
    }

    public void ChooseLevel()
    {
        chosenLevel = (int)slider.value;
        chosenLevelText.text = "" + chosenLevel;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(chosenLevel);
    }
}
