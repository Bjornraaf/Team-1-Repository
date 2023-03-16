using UnityEngine;

/// <summary>  
/// Class rotates the camera by dragging your mouse or by swiping your finger on your phone.
/// </summary>
public class ObjectRotation : MonoBehaviour
{
    #region Variables

    [Tooltip("The speed of the camera when swiping your finger on the screen")]
    public float rotationSpeed = 10f; //Float that determines how quickly the camera rotates.

    private bool isDragging = false; //Bool that determines whether the player is dragging their finger on the screen.
    private Vector2 lastTouchPosition; //Vector2 that stores the posistion of the player's last touch.

    #endregion

    #region Unity Functions

    void Update()
    {
        if (Input.touchCount > 0) //Check if there is a touch on the screen.
        {
            Touch touch = Input.GetTouch(0); //Assign the touch to a variable.

            if (touch.phase == TouchPhase.Began) //Check if the touch has started.
            {
                isDragging = true; //Set isDragging to true.
                lastTouchPosition = touch.position; //Set lastTouchPostion to the current touch position.
            }
            else if (touch.phase == TouchPhase.Moved && isDragging) //If touch is still active execute lines below.
            {
                Vector2 delta = touch.position - lastTouchPosition; //Calculate the distance between the current and last touch position and assign it to a variable.
                float rotationAmount = delta.x * rotationSpeed * Time.deltaTime; //Calculate the amount of rotation that should be applied.
                transform.Rotate(0f, rotationAmount, 0f); //Applies the rotation
                lastTouchPosition = touch.position; //Set lastTouchPostion to the current touch position.
            }
            else if (touch.phase == TouchPhase.Ended) //Check if touch has ended.
            {
                isDragging = false; //Set isDragging to false.
            }
        }
    }

    #endregion
}
