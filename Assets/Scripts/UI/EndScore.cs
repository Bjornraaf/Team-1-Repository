using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///----------------------------------------$$$$$$$\   $$$$$$\  $$$$$$$\   $$$$$$\  
///----------------------------------------$$  __$$\ $$  __$$\ $$  __$$\ $$$ __$$\ 
///----------------------------------------$$ |  $$ |$$ /  $$ |$$ |  $$ |$$$$\ $$ |
///----------Author------------------------$$$$$$$  |$$$$$$$$ |$$$$$$$  |$$\$$\$$ |
///----------Patryk Podworny---------------$$  ____/ $$  __$$ |$$  ____/ $$ \$$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      $$ |\$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      \$$$$$$  /
///----------------------------------------\__|      \__|  \__|\__|       \______/ 

public class EndScore : MonoBehaviour
{
    [Tooltip("The text that displays the end score")]
    public Text endScoreText; // String that changes depending on the score.
    public int endScore = 0; // Int of the end score that is shown in the game over screen.
    public ScoreScript scoreScript; // The score script.
    public GameObject[] uiElements; // The Ui elements that are turned off after the game ends.
    public GameObject levelLoader;

    public void endGame()
    {
        endScore = scoreScript.gameScore;
        foreach (var uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
        endScoreText.text = "Eindscore: " + endScore;
    }
}
