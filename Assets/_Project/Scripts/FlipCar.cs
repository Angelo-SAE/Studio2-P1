using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCar : MonoBehaviour
{

    private Rigidbody rb;
    private bool canFlip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      if(!TimeTracker.isDead)
      {
        CheckFlip();
        CarFlip();
      }
    }


    private void CheckFlip()
    {
      if(Physics.Raycast(transform.position, transform.up))
      {
        canFlip = true;
      } else {
        canFlip = false;
      }
    }

    private void CarFlip()
    {
      if(Input.GetButtonDown("Flip") && canFlip)
      {
        transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        var carFront = transform.forward;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.rotation = Quaternion.LookRotation(carFront);
        rb.freezeRotation = true;
        rb.freezeRotation = false;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.None;
      }
    }
}
