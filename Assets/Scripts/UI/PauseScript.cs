using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///----------------------------------------$$$$$$$\   $$$$$$\  $$$$$$$\   $$$$$$\  
///----------------------------------------$$  __$$\ $$  __$$\ $$  __$$\ $$$ __$$\ 
///----------------------------------------$$ |  $$ |$$ /  $$ |$$ |  $$ |$$$$\ $$ |
///----------Author------------------------$$$$$$$  |$$$$$$$$ |$$$$$$$  |$$\$$\$$ |
///----------Patryk Podworny---------------$$  ____/ $$  __$$ |$$  ____/ $$ \$$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      $$ |\$$$ |
///----------------------------------------$$ |      $$ |  $$ |$$ |      \$$$$$$  /
///----------------------------------------\__|      \__|  \__|\__|       \______/ 

/// <summary>  
/// Class determines wether the game should be running or not when paused/unpaused.
/// </summary>

public class PauseScript : MonoBehaviour
{
    #region Variables

    private bool isPaused = false; //Bool that determines wether the game should be running or not.

    #endregion

    #region Unity Functions

    void Update()
    {
        PauseGame();
    }

    #endregion

    #region Custom Functions

    /// Check state of isPaused and stop/resume time.
    /// </summary>
    public void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; //Unpause the game
        }
        else
        {
            Time.timeScale = 1f; //Pause the game
        }
    }

    /// Change state of isPaused.
    /// </summary>
    public void Switch()
    {
        isPaused = !isPaused; //Change the boolean state.
    }
    #endregion
}