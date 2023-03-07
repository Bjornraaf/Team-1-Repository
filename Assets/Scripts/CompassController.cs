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
    [Tooltip("The target the UI element should point towards")]
    public Transform targetCheckpoint;
    [Tooltip("The UI element that is the compass")]
    public Image compassUI;
    [Tooltip("The maximum angle difference between the compass and the target direction")]
    public float maxAngleDifference = 5.0f;
    [Tooltip("The smoothed compass heading")]
    public float compassHeading;
    [Tooltip("The amount of noise filtering for the smoothed compass")]
    public float filterFactor = 0.05f;
    [Tooltip("The direction text that displays the heading(N, W, E,S)")]
    public Text directionText;

    private float rawHeading; // Raw compass heading value.
    private string directionString = ""; // String that changes depending on the compass direction.

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
    }

    void Update()
    {
        // Assigns the raw heading to the phone's true heading.
        rawHeading = Input.compass.trueHeading;

        // If the compass is on, continue running script.
        if (Input.compass.enabled)
        {
            // Get the direction to the target checkpoint.
            Vector3 targetDirection = targetCheckpoint.position - transform.position;
            targetDirection.y = 0;

            // Apply a low-pass filter to smooth out the heading value.
            compassHeading = Mathf.LerpAngle(compassHeading, rawHeading, filterFactor);
            compassHeading = (compassHeading + 360f) % 360f;

            // Determine the compass direction based on the heading value.
            if (compassHeading >= 315 || compassHeading < 45)
            {
                directionString = "N";
            }
            else if (compassHeading >= 45 && compassHeading < 135)
            {
                directionString = "E";
            }
            else if (compassHeading >= 135 && compassHeading < 225)
            {
                directionString = "S";
            }
            else if (compassHeading >= 225 && compassHeading < 315)
            {
                directionString = "W";
            }

            // Get the angle difference between the compass heading and the target direction.
            float angleDifference = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);

            // Wrap the angle difference to the -180 to 180 range.
            angleDifference = (angleDifference + 180f) % 360f - 180f;

            // Snap the compass heading to 0 or 360 when necessary.
            if (compassHeading <= 0.1f || compassHeading >= 359.9f)
            {
                compassHeading = 0f;
            }

            // Update the UI element to display the compass.
            compassUI.transform.rotation = Quaternion.Euler(0, 0, -compassHeading);
            compassUI.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, angleDifference);
            directionText.text = "Direction: " + directionString;

            // Log the heading and direction to the console.
            Debug.Log("Compass Heading: " + compassHeading.ToString("F2") + " degrees ");
            Debug.Log((rawHeading));
            Debug.Log(directionString);
        }
    }
}