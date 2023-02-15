using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    private const float AVERAGE_TIME_WINDOW = 2.0f;
    private List<float> headingHistory = new List<float>();
    public Text directionText;

    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
    }
    void Update()
    {
        // Check if the compass is enabled
        if (Input.compass.enabled)
        {
            // Get the current heading from the device's compass in degrees
            float heading = Input.compass.trueHeading;

            // Add the current heading to the history
            headingHistory.Add(heading);

            // Remove any old heading values from the history
            while (headingHistory.Count > 0 && headingHistory[0] < Time.time - AVERAGE_TIME_WINDOW)
            {
                headingHistory.RemoveAt(0);
            }

            // Calculate the rolling average of the heading over the past 5 seconds
            float averageHeading = 0.0f;
            if (headingHistory.Count > 0)
            {
                foreach (float h in headingHistory)
                {
                    averageHeading += h;
                }
                averageHeading /= headingHistory.Count;
            }

            // Determine the compass direction based on the average heading value
            string direction = "";
            if (averageHeading >= 315 || averageHeading < 45)
            {
                direction = "North";
            }
            else if (averageHeading >= 45 && averageHeading < 135)
            {
                direction = "East";
            }
            else if (averageHeading >= 135 && averageHeading < 225)
            {
                direction = "South";
            }
            else if (averageHeading >= 225 && averageHeading < 315)
            {
                direction = "West";
            }

            // Log the average heading and direction to the console
            Debug.Log("Average Compass Heading: " + averageHeading.ToString("F2") + " degrees ");
            
            // Log the heading and direction to the console
            Debug.Log("Compass Heading: " + heading.ToString("F2") + " degrees ");
            Debug.Log((direction));
            
            // Show the direction text in the UI Text object
            directionText.text = "Direction: " + direction;
        }
        else
        {
            // Log an error message if the compass is not enabled
            Debug.LogError("Compass is not enabled on this device");
        }
    }
}
