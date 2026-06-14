using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Public Variables
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 5f;

    // 
    void LateUpdate()
    {
        // Only use the car's left/right rotation
        Quaternion yawRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);

        // Sets the desired position of the camera
        Vector3 desiredPosition = target.position + yawRotation * offset;

        // sets the position of the camera
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // Look at the car but keep camera upright
        transform.LookAt(target.position + Vector3.up * 2f);
    }

    
}
