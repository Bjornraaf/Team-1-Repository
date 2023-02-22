using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shootscript : MonoBehaviour
{
    public GameObject arCamera; // so you can add the camera to raycast
    public GameObject particle; // so you can choose what particle to play
    public Text scoreText; // so you can see your score
    public Text scoreText2; // so you can see your score at the end
     int score = 0;

    public void shoot() //takes care of the shooting mechanic
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
