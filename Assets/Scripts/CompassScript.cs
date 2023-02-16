using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{ 
    [Range(0,360)]
    public float _compassHeading;
    public float _filterFactor = 0.05f; // Adjust this value to control the amount of filtering
    public float _calibrationTime = 5.0f; // Adjust this value to control the duration of the calibration routine
    public Text directionText;
    public string direction = "";

    private bool _calibrating = false;
    private float _calibrationEndTime;

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        _compassHeading = Input.compass.trueHeading;
    }

    void Update()
    {
        if (Input.compass.enabled)
        {
            // Get the raw compass heading value
            float rawHeading = Input.compass.trueHeading;

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
        }
    }
}
