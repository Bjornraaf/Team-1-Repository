using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    public float _compassHeading;
    public float _filterFactor = 0.05f; // Adjust this value to control the amount of filtering
    public Text directionText;
    public string direction = "";
    public Image arrowImage;
    public Transform targetTransform;
    // Get the raw compass heading value
    public float rawHeading;

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        rawHeading = Input.compass.trueHeading;
    }

    void Update()
    {
        if (Input.compass.enabled)
        {

            // Apply a low-pass filter to smooth out the heading value
            _compassHeading = Mathf.LerpAngle(_compassHeading, rawHeading, _filterFactor);

            // Determine the compass direction based on the heading value
            if (_compassHeading >= 315 || _compassHeading < 45)
            {
                direction = "North";
            }
            else if (_compassHeading >= 45 && _compassHeading < 135)
            {
                direction = "East";
            }
            else if (_compassHeading >= 135 && _compassHeading < 225)
            {
                direction = "South";
            }
            else if (_compassHeading >= 225 && _compassHeading < 315)
            {
                direction = "West";
            }

            // Log the heading and direction to the console
            Debug.Log("Compass Heading: " + _compassHeading.ToString("F2") + " degrees ");
            Debug.Log(direction);

            // Show the direction text in the UI Text object
            directionText.text = "Direction: " + direction;
            
            // Calculate the rotation angle of the arrow
            float arrowRotation = 360 - _compassHeading;

            // Set the rotation of the arrow's RectTransform component
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, arrowRotation);
        }
    }
}
