using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraRotation : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public float verticalRotationLimit = 60.0f; // Adjust as needed
    public float horizontalRotationLimit = 90.0f; // Adjust as needed

    private Vector2 lastTouchPosition;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;


    void FixedUpdate()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check the phase of the touch
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Record the starting touch position
                    lastTouchPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    // Calculate the delta position
                    Vector2 deltaPosition = touch.position - lastTouchPosition;

                    // Rotate the camera based on touch movement
                    rotationX -= deltaPosition.y * rotationSpeed * Time.deltaTime;
                    rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);

                    rotationY += deltaPosition.x * rotationSpeed * Time.deltaTime;
                    rotationY = Mathf.Clamp(rotationY, -horizontalRotationLimit, horizontalRotationLimit);

                    transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Fire");
                    break;
            }

            // Update the last touch position
            lastTouchPosition = touch.position;
        }
    }
}
