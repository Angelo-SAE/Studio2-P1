using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float horizontal, vertical, moveSpeed, magnetForce, rotationSpeed, highVel;
    [Header("Car Tings")]
    [SerializeField] private float BLANK;
    [SerializeField] private float motorTorque, brakeTorque, maxSpeed, steeringRange, steeringRangeAtMaxSpeed;

    WheelControls[] wheels;


    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody>();
      wheels = GetComponentsInChildren<WheelControls>();
    }

    void Update()
    {
      Movement();
      MagnetForce();
    }

    private void Movement()
    {
      horizontal = Input.GetAxis("Horizontal");
      vertical = Input.GetAxis("Vertical");

      //need to look into more
      float forwardSpeed = Vector3.Dot(transform.forward, rb.velocity);
      float speedFactor = Mathf.InverseLerp(0, maxSpeed, Mathf.Abs(forwardSpeed));
      float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
      float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
      bool isAccelerating = Mathf.Sign(vertical) == Mathf.Sign(forwardSpeed);

      foreach(var wheel in wheels)
      {
        if(wheel.steerable)
        {
          wheel.wheelCollider.steerAngle = horizontal * currentSteerRange;
        }

        if(isAccelerating)
        {
          if(wheel.motorized)
          {
            wheel.wheelCollider.motorTorque = vertical * currentMotorTorque;
          }
          wheel.wheelCollider.brakeTorque = 0;
        } else {
          wheel.wheelCollider.brakeTorque = Mathf.Abs(vertical) * brakeTorque;
          wheel.wheelCollider.motorTorque = 0;
        }
        //need to look into more

        if(Input.GetButton("Brake"))
        {
          wheel.wheelCollider.brakeTorque = brakeTorque * 1;
        }
      }
    }

    //private void Movement()
    //{
    //  horizontal = Input.GetAxis("Horizontal");
    //  vertical = Input.GetAxis("Vertical");
    //
    //  if(rb.velocity.x < maxSpeed && rb.velocity.y < maxSpeed && rb.velocity.z < maxSpeed && rb.velocity.x > -maxSpeed && rb.velocity.y > -maxSpeed && rb.velocity.z > -maxSpeed)
    //  {
    //  rb.AddForce(transform.forward * vertical * moveSpeed, ForceMode.Acceleration);
    //  }
    //
    //  if(horizontal > 0 || horizontal < 0)
    //  {
    //    transform.Rotate(0f, horizontal * rotationSpeed, 0f,Space.Self);
    //  }
    //}

    private void MagnetForce()
    {
      RaycastHit hit;
      foreach(var wheel in wheels)
      {
        if(Physics.Raycast(wheel.gameObject.transform.position, -wheel.gameObject.transform.up, 3f))
        {
          Physics.Raycast(wheel.gameObject.transform.position, -wheel.gameObject.transform.up, out hit);
          rb.AddForce((hit.point - wheel.gameObject.transform.position) * magnetForce, ForceMode.Force);
        }
      }

    }
}
