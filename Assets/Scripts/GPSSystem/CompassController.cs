using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
/// This class grabs the phone's raw compass heading value and uses a low-pass filter to smooth out the raw heading
/// </summary>
/// 
public class CompassController : MonoBehaviour
{
    [Tooltip("The smoothed compass heading")]
    public float compassHeading;
    [Tooltip("The amount of noise filtering for the smoothed compass")]
    public float filterFactor = 0.05f;
    [Tooltip("The direction text that displays the heading(N, W, E,S)")]
    public Text directionText;

    private float RawHeading; // Raw compass heading value.
    private string DirectionString = ""; // String that changes depending on the compass direction.

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
    }

    void Update()
    {
        // Assigns the raw heading to the phone's true heading.
        RawHeading = Input.compass.trueHeading;

        // If the compass is on, continue running script.
        if (Input.compass.enabled)
        {
            // Apply a low-pass filter to smooth out the heading value.
            compassHeading = Mathf.LerpAngle(compassHeading, RawHeading, filterFactor);
            compassHeading = (compassHeading + 360f) % 360f;

            // Determine the compass direction based on the heading value.
            if (compassHeading >= 315 || compassHeading < 45)
            {
                DirectionString = "N";
            }
            else if (compassHeading >= 45 && compassHeading < 135)
            {
                DirectionString = "E";
            }
            else if (compassHeading >= 135 && compassHeading < 225)
            {
                DirectionString = "S";
            }
            else if (compassHeading >= 225 && compassHeading < 315)
            {
                DirectionString = "W";
            }

            // Snap the compass heading to 0 or 360 when necessary.
            if (compassHeading <= 0.1f || compassHeading >= 359.9f)
            {
                compassHeading = 0f;
            }
            
            // Update the UI element to display the compass.
            directionText.text = "Direction: " + DirectionString;

            // Log the heading and direction to the console.
            Debug.Log("Compass Heading: " + compassHeading.ToString("F2") + " degrees ");
            Debug.Log((RawHeading));
            Debug.Log(DirectionString);
        }
    }
}