using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float moveForce; // The force to apply when moving the ball
    public float moveForceDefault; // The value for moveForce to reset to
    public float jumpForce; // The force to apply when jumping
    public float maxSpeed; // The maximum speed of the ball
    public int maxJumps; // Maximum number of jumps (including initial jump)
    private int jumpsRemaining; // Number of jumps remaining
    public Rigidbody rb; // The Rigidbody component of the ball
    public Transform playerCamera; // Reference to the camera transform
    public float downforceStrength = 20f;
    private Vector3 forceDirection;
    public bool touchingPipe;
    public CameraTest cameraTestScript; // Reference to the CameraTest script

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 cameraForward = playerCamera.forward;
        Vector3 cameraRight = playerCamera.right;
        cameraForward.y = 0; // Ignore vertical camera rotation
        cameraRight.y = 0;

        if (!touchingPipe)
        {
            forceDirection = cameraRight;
        }

        Vector3 movement = (cameraForward * moveVertical + forceDirection * moveHorizontal).normalized;

        if (movement.magnitude > 0.1f)
        {
            rb.AddForce(movement * moveForce, ForceMode.Impulse);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            moveForce = 0f;
        }
        else
        {
            moveForce = moveForceDefault;
        }

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsRemaining--;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            touchingPipe = true;
            Vector3 averageNormal = Vector3.zero;
            foreach (ContactPoint contact in collision.contacts)
            {
                averageNormal += contact.normal;
            }
            averageNormal /= collision.contacts.Length;

            forceDirection = Vector3.Cross(averageNormal, playerCamera.forward).normalized;

            if (cameraTestScript != null)
            {
                cameraTestScript.UpdateCameraRotation(averageNormal);
            }

            rb.AddForce(-averageNormal * downforceStrength, ForceMode.Acceleration);
            rb.useGravity = false;
            jumpsRemaining = maxJumps;
        }
        else
        {
            touchingPipe = false;
            if (cameraTestScript != null)
            {
                cameraTestScript.UpdateCameraRotation(Vector3.up); // Reset camera when not touching the pipe
            }
        }
    }
}
