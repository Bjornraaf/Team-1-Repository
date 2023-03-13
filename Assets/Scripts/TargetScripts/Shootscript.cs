using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shootscript : MonoBehaviour
{
    // So you can add the camera to raycast.
    [Header("ARCamera")]
    [SerializeField] private GameObject ARCamera;
    // So you can choose what particle to play.
    [Header("Particle")]
    [SerializeField] private GameObject Particle;
    // So you can see your score at the end.
    [Header("Score")]
    [SerializeField] private Text EndScoreText; 
    // The score asset
    private int Score = 0;

    /// <summary>
    /// This takes care of all the shooting by using the raycast of the camera to see if it hits the object with a specific name and adds a point to the player's score.
    /// </summary>
    public void Shoot()
    {
            RaycastHit hit;

        //Checks if the raycast hits the object.
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "Seed(Clone)" )
            {
                //Destroys the object.
                Destroy(hit.transform.gameObject); 
                Instantiate(Particle, hit.point, Quaternion.LookRotation(hit.normal));
                //Adds score.
                Score += 1;
                //Shows the score in the upper right corner.
                GameObject.Find("Score").GetComponent<Text>().text = Score.ToString() + " Points";
                //Shows the text at the end of the game.
                EndScoreText.text = Score.ToString() + " Points"; 
            }
        }
    }
}
