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
/// Class keeps track of the player health and calls the endScore script to end the game.
/// </summary>

public class HealthScript : MonoBehaviour
{
    #region Variables

    [Tooltip("The int that equals to the player's health")]
    public int healthAmount = 3; //Int that changes depending on the player's health;

    [Tooltip("The Game Over UI Element")]
    public GameObject endScreen; //UI Element that is enabled when the game ends.

    [Tooltip("The script that displays the ending score and disables unneeded UI elements")]
    public EndScoreScript endScoreScript; //Script that shows game over screen and the score.

    [Tooltip("The array of UI player hearts")]
    public GameObject[] playerHearts; //GameObject array that equals to the player's hearts


    #endregion

    #region Unity Functions

    void Update()
    {
        if (healthAmount == 2) //If health is equal to 2.
        {
            playerHearts[2].SetActive(false); //Disable the first heart.
        }

        if (healthAmount == 1) //If health is equal to 1.
        {
            playerHearts[1].SetActive(false); //Disable the second heart.
        }

        if (healthAmount == 0) //If health is equal to 0.
        {
            playerHearts[0].SetActive(false); //Disable the third heart.
            Time.timeScale = 0f; //Stop/Pause the game.
            endScreen.SetActive(true); //Turn on the game over screen.
            endScoreScript.endGame(); //Call endScoreScript to show the score and disable UI elements.
        }
    }

    #endregion
}
