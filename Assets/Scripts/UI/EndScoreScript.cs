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

/// <summary>  
/// Class determines and shows the ending score and turns off certain UI elements when the game ends.
/// </summary>

public class EndScoreScript : MonoBehaviour
{
    #region Variables

    [Tooltip("The text that displays the end score")]
    public Text endScoreText; // String that changes depending on the score.

    [Tooltip("The scorescript that contains the game score")]
    public ScoreScript scoreScript; // The score script.

    [Tooltip("The UI elements that are disabled at the end of the game")]
    public GameObject[] uiElements; // The Ui elements that are turned off after the game ends.

    private int EndScore = 0; // Int of the end score that is shown in the game over screen.

    #endregion

    #region Custom Functions

    /// Set EndScore, disable UI elemenets, and show the ending score.
    /// </summary>
    public void endGame()
    {
        EndScore = scoreScript.gameScore; //Set the end score variable equal to the current game score.
        foreach (var uiElement in uiElements) //Set every item in uiElements as a seperate variable.
        {
            uiElement.SetActive(false);  //Turn off every UI element from the uiElements array.
        }
        endScoreText.text = "Eindscore: " + EndScore; //Changes the UI text combining a string and the EndScore int.
    }

    #endregion
}
