using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform target; // Reference to the player's Transform
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Camera offset from the player
    public float smoothSpeed = 5f; // Speed at which the camera follows the player

    // Method to update the camera's rotation based on the surface normal
    public void UpdateCameraRotation(Vector3 surfaceNormal)
    {
        // Invert the normal to flip the camera's up vector as needed
        Vector3 newUp = -surfaceNormal;
        // Smoothly interpolate the camera's up vector towards the new up vector
        Vector3 smoothedUp = Vector3.Lerp(transform.up, newUp, smoothSpeed * Time.deltaTime);
        // Adjust the camera's rotation while maintaining its current look direction
        transform.rotation = Quaternion.LookRotation(transform.forward, smoothedUp);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
