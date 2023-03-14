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
/// Class that contains the player score and changes the UI text depending on the score.
/// </summary>

public class ScoreScript : MonoBehaviour
{
    #region Variables
    [Tooltip("The text that displays the score")]
    public Text scoreText; //String that changes depending on the score.
    [Tooltip("The int that is the score")]
    public int gameScore = 0; //Int that changes depending on the score.
    #endregion

    #region Unity Events
    void Update()
    {
        scoreText.text = "Score: " + gameScore; //Changes the UI text combining a string and the gameScore int.
    }
    #endregion
}
