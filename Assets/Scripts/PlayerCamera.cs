using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
  
    public Transform target; // The object the camera will follow
    public float smoothSpeed = 0.125f; // How smoothly the camera will follow the target
    public float minXBorder; // Minimum X position where camera stops following
    public float maxXBorder; // Maximum X position where camera stops following
    public float minYBorder; // Minimum Y position where camera stops following
    public float maxYBorder; // Maximum Y position where camera stops following

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position;
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minXBorder, maxXBorder);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minYBorder, maxYBorder);
            desiredPosition.z = transform.position.z; // Keep the Z position constant

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
