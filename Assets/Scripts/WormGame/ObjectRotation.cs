using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    private bool isDragging = false;
    private Vector2 lastTouchPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 delta = touch.position - lastTouchPosition;
                float rotationAmount = delta.x * rotationSpeed * Time.deltaTime;
                transform.Rotate(0f, rotationAmount, 0f);
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
