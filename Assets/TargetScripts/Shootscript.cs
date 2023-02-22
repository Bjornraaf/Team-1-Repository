using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shootscript : MonoBehaviour
{
    [SerializeField] private GameObject arCamera; // so you can add the camera to raycast
    [SerializeField] private GameObject particle; // so you can choose what particle to play
    [SerializeField] private Text scoreText; // so you can see your score
    [SerializeField] private  Text scoreText2; // so you can see your score at the end
     int score = 0;

    /// <summary>
    /// this takes care of all the shooting by using the raycast of the camera to see if it hits the object with a specific name and adds a point to the player's score
    /// </summary>
    public void Shoot() //takes care of the shooting mechanic
    {
            RaycastHit hit;
        
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)) //checks if the raycast hits the object
        {
            if (hit.transform.name == "seed(Clone)"    || hit.transform.name == "object 2(Clone)"   || hit.transform.name == "object 3(Clone)")
            {
                Destroy(hit.transform.gameObject); //destroys the object
                Instantiate(particle, hit.point, Quaternion.LookRotation(hit.normal));
                score += 1; //adds score
                scoreText.text = score.ToString() + " Points"; //shows the score in the upper right corner
                scoreText2.text = score.ToString() + " Points"; //shows the text at the end of the game
            }
        }
    }
}
