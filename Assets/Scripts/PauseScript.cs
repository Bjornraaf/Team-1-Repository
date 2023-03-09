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

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f; // unpause the game
        }
        else
        {
            Time.timeScale = 1f; // pause the game
        }
    }

    public void Switch()
    {
        isPaused = !isPaused;
        Debug.Log("switch");
        Time.timeScale = 0f; 
    }
}