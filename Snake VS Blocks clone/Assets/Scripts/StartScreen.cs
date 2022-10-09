using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartScreen : ScreenScript
{
    [SerializeField] int chosenLevel;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI chosenLevelText;
    // Start is called before the first frame update
    void Start()
    {
        chosenLevel = (int)slider.value;
    }

    public void ChooseLevel()
    {
        chosenLevel = (int)slider.value;
        chosenLevelText.text = "" + chosenLevel;
    }

    public void StartLevel()
    {
        Debug.Log("Level " + chosenLevel + " started!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
