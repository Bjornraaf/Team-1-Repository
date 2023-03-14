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

public class HealthScript : MonoBehaviour
{
    public int healthAmount = 3;
    public GameObject[] playerHearts;
    public GameObject endScreen;
    public EndScore endScore;
    
    void Update()
    {
        if (healthAmount == 2)
        {
            playerHearts[2].SetActive(false);
        }
        
        if (healthAmount == 1)
        {
            playerHearts[1].SetActive(false);
        }

        if (healthAmount == 0)
        {
            playerHearts[0].SetActive(false);
            Time.timeScale = 0f;
            endScreen.SetActive(true);
            endScore.endGame();
        }
    }
}
